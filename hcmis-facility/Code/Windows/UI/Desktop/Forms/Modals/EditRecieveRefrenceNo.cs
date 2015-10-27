using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Modals
{
    public partial class EditRecieveRefrenceNo : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _refno;
        public EditRecieveRefrenceNo()
        {
            InitializeComponent();
        }
        public EditRecieveRefrenceNo(string refno)
        {
            InitializeComponent();
            _refno = refno;
        }
   
        private void EditRecieveRefrenceNo_Load(object sender, EventArgs e)
        {
            dtRecDate.Value = DateTime.Now;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            var rec = new ReceiveDoc();
            if(_refno!=null)
            {
                dtRecDate.ResetValue();
                rec.GetTransactionByRefNo(_refno);
                refnotextEdit.Text = rec.RefNo;
                DateTime dtDate = Convert.ToDateTime(rec.Date.ToString("MM/dd/yyyy"));
                txtDate.Text = dtDate.ToShortDateString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var rec = new ReceiveDoc();
            DataTable dtbl = rec.GetTransactionByRefNo(_refno);
            if (rec.RowCount > 0)
            {
                foreach (DataRow datarow in dtbl.Rows)
                {
                    datarow["RefNo"] = refnotextEdit.Text;
                    datarow["Date"] = txtDate.Text;
                }
                rec.Save();
                Close();
                XtraMessageBox.Show("Refrence No and Date is successfully updated", "Success");
            }

            else
            {
                XtraMessageBox.Show("There is no refrence to edit");
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