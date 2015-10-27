using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PharmInventory.Forms.Tools
{
    public partial class DatabaseCleaning : Form
    {
        public DatabaseCleaning()
        {
            InitializeComponent();
        }

        private void ItemCleaning_Load(object sender, EventArgs e)
        {
            BLL.Items itm = new BLL.Items();
            grdItems.DataSource = itm.GetAllItem();
        }

        

    }
}
