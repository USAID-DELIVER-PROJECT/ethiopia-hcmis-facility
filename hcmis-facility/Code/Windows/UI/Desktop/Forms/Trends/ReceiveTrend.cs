using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using StockoutIndexBuilder;

namespace PharmInventory
{
    public partial class ReceiveTrend : Form
    {
        public ReceiveTrend()
        {
            InitializeComponent();
        }
        int catID = 0;

        private void ManageItems_Load(object sender, EventArgs e)
        {
            
            Category cat = new Category();
            SubCategory subCat = new SubCategory();
            Product prod = new Product();
            cat.LoadAll();
            cat.Sort = "CategoryName";
            lblCategory.Text = "Products By Category";
            ProductTree.Nodes.Add("All0","All");
            foreach (DataRowView dv in cat.DefaultView)
            {
                TreeNode nodes = new TreeNode();
                nodes.Name =  "cat" + dv["ID"].ToString();
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

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
            
            
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
            int storeId = (cboStores.SelectedValue != null)?Convert.ToInt32(cboStores.SelectedValue): 1;
            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            Balance bal = new Balance();
            Items itmIssues = new Items();

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            int year = dtCurrent.Year;

            foreach (DataRow dr in dtItem.Rows)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                DataTable dtBal = bal.GetLastBalance(Convert.ToInt32(dr["ID"]),storeId);
                double AMC = Builder.CalculateAverageConsumption(itemId, storeId, dtCurrent.Subtract(TimeSpan.FromDays(180)), dtCurrent, CalculationOptions.Monthly);//(dtBal.Rows.Count <= 0) ? 0 : ((dtBal.Rows[0]["AMC"].ToString() != "")?Convert.ToInt64(dtBal.Rows[0]["AMC"]): 0);
                double MinCon =  AMC * min;
                double maxCon = AMC * max;
                Int64 SOH = (dtBal.Rows.Count > 0) ? Convert.ToInt64(dtBal.Rows[0]["SOH"]) : 0;
                decimal MOS = (AMC != 0)? (Convert.ToDecimal(SOH )/ Convert.ToDecimal(AMC)) : 0;
                MOS = Decimal.Round(MOS, 1);
                int[] mon = {11, 12, 1, 2, 3, 4, 5, 6 ,7, 8,9, 10 };
                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (i < 11)?year:year-1;
                    cons[i] = itmIssues.GetQuantityReceiveByItemPerMonth(mon[i], itemId,storeId,yr);
                }
                string[] str = { count.ToString(), itemName, ((SOH != 0) ? SOH.ToString("#,###") : "0"), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                

                //string[] str = { count.ToString(), itemName, ((SOH != 0)?SOH.ToString("#,###") :"0"), itmIssues.GetQuantityReceiveByItemPerMonth(9, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(10, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(11, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(12, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(1, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(2, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(3, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(4, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(5, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(6, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(7, itemId).ToString(), itmIssues.GetQuantityReceiveByItemPerMonth(8, itemId).ToString() };
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
            else
            {
                dtItem = itm.GetAllItems(1);
                lblState.Text = "All Items";
            }
            PopulateItemList(dtItem);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                DataTable dtItem = itm.GetAllItems(1);
                PopulateItemList(dtItem);
                lblState.Text = "All Items";
            }
        }

        
    }
}