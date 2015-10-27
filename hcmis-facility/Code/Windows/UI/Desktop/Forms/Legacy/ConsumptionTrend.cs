using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory
{
    public partial class ConsumptionTrend : Form
    {
        public ConsumptionTrend()
        {
            InitializeComponent();
        }
        int catID = 0;
        DateTime dtCurrent = new DateTime();

        private void ManageItems_Load(object sender, EventArgs e)
        {
            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;

            PopulateCatTree();

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            Programs prog = new Programs();
            DataTable dtProg = new DataTable();
            dtProg = prog.GetSubPrograms();
            object[] objProg = { 0, "All Programs", "", 0, "" };
            dtProg.Rows.Add(objProg);
            cboSubProgram.DataSource = dtProg;
            cboSubProgram.SelectedIndex = -1;
            cboSubProgram.Text = "Select Program";

            ReceivingUnits rec = new ReceivingUnits();
            DataTable drRec = rec.GetAllApplicableDU();
            cboIssuedTo.DataSource = drRec;
            cboIssuedTo.SelectedIndex = -1;
            cboIssuedTo.Text = "Select Issue Location";

            int month = dtCurrent.Month;
            int year = ((dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year + 1);
            
            DataTable dtyears = Items.AllYears();

            foreach (DataRow drYears in dtyears.Rows)
            {
                int yr = Convert.ToInt32(drYears["year"]);
                cboYear.Items.Add(yr);
            }
            bool added = true;
            for (int x = 0; x < cboYear.Items.Count; x++)//to check if the current year is included or not
            {
                if (Convert.ToInt64(cboYear.Items[x]) == year)
                {
                    added = false;
                    break;
                }
            }
            if (added)
            {
                cboYear.Items.Add(year);
            }
            cboYear.SelectedItem = year;
        }

        private void PopulateCatTree()
        {
            ProductTree.Nodes.Clear();
            if (Convert.ToInt32(lkCommodityTypes.EditValue) == BLL.Type.Constants.Pharmacuticals)
            {
                Category cat = new Category();
                SubCategory subCat = new SubCategory();
                Product prod = new Product();
                cat.LoadAll();
                cat.Sort = "CategoryName";
                ProductTree.Nodes.Add("All0", "All");
                foreach (DataRowView dv in cat.DefaultView)
                {
                    TreeNode nodes = new TreeNode();
                    nodes.Name = "cat" + dv["ID"].ToString();
                    nodes.Text = dv["CategoryName"].ToString() + " (" + dv["CategoryCode"].ToString() + ")";
                    nodes.ToolTipText = "Double Click to List";
                    subCat.GetSubCategory(Convert.ToInt32(dv["ID"]));
                    subCat.Sort = "SubCategoryName";
                    foreach (DataRowView subDv in subCat.DefaultView)
                    {

                        TreeNode subNodes = new TreeNode();
                        subNodes.Name = "sub" + subDv["ID"].ToString();
                        subNodes.Text = subDv["SubCategoryName"].ToString() + " (" + subDv["SubCategoryCode"].ToString() + ")";
                        subNodes.ToolTipText = "Double Click to List";

                        nodes.Nodes.Add(subNodes);
                    }
                    ProductTree.Nodes[0].Nodes.Add(nodes);

                }
                ProductTree.Nodes[0].Expand();
            }
            else
            {
                SupplyCategory scat = new SupplyCategory();
                scat.LoadAll();
                scat.Sort = "Name";
                ProductTree.Nodes.Add("Als0", "All");
                foreach (DataRowView dv in scat.DefaultView)
                {
                    TreeNode nodes = new TreeNode();
                    nodes.Name = "sup" + dv["ID"].ToString();
                    nodes.Text = dv["Name"].ToString();
                    nodes.ToolTipText = "Double Click to List";
                    ProductTree.Nodes[0].Nodes.Add(nodes);

                }
                ProductTree.Nodes[0].Expand();
            }

        }

        public void PopulateItemList(DataTable dtItem)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtItem.Rows.Count;

            GeneralInfo pipline = new GeneralInfo();
            pipline.LoadAll();
            int min = pipline.Min;
            int max = pipline.Max;
            int storeId = (cboStores.SelectedValue != null)?Convert.ToInt32(cboStores.SelectedValue):1;
            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            Balance bal = new Balance();
            Items itmIssues = new Items();
            int year = Convert.ToInt32(cboYear.SelectedItem);
            foreach (DataRow dr in dtItem.Rows)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                int yer = (dtCurrent.Month < 11) ? year : year - 1;// (dtCurrent.Month < 11) ? Convert.ToInt32(cboYear.SelectedItem) : Convert.ToInt32(cboYear.SelectedItem) - 1; 
                Int64 SOH = bal.GetSOH(Convert.ToInt32(dr["ID"]), storeId, dtCurrent.Month, yer);
                
                int[] mon = {11,12,1,2,3,4,5,6,7,8,9,10};
                
                long[] cons = new long[12];
                for (int i = 0; i < mon.Length;i++ )
                {
                    int yr = (mon[i] < 11) ? year : year - 1;
                    cons[i] = itmIssues.GetQuantityIssuedByItemPerMonth(mon[i], itemId, storeId, yr);
                  
                }
                string[] str = { count.ToString(), itemName, ((SOH != 0) ? SOH.ToString("#,###") : "0"), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem listItem = new ListViewItem(str);
                listItem.ToolTipText = itemName;
                listItem.Tag = dr["ID"];
                if (col != 0)
                {
                    listItem.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                lstItem.Items.Add(listItem);
                count++;
                progressBar1.PerformStep();
            }
            progressBar1.Visible = false;
        }

        private void ProductTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Items itm = new Items();
            DataTable dtItem = new DataTable();
            string value = ProductTree.SelectedNode.Name;
            string type = value.Substring(0, 3);
            int len = value.Length - 3;
            int categoryId = Convert.ToInt32(value.Substring(3,len));
            if (type == "cat")
            {
                dtItem = itm.GetItemsByCategory(categoryId);
                lblState.Text = "All Items under " + ProductTree.SelectedNode.Text + " Category";
                
            }
            else if(type == "sub")
            {
                dtItem = itm.GetItemsBySubCategory(categoryId);
                lblState.Text = "All Items under " + ProductTree.SelectedNode.Text + " Sub Category";
                catID = categoryId;
            }
            else if (type == "sup")
            {
                dtItem = itm.GetSupplyByCategory(categoryId);
                lblState.Text = "All Items under " + ProductTree.SelectedNode.Text + " Category";
                catID = categoryId;
            }
            else if (type == "Als")
            {
                dtItem = itm.GetAllSupply();
                lblState.Text = "All Items under " + ProductTree.SelectedNode.Text + " Category";
                catID = categoryId;
            }
            else
            {
                dtItem = itm.GetAllItems(1);
                lblState.Text = "All Items";
            }
            PopulateItemList(dtItem);
        }

        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null && cboYear.SelectedItem != null)
            {
                Items itm = new Items();
                DataTable dtItem = new DataTable();
                int storeId = Convert.ToInt32(cboStores.SelectedValue);
                
                    dtItem = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)
                        ) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId,7) : itm.GetAllItems(1)));
               
                PopulateItemList(dtItem);
                lblState.Text = "All Items";
            }
        }

        private void lstItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItem.SelectedItems[0].Tag != null)
            {
              
                int month = dtCurrent.Month;
                int year = Convert.ToInt32(cboYear.SelectedItem);

                int itemId = Convert.ToInt32(lstItem.SelectedItems[0].Tag);
                ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year,8);
                con.ShowDialog();
            }
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";

            string header = info.HospitalName + " Consumption Trend " + cboStores.Text + " Date: " + dtDate.Text;
            lstItem.Title = header;
            lstItem.FitToPage = true;
            lstItem.Print();

        }

        private void xpButton2_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";

            string[] header = { info.HospitalName, "Consumption Trend" , cboStores.Text , " Date: " + dtDate.Text };
            MainWindow.ExportToExcel(lstItem,header);
        }

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            ckExcNeverIssued.Enabled = ckExclude.Checked;
            if (cboStores.SelectedValue != null && (cboYear.SelectedItem != null))
            {
                Items itm = new Items();
                int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 0;
                DataTable dtItm = new DataTable();
                
                dtItm = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1));
                
                PopulateItemList(dtItm);
            }
        }

        private int sortColumn = -1;
        private void lstItem_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //int clicked = e.Column;
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lstItem.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstItem.Sorting = ((lstItem.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
            }
            int num = 0;
            switch (e.Column)
            {
                case 1:
                    num = 0;
                    break;
                default:
                    num = 1;
                    break;
            }
            this.lstItem.ListViewItemSorter = new ListViewItemComparer(e.Column, lstItem.Sorting, num);
            //this.lstItem.Sorting = ((lstItem.Sorting == SortOrder.Ascending)? SortOrder.Descending : SortOrder.Ascending);
            lstItem.Sort();

        }

     
        private void ckExcNeverIssued_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null && (cboYear.SelectedItem != null))
            {
                Items itm = new Items();
                int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 0;
                DataTable dtItm = new DataTable();
              
                dtItm = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1)));
               
                PopulateItemList(dtItm);
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null && (cboYear.SelectedItem != null))
            {
                Items itm = new Items();
                int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 0;
                DataTable dtItm = new DataTable();
                if (txtItemName.Text != "")
                {
                    
                        dtItm = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItemsByKeyword(storeId, txtItemName.Text) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItemsByKeyword(storeId, txtItemName.Text) : itm.GetItemByKeywordInList(txtItemName.Text)));
                   
                }
                else
                {
                        dtItm = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1)));
                 
                }
                PopulateItemList(dtItm);

            }
        }

        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateByProgram();
        }

        private void PopulateByProgram()
        {
            if (cboSubProgram.SelectedValue != null && cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                DataTable dtItem = new DataTable();
                if (Convert.ToInt32(cboSubProgram.SelectedValue) > 0)
                {
                    
                    dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItemsByProgram(Convert.ToInt32(cboSubProgram.SelectedValue), Convert.ToInt32(cboStores.SelectedValue)) : itm.GetItemsByProgram(Convert.ToInt32(cboSubProgram.SelectedValue)));
                    
                }
                else
                {
                      dtItem = (((ckExcNeverIssued.Checked && ckExclude.Checked) ? itm.GetReceivedNotIssuedItems(Convert.ToInt32(cboStores.SelectedValue),Convert.ToInt32(lkCommodityTypes.EditValue)) : (ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(Convert.ToInt32(cboStores.SelectedValue), Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1)));
                }
                PopulateItemList(dtItem);
            }
        }

        private void cboSubProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboIssuedTo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboIssuedTo.SelectedValue != null)
            {
                DataTable dtItem = new DataTable();
                Items itm = new Items();
                int duId = Convert.ToInt32(cboIssuedTo.SelectedValue);
                dtItem = itm.GetItemsByDU(duId);
                PopulateItemListByDU(dtItem);
            }
        }


        public void PopulateItemListByDU(DataTable dtItem)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtItem.Rows.Count;

            GeneralInfo pipline = new GeneralInfo();
            pipline.LoadAll();
            int min = pipline.Min;
            int max = pipline.Max;
            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            int duId = Convert.ToInt32(cboIssuedTo.SelectedValue);
            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            Balance bal = new Balance();
            IssueDoc itmIssues = new IssueDoc();
            foreach (DataRow dr in dtItem.Rows)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
               
                int year = Convert.ToInt32(cboYear.SelectedItem);
                Int64 SOH = bal.GetDUSOH(Convert.ToInt32(dr["ID"]), duId, dtCurrent.Month, year);

                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? year - 1 : year;
                    cons[i] = itmIssues.GetDUConsumptionByMonth(itemId,duId,mon[i], yr);
                }
                string[] str = { count.ToString(), itemName, ((SOH != 0) ? SOH.ToString("#,###") : "0"), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem listItem = new ListViewItem(str);
                listItem.ToolTipText = itemName;
                listItem.Tag = dr["ID"];
                if (col != 0)
                {
                    listItem.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                lstItem.Items.Add(listItem);
                count++;
                progressBar1.PerformStep();
            }
            progressBar1.Visible = false;
        }
        
    }
}