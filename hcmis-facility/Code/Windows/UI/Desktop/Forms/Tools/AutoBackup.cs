using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace PharmInventory.Forms.Tools
{
    public partial class AutoBackup : XtraForm
    {
        public AutoBackup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the autobackup configuration to the registry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("Software\\JSI\\HCMIS\\Configuration");
            reg.SetValue("AutoBackupEnabled", chkAutobackupEnabled.Checked);
            if (chkAutobackupEnabled.Checked)
            {
                reg.SetValue("AutoBackupFrequency", cboFrequency.SelectedText);
                reg.SetValue("AutoBackupFolder", btnEditFolder.Text);
            }
            XtraMessageBox.Show("Auto backup settings successfully changed.", "Successfully Saved.");
            this.Close();
        }

        private void chkAutobackupEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cboFrequency.Enabled = chkAutobackupEnabled.Checked;
            btnEditFolder.Enabled = chkAutobackupEnabled.Checked;
        }

        private void btnEditFolder_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnEditFolder.Text = folder.SelectedPath;
            }
        }
        
        /// <summary>
        /// Pulls the autobackup configuration from the registry if there is any.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoBackup_Load(object sender, EventArgs e)
        {
            bool isAutoBackUpEnabled=PharmInventory.HelperClasses.DatabaseHelpers.GetIsAutoBackupEnabled();
            string autoBackupFrequency=PharmInventory.HelperClasses.DatabaseHelpers.GetAutoBackupFrequency();
            string folderLocation=PharmInventory.HelperClasses.DatabaseHelpers.GetDBAutoBackupPath();

            chkAutobackupEnabled.Checked = isAutoBackUpEnabled;
            if(chkAutobackupEnabled.Checked==true)
            {
                cboFrequency.SelectedText = autoBackupFrequency;
                btnEditFolder.Text = folderLocation;
            }
        }


    }
}