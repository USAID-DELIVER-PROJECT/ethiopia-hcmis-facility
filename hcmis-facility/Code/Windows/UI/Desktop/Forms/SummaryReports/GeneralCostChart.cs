using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;

namespace PharmInventory
{
   
    public partial class GeneralCostChart : XtraForm
    {

        public GeneralCostChart()
        {
            InitializeComponent();
        }
DateTime dtCurrent = new DateTime();

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            Stores stor = new Stores();
            DataTable dtStor = stor.GetActiveStores();
            DataRow rowStore = dtStor.NewRow();
            rowStore["ID"] = "0";
            rowStore["StoreName"] = "All";
            dtStor.Rows.InsertAt(rowStore, 0);

            cboStores.Properties.DataSource = dtStor;
            cboStores.ItemIndex = 0;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            cboYear.Properties.DataSource = Items.AllYears();
            cboYear.EditValue = dtCurrent.Year;

            GeneratCostChartForAllStores();            
        }

        private void GeneratCostChartForAllStores()
        {
            DataTable dtList = new DataTable();

            DataTable dtCons = new DataTable();
            string[] co = { "Ham", "Neh", "Mes", "Tek", "Hed", "Tah", "Tir", "Yek", "Meg", "Miz", "Gen", "Sen" };
            dtList.Columns.Add("Month");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);
            dtCons.Columns.Add("Month");
            dtCons.Columns.Add("Value");
            dtCons.Columns[1].DataType = typeof(Int64);
            int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] cos = new double[12];
            DataTable dtBal = new DataTable();

            Items recd = new Items();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int year = (dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year + 1;
            int selectedYear = Convert.ToInt32(cboYear.EditValue);

            for (int i = 0; i < mon.Length; i++)
            {
                if (selectedYear == dtCurrent.Year)
                {
                    if (((mon[i] == 11 || mon[i] == 12) && (mon[i] <= dtCurrent.Month || year == dtCurrent.Year)) || (mon[i] < 11 && mon[i] <= dtCurrent.Month && year == dtCurrent.Year))
                    {
                        int yr = (mon[i] < 11) ? dtCurrent.Year : year;

                        double recVal = recd.GetCostReceiveByItemPerMonthForAllStores(mon[i], yr);
                        object[] objrec = { co[i], recVal };
                        double issVal = recd.GetCostIssuedByItemPerMonthForAllStores(mon[i], yr);
                        object[] objiss = { co[i], issVal };
                        dtList.Rows.Add(objrec);
                        dtCons.Rows.Add(objiss);
                    }
                }
                else
                {
                        int yr = (mon[i] < 11) ? selectedYear : selectedYear - 1 ;

                        double recVal = recd.GetCostReceiveByItemPerMonthForAllStores(mon[i], yr);
                        object[] objrec = { co[i], recVal };
                        double issVal = recd.GetCostIssuedByItemPerMonthForAllStores(mon[i], yr);
                        object[] objiss = { co[i], issVal };
                        dtList.Rows.Add(objrec);
                        dtCons.Rows.Add(objiss);
                }
            }
            chartReceiveCost.Series.Clear();
            Series ser = new Series("Received Cost In Birr", ViewType.Line) { DataSource = dtList, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "Month", ValueScaleType = ScaleType.Numerical };
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            // ser.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(ser);
            Series serIss = new Series("Issued Cost In Birr", ViewType.Line) { DataSource = dtCons, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "Month", ValueScaleType = ScaleType.Numerical };

            serIss.ValueDataMembers.AddRange(new string[] { "Value" });
            serIss.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            //serIss.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(serIss);

            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Precision = 0;
        }

        private void GeneratCostChart()
        {
            DataTable dtList = new DataTable();

            DataTable dtCons = new DataTable();
            string[] co = { "Ham", "Neh", "Mes", "Tek", "Hed", "Tah", "Tir", "Yek", "Meg", "Miz", "Gen", "Sen" };
            dtList.Columns.Add("Month");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);
            dtCons.Columns.Add("Month");
            dtCons.Columns.Add("Value");
            dtCons.Columns[1].DataType = typeof(Int64);
            int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] cos = new double[12];
            DataTable dtBal = new DataTable();

            Items recd = new Items();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int year = (dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year + 1;
            int selectedYear = Convert.ToInt32(cboYear.EditValue);
            int storeId = Convert.ToInt32(cboStores.EditValue);


            for (int i = 0; i < mon.Length; i++)
            {
                if (selectedYear == dtCurrent.Year)
                {
                    if (((mon[i] == 11 || mon[i] == 12) && (mon[i] <= dtCurrent.Month || year == dtCurrent.Year)) || (mon[i] < 11 && mon[i] <= dtCurrent.Month && year == dtCurrent.Year))
                    {
                        int yr = (mon[i] < 11) ? dtCurrent.Year : year;

                        double recVal = recd.GetCostReceiveByItemPerMonth(mon[i], storeId, yr);
                        object[] objrec = { co[i], recVal };
                        double issVal = recd.GetCostIssuedByItemPerMonth(mon[i], storeId, yr);
                        object[] objiss = { co[i], issVal };
                        dtList.Rows.Add(objrec);
                        dtCons.Rows.Add(objiss);
                    }
                }
                else
                {
                    int yr = (mon[i] < 11) ? selectedYear : selectedYear - 1;

                    double recVal = recd.GetCostReceiveByItemPerMonth(mon[i], storeId, yr);
                    object[] objrec = { co[i], recVal };
                    double issVal = recd.GetCostIssuedByItemPerMonth(mon[i], storeId, yr);
                    object[] objiss = { co[i], issVal };
                    dtList.Rows.Add(objrec);
                    dtCons.Rows.Add(objiss);
                }
            }
            chartReceiveCost.Series.Clear();
            Series ser = new Series("Received Cost In Birr", ViewType.Line) { DataSource = dtList, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "Month", ValueScaleType = ScaleType.Numerical };
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            // ser.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(ser);
            Series serIss = new Series("Issued Cost In Birr", ViewType.Line) { DataSource = dtCons, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "Month", ValueScaleType = ScaleType.Numerical };

            serIss.ValueDataMembers.AddRange(new string[] { "Value" });
            serIss.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            //serIss.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(serIss);

            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Precision = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += printableComponentLink1_CreateMarginalHeaderArea;
            printableComponentLink1.CreateDocument(false);
            printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            printableComponentLink1.ShowPreview();     
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();

            int year = Convert.ToInt32(cboYear.EditValue);
            int month = 10;
            int day = 30;
            if (year == dtCurrent.Year)
            {
                month = dtCurrent.Month;
                day = dtCurrent.Day;
            }

            DateTime startDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, 11, year - 1));
            DateTime endDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", day, month, year));
            DateTime currentDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", dtCurrent.Day, dtCurrent.Month, dtCurrent.Year));

            string strStartDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(startDate);
            string strEndDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(endDate);
            string strCurrentDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(currentDate);

            string[] header = { info.HospitalName, "Store: " + cboStores.Text, "From Start Date: " + strStartDate, "To End Date: " + strEndDate, "Printed Date: " + strCurrentDate };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;            

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(160, 40, 200, 100), BorderSide.None);
            TextBrick brick4 = e.Graph.DrawString(header[4], Color.DarkBlue, new RectangleF(0, 60, 200, 100), BorderSide.None);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.ItemIndex == 0)
            {
                GeneratCostChartForAllStores();
            }
            else
            {
                GeneratCostChart();
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(string.Format("Width:{0}, Height:{1}",this.Width,this.Height));
        }

        private void cboYear_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.ItemIndex == 0)
            {
                GeneratCostChartForAllStores();
            }
            else
            {
                GeneratCostChart();
            }
        }

    }
}