using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using PharmInventory.Forms.Modals;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;
using StockoutIndexBuilder;
using IssueDoc = BLL.IssueDoc;
using ItemUnit = BLL.ItemUnit;
using ReceiveDoc = BLL.ReceiveDoc;


namespace PharmInventory.Forms.Transactions
{
    /// <summary>
    /// This form is for issuing items.
    /// The following fields will be required
    /// Item Name,
    /// Dispensary Unit,
    /// Reference Number,
    /// Date of Issue,
    /// Dispensary Unit Remaining Stock on hand (DUSOH),
    /// Pack Qty,
    /// Qty/Pack,
    /// After receiving the following as an input, the form generates a pick list for printing and the issue is confirmed.
    /// </summary>
    public partial class IssueForm : XtraForm
    {
        public IssueForm()
        {
            InitializeComponent();
        }

        #region Members
        DataTable _dtRec = new DataTable();
        int _tabPage = 0;
        int _catID = 0;
        String _selectedType = "Drug";
        DataTable _dtSelectedTable = null;

        #endregion

        /// <summary>
        /// Load all the stores and put them in the combo box
        /// Set the logged in user name in the issued by text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IssuingForm_Load(object sender, EventArgs e)
        {
            var unitcolumn = ((GridView)gridItemsChoice.MainView).Columns[4];
            var unitid = ((GridView)issueGrid.MainView).Columns[14];
            var unitcolumn1 = ((GridView)issueGrid.MainView).Columns[2];
            var duamc = ((GridView)issueGrid.MainView).Columns[8];
            var mrdusoh = ((GridView)issueGrid.MainView).Columns[6];
            var recommendedqty = ((GridView)issueGrid.MainView).Columns[9];
            var requestedqty = ((GridView)issueGrid.MainView).Columns[12];
            var qtyperpack = ((GridView)issueGrid.MainView).Columns[11];
            var unitcolumn3 = ((GridView)gridItemsChoice.MainView).Columns[14];
            switch (VisibilitySetting.HandleUnits)
            {
                case 3:
                    unitcolumn.Visible = false;
                    unitcolumn1.Visible = false;
                    unitid.Visible = true;
                    qtyperpack.Visible = true;
                    mrdusoh.Visible = true;
                    duamc.Visible = true;
                    recommendedqty.Visible = true;
                    duamc.Visible = true;
                    requestedqty.Visible = false;
                    unitcolumn3.Visible = true;
                    break;
                case 2:
                    unitcolumn.Visible = false;
                    unitcolumn1.Visible = false;
                    unitid.Visible = true;
                    qtyperpack.Visible = true;
                    mrdusoh.Visible = false;
                    recommendedqty.Visible = false;
                    duamc.Visible = false;
                    requestedqty.Visible = false;
                    unitcolumn3.Visible = true;
                    break;
                default:
                    unitcolumn.Visible = true;
                    unitcolumn1.Visible = true;
                    unitid.Visible = false;
                    qtyperpack.Visible = true;
                    duamc.Visible = true;
                    unitcolumn3.Visible = false;
                    break;
            }

            PopulateCatTree(_selectedType);
            var stor = new Stores();
            stor.GetActiveStores();
            storebindingSource.DataSource = stor.DefaultView;
            cboStores.Properties.DataSource = storebindingSource.DataSource;
            cboStores.ItemIndex = 0;
            cboStores.Properties.DisplayMember = "StoreName";
            cboStores.Properties.ValueMember = "ID";
            cboStoreConf.Properties.DataSource = stor.DefaultView;
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCategories.ItemIndex = 0;

            var unit = new ItemUnit();
            var xx = unit.GetAllUnits();
            UnitsbindingSource.DataSource = xx.DefaultView;

            var userID = MainWindow.LoggedinId;
            var us = new User();
            us.LoadByPrimaryKey(userID);
            txtIssuedBy.Text = us.FullName;

            if (!chkExcludeStockedOut.Checked)
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
        }

        private void PopulateCatTree(String type)
        {
            if (type == "Drug")
            {
                var cat = new Category();
                treeCategory.DataSource = cat.GetCategoryTree();
            }
            else
            {
                var subCat = new SupplyCategory();
                treeCategory.DataSource = subCat.GetAllSupplyCategories();
            }
        }

        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));
            _catID = categoryId;
            var itm = new Items();
            string filterString = "";
            string isStock = ((ckStockOut.Checked) ? "[Status] = 'Stock Out' AND " : "[Status] != 'Stock Out' AND ");
            switch (value.Substring(0, 1))
            {

                case "S":
                    filterString = isStock + "[SubCategoryID] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;
                    break;
                case "C":
                case "U":
                    filterString = isStock + "[CategoryId] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;
                    break;
                case "P":
                    gridItemChoiceView.ActiveFilterString = ((ckStockOut.Checked) ? "[Status] = 'Stock Out'" : "[Status] != 'Stock Out'");
                    break;
            }
            gridItemChoiceView.ClearSelection();
            gridItemChoiceView.SelectRow(0);
        }

        public void PopulateItemList()
        {
            if (!bw.IsBusy)
            {
                dtIssueDate.Value = DateTime.Now;
                dtIssueDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                var storeID = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
                bw.RunWorkerAsync(storeID);
            }
        }

        DataTable _dtRecGrid = new DataTable();

        /// <summary>
        /// Validate the input based on which tab is active right now. And retuns true if input is valid.
        /// When the input is invalid, the function returns false.
        /// </summary>
        /// <returns>True - If input is valid, False - If input is invalid</returns>
        private bool Validation()
        {
            var inventory = new YearEnd();
            if (_tabPage == 0)
            {
                if (_dtSelectedTable != null && _dtSelectedTable.Rows.Count > 0 && gridItemChoiceView.SelectedRowsCount > 0)
                {
                    PopulateGridList();
                }
                else
                {
                    XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else if (_tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    _tabPage = tabControl1.SelectedTabPageIndex;
                if (tabControl1.SelectedTabPageIndex == 2)
                {
                    PopulatePickList();

                }
            }
            else if (_tabPage == 2)
            {
                if (tabControl1.SelectedTabPageIndex != 2)
                    _tabPage = tabControl1.SelectedTabPageIndex;
            }
            else if(inventory.DoesBalanceExist(2006 ,10 ,false) ==false)
            {
                XtraMessageBox.Show("You must enter Inventory data before issue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            Validation();
        }

        /// <summary>
        /// Populates the grid based on the selection.
        /// </summary>

        private void PopulateGridList()
        {
            if (issueGrid.DataSource != null)
            {
                var dt = new DataTable();
                issueGrid.DataSource = dt;
                _dtRecGrid.Rows.Clear();
                _dtRecGrid.Columns.Clear();
            }

            var itm = new Items();
            var itmB = new Items();
            var bal = new Balance();
            _tabPage = 1;
            tabControl1.SelectedTabPageIndex = 1;

            if (_dtRecGrid.Columns.Count == 0)
            {
                string[] str = { "ID", "Stock Code", "Item Name", "Unit", "Store SOH", "Dispatchable", "MR Issue Qty", 
                                   "DU Remaining SOH", "DU AMC", "Recommended Qty", "Pack Qty", "Qty Per Pack", 
                                   "Requested Qty", "MR DU SOH","UnitID"};
                foreach (string col in str)
                {
                    _dtRecGrid.Columns.Add(col);
                }
            }

            int count = 1;
            Int64 quantity = 0;
            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            var dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            if (_dtSelectedTable != null)
                foreach (DataRow lst in _dtSelectedTable.Rows)//(ListViewItem lst in lstItem.Items)
                {
                    var itmID = Convert.ToInt32(lst["ID"]);
                    var dtExp = itm.GetExpiredItemsByID(Convert.ToInt32(cboStores.EditValue), itmID);
                    var dtItm = itm.GetItemById(itmID);
                    Int64 expAmount = 0;
                    foreach (DataRow dr in dtExp.Rows)
                    {
                        expAmount = itmB.GetExpiredQtyItemsByID(Convert.ToInt32(dr["ID"]), Convert.ToInt32(cboStores.EditValue));
                        quantity = Convert.ToInt64(dr["Quantity"]) - expAmount;//+ adjQuant - issuedQuant - lostQuant 
                    }
                    Int64 soh = 0;
                    Int64 dispatchable = Convert.ToInt64(lst["Dispatchable"]);

                    object[] obj;
                    string itemName = lst["FullItemName"].ToString();
                    switch (VisibilitySetting.HandleUnits)
                    {
                        case 1:
                            soh = bal.GetSOH(itmID, Convert.ToInt32(cboStores.EditValue), dtCurrent.Month, dtCurrent.Year);
                            obj = new object[] {itmID.ToString(), dtItm.Rows[0]["StockCode"].ToString(), itemName, dtItm.Rows[0]["Unit"].ToString(), 
                                                soh, dispatchable, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                            break;
                        case 2:
                            soh = bal.GetSOHByUnit(itmID, Convert.ToInt32(cboStores.EditValue), dtCurrent.Month, dtCurrent.Year, Convert.ToInt32(lst["UnitID"]));
                            obj = new object[]{ itmID.ToString(), dtItm.Rows[0]["StockCode"].ToString(), 
                                                itemName, dtItm.Rows[0]["Unit"].ToString(), 
                                                soh, dispatchable, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lst["UnitID"])};
                            break;
                        default:
                            soh = bal.GetSOHByUnit(itmID, Convert.ToInt32(cboStores.EditValue), dtCurrent.Month, dtCurrent.Year, Convert.ToInt32(lst["UnitID"]));
                            obj = new object[]{ itmID.ToString(), dtItm.Rows[0]["StockCode"].ToString(), 
                                                itemName, dtItm.Rows[0]["Unit"].ToString(), 
                                                soh, dispatchable, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lst["UnitID"])};
                            break;
                    }

                    //if (expAmount < soh && quantity < soh || dispatchable > 0)
                    //{
                    //    _dtRecGrid.Rows.Add(obj);
                    //    count++;
                    //}

                    if (expAmount < soh && dispatchable > 0)
                    {
                        _dtRecGrid.Rows.Add(obj);
                        count++;
                    }
                    else if(soh >0 && dispatchable==0)
                    {
                        XtraMessageBox.Show(String.Format("{0} Is Expired!", itemName), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ResetValues();
                        tabControl1.TabIndex = 0;
                        break;
                    }
                    else if (soh == 0)
                    {
                      XtraMessageBox.Show(String.Format("{0} is stocked out!", itemName), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }
                    else if (expAmount == soh && expAmount != 0)
                    {
                        XtraMessageBox.Show(String.Format("{0} Is Expired!",itemName), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ResetValues();
                        tabControl1.TabIndex = 0;
                        break;
                    }
                    else if( dispatchable>0 )
                    {
                        _dtRecGrid.Rows.Add(obj);
                        count++;
                    }
                    else
                    {
                        ResetValues();
                        XtraMessageBox.Show("You are trying to issue an Expired item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        tabControl1.TabIndex = 0;
                        break;
                    }
                }

            issueGrid.DataSource = _dtRecGrid;
            cboStoreConf.EditValue = cboStores.EditValue;
            dtIssueDate.CustomFormat = "MMM dd,yyyy";

            var recUnit = new ReceivingUnits();
            recUnit.GetActiveDispensaries();
            cboReceivingUnits.Properties.DataSource = recUnit.DefaultView;
            cboReceivingUnits.Properties.DisplayMember = "Name";
            cboReceivingUnits.Properties.ValueMember = "ID";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PopulatePickList();
        }


        /// <summary>
        /// Populates the picklist based on the selected issue configuration
        /// </summary>
        private void PopulatePickList()
        {
            
            var valid = ValidateFields();

            if (valid == "true")
            {
                var iss = new IssueDoc();
                var rec = new ReceiveDoc();
                var bal = new Balance();
                var itmB = new Items();
                var DUs = new ReceivingUnits();

                var dtIssueConf = new DataTable();
                string[] strr = { "No", "Stock Code", "Item Name", "Quantity", "BatchNo", "Expiry Date", "Pack Price", "Total Price",
                                    "ItemId", "RecId", "Unit Price", "No of Pack", "Qty per pack",
                                    "DUSOH", "DUAMC", "Near Expiry", "DURecomended","SOH Left","UnitID" };
                foreach (string col in strr)
                {
                    dtIssueConf.Columns.Add(col);
                }

                DUs.LoadByPrimaryKey(Convert.ToInt32(cboReceivingUnits.EditValue));
                double duMax = 0.5;
                try
                {
                    duMax = DUs.Max;
                }
                catch { }
                double duMaxDays = duMax * 30;
                lblNearExpiryComment.Text = "*Near Expiry means items that has expiry in the next " + duMaxDays.ToString() + " Days.";

                DateTime xx = dtIssueDate.Value;
                dtIssueDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtIss = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = DateTime.Now;

                DateTime dtCurrent = new DateTime();// Convert.ToDateTime(dtIssueDate.Text);
                dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = xx;
                dtIssueDate.CustomFormat = "MMM dd,yyyy";
                var dtIssueGrid = (DataTable)issueGrid.DataSource;
                for (int i = 0; i < dtIssueGrid.Rows.Count; i++)
                {
                    var unitid = Convert.ToInt32(dtIssueGrid.Rows[i]["UnitID"]);
                    Int64 expAmount = itmB.GetExpiredQtyItemsByID(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue));
                    Int64 sohQty = 0;
                    try
                    {
                       
                        switch (VisibilitySetting.HandleUnits)
                        {

                            case 1:
                                sohQty = bal.GetSOH(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue), dtIss.Month, dtIss.Year) - expAmount;
                                break;
                            case 2:
                                sohQty = bal.GetSOHByUnit(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue), dtIss.Month, dtIss.Year, unitid) - expAmount;
                                break;
                            case 3:
                                sohQty = bal.GetSOHByUnit(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(cboStores.EditValue), dtIss.Month, dtIss.Year, unitid) - expAmount;
                                break;
                        }
                    }
                    catch
                    {
                        XtraMessageBox.Show("Please check all the information you have input into the form including the issue date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    if (sohQty >= Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]))
                    {
                        var itm = new Items();
                        itm.LoadByPrimaryKey(Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]));
                        if (itm.IsColumnNull("NeedExpiryBatch"))
                        {
                            itm.NeedExpiryBatch = true;
                            itm.Save();
                        }
                        if (itm.NeedExpiryBatch && VisibilitySetting.HandleUnits == 1)
                        {
                            _dtRec = rec.GetBatchToIssue(Convert.ToInt32(cboStores.EditValue),
                                                         Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), dtIss);
                        }
                        else if (itm.NeedExpiryBatch && VisibilitySetting.HandleUnits == 2)
                        {
                            _dtRec = rec.GetBatchToIssueByUnit(Convert.ToInt32(cboStores.EditValue),
                                                        Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), dtIss ,unitid);
                        }
                        else if (itm.NeedExpiryBatch && VisibilitySetting.HandleUnits == 3)
                        {
                            _dtRec = rec.GetBatchToIssueByUnit(Convert.ToInt32(cboStores.EditValue),
                                                        Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), dtIss, unitid);
                        }
                        else
                            _dtRec = rec.GetSupplyToIssueWithOutBatch(Convert.ToInt32(cboStores.EditValue),
                                                                      Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]),
                                                                      dtIssueDate.Value);

                        // Extream measures:
                        // This has tobe properly mitigated
                        // if there is the balance an there is no batch to be issued, just select the last batch and add the balance to it.



                        if (rec.RowCount > 0)
                        {
                            int j = 0;
                            Int64 quantity = 0;
                            double sohbalance = 0;
                            switch (VisibilitySetting.HandleUnits)
                            {
                                case 1:
                                    quantity = Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]);
                                    sohbalance = sohQty - quantity;
                                    break;
                                case 2:
                                    quantity = Convert.ToInt64(dtIssueGrid.Rows[i]["Pack Qty"]);
                                    sohbalance = sohQty - quantity;
                                    break;
                                default:
                                    quantity = Convert.ToInt64(dtIssueGrid.Rows[i]["Pack Qty"]);
                                    sohbalance = sohQty - quantity;
                                    break;
                            }

                            while (quantity >=0 && rec.RowCount > j)
                            {
                                var batch = itm.NeedExpiryBatch ? _dtRec.Rows[j]["BatchNo"].ToString() : "";
                                Int64 qu = ((quantity > Convert.ToInt32(_dtRec.Rows[j]["QuantityLeft"])) ? Convert.ToInt64(_dtRec.Rows[j]["QuantityLeft"]) : quantity);
                                double qtyPerPack = Convert.ToDouble(_dtRec.Rows[j]["QtyPerPack"]);
                                double unitPrice = Convert.ToDouble(_dtRec.Rows[j]["Cost"]);
                                double packPrice = unitPrice * qtyPerPack; //Convert.ToDouble(dtIssueGrid.Rows[i]["Qty Per Pack"]);
                                double reqPackQty = Convert.ToDouble(dtIssueGrid.Rows[i]["Pack Qty"]);
                                double totPrice = unitPrice * qu;
                                bool nearExp = false;
                                DateTime? dtx = new DateTime();

                                switch (VisibilitySetting.HandleUnits)
                                {
                                    case 1:
                                        rec.UnitID = 0;
                                        rec.QtyPerPack = Convert.ToInt32(dtIssueGrid.Rows[i]["Qty Per Pack"]);
                                        break;
                                    case 2:
                                        rec.UnitID = Convert.ToInt32(dtIssueGrid.Rows[i]["UnitID"]);
                                        rec.QtyPerPack = 1;
                                        break;
                                    case 3:
                                        rec.UnitID = Convert.ToInt32(dtIssueGrid.Rows[i]["UnitID"]);
                                        rec.QtyPerPack = 1;
                                        break;
                                }

                                if (itm.NeedExpiryBatch)
                                {
                                    dtx = Convert.ToDateTime(_dtRec.Rows[j]["ExpDate"]);
                                    if (dtx <= DateTime.Now.AddDays(duMaxDays))
                                        nearExp = true;
                                }
                                else if (!itm.NeedExpiryBatch)
                                {
                                    dtx = null;
                                    // nearExp = false;
                                }
                                int rowNo = j + 1;

                                object[] obj = { rowNo, dtIssueGrid.Rows[i]["Stock Code"], 
                                                     dtIssueGrid.Rows[i]["Item Name"], qu, batch,dtx, 
                                                     packPrice.ToString("#,##0.#0"), ((totPrice != double.NaN) ? totPrice.ToString("#,##0.#0") : "0"), 
                                                     Convert.ToInt32(dtIssueGrid.Rows[i]["ID"]), Convert.ToInt32(_dtRec.Rows[j]["ID"]), unitPrice.ToString("#,##0.00"), 
                                                     dtIssueGrid.Rows[i]["Pack Qty"], dtIssueGrid.Rows[i]["Qty Per Pack"], dtIssueGrid.Rows[i]["DU Remaining SOH"],
                                                     dtIssueGrid.Rows[i]["DU AMC"], ((nearExp) ? "Yes" : "No"), dtIssueGrid.Rows[i]["Recommended Qty"],
                                                     sohbalance,dtIssueGrid.Rows[i]["UnitID"]};
                                dtIssueConf.Rows.Add(obj);

                                quantity = quantity - Convert.ToInt64(_dtRec.Rows[j]["QuantityLeft"]);
                                j++;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("There is no enough Quantity in the store OR It has expired. Please check the issue date, quantity and try again!");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("There is not enough Quantity in the store OR It has expired. Please check the issue date, quantity and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (dtIssueConf.Rows.Count > 0)
                {
                    _tabPage = 2;

                    tabControl1.SelectedTabPageIndex = 2;
                    txtConfRef.Text = txtRefNo.Text;
                    txtIssuedDate.Value = dtIssueDate.Value;
                    txtIssuedTo.Text = cboReceivingUnits.Text;

                    txtStore.Text = cboStores.Text;
                    txtConIssuedBy.Text = txtIssuedBy.Text;
                    txtConRemark.Text = txtRemark.Text;
                    txtConRecipientName.Text = txtRecipientName.Text;
                    gridConfirmation.DataSource = dtIssueConf;
                }
            }
            else
            {
                tabControl1.SelectedTabPageIndex = 1;
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (chkExcludeStockedOut.Checked)
                gridItemChoiceView.ActiveFilterString = string.Format("[Status] != 'Stock Out' AND [FullItemName] Like '{0}%' and [TypeID]={1}", txtItemName.Text, (int)lkCategories.EditValue);
            else if (!ckStockOut.Checked)
            {
                gridItemChoiceView.ActiveFilterString = string.Format("[FullItemName] Like '{0}%' and TypeID ={1} ", txtItemName.Text, (int)lkCategories.EditValue);
            }
        }

        /// <summary>
        /// Validate the fields in the issue form
        /// </summary>
        /// <returns>"true" is returned if valid; if invalid, the error description is returned as a string which 
        /// can be used in the message displayed to the user.
        /// </returns>
        private string ValidateFields()
        {
            dtIssueDate.Value =DateTime.Now;
            var dtCurent = new DateTime();
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            //  CALENDAR:
            string valid = "true";
            
            if (!dxValidationProvider1.Validate())
            {
                valid = "All * marked fields are required!";
            }
            if (Convert.ToDateTime(dtIssueDate.Value).Date > DateTime.Now.Date)
            {
                valid = "You cannot pick a Date into the future!";
            }

            if (dtIssueDate.IsGregorianCurrentCalendar)
            {
                valid = "The Date has to be in Ethiopian Calander.";
            }

            var dtIssueGrid = (DataTable)issueGrid.DataSource;
            if (dtIssueGrid != null)
                for (int i = 0; i < dtIssueGrid.Rows.Count; i++)
                {
                   
                    if (VisibilitySetting.HandleUnits == 1)
                    {
                        if (Convert.ToInt64(dtIssueGrid.Rows[i]["Requested Qty"]) >
                            Convert.ToInt64(dtIssueGrid.Rows[i]["Dispatchable"]))
                        {
                            dtIssueGrid.Rows[i].SetColumnError("Requested Qty",
                                                               "Requested quantity cannot be greater than the usable stock!");
                            valid = "Requested quantity cannot be greater than the usable stock!";
                        }
                    }
                }

            return valid;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var confirmedItemsQuantity = new Dictionary<int, long>();
            var confirmedItems = new List<int>();
            var valid = ValidateFields();
            if (valid == "true")
            {
                if (XtraMessageBox.Show("Are You Sure, You Want To Save This Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var issDoc = new IssueDoc();
                    var recDoc = new ReceiveDoc();
                    DataTable dtConfirm;
                    long currentSOH = 0;
                    var storeId = 0;
                    var itemId = 0;

                    using (dtConfirm = (DataTable)gridConfirmation.DataSource)
                    {
                        for (int i = 0; i < dtConfirm.Rows.Count; i++)
                        {
                           var receivedocid = Convert.ToInt32(dtConfirm.Rows[i]["RecId"]);
                            issDoc.GetDULastIssue(Convert.ToInt32(dtConfirm.Rows[i]["ItemID"]), Convert.ToInt32(cboReceivingUnits.EditValue));
                            confirmedItems.Add(Convert.ToInt32(dtConfirm.Rows[i]["ItemID"]));
                            if (issDoc.RowCount > 0)
                            {
                                //issDoc.DUSOH = ((dtConfirmation.Rows[i]["DUSOH"] != null) ? Convert.ToInt64(dtConfirmation.Rows[i]["DUSOH"]) : 0);
                                //issDoc.Save();
                            }
                            //Saving the issue
                            issDoc.AddNew();
                            issDoc.StoreId = Convert.ToInt32(cboStores.EditValue);
                            issDoc.RefNo = txtRefNo.Text.Trim();
                            issDoc.ReceivingUnitID = Convert.ToInt32(cboReceivingUnits.EditValue);
                            DateTime xx = dtIssueDate.Value;
                            dtIssueDate.CustomFormat = "MM/dd/yyyy";

                            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                            issDoc.Date = dtCurrent;
                            dtIssueDate.IsGregorianCurrentCalendar = true;
                            issDoc.EurDate = dtIssueDate.Value;
                            dtIssueDate.IsGregorianCurrentCalendar = false;
                            issDoc.RecievDocID =Convert.ToInt32(dtConfirm.Rows[i]["RecId"]); // Used to have 8 as an index
                            recDoc.LoadByPrimaryKey(receivedocid);
                            issDoc.IsApproved = true;
                            issDoc.IsTransfer = false;

                            issDoc.Remark = txtRemark.Text;
                            issDoc.RecipientName = txtRecipientName.Text;
                            issDoc.IssuedBy = txtIssuedBy.Text;
                            issDoc.DUSOH = Convert.ToInt32(dtConfirm.Rows[i]["DUSOH"]);
                            issDoc.ItemID = Convert.ToInt32(dtConfirm.Rows[i]["ItemId"]);
                            issDoc.Quantity = Convert.ToInt64(dtConfirm.Rows[i]["Quantity"]);
                            
                            issDoc.NoOfPack = Convert.ToInt32(dtConfirm.Rows[i]["No Of Pack"]);
                            issDoc.QtyPerPack = Convert.ToInt32(dtConfirm.Rows[i]["Qty Per Pack"]);
                            switch (VisibilitySetting.HandleUnits)
                            {
                                case 1:
                                    issDoc.UnitID = 0;
                                    break;
                                case 2:
                                    issDoc.UnitID = Convert.ToInt32(dtConfirm.Rows[i]["UnitID"]);
                                    break;
                                default:
                                    issDoc.UnitID = Convert.ToInt32(dtConfirm.Rows[i]["UnitID"]);
                                    break;
                            }
                            issDoc.BatchNo = dtConfirm.Rows[i]["BatchNo"].ToString();
                            issDoc.Cost = Convert.ToDouble(dtConfirm.Rows[i]["Unit Price"]);
                            issDoc.RecomendedQty = Convert.ToInt32(dtConfirm.Rows[i]["DURecomended"]);// ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
                            //End DU
                            issDoc.Save();
                            //updating the receiving doc
                            recDoc.LoadByPrimaryKey(Convert.ToInt32(dtConfirm.Rows[i]["RecId"]));
                            //this line calculates the current SOH
                            recDoc.QuantityLeft = recDoc.QuantityLeft - issDoc.Quantity;
                            currentSOH = currentSOH + recDoc.QuantityLeft;

                            itemId = Convert.ToInt32(dtConfirm.Rows[i]["ItemId"]);
                            var unitId = Convert.ToInt32(dtConfirm.Rows[i]["UnitID"]);
                            if (recDoc.QuantityLeft != 0)
                                recDoc.Out = false;
                            else
                                recDoc.Out = true;

                            if (confirmedItemsQuantity.ContainsKey(itemId))
                                confirmedItemsQuantity[itemId] += recDoc.QuantityLeft;
                            else
                            {
                                confirmedItemsQuantity.Add(itemId, recDoc.QuantityLeft);
                            }
                            recDoc.Save();

                            storeId = Convert.ToInt32(cboStores.EditValue);

                            //Log Activity
                            dtIssueDate.Value = xx;
                            Builder.RefreshAMCValues(storeId, confirmedItemsQuantity,unitId);
                        }

                        //save stockout information for the current item in current store
                        //if current SOH after this issue is 0
                        if (currentSOH == 0)
                        {
                            StockoutLog stockoutLog = new StockoutLog();
                            stockoutLog.AddNew();
                            stockoutLog.StoreID = storeId;
                            stockoutLog.ItemID = itemId;
                            stockoutLog.StartDate = DateTime.Today;
                            stockoutLog.Save();
                        }
                    }
                    XtraMessageBox.Show("Transaction Successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            xpButton2_Click(sender, e);
            issueGrid.DataSource = null;
            issueGridView.RefreshData();
            RefreshItems();
        }       

        /// <summary>
        /// The issue form is reset so that every input is cleared out.
        /// </summary>
        private void ResetValues()
        {
            _dtRec = new DataTable();
            _dtRecGrid = new DataTable();
            _dtRecGrid.Columns.Clear();
            _dtSelectedTable = null;// new DataTable();
            dtIssueDate.Value = DateTime.Now;
            issueGrid.DataSource = null;
            gridConfirmation.DataSource = null;
            txtRefNo.Text = "";
            txtConfRef.Text = "";
            txtIssuedBy.Text = "";
            txtIssuedDate.Text = "";
            txtIssuedTo.Text = "";
            txtItemName.Text = "";
            txtRemark.Text = "";
            txtStore.Text = "";
            cboReceivingUnits.ItemIndex = -1;
            cboStores.EditValue = 1;
            PopulateItemList();
            _tabPage = 0;
            tabControl1.SelectedTabPageIndex = 0;
        }

        public void RefreshItems()
        {
            _dtSelectedTable.Clear();
            ResetValues();

            for (int i = 0; i < gridItemChoiceView.DataRowCount; i++)
            {
                DataRow dr = gridItemChoiceView.GetDataRow(i);
                if ((dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]))
                {
                    dr["IsSelected"] = 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void xpButton3_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void ckStockOut_CheckedChanged(object sender, EventArgs e)
        {
            if (ckStockOut.Checked) gridItemChoiceView.ActiveFilterString = "[Status] = 'Stock Out'";
            else gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", (int)lkCategories.EditValue);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                PopulateItemList();
            }
        }

        private void xpButton2_Click(object sender, EventArgs e)
        {
            if (printableComponentLink2 == null)
                printableComponentLink2 = new PrintableComponentLink();
            printableComponentLink2.CreateMarginalHeaderArea += Link_CreateMarginalHeaderArea;
            printableComponentLink2.CreateDocument();
            printableComponentLink2.Landscape = false;
            printableComponentLink2.ShowPreviewDialog();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            var dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            string[] header = { "Issue Pick List ", "Date: " + dtCurrent.ToShortDateString(), " Ref No: " + txtConfRef.Text, "From: " + txtStore.Text, "To: " + txtIssuedTo.Text };
            printableComponentLink2.PageHeaderFooter = header;
            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(20, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(20, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(20, 40, 200, 100), BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(300, 20, 200, 100), BorderSide.None);
            TextBrick brick4 = e.Graph.DrawString(header[4], Color.DarkBlue, new RectangleF(300, 40, 200, 100), BorderSide.None);
        }

        private void cboReceivingUnits_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable issGrid = (DataTable)issueGrid.DataSource;
            if (issGrid != null)
            {
                if (cboReceivingUnits.EditValue != null && issGrid.Rows.Count > 0)
                {
                    DateTime xx = dtIssueDate.Value;
                    dtIssueDate.Value = DateTime.Now;
                    dtIssueDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                    dtIssueDate.Value = xx;

                    var iss = new IssueDoc();
                    var bal = new Balance();
                    int receivingUnit = Convert.ToInt32(cboReceivingUnits.EditValue);
                    var DUs = new ReceivingUnits();
                    DUs.LoadByPrimaryKey(receivingUnit);
                    double dumax = 0.5;
                    try
                    {
                        dumax = DUs.Max;
                    }
                    catch(Exception EX)
                    {
                       
                    }

                    for (int i = 0; i < issGrid.Rows.Count; i++)
                    {
                        int itmId = Convert.ToInt32(issGrid.Rows[i]["ID"]);
                        int lastIssueQty = iss.GetDULastIssueQty(itmId, receivingUnit);
                        int lastDUSOH = iss.GetDULastSOH(itmId, receivingUnit);
                        issGrid.Rows[i]["MR Issue Qty"] = lastIssueQty;
                        issGrid.Rows[i]["MR DU SOH"] = lastDUSOH;
                        const int lstSOH = 0;
                        issGrid.Rows[i]["DU Remaining SOH"] = 0;
                        int yer = (dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year - 1;
                        Int64 duAmc = bal.CalculateDUAMC(itmId, receivingUnit, dtCurrent.Month, dtCurrent.Year, lstSOH);
                        issGrid.Rows[i]["DU AMC"] = duAmc;
                        double recQty = (duAmc * dumax) - Convert.ToInt32(issGrid.Rows[i]["DU Remaining SOH"]);
                        issGrid.Rows[i]["Recommended Qty"] = ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
                    }
                }
            }
        }


        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtItem = new DataTable();
            Items itm = new Items();
            _selectedType = radioGroup1.EditValue.ToString();
            PopulateCatTree(_selectedType);
            PopulateItemList();
        }

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
            //Commented out by tedy
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();

            bool b = (dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]);

            if (b)
            {
                try
                {
                    _dtSelectedTable.ImportRow(dr);
                }
                catch { }
            }
            else
            {
                if (_dtSelectedTable.Columns != null)
                    _dtSelectedTable.PrimaryKey = new[] { _dtSelectedTable.Columns["ID"] };
                int id = Convert.ToInt32(dr["ID"]);
                DataRow rw = _dtSelectedTable.Rows.Find(id);
                if (rw != null)
                {
                    _dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = _dtRecGrid.Select(String.Format("ID = {0}", dr["ID"]));// dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                        foreach (DataRow r in dataRows)
                        {
                            r.Delete();
                            txtItemName.Text = "";
                        }
                    }
                    catch { }
                }

            }

        }

        private void gridItemChoiceView_RowClick_1(object sender, RowClickEventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            txtItemName.Select();
            txtItemName.SelectAll();
            dr["IsSelected"] = ((dr["IsSelected"] == DBNull.Value) || !Convert.ToBoolean(dr["IsSelected"]));
            dr.EndEdit();
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            var iu = new ItemUnit();

            if ((view.FocusedColumn.FieldName == "Pack Qty") || (view.FocusedColumn.FieldName == "Qty Per Pack") || (view.FocusedColumn.FieldName == "DU Remaining SOH"))
            {
                DataRow dr = issueGridView.GetDataRow(issueGridView.GetSelectedRows()[0]);

                int qty = Convert.ToInt32(dr["Pack Qty"]);
                int qtyPerpack = Convert.ToInt32(dr["Qty Per Pack"]);
                switch (VisibilitySetting.HandleUnits)
                {
                    case 2:
                        {
                            iu.LoadByPrimaryKey(Convert.ToInt32(dr["UnitID"]));
                            var qtyperunit = iu.QtyPerUnit;
                            dr["Qty Per Pack"] = qtyperunit;
                            dr["Requested Qty"] = qty;
                        }
                        break;
                    case 3:
                        {
                            iu.LoadByPrimaryKey(Convert.ToInt32(dr["UnitID"]));
                            var qtyperunit = iu.QtyPerUnit;
                            dr["Qty Per Pack"] = qtyperunit;
                            dr["Requested Qty"] = qty;
                        }
                        break;
                    case 1:
                        dr["Qty Per Pack"] = qtyPerpack;
                        dr["Requested Qty"] = (qtyPerpack * qty);
                        break;
                }

                DateTime xx = dtIssueDate.Value;
                dtIssueDate.Value = DateTime.Now;
                dtIssueDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
                dtIssueDate.Value = xx;

                var bal = new Balance();
                var receivingUnit = Convert.ToInt32(cboReceivingUnits.EditValue);

                Int64 duAmc = 0;
                int itmId = Convert.ToInt32(dr["ID"]);
                int lstSOH = ((dr["DU Remaining SOH"] != null && dr["DU Remaining SOH"] != DBNull.Value) ? Convert.ToInt32(dr["DU Remaining SOH"]) : 0);
                duAmc = bal.CalculateDUAMC(itmId, receivingUnit, dtCurrent.Month, dtCurrent.Year, lstSOH);
                dr["DU AMC"] = duAmc;

                //recommend qty to du
                var DUs = new ReceivingUnits();
                DUs.LoadByPrimaryKey(receivingUnit);
                double dumax = 0.5;
                try
                {
                    dumax = DUs.Max;
                }
                catch
                { }
                double recQty = (Convert.ToInt32(dr["DU AMC"]) * dumax) - lstSOH;
                dr["Recommended Qty"] = ((recQty > 0) ? Convert.ToInt64(recQty) : 0);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            _dtSelectedTable = new DataTable();
        }

        /// <summary>
        /// We want to show the item detail report when the user double clicks on the grid row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemChoiceView_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            DataRow dr = view.GetFocusedDataRow();
            if (dr == null) return;

            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCur = ConvertDate.DateConverter(dtIssueDate.Text);
            int year = ((dtCur.Month < 11) ? dtCur.Year : dtCur.Year + 1);
            dtIssueDate.CustomFormat = "MMM dd,yyyy";
            var itemId = Convert.ToInt32(dr["ID"]);
            

            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                        var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                        con.ShowDialog();
                    }
                    break;
                case 2:
                    {
                        var unitId = Convert.ToInt32(dr["UnitID"]);
                        var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year,0,unitId);
                        con.ShowDialog();
                    }
                    break;
                case 3:
                    {
                        var unitId = Convert.ToInt32(dr["UnitID"]);
                        var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0,unitId);
                        con.ShowDialog();
                    }
                    break;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var storeId = Convert.ToInt32(e.Argument);
            var bal = new Balance();
            dtIssueDate.Value = DateTime.Now;
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                      e.Result = bal.ItemListToIssue(storeId, dtCurrent, _selectedType, bw);
                    }
                    break;
                case 2:
                    {
                        e.Result = bal.ItemsListToIssueByUnit(storeId, dtCurrent, _selectedType, bw);
                    }
                    break;
                default:
                    {
                        e.Result = bal.ItemsListToIssueByUnit(storeId, dtCurrent, _selectedType, bw);
                    }
                    break;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dtList;
            gridItemsChoice.DataSource = dtList = (DataTable)e.Result;
            if (_dtSelectedTable == null)
            {
                _dtSelectedTable = dtList.Clone();
            }
            gridItemChoiceView.ActiveFilterString = "";
            gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue)); ;
        }

        private void tabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == tabPage2)
            {
                if (!Validation())
                {
                    e.Cancel = true;
                }
            }
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            var inventory = new YearEnd();
            if (inventory.IsInventoryCompleteToReceive(2006, Convert.ToInt32(cboStores.EditValue)) != false) return;
                XtraMessageBox.Show("Please First Finish All Inventory and come back!","Error", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                btnSave.Enabled = false;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow dr = issueGridView.GetDataRow(issueGridView.GetSelectedRows()[0]);
            if (dr != null)
            {
                dr.Delete();
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if (chkExcludeStockedOut.Checked)
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] =='Stock Out' and TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
            else
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));

        }

        private void chkExcludeStockedOut_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkExcludeStockedOut.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
            }
            else if (chkExcludeStockedOut.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and [Status] !='Stock Out'", Convert.ToInt32(lkCategories.EditValue));
            }
        }

        private void printableComponentLink2_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            dtIssueDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtIssueDate.Text);
            string[] header = { "Pick List ", "Date: " + dtCurrent.ToShortDateString(), " Ref No: " + txtConfRef.Text, "From: " + txtStore.Text, "To: " + txtIssuedTo.Text };
            printableComponentLink2.PageHeaderFooter = header;
        }

        private void repositoryItemLookUpEdit1_Enter(object sender, EventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit == null) return;
            var clone = new ItemUnit();
            var row = gridItemChoiceView.GetFocusedDataRow();
            var id = Convert.ToInt32(row["ID"]);
            var filterunit = clone.LoadFromSQl(id);

            edit.Properties.DataSource = filterunit.DefaultView;
            edit.Properties.DisplayMember = "Text";
            edit.Properties.ValueMember = "ID";
        }

        private void gridItemChoiceView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Dispatchable")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
          
        }

        private void gridItemChoiceView_RowStyle(object sender, RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (view.GetRowCellValue(e.RowHandle, view.Columns["gridColumn15"]).Equals("Expired"))
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }

        }

       
       



    }
}