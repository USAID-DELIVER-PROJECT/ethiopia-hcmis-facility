using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Modals
{
    /// <summary>
    /// Interaction logic for EditReceive Form
    /// </summary>
    public partial class EditReceive : Form
    {
        readonly int _tranId = 0;
        
        public EditReceive()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form with transaction id and with partial or full edit previleges.
        /// </summary>
        /// <param name="tId">The Receive ID</param>
        /// <param name="allowOnlyPartialEdit">True to allow only partial edit</param>
        public EditReceive(int tId,bool allowOnlyPartialEdit)
        {
           
            InitializeComponent();
            _tranId = tId;
                        
            if (allowOnlyPartialEdit)
            {
                cboStores.Enabled = false;
                txtPack.Properties.ReadOnly = true;
                txtQtyPack.Properties.ReadOnly = true;
                txtQuantity.Properties.ReadOnly = true;
                txtReceivedBy.Properties.ReadOnly = true;
            }
            //var itemunit = new ItemUnit();
            //var units = itemunit.GetAllUnits();
           
            //itemUnitBindingSource.DataSource = units.DefaultView;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load the lookups and Prepare the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditReceive_Load(object sender, EventArgs e)
        {
            lkItemUnit.Enabled = VisibilitySetting.HandleUnits != 1;
            var str = new Stores();
            str.LoadAll();
            cboStores.DataSource = str.DefaultView;

            var sup = new Supplier();
            sup.GetActiveSuppliers();
            cboSupplier.DataSource = sup.DefaultView;

            if(_tranId != 0)
            {
                var rec = new ReceiveDoc();
                var itm = new Items();

                
                rec.LoadByPrimaryKey(_tranId);
                
                var dtItm = itm.GetItemById(rec.ItemID);

                var units = new ItemUnit();
                var unit = units.LoadFromSQl(rec.ItemID);
                lkItemUnit.Properties.DataSource = unit;
                lkItemUnit.Properties.DisplayMember = "Text";
                lkItemUnit.Properties.ValueMember = "ID";

                var programs = new Programs();
                var allprograms = programs.GetSubPrograms();
                lkPrograms.Properties.DataSource = allprograms;
                lkPrograms.Properties.ValueMember = "ID";
                lkPrograms.Properties.DisplayMember = "Name";

                string itemName = dtItm.Rows[0]["ItemName"].ToString() + " - " + dtItm.Rows[0]["DosageForm"].ToString() + " - " + dtItm.Rows[0]["Strength"].ToString();

                txtRefNo.Text = rec.RefNo;
                txtBatchNo.Text = rec.BatchNo;
                try
                {
                    txtPack.Text = rec.NoOfPack.ToString();
                    txtQtyPack.Text =rec.QtyPerPack.ToString();
                    txtPrice.Text = (rec.Cost * rec.QtyPerPack).ToString();
                    //txtQuantityLeft.Text = rec.QuantityLeft.ToString();
                }
                catch
                {
                    txtPack.Text = "0";
                    txtQtyPack.Text = "0";
                    txtPrice.Text = (rec.Cost * 1).ToString();
                }
                txtQuantity.Text = rec.Quantity.ToString();
                lkPrograms.EditValue = rec.SubProgramID;
                DateTime dtDate = Convert.ToDateTime(rec.Date.ToString("MM/dd/yyyy"));
                txtDate.Text = dtDate.ToShortDateString();
                dtRecDate.Value = DateTime.Now;
                dtRecDate.CustomFormat = "MM/dd/yyyy";
                if (!rec.IsColumnNull("ExpDate"))
                    dtExpiryDate.Value = rec.ExpDate;
                cboStores.SelectedValue = rec.StoreID;
                cboSupplier.SelectedValue = rec.SupplierID;

                if (!rec.IsColumnNull("UnitID"))
                    lkItemUnit.EditValue = rec.UnitID;
                txtItemName.Text = itemName;
                txtReceivedBy.Text = rec.ReceivedBy;
                txtRemark.Text = rec.Remark;
                
            }
        }

        /// <summary>
        /// Calculates the quantity based on the amount of packs and quantity per pack supplied
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQtyPack_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyPack.Text != "" && txtPack.Text != "")
            {
                try
                {
                    txtQuantity.Text = (Convert.ToInt32(txtPack.Text) * Convert.ToInt32(txtQtyPack.Text)).ToString();
                    //txtQuantityLeft.Text = (Convert.ToInt32(txtPack.Text)*Convert.ToInt32(txtQtyPack.Text)).ToString();
                }
                catch
                {
                    XtraMessageBox.Show("Pack & Qty Per Pack should be a Number!");
                }
            }
        }

        /// <summary>
        /// Performs validation of form items.
        /// </summary>
        /// <returns>String value indicating the error is returned.  If the form items are all valid, a string value of "true" is returned.</returns>
        private string ValidateFields()
        {
          
            string valid = "true";
            if (_tranId == 0)
                valid = "This is not a valid Transaction!";
            else
            {
                //if (txtRefNo.Text != "" && cboStores.SelectedValue != null && cboSupplier.SelectedValue != null && txtDate.Text != "" && txtBatchNo.Text != "" && txtPack.Text != "" && txtQtyPack.Text != "")
                if (txtRefNo.Text != "" && cboStores.SelectedValue != null && cboSupplier.SelectedValue != null  && txtPack.Text != "" && txtQtyPack.Text != "")
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

                try
                {
                    double price = Convert.ToDouble(txtPrice.Text);
                }
                catch
                {
                    valid = "Price should be a Valid Number!";
                }
            }

            return valid;
        }

        /// <summary>
        /// After doing validation, the receive information is saved to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string valid = ValidateFields();
            if ( valid == "true")
            {
                if (XtraMessageBox.Show("Are You Sure, You want to save this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ReceiveDoc rec = new ReceiveDoc();
                    IssueDoc iss =new IssueDoc();
                    ProgramProduct pp = new ProgramProduct();
                    rec.LoadByPrimaryKey(_tranId);
                    iss.GetIssueByBatchAndId(rec.ItemID, rec.BatchNo, rec.ID);
                    rec.RefNo = txtRefNo.Text;
                    int previousprogid = rec.SubProgramID;
                    dtRecDate.CustomFormat = "MM/dd/yyyy";
                     string dtValid  = "";
                    try
                     {
                         rec.Date = Convert.ToDateTime(txtDate.Text);
                     }
                     catch
                     {
                         string year = "";
                         if (Convert.ToInt32(txtDate.Text.Substring(0, 2)) == 13)
                         {
                             dtValid = txtDate.Text;
                             year = dtValid.Substring(dtValid.Length - 4, 4);
                             rec.Date = Convert.ToDateTime("12/30/" + year);
                         }
                         else if (Convert.ToInt32(txtDate.Text.Substring(0, 2)) == 2)
                         {
                             dtValid = txtDate.Text;
                             year = dtValid.Substring(dtValid.Length - 4, 4);
                             rec.Date = Convert.ToDateTime("2/28/" + year);
                         }
                     }
                    if ((iss.RowCount != 0) && (iss.RecievDocID != null && iss.RecievDocID == rec.ID))
                        {
                            rec.BatchNo = txtBatchNo.Text;
                            rec.ExpDate = dtExpiryDate.Value;
                            rec.Remark = txtRemark.Text;
                            rec.ReceivedBy = txtReceivedBy.Text;
                            rec.SupplierID = Convert.ToInt32(cboSupplier.SelectedValue);
                            rec.UnitID = VisibilitySetting.HandleUnits==1 ? 0 : Convert.ToInt32(lkItemUnit.EditValue);
                            rec.StoreID = Convert.ToInt32(cboStores.SelectedValue);
                            pp.LoadByNewProgramIdAndItemId(Convert.ToInt32(rec.ItemID), Convert.ToInt32(lkPrograms.EditValue));
                            if (pp.RowCount == 1)
                            {
                                rec.SubProgramID = Convert.ToInt32(lkPrograms.EditValue);
                                pp.ProgramID = Convert.ToInt32(lkPrograms.EditValue);
                                pp.ItemID = Convert.ToInt32(rec.ItemID);
                                pp.Save();

                            }
                            else if (pp.RowCount == 0)
                            {
                                rec.SubProgramID = Convert.ToInt32(lkPrograms.EditValue);
                                pp.AddNew();
                                pp.ProgramID = rec.SubProgramID;
                                pp.ItemID = Convert.ToInt32(rec.ItemID);
                                pp.Save();
                            }
                            rec.Out = false;
                            rec.Save();
                            XtraMessageBox.Show("Transaction Succsfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    else if (iss.RowCount == 0)
                    {
                        rec.BatchNo = txtBatchNo.Text;
                        rec.ExpDate = dtExpiryDate.Value;
                        rec.Remark = txtRemark.Text;
                        rec.ReceivedBy = txtReceivedBy.Text;
                        rec.NoOfPack = Convert.ToInt32(txtPack.Text);
                        rec.QtyPerPack = Convert.ToInt32(txtQtyPack.Text);
                        rec.Quantity = Convert.ToInt32(txtPack.Text) * Convert.ToInt32(txtQtyPack.Text);
                        rec.QuantityLeft = Convert.ToInt32(txtPack.Text) * Convert.ToInt32(txtQtyPack.Text);
                        rec.Out = false;
                        rec.StoreID = Convert.ToInt32(cboStores.SelectedValue);
                        rec.SupplierID = Convert.ToInt32(cboSupplier.SelectedValue);
                        rec.UnitID = VisibilitySetting.HandleUnits == 1 ? 0 : Convert.ToInt32(lkItemUnit.EditValue);
                        pp.LoadByNewProgramIdAndItemId(Convert.ToInt32(rec.ItemID), previousprogid);
                        if (pp.RowCount == 1)
                        {
                            rec.SubProgramID = Convert.ToInt32(lkPrograms.EditValue);
                            pp.ProgramID = Convert.ToInt32(lkPrograms.EditValue);
                            pp.ItemID = Convert.ToInt32(rec.ItemID);
                            pp.Save();

                        }
                        else if(pp.RowCount ==0)
                        {
                            rec.SubProgramID = Convert.ToInt32(lkPrograms.EditValue);
                            pp.AddNew();
                            pp.ProgramID = rec.SubProgramID;
                            pp.ItemID = Convert.ToInt32(rec.ItemID);
                            pp.Save();
                        }
                        rec.Cost = Convert.ToDouble(txtPrice.Text) / Convert.ToDouble(txtQtyPack.Text);
                        rec.Save();
                        XtraMessageBox.Show("Transaction Succsfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                   
                    
                }
            }
            else
            {
                XtraMessageBox.Show(valid, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = true;

        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            txtDate.Text = dtRecDate.Text;
        }
    }
}