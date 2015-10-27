using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Modals
{
    public partial class EditLossAndAdjustment : DevExpress.XtraEditors.XtraForm
    {
        readonly string _refno;
        public EditLossAndAdjustment()
        {
            InitializeComponent();    
        }
        public EditLossAndAdjustment(string refno)
        {
            InitializeComponent();
            _refno = refno;
         
        }

        private void EditLossAndAdjustment_Load(object sender, EventArgs e)
        {
            dtRecDate.Value = DateTime.Now;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            var dis = new Disposal();
            if (_refno != null)
            {
                dis.GetTransactionByRefNo(_refno);
                txtRefNo.Text = dis.RefNo;
                DateTime dtDate = Convert.ToDateTime(dis.Date.ToString("MM/dd/yyyy"));
                txtDate.Text = dtDate.ToShortDateString();
                // dtLossDate.Value = dis.Date;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dis =new Disposal();
            var dtbl=dis.GetTransactionByRefNo(_refno);
                if (dis.RowCount > 0)
                {
                    foreach (DataRow datarow in dtbl.Rows)
                    {
                        datarow["RefNo"] = txtRefNo.Text;
                        datarow["Date"] = txtDate.Text;
                    }
                    dis.Save();
                    Close();
                    XtraMessageBox.Show("Refrence No and Date is successfully updated", "Success");
                }

                else
                {
                    XtraMessageBox.Show("There is no refrence no to edit");
                    return;
                }
                this.Close();
         }
        
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            txtDate.Text = dtRecDate.Text;
        }

      
    }
}