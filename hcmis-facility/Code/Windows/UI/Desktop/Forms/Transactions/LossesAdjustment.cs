using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory
{
    /// <summary>
    /// Used to register losses and adjustments.
    /// Inputs: Item, Loss/Adjustment Amount, Reason of Adjustment/Loss
    /// </summary>
    public partial class LossesAdjustment : XtraForm
    {
        public LossesAdjustment()
        {
            InitializeComponent();
        }

        #region Members
        int tabPage = 0;
        string selectedType = "Drug";
        DataTable dtSelectedTable = null;
        DataTable dtRecGrid = new DataTable();
        #endregion

        /// <summary>
        /// Load the lookups and the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LossesAdjustment_Load(object sender, EventArgs e)
        {
            var UnitColumn = ((GridView)AdjustmentGrid.MainView).Columns[10];
            var UnitColumn1 = ((GridView)gridItemsChoice.MainView).Columns[4];

            switch (VisibilitySetting.HandleUnits)
            {
                case 2:
                    UnitColumn.Visible = true;
                    UnitColumn1.Visible = false;
                    break;
                case 1:
                    UnitColumn.Visible = false;
                    UnitColumn1.Visible = true;
                    break;
                case 3:
                    UnitColumn.Visible = true;
                    UnitColumn1.Visible = false;
                    break;
            }

            var stor = new Stores();
            stor.GetActiveStores();

            cboStores.Properties.DataSource = stor.DefaultView;
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();

            var unit = new ItemUnit();
            var allunits = unit.GetAllUnits();
            unitsbindingSource.DataSource = allunits.DefaultView;

            var disRes = new DisposalReasons();
            var allreasons = disRes.GetAllReasons();
            reasonBindingSource.DataSource = allreasons.DefaultView;

            lkCategories.ItemIndex = 0;
            cboStores.ItemIndex = 0;
            dtAdjustDate.Value = DateTime.Now;
            if (ckExpired.Checked)
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] < #{0}# and [TypeID]={1} and [QuantityLeft] > 0", DateTime.Now, (int)lkCategories.EditValue);
        }

        public void PopulateItemList(DataTable dtItem)
        {
            if (dtSelectedTable == null)
            {
                dtSelectedTable = dtItem.Clone();
                dtSelectedTable.PrimaryKey = new[] { dtSelectedTable.Columns["ReceiveID"] };
            }

            gridItemsChoice.DataSource = dtItem;

            try
            {
                dtItem.Columns.Add("IsSelected", typeof(bool));
            }
            catch
            {

            }
        }

        private void txtItemName_TextChanged_1(object sender, EventArgs e)
        {
            if (ckExpired.Checked)
            {
                gridItemChoiceView.ActiveFilterString =
                    String.Format("[FullItemName] Like '{0}%' AND [ExpiryDate] < '{1}'",
                                  txtItemName.Text, DateTime.Now.ToShortDateString());
                gridItemChoiceView.RefreshData();

            }
            else if (!ckExpired.Checked)
            {
                gridItemChoiceView.ActiveFilterString = "";
                gridItemChoiceView.ActiveFilterString =
                    String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1} And [StoreID]={2}", txtItemName.Text,
                                  (int)(lkCategories.EditValue ?? 0), (int)(cboStores.EditValue ?? 0));
                gridItemChoiceView.RefreshData();
            }

        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            if (tabPage == 0)
            {
                if (dtSelectedTable != null && dtSelectedTable.Rows.Count > 0)
                {
                    PopulateGridList();
                }
                else
                {
                    XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    tabPage = 0;
            }
        }

        /// <summary>
        /// Populate the grid with the selected items.
        /// </summary>
        private void PopulateGridList()
        {
            dtRecGrid = new DataTable();
            Items itm = new Items();
            ReceiveDoc rec = new ReceiveDoc();
            tabPage = 1;
            tabControl1.SelectedTabPageIndex = 1;
            if (dtRecGrid.Columns.Count == 0)
            {
                string[] str = { "ID", "Stock Code", "Item Name", "Batch No", "Unit", "BU Qty", "Price", "Losses", "Adjustment", "RecID", "Reason",
                               "UnitID"};
                foreach (string col in str)
                {
                    dtRecGrid.Columns.Add(col);
                }
            }
            int count = 1;
            foreach (DataRow dr in dtSelectedTable.Rows)
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
                var obj = new object[] { };
                switch (VisibilitySetting.HandleUnits)
                {
                    case 1:
                        obj = new object[]
                                 {
                                     id, dtItm.Rows[0]["StockCode"].ToString(),
                                     itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),
                                     rec.QuantityLeft, price, "", "",
                                     Convert.ToInt32(dr["ReceiveID"]),
                                     0, 0
                                 };
                        break;
                    case 2:
                        obj = new object[]
                                 {
                                     id, dtItm.Rows[0]["StockCode"].ToString(),
                                     itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),
                                     rec.QuantityLeft, price, "", "",
                                     Convert.ToInt32(dr["ReceiveID"]),
                                     0, rec.UnitID
                                 };
                        break;
                    default:
                        obj = new object[]
                                 {
                                     id, dtItm.Rows[0]["StockCode"].ToString(),
                                     itemName, rec.BatchNo, dtItm.Rows[0]["Unit"].ToString(),
                                     rec.QuantityLeft, price, "", "",
                                     Convert.ToInt32(dr["ReceiveID"]),
                                     0, rec.UnitID
                                 };
                        break;
                }
                dtRecGrid.Rows.Add(obj);
                count++;

            }

            //var disRes = new DisposalReasons();
            //var allreasons = disRes.GetAllReasons();
            //reasonBindingSource.DataSource = allreasons.DefaultView;

            AdjustmentGrid.DataSource = dtRecGrid;
            cboStoreConfi.Text = cboStores.Text;
        }

        /// <summary>
        /// Validates user input
        /// </summary>
        /// <returns>"true" if valid, and if invalid, the error is returned as a string.</returns>
        private string ValidateFields()
        {
            string valid = "true";
            dtAdjustDate.Value = DateTime.Now;
            DateTime dtCurent = new DateTime();
            dtAdjustDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtAdjustDate.Text);

            if (!dxValidation.Validate())
            {
                valid = "All * marked fields are required!";
                return valid;
            }

            //if ((dtCurent.Month == 10 && dtCurent.Day == 30) || dtCurent.Month == 11)
            //{
            //    valid = "You can not perform loss and adjustment on an item because it is an inventory period!";
            //}

            if (Convert.ToDateTime(dtAdjustDate.Value) > DateTime.Now)
            {
                valid = "You cannot pick a Date in a future!";
                return valid;
            }

            DataTable dtAdjVal = (DataTable)AdjustmentGrid.DataSource;
            for (int i = 0; i < dtAdjVal.Rows.Count; i++)
            {
                try
                {
                    Int64 xx = 0;
                    Int64 xy = 0;

                    if (dtAdjVal.Rows[i]["Adjustment"].ToString() != "")
                    {
                        xx = Convert.ToInt64(dtAdjVal.Rows[i]["Adjustment"]);
                    }
                    if (dtAdjVal.Rows[i]["Losses"].ToString() != "")
                    {
                        xy = Convert.ToInt64(dtAdjVal.Rows[i]["Losses"]);
                    }
                    if (xx < 0 || xy < 0)
                    {
                        valid = "Loss and adjustment values always have to be greater than zero.  You cannot enter negative values.";
                        return valid;
                    }
                    if (xx == 0 && xy == 0)
                    {
                        valid = "Either loss or adjustment has to be entered!";
                        return valid;
                    }
                    else if (xx > 0 && xy > 0)
                    {
                        valid = "You can't add both loss and adjustment at one time!";
                        return valid;
                    }

                    else if (dtAdjVal.Rows[i]["Reason"].ToString() == "0")
                    {
                        valid = "Adjustment Reason has to be picked!";
                        return valid;
                    }
                }
                catch
                {
                    valid = "Value has to be a Number!";

                    return valid;
                }


            }
            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string valid = ValidateFields();
            if (valid == "true")
            {
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Disposal dis = new Disposal();
                    Balance bal = new Balance();
                    ReceiveDoc rec = new ReceiveDoc();
                    DataTable dtAdjVal = (DataTable)AdjustmentGrid.DataSource;
                    for (int i = 0; i < dtAdjVal.Rows.Count; i++)
                    {

                        dis.AddNew();
                        dis.StoreId = Convert.ToInt32(cboStores.EditValue);
                        dis.ItemID = Convert.ToInt32(dtAdjVal.Rows[i]["ID"]);
                        dis.ApprovedBy = txtApprovedBy.Text;
                        DateTime xx = dtAdjustDate.Value;
                        dtAdjustDate.CustomFormat = "MM/dd/yyyy";
                        DateTime dtRec = new DateTime();

                        dis.Date = ConvertDate.DateConverter(dtAdjustDate.Text);
                        dtRec = ConvertDate.DateConverter(dtAdjustDate.Text);

                        dis.RefNo = txtRefNo.Text;
                        dis.BatchNo = dtAdjVal.Rows[i]["Batch No"].ToString();
                        double price = ((Convert.ToDouble(dtAdjVal.Rows[i]["BU Qty"]) != 0) ? (Convert.ToDouble(dtAdjVal.Rows[i]["Price"]) / Convert.ToDouble(dtAdjVal.Rows[i]["BU Qty"])) : 0);
                        dis.Cost = price;
                        dis.Remark = txtRemark.Text;
                        if (dtAdjVal.Rows[i]["Losses"].ToString() != "")
                        {
                            if (Convert.ToInt64(dtAdjVal.Rows[i]["Losses"]) <= Convert.ToInt64(dtAdjVal.Rows[i]["BU Qty"]))
                            {
                                dis.Losses = true;
                                dis.Quantity = Convert.ToInt64(dtAdjVal.Rows[i]["Losses"]);
                            }
                            else
                            {
                                XtraMessageBox.Show("You can't loss more quantity than what you have in the store!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                ResetFields();
                                return;
                            }
                        }
                        else
                        {
                            dis.Losses = false;
                            dis.Quantity = Convert.ToInt64(dtAdjVal.Rows[i]["Adjustment"]);
                        }
                        dis.ReasonId = Convert.ToInt32(dtAdjVal.Rows[i]["Reason"]);
                        if (VisibilitySetting.HandleUnits == 1)
                        {
                            dis.UnitID = 0;
                        }
                        else if (VisibilitySetting.HandleUnits == 2)
                        {
                            dis.UnitID = Convert.ToInt32(dtRecGrid.Rows[i]["UnitID"]);
                        }
                        else if (VisibilitySetting.HandleUnits == 3)
                        {
                            dis.UnitID = Convert.ToInt32(dtRecGrid.Rows[i]["UnitID"]);
                        }
                        dis.RecID = Convert.ToInt32(dtAdjVal.Rows[i]["RecID"]);
                        dis.EurDate = dtAdjustDate.Value;
                        dis.Save();

                        rec.LoadByPrimaryKey(Convert.ToInt32(dtAdjVal.Rows[i]["RecID"]));

                        if (rec.RowCount > 0)
                        {
                            if (dis.Losses)
                            {
                                rec.QuantityLeft = rec.QuantityLeft - dis.Quantity;
                                if (rec.QuantityLeft == 0)
                                    rec.Out = true;
                                else
                                    rec.Out = false;
                                //  rec.UnitID = Convert.ToInt32(dtAdjVal.Rows[i]["UnitID"]);
                                rec.Save();
                                //Log Activity, ActivityID for save is 1
                                // logger.SaveAction(1, 1, "Transaction\\LossesAdjustment.cs", "Loss/Adjustmet of " + dis.Quantity +" LOSS has been made.");
                            }
                            else
                            {
                                rec.QuantityLeft = rec.QuantityLeft + dis.Quantity;
                                if (rec.QuantityLeft != 0)
                                    rec.Out = false;
                                else
                                    rec.Out = true;
                                rec.Save();
                                //Log Activity, ActivityID for save is 1
                                //logger.SaveAction(1, 1, "Transaction\\LossesAdjustment.cs", "Loss/Adjustmet of " + dis.Quantity + " ADJUSTMENT has been made.");
                            }
                        }


                        dtAdjustDate.Value = xx;
                    }
                    XtraMessageBox.Show("Transaction successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields();
                }
            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Reset the form for further input from the user.
        /// </summary>
        private void ResetFields()
        {
            tabControl1.SelectedTabPageIndex = 0;
            dtRecGrid = new DataTable();
            txtApprovedBy.Text = "";
            txtItemName.Text = "";
            txtRefNo.Text = "";
            txtRemark.Text = "";
            dtAdjustDate.Value = DateTime.Now;

            Items itm = new Items();
        }

        private void tabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == tabPage2)
            {
                if (!Validate())
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Validates that an item has been selected before proceeding to the next tab.
        /// </summary>
        /// <returns>true</returns>
        private bool Validate()
        {
            if (tabPage == 0)
            {
                if (dtSelectedTable != null && dtSelectedTable.Rows.Count > 0)
                {
                    PopulateGridList();
                }
                else
                {
                    tabControl1.SelectedTabPageIndex = 0;
                    XtraMessageBox.Show("You must select a drug to populate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else if (tabPage == 1)
            {
                if (tabControl1.SelectedTabPageIndex != 1)
                    tabPage = 0;
            }
            return true;

        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            var rDoc = new ReceiveDoc();
            if (ckExpired.Checked && cboStores.EditValue !=null && lkCategories.EditValue !=null)
            {
                var dtItem = rDoc.GetRecievedItemsWithBalanceForStore(Convert.ToInt32(cboStores.EditValue),
                                                                      (int) lkCategories.EditValue);
                PopulateItemList(dtItem);
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] < #{0}# and [TypeID]={1}",
                                                                      DateTime.Now, (int) lkCategories.EditValue);
            }
            if (!ckExpired.Checked && cboStores.EditValue != null && lkCategories.EditValue != null)
            {
                var dtItem = rDoc.GetRecievedItemsWithBalanceForStore(Convert.ToInt32(cboStores.EditValue),
                                                                      (int) lkCategories.EditValue);
                PopulateItemList(dtItem);
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] > #{0}# and [TypeID]={1}",
                                                                      DateTime.Now, (int) lkCategories.EditValue);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }


        private void ckExpired_CheckedChanged(object sender, EventArgs e)
        {
            if (ckExpired.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] < #{0}# and [TypeID]={1} and [QuantityLeft] > 0 ", DateTime.Now, (int)lkCategories.EditValue);

            }
            else if (!ckExpired.Checked)
            {
                //gridItemChoiceView.ActiveFilterString = "";
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] >= #{0}# and [TypeID]={1}", DateTime.Now, (int)lkCategories.EditValue);
              //  gridItemChoiceView.RefreshData();
            }


        }



        //private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboStores.EditValue  != null)
        //    {
        //        Items itm = new Items();
        //        selectedType = radioGroup1.EditValue.ToString();
        //        DataTable dtItem = ((selectedType == "Drug") ? itm.GetItemsReceivedByBatchForAdj(Convert.ToInt32(cboStores.EditValue)) : itm.GetCommoditiesReceivedByBatch(Convert.ToInt32(cboStores.EditValue)));
        //        PopulateItemList(dtItem);
        //        PopulateCatTree(selectedType);
        //    }
        //}

        //private void treeCategory_Click(object sender, EventArgs e)
        //{

        //    string value = treeCategory.Selection[0].GetValue("ID").ToString();
        //    int categoryId = Convert.ToInt32(value.Substring(1));

        //    Items itm = new Items();
        //    string FilterString = "";
        //    switch (value.Substring(0, 1))
        //    {

        //        case "S":
        //            FilterString = "[SubCategoryID] = " + categoryId.ToString();
        //            gridItemChoiceView.ActiveFilterString = FilterString;

        //            break;
        //        case "C":
        //        case "U":
        //            FilterString = "[CategoryID] = " + categoryId.ToString();
        //            gridItemChoiceView.ActiveFilterString = FilterString;

        //            break;
        //        case "P":                    
        //            gridItemChoiceView.ActiveFilterString = "";
        //            break;
        //    }

        //    gridItemChoiceView.ClearSelection();
        //    gridItemChoiceView.SelectRow(0);
        //}

        /// <summary>
        /// Show the detailed report for the item on the focused row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemChoiceView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow dr = view.GetFocusedDataRow();
                if (dr != null)
                {
                    dtAdjustDate.Value = DateTime.Now;
                    dtAdjustDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtAdjustDate.Text);
                    int month = dtCur.Month;
                    //int year = ((month < 11) ? dtCur.Year : dtCur.Year + 1);
                    int year = dtCur.Year;
                    dtAdjustDate.CustomFormat = "MMM dd,yyyy";
                    int itemId = Convert.ToInt32(dr["ItemID"]);
                    ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                    con.ShowDialog();
                }
            }
        }

        private void gridItemChoiceView_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = view.GetFocusedDataRow();
            dr["IsSelected"] = ((dr["IsSelected"] == DBNull.Value) || !Convert.ToBoolean(dr["IsSelected"])); // true;
            dr.EndEdit();
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();

            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;

            if (b)
            {
                try
                {
                    dtSelectedTable.ImportRow(dr);
                }
                catch { }
            }
            else
            {
                int id = Convert.ToInt32(dr["ReceiveID"]);
                DataRow rw = dtSelectedTable.Rows.Find(id);
                if (rw != null)
                {
                    dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = dtRecGrid.Select(String.Format("ReceiveID = {0}", dr["ReceiveID"]));// dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                        foreach (DataRow r in dataRows)
                        {
                            r.Delete();
                        }
                    }
                    catch { }
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {

            if (!ckExpired.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] >= #{0}# && [TypeID]={1}", DateTime.Now, (int)lkCategories.EditValue);
                //gridItemChoiceView.RefreshData();
            }
            else if (ckExpired.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[ExpiryDate] < #{0}# && [TypeID]={1}", DateTime.Now, (int)lkCategories.EditValue);
            }

        }


        private void unitrepositoryItemLookUpEdit_Enter_1(object sender, EventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit == null) return;
            var clone = new ItemUnit();
            var row = gridAdjView.GetFocusedDataRow();
            var id = Convert.ToInt32(row["ID"]);
            var filterunit = clone.LoadFromSQl(id);
            //UnitsbindingSource.DataSource = clone.DefaultView;
            edit.Properties.DataSource = filterunit;
            edit.Properties.DisplayMember = "Text";
            edit.Properties.ValueMember = "ID";
        }

    }
}