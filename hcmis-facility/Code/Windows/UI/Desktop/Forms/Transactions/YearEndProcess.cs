using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;


namespace PharmInventory.Forms.Transactions
{
    /// <summary>
    /// Used to manage inventory data.
    /// </summary\>
    public partial class YearEndProcess : XtraForm
    {
        private DataTable dtRecGrid = new DataTable();
       // private int storeId = 0;
        public YearEndProcess()
        {
            InitializeComponent();
        }

        public YearEndProcess(bool giveDefaultValueToPhysicalInventory)
        {
            InitializeComponent();
            _defaultValueToPhysicalInventory = giveDefaultValueToPhysicalInventory;
        }

        #region Members
        DataTable dtBB;
        private bool _defaultValueToPhysicalInventory;
        #endregion

        /// <summary>
        /// The save button should be active only when the date is Sene 30 or in the month of Hamle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YearEndProcess_Load(object sender, EventArgs e)
        {
            var ethDate = new EthiopianDate.EthiopianDate();

            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;
            btnSave.Enabled = false;
            var unit = new ItemUnit();
            var allunits = unit.GetAllUnits();
            unitBindingSource.DataSource = allunits.DefaultView;
            var unitcolumn = ((GridView)grdYearEnd.MainView).Columns[9];
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    unitcolumn.Visible = false;
                    break;
                case 2:
                    unitcolumn.Visible = true;
                    break;
                default:
                    unitcolumn.Visible = true;
                   break;
            }
            var str = new Stores();
            str.GetActiveStores();

            cboStores.Properties.DataSource = str.DefaultView;
            cboStores.ItemIndex = 0;
            dtDate.CustomFormat = "MMMM dd, yyyy";
          
        }

        /// <summary>
        /// Populate the items.
        /// </summary>
        /// <param name="dtItm"></param>
        /// <param name="year"></param>
        private void PopulateItemList(DataTable dtItm, int year)
        {
            dtBB = new DataTable();
            var storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    BuildStoreInventoryList(year, storeId, dtItm);
                    break;
                case 2:

                    BuildStoreInventoryListForHandleUnit(year, storeId, dtItm);
                    break;
                case 3:
                    BuildStoreInventoryListForHandleUnit(year, storeId, dtItm);
                    break;
            }
        }


        private void BuildStoreInventoryListForHandleUnit(int year, int storeId, DataTable dtItm)
        {
            string[] str = { "Item Name", "Batch No.", "Remark" };
            foreach (string co in str)
            {
                dtBB.Columns.Add(co);
            }
            str = new string[] { "ItemId", "No.", "Beginning Balance", "Ending Balance(SOH)", "Physical Inventory", "ID", "RecID", "UnitID" };//, "Change Since Sene 30" };

            foreach (string co in str)
            {
                dtBB.Columns.Add(co, typeof(int));
            }
            int count = 1;
            var yProcess = new YearEnd();
            var bal = new Balance();

            dtDate.Value = DateTime.Now;
            var dtCurent = new DateTime();
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtDate.Text);

            var recDoc = new ReceiveDoc();
            int month = dtCurent.Month;

            if ((dtCurent.Month == 10 && dtCurent.Day == 30) || dtCurent.Month == 11)
            {
                btnSave.Enabled = ((!yProcess.IsInventoryComplete(year, storeId)));
               //btnSave.Enabled = true;
                month = 10;
            }
            else
                btnSave.Enabled = false;


            var yEnd = new YearEnd();
            foreach (DataRow dr in dtItm.Rows)//For each item
            {
                var itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                int itemId= Convert.ToInt32(dr["ID"]);
                var unitid = Convert.ToInt32(dr["UnitID"]);
                var BalanceExists = (yProcess.DoesBalanceExistByUnit(year, itemId,storeId, false,unitid));

                //We don't want to display those items whose inventory has already been done.
                if (BalanceExists)
                    continue;
                 

               // Int64 soh = bal.GetSOHByUnit(Convert.ToInt32(dr["ID"]), storeId, month, year,unitid);
                Int64 soh = bal.GetSOHByUnitOptimized(Convert.ToInt32(dr["ID"]), storeId, month, year, unitid);
                Int64 bbal = yEnd.GetBBalanceByUnit(year, storeId, Convert.ToInt32(dr["ID"]), month,unitid);

                yProcess.GetBalanceByItemIdByUnitID(year, storeId, Convert.ToInt32(dr["ID"]),unitid);

                Int64 BB = (yProcess.RowCount > 0) ? yProcess.BBalance : bbal;
                Int64 EB = ((yProcess.RowCount > 0 && yProcess.EBalance != 0) ? yProcess.EBalance : soh);
                string Phy = (yProcess.RowCount > 0) ? yProcess.PhysicalInventory.ToString() : (_defaultValueToPhysicalInventory ? EB.ToString() : "");
                string remark = (yProcess.RowCount > 0) ? yProcess.Remark : "";

                DataRowView drv = dtBB.DefaultView.AddNew();
                if (yProcess.RowCount > 0)
                {
                    drv["ID"] = yProcess.ID;
                }
                drv["ItemId"] = dr["ID"];
                drv["No."] = count;
                drv["Item Name"] = itemName;
                drv["Beginning Balance"] = BB;
                drv["Ending Balance(SOH)"] = EB;
                drv["UnitID"] = unitid;

                if (Phy != "")
                {
                    drv["Physical Inventory"] = Phy;
                }
                drv["RecID"] = -1;
                drv["Remark"] = remark;
                count++;


                int theLastBalance = 0;
                DataTable dtBatchs = recDoc.GetBatchWithValueByUnit(storeId, Convert.ToInt32(dr["ID"]), dtCurent ,unitid);
                foreach (DataRow drBatch in dtBatchs.Rows) //For each batch
                {
                    if (drBatch["QuantityLeft"] != DBNull.Value && Convert.ToInt64(drBatch["QuantityLeft"]) != 0)
                    {
                       drv = dtBB.DefaultView.AddNew();
                        

                        drv["Item Name"] = ">>";
                        drv["UnitID"] =drBatch["UnitID"];
                        drv["Batch No."] = drBatch["BatchNo"];
                        drv["Ending Balance(SOH)"] = Convert.ToInt64(drBatch["QuantityLeft"]);
                        //Now if the physical inventory is chosen to be default value, we set it to the ending balance of last year.
                        if (_defaultValueToPhysicalInventory)
                            drv["Physical Inventory"] = drBatch["QuantityLeft"].ToString();

                        theLastBalance += Convert.ToInt32(drBatch["QuantityLeft"]);
                        drv["RecID"] = drBatch["ID"];
                    }
                }
                //}
            }

            grdYearEnd.DataSource = dtBB;
            dtDate.CustomFormat = "MMMM dd, yyyy"; //throw new NotImplementedException();
        }


        private void BuildStoreInventoryList(int year, int storeId, DataTable dtItm)
        {
            string[] str = { "Item Name", "Batch No.", "Remark" };
            foreach (string co in str)
            {
                dtBB.Columns.Add(co);
            }
            str = new string[] { "ItemId", "No.", "Beginning Balance", "Ending Balance(SOH)", "Physical Inventory", "ID", "RecID"};//, "Change Since Sene 30" };
            
            foreach (string co in str)
            {
                dtBB.Columns.Add(co, typeof(int));
            }
            int count = 1;
            var yProcess = new YearEnd();
            var bal = new Balance();

            dtDate.Value = DateTime.Now;
            DateTime dtCurent = new DateTime();
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtDate.Text);

            var recDoc = new ReceiveDoc();
            int month = dtCurent.Month;
            //btnSave.Enabled = true;
            //CALENDAR:

            //if ((dtCurent.Month == 10 && dtCurent.Day == 30) || dtCurent.Month == 11)
            //{
            //    //btnSave.Enabled = ((!yProcess.IsInventoryComplete(year, storeId)));
            //    btnSave.Enabled =true;
            //    month = 10;
             
            //}
            //else
            //    btnSave.Enabled = false;

            var yEnd = new YearEnd();


            foreach (DataRow dr in dtItm.Rows)//For each item
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                int itemID = Convert.ToInt32(dr["ID"]);
                bool BalanceExists = (yProcess.DoesBalanceExist(year, storeId, itemID, false));

                //We don't want to display those items whose inventory has already been done.
                if (BalanceExists)
                    continue;

                //bereket
                //Int64 soh = bal.GetSOH(Convert.ToInt32(dr["ID"]), storeId, month, year);
                Int64 soh = bal.GetSOHOptimized(Convert.ToInt32(dr["ID"]), storeId, month, year);
                Int64 bbal = yEnd.GetBBalance(year, storeId, Convert.ToInt32(dr["ID"]), month);
                
                yProcess.GetBalanceByItemId(year, storeId, Convert.ToInt32(dr["ID"]));

                Int64 BB = (yProcess.RowCount > 0) ? yProcess.BBalance : bbal;
                Int64 EB = ((yProcess.RowCount > 0 && yProcess.EBalance != 0) ? yProcess.EBalance : soh);
                //Now if the physical inventory is chosen to be default value, we set it to the ending balance of last year.
                string Phy = (yProcess.RowCount > 0) ? yProcess.PhysicalInventory.ToString() : (_defaultValueToPhysicalInventory ? EB.ToString() : "");
                int id = (yProcess.RowCount > 0) ? yProcess.ID : 0;
                string remark = (yProcess.RowCount > 0) ? yProcess.Remark : "";
                //object[] obj = {Convert.ToInt32(dr["ID"]),count,itemName,"",BB,((EB != 0)?EB.ToString("#,###"):"0"),Phy,remark,id,-1};
                //dtBB.Rows.Add(obj);
                DataRowView drv = dtBB.DefaultView.AddNew();
                if (yProcess.RowCount > 0)
                {
                    drv["ID"] = yProcess.ID;
                }
                drv["ItemId"] = dr["ID"];
                drv["No."] = count;
                drv["Item Name"] = itemName;
                drv["Beginning Balance"] = BB;
                drv["Ending Balance(SOH)"] = EB;
               
                if (Phy != "")
                {
                    drv["Physical Inventory"] = Phy;
                }
                drv["RecID"] = -1;
                drv["Remark"] = remark;
                var ethioDate = new EthiopianDate.EthiopianDate(year, 1, 1);
                //drv["Change Since Sene 30"] = BLL.Balance.GetChangeAfterDate(itemID, storeId, ethioDate.EndOfFiscalYear.ToGregorianDate());
                count++;
                //if (!BalanceExists)
                //{
                int theLastBalance = 0;
                DataTable dtBatchs = recDoc.GetBatchWithValue(storeId, Convert.ToInt32(dr["ID"]), dtCurent);
                foreach (DataRow drBatch in dtBatchs.Rows) //For each batch
                {
                    if (drBatch["QuantityLeft"] != DBNull.Value && Convert.ToInt64(drBatch["QuantityLeft"]) != 0)
                    {
                        drv = dtBB.DefaultView.AddNew();

                        drv["Item Name"] = ">>";
                        drv["Batch No."] = drBatch["BatchNo"];
                        drv["Ending Balance(SOH)"] = Convert.ToInt64(drBatch["QuantityLeft"]);
                        //Now if the physical inventory is chosen to be default value, we set it to the ending balance of last year.
                        if (_defaultValueToPhysicalInventory)
                            drv["Physical Inventory"] = drBatch["QuantityLeft"].ToString();

                        theLastBalance += Convert.ToInt32(drBatch["QuantityLeft"]);
                        drv["RecID"] = drBatch["ID"];
                    }
                }
                //}
            }

            grdYearEnd.DataSource = dtBB;
            dtDate.CustomFormat = "MMMM dd, yyyy";
        }



        private string FilterNumbers(string unformattedNumber)
        {
            string numberExtractorExpression = @"(\d+\.?\d*|\.\d+)";

            MatchCollection formattedNumber = Regex.Matches(unformattedNumber, numberExtractorExpression);

            StringBuilder numbers = new StringBuilder();

            for (int i = 0; i != formattedNumber.Count; ++i)
            {
                numbers.Append(formattedNumber[i].Value);
            }
            if (numbers.Length > 6)
            {
                return numbers.ToString().Substring(0, 6);
            }
            if (numbers.Length == 0)
            {

            }
            return numbers.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    if (SaveInventoryWithOutUnit())
                        LoadInventoryItems();
                    break;
                case 2:
                    if (SaveInventory())
                        LoadInventoryItems();
                    break;
                case 3:
                    if (SaveInventory())
                        LoadInventoryItems();
                    break;
            }

            ManageSaveButton();
        }

        private bool SaveInventoryWithOutUnit()
        {
            var yEnd = new YearEnd();
            var rec = new ReceiveDoc();

            if (IsValid())
            {
                dtDate.Value = DateTime.Now;
                DateTime dtCurent = new DateTime();
                dtDate.CustomFormat = "MM/dd/yyyy";
                dtCurent = ConvertDate.DateConverter(dtDate.Text);

                int year = dtCurent.Year;
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable yearEndTable = (DataTable)grdYearEnd.DataSource;
                    
                    for (int i = 0; i < dtBB.Rows.Count; i++)
                    {
                        int id = 0;
                        int storeID = Convert.ToInt32(cboStores.EditValue);
                        if (dtBB.Rows[i]["ItemID"] != DBNull.Value)
                        {
                            var itemID = Convert.ToInt32(dtBB.Rows[i]["ItemID"]);
                            //var unitID = Convert.ToInt32(dtBB.Rows[i]["UnitID"]);
                            id = yEnd.LoadByItemIDStoreAndYear(itemID, storeID, year, false);
                        }
                        if (id != 0 && !ReferenceEquals(yearEndTable.Rows[i]["Physical Inventory"], string.Empty))//There is already a manual entry in the yearend table.
                        {
                            //yEnd.LoadByPrimaryKey(id);
                            yEnd.BBalance = Convert.ToInt64(FilterNumbers(yearEndTable.Rows[i]["Beginning Balance"].ToString()));
                            yEnd.EBalance = Int64.Parse(FilterNumbers(yearEndTable.Rows[i]["Ending Balance(SOH)"].ToString()), NumberStyles.AllowThousands);
                            yEnd.PhysicalInventory = Convert.ToInt64(FilterNumbers(yearEndTable.Rows[i]["Physical Inventory"].ToString()));
                            //yEnd.BatchNo = yearEndTable.Rows[i]["Batch No."].ToString();
                            yEnd.UnitID = 0;
                            yEnd.Remark = yearEndTable.Rows[i]["Remark"].ToString();
                            yEnd.AutomaticallyEntered = false;
                            yEnd.Save();
                        }
                        else//There is no entry in the yearend table under this item name that has been entered manually.
                        {
                            DataRow cRow = dtBB.Rows[i];
                            if (!ReferenceEquals(cRow["Physical Inventory"], string.Empty) && cRow["ItemID"] != DBNull.Value)
                            {
                                var itemID = Convert.ToInt32(cRow["ItemID"]);
                                var unitID = 0;
                                YearEnd.PurgeAutomaticallyEnteredInventoryForUnit(itemID, storeID, year, unitID);
                                //if (areAllBatchesPhyInventoryNullValue == false) //We want to add an inventory record if at least one of the batches has a non empty value.
                                //{
                                yEnd.AddNew();
                                yEnd.ItemID = itemID;
                                yEnd.StoreID = storeID;
                                yEnd.Year = year;
                                yEnd.BBalance = Convert.ToInt64(cRow["Beginning Balance"]);
                                Int64 endBal = Convert.ToInt64(cRow["Ending Balance(SOH)"]);
                                //yEnd.BatchNo = cRow["Batch No."].ToString();
                                yEnd.EBalance = endBal;// Convert.ToInt64(yearEndTable.Rows[i].Cells[5].Value);

                                if (cRow["Physical Inventory"] != DBNull.Value)
                                    yEnd.PhysicalInventory = Convert.ToInt64(cRow["Physical Inventory"]);


                                //yEnd.PhysicalInventory = physicalInventoryTotal;
                                yEnd.UnitID = 0;
                                 yEnd.Remark = cRow["Remark"].ToString();

                                yEnd.AutomaticallyEntered = cRow["Physical Inventory"] == DBNull.Value;
                                yEnd.Save();
                                //}


                                //long physicalInventoryTotal = 0;
                                //bool areAllBatchesPhyInventoryNullValue = true;
                                //if (endBal != yEnd.PhysicalInventory)
                                if (true)
                                {
                                    int k = i + 1;

                                    if (k < dtBB.Rows.Count)
                                    {
                                        while (Convert.ToInt32(dtBB.Rows[k]["RecID"]) != -1)
                                        {
                                            if (dtBB.Rows[k]["Physical Inventory"] != DBNull.Value)
                                            {
                                                //areAllBatchesPhyInventoryNullValue = false;
                                                long batchPhysicalInventory =
                                                    Convert.ToInt64(dtBB.Rows[k]["Physical Inventory"]);
                                                //physicalInventoryTotal += batchPhysicalInventory;
                                                rec.LoadByPrimaryKey(Convert.ToInt32(dtBB.Rows[k]["RecID"]));
                                                rec.QuantityLeft = Convert.ToInt64(batchPhysicalInventory);
                                                rec.Remark = "Physical Inventory";
                                                rec.UnitID = 0;
                                                rec.Out = rec.QuantityLeft == 0;
                                                rec.Save();
                                            }
                                            k++;
                                            if (k >= yearEndTable.Rows.Count)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    XtraMessageBox.Show("Transaction Succsfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool SaveInventory()
        {
            var yEnd = new YearEnd();
            var rec = new ReceiveDoc();
            
            if (IsValid())
            {
                dtDate.Value = DateTime.Now;
                DateTime dtCurent = new DateTime();
                dtDate.CustomFormat = "MM/dd/yyyy";
                dtCurent = ConvertDate.DateConverter(dtDate.Text);

                int year = dtCurent.Year;
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable yearEndTable = (DataTable)grdYearEnd.DataSource;
                    
                    for (int i = 0; i < dtBB.Rows.Count; i++)
                    {
                        int id = 0;
                        int storeID = Convert.ToInt32(cboStores.EditValue);
                        if (dtBB.Rows[i]["ItemID"] != DBNull.Value)
                        {
                            var itemID = Convert.ToInt32(dtBB.Rows[i]["ItemID"]);
                            var unitID = Convert.ToInt32(dtBB.Rows[i]["UnitID"]);
                            id = yEnd.LoadByItemIDStoreAndYearAndUnit(itemID, storeID, year, false,unitID);
                        }
                        if (id != 0 && !ReferenceEquals(yearEndTable.Rows[i]["Physical Inventory"], string.Empty))//There is already a manual entry in the yearend table.
                        {
                            //yEnd.LoadByPrimaryKey(id);
                            yEnd.BBalance = Convert.ToInt64(FilterNumbers(yearEndTable.Rows[i]["Beginning Balance"].ToString()));
                            yEnd.EBalance = Int64.Parse(FilterNumbers(yearEndTable.Rows[i]["Ending Balance(SOH)"].ToString()), NumberStyles.AllowThousands);
                            yEnd.PhysicalInventory = Convert.ToInt64(FilterNumbers(yearEndTable.Rows[i]["Physical Inventory"].ToString()));
                            //yEnd.BatchNo = yearEndTable.Rows[i]["Batch No."].ToString();
                            yEnd.UnitID =  Convert.ToInt32(yearEndTable.Rows[i]["UnitID"]);
                            yEnd.Remark = yearEndTable.Rows[i]["Remark"].ToString();
                            yEnd.AutomaticallyEntered = false;
                            yEnd.Save();
                        }
                        else//There is no entry in the yearend table under this item name that has been entered manually.
                        {
                           DataRow cRow = dtBB.Rows[i];
                           if (!ReferenceEquals(cRow["Physical Inventory"], string.Empty) && cRow["ItemID"] != DBNull.Value)
                           {
                                var itemID = Convert.ToInt32(cRow["ItemID"]);
                                var unitID = Convert.ToInt32(cRow["UnitID"]);
                                YearEnd.PurgeAutomaticallyEnteredInventoryForUnit(itemID, storeID, year,unitID);
                                
                                yEnd.AddNew();
                                yEnd.ItemID = itemID;
                                yEnd.StoreID = storeID;
                                yEnd.Year = year;
                                yEnd.BBalance = Convert.ToInt64(cRow["Beginning Balance"]);
                                Int64 endBal = Convert.ToInt64(cRow["Ending Balance(SOH)"]);
                                yEnd.EBalance = endBal;// Convert.ToInt64(yearEndTable.Rows[i].Cells[5].Value);

                                if (cRow["Physical Inventory"] !=DBNull.Value)
                                    yEnd.PhysicalInventory = Convert.ToInt64(cRow["Physical Inventory"]);
                               
                                yEnd.UnitID = Convert.ToInt32(cRow["UnitID"]);
                                yEnd.Remark = cRow["Remark"].ToString();

                                yEnd.AutomaticallyEntered = cRow["Physical Inventory"] == DBNull.Value;
                                yEnd.Save();

                                //long physicalInventoryTotal = 0;
                                //bool areAllBatchesPhyInventoryNullValue = true;
                                //if (endBal != yEnd.PhysicalInventory)
                                if (true) 
                                {
                                    int k = i + 1;

                                    if (k < dtBB.Rows.Count)
                                    {
                                        while (Convert.ToInt32(dtBB.Rows[k]["RecID"]) != -1)
                                        {
                                            if (dtBB.Rows[k]["Physical Inventory"] != DBNull.Value)
                                            {
                                                //areAllBatchesPhyInventoryNullValue = false;
                                                long batchPhysicalInventory =
                                                    Convert.ToInt64(dtBB.Rows[k]["Physical Inventory"]);
                                                //physicalInventoryTotal += batchPhysicalInventory;
                                                rec.LoadByPrimaryKey(Convert.ToInt32(dtBB.Rows[k]["RecID"]));
                                                rec.QuantityLeft = Convert.ToInt64(batchPhysicalInventory);
                                                rec.Remark = "Physical Inventory";
                                                rec.UnitID = Convert.ToInt32(dtBB.Rows[k]["UnitID"]);
                                                rec.Out = rec.QuantityLeft == 0;
                                                rec.Save();
                                            }
                                            k++;
                                            if (k >= yearEndTable.Rows.Count)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    XtraMessageBox.Show("Transaction Successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsValid()
        {
            DataTable yearEndTable = (DataTable)grdYearEnd.DataSource;

            for (int i = 0; i < dtBB.Rows.Count; i++)
            {
                DataRow cRow = dtBB.Rows[i];
                if (cRow["Physical Inventory"] != DBNull.Value && cRow["ItemID"] != DBNull.Value)
                {
                    Int64 endBal = Convert.ToInt64(cRow["Ending Balance(SOH)"]);
                    Int64 phyInv = Convert.ToInt64(cRow["Physical Inventory"]);
                    string itemName = cRow["Item Name"].ToString();
                    long physicalInventoryTotal = 0;
                    //if (endBal != phyInv)//Was commented out
                    //{
                        int k = i + 1;

                        if (k < dtBB.Rows.Count)
                        {
                            while (Convert.ToInt32(dtBB.Rows[k]["RecID"]) != -1)
                            {
                                try
                                {
                                 if (dtBB.Rows[k]["Physical Inventory"] != DBNull.Value)
                                {
                                    //areAllBatchesPhyInventoryNullValue = false;
                                    long batchPhysicalInventory = Convert.ToInt64(dtBB.Rows[k]["Physical Inventory"]);
                                    physicalInventoryTotal += batchPhysicalInventory;
                                }

                                k++;
                                if (k >= yearEndTable.Rows.Count)
                                    break;
                               }   
                                catch (Exception)
                                {
                                    if (dtBB.Rows[k]["Physical Inventory"] != DBNull.Value)
                                    {
                                        //areAllBatchesPhyInventoryNullValue = false;
                                        long batchPhysicalInventory = Convert.ToInt64(dtBB.Rows[k]["Physical Inventory"]);
                                        physicalInventoryTotal += batchPhysicalInventory;
                                    }

                                    k++;
                                    if (k >= yearEndTable.Rows.Count)
                                        break;
                                }
                            }
                              
                        }
                        if (phyInv != physicalInventoryTotal)
                        {
                            XtraMessageBox.Show("Validation has failed for item: " + itemName, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return false;
                        }
                        //}
                    }
                //}
            }

            return true;
        }


        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && lkCommodityTypes.EditValue != null)
            {
                LoadInventoryItems();
                //btnSave.Enabled = true;

                ManageSaveButton();
            }
        }

        private void ManageSaveButton()
        {
            dtDate.Value = DateTime.Now;
            DateTime dtCurent;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtDate.Text);

            if ((dtCurent.Month == 10 && dtCurent.Day == 30) || dtCurent.Month == 11)
            {
                if (grdYearEnd.DataSource != null)
                {
                    DataTable yearEndTable = (DataTable)grdYearEnd.DataSource;
                    if (yearEndTable.Rows.Count > 0)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                }

            }
            else
                btnSave.Enabled = false;

          
        }

        private void LoadInventoryItems()
        {
            dtDate.Value = DateTime.Now;
            DateTime dtCurent;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtDate.Text);

            int year = dtCurent.Year;
            var itm = new Items();
            DataTable dtItm;
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    if (ckExclude == null || (!ckExclude.Checked))
                        dtItm = itm.ExcludeNeverReceivedItems(Convert.ToInt32(cboStores.EditValue),
                                                              Convert.ToInt32(lkCommodityTypes.EditValue));
                    else dtItm = itm.GetAllItems(1, Convert.ToInt32(lkCommodityTypes.EditValue));
                    PopulateItemList(dtItm, year);
                    dtDate.CustomFormat = "MMMM dd, yyyy";
                    break;
                case 2:
                     if (ckExclude == null || (!ckExclude.Checked))
                        dtItm = itm.ExcludeNeverReceivedItemsForHandlingUnit(Convert.ToInt32(cboStores.EditValue),
                                                              Convert.ToInt32(lkCommodityTypes.EditValue));
                    else dtItm = itm.GetAllItems(1, Convert.ToInt32(lkCommodityTypes.EditValue));
                    PopulateItemList(dtItm, year);
                    dtDate.CustomFormat = "MMMM dd, yyyy";
                    break;
                case 3:
                    if (ckExclude == null || (!ckExclude.Checked)) dtItm = itm.ExcludeNeverReceivedItemsForHandlingUnit(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCommodityTypes.EditValue));
                    else dtItm = itm.GetAllItems(1, Convert.ToInt32(lkCommodityTypes.EditValue));
                    PopulateItemList(dtItm, year);
                    dtDate.CustomFormat = "MMMM dd, yyyy";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadInventoryItems();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog { Filter = "Microsoft Excel | *.xls" };

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                grdYearEnd.MainView.ExportToXls(saveDlg.FileName);
              
            }
         
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pcl.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            pcl.CreateDocument();
            pcl.ShowPreview();
           
            //grdYearEnd.Print();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string[] header = { "Ending Balance for " + cboStores.Text + " of year " + EthiopianDate.EthiopianDate.Now.Year };
            pcl.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(100, 0, 500, 300), BorderSide.None);
            //TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(20, 20, 200, 100), BorderSide.None);
            //TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(20, 40, 200, 100), BorderSide.None);
        }

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                LoadInventoryItems();
            }
        }

        private void repositoryItemTextEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow dr = grdViewYearEnd.GetDataRow(grdViewYearEnd.GetSelectedRows()[0]);
            if (dr != null)
            {
                string batchNo = dr["Batch No."].ToString();
                int recID = int.Parse(dr["RecID"].ToString());
                BLL.ReceiveDoc rec = new ReceiveDoc();

                if (recID == -1)
                {
                    XtraMessageBox.Show("Use this button only on invalid batches", "Nothing to Remove",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                rec.LoadByPrimaryKey(recID);
                int itemID = rec.ItemID;

                //Do another validation here (Make sure that the items that they try to remove have issues like the Total SOH not being equal to the sum of the listed batches and so forth.
                int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
                int month = EthiopianDate.EthiopianDate.Now.Month;
                int year = EthiopianDate.EthiopianDate.Now.Year;

                BLL.Balance bal = new Balance();
                BLL.Items itm = new Items();
                itm.LoadByPrimaryKey(itemID);

                long currentBalance = bal.GetSOH(itemID, storeId, month, year);
                long totalQuantityLeftInBatches = itm.TotalQuantityLeftInAllBatches(storeId);

                if (currentBalance == totalQuantityLeftInBatches)
                {
                    XtraMessageBox.Show(
                        "You do not have to use this button to remove this batch.  Please set the physical inventory 0 instead.  Use this button only for items with discrepancies.",
                        "Unapplicable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (XtraMessageBox.Show("This will make the quantity left for this received batch zero and remove it from this list.  Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BLL.ReceiveDoc.MarkReceivedBatchAsEmpty(recID))
                    {
                        dr.Delete();
                       
                    }
                }
            }
        }

        private void repositoryItemButtonEdit2_Click(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Now.Subtract(TimeSpan.FromDays(35));
            var dtCurent = new DateTime();
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurent = ConvertDate.DateConverter(dtDate.Text);

            DataRow dr = grdViewYearEnd.GetDataRow(grdViewYearEnd.GetSelectedRows()[0]);
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                        if(Convert.ToString(dr["Item Name"]) ==">>")
                        {
                            XtraMessageBox.Show("Please add batch with only full item name not with >> !", "Validation");
                            return;
                        }
                        var addbatch = new NewBatch(Convert.ToInt32(dr["ItemID"]), Convert.ToString(dr["Item Name"]), (int)cboStores.EditValue, dtCurent);
                        addbatch.ShowDialog();
                        grdViewYearEnd.RefreshData();
              
                    }
                    break;
                default:
                    {
                        if (Convert.ToString(dr["Item Name"]) == ">>")
                        {
                            XtraMessageBox.Show("Please add batch with only full item name not with >> !", "Validation");
                            return;
                        }
                        if (Convert.ToInt32(dr["UnitID"]) != null)
                        {
                            var addbatch = new NewBatch(Convert.ToInt32(dr["ItemID"]), Convert.ToString(dr["Item Name"]), Convert.ToInt32(dr["UnitID"]), (int)cboStores.EditValue, dtCurent);
                            addbatch.ShowDialog();
                            grdViewYearEnd.RefreshData();
                        }
                          
                    }
                    break;
            }


        }

        }

    
    }
