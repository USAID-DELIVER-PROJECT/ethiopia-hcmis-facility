using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using BLL;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PharmInventory.HelperClasses
{
    public static class DatabaseHelpers
    {
        public static string GetConnectionString()
        {
            RegistryKey connStringKey = Registry.CurrentUser.OpenSubKey(Program.RegKey);// "Software\\JSI\\HCMIS\\Configuration");
            string connString = connStringKey.GetValue("ConnectionString").ToString();
            return connString;
        }

        public static string GetDBAutoBackupPath()
        {
            RegistryKey configKey = Registry.CurrentUser.OpenSubKey(Program.RegKey, true);
            // @"C:\Databases\FE\
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            string folderPath = "";
            try
            {
                folderPath = configKey.GetValue("AutoBackupFolder").ToString();
            }
            catch {
                configKey.SetValue("AutoBackupFolder", appPath);
                configKey.Close();
                folderPath = "C:\\Databases\\FE\\";
                }
            return folderPath;
        }

        /// <summary>
        /// Looks to see if auto backup is enabled.
        /// </summary>
        /// <returns></returns>
        public static bool GetIsAutoBackupEnabled()
        {
            RegistryKey autoBackupKey = Registry.CurrentUser.OpenSubKey(Program.RegKey);
            bool isAutoBackupEnabled = bool.Parse(autoBackupKey.GetValue("AutoBackupEnabled", false).ToString());
            return isAutoBackupEnabled;
        }

        /// <summary>
        /// Gets the autobackup frequency from the registry.
        /// </summary>
        /// <returns></returns>
        public static string GetAutoBackupFrequency()
        {
            RegistryKey autoBackupKey = Registry.CurrentUser.OpenSubKey(Program.RegKey);
            string autoBackupFrequency = autoBackupKey.GetValue("AutoBackupFrequency").ToString();
            return autoBackupFrequency;
        }

        /// <summary>
        /// Gets the autobackup frequency in days.
        /// </summary>
        /// <returns></returns>
        private static int GetAutoBackupFrequencyInDays()
        {
            string frequencyString = GetAutoBackupFrequency();

            if(frequencyString=="Daily")
                return 1;
            else if(frequencyString=="Twice a Week")
                return 3;
            else if (frequencyString=="Weekly")
                return 7;
            else if (frequencyString=="Twice a Month")
                return 15;
            else if (frequencyString=="Monthly")
                return 30;

            return 7;
        }
        
        /// <summary>
        /// Checks if automatic backup should be performed on the presently attached database.
        /// </summary>
        /// <returns></returns>
        private static bool ShouldAutoBackupBePerformed()
        {
            if (GetIsAutoBackupEnabled())
            {                
                GeneralInfo dbInfo = new GeneralInfo();
                dbInfo.LoadAll();
                TimeSpan spanAfterBackup = DateTime.Now.Subtract(dbInfo.LastBackUp);
                int daysSinceBackup = spanAfterBackup.Days;
                if (daysSinceBackup >= GetAutoBackupFrequencyInDays())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Takes the database backup path from the registry
        /// </summary>
        private static void BackUpDatabase()
        {

            try
            {
                GeneralInfo info = new GeneralInfo();
                info.LoadAll();
                
                string path = GetDBAutoBackupPath() + "\\" + info.HospitalName + "PharmaInventory" + DateTime.Now.ToString("MMMddyyyy") + ".bak";

                string connectionString = PharmInventory.HelperClasses.DatabaseHelpers.GetConnectionString();

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
                System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();

                if (!(conn.State == ConnectionState.Open))
                    conn.Open();
                string dbName = conn.Database;
                com.CommandText = "BACKUP DATABASE [" + dbName + "] TO  DISK = N'" + path + "' WITH NOFORMAT, NOINIT,  NAME = N'PharmaInventory" + DateTime.Now.ToString("MMMddyyyy") + "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                com.Connection = conn;
                com.ExecuteNonQuery();
                info.LoadAll();
                info.LastBackUp = DateTime.Now;
                info.Save();
                XtraMessageBox.Show("Backup completed to " + path + "!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                XtraMessageBox.Show("Backup has failed! Please Try Again.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// If the autobackup is enabled and the day has passed that the db should be backed up, this performs a backup of the database
        /// </summary>
        public static void AutoBackupDatabase()
        {
            if (ShouldAutoBackupBePerformed())
            {
                BackUpDatabase();
            }
        }

        public static bool AutoBackUp()
        {
            
                try
                {
                    GeneralInfo info = new GeneralInfo();
                    info.LoadAll();

                    string path = GetDBAutoBackupPath() + "\\" + info.HospitalName + "PharmaInventory" + DateTime.Now.ToString("MMMddyyyy") + ".bak";

                    string connectionString = "";

                    try
                    {
                        connectionString = Program.ConnStringManager.GetFromRegistry();
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
                    com.CommandText = "BACKUP DATABASE [" + dbName + "] TO  DISK = N'" + path + "' WITH NOFORMAT, NOINIT,  NAME = N'PharmaInventory" + DateTime.Now.ToString("MMMddyyyy") + "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    com.Connection = conn;
                    com.ExecuteNonQuery();
                    info.LoadAll();
                    info.LastBackUp = DateTime.Now;
                    info.Save();
                   // XtraMessageBox.Show("Backup completed to " + path + "!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch(Exception ex)
                {
                    //XtraMessageBox.Show("Auto Backup has failed! Backup the database manually.", "Backup the database manually", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
        }


        public static void FixInconsistencies()
        {
            Balance.GetAndFixInventoryInconsistencies();
            Balance.GetAndFixLossAdjustmentInconsistencies();            
        }

        public static void RunScriptsOnDatabase()
        {
            string scriptDirectory = Application.StartupPath + "\\Scripts";
            string sqlConnectionString = Program.ConnStringManager.GetFromRegistry();
            DirectoryInfo di = new DirectoryInfo(scriptDirectory);
            FileInfo[] rgFiles = di.GetFiles("*.sql");
            foreach (FileInfo fi in rgFiles)
            {                                
                SqlConnection connection = new SqlConnection(sqlConnectionString);
                ExecuteSqlOnDatabase(connection, fi.FullName);
            }
        }

        private static void ExecuteSqlOnDatabase(SqlConnection connection, string sqlFile)
        {
            string sql = "";

            using (FileStream strm = File.OpenRead(sqlFile))
            {
                StreamReader reader = new StreamReader(strm);
                sql = reader.ReadToEnd();
            }

            Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(sql);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlTransaction transaction = connection.BeginTransaction();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;

                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        cmd.CommandText = line;
                        cmd.CommandType = CommandType.Text;

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            return;
                            //throw;
                        }
                    }
                }
            }

            transaction.Commit();
        }



    }
}