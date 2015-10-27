using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using BLL;
using System.IO;
using DevExpress.XtraEditors;
using System.Configuration;
using DevExpress.XtraLayout.Utils;
using Microsoft.Win32;
using PharmInventory.DirectoryService;
using PharmInventory.Forms.Tools;
using PharmInventory.HelperClasses;
using StockoutIndexBuilder.DAL;
using ABC = BLL.ABC;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;


namespace PharmInventory.Forms.UtilitiesAndForms
{
    public partial class DatabaseActions : XtraForm
    {
        public const string UIDPWD_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\UIDConfig";
        public const string REMOTE_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\RSConfig";
        public const string PSCONFIG_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\PSConfig";
       
        public const string HANDLE_UNITS_KEY = @"HandleUnits";
        public const string PS_CONFIG_KEY = @"PSConfig";

        public const string UID_PWD_KEY = @"UserNameAndPasswordConfig";
        public const string REMOTE_CONFIG_KEY = @"RemoteServerAddressConfig";
        public const  string keyvalue1 ="-u \"Administrator\" -p \"lucky@bole2005\"";
        public const  string keyvalue2 ="\\192.168.2.62";
        public const string keyvalue3 = @"C:\Tools\PsExec.exe";

        GeneralInfoRepository genralInfo =new GeneralInfoRepository();
        public DatabaseActions()
        {
            InitializeComponent();
            Write1(UID_PWD_KEY,keyvalue1);
            Write2(REMOTE_CONFIG_KEY,keyvalue2);
            Write3(PS_CONFIG_KEY, keyvalue3);

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog1.FileName;

                    string connectionString = "";
                    // this try catch is used only to avoid the error that will happen when the registry connection string gives error and the connection string has fallen to thee default location in the configutration filee.

                    try
                    {
                        connectionString = PharmInventory.HelperClasses.DatabaseHelpers.GetConnectionString();
                    }
                    catch
                    {
                        connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();
                    }
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
                    System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();

                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string dbName = conn.Database;
                    com.CommandText = " USE MASTER RESTORE DATABASE [" + dbName + "] FROM  DISK = N'" + path + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
                    com.Connection = conn;
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Restore completed!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    XtraMessageBox.Show("Restore has failed! Make sure that the file exists and  Try Again.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DatabaseActions_Load(object sender, EventArgs e)
        {
            SyncImageVisibility(false);
            if (MainWindow.IsAdmin)
                btnRestore.Enabled = true;
            else
                btnRestore.Enabled = false;


            GetLastBackupAndSyncDates();

        }

        private void GetLastBackupAndSyncDates()
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            TimeSpan tt = new TimeSpan();

            if (!info.IsColumnNull("LastBackUp"))
            {
                string lastBackupDt = info.LastBackUp.ToString("MMM dd,yyyy") + " (" + DateTime.Now.Subtract(info.LastBackUp).Days + " days ago)"; ;
                lblLastBackupDate.Text = "Last Backup Date: " + lastBackupDt;
            }

            if (!info.IsColumnNull("LastSync"))
            {
                int days = DateTime.Now.Subtract(info.LastSync).Days;
                string lastSyncDt;
                if (days != 0)
                {
                    lastSyncDt = info.LastSync.ToString("MMM dd,yyyy") + " (" + days +
                                        " days ago)";
                }

                else
                    lastSyncDt = info.LastSync.ToString("MMM dd,yyyy") + " (Today)";

                lblLastSyncDate.Text = "Last Sync Date: " + lastSyncDt;
            }
        }

        private void btnImportUpdate_Click(object sender, EventArgs e)
        {
            bool success = true;
            if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to import this file? Please make sure you have backup of the database before running this update.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                OpenFileDialog od = new OpenFileDialog();
                if (DialogResult.OK == od.ShowDialog())
                {
                    StreamReader sr = new StreamReader(new FileStream(od.FileName, FileMode.Open, FileAccess.Read), false);
                    ABC abc = new ABC();
                    string query = "";
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        if (str == "GO" || (sr.EndOfStream && str != ""))
                        {
                           
                            success = abc.LoadQuery(query);
                            //XtraMessageBox.Show(query);
                            str = "";
                            query = "";
                            continue;
                        }
                        query += "\n" + str;
                    }

                    if (success == false)
                        XtraMessageBox.Show("Your Database has been updated with errors!", "Notice");
                    else
                        XtraMessageBox.Show("Your Database has been updated! Please restart the application and try again!", "Notice");
                };
            }
        }

        private void btnAutoBackup_Click(object sender, EventArgs e)
        {
            AutoBackup autoBackUpSettings = new AutoBackup();
            autoBackUpSettings.ShowDialog();
        }

        private void btnRefreshDirectoryService_Click(object sender, EventArgs e)
        {
            SyncImageVisibility(true);
            btnRefreshDirectoryService.Enabled = false;
            bw.RunWorkerAsync(MainWindow.LoggedinId);
        }

        private void SyncImageVisibility(bool visibility)
        {
            if (visibility == false)
            {
                lcSyncLabel.Visibility = LayoutVisibility.Never;
                lcSyncPic.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcSyncLabel.Visibility = LayoutVisibility.Always;
                lcSyncPic.Visibility = LayoutVisibility.Always;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int userID = Convert.ToInt32(e.Argument);
            BLL.User user = new User();
            user.LoadByPrimaryKey(userID);
            try
            {

                HelperClasses.DirectoryServices.RefreshFromDirectoryServices();
                BLL.GeneralInfo info = new GeneralInfo();
                info.LoadAll();
                info.LastSync = DateTime.Now;
                info.Save();
                e.Result = "Completed!";
            }
            catch (Exception ex)
            {
                if (user.UserType != UserType.Constants.SYSTEM_ADMIN)
                    e.Result =
                        "There has been a network error.  The database is not in sync with directory services.  Please connect to the Internet and try again.";
                else
                    e.Result = ex.Message;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SyncImageVisibility(false);

            XtraMessageBox.Show(e.Result.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRefreshDirectoryService.Enabled = true;
            GetLastBackupAndSyncDates();
        }

        private void btnRunSSIS_Click(object sender, EventArgs e)
        {
            var geninfo = genralInfo.AllGeneralInfos().SingleOrDefault();
            var facilityID = geninfo.FacilityID;

            var fileName = VisibilitySetting.PSConfig;
            var remoteComputer = VisibilitySetting.RemoteServerAddressConfig;
            var usernameAndPassword =VisibilitySetting.UserNameAndPasswordConfig;
            const string ssisCommand = @"C:\SSIS\ExecutePackages.exe";
            var ssisCommandParameters = string.Format("-pull {0}", facilityID);
           
            string arguments = String.Format("{0} {1} \"{2}\" {3}", remoteComputer, usernameAndPassword, ssisCommand,
                                             ssisCommandParameters);
            if (!File.Exists(fileName))
            {
                XtraMessageBox.Show("PsTools Not Installed. Please contact the administrator Or Install PsTools","Warning");
                return;
            }
            Process.Start(fileName, arguments).WaitForExit();
            XtraMessageBox.Show("Synchronisation Successfull!");


        }

        public bool Write1(string KeyName, string valueName)
        {
             try
            {
                // if the sub key doesn't exsit ... create it.
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(UIDPWD_REGISTRY_PATH);
                // Save the value
                sk1.SetValue(UID_PWD_KEY, keyvalue1);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Write2(string KeyName, string valueName)
        {
            try
            {
                // if the sub key doesn't exsit ... create it.
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(REMOTE_REGISTRY_PATH);
                // Save the value
                sk1.SetValue(REMOTE_CONFIG_KEY, keyvalue2);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Write3(string KeyName, string valueName)
        {
            try
            {
                // if the sub key doesn't exsit ... create it.
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(PSCONFIG_REGISTRY_PATH);
                // Save the value
                sk1.SetValue(PS_CONFIG_KEY, keyvalue3);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}