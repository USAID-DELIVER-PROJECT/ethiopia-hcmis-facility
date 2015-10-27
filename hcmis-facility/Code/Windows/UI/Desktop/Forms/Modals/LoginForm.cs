using System;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using PharmInventory.Forms.Tools;
using ConnectionStringManager;
using PharmInventory.Forms.Transactions;
using PharmInventory.HelperClasses;
using System.ComponentModel;
namespace PharmInventory.Forms.Modals
{
    public partial class LoginForm : XtraForm
    {   
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(bool loadConnectionConfig)
        {
            _loadConnectionConfigAtStartUp = loadConnectionConfig;
            InitializeComponent();
        }

        
        private readonly bool _loadConnectionConfigAtStartUp = false;
        private int _usId = 0;

        public int UsId
        {
            get { return _usId; }
            private set { _usId = value; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string connectionString = GenerateConnString.GetFromRegistry();
                
                string connectionString = Program.ConnStringManager.GetFromRegistry();
                if(string.IsNullOrEmpty(connectionString)) //If the connection string hasn't been set, let's assume that the database is installed in the default location (ApplicationStartUpPath\Database\PharmInventory.mdf)
                {
                    connectionString = Program.ConnStringManager.GenerateDefaultConnectionString(@".\SQLExpress", @"C:\Databases\FE\PharmInventory.mdf",false);
                    Program.ConnStringManager.SaveToRegistry(connectionString);
                }
                
                MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString = connectionString;

                User us = new User();
                us.GetUserByAccountInfo(txtUsername.Text, txtPassword.Text);
                if (us.RowCount > 0)
                {
                    //check for last date of backup and if old just do another one
                    GeneralInfo info = new GeneralInfo();
                    info.LoadAll();
                    TimeSpan spanAfterBackup;
                    int daysSinceBackup = -1;
                    if (!info.IsColumnNull("LastBackUp"))
                    {
                        spanAfterBackup = DateTime.Now.Subtract(info.LastBackUp);
                        daysSinceBackup = spanAfterBackup.Days;
                    }

                    if (daysSinceBackup > 7 || daysSinceBackup == -1)
                    {
                        HelperClasses.DatabaseHelpers.AutoBackUp();
                    }
                    DatabaseHelpers.FixInconsistencies(); //Clean any database inconsistencies

                    //XtraMessageBox.Show("Would you please chose the FE Settings", "Warning");
                    var mw = new MainWindow {UserId = MainWindow.LoggedinId = us.ID};
                    UsId = us.ID;
                    mw.Show();

                    try
                    {
                        HelperClasses.RegistrationHelper.SendAdditionalData("LastLogin", DateTime.Now.ToString());
                    }
                    catch { }

                    YearEnd yEnd = new YearEnd();
                    if (yEnd.InventoryRequired(true))
                    {
                        XtraMessageBox.Show("Inventory information has not been filled for the past fiscal year!",
                                            "Inventory Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    this.Hide();
                }
                else
                {
                    XtraMessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch
            {
                //Tools.GenerateConnString generator = new Tools.GenerateConnString();
                //generator.ShowDialog();
                Program.ConnStringManager.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
            //MyGeneration.dOOdads.SqlClientEntity.RegistryConnectionString = GetFromRegistry();//"Data Source=P-6294A2;Initial Catalog=Dila;Integrated Security=true;";            
            //MyGeneration.dOOdads.SqlClientEntity.DefaultConnectionStringConfig = "Data Source=.\\MSSQLSERVER2008;Initial Catalog=Bishoftu;Integrated Security=true;";
            //MyGeneration.dOOdads.BusinessEntity.DefaultConnectionStringConfig = MyGeneration.dOOdads.SqlClientEntity.DefaultConnectionStringConfig;            
            if (_loadConnectionConfigAtStartUp == true)
            {
                //Tools.GenerateConnString generator = new Tools.GenerateConnString();
                //generator.ShowDialog();
                Program.ConnStringManager.ShowDialog();
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Program.SaveHCMISVersionToRegistry();
                Program.UpdateDatabase();
                HelperClasses.RegistrationHelper.SendAdditionalData("LastIssueDate", BLL.IssueDoc.GetLastIssuedDate().ToString());
                HelperClasses.RegistrationHelper.SendAdditionalData("LastReceiveDate", BLL.ReceiveDoc.GetLastReceivedDate().ToString());
            }
            catch
            {
            }
        }



    }
}