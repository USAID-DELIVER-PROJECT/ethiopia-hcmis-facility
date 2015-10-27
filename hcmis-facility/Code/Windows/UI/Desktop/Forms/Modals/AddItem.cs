using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;


namespace PharmInventory.Forms.Modals
{
    /// <summary>
    /// Interaction logic for AddItemForm
    /// </summary>
    public partial class AddItem : XtraForm
    {
        public AddItem()
        {
            InitializeComponent();
        }

        readonly int _itemId = 0;
        readonly int _categoryId = 0;

        /// <summary>
        /// Initialize the form with and id
        /// </summary>
        /// <param name="id">A unique ID</param>
        /// <param name="itemId">True if the id is an itemID, false if the id is a categoryID</param>
        public AddItem(int id, bool itemId)
        {
            InitializeComponent();
            if (itemId)
                _itemId = id;
            else
                _categoryId = id;
        }

        private void PopulateFields()
        {
            try
            {
                if (_itemId == 0) return;

                Items itm = new Items();

                itm.LoadByPrimaryKey(_itemId);
                SubCategory cat = new SubCategory();
                DataTable dtCat = cat.GetSubCategoryOfItem(_itemId);
                foreach (DataRow drcat in dtCat.Rows)
                {
                    DataTable dtProd = cat.GetSubCategoryByID(Convert.ToInt32(drcat["SubCategoryID"]));
                    //txtCategory.Text = dtProd.Rows[0]["CategoryName"].ToString();
                    //txtSubCategory.Text = dtProd.Rows[0]["SubCategoryName"].ToString();
                    string[] categor = { dtProd.Rows[0]["CategoryName"].ToString(), dtProd.Rows[0]["SubCategoryName"].ToString() };
                    ListViewItem listCat = new ListViewItem(categor) { Tag = dtProd.Rows[0]["ID"] };
                    lstCat.Items.Add(listCat);
                }
                cboIIN.SelectedValue = itm.IINID.ToString();
                Product nInn = new Product();
                nInn.LoadByPrimaryKey(itm.IINID);
                //txtATC.Text = nInn.ATC;
                txtStrength.Text = itm.Strength;
                ckIsDiscontinued.Checked = itm.IsDiscontinued;
                ckIsEDL.Checked = itm.EDL;
                ckIsFree.Checked = itm.IsFree;
                ckIsPedatric.Checked = itm.Pediatric;
                ckIsRefrigerated.Checked = itm.Refrigeratored;
                cboDosageForm.SelectedValue = itm.DosageFormID.ToString();
                cboUnit.SelectedValue = itm.UnitID.ToString();
                string code = itm.StockCode;
                txtStockCode.Text = code;
                txtStock2.Text = itm.Code;
                txtStock3.Text = itm.StockCodeDACA;
            }
            catch
            {

            }
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            DosageForm doFrm = new DosageForm();
            doFrm.GetDosageForItem();
            
            doFrm.Sort = "Form";
            cboDosageForm.DataSource = doFrm.DefaultView;

            Unit un = new Unit();
            un.LoadAll();
            un.Sort = "Unit";
            cboUnit.DataSource = un.DefaultView;


            Product pInn = new Product();
            pInn.GetInnForItem();
            
            pInn.Sort = "IIN";
            cboIIN.DataSource = pInn.DefaultView;

            if (_categoryId != 0)
            {
                SubCategory cat = new SubCategory();
                DataTable dtProd = cat.GetSubCategoryByID(_categoryId);
                string[] categor = { dtProd.Rows[0]["CategoryName"].ToString(), dtProd.Rows[0]["SubCategoryName"].ToString() };
                ListViewItem listCat = new ListViewItem(categor) {Tag = dtProd.Rows[0]["ID"]};
                lstCat.Items.Add(listCat);
                //txtCatCode.Text = dtProd.Rows[0]["CategoryCode"].ToString() + "-" + dtProd.Rows[0]["SubCategoryCode"].ToString();
            }
            else
            {
                PopulateFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Items itm = new Items();
            if (_itemId != 0)
                itm.LoadByPrimaryKey(_itemId);
            else
            {
                itm.AddNew();
                itm.IsInHospitalList = true;
             
                Items itms = new Items();
                itm.ID = itms.GetNextItemID();
                itm.StorageTypeID = 1;
                itm.NearExpiryTrigger = 0;
            }
            itm.IINID = Convert.ToInt32(cboIIN.SelectedValue);

            //itm.StockCode = txtCatCode.Text + "-" + txtStockCode.Text;
            itm.StockCode = txtStockCode.Text;
            itm.Code = txtStock2.Text;
            itm.StockCodeDACA = txtStock3.Text;
            itm.Strength = txtStrength.Text;
            itm.DosageFormID = Convert.ToInt32(cboDosageForm.SelectedValue);
            itm.IsDiscontinued = ckIsDiscontinued.Checked;
            itm.IsFree = ckIsFree.Checked;
            itm.EDL = ckIsEDL.Checked;
            itm.UnitID = Convert.ToInt32(cboUnit.SelectedValue);
            itm.Pediatric = ckIsPedatric.Checked;
            itm.Refrigeratored = ckIsRefrigerated.Checked;
            itm.NeedExpiryBatch = true;
            itm.Save();

            ProductsCategory prodCate = new ProductsCategory();
            foreach (ListViewItem lstC in lstCat.Items)
            {
                int catId = Convert.ToInt32(lstC.Tag);

                if (prodCate.CategoryExists(itm.ID, catId)) continue;

                prodCate.AddNew();
                prodCate.ItemId = itm.ID;
                prodCate.SubCategoryID = catId;
                prodCate.Save();
            }

            if (itm.IsColumnNull("StockCode"))
            {
                // Update the Stock Code

                prodCate.Rewind();
                SubCategory sc = new SubCategory();
                sc.LoadByPrimaryKey(prodCate.SubCategoryID);

                if(sc.RowCount > 0)
                {
                    itm.StockCode = string.Format("{0}.{1}.{2}.{3}",sc.SubCategoryCode, 1, itm.DosageFormID, 1);
                    itm.Save();
                }
            }
            XtraMessageBox.Show( "Item is Saved Successfully!" , "Confirmation" , MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            
        }

        private void cboIIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboIIN.SelectedValue != null)
            {
                INN getinn = new INN();
                getinn.LoadByPrimaryKey(Convert.ToInt32(cboIIN.SelectedValue));
               // txtATC.Text = getinn.ATC;
            }
        }
        
        private void btnAddCat_Click(object sender, EventArgs e)
        {
            PopulateCategory();
            ProductTree.Visible = true;
        }

        private void PopulateCategory()
        {
            ProductTree.Nodes.Clear();
            Category cat = new Category();
            SubCategory subCat = new SubCategory();
            cat.LoadAll();
            cat.Sort = "CategoryName";
            ProductTree.Nodes.Add("All0", "All");
            foreach (DataRowView dv in cat.DefaultView)
            {
                TreeNode nodes = new TreeNode
                                     {
                                         Name = "cat" + dv["ID"].ToString(),
                                         Text =
                                             dv["CategoryName"].ToString() + " (" + dv["CategoryCode"].ToString() + ")",
                                         ToolTipText = "Double click to add"
                                     };
                subCat.GetSubCategory(Convert.ToInt32(dv["ID"]));
                subCat.Sort = "SubCategoryName";
                foreach (DataRowView subDv in subCat.DefaultView)
                {
                    if (!ExistInList(Convert.ToInt32(subDv["ID"])))
                    {
                        TreeNode subNodes = new TreeNode
                                                {
                                                    Name = "sub" + subDv["ID"].ToString(),
                                                    Text =
                                                        subDv["SubCategoryName"].ToString() + " (" +
                                                        subDv["SubCategoryCode"].ToString() + ")",
                                                    ToolTipText = "Double click to add"
                                                };

                        nodes.Nodes.Add(subNodes);
                    }
                }
                ProductTree.Nodes[0].Nodes.Add(nodes);
            }
            ProductTree.Nodes[0].Expand();
        }

        private bool ExistInList(int subCateId)
        {
            foreach (ListViewItem lst in lstCat.Items)
            {
                if (Convert.ToInt32(lst.Tag) == subCateId)
                    return true;
            }
            return false;
        }

        private void ProductTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Items itm = new Items();
                DataTable dtItem = new DataTable();
                string value = ProductTree.SelectedNode.Name;
                string type = value.Substring(0, 3);
                int len = value.Length - 3;
                int categoryId = Convert.ToInt32(value.Substring(3, len));

                if (type == "sub")
                {
                    SubCategory cat = new SubCategory();
                    DataTable dtProd = cat.GetSubCategoryByID(categoryId);
                    string[] categor = { dtProd.Rows[0]["CategoryName"].ToString(), dtProd.Rows[0]["SubCategoryName"].ToString() };
                    ListViewItem listCat = new ListViewItem(categor);
                    listCat.Tag = dtProd.Rows[0]["ID"];
                    lstCat.Items.Add(listCat);
                    ProductTree.Visible = false;
                }
            }
            catch
            { }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ProductTree.Visible = false;
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {
            ProductTree.Visible = false;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (lstCat.SelectedItems.Count > 0)
            {
                if (lstCat.SelectedItems[0] != null)
                {
                    ProductsCategory prodCate = new ProductsCategory();
                    int id = Convert.ToInt32(lstCat.SelectedItems[0].Tag);

                    if (prodCate.CategoryExists(_itemId, id))
                    {
                        prodCate.GetProductCategory(_itemId, id);
                        prodCate.MarkAsDeleted();
                        prodCate.Save();
                       
                    }
                    lstCat.Items.Remove(lstCat.SelectedItems[0]);
                }
            }
        }
    }
}