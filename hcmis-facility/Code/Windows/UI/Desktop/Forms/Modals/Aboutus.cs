using System;
using System.Windows.Forms;

namespace PharmInventory.Forms.Modals
{
    /// <summary>
    /// About Us Dialog Box
    /// </summary>
    public partial class Aboutus : Form
    {
        public Aboutus()
        {
            InitializeComponent();
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}