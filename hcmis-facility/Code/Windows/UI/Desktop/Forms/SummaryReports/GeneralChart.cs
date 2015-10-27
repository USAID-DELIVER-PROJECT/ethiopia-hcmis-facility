using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;

namespace PharmInventory
{

    public partial class GeneralChart : XtraForm
    {

        public GeneralChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStor = stor.DefaultView.ToTable();
            DataRow rowStore = dtStor.NewRow();
            rowStore["ID"] = "0";
            rowStore["StoreName"] = "All";
            dtStor.Rows.InsertAt(rowStore, 0);
            cboStores.Properties.DataSource = dtStor;

            if (stor.RowCount > 1)
                cboStores.ItemIndex = 0;

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

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            curMont = dtCurrent.Month;
            curYear = dtCurrent.Year;

            cboYear.Properties.DataSource = Items.AllYears();
            cboYear.EditValue = dtCurrent.Year;
            if (cboYear.Properties.Columns.Count > 0)
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
        }

        private DateTime dtCurrent = new DateTime();
        private int curMont = 0;
        private int curYear = 0;

        private void GenerateStockStatusPieChart()
        {
            ReceiveDoc rec = new ReceiveDoc();

            chartPie.UseWaitCursor = true;
            chartPie.Series.Clear();
            int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 0;
            curYear = Convert.ToInt32(cboYear.EditValue);

            var category = Convert.ToInt32(lkCategory.EditValue);
            curMont = (curYear == dtCurrent.Year) ? dtCurrent.Month : 12;
            //progressBar1.PerformStep();
            Balance bal = new Balance();
            Int64 stockin = bal.CountStockInByCategory(storeId, curMont, curYear ,category );
            // progressBar1.PerformStep();
            Int64 stockout = bal.CountStockOutByCategory(storeId, curMont, curYear, category);
            // progressBar1.PerformStep();
            Int64 overstock = bal.CountOverStockByCategory(storeId, curMont, curYear, category);
            // progressBar1.PerformStep();
            Int64 nearEOP = bal.CountNearEOPByCategory(storeId, curMont, curYear, category);
            // progressBar1.PerformStep();
            Int64 BelowEOP = bal.CountBelowEOPByCategory(storeId, curMont, curYear, category);

            object[] obj = {stockin, stockout, overstock, nearEOP, BelowEOP};

            DataTable dtList = new DataTable();
            dtList.Columns.Add("Type");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof (Int64);

            object[] oo = {"In Stock", obj[0]};
            dtList.Rows.Add(oo);

            object[] oo2 = {"Stock Out", obj[1]};
            dtList.Rows.Add(oo2);

            object[] oo3 = {"Over Stock", obj[2]};
            dtList.Rows.Add(oo3);

            object[] oo4 = {"Near EOP", obj[3]};
            dtList.Rows.Add(oo4);

            object[] oo5 = {"Below EOP", obj[4]};
            dtList.Rows.Add(oo5);

            Series ser = new Series("pie", ViewType.Pie3D);
            ser.DataSource = dtList;

            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Type";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] {"Value"});
            ser.PointOptions.PointView = PointView.ArgumentAndValues;
            ser.LegendText = "Key";
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            ser.PointOptions.ValueNumericOptions.Precision = 0;

            ((PieSeriesLabel) ser.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions) ser.PointOptions).PointView = PointView.ArgumentAndValues;

            chartPie.Series.Add(ser);
            chartPie.Size = new System.Drawing.Size(1000, 500);
            //progressBar1.PerformStep();
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();

            lblHeader.Text = info.HospitalName + " Stock Status summary of year " + curYear + " of " + cboStores.Text;
            // progressBar1.Visible = false;
            chartPie.UseWaitCursor = false;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void cboStores_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && cboYear.EditValue != null && lkCategory.EditValue != null && ckExclude.Checked)
            {
                PopulateSStatusReport();
            }
            if (cboStores.EditValue != null && cboYear.EditValue != null && lkCategory.EditValue != null && !ckExclude.Checked)
            {
                GenerateStockStatusPieChart();
            }
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && cboYear.EditValue != null && lkCategory.EditValue != null && ckExclude.Checked)
            {
                PopulateSStatusReport();
            }

            if (cboStores.EditValue != null && cboYear.EditValue != null && lkCategory.EditValue != null && !ckExclude.Checked)
            {
                GenerateStockStatusPieChart();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += printableComponentLink1_CreateMarginalHeaderArea;
            printableComponentLink1.CreateDocument(false);
            printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            printableComponentLink1.ShowPreview();
        }

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (ckExclude.Checked)
            {
                PopulateSStatus1();
            }
            if (!ckExclude.Checked)
            {
                GenerateStockStatusPieChart();
            }
        }

        private void PopulateSStatus1()
        {
            if (curMont != 0 && curYear != 0)
            {
                var storeId = Convert.ToInt32(cboStores.EditValue);
                curYear = Convert.ToInt32(cboYear.EditValue);

                Balance blnc = new Balance();
                DataTable dtbl = blnc.GetSOH(storeId, curMont, Convert.ToInt32(cboYear.EditValue));

                Items itm = new Items();
                Balance bal = new Balance();
                ReceiveDoc rec = new ReceiveDoc();

                Programs prog = new Programs();
                prog.GetProgramByName("Family Planning");
                DataTable dtItm = itm.GetItemsByProgram(prog.ID);
                int totalECLS = dtItm.Rows.Count;
              
                int stockin = (from m in dtbl.AsEnumerable()
                               where m["Status"].ToString() == "Normal"
                               && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                               select m).Count();
             
                int stockout = (from m in dtbl.AsEnumerable()
                                where m["Status"].ToString() == "Stock Out"
                                && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                select m).Count();
            
                int overstock = (from m in dtbl.AsEnumerable()
                                 where m["Status"].ToString() == "Over Stocked"
                                 && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                 select m).Count();
              
                int nearEOP = (from m in dtbl.AsEnumerable()
                               where m["Status"].ToString() == "Near EOP"
                               && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                               select m).Count();
             
                int belowEOP = (from m in dtbl.AsEnumerable()
                                where m["Status"].ToString() == "Below EOP"
                                && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                select m).Count();
               
                int freeStockOut = (from m in dtbl.AsEnumerable()
                                    where m["Status"].ToString() == "Stock Out"
                                    && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                    select m).Count();
            
                object[] obj = { stockin, stockout, overstock, nearEOP, belowEOP };
                int totalItm = stockin + stockout + nearEOP + overstock;

                decimal percen = ((totalItm != 0) ? (Convert.ToDecimal(stockin) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
             
                percen = ((totalItm != 0) ? (Convert.ToDecimal(stockout) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(overstock) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(nearEOP) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(belowEOP) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                int totalFree = itm.CountFreeItems();
                percen = ((totalFree != 0) ? (Convert.ToDecimal(freeStockOut) / Convert.ToDecimal(totalFree)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                totalFree = itm.CountVitalItems();
                GenerateStockStatusPieChart(obj);
            }
        }

        private void PopulateSStatusReport()
        {
            if (curMont != 0 && curYear != 0)
            {
                var storeId = Convert.ToInt32(cboStores.EditValue);
                curYear = Convert.ToInt32(cboYear.EditValue);

                Balance blnc = new Balance();
                DataTable dtbl = new DataTable();
                if (storeId == 0)
                {
                    dtbl = blnc.GetSOHForAllStores(curMont, Convert.ToInt32(cboYear.EditValue));
                }
                else
                {
                    dtbl = blnc.GetSOH(storeId, curMont, Convert.ToInt32(cboYear.EditValue));
                }

                Items itm = new Items();
                Balance bal = new Balance();
                ReceiveDoc rec = new ReceiveDoc();

                Programs prog = new Programs();
                prog.GetProgramByName("Family Planning");
                DataTable dtItm = itm.GetItemsByProgram(prog.ID);
                int totalECLS = dtItm.Rows.Count;
                int stockin, stockout, overstock, nearEOP, belowEOP, freeStockOut;

                if (Convert.ToInt32(lkCategory.EditValue) != 0)
                {
                    stockin = (from m in dtbl.AsEnumerable()
                                   where m["Status"].ToString() == "Normal"
                                   && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                   select m).Count();

                    stockout = (from m in dtbl.AsEnumerable()
                                    where m["Status"].ToString() == "Stock Out"
                                    && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                    select m).Count();

                    overstock = (from m in dtbl.AsEnumerable()
                                     where m["Status"].ToString() == "Over Stocked"
                                     && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                     select m).Count();

                    nearEOP = (from m in dtbl.AsEnumerable()
                                   where m["Status"].ToString() == "Near EOP"
                                   && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                   select m).Count();

                    belowEOP = (from m in dtbl.AsEnumerable()
                                    where m["Status"].ToString() == "Below EOP"
                                    && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                    select m).Count();

                    freeStockOut = (from m in dtbl.AsEnumerable()
                                        where m["Status"].ToString() == "Stock Out"
                                        && Convert.ToInt32(m["TypeID"]) == Convert.ToInt32(lkCategory.EditValue) && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                        select m).Count();
                }
                else
                {
                    stockin = (from m in dtbl.AsEnumerable()
                               where m["Status"].ToString() == "Normal"
                               && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                               select m).Count();

                    stockout = (from m in dtbl.AsEnumerable()
                                where m["Status"].ToString() == "Stock Out"
                                && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                select m).Count();

                    overstock = (from m in dtbl.AsEnumerable()
                                 where m["Status"].ToString() == "Over Stocked"
                                 && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                 select m).Count();

                    nearEOP = (from m in dtbl.AsEnumerable()
                               where m["Status"].ToString() == "Near EOP"
                               && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                               select m).Count();

                    belowEOP = (from m in dtbl.AsEnumerable()
                                where m["Status"].ToString() == "Below EOP"
                                && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                select m).Count();

                    freeStockOut = (from m in dtbl.AsEnumerable()
                                    where m["Status"].ToString() == "Stock Out"
                                    && ((!ckExclude.Checked) || Convert.ToInt32(m["EverReceived"]) == 1)
                                    select m).Count();
                }

                object[] obj = { stockin, stockout, overstock, nearEOP, belowEOP };
                int totalItm = stockin + stockout + nearEOP + overstock;

                decimal percen = ((totalItm != 0) ? (Convert.ToDecimal(stockin) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
             
                percen = ((totalItm != 0) ? (Convert.ToDecimal(stockout) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(overstock) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(nearEOP) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                percen = ((totalItm != 0) ? (Convert.ToDecimal(belowEOP) / Convert.ToDecimal(totalItm)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                int totalFree = itm.CountFreeItems();
                percen = ((totalFree != 0) ? (Convert.ToDecimal(freeStockOut) / Convert.ToDecimal(totalFree)) * 100 : 0);
                percen = Decimal.Round(percen, 0);
                totalFree = itm.CountVitalItems();
                GenerateStockStatusPieChart(obj);
            }
        }

        private void GenerateStockStatusPieChart(Object[] obj)
        {
            chartPie.Series.Clear();

            DataTable dtList = new DataTable();
            dtList.Columns.Add("Type");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);
            object[] oo = { "Stock In", obj[0] };
            dtList.Rows.Add(oo);

            object[] oo2 = { "Stock Out", obj[1] };
            dtList.Rows.Add(oo2);

            object[] oo3 = { "OverStock", obj[2] };
            dtList.Rows.Add(oo3);

            object[] oo4 = { "Near EOP", obj[3] };
            dtList.Rows.Add(oo4);

            object[] oo5 = { "Below EOP", obj[4] };
            dtList.Rows.Add(oo5);

            Series ser = new Series("pie", ViewType.Pie3D);
            ser.DataSource = dtList;

            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Type";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.PointView = PointView.Argument;
            ser.LegendText = "Key";

            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            ((PieSeriesLabel)ser.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions)ser.PointOptions).PointView = PointView.ArgumentAndValues;
            ser.PointOptions.ValueNumericOptions.Precision = 0;
            chartPie.Series.Add(ser);
            //chartPie.Size = new System.Drawing.Size(500, 300);
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

            DateTime startDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, 11, year-1));
            DateTime endDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", day, month, year));
            DateTime currentDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", dtCurrent.Day, dtCurrent.Month, dtCurrent.Year));

            string strStartDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(startDate);
            string strEndDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(endDate);
            string strCurrentDate = EthiopianDate.EthiopianDate.GregorianToEthiopian(currentDate);

            string[] header = { info.HospitalName, "Store: " + cboStores.Text, " From Start Date: " + strStartDate, " To End Date: " + strEndDate, "Printed Date: " + strCurrentDate };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(160, 40, 200, 100), BorderSide.None);
            TextBrick brick4 = e.Graph.DrawString(header[4], Color.DarkBlue, new RectangleF(0, 60, 200, 100), BorderSide.None);
          }
    }
}

