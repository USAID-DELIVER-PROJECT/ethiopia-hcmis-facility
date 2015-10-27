using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.UtilitiesAndForms
{
    public partial class Registrations : Form
    {
        public Registrations()
        {
            InitializeComponent();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrations_Load(object sender, EventArgs e)
        {
            string authenticationCode = RegistrationHelper.GetAuthenticationCode();
            if (!string.IsNullOrEmpty(authenticationCode))
            {
                if (XtraMessageBox.Show("HCMIS Already registered.  Trying to register again may invalidate your current registration information.  Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    this.Close();
                }
            }

            cboUserType.Properties.Items.AddRange(RegistrationHelper.UserTypesForFE());
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFacilityID.Enabled = cboUserType.Text != "Individual User";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HCMISRegistrations.RegistrationsSoapClient soapClient = new HCMISRegistrations.RegistrationsSoapClient();
            int? facilityID = null;

            if (txtFacilityID.Text != "")
                facilityID = int.Parse(txtFacilityID.Text);

            int registered = -1;
            int userType = RegistrationHelper.GetUserTypeID(cboUserType.Text);
            registered = soapClient.RegisterNewUser(txtUserName.Text, userType, facilityID, txtAssemblyName.Text, Program.HCMISVersionString, txtAuthenticationCode.Text);
            if (registered!=-1)
            {
                //Save Authentication code to the registry
                RegistrationHelper.SaveAuthenticationInfoToRegistry(txtAuthenticationCode.Text, userType,facilityID,registered);
                XtraMessageBox.Show("Successfully Registered.", "Registration");
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Registration failed!", "Registration");
            }
        }
    }
}
