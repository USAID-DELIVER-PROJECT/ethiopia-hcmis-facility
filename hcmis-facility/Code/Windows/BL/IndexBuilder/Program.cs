using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IndexBuilder.cs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StockoutIndexBuilder.Settings.ConnectionString = @"Server=.\; Database=FE_DB; Integrated Security=true;";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BuildIndicesView());
        }
    }
}
