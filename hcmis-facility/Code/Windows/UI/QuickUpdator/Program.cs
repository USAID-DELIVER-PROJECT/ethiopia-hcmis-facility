using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConnectionStringManager;

namespace QuickUpdator
{
    static class Program
    {
        public const string RegKey = "Software\\JSI\\HCMIS\\Configuration";
        public const string PrevConnectionStringKey = "Software\\JSI\\HCMIS\\Configuration\\ConnectionStringManager\\History";

        
        public static ConnectionStringManager.ConnectionStringManager ConnectionManager;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString = System.Configuration.ConfigurationManager.AppSettings.Get("dbConnection");
            ConnectionManager = new ConnectionStringManager.ConnectionStringManager(RegKey, PrevConnectionStringKey);
            MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString = ConnectionManager.GetFromRegistry();
            Application.Run(new UpdatorForm());
        }
    }
}
