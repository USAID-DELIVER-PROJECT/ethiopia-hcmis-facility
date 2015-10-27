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
    public partial class IssuesByDep : Form
    {
        public IssuesByDep()
        {
            InitializeComponent();
        }
        int catID = 0;
        int[] recId = null;

        private void ManageItems_Load(object sender, EventArgs e)
        {
            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;

            PopulateCatTree();
            ReceivingUnits recUnits = new ReceivingUnits();
            recUnits.GetActiveDispensaries();
            recId = new int[recUnits.RowCount];
            int i = 0;
            if (lstItem.Columns.Count <= 2)
            {
                foreach (DataRowView dv in recUnits.DefaultView)
                {
                    lstItem.Columns.Add(dv["Name"].ToString());
                    recId[i] = Convert.ToInt32(dv["ID"]);
                    i++;
                }
            }

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
            
            
            
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

            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = new DateTime();
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            IssueDoc issues = new IssueDoc();
            foreach (DataRow dr in dtItem.Rows)
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                Int64[] obj = new Int64[recId.Length];
                int itemId = Convert.ToInt32(dr["ID"]);
                string[] str = new string[recId.Length + 2];
                str[0] = count.ToString();
                str[1] = itemName;
                for (int j = 0; j < recId.Length; j++)
                {
                   obj[j] =  issues.GetIssuedQuantityByReceivingUnit(itemId,storeId,recId[j],dtCurrent.Year);
                    str[j + 2] = (obj[j] != 0)?obj[j].ToString("#,###"): "0";
                }
                
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

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            Items itm = new Items();
            DataTable dtItm  = new DataTable();
            if (dtFrom.Value < dtTo.Value)
            {

                int storeId = Convert.ToInt32(cboStores.SelectedValue);
             
                dtItm = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1));
                
                PopulateItemListByDateRange(dtItm);
            }
            
        }

        public void PopulateItemListByDateRange(DataTable dtItem)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtItem.Rows.Count;

            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;

            dtFrom.CustomFormat = "MM/dd/yyyy";
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dteFrm = new DateTime(); 
            DateTime dteTo = new DateTime(); 

            if (Convert.ToInt32(dtFrom.Text.Substring(0, 2)) != 13)
            {
                dteFrm = Convert.ToDateTime(dtFrom.Text);
            }
            else
            {
                string dtValid = dtFrom.Text;
                string year = dtValid.Substring(dtValid.Length - 4, 4);
                dteFrm = Convert.ToDateTime("12/30/" + year);
            }

            if (Convert.ToInt32(dtTo.Text.Substring(0, 2)) != 13)
            {
                dteTo = Convert.ToDateTime(dtTo.Text);
            }
            else
            {
                string dtValid = dtTo.Text;
                string year = dtValid.Substring(dtValid.Length - 4, 4);
                dteTo = Convert.ToDateTime("12/30/" + year);
            }

            IssueDoc issues = new IssueDoc();
            foreach (DataRow dr in dtItem.Rows)
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                Int64[] obj = new Int64[recId.Length];
                int itemId = Convert.ToInt32(dr["ID"]);
                string[] str = new string[recId.Length + 2];
                str[0] = count.ToString();
                str[1] = itemName;
                for (int j = 0; j < recId.Length; j++)
                {
                    obj[j] = issues.GetIssuedQuantityByReceivingUnitDate(itemId, storeId, recId[j],dteFrm.ToShortDateString(),dteTo.ToShortDateString());
                    str[j + 2] = obj[j].ToString();
                }

                ListViewItem listItem = new ListViewItem(str);
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

        private void cboStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                int storeId = Convert.ToInt32(cboStores.SelectedValue);
                DataTable dtItem = new DataTable();
               
                    dtItem = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1,Convert.ToInt32(lkCommodityTypes.EditValue))));
               
                PopulateItemList(dtItem);
                lblState.Text = "All Items";
            }
        }

        private void lstItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItem.SelectedItems[0].Tag != null)
            {
                dtDate.Value = DateTime.Now;
                dtDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = new DateTime();// Convert.ToDateTime(dtDate.Text);
                dtCur = ConvertDate.DateConverter(dtDate.Text);
                
                int month = dtCur.Month;
                int year = (month < 11) ? dtCur.Year : dtCur.Year + 1;

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

            string header = info.HospitalName + " Issues By Receiving Units " + cboStores.Text + " Date: " + dtDate.Text;
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

            string[] header = { info.HospitalName , " Issues By Receiving Units " , cboStores.Text , " Date: " + dtDate.Text };
            MainWindow.ExportToExcel(lstItem,header);
        }

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            ckExcNeverIssued.Enabled = ckExclude.Checked;
            if (cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                int storeId = Convert.ToInt32(cboStores.SelectedValue);
                DataTable dtItem = new DataTable();
               
                dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1, Convert.ToInt32(lkCommodityTypes.EditValue)));
                                
                PopulateItemList(dtItem);
                lblState.Text = "All Items";
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

        private void rdDrug_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                int storeId = Convert.ToInt32(cboStores.SelectedValue);
                DataTable dtItem = new DataTable();

                dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1));
            
                PopulateItemList(dtItem);
                lblState.Text = "All Items";
                PopulateCatTree();
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
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
                    dtItm = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1)));
                   
                }
                PopulateItemList(dtItm);

            }
        }

        private void ckExcNeverIssued_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 0;
                DataTable dtItm = new DataTable();

                dtItm = ((ckExclude.Checked && ckExcNeverIssued.Checked) ? itm.GetReceivedNotIssuedItems(storeId,Convert.ToInt32(lkCommodityTypes.EditValue)) : ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(storeId, Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1)));
                
                PopulateItemList(dtItm);
            }
        }
        
        
    }
}