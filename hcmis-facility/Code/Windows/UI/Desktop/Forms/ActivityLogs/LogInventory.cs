using System;
using System.Data;
using System.Drawing;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.ActivityLogs
{
    /// <summary>
    /// Shows the log of inventory
    /// </summary>
    public partial class LogInventory : XtraForm
    {
        public LogInventory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the loookups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {

            var unitcolumn = ((GridView) gridInventory.MainView).Columns[7];
            unitcolumn.Visible = VisibilitySetting.HandleUnits != 1;
            var stor = new Stores();

            var unit = new ItemUnit();
            var allunit = unit.GetAllUnits();
            unitbindingSource.DataSource = allunit.DefaultView;

            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
        }

        private void PopulateDocument(DataTable dtRec)
        {
            grdRefYear.DataSource = dtRec;
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue == null) return;

            YearEnd yEnd = new YearEnd();
            DataTable dtRec = yEnd.GetDistinctYear(Convert.ToInt32(cboStores.SelectedValue));
            PopulateDocument(dtRec);

            dtRec = yEnd.GetDocumentAll(Convert.ToInt32(cboStores.SelectedValue));
            lblAdjDate.Text = @"All Years";
            if (dtRec.Rows.Count == 0)
            {
                txtEmpty.Visible = true;
                gridInventory.Visible = false;
            }
            else
            {
                gridInventory.Visible = true;
                gridInventory.DataSource = dtRec;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {            
            string fileName = MainWindow.GetNewFileName("xls");
            gridInventory.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);         
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            // old header 
            //string header = info.HospitalName + "Inventory Log of " + lblAdjDate.Text;

            //header with reference number  and date included
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
            {
                Value = DateTime.Now,
                CustomFormat = "MM/dd/yyyy"
            };
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            string header = info.HospitalName + "Inventory Log of " + lblAdjDate.Text + "    " + dtCurrent.ToString("MM dd,yyyy");
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString("", Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header, Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString("", Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetFocusedDataRow();
            if (dr == null) return;

            int year = Convert.ToInt32(dr["Year"]);
            YearEnd yEnd = new YearEnd();
            gridInventory.DataSource = yEnd.GetDocumentByYear(Convert.ToInt32(cboStores.SelectedValue), year);
        }
    }
}