using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;

namespace PharmInventory
{

    public partial class GeneralExpiryChart : Form
    {

        // System.Runtime.InteropServices.DllImportAttribute("gdi32.dll");
        private DateTime _dtCur;
        private System.IO.Stream streamToPrint;
        string streamType;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
        );

        DateTime dtCurrent = new DateTime();
        int curMont = 0;
        int curYear = 0;

        public GeneralExpiryChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            var type = new BLL.Type();
            DataTable alltypes = type.GetAllCategory();
            DataRow row = alltypes.NewRow();
            row["ID"] = "0";
            row["Name"] = "All";
            alltypes.Rows.InsertAt(row, 0);

            lkCategory.Properties.DataSource = alltypes;
            lkCategory.Properties.DisplayMember = "Name";
            lkCategory.Properties.ValueMember = "ID";
            lkCategory.ItemIndex = 0;

            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStor = stor.DefaultView.ToTable();
            DataRow rowStore = dtStor.NewRow();
            rowStore["ID"] = "0";
            rowStore["StoreName"] = "All";
            dtStor.Rows.InsertAt(rowStore, 0);

            cboStores.Properties.DataSource = dtStor;
            cboStores.ItemIndex = 0;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            curMont = dtCurrent.Month;
            curYear = dtCurrent.Year;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);

            cboYear.Properties.DataSource = Items.AllYears();
            cboYear.EditValue = curYear;
          }

        public void GenerateExpiryChart()
        {
            DateTime selectedStartedDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, 1, (int)cboYear.EditValue));
            DateTime selectedEndDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 30, 12, (int)cboYear.EditValue));

            dtFrom.Value = selectedStartedDate;
            dtTo.Value = selectedEndDate;

            // Generate the pie Chart for the Current SOH and EXpired Drugs
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            //string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            //layoutControlGroup3.Text = "Cost Report " + dRange;
            if (dt1.Year == dt2.Year)
            {
                dt1 = ((dt1.Month == 11 || dt1.Month == 12) ? new DateTime(dt1.Year, 11, 1) : new DateTime(dt1.Year - 1, 11, 1));
                //dRange = "For Year " + dt1.Year.ToString();
            }

            ReceiveDoc rec = new ReceiveDoc();
            Balance bal = new Balance();
            chartPie.Series.Clear();
            lstExpStatus.Items.Clear();
            Items itm = new Items();

            int storeId = Convert.ToInt32(cboStores.EditValue);
            int typeID = Convert.ToInt32(lkCategory.EditValue);
            //object[] objExp = itm.CountExpiredItemsAndAmount(storeId);
            
            object[] objExp = itm.CountExpiredItemsAndAmountByCategory(storeId,typeID ,dt1 ,dt2);
            Int64 expAmount = Convert.ToInt64(objExp[0]);
            Double expCost = Convert.ToDouble(objExp[1]);

           // object[] nearObj = itm.CountNearlyExpiredQtyAmount(storeId);
            object[] nearObj = itm.CountNearlyExpiredQtyAmountByCategory(storeId , typeID ,dt1 ,dt2);
            Int64 nearExpAmount = Convert.ToInt64(nearObj[0]);
            double nearExpCost = Convert.ToDouble(nearObj[1]);

           // object[] sohObj = itm.GetAllSOHQtyAmount(storeId);
            object[] sohObj = itm.GetAllSOHQtyAmountByCategory(storeId ,typeID ,dt1 ,dt2);
            Int64 soh = Convert.ToInt64(sohObj[0]);
            double sohPrice = Convert.ToDouble(sohObj[1]);

            Int64 normal = (soh - nearExpAmount - expAmount);
            Int64 nearExpiry = nearExpAmount;
            Int64 expired = expAmount;


            object[] obj = { normal, nearExpiry, expired };

            DataTable dtSOHList = new DataTable();
            dtSOHList.Columns.Add("Type");
            dtSOHList.Columns.Add("Value");
            dtSOHList.Columns[1].DataType = typeof(Int64);
            double normalPrice = (sohPrice - nearExpCost - expCost);

            Int64 totItm = normal + nearExpiry + expired;

            object[] oo = { "Normal : " + normalPrice.ToString("C"), obj[0] };
            dtSOHList.Rows.Add(oo);

            object[] oo3 = { "Expired : " + expCost.ToString("C"), obj[2] };
            dtSOHList.Rows.Add(oo3);

            object[] oo2 = { "Near Expiry : " + nearExpCost.ToString("C"), obj[1] };
            dtSOHList.Rows.Add(oo2);

            decimal per = Convert.ToDecimal(normal) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str = { "Normal", per.ToString() + "%", obj[0].ToString(), normalPrice.ToString("C") };
            ListViewItem lstItmNor = new ListViewItem(str);
            lstExpStatus.Items.Add(lstItmNor);

            per = Convert.ToDecimal(nearExpiry) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str1 = { "Near Expiry", per.ToString() + "%", obj[1].ToString(), nearExpCost.ToString("C") };
            ListViewItem lstItmNor1 = new ListViewItem(str1);
            lstExpStatus.Items.Add(lstItmNor1);

            per = Convert.ToDecimal(expired) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str2 = { "Expired", per.ToString() + "%", obj[2].ToString(), expCost.ToString("C") };
            ListViewItem lstItmNor2 = new ListViewItem(str2);
            lstExpStatus.Items.Add(lstItmNor2);

            Series serExpired = new Series("pie", ViewType.Pie3D);
            serExpired.DataSource = dtSOHList;

            serExpired.ArgumentScaleType = ScaleType.Qualitative;
            serExpired.ArgumentDataMember = "Type";
            serExpired.ValueScaleType = ScaleType.Numerical;
            serExpired.ValueDataMembers.AddRange(new string[] { "Value" });
            serExpired.PointOptions.PointView = PointView.ArgumentAndValues;
            serExpired.LegendText = "Key";
            serExpired.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            serExpired.PointOptions.ValueNumericOptions.Precision = 0;
            ((PieSeriesLabel)serExpired.Label).Position = PieSeriesLabelPosition.TwoColumns;
            // ((PieSeriesLabel)serExpired.Label).ColumnIndent = 2;
            ((PiePointOptions)serExpired.PointOptions).PointView = PointView.ArgumentAndValues;
            //((PiePointOptions)serExpired.PointOptions).Separator = " , ";
            chartPie.Series.Add(serExpired);
            chartPie.Size = new System.Drawing.Size(1000, 500);
        }

        public void GenerateExpiryChartForAllStores()
        {
            DateTime selectedStartedDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, 1, (int)cboYear.EditValue));
            DateTime selectedEndDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 30, 12, (int)cboYear.EditValue));

            dtFrom.Value = selectedStartedDate;
            dtTo.Value = selectedEndDate;

            // Generate the pie Chart for the Current SOH and EXpired Drugs
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            //string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            //layoutControlGroup3.Text = "Cost Report " + dRange;
            if (dt1.Year == dt2.Year)
            {
                dt1 = ((dt1.Month == 11 || dt1.Month == 12) ? new DateTime(dt1.Year, 11, 1) : new DateTime(dt1.Year - 1, 11, 1));
                //dRange = "For Year " + dt1.Year.ToString();
            }

            ReceiveDoc rec = new ReceiveDoc();
            Balance bal = new Balance();
            chartPie.Series.Clear();
            lstExpStatus.Items.Clear();
            Items itm = new Items();

            int typeID = Convert.ToInt32(lkCategory.EditValue);
            //object[] objExp = itm.CountExpiredItemsAndAmount(storeId);
            
            object[] objExp = itm.CountExpiredItemsAndAmountByCategoryForAllStores(typeID ,dt1 ,dt2);
            Int64 expAmount = Convert.ToInt64(objExp[0]);
            Double expCost = Convert.ToDouble(objExp[1]);

           // object[] nearObj = itm.CountNearlyExpiredQtyAmount(storeId);
            object[] nearObj = itm.CountNearlyExpiredQtyAmountByCategoryForAllStores(typeID ,dt1 ,dt2);
            Int64 nearExpAmount = Convert.ToInt64(nearObj[0]);
            double nearExpCost = Convert.ToDouble(nearObj[1]);

           // object[] sohObj = itm.GetAllSOHQtyAmount(storeId);
            object[] sohObj = itm.GetAllSOHQtyAmountByCategoryForAllStores(typeID ,dt1 ,dt2);
            Int64 soh = Convert.ToInt64(sohObj[0]);
            double sohPrice = Convert.ToDouble(sohObj[1]);

            Int64 normal = (soh - nearExpAmount - expAmount);
            Int64 nearExpiry = nearExpAmount;
            Int64 expired = expAmount;


            object[] obj = { normal, nearExpiry, expired };

            DataTable dtSOHList = new DataTable();
            dtSOHList.Columns.Add("Type");
            dtSOHList.Columns.Add("Value");
            dtSOHList.Columns[1].DataType = typeof(Int64);
            double normalPrice = (sohPrice - nearExpCost - expCost);

            Int64 totItm = normal + nearExpiry + expired;

            object[] oo = { "Normal : " + normalPrice.ToString("C"), obj[0] };
            dtSOHList.Rows.Add(oo);

            object[] oo3 = { "Expired : " + expCost.ToString("C"), obj[2] };
            dtSOHList.Rows.Add(oo3);

            object[] oo2 = { "Near Expiry : " + nearExpCost.ToString("C"), obj[1] };
            dtSOHList.Rows.Add(oo2);

            decimal per = Convert.ToDecimal(normal) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str = { "Normal", per.ToString() + "%", obj[0].ToString(), normalPrice.ToString("C") };
            ListViewItem lstItmNor = new ListViewItem(str);
            lstExpStatus.Items.Add(lstItmNor);

            per = Convert.ToDecimal(nearExpiry) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str1 = { "Near Expiry", per.ToString() + "%", obj[1].ToString(), nearExpCost.ToString("C") };
            ListViewItem lstItmNor1 = new ListViewItem(str1);
            lstExpStatus.Items.Add(lstItmNor1);

            per = Convert.ToDecimal(expired) / Convert.ToDecimal(totItm) * 100;
            per = Decimal.Round(per, 0);
            string[] str2 = { "Expired", per.ToString() + "%", obj[2].ToString(), expCost.ToString("C") };
            ListViewItem lstItmNor2 = new ListViewItem(str2);
            lstExpStatus.Items.Add(lstItmNor2);

            Series serExpired = new Series("pie", ViewType.Pie3D);
            serExpired.DataSource = dtSOHList;

            serExpired.ArgumentScaleType = ScaleType.Qualitative;
            serExpired.ArgumentDataMember = "Type";
            serExpired.ValueScaleType = ScaleType.Numerical;
            serExpired.ValueDataMembers.AddRange(new string[] { "Value" });
            serExpired.PointOptions.PointView = PointView.ArgumentAndValues;
            serExpired.LegendText = "Key";
            serExpired.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            serExpired.PointOptions.ValueNumericOptions.Precision = 0;
            ((PieSeriesLabel)serExpired.Label).Position = PieSeriesLabelPosition.TwoColumns;
            // ((PieSeriesLabel)serExpired.Label).ColumnIndent = 2;
            ((PiePointOptions)serExpired.PointOptions).PointView = PointView.ArgumentAndValues;
            //((PiePointOptions)serExpired.PointOptions).Separator = " , ";
            chartPie.Series.Add(serExpired);
            chartPie.Size = new System.Drawing.Size(1000, 500);
        }

        private void cboStores_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if ((cboStores.EditValue != null) && (cboYear.EditValue != null))
            {
                if (cboStores.ItemIndex == 0)
                {
                    GenerateExpiryChartForAllStores();
                }
                else
                {
                    GenerateExpiryChart();
                }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(this.streamToPrint);
            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;
            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            MyImage.Save(@"c:\PrintPage.jpg", ImageFormat.Jpeg);
            FileStream fileStream = new FileStream(@"c:\PrintPage.jpg", FileMode.Open, FileAccess.Read);
            StartPrint(fileStream, "Image");
            fileStream.Close();
            if (System.IO.File.Exists(@"c:\PrintPage.jpg"))
            {
                System.IO.File.Delete(@"c:\PrintPage.jpg");
            }
        }

        public void StartPrint(Stream streamToPrint, string streamType)
        {
            this.printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.streamToPrint = streamToPrint;
            this.streamType = streamType;
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
            PrintDialog1.ShowHelp = true;
            printDoc.DefaultPageSettings.Landscape = true;
            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;

            PrintDialog1.Document = printDoc;
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDoc.Print();
                //docToPrint.Print();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument(false);
            printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            printableComponentLink1.ShowPreview();           
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
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

            string[] header = { info.HospitalName, "General Expiry For Current Year", "From Start Date: " + strStartDate, "To End Date: " + strEndDate, "Printed Date: " + strCurrentDate };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(160, 40, 200, 100), BorderSide.None);
            TextBrick brick4 = e.Graph.DrawString(header[4], Color.DarkBlue, new RectangleF(0, 60, 200, 100), BorderSide.None);
           }

        private void cboYear_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                if (cboYear.EditValue != null)
                {
                    if (cboStores.ItemIndex == 0)
                    {
                        GenerateExpiryChartForAllStores();
                    }
                    else
                    {
                        GenerateExpiryChart();
                    }
                }
            }
        }        
    }
}
