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
    public partial class NewBatch : DevExpress.XtraEditors.XtraForm
    {
        private readonly int _itemid;
        private readonly string _itemname;
        private readonly int _unitid;
        private readonly int _storeid;
        private readonly DateTime _date;

        public NewBatch()
        {
            InitializeComponent();
        }

        public NewBatch(int itemid, string itemname, int unitid, int storeid ,DateTime _dtcurrent)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            _itemid = itemid;
            _itemname = itemname;
            _unitid = unitid;
            _storeid = storeid;
            _date = _dtcurrent;
        }

        public NewBatch(int itemid, string itemname, int storeid, DateTime _dtcurrent)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            _itemid = itemid;
            _itemname = itemname;
            _storeid = storeid;
            _date = _dtcurrent;
        }
        private void NewBatch_Load(object sender, EventArgs e)
        {
            txtItemName.Text = _itemname;
        }


        private void BtnAddBatchClick(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            var rec = new ReceiveDoc();
            var yEnd = new YearEnd();

            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                        rec.AddNew();
                        rec.ItemID = _itemid;
                        rec.BatchNo = txtBatchNo.Text;
                        rec.StoreID = _storeid;
                        rec.ExpDate = (DateTime) dateEditExpiryDate.EditValue;
                        rec.Date = _date;
                        rec.UnitID = 0;
                        rec.RefNo = txtRefNo.Text;
                        rec.Out = false;
                        rec.EurDate = DateTime.Now.Subtract(TimeSpan.FromDays(35));
                        rec.NoOfPack = Convert.ToInt32(txtPackQty.Text);
                        rec.QtyPerPack = Convert.ToInt32(txtQtyPerPack.Text);
                        rec.Quantity = (Convert.ToInt32(txtPackQty.Text))*(Convert.ToInt32(txtQtyPerPack.Text));
                        rec.QuantityLeft = (Convert.ToInt32(txtPackQty.Text))*(Convert.ToInt32(txtQtyPerPack.Text));
                        rec.Cost = Convert.ToDouble(txtPrice.Text);
                        rec.Save();

                        yEnd.AddNew();
                        yEnd.ItemID = _itemid;
                        yEnd.StoreID = _storeid;
                        yEnd.Year = _date.Year;
                        yEnd.AutomaticallyEntered = true;
                        yEnd.BBalance = 0;
                        yEnd.EBalance = 0;
                        yEnd.Save();


                    }
                    break;
                default:
                    {
                        rec.AddNew();
                        rec.ItemID = _itemid;
                        rec.BatchNo = txtBatchNo.Text;
                        rec.StoreID = _storeid;
                        rec.UnitID = _unitid;
                        rec.ExpDate = (DateTime) dateEditExpiryDate.EditValue;
                        rec.NoOfPack = Convert.ToInt32(txtPackQty.Text);
                        rec.Quantity = Convert.ToInt32(txtPackQty.Text);
                        rec.QuantityLeft = Convert.ToInt32(txtPackQty.Text);
                        rec.QtyPerPack = Convert.ToInt32(txtQtyPerPack.Text);
                        rec.Date = _date;
                        rec.RefNo = txtRefNo.Text;
                        rec.Out = false;
                        rec.EurDate = DateTime.Now.Subtract(TimeSpan.FromDays(35));
                        rec.Cost = Convert.ToDouble(txtPrice.Text);
                        rec.Save();

                        yEnd.AddNew();
                        yEnd.ItemID = _itemid;
                        yEnd.StoreID = _storeid;
                        yEnd.UnitID = _unitid;
                        yEnd.AutomaticallyEntered = true;
                        yEnd.BBalance = 0;
                        yEnd.EBalance = 0;
                        yEnd.Save();
                    }
                    break;
            }
            XtraMessageBox.Show("New Batch successfully added.", "Success");
            Close();
        }

        private void txtPackQty_TextChanged(object sender, EventArgs e)
        {
            if(txtPackQty.Text !=null && VisibilitySetting.HandleUnits!=1)
            {
                txtQtyPerPack.Text = 1.ToString();
            }
        }
    }
}