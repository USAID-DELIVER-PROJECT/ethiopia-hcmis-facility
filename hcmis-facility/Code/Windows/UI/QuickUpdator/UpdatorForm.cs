using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using System.ComponentModel;

namespace QuickUpdator
{
    /// <summary>
    /// Interaction logic for the quick updator Form
    /// This form is used to correct erroneous HCMIS databases
    /// </summary>
    public partial class UpdatorForm : Form
    {
        public UpdatorForm()
        {
            InitializeComponent();
        }

        private void btnUpdateOnlyOnce_Click(object sender, EventArgs e)
        {
            DataTable dtBB = new DataTable();
            Items itms = new Items();
            
            int storeId = 1;// (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;

            DataTable dtItm = itms.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue));
            string[] str = { "Item Name", "Batch No.", "Remark" };
            foreach (string co in str)
            {
                dtBB.Columns.Add(co);
            }
            str = new string[] { "ItemId", "No.", "Begining Balance", "Ending Balance(SOH)", "Physical Inventory", "ID", "RecID" };

            foreach (string co in str)
            {
                dtBB.Columns.Add(co, typeof(int));
            }
            int count = 1;
            YearEnd yProcess = new YearEnd();
            Balance bal = new Balance();

            //dtDate.Value = DateTime.Now;
            //DateTime dtCurent = new DateTime();// Convert.ToDateTime(dtDate.Text);
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //dtCurent = ConvertDate.DateConverter(dtDate.Text);

            ReceiveDoc recDoc = new ReceiveDoc();
            int month = 2;

            int year = 2003;

            YearEnd yEnd = new YearEnd();
            bool BalanceExists = (yProcess.DoesBalanceExist(year, storeId,false));

            //int mon = (year == dtCurent.Year) ? dtCurent.Month : 10;
            foreach (DataRow dr in dtItm.Rows)
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                int itemID = Convert.ToInt32(dr["ID"]);
                Int64 soh = bal.GetSOH(Convert.ToInt32(dr["ID"]), storeId, month, year);
                Int64 bbal = yEnd.GetBBalance(year, storeId, Convert.ToInt32(dr["ID"]), month);
                yProcess.GetBalanceByItemId(year, storeId, Convert.ToInt32(dr["ID"]));

