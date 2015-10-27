using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PharmInventory.HelperClasses;
using PharmInventory.ViewModels;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.Transactions
{
    public partial class AMCView : DevExpress.XtraEditors.XtraForm
    {
        private readonly StoreRepository _storerepository = new StoreRepository();
        private readonly AmcReportRepository _amcReportRepository =new AmcReportRepository();

        public AMCView()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void loadamc()
        {          
            var allamcs = _amcReportRepository.AllAmcReport();
            gridControl1.DataSource = allamcs.Distinct().Where(m => m.StoreID == Convert.ToInt32(cboStores.EditValue)).OrderBy(m=>m.FullItemName);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "")
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void AMCView_Load(object sender, EventArgs e)
        {
            var allstores = _storerepository.AllStores();
            cboStores.Properties.DataSource = allstores;
            cboStores.ItemIndex = 0;

            var unitcolumn = ((GridView)gridControl1.MainView).Columns[9];

            if(VisibilitySetting.HandleUnits == 1)
            {
                unitcolumn.Visible = false;
            }
            else if (VisibilitySetting.HandleUnits == 2)
            {
                unitcolumn.Visible = true;
            }
            else if (VisibilitySetting.HandleUnits == 3)
            {
                unitcolumn.Visible = true;
            }
        }

        private void btnExportToEx_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("xls");
            gridControl1.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = _amcReportRepository.AllAmcReport().Where(m => m.StoreID == Convert.ToInt32(cboStores.EditValue));
        }      
    }
}