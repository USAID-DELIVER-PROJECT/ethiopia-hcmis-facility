using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction logic for SystemSetting Form
    /// </summary>
    public partial class SystemSetting : XtraForm
    {

        public SystemSetting()
        {
            InitializeComponent();
        }

        int _catId = 0;
        int _unitId = 0;
        int _dosageFormId = 0;
        int _disposalReasonId = 0;
        string _locationType = "";
        int _locId = 0;
        int _innId = 0;
        int _supCatId = 0;

        /// <summary>
        /// Populates lookups and tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemSetting_Load(object sender, EventArgs e)
        {
            PopulatePrograms();
            // TAb IIN 
            BLL.INN innInfo = new INN();
            innInfo.LoadAll();
            innInfo.Sort = "IIN";
            PopulateINN(innInfo);

            // TAb Category

            BLL.Type type = new BLL.Type();
            type.LoadAll();
            lkCategory.DataSource = type.DefaultView;

            PopulateCategoryTree();
            //unit section
            BLL.Unit uni = new Unit();
            uni.LoadAll();
            lstUnits.DataSource = uni.DefaultView;

            // dosage form section
            DosageForm doForm = new DosageForm();
            doForm.LoadAll();
            doForm.Sort = "Form";
            PopulateDosageForm(doForm);
            //receiving status section
            // PopulateManufacturer();
            //disposal reasons 
            DisposalReasons reason = new DisposalReasons();
            reason.LoadAll();
            reason.Sort = "Reason";
            PopulateDisposalReason(reason);
            //location regions zones and woredas
            PopulateLocationTree();
            PopulateSupplyCatTree();

            PopulateBalance();
        }

        #region

        /// <summary>
        /// Populates the balance
        /// </summary>
        private void PopulateBalance()
        {
            Stores str = new Stores();
            str.LoadAll();
            cboStore.DataSource = str.DefaultView;

            dtDate.Value = DateTime.Now;

            DateTime dtCurent = new DateTime();// 
            dtDate.CustomFormat = "MM/dd/yyyy";
            try
            {
                dtCurent = Convert.ToDateTime(dtDate.Text);
            }
            catch
            {
                string dtValid = "";
                string year = "";
                if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                {
                    dtValid = dtDate.Text;
                    year = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurent = Convert.ToDateTime("12/30/" + year);
                }
                else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                {
                    dtValid = dtDate.Text;
                    year = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurent = Convert.ToDateTime("2/28/" + year);
                }
            }
            for (int i = (dtCurent.Year); i > (dtCurent.Year - 11); i--)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = dtCurent.Year;
        }

        /// <summary>
        /// Handles the processing of balance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcessBalance_Click(object sender, EventArgs e)
        {
            Items itm = new Items();
            YearEnd yEnd = new YearEnd();
            Balance bal = new Balance();

            DataTable dtItm = itm.GetAllItems(1);
            dtDate.Value = DateTime.Now;
            DateTime dtCurent = Convert.ToDateTime(dtDate.Text);

            foreach (DataRow dr in dtItm.Rows)
            {
                yEnd.AddNew();
                yEnd.StoreID = Convert.ToInt32(cboStore.SelectedValue);
                yEnd.ItemID = Convert.ToInt32(dr["ID"]);
                yEnd.Year = Convert.ToInt32(cboYear.SelectedItem);
                yEnd.Month = (Convert.ToInt32(cboYear.SelectedItem) == dtCurent.Year) ? dtCurent.Month : 10;
                yEnd.BBalance = 0;
                yEnd.EBalance = 0;
                yEnd.PhysicalInventory = 0;
                yEnd.Save();
            }
        }

        #endregion

        #region supply category

        /// <summary>
        /// Populates the supply category tree
        /// </summary>
        private void PopulateSupplyCatTree()
        {
            SupplyCategory subCat = new SupplyCategory();
            treeSupCategory.DataSource = subCat.GetAllSupplyCategories();
        }

        /// <summary>
        /// handles the btnSupCat Click event
        /// Updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupCat_Click(object sender, EventArgs e)
        {
            cboSupCat.Visible = false;

            lblSupCat.Text = "Main Category";
            _supCatId = 0;
            txtSupCode.Text = "";
            txtSupCat.Text = "";
        }

        /// <summary>
        /// Handles the btnSupSubCat Click Event
        /// Updates the form accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupSubCat_Click(object sender, EventArgs e)
        {
            cboSupCat.Visible = true;

            lblSupCat.Text = "SubCategory";
            _supCatId = 0;
            txtSupCode.Text = "";
            txtSupCat.Text = "";
        }

        /// <summary>
        /// Handles the saving of supply category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSupCat_Click(object sender, EventArgs e)
        {
            if (txtSupCat.Text != "")
            {
                SupplyCategory supCat = new SupplyCategory();
                if (_supCatId == 0)
                    supCat.AddNew();
                else
                    supCat.LoadByPrimaryKey(_supCatId);
                supCat.Name = txtSupCat.Text;
                supCat.Code = txtSupCode.Text;
                supCat.ParentId = ((cboSupCat.Visible) ? Convert.ToInt32(cboSupCat.SelectedValue) : 0);
                supCat.Save();
                PopulateSupplyCatTree();
            }
        }

        /// <summary>
        /// Clears the Supply related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSupCat.Visible = false;
            lblSupCat.Text = "Main Category";
            _supCatId = 0;
            txtSupCode.Text = "";
            txtSupCat.Text = "";
        }
        
        #endregion
        
        #region Program

        int _programId = 0;

        /// <summary>
        /// Populates the programs and loads them into the TreeProgram
        /// </summary>
        private void PopulatePrograms()
        {

            BLL.Programs prog = new Programs();
            prog.LoadAll();
            cboProgram.DataSource = prog.DefaultView;

            TreeProgram.DataSource = prog.DefaultView;
        }

        /// <summary>
        /// Resets the program and sets the visibility of cboProgram into False
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            ResetProgram();
            cboProgram.Visible = false;
            //lbPro.Visible = false;
            //lblProgram.Text = "Program";
        }

        /// <summary>
        /// Clears program related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearProgram_Click(object sender, EventArgs e)
        {
            ResetProgram();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProgramSave_Click(object sender, EventArgs e)
        {
            if (txtProgram.Text != "")
            {
                Programs prog = new Programs();
                if (_programId != 0)
                    prog.LoadByPrimaryKey(_programId);
                else
                    prog.AddNew();
                prog.Name = txtProgram.Text;
                prog.Description = txtProgramDescription.Text;
                prog.ParentID = cboProgram.Visible ? Convert.ToInt32(cboProgram.SelectedValue) : 0;
                prog.Save();
                PopulatePrograms();
                ResetProgram();
            }
            else
            {
                txtProgram.BackColor = Color.FromArgb(251, 214, 214);
            }
        }

        /// <summary>
        /// Resets program related information from the form 
        /// </summary>
        private void ResetProgram()
        {
            _programId = 0;
            txtProgram.Text = "";
            txtProgramDescription.Text = "";
            cboProgram.Visible = true;
            //lbPro.Visible = true;
            //lblProgram.Text = "SubProgram";
            btnProgramSave.Text = "Save";
            txtProgram.BackColor = Color.White;
        }

        /// <summary>
        /// Resets program related information from the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubProgram_Click(object sender, EventArgs e)
        {
            ResetProgram();
        }

        #endregion

        #region category

        /// <summary>
        /// Loads the category tree
        /// </summary>
        private void PopulateCategoryTree()
        {
            Category cat = new Category();
            DataTable dtbl = cat.GetCategoryTree();
            treeCategory.DataSource = dtbl;
        }

        /// <summary>
        /// Saves Category/Sub Category related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text != "" || txtCatCode.Text != "")
            {
                if (cboCategory.Visible)
                {
                    SubCategory subCat = new SubCategory();
                    if (_catId != 0)
                        subCat.LoadByPrimaryKey(_catId);
                    else
                        subCat.AddNew();

                    subCat.CategoryId = Convert.ToInt32(cboCategory.SelectedValue);
                    subCat.SubCategoryName = txtCategory.Text;
                    subCat.Description = txtDescription.Text;
                    subCat.SubCategoryCode = txtCatCode.Text;
                    subCat.Save();
                }
                else
                {
                    Category cat = new Category();
                    if (_catId != 0)
                        cat.LoadByPrimaryKey(_catId);
                    else
                        cat.AddNew();
                    cat.CategoryName = txtCategory.Text;
                    cat.Description = txtDescription.Text;
                    cat.CategoryCode = txtCatCode.Text;
                    cat.Save();
                }

                PopulateCategoryTree();
                ResetCategoryForm();
            }
            else
            {
                if (txtCatCode.Text == "")
                    txtCatCode.BackColor = Color.FromArgb(251, 214, 214);
                if (txtCategory.Text == "")
                    txtCategory.BackColor = Color.FromArgb(251, 214, 214);
            }
        }

        /// <summary>
        /// Handles category adding logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            cboCategory.Visible = false;

            //lblCateName.Text = "Category Name";
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtCatCode.Text = "";
            _catId = 0;
            btnSave.Text = "Save";
        }

        /// <summary>
        /// Resets Category related info from the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetCategory_Click(object sender, EventArgs e)
        {
            ResetCategoryForm();
        }

        /// <summary>
        /// Resets the category related info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetCategoryForm();
        }

        /// <summary>
        /// Resets category related information from the form fields
        /// </summary>
        private void ResetCategoryForm()
        {
            cboCategory.Visible = true;

            //lblCateName.Text = "SubCategory Name";
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtCatCode.Text = "";
            _catId = 0;
            btnSave.Text = "Save";
            txtCategory.BackColor = Color.White;
            txtCatCode.BackColor = Color.White;
        }

        /// <summary>
        /// Handles formatting when the category text is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            txtCategory.BackColor = Color.White;
        }
        
        /// <summary>
        /// Handles formatting when the category code text is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCatCode_TextChanged(object sender, EventArgs e)
        {
            txtCatCode.BackColor = Color.White;
        }

        #endregion

        
        #region Disposal Region

        /// <summary>
        /// Loads the reason grid
        /// </summary>
        /// <param name="reason"></param>
        private void PopulateDisposalReason(DisposalReasons reason)
        {
            gridReasons.DataSource = reason.DefaultView;
        }

        /// <summary>
        /// Saves disposal info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisposalSave_Click(object sender, EventArgs e)
        {
            if (txtReasons.Text != "")
            {
                DisposalReasons reason = new DisposalReasons();
                if (_disposalReasonId != 0)
                    reason.LoadByPrimaryKey(_disposalReasonId);
                else
                    reason.AddNew();
                reason.Reason = txtReasons.Text.Trim();
                reason.Description = txtDisposalDescription.Text;
                reason.Save();
                reason.LoadAll();
                PopulateDisposalReason(reason);
                ResetDisposalForm();
            }
            else
            {
                txtReasons.BackColor = Color.FromArgb(251, 214, 214);
            }
        }

        /// <summary>
        /// Handles the adding of new reason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewReason_Click(object sender, EventArgs e)
        {
            ResetDisposalForm();
        }

        /// <summary>
        /// Clears disposal related info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearDisposal_Click(object sender, EventArgs e)
        {
            ResetDisposalForm();
        }

        /// <summary>
        /// Resets disposal related info from the form
        /// </summary>
        private void ResetDisposalForm()
        {
            txtReasons.Text = "";
            txtDisposalDescription.Text = "";
            _disposalReasonId = 0;
            btnDisposalSave.Text = "Update";
        }


        #endregion

        #region Location

        /// <summary>
        /// Loads the location tree
        /// </summary>
        private void PopulateLocationTree()
        {
            BLL.Region reg = new BLL.Region();
            Zone zon = new Zone();
            Woreda wrd = new Woreda();
            reg.LoadAll();
            locationTree.Nodes.Clear();
            foreach (DataRowView dv in reg.DefaultView)
            {
                TreeNode nodes = new TreeNode
                                     {
                                         Name = "Reg" + dv["ID"].ToString(),
                                         Text = dv["RegionName"].ToString(),
                                         ToolTipText = "Double Click to Edit."
                                     };
                zon.GetZoneByRegion(Convert.ToInt32(dv["ID"]));
                foreach (DataRowView subDv in zon.DefaultView)
                {
                    TreeNode zonNodes = new TreeNode
                                            {
                                                Name = "Zon" + subDv["ID"].ToString(),
                                                Text = subDv["ZoneName"].ToString(),
                                                ToolTipText = "Double Click to Edit."
                                            };
                    wrd.GetWoredaByZone(Convert.ToInt32(subDv["ID"]));
                    foreach (DataRowView worDv in wrd.DefaultView)
                    {
                        TreeNode wrdNodes = new TreeNode
                                                {
                                                    Name = "Wrd" + worDv["ID"].ToString(),
                                                    Text = worDv["WoredaName"].ToString(),
                                                    ToolTipText = "Double Click to Edit."
                                                };
                        zonNodes.Nodes.Add(wrdNodes);
                    }
                    nodes.Nodes.Add(zonNodes);
                }
                locationTree.Nodes.Add(nodes);
            }

            cboRegion.DataSource = reg.DefaultView;


        }

        /// <summary>
        /// Handles the adding of a region
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRegion_Click(object sender, EventArgs e)
        {
            cboZone.Enabled = false;
            cboWoreda.Enabled = false;
            cboRegion.Enabled = true;
            _locId = 0;
            _locationType = "Reg";
        }

        /// <summary>
        /// Handles double click event of the location tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locationTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BLL.Region rgn = new BLL.Region();
            Zone zon = new Zone();
            Woreda wrd = new Woreda();
            string value = locationTree.SelectedNode.Name;
            string type = value.Substring(0, 3);
            int len = value.Length - 3;
            int locationId = Convert.ToInt32(value.Substring(3, len));
            if (type == "Reg")
            {
                rgn.LoadByPrimaryKey(locationId);
                cboRegion.SelectedValue = rgn.ID.ToString();
                txtCode.Text = rgn.RegionCode;
                cboWoreda.Enabled = false;
                cboZone.Enabled = false;
                cboRegion.Enabled = true;
                _locId = rgn.ID;
            }
            else if (type == "Zon")
            {
                zon.LoadByPrimaryKey(locationId);
                cboZone.SelectedValue = zon.ID.ToString();
                txtCode.Text = zon.ZoneCode;
                cboRegion.SelectedValue = zon.RegionId.ToString();
                cboWoreda.Enabled = false;
                cboRegion.Enabled = true;
                cboZone.Enabled = true;
                _locId = zon.ID;
            }
            else if (type == "Wrd")
            {
                wrd.LoadByPrimaryKey(locationId);
                cboWoreda.SelectedValue = wrd.ID.ToString();
                txtCode.Text = wrd.WoredaCode;
                cboZone.SelectedValue = wrd.ZoneID.ToString();
                zon.LoadByPrimaryKey(wrd.ZoneID);
                cboRegion.SelectedValue = zon.RegionId.ToString();
                cboWoreda.Enabled = true;
                cboRegion.Enabled = true;
                cboZone.Enabled = true;
                _locId = wrd.ID;

            }
            _locationType = type;
        }

        /// <summary>
        /// Populates the zones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zone zn = new Zone();
            zn.GetZoneByRegion(Convert.ToInt32(cboRegion.SelectedValue));
            cboZone.DataSource = zn.DefaultView;
        }

        /// <summary>
        /// Populates the Woredas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            Woreda wer = new Woreda();
            wer.GetWoredaByZone(Convert.ToInt32(cboZone.SelectedValue));
            cboWoreda.DataSource = wer.DefaultView;
        }

        /// <summary>
        /// Hanldes the adding of a zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddZone_Click(object sender, EventArgs e)
        {
            cboWoreda.Enabled = false;
            cboZone.Enabled = true;
            cboRegion.Enabled = true;
            _locId = 0;
            _locationType = "Zon";
        }

        /// <summary>
        /// Handles the adding of a woreda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWoreda_Click(object sender, EventArgs e)
        {
            cboWoreda.Enabled = true;
            cboZone.Enabled = true;
            cboRegion.Enabled = true;
            _locId = 0;
            _locationType = "Wrd";
        }

        /// <summary>
        /// Save location related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            if (_locationType == "Reg")
            {
                BLL.Region reg = new BLL.Region();
                if (_locId != 0)
                    reg.LoadByPrimaryKey(_locId);
                else
                    reg.AddNew();
                reg.RegionName = cboRegion.Text;
                reg.RegionCode = txtCode.Text;
                reg.Save();

            }
            else if (_locationType == "Zon")
            {
                Zone zn = new Zone();
                if (_locId != 0)
                    zn.LoadByPrimaryKey(_locId);
                else
                    zn.AddNew();
                zn.ZoneName = cboZone.Text;
                zn.RegionId = Convert.ToInt32(cboRegion.SelectedValue);
                zn.ZoneCode = txtCode.Text;
                zn.Save();
            }
            else if (_locationType == "Wrd")
            {
                Woreda wrd = new Woreda();
                if (_locId != 0)
                    wrd.LoadByPrimaryKey(_locId);
                else
                    wrd.AddNew();
                wrd.WoredaName = cboWoreda.Text;
                wrd.ZoneID = Convert.ToInt32(cboZone.SelectedValue);
                wrd.WoredaCode = txtCode.Text;
                wrd.Save();
            }
            PopulateLocationTree();
        }

        private void xpButton26_Click(object sender, EventArgs e)
        {
            cboWoreda.Enabled = true;
            cboZone.Enabled = true;
            cboRegion.Enabled = true;
            _locId = 0;
        }
        
        #endregion

        #region unit

        /// <summary>
        /// Saves unit info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnitSave_Click(object sender, EventArgs e)
        {
            if (txtUnit.Text != "")
            {
                BLL.Unit uni = new Unit();
                if (_unitId != 0)
                    uni.LoadByPrimaryKey(_unitId);
                else
                    uni.AddNew();
                uni.Unit = txtUnit.Text;
                uni.Description = txtUnitDescription.Text;
                uni.Save();
                uni.LoadAll();
                lstUnits.DataSource = uni.DefaultView;
                ResetUnit();
            }
            else
            {
                txtUnit.BackColor = Color.FromArgb(251, 214, 214);
            }
        }

        /// <summary>
        /// Reset unit related info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewUnit_Click(object sender, EventArgs e)
        {
            ResetUnit();
        }

        
        private void btnClearUnit_Click(object sender, EventArgs e)
        {
            ResetUnit();
        }

        /// <summary>
        /// Resets unit related information
        /// </summary>
        private void ResetUnit()
        {
            txtUnit.Text = "";
            txtUnitDescription.Text = "";
            _unitId = 0;
            btnUnitSave.Text = "Save";
            txtUnit.BackColor = Color.White;
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            txtUnit.BackColor = Color.White;
        }
        #endregion

        #region Inn


        private void PopulateINN(INN innInfo)
        {
            gridProducts.DataSource = innInfo.DefaultView;
        }

        /// <summary>
        /// Saves INN related info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInnSave_Click(object sender, EventArgs e)
        {
            if (txtINN.Text != "")
            {
                INN newInn = new INN();
                if (_innId != 0)
                    newInn.LoadByPrimaryKey(_innId);
                else
                    newInn.AddNew();
                newInn.IIN = txtINN.Text;
                //newInn.ATC = txtATC.Text;
                newInn.Description = txtIINDescription.Text;
                newInn.TypeID = ((rdDrug.Checked) ? 1 : 2);
                newInn.Save();
                newInn.LoadAll();
                PopulateINN(newInn);
                ResetInnForm();
            }
            else
            {
                txtINN.BackColor = Color.FromArgb(251, 214, 214);

            }
        }



        private void xpButton31_Click(object sender, EventArgs e)
        {
            ResetInnForm();
        }

        private void xpButton32_Click(object sender, EventArgs e)
        {
            ResetInnForm();
        }

        /// <summary>
        /// Clears INN related information
        /// </summary>
        private void ResetInnForm()
        {
            _innId = 0;
            txtINN.Text = "";
            //txtATC.Text = "";
            txtIINDescription.Text = "";
            btnInnSave.Text = "Save";
            txtINN.BackColor = Color.White;
        }

        private void txtINN_TextChanged(object sender, EventArgs e)
        {
            txtINN.BackColor = Color.White;
        }


        #endregion

        #region DosageForm

        private void PopulateDosageForm(DosageForm doForm)
        {

            gridDosageForm.DataSource = doForm.DefaultView;

        }

        private void btnDosageSave_Click(object sender, EventArgs e)
        {
            if (txtDosageForm.Text != "")
            {
                DosageForm doForm = new DosageForm();
                if (_dosageFormId != 0)
                    doForm.LoadByPrimaryKey(_dosageFormId);
                else
                    doForm.AddNew();
                doForm.Form = txtDosageForm.Text;
                doForm.Description = txtDosageDescription.Text;
                doForm.TypeID = ((rdDosDrug.Checked) ? 1 : 2);
                doForm.Save();
                doForm.LoadAll();
                PopulateDosageForm(doForm);
                ResetDosageForm();
            }
            else
            {
                txtDosageForm.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Reset dosage related information from the form
        /// </summary>
        private void ResetDosageForm()
        {
            _dosageFormId = 0;
            rdDosDrug.Checked = true;
            txtDosageDescription.Text = "";
            txtDosageForm.Text = "";
            btnDosageSave.Text = "Save";
            txtDosageForm.BackColor = Color.White;
        }

        private void btnAddDosageForm_Click(object sender, EventArgs e)
        {
            ResetDosageForm();
        }

        private void btnClearDosage_Click(object sender, EventArgs e)
        {
            ResetDosageForm();
        }

        #endregion


        private void txtReasons_TextChanged(object sender, EventArgs e)
        {
            txtReasons.BackColor = Color.White;
        }

        private void txtDosageForm_TextChanged(object sender, EventArgs e)
        {
            txtDosageForm.BackColor = Color.White;
        }

        /// <summary>
        /// Handles the selection changed event of the grid product view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridProductView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow dr = gridProductView.GetFocusedDataRow();
            int selection = Convert.ToInt32(dr["ID"]);

            INN nInn = new INN();
            nInn.LoadByPrimaryKey(selection);
            //txtATC.Text = nInn.ATC;
            txtINN.Text = nInn.IIN;
            txtIINDescription.Text = nInn.Description;
            rdDrug.Checked = ((nInn.TypeID == 1) ? true : false);
            rdSupply.Checked = ((nInn.TypeID == 2) ? true : false);
            _innId = nInn.ID;
            btnInnSave.Text = "Update";
        }

        /// <summary>
        /// Handles when the focused row gets changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridProductView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridProductView.GetFocusedDataRow();
            int selection = Convert.ToInt32(dr["ID"]);

            INN nInn = new INN();
            nInn.LoadByPrimaryKey(selection);
            //txtATC.Text = nInn.ATC;
            txtINN.Text = nInn.IIN;
            txtIINDescription.Text = nInn.Description;
            rdDrug.Checked = ((nInn.TypeID == 1) ? true : false);
            rdSupply.Checked = ((nInn.TypeID == 2) ? true : false);
            _innId = nInn.ID;
            btnInnSave.Text = "Update";
        }

        /// <summary>
        /// Handles the focused row changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridUnit_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridUnit.GetFocusedDataRow();
            int id = Convert.ToInt32(dr["ID"]);

            Unit u = new Unit();
            u.LoadByPrimaryKey(id);
            txtUnit.Text = u.Unit;
            txtUnitDescription.Text = u.Description;
            _unitId = u.ID;
        }

        /// <summary>
        /// Handles the treeCategory focused node changed and updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            Category cat = new Category();
            SubCategory subCat = new SubCategory();
            if (treeCategory.Selection.Count == 0)
                return;

            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));
            string type = "cat";
            if (value.Substring(0, 1) == "S")
            {
                type = "sub";
            }
            else if (value == "P999")
            {
                type = "All";
            }

            if (type == "cat")
            {
                cat.LoadByPrimaryKey(categoryId);
                cboCategory.SelectedValue = categoryId.ToString();
                cboCategory.Visible = false;
                txtCategory.Text = cat.CategoryName;
                txtCatCode.Text = cat.CategoryCode;
                txtDescription.Text = cat.Description;
                _catId = cat.ID;

            }
            else if (type == "sub")
            {
                subCat.LoadByPrimaryKey(categoryId);
                cboCategory.Visible = true;

                cboCategory.SelectedValue = subCat.CategoryId.ToString();
                txtCategory.Text = subCat.SubCategoryName;
                txtCatCode.Text = subCat.SubCategoryCode;
                txtDescription.Text = subCat.Description;
                _catId = subCat.ID;
            }
            btnSave.Text = "Update";
        }

        /// <summary>
        /// Handles the treeSupCategory focused node changed and updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeSupCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            SupplyCategory supCat = new SupplyCategory();
            string value = treeSupCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));

            supCat.LoadByPrimaryKey(categoryId);
            if (supCat.ParentId != 0)
            {
                cboSupCat.Visible = true;

                lblSupCat.Text = "Sub Category";
                cboSupCat.SelectedValue = Convert.ToInt32(supCat.ParentId);
            }
            else
            {
                cboSupCat.Visible = false;
                lblSupCat.Text = "Main Category";
            }
            txtSupCat.Text = supCat.Name;
            txtSupCode.Text = supCat.Code;
            _supCatId = supCat.ID;
            btnSave.Text = "Update";
        }

        /// <summary>
        /// Handles the TreeProgram focused node changed and updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeProgram_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int selected = Convert.ToInt32(TreeProgram.Selection[0]["ID"]);
            Programs prog = new Programs();
            prog.LoadByPrimaryKey(selected);

            if (prog.ParentID != 0)
            {
                cboProgram.SelectedValue = prog.ParentID.ToString();
                //lblProgram.Text = "Sub Program";
                cboProgram.Visible = true;
                //lbPro.Visible = true;
            }
            else
            {
                cboProgram.SelectedValue = prog.ID.ToString();
                cboProgram.Visible = false;
                //lbPro.Visible = false;
                //lblProgram.Text = "Program";
            }
            txtProgram.Text = prog.Name;
            txtProgramDescription.Text = prog.Description;
            _programId = prog.ID;
        }

        /// <summary>
        /// Handles the gridViewDosageForm focused node changed and updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDosageForm_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewDosageForm.GetFocusedDataRow();
            if (dr != null)
            {
                DosageForm doForm = new DosageForm();
                int formId = Convert.ToInt32(dr["ID"]);
                doForm.LoadByPrimaryKey(formId);
                txtDosageForm.Text = doForm.Form;
                txtDosageDescription.Text = doForm.Description;
                // if (doForm.TypeID == 1)
                rdDosDrug.Checked = ((doForm.TypeID == 1) ? true : false);
                rdDosSupply.Checked = ((doForm.TypeID == 2) ? true : false);
                _dosageFormId = doForm.ID;
                btnDosageSave.Text = "Update";
            }
        }

        /// <summary>
        /// Handles the gridViewReason focused node changed and updates the form accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewReason_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewReason.GetFocusedDataRow();
            if (dr != null)
            {
                DisposalReasons reason = new DisposalReasons();
                int reasonId = Convert.ToInt32(dr["ID"]);
                reason.LoadByPrimaryKey(reasonId);
                txtReasons.Text = reason.Reason;
                txtDisposalDescription.Text = reason.Description;
                _disposalReasonId = reason.ID;
                btnDisposalSave.Text = "Update";
            }
        }
    }
}