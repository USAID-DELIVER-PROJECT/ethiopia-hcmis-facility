using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Modals
{
    public partial class EditIssue : Form
    {
        readonly int _tranId = 0;

        public EditIssue()
        {
            InitializeComponent();
        }

        public EditIssue(int tId)
        {
            InitializeComponent();
            _tranId = tId;
        }

        private void EditIssue_Load(object sender, EventArgs e)
        {
            Stores str = new Stores();
            str.LoadAll();
            cboStores.DataSource = str.DefaultView;

            ReceivingUnits rUnit = new ReceivingUnits();
            rUnit.GetActiveDispensaries();
            cboReceivingUnit.DataSource = rUnit.DefaultView;

            if (_tranId != 0)
            {
                IssueDoc iss = new IssueDoc();
                Items itm = new Items();


                iss.LoadByPrimaryKey(_tranId);

                DataTable dtItm = itm.GetItemById(iss.ItemID);
                string itemName = dtItm.Rows[0]["ItemName"].ToString() + " - " + dtItm.Rows[0]["DosageForm"].ToString() + " - " + dtItm.Rows[0]["Strength"].ToString();

                txtRefNo.Text = iss.RefNo;
                txtBatchNo.Text = iss.BatchNo;
                try
                {
                    txtPack.Text = iss.NoOfPack.ToString();
                    txtQtyPack.Text = iss.QtyPerPack.ToString();
                    txtPrice.Text = (iss.Cost * iss.QtyPerPack).ToString();
                }
                catch
                {
                    txtPack.Text = "0";
                    txtQtyPack.Text = "0";
                    txtPrice.Text = (iss.Cost * 1).ToString();
                }
                txtQuantity.Text = iss.Quantity.ToString();
                DateTime dtDate = Convert.ToDateTime(iss.Date.ToString("MM/dd/yyyy"));
                txtDate.Text = dtDate.ToShortDateString();
                //dtIssDate.Value = DateTime.Now;
                //dtIssDate.CustomFormat = "MM/dd/yyyy";
                //DateTime dtCurrent = Convert.ToDateTime(dtIssDate.Text);

                //long tic = (DateTime.Now.Ticks - dtCurrent.Ticks);
                //DateTime dtIssG = dtDate.AddTicks(tic);

                //dtIssDate.Value = dtIssG;
                cboStores.SelectedValue = iss.StoreId;
                cboReceivingUnit.SelectedValue = iss.ReceivingUnitID;
                txtItemName.Text = itemName;
                txtReceivedBy.Text = iss.IssuedBy;
                txtRemark.Text = iss.Remark;
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string valid = ValidateFields();
            if (valid == "true")
            {
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IssueDoc iss = new IssueDoc();
                    ReceiveDoc rec = new ReceiveDoc();

                    iss.LoadByPrimaryKey(_tranId);

                    string batchNo = iss.BatchNo;
                    Int64 qty = iss.Quantity;
                    rec.GetTransactionByBatch(iss.ItemID, iss.BatchNo, iss.StoreId);

                    iss.RefNo = txtRefNo.Text;
                    iss.BatchNo = txtBatchNo.Text;
                    iss.NoOfPack = Convert.ToInt32(txtPack.Text);
                    iss.QtyPerPack = Convert.ToInt32(txtQtyPack.Text);
                    iss.Quantity = Convert.ToInt32(txtPack.Text) * Convert.ToInt32(txtQtyPack.Text);
                    iss.StoreId = Convert.ToInt32(cboStores.SelectedValue);
                    iss.ReceivingUnitID = Convert.ToInt32(cboReceivingUnit.SelectedValue);
                    iss.Remark = txtRemark.Text;
                    iss.IssuedBy = txtReceivedBy.Text;
                    iss.Save();

                    Int64 newQty = 0;
                    if(qty > iss.Quantity)
                        newQty = rec.QuantityLeft + (qty - iss.Quantity);
                    else
                        newQty = rec.QuantityLeft - (iss.Quantity - qty);

                    rec.QuantityLeft = newQty;
                    if(rec.QuantityLeft >0)
                        rec.Out = false;
                    rec.Save();

                    XtraMessageBox.Show("Transaction Succsfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

 
        }


        private string ValidateFields()
        {
            string valid = "true";
            if (_tranId == 0)
                valid = "This is not a valid Transaction!";
            else
            {
                if (txtRefNo.Text != "" && cboStores.SelectedValue != null && cboReceivingUnit.SelectedValue != null && txtDate.Text != "" && txtPack.Text != "" && txtQtyPack.Text != "")
                    valid = "true";
                else
                {
                    valid = "All * marked fields are required!";
                    return valid;
                }
                try
                {
                    int pk = Convert.ToInt32(txtPack.Text);
                    int qtPk = Convert.ToInt32(txtQtyPack.Text);
                }
                catch
                {
                    valid = "Both Pack & Qty/Pack should be a Valid Number!";
                }
            }


            return valid;
        }

        private void txtQtyPack_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyPack.Text != "" && txtPack.Text != "")
            {
                try
                {
                    txtQuantity.Text = (Convert.ToInt32(txtPack.Text) * Convert.ToInt32(txtQtyPack.Text)).ToString();
                }
                catch
                {
                    XtraMessageBox.Show("Pack & Qty Per Pack should be a Number!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dtIssDate.CustomFormat = "MM/dd/yyyy";
            txtDate.Text = dtIssDate.Text;
        }
    }
}