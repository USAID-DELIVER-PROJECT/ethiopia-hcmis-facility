using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace PharmInventory.Forms.Tools
{
    public partial class ConnectionStringGenerator : Form
    {
        public ConnectionStringGenerator()
        {
            InitializeComponent();
        }

        private void GetAListOfDatabaseFromTheLocalServer()
        {
            SqlConnection con = new SqlConnection("Server=127.0.0.1; Integrated Security=true");
            con.Open();

            SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_databases";

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dtbl = new DataTable();
            dtbl.Load(dr);

            lstDatabases.DataSource = dtbl;
            lstDatabases.ValueMember = "DATABASE_NAME";
            lstDatabases.DisplayMember = "DATABASE_NAME";
        }

        private void ConnectionStringGenerator_Load(object sender, EventArgs e)
        {
            GetAListOfSQLServerInstances();
            GetAListOfDatabaseFromTheLocalServer();
            
        }

        /// <summary>
        /// If we need to get the list of server instances as well, we can use the following function.  But right now
        /// the assumption is that the server is running 
        /// </summary>
        private void GetAListOfSQLServerInstances()
        {
            
            SqlDataSourceEnumerator enumerator = SqlDataSourceEnumerator.Instance;
            DataTable dtblServerInstances = enumerator.GetDataSources();
            cboServers.Properties.DataSource = dtblServerInstances;
            cboServers.Properties.ValueMember = "Server Name";
            cboServers.Properties.DisplayMember = "Server Name";
            //cboServers.Properties.DisplayMember = dtblServerInstances.Columns["Server Name"].ColumnName + " " + dtblServerInstances.Columns["Instance Name"].ColumnName;//"[Server Name] " + " [Instance Name]";
        }

        private void btnGetServerInstances_Click(object sender, EventArgs e)
        {
            String connectionString = String.Format("Data Source={0}; Initial Catalog = {1}; Integrated Security=true", ".", lstDatabases.SelectedValue.ToString());
            XtraMessageBox.Show(connectionString);
            if (cboServers.EditValue != null)
            {
                string serverName = cboServers.EditValue.ToString();
                XtraMessageBox.Show(serverName);
            }

            DialogResult=XtraMessageBox.Show("Save to registry?","Registry",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
                SaveToRegistry(connectionString);
        }

        private void SaveToRegistry(String connectionString)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey("Software\\JSI\\HCMIS\\Configuration");
            reg.SetValue("ConnectionString", connectionString);
        }

        private void cboServers_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}