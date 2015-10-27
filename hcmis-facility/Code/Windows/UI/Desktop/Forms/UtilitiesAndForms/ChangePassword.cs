using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory
{
    public partial class ChangePassword : XtraForm
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        #region Members
        int userId = 0;

        #endregion
        public ChangePassword(int usId)
        {
            InitializeComponent();
            userId = usId;
        }

        /// <summary>
        /// Saves the password change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton18_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                var us = new User();
                if (userId != 0)
                {
                    us.LoadByPrimaryKey(userId);
                    if (us.UserName != "admin")
                    {
                        XtraMessageBox.Show("You have no administative privilage to change password!", "Warning");
                        return;
                    }
                    if (us.Password == txtOldPass.Text)
                        {
                            us.Password = txtPassword.Text;
                            us.Save();
                            XtraMessageBox.Show("The password have been changed!", "Succcess");
                        }
                        else
                        {
                            XtraMessageBox.Show("Old Password is not correct!", "Invaild Password", MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                        }
                    
                }
            }
            else
            {
                XtraMessageBox.Show("Password doesnt match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton17_Click(object sender, EventArgs e)
        {
            txtOldPass.Text = "";
            txtConfirm.Text = "";
            txtPassword.Text = "";
        }
    }
}