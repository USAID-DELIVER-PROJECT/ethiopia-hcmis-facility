using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    public partial class EditIssueDocRefrenceNo : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _refno;
        public EditIssueDocRefrenceNo()
        {
            InitializeComponent();
        }
        public EditIssueDocRefrenceNo(string refno)
        {
            InitializeComponent();
            _refno = refno;
        }

        private void EditIssueDocRefrenceNo_Load(object sender, EventArgs e)
        {
            dtRecDate.Value = DateTime.Now;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            if(_refno!=null)
            {
                var iss = new IssueDoc();
                iss.GetTransactionByRefNo(_refno);
                DateTime dtDate = Convert.ToDateTime(iss.Date.ToString("MM/dd/yyyy"));
                txtDate.Text = dtDate.ToShortDateString();
                txtRefNo.Text = iss.RefNo;
            }
        }

    
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var isd = new IssueDoc();
            DataTable dtbl = isd.GetTransactionByRefNo(_refno);
            if (isd.RowCount > 0)
            {
                foreach (DataRow datarow in dtbl.Rows)
                {
                    datarow["RefNo"] = txtRefNo.Text;
                    datarow["Date"] = txtDate.Text;
             
                }
                isd.Save();
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

        private void xpButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            txtDate.Text = dtRecDate.Text;
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }
    }
}