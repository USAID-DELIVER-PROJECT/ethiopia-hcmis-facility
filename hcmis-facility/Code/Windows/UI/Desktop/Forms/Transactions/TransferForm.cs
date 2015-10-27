using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Transactions
{
    public partial class TransferForm : DevExpress.XtraEditors.XtraForm
    {
        public TransferForm()
        {
            InitializeComponent();
        }

        #region Members

        int _tabPage=0;
        string _selectedType = "Drug";
        DataTable _dtSelectedTable;
        private int _itemID;
        DataTable _dtRecGrid = new DataTable();

        #endregion

        private void TransferForm_Load(object sender, EventArgs e)
        {
            var store = new Stores();
            store.GetActiveStores();
            lkFromStore.Properties.DataSource = store.DefaultView;
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();

            var units = new ItemUnit();
            var allunits = units.GetAllUnits();
            unitBindingSource.DataSource = allunits.DefaultView;

            lkToStore.Properties.DataSource = store.DefaultView;
            var unitcolumn0 = ((GridView)gridItemsChoice.MainView).Columns[7];
            var unitcolumn1 = ((GridView)gridItemsChoice.MainView).Columns[2];
            var unitcolumn2 = ((GridView)receivingGrid.MainView).Columns[4];
           
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    unitcolumn0.Visible = false;
                    unitcolumn1.Visible = true;
                    unitcolumn2.Visible = false;
                    break;
                case 2:
                    unitcolumn0.Visible = true;
                    unitcolumn1.Visible = false;
                    unitcolumn2.Visible = true;
                    break;
                default:
                    unitcolumn0.Visible = true;
                    unitcolumn1.Visible = false;
                    unitcolumn2.Visible = true;
                    break;
            }

            lkCategories.ItemIndex = 0;
            lkFromStore.ItemIndex = 0;

            var userID = MainWindow.LoggedinId;
            var us = new User();
            us.LoadByPrimaryKey(userID);
            txtApprovedBy.Text = us.FullName;
           

            // bind the current date as the datetime field
            dtRecDate.Value = DateTime.Now;
            gridItemsView.ActiveFilterString = String.Format("[ExpiryDate] > #{0}# ", DateTime.Now);
        }


        private void PopulateItemList(DataTable dtItem)
        {
            if (_dtSelectedTable == null)
            {
                _dtSelectedTable = dtItem.Clone();
                _dtSelectedTable.PrimaryKey = new[] { _dtSelectedTable.Columns["ReceiveID"] };
            }
            gridItemsChoice.DataSource = dtItem;
          
            try
            {
                dtItem.Columns.Add("IsSelected", typeof(bool));
            }
          
            catch (Exception exception)
            {
                throw new InvalidDataException(exception.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var transfer = new Transfer();
            var newreceiveDoc = new ReceiveDoc();
            var receiveDoc = new ReceiveDoc();
            var issuedoc = new IssueDoc();
            var valid = ValidateFields();
            if (valid == "true")
            {
                if (XtraMessageBox.Show("Are you sure you want to save this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try{
                        var dtRecGrid = (DataTable)receivingGrid.DataSource;
                        for (int i = 0; i < dtRecGrid.Rows.Count; i++)
                        {
                            transfer.AddNew();
                            var receiveid = Convert.ToInt32(dtRecGrid.Rows[i]["RecID"]);
                            transfer.ItemID = _itemID = Convert.ToInt32(dtRecGrid.Rows[i]["ID"]);
                            transfer.RecID = receiveid;
                            transfer.BatchNo = dtRecGrid.Rows[i]["Batch No"].ToString();
                            transfer.FromStoreID = Convert.ToInt32(lkFromStore.EditValue);
                            transfer.ToStoreID = Convert.ToInt32(lkToStore.EditValue);
                            transfer.Quantity = Convert.ToInt64(dtRecGrid.Rows[i]["Qty To Transfer"]);
                            transfer.RefNo = txtRefNo.Text;
                            transfer.UnitID = VisibilitySetting.HandleUnits == 1 ? 0 : Convert.ToInt32(dtRecGrid.Rows[i]["UnitID"]);

                            DateTime xx = dtRecDate.Value;
                            dtRecDate.CustomFormat = "MM/dd/yyyy";
                            new DateTime();
                            transfer.Date = ConvertDate.DateConverter(dtRecDate.Text);
                            ConvertDate.DateConverter(dtRecDate.Text);
                            dtRecDate.IsGregorianCurrentCalendar = true;

                            transfer.EurDate = dtRecDate.Value;
                            dtRecDate.IsGregorianCurrentCalendar = false;

                           
                           
                           
                            transfer.TransferReason = txtTransferReason.Text;
                            transfer.ApprovedBy = txtApprovedBy.Text;
                            transfer.TransferRequestedBy = txtRequestedBy.Text;
                            transfer.Save();

                            transfer.GetTransfered(receiveid, _itemID, Convert.ToInt32(lkFromStore.EditValue));
                            issuedoc.AddNew();
                            issuedoc.StoreId = transfer.FromStoreID;
                            issuedoc.ItemID = transfer.ItemID;
                            issuedoc.Quantity = transfer.Quantity;
                            issuedoc.Date = transfer.Date;
                            issuedoc.BatchNo = transfer.BatchNo;
                            issuedoc.UnitID = transfer.UnitID;
                            issuedoc.RecievDocID = transfer.RecID;
                            issuedoc.IsTransfer = true;
                            issuedoc.RefNo = transfer.RefNo;
                            var allstores = new Stores();
                            allstores.LoadByPrimaryKey(transfer.ToStoreID);
                            issuedoc.ReceivingUnitID = (int) allstores.GetColumn("ReceivingUnitID");
                            issuedoc.Save();

                            receiveDoc.GetReceivedItems(receiveid,_itemID, Convert.ToInt32(lkFromStore.EditValue));
                            receiveDoc.QuantityLeft = receiveDoc.QuantityLeft - transfer.Quantity;
                            

                            newreceiveDoc.AddNew();

                            newreceiveDoc.StoreID = transfer.ToStoreID;
                            newreceiveDoc.RefNo = transfer.RefNo;
                            newreceiveDoc.BatchNo = transfer.BatchNo;
                            newreceiveDoc.ItemID = transfer.ItemID;
                            newreceiveDoc.Quantity = transfer.Quantity;
                            newreceiveDoc.QuantityLeft = transfer.Quantity;
                            newreceiveDoc.NoOfPack =  Convert.ToInt32(transfer.Quantity) / receiveDoc.QtyPerPack;
                            newreceiveDoc.QtyPerPack = receiveDoc.QtyPerPack;
                            newreceiveDoc.Cost = receiveDoc.Cost;

                            newreceiveDoc.Date = transfer.Date;
                            newreceiveDoc.UnitID = transfer.UnitID;
                            newreceiveDoc.Out = false;
                            newreceiveDoc.ReceivedBy = transfer.ApprovedBy;
                            newreceiveDoc.ExpDate = receiveDoc.ExpDate;

                            allstores.LoadByPrimaryKey(transfer.FromStoreID);
                            newreceiveDoc.SupplierID = (int) allstores.GetColumn("SupplierID");
                            newreceiveDoc.BoxLevel = 1;
                            newreceiveDoc.Save();
                            receiveDoc.Save();
                        }

                        XtraMessageBox.Show("Transaction Successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                        
                    }
                    catch (Exception exp)
                    {
                        XtraMessageBox.Show(exp.InnerException.Message ,"Error");
                    }
                }

            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private string ValidateFields()
        {
            dtRecDate.Value = DateTime.Now;
            DateTime dtCurent = new DateTime();
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtRecDate.Text);


            string valid = "true";

            if (Convert.ToDateTime(dtRecDate.Value) > DateTime.Now)
            {
                valid = "You cannot pick a Date in a future!";
                return valid;
            }

            if (lkFromStore != null && Convert.ToInt32(lkFromStore.EditValue) == Convert.ToInt32(lkToStore.EditValue))
            {
                valid = "You cannot transfer an item to the same store.";
                return valid;
            }

            if (!dxValidationProvider1.Validate())
            {
                valid = "Please correct the highlighted filed!";
            }

            var itm = new Items();
            for (int i = 0; i < gridRecieveView.DataRowCount; i++)
            {
                DataRow dr = gridRecieveView.GetDataRow(i);
                dr.ClearErrors();

                if (dr["Qty To Transfer"] == null || dr["Qty To Transfer"].ToString() == "" || Convert.ToInt64(dr["Qty To Transfer"]) == 0)
                {
                    dr.SetColumnError("Qty To Transfer", "This field cannot be left blank.");
                    valid = "Please fill the requested feild!";
                }

                if (Convert.ToInt32(dr["Qty To Transfer"]) > Convert.ToInt32(dr["BU Qty"]))
                {
                    dr.SetColumnError("Qty To Transfer", "Qty To Transfer should be less than BU Qty(Remaining).");
                    valid = "Qty To Transfer should be less than BU Qty(Remaining)";
                }
                itm.LoadByPrimaryKey(Convert.ToInt32(_dtRecGrid.Rows[i]["ID"]));

            }
            return valid;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        private void ResetFields()
        {
            tabControl1.SelectedTabPageIndex = 0;
            lkToStore.ItemIndex = 0;
            dtRecDate.Value = DateTime.Now;
            txtRequestedBy.Text = "";
            txtTransferReason.Text = "";
            txtItemName.Text = "";
            _dtSelectedTable.Rows.Clear();
            foreach (DataRowView dr in ((DataView)gridItemsView.DataSource))
            {
                dr["IsSelected"] = false;
            }
        }
        private void gridItemsView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var dr = view.GetFocusedDataRow();
                dr["IsSelected"] = ((dr["IsSelected"] == DBNull.Value) || !Convert.ToBoolean(dr["IsSelected"])); // true;
                dr.EndEdit();
            }
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void OnItemCheckedChanged(object o, EventArgs eventArgs)
        {
            var dr = gridItemsView.GetFocusedDataRow();

            var b = (dr["IsSelected"] != DBNull.Value) && Convert.ToBoolean(dr["IsSelected"]);

            if (b)
            {
                try
                {
                    _dtSelectedTable.ImportRow(dr);
                }
                catch
                {
                    
                }
            }
            else
            {
                int id = Convert.ToInt32(dr["ReceiveID"]);
                DataRow rw = _dtSelectedTable.Rows.Find(id);
                if (rw != null)
                {
                    _dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = _dtRecGrid.Select(String.Format("ReceiveID = {0}", dr["ReceiveID"]));
                        foreach (DataRow r in dataRows)
                        {
                            r.Delete();
                        }
                    }
                    catch { }
                }
            }
        }

        private void PopulateListToGrid()
        {
            _dtRecGrid = new DataTable();
            var itm = new Items();
            var rec = new ReceiveDoc();
            _tabPage = 1;
            tabControl1.SelectedTabPageIndex = 1;
            if (_dtRecGrid.Columns.Count == 0)
            {
                string[] str = { "ID", "Stock Code", "Item Name", "Batch No", "Unit", "BU Qty", "Price", "Qty To Transfer", "RecID", "UnitID"};
                foreach (string col in str)
                {
                    _dtRecGrid.Columns.Add(col);
                }
            }
            int count = 1;
            foreach (DataRow dr in _dtSelectedTable.Rows)
            {
                rec.LoadByPrimaryKey(Convert.ToInt32(dr["ReceiveID"]));

                int id = Convert.ToInt32(dr["ItemID"]);
                double price = 0;
                if (!rec.IsColumnNull("Cost"))
                {
                    price = (rec.RowCount > 0) ? Convert.ToDouble(rec.Cost) * rec.QuantityLeft : 0;
                }
                DataTable dtItm = itm.GetItemById(id);
                string itemName = dtItm.Rows[0]["FullItemName"].ToString();
                object[] obj;
                switch (VisibilitySetting.HandleUnits)
                {
                    case 1:
                        obj = new object[]
                                  {
                                      id, dtItm.Rows[0]["StockCode"].ToString(),itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),rec.QuantityLeft, price, "",Convert.ToInt32(dr["ReceiveID"]),0};
                        break;
                    case 2:
                        obj = new object[]
                                  {
                                      id, dtItm.Rows[0]["StockCode"].ToString(),itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),rec.QuantityLeft, price, "",Convert.ToInt32(dr["ReceiveID"]),rec.UnitID
                                  };
                        break;
                    default:
                        obj = new object[]
                                  {
                                      id, dtItm.Rows[0]["StockCode"].ToString(),itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),rec.QuantityLeft, price, "",Convert.ToInt32(dr["ReceiveID"]),rec.UnitID
                                  };
                        break;
                }
                _dtRecGrid.Rows.Add(obj);
                count++;
            }
            receivingGrid.DataSource =_dtRecGrid;
            txtTranferFrom.Text = lkFromStore.Text;
        }

        private void TxtItemNameTextChanged(object sender, EventArgs e)
        {
            gridItemsView.ActiveFilterString = String.Format("[FullItemName] Like '%{0}%' And [TypeID] = {1}", txtItemName.Text, (int)(lkCategories.EditValue ?? 0));
        }

        private void RepositoryItemLookUpEdit1Enter(object sender, EventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit == null) return;
            var clone = new ItemUnit();
            var row = gridRecieveView.GetFocusedDataRow();
            var id = Convert.ToInt32(row["ID"]);
            var filterunit = clone.LoadFromSQl(id);
            //UnitsbindingSource.DataSource = clone.DefaultView;

            edit.Properties.DataSource = filterunit;
            edit.Properties.DisplayMember = "Text";
            edit.Properties.ValueMember = "ID";
        }

        private void LkFromStoreEditValueChanged(object sender, EventArgs e)
        {
            var rDoc = new ReceiveDoc();
            if (lkFromStore.EditValue == null) return;
            var dtItem = rDoc.GetRecievedItemsWithBalanceForStore(Convert.ToInt32(lkFromStore.EditValue), (int)lkCategories.EditValue);
            PopulateItemList(dtItem);
            var inventory = new YearEnd();
            if (inventory.IsInventoryCompleteToReceive(2006, Convert.ToInt32(lkFromStore.EditValue)) != false) return;
            XtraMessageBox.Show("Please First Finish All Inventory and come back!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnSave.Enabled = false;


        }


        private bool Validate()
        {
            switch (_tabPage)
            {
                case 0:
                    if (_dtSelectedTable != null && _dtSelectedTable.Rows.Count > 0)
                    {
                        PopulateListToGrid();
                    }
                    else
                    {
                        tabControl1.SelectedTabPageIndex = 0;
                        XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    break;
                case 1:
                    if (tabControl1.SelectedTabPageIndex != 1)
                        _tabPage = 0;
                    break;
            }
            return true;
        }

        private void TabControl1SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page != tabPage2) return;
            if (!Validate())
            {
                e.Cancel = true;
            }
        }

        private void BtnPickClick(object sender, EventArgs e)
        {
            if (_tabPage == 0)
            {
                if (_dtSelectedTable != null && _dtSelectedTable.Rows.Count > 0)
                {
                    PopulateListToGrid();
                }
                else
                {
                    XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (_tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    _tabPage = 0;
            }
        }

    }
}
