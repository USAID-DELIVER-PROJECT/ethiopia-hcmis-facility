using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.Forms.Modals;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction Logic for ManageItems Form
    /// </summary>
    public partial class ManageSupplies : XtraForm
    {
        public ManageSupplies()
        {
            InitializeComponent();
        }

        int _catId = 0;
        int _selectedCat = 0;
        int _selectedSubCat = 0;

        /// <summary>
        /// Loads the form data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItemsLoad(object sender, EventArgs e)
        {
            PopulateCatTree();
            Items itm = new Items();
            DataTable dtItem = itm.GetAllSupply();
            
            PopulateItemList(dtItem);
            //lblState.Text = "All Items";
        }

        /// <summary>
        /// Populates the CatTree
        /// </summary>
        private void PopulateCatTree()
        {
            SupplyCategory suppCategory = new SupplyCategory();
            treeCategory.DataSource = suppCategory.GetAllSupplyCategories();
        }

        /// <summary>
        /// Populates the item list based on the supplied data table.
        /// </summary>
        /// <param name="dtItem">The datatable to fill the list with</param>
        private void PopulateItemList(DataTable dtItem)
        {
            int count = 0;
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("No");
            dtbl.Columns.Add("ID");
            dtbl.Columns.Add("ItemName");
            dtbl.Columns.Add("StockCode");
            dtbl.Columns.Add("Unit");
            dtbl.Columns.Add("DosageForm");

            foreach (DataRow dr in dtItem.Rows)
            {
                DataRowView drv = dtbl.DefaultView.AddNew();
                drv["ID"] = dr["ID"];
                drv["ItemName"] = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                drv["No"] = count++;
                drv["StockCode"] = dr["StockCode"];
                drv["Unit"] = dr["Unit"];
                drv["DosageForm"] = dr["DosageForm"];
            }

            gridControl1.DataSource = dtbl;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_catId == 0) return;
            AddSupply addItm = new AddSupply(_catId, false);
            MainWindow.ShowForms(addItm);
        }
        
        /// <summary>
        /// Edit the items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EditItems();
        }

        /// <summary>
        /// Open the AddItem Form with a supplied ID
        /// </summary>
        private void EditItems()
        {

            DataRow drv = gridView1.GetFocusedDataRow();
            if (drv == null) return;

            int itemId = Convert.ToInt32(drv["ID"]);
            AddSupply addItm = new AddSupply(itemId, true);
            MainWindow.ShowForms(addItm);

            DataTable dtItem;
            Items itm = new Items();

            //if (txtItemName.Text != "")
            //{
            //    string keyword = txtItemName.Text;
            //    dtItem = itm.GetItemByKeyword(keyword);
            //}
            //else if (selectedCat != 0)
            //{
            //    dtItem = itm.GetItemsByCategory(selectedCat);
            //    toolStripButtonAddItems.Enabled = false;
            //    toolStripButtonEditItem.Enabled = false;
            //}
            //else if (selectedSubCat != 0)
            //{
            //    dtItem = itm.GetItemsBySubCategory(selectedSubCat);
            //    toolStripButtonAddItems.Enabled = true;
            //    toolStripButtonEditItem.Enabled = false;
            //}
            //else
            {
                dtItem = itm.GetAllItems(1);
            }
            PopulateItemList(dtItem);
        }
        
        /// <summary>
        /// Handles the text changed event of the txtItemName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            DataTable dtItem;
            Items itm = new Items();

            if (txtItemName.Text != "")
            {
                string keyword = txtItemName.Text;
                dtItem = itm.GetItemByKeyword(keyword);
            }
            else
            {
                dtItem = itm.GetAllItems(1);
            }
            PopulateItemList(dtItem);
        }

        /// <summary>
        /// Handles printing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();

            string header = info.HospitalName + " National Drug List";
            gridControl1.ShowPrintPreview();
        }

        /// <summary>
        /// Handles Delete of an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnDelete_Click(object sender, EventArgs e)
        {
            DataRow drv = gridView1.GetFocusedDataRow();
            if (drv != null)
            {
                Items itm = new Items();
                ProductsCategory proCat = new ProductsCategory();
                int itemId = Convert.ToInt32(drv["ID"]);
                if (!itm.HasTransactions(itemId))
                {
                    if (XtraMessageBox.Show("Are You Sure, You want to delete this Transaction? You will not be able to restore this data.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        proCat.GetCategoryByItem(itemId);
                        foreach (DataRowView drcat in proCat.DefaultView)
                        {
                            ProductsCategory cat = new ProductsCategory();
                            cat.LoadByPrimaryKey(Convert.ToInt32(drcat["ID"]));
                            cat.MarkAsDeleted();
                            cat.Save();
                        }
                        itm.LoadByPrimaryKey(itemId);
                        itm.MarkAsDeleted();
                        itm.Save();
                        XtraMessageBox.Show("Item Deleted!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Unable to Delete, This Item has been Received or Issued.", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        /// <summary>
        /// Handles editing of items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnEdit_Click(object sender, EventArgs e)
        {
            EditItems();
        }
        
        /// <summary>
        /// Handles whether the focussed row should be editable or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow drv = gridView1.GetFocusedDataRow();
            toolStripButtonEditItem.Enabled = drv != null;
        }

        /// <summary>
        /// Populates Item list based on the selected category in the treeCategory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)treeCategory.GetDataRecordByNode(treeCategory.Selection[0]);
            Items itm = new Items();
            DataTable dtItem;
            //TODO: filter criteria;
            string value = dr["ID"].ToString();
            string type = value.Substring(0,1);
            _catId = 0;
            int categoryId = Convert.ToInt32(value.Substring(1));

            dtItem = itm.GetSupplyByCategory(categoryId);
            toolStripButtonAddItems.Enabled = true;
            _catId = categoryId;
            toolStripButtonEditItem.Enabled = false;
            _selectedSubCat = categoryId;
            PopulateItemList(dtItem);
        }
    }
}