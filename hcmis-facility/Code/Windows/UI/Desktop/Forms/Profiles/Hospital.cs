using System;
using System.ComponentModel;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Contains the interaction logic for the Hospital Form
    /// </summary>
    public partial class Hospital :XtraForm
    {
        public Hospital()
        {
            InitializeComponent();
        }

        readonly GeneralInfo _hospInfo = new GeneralInfo();
        int _hospitalId = 0;

        /// <summary>
        /// Loads the regions, zones and woredas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hospital_Load(object sender, EventArgs e)
        {
           //BLL.Region reg = new BLL.Region();
           // reg.LoadAll();
           // cboRegion.DataSource = reg.DefaultView;
           // Zone zon = new Zone();
           // zon.LoadAll();
           // cboZone.DataSource = zon.DefaultView;
           // Woreda wor = new Woreda();
           // wor.LoadAll();
           // cboWoreda.DataSource = wor.DefaultView;
            GetLookUp();
            PopulateFields();
          
        }

        /// <summary>
        /// Populates the fields of the form
        /// </summary>
        private void PopulateFields()
        {
            lookUpEdit1.EditValue = Convert.ToInt32(VisibilitySetting.GetRegistryValue(VisibilitySetting.REGISTRY_PATH,VisibilitySetting.HANDLE_UNITS_KEY));
            _hospInfo.LoadAll();
           
            txtHospitalName.Text = _hospInfo.HospitalName;
            txtPhone.Text = _hospInfo.Telephone;
            //txtContactPerson.Text = _hospInfo.HospitalContact;
            //cboRegion.SelectedValue = _hospInfo.Region;
            //cboWoreda.SelectedValue = _hospInfo.Woreda;
            //cboZone.SelectedValue = _hospInfo.Zone;
            string [] userPass = _hospInfo.Description.Split(';');
            txtUserName.Text = userPass[0];
            txtScmsUserName.Text = _hospInfo.ScmsWSUserName;
            txtScmsPassword.Text = _hospInfo.ScmsWSPassword;
            txtPassword.Text = (userPass.Length == 1) ? "" : userPass[1];
            cboDSUpdateFrequency.EditValue = _hospInfo.IsColumnNull("DSUpdateFrequency")?"": _hospInfo.DSUpdateFrequency;
            cboHCTSUpdateFrequency.EditValue = _hospInfo.IsColumnNull("RRFStatusUpdateFrequency")?"":_hospInfo.RRFStatusUpdateFrequency;
            cboHCTSFirstUpdate.EditValue = _hospInfo.IsColumnNull("RRFStatusFirstUpdateAfter") ? "" : _hospInfo.RRFStatusFirstUpdateAfter;
            _hospitalId = _hospInfo.ID;
           //  chkNormal.EditValue = _hospInfo.NormalFacility;
            if (!_hospInfo.IsColumnNull("FacilityID"))
            {
                txtFacilityID.EditValue = _hospInfo.FacilityID;
            }
        }

        private void GetLookUp()
        {
            var fe = new FeSetting();
            settingbindingSource.DataSource = fe.GetFeLookup();
            //lookUpEdit1.Properties.DisplayMember = "Name";
            //lookUpEdit1.Properties.ValueMember = "RecordID";
        }

        

        /// <summary>
        /// Handles the region changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Zone zon = new Zone();
            //zon.GetZoneByRegion(Convert.ToInt32(cboRegion.SelectedValue));
            //cboZone.DataSource = zon.DefaultView;
        }

        /// <summary>
        /// Handles the cboZone SelectedIndexChanged event
        /// Populates the Woreda based on the selected Zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Woreda wor = new Woreda();
            //wor.GetWoredaByZone(Convert.ToInt32(cboZone.SelectedValue));
            //cboWoreda.DataSource = wor.DefaultView;
        }

        private static readonly System.Configuration.AppSettingsReader ReadApp = new System.Configuration.AppSettingsReader();

        /// <summary>
        /// Saves the Facility Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            User user =new User();
            user.LoadByPrimaryKey(MainWindow.LoggedinId);
           if (_hospitalId == 0)
                return;

            if (XtraMessageBox.Show("Are You sure, You want to save the changes to Hospital General Info.?", "Confirmation",
                                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (user.UserName != "admin")
            {
                XtraMessageBox.Show("You have no privilege to change FE setting!", "Error");
                return;
               
            }
            switch (Convert.ToInt32(lookUpEdit1.EditValue))
            {
                case 1:
                    VisibilitySetting.SetRegistryValue(VisibilitySetting.HANDLE_UNITS_KEY, 1);
                    break;
                case 2:
                    VisibilitySetting.SetRegistryValue(VisibilitySetting.HANDLE_UNITS_KEY, 2);
                    break;
                case 3:
                    VisibilitySetting.SetRegistryValue(VisibilitySetting.HANDLE_UNITS_KEY, 3);
                    break;
            }


            _hospInfo.LoadByPrimaryKey(_hospitalId);
            _hospInfo.HospitalName = txtHospitalName.Text;
          
            //_hospInfo.HospitalContact = txtContactPerson.Text;
            _hospInfo.Telephone = txtPhone.Text;
            if(txtUserName.Text.IndexOf(';')!=-1 || txtPassword.Text.IndexOf(';')!=-1)
            {
                XtraMessageBox.Show("User name or password cannot contain the ';' character!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _hospInfo.Description = txtUserName.Text + ";" + txtPassword.Text;
            _hospInfo.DSUpdateFrequency = cboDSUpdateFrequency.EditValue.ToString();
            _hospInfo.RRFStatusUpdateFrequency = cboHCTSUpdateFrequency.EditValue.ToString();
            _hospInfo.RRFStatusFirstUpdateAfter = cboHCTSFirstUpdate.EditValue.ToString();
            //_hospInfo.NormalFacility = (bool) chkNormal.EditValue;
            //_hospInfo.Region = Convert.ToInt32(cboRegion.SelectedValue);
            //_hospInfo.Woreda = Convert.ToInt32(cboWoreda.SelectedValue);
            //_hospInfo.Zone = Convert.ToInt32(cboZone.SelectedValue);

            if (txtFacilityID.Text != "")
            {
                _hospInfo.FacilityID = Convert.ToInt32(txtFacilityID.EditValue);
                _hospInfo.ScmsWSUserName = txtScmsUserName.Text;
                _hospInfo.ScmsWSPassword = txtScmsPassword.Text;
            }
            if (txtLogo.Text != "")
            {
                try
                {
                    string logo = txtLogo.Text;
                    int le = logo.LastIndexOf('\\') + 1;
                    logo = logo.Substring(le, logo.Length - le);
                    string dest = ReadApp.GetValue("logoPath", typeof(string)).ToString();
                    System.IO.File.Copy(txtLogo.Text, dest + logo);
                    _hospInfo.Logo = logo;
                }
                catch { }
            }

            _hospInfo.Save();
            XtraMessageBox.Show("Facility Setting Successfully Saved.", "Success",
                                MessageBoxButtons.OK);


            PopulateFields();
            this.Parent.Parent.Text = _hospInfo.HospitalName + " - Ethiopian Health Commodity Management Information System(HCMS)";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateFields();
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtLogo.Text = openFileDialog1.FileName;
        }

    }
}