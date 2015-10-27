using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment.Application;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace PharmInventory.HelperClasses
{
    static class UpdateManager
    {
        private static ApplicationDeployment AppDeployment;

        public static bool UpdateRunning;
        public static bool RestartRequired;
        public static bool EnableAutomaticUpdating;

        static UpdateManager()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                AppDeployment = ApplicationDeployment.CurrentDeployment;
                AppDeployment.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(AppDeployment_CheckForUpdateCompleted);
                AppDeployment.UpdateCompleted += new System.ComponentModel.AsyncCompletedEventHandler(AppDeployment_UpdateCompleted);
            }
        }
        
        public static void UpdateApplication()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                XtraMessageBox.Show("The application is not network deployed and can't be updated online.",
                                    "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (RestartRequired)
            {
                XtraMessageBox.Show("The application needs to be restarted!", "Restart", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }

            if (UpdateRunning)
                return;

            UpdateRunning = true;
            AppDeployment.CheckForUpdateAsync();
        }

        private static void AppDeployment_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            UpdateRunning = false;

            if (e.Error != null)
            {
                XtraMessageBox.Show("An Error occurred:\n" + e.Error.Message, "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }

            if (!e.UpdateAvailable)
            {
                XtraMessageBox.Show("No updates found!", "AppDeployment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.Cancelled)
            {
                XtraMessageBox.Show("Update was cancelled!", "Update Cancelled", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }

            if (e.UpdateAvailable)
            {
                if (e.IsUpdateRequired)
                {
                    XtraMessageBox.Show("There is a mandatory update available. Click OK to start installation", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateRunning = true;
                    AppDeployment.UpdateAsync();
                    OnUpdating();
                }

                if (XtraMessageBox.Show("Update found! Would you like to download and install the update now?", "Update Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateRunning = true;
                    AppDeployment.UpdateAsync();
                    OnUpdating();
                }
            }
        }

        private static void OnUpdating()
        {
            MainWindow.Instance.mnuCheckForUpdates.Text = "Updating...";
        }

        private static void AppDeployment_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            UpdateRunning = false;

            if (e.Cancelled)
            {
                XtraMessageBox.Show("Update cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.Error != null)
            {
                XtraMessageBox.Show("Couldn't Install application! Reason: \n" + e.Error.Message);
            }

            //If it reaches here, a restart is required for the update to be applied.
            RestartRequired = true;
            if (XtraMessageBox.Show("Update Completed! Update will not take effect until you restart AppDeployment.  Restart AppDeployment now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }

            OnUpdateFinished();
        }

        private static void OnUpdateFinished()
        {
            MainWindow.Instance.mnuCheckForUpdates.Text = "Check for Updates";
        }


    }

    
}