                Int64 BB = (yProcess.RowCount > 0) ? yProcess.BBalance : bbal;
                Int64 EB = ((yProcess.RowCount > 0 && yProcess.EBalance != 0) ? yProcess.EBalance : soh);
                string Phy = (yProcess.RowCount > 0) ? yProcess.PhysicalInventory.ToString() : "";
                int id = (yProcess.RowCount > 0) ? yProcess.ID : 0;
                string remark = (yProcess.RowCount > 0) ? yProcess.Remark : "";
                //object[] obj = {Convert.ToInt32(dr["ID"]),count,itemName,"",BB,((EB != 0)?EB.ToString("#,###"):"0"),Phy,remark,id,-1};
                //dtBB.Rows.Add(obj);
                DataRowView drv = dtBB.DefaultView.AddNew();
                drv["ItemId"] = dr["ID"];
                drv["No."] = count;
                drv["Item Name"] = itemName;
                drv["Begining Balance"] = BB;
                drv["Ending Balance(SOH)"] = EB;
                if (Phy != "")
                {
                    drv["Physical Inventory"] = Phy;
                }
                drv["RecID"] = -1;
                drv["Remark"] = remark;
                count++;
                if (!BalanceExists)
                {
                    // this is the wierdest fixer ever

                    int theLastBalance = 0;
                    //DataTable dtBatchs = recDoc.GetBatchWithValue(storeId, Convert.ToInt32(dr["ID"]), dtCurent);
                    //foreach (DataRow drBatch in dtBatchs.Rows)
                    //{

                    //    if (drBatch["QuantityLeft"] != DBNull.Value && Convert.ToInt64(drBatch["QuantityLeft"]) != 0)
                    //    {

                    //        drv = dtBB.DefaultView.AddNew();

                    //        drv["Item Name"] = ">>";
                    //        drv["Batch No."] = drBatch["BatchNo"];
                    //        drv["Ending Balance(SOH)"] = Convert.ToInt64(drBatch["QuantityLeft"]);
                    //        theLastBalance += Convert.ToInt32(drBatch["QuantityLeft"]);
                    //        drv["RecID"] = drBatch["ID"];
                    //    }
                    //}
                    //try
                    //{
                    //    if ((theLastBalance - EB) != 0)
                    //    {
                    //        int ID = Convert.ToInt32(dtBatchs.Rows[dtBatchs.Rows.Count - 1]);
                    //        ReceiveDoc rd = new ReceiveDoc();
                    //        rd.LoadByPrimaryKey(ID);
                    //        rd.QuantityLeft -= (theLastBalance - EB);
                    //        rd.Quantity -= theLastBalance;

                    //        if (rd.QuantityLeft < 0)
                    //        {
                    //            rd.QuantityLeft = 0;
                    //            rd.Out = true;
                    //            if (rd.Quantity < 0)
                    //            {
                    //                rd.Quantity = 0;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            rd.Out = false;
                    //        }

                    //        rd.Save();
                    //    }
                    //}
                    //catch
                    //{
                    //    ReceiveDoc rd = new ReceiveDoc();
                    //    rd.GetLastReceivedBatchAfterIssue(storeId, itemID);
                    //    rd.Quantity -= (theLastBalance - EB);
                    //    rd.QuantityLeft -= (theLastBalance - EB);
                    //    rd.Save();
                    //};
                }
            }
        }

        private void removeNegatives_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you would like to remove the -ve items", "Confirmation", MessageBoxButtons.YesNo))
            {
                Stores strs = new Stores();
                strs.LoadAll();
                string message = "";
                while (!strs.EOF)
                {
                    Balance balance = new Balance();
                    DataTable dtbl = balance.GetSOH(strs.ID, 3, 2003);

                    var x = from y in dtbl.AsEnumerable()
                            where Convert.ToDouble(y["SOH"]) < 0
                            select y;
                    ABC abc = new ABC();
                    foreach (var b in x)
                    {
                        abc.LoadQuery(string.Format("delete from Disposal where ItemID = {0} and StoreID = {1}", b["ID"], strs.ID));
                        abc.LoadQuery(string.Format("delete from YearEnd where ItemID = {0} and StoreID = {1}", b["ID"], strs.ID));
                        abc.LoadQuery(string.Format("delete from IssueDoc where ItemID = {0} and StoreID = {1}", b["ID"], strs.ID));
                        abc.LoadQuery(string.Format("delete from ReceiveDoc where ItemID = {0} and StoreID = {1}", b["ID"], strs.ID));
                    }
                    message += string.Format("{0} Items to be deleted from {1} \n", x.Count(), strs.StoreName);

                    strs.MoveNext();
                }

                XtraMessageBox.Show(message);
                
            
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(String.Format("Are you sure you want to remove {0}", lkItems.Text), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ABC abc = new ABC();
                int storeID = Convert.ToInt32(lkStores.EditValue);
                int itemID = Convert.ToInt32(lkItems.EditValue);
                abc.LoadQuery(string.Format("delete from Disposal where ItemID = {0} and StoreID = {1}", itemID, storeID));
                abc.LoadQuery(string.Format("delete from YearEnd where ItemID = {0} and StoreID = {1}", itemID, storeID));
                abc.LoadQuery(string.Format("delete from IssueDoc where ItemID = {0} and StoreID = {1}", itemID, storeID));
                abc.LoadQuery(string.Format("delete from ReceiveDoc where ItemID = {0} and StoreID = {1}", itemID, storeID));

                XtraMessageBox.Show("The Item Has been removed!");
                lkStores_EditValueChanged(null, null);
            }
        }

        /// <summary>
        /// Loads the doodads connection string from the registry and loads the lookups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatorForm_Load(object sender, EventArgs e)
        {

            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;
            
            if (MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString == "")
            {
                Program.ConnectionManager.ShowDialog();
            }

            Stores stors = new Stores();
            stors.LoadAll();
            lkStores.Properties.DataSource = stors.DefaultView;
            lkStores.ItemIndex = 0;
            ddnStore.Properties.DataSource = stors.DefaultView;
            ddnStore.ItemIndex = 0;
        }

        private void lkStores_EditValueChanged(object sender, EventArgs e)
        {
            Items itms = new Items();
            Stores stores = new Stores();
            lkItems.Properties.DataSource = stores.GetActiveItems(Convert.ToInt32(lkStores.EditValue));
            lkItems.ItemIndex = 0;
        }

        private void ddnItem_EditValueChanged(object sender, EventArgs e)
        {
            BLL.ReceiveDoc rec = new ReceiveDoc();
            //grdViewItemBatches.DataSource = rec.GetBatchWithValue(int.Parse(ddnStore.EditValue.ToString()),
            //                                                      int.Parse(ddnItem.EditValue.ToString()));
        }

        private void ddnStore_EditValueChanged(object sender, EventArgs e)
        {
            Items itms = new Items();
            Stores stores = new Stores();
            ddnItem.Properties.DataSource = stores.GetActiveItems(Convert.ToInt32(ddnStore.EditValue));
            ddnItem.ItemIndex = 0;
        }
    }
}
