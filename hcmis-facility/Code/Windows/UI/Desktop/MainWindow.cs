using System;
using System.Deployment.Application;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.Forms.Modals;
using PharmInventory.Forms.Transactions;
using System.ComponentModel;

namespace PharmInventory
{
    /// <summary>
    /// Interaction logic for the main window form partially implemented here
    /// Partially implemented in the MainWindowController.cs File in the HelperClasses
    /// </summary>
    public partial class MainWindow : XtraForm
    {
        public static MainWindow Instance = null;

        private int _userId = 0;

        public int UserId
        {
            private get { return _userId; }
            set { _userId = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            MainWindow.Instance = this;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ChangeHospitalName();
            ShowAccessLevel();

            bwAMCCalculator.RunWorkerAsync();
        }

        /// <summary>
        /// Displays a form in the main panel of the main window. 
        /// </summary>
        /// <param name="title">The text to be displayed on the title bar</param>
        /// <param name="frm">The form to be displayed</param>
        private void AddTab(string title, Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            ttlBar.Text = title;
            frm.Show();
        }

        private static void OpenInExcel(System.Windows.Forms.ListView listView, string[] header)
        {
            // OpenInExcel(ExportTableToFile(header, true, listView, false));
        }

        public static void PrintFromExcel(System.Windows.Forms.ListView listView, string[] header)
        {
            //string fName = ExportTableToFile(header, true, listView, false);
            //OpenInExcel(fName);
        }

        /// <summary>
        /// Opens the file in excel
        /// </summary>
        /// <param name="filename"></param>
        public static void OpenInExcel(string filename)
        {
            System.Diagnostics.Process.Start(filename, "excel");
        }

        public static void OpenInPdf(string filename)
        {
            System.Diagnostics.Process.Start(filename, "pdf");
        }

        /// <summary>
        /// Exports a listview to excel
        /// </summary>
        /// <param name="lsView">The list view to be exported</param>
        /// <param name="header">The header for the excel file</param>
        public static void ExportToExcel(ListView lsView, string[] header)
        {
            OpenInExcel(lsView, header);
        }

        /// <summary>
        /// Gets a new file name for exporting with the specified extension.
        /// </summary>
        /// <param name="extension">The extension of the specified file</param>
        /// <returns>Returns a file name that can be used for exporting</returns>
        public static string GetNewFileName(string extension)
        {
            System.CodeDom.Compiler.TempFileCollection tempFileLocation =
                new System.CodeDom.Compiler.TempFileCollection();
            string tempFolder = GetTempFolder();
            if (!System.IO.Directory.Exists(tempFolder))
            {
                System.IO.Directory.CreateDirectory(tempFolder);
            }
            return tempFileLocation.AddExtension(extension);
        }

        /// <summary>
        /// Gets a temporary folder specifically for HCMIS
        /// </summary>
        /// <returns></returns>
        private static string GetTempFolder()
        {
            System.CodeDom.Compiler.TempFileCollection tempFileLocation =
                new System.CodeDom.Compiler.TempFileCollection();
            string tempFolder = tempFileLocation.BasePath;
            tempFolder = tempFolder.Substring(0, tempFolder.LastIndexOf("\\"));
            tempFolder += "\\HCMS";
            return tempFolder;
        }

        private static readonly System.Configuration.AppSettingsReader ReadApp = new System.Configuration.AppSettingsReader();

        private void ChangeHospitalName()
        {
            GeneralInfo hos = new GeneralInfo();
            hos.LoadAll();
            this.Text = hos.HospitalName + @" - Health Commodity Management Information System (HCMIS)";
           // picLogo.ImageLocation = ReadApp.GetValue("logoPath", typeof(string)).ToString() + hos.Logo;
        }

        private void Login()
        {
            LoginForm logFrm = new LoginForm();
            ShowForms(logFrm);

            if (logFrm.UsId != 0)
            {
                _userId = logFrm.UsId;
                ShowAccessLevel();
            }
            else //The login form is supposed to be displayed
            {
                ShowForms(logFrm);
                if (logFrm.UsId != 0)
                {
                    _userId = logFrm.UsId;
                    ShowAccessLevel();
                }
                else
                {
                    XtraMessageBox.Show("Please Try to login with the correct Username and Password!", "Application End",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
        }

        private static bool _isAdmin = false;

        /// <summary>
        /// Gets or sets the administrational rights of the presently logged in user
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                User usr = new User();
                usr.LoadByPrimaryKey(MainWindow.Instance.UserId);
                return (usr.UserType == 5);
            }
            private set { _isAdmin = value; }
        }

        public static int LoggedinId = 0;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Shows a modal form
        /// </summary>
        /// <param name="frm">The form that is going to be opened</param>
        public static void ShowForms(Form frm)
        {
            frm.BackColor = Color.FromArgb(221, 231, 253);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        /// <summary>
        /// Log out the presently logged in user
        /// </summary>
        private void LogOut()
        {
            _userId = 0;
            this.Hide();
            Login();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(e.Link.Item.Tag.ToString());
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens the chosen menu item based on its Tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMenuItem(object sender, EventArgs e)
        {
            if (((ToolStripItem)sender).Tag == null) return;

            string tag = (sender as ToolStripItem).Tag.ToString();
            LoadForm(tag);
        }

        private void mnuCheckForUpdates_Click(object sender, EventArgs e)
        {
            Program.UpdateApplication();
        }

        private void mnuRegistration_Click(object sender, EventArgs e)
        {
            PharmInventory.Forms.UtilitiesAndForms.Registrations reg = new Forms.UtilitiesAndForms.Registrations();
            reg.ShowDialog();
        }

        private void mnuDatabaseCleaning_Click(object sender, EventArgs e)
        {
            PharmInventory.Forms.Tools.DatabaseCleaning dbCleaning = new Forms.Tools.DatabaseCleaning();
            dbCleaning.ShowDialog();
        }

        private void bwAMCCalculator_DoWork(object sender, DoWorkEventArgs e)
        {
            statusStrip.Items[0].Text = "AMC calculation started for all stores.";
            HelperClasses.CalculateAMC calcAMC = new HelperClasses.CalculateAMC();
            calcAMC.BuildAMC();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (statusStrip.Items[0].Text == "AMC calculation started for all stores.")
            {
                MessageBox.Show(@"Automatic AMC calculation is in progress, please wait until it is completed. 
                    Check the bottom of the window for status update.", "HCMIS FE", MessageBoxButtons.OK);

                e.Cancel = true;
            }
        }

        private void bwAMCCalculator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusStrip.Items[0].Text = "AMC calculation completed for all stores.";
        }
    }
}
