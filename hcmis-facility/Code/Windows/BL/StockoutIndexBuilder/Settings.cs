using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder
{
    public class Settings
    {        
        private static string _connectionString = "";

        public static string ConnectionString 
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
}
