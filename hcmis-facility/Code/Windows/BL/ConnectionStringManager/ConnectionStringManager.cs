using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;
using DevExpress.XtraEditors;
using System.Data.Sql;

namespace ConnectionStringManager
{
    public partial class ConnectionStringManager : Form
    {
        public static string ConnRegistryKey { get; set; }

        public static string PrevConnRegistryKey { get; set; }

        private static string ConnString { get; set; }

        public ConnectionStringManager(string registryKey, string prevConnStringRegKey)
        {
            InitializeComponent();
            ConnRegistryKey = registryKey;
            PrevConnRegistryKey = prevConnStringRegKey;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(ConnRegistryKey);

            if (key != null)
            {
                try
                {
                    ConnString = key.GetValue("ConnectionString").ToString();
                }
                catch
                {
                    ConnString = "";
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = @"SQL Server Database Files |*.mdf";
            openFile.ShowDialog();
            if (openFile.CheckFileExists)
                txtDBPath.Text = openFile.FileName;

            GenerateConnectionString();
        }

        private void btnConnectionStringGenerate_Click(object sender, EventArgs e)
        {
            GenerateConnectionString();
        }

        private void GenerateConnectionString()
        {
            try
            {
                bool useInitialCatalog = chkUseInitialCatalog.Checked;
                string selectedServer = gridViewServers.GetFocusedDataRow()["ServerName"].ToString();
                string selectedInstance = gridViewServers.GetFocusedDataRow()["InstanceName"].ToString();
                string dataSource = selectedInstance == "" ? selectedServer : selectedServer + "\\" + selectedInstance;
                String connectionString;
                if (!useInitialCatalog)
                    connectionString = String.Format("Data Source={0};AttachDbFilename={1};Integrated Security=true;",
                                                     dataSource, txtDBPath.Text);
                else
                {
                    if (txtUid.Text != string.Empty && txtpwd.Text != string.Empty)
                    {
                        connectionString = String.Format("Data Source={0};Initial Catalog={1};uid={2};pwd={3};",
                                                         dataSource, txtCatalogName.Text, txtUid.Text, txtpwd.Text);
                    }
                    else
                    {
                        connectionString = String.Format(
                            "Data Source={0};Initial Catalog={1};Integrated Security=true;", dataSource,
                            txtCatalogName.Text);
                    }
                }

                txtConnectionString.Text = connectionString;
            }
            catch
            {
            }
        }

        public void SaveToRegistry(String connectionString)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(ConnRegistryKey);
            if (reg != null)
                reg.SetValue("ConnectionString", connectionString);
            SaveHistory(connectionString);
        }

        private void SaveHistory(string connectionString)
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(PrevConnRegistryKey);
            if (registryKey != null)
            {
                int i = registryKey.ValueCount;
                string valueName = "Conn" + i.ToString();
                registryKey.SetValue(valueName, connectionString);
            }
        }

        public string GetFromRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(ConnRegistryKey);
            if (key != null)
            {
                try
                {
                    ConnString = key.GetValue("ConnectionString").ToString();
                }
                catch
                {
                    ConnString = "";
                }
            }

            return ConnString;
        }

        public List<string> GetListFromRegistry()
        {
            List<string> connectionLists = new List<string>();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(PrevConnRegistryKey);
            if (key != null)
            {
                foreach (string keyName in key.GetValueNames())
                {
                    connectionLists.Add(key.GetValue(keyName).ToString());
                }
            }

            return connectionLists;
        }

        /// <summary>
        /// Returns the default connection string
        /// </summary>
        /// <returns></returns>
        public string GenerateDefaultConnectionString(string serverInstance, string dbFileName, bool useInitialCatalog)
        {
            if (!useInitialCatalog)
            {
                return @"Data Source=" + serverInstance + ";AttachDbFilename=" + dbFileName + ";Integrated Security=true;";
            }
            else
            {
                return @"Data Source=" + serverInstance + ";Initial Catalog=" + dbFileName + ";Integrated Security=true;";
            }
        }

        private void ConnectionStringManager_Load(object sender, EventArgs e)
        {
            lkPrevConnectionStrings.Properties.DataSource = GetPreviousConnectionStrings();
            string connString = GetFromRegistry();
            txtConnectionString.Text = connString;
            if (IsItInitialCatalog(connString))
            {
                chkUseInitialCatalog.Checked = true;
            }
            else
            {
                txtCatalogName.Enabled = false;
            }
        }

        private object GetPreviousConnectionStrings()
        {
            return GetListFromRegistry();
        }

        private bool IsItInitialCatalog(string connectionString)
        {
            if (connectionString == null)
                return false;
            return connectionString.IndexOf("Initial Catalog") != -1;
        }

        private static DataTable GetAListOfSqlServerInstances()
        {
            SqlDataSourceEnumerator enumerator = SqlDataSourceEnumerator.Instance;
            DataTable dtblServerInstances = enumerator.GetDataSources();
            return dtblServerInstances;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                DialogResult = XtraMessageBox.Show("Save to registry?", "Registry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    SaveToRegistry(txtConnectionString.Text);
                    if (XtraMessageBox.Show("Restart application?", "Connection String Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        Application.Restart();
                }
            }
        }

        private void chkUseInitialCatalog_CheckedChanged(object sender, EventArgs e)
        {
            bool useInitialCatalog = chkUseInitialCatalog.Checked;
            txtCatalogName.Enabled = useInitialCatalog;
            txtUid.Enabled = useInitialCatalog;
            txtpwd.Enabled = useInitialCatalog;
            btnBrowse.Enabled = !useInitialCatalog;

            lcCatalogName.Visibility = useInitialCatalog ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcUID.Visibility = useInitialCatalog ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcPassword.Visibility = useInitialCatalog ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void txtCatalogName_EditValueChanged(object sender, EventArgs e)
        {
            GenerateConnectionString();
        }

        private void txtUid_EditValueChanged(object sender, EventArgs e)
        {
            GenerateConnectionString();
        }

        private void txtpwd_EditValueChanged(object sender, EventArgs e)
        {
            GenerateConnectionString();
        }

        private void lkPrevConnectionStrings_EditValueChanged(object sender, EventArgs e)
        {
            if (lkPrevConnectionStrings.EditValue != null)
                txtConnectionString.Text = lkPrevConnectionStrings.EditValue.ToString();
        }

        private void btnSearchAvailableServers_Click(object sender, EventArgs e)
        {
            gridServers.DataSource = GetAListOfSqlServerInstances();
        }
    }
}