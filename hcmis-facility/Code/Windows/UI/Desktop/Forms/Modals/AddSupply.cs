using System;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    /// <summary>
    /// Interaction logic for AddSupply Form
    /// </summary>
    public partial class AddSupply : XtraForm
    {
        public AddSupply()
        {
            InitializeComponent();
        }

        readonly int _itemId = 0;
        readonly int _categoryId = 0;

        /// <summary>
        /// Initialize the form with an id.
        /// </summary>
        /// <param name="id">ItemID or CategoryID</param>
        /// <param name="itemId">True if the id supplied is an item id and false if it is a category id</param>
        public AddSupply(int id, bool itemId)
        {
            InitializeComponent();
            if (itemId)
                _itemId = id;
            else
                _categoryId = id;
        }

        private void PopulateFields()
        {
            if (_itemId == 0) return;

            Items itm = new Items();

            itm.LoadByPrimaryKey(_itemId);
            cboIIN.EditValue = itm.IINID;
            INN nInn = new INN();
            nInn.LoadByPrimaryKey(itm.IINID);
            txtStrength.Text = itm.Strength;
            cboDosageForm.EditValue = itm.DosageFormID;
            cboUnit.EditValue = itm.UnitID;
            string code = itm.StockCode;
            txtStockCode.Text = code;
            ckNeedExp.Checked = itm.NeedExpiryBatch;

            if (itm.HasTransactions(_itemId))
                ckNeedExp.Enabled = false;
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            DosageForm doFrm = new DosageForm();
            doFrm.GetDosageForSupply();
            
            doFrm.Sort = "Form";
            cboDosageForm.Properties.DataSource = doFrm.DefaultView;

            Unit un = new Unit();
            un.LoadAll();
            un.Sort = "Unit";
            cboUnit.Properties.DataSource = un.DefaultView;


            Product pInn = new Product();
            pInn.GetInnForSupply();
            
            pInn.Sort = "IIN";
            cboIIN.Properties.DataSource = pInn.DefaultView;

            //if (categoryId != 0)
            //{
            //    SubCategory cat = new SubCategory();
            //    DataTable dtProd = cat.GetSubCategoryByID(categoryId);
            //    string[] categor = { dtProd.Rows[0]["CategoryName"].ToString(), dtProd.Rows[0]["SubCategoryName"].ToString() };
            //    ListViewItem listCat = new ListViewItem(categor);
            //    listCat.Tag = dtProd.Rows[0]["ID"];
            //    lstCat.Items.Add(listCat);
            //    //txtCatCode.Text = dtProd.Rows[0]["CategoryCode"].ToString() + "-" + dtProd.Rows[0]["SubCategoryCode"].ToString();
            //}
            if(_categoryId == 0)
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
            }
            itm.IINID = Convert.ToInt32(cboIIN.EditValue);
            //itm.StockCode = txtCatCode.Text + "-" + txtStockCode.Text;
            itm.StockCode = txtStockCode.Text;
            itm.Strength = txtStrength.Text;
            itm.DosageFormID = Convert.ToInt32(cboDosageForm.EditValue);
            //itm.IsDiscontinued = false;
            //itm.IsFree = ckIsFree.Checked;
            //itm.EDL = ckIsEDL.Checked;
            itm.UnitID = Convert.ToInt32(cboUnit.EditValue);
            itm.NeedExpiryBatch = ckNeedExp.Checked ;
            //itm.Pediatric = ckIsPedatric.Checked;
            //itm.Refrigeratored = ckIsRefrigerated.Checked;
            
            itm.Save();

            ItemSupplyCategory prodCate = new ItemSupplyCategory();
            
                //int catId = Convert.ToInt32(lstC.Tag);
            if (_categoryId != 0)
            {
                if (!prodCate.CategoryExists(itm.ID, _categoryId))
                {

                    prodCate.AddNew();
                    prodCate.ItemID = itm.ID;
                    prodCate.CategoryID = _categoryId;
                    prodCate.Save();
                }
            }
            
            XtraMessageBox.Show("Supply is Saved Successfully!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
            
        }

       
    }
}