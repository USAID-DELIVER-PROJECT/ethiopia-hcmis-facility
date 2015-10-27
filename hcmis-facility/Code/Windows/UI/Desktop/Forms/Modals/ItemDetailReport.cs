using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using System.Drawing.Printing;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;
using StockoutIndexBuilder;

namespace PharmInventory.Forms.Modals
{
    /// <summary>
    /// This form gives the detail information for an item.  The item ID, Store ID, and the year 
    /// the tab index of the form that's supposed to be displayed are passed to the constructor as an argument
    /// </summary>
    public partial class ItemDetailReport : Form
    {
        public ItemDetailReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open the item detail report form with parameters.
        /// </summary>
        /// <param name="itmId">The Item ID</param>
        /// <param name="strid">The Store ID</param>
        /// <param name="yr">The Fiscal Year</param>
        /// <param name="tab">The tab index to be shown</param>
        public ItemDetailReport(int itmId, int strid, int yr, int tab, int unitId)
        {
            InitializeComponent();
            _itemId = itmId;
            _storeId = strid;
            _year = (yr < 1990) ? 2001 : yr;
            _tabInd = tab;
            _unitID = unitId;
        }

        public ItemDetailReport(int itmId, int strid, int yr, int tab)
        {
            InitializeComponent();
            _itemId = itmId;
            _storeId = strid;
            _year = (yr < 1990) ? 2001 : yr;
            _tabInd = tab;
        }
        #region Members

        readonly int _itemId = 0;
        readonly int _unitID = 0;
        readonly int _storeId = 1;
        int _year = 0;
        readonly int _tabInd = 0;
        DateTime _dtCurrent = new DateTime();

        private System.IO.Stream _streamToPrint;
        string _streamType;
        #endregion

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
        int _first = 0;

        private void PopulateLogisticSummary()
        {
            //dtDate.Value = DateTime.Now;
            //    dtDate.CustomFormat = "MM/dd/yyyy";
            //DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            ReceivingUnits du = new ReceivingUnits();
            DataTable dtDus = du.GetApplicableDUsAll(_itemId);
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStores = stor.DefaultView.ToTable();

            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("StoreName");
            dtbl.Columns.Add("SOH");
            dtbl.Columns.Add("AMC");
            dtbl.Columns.Add("Issue");
            dtbl.Columns.Add("MOS");

            foreach (DataRow drStr in dtStores.Rows)
            {
                int storeId = Convert.ToInt32(drStr["ID"]);
                Int64 soh = bal.GetSOH(_itemId, storeId, _dtCurrent.Month, _dtCurrent.Year);
                double amc = Builder.CalculateAverageConsumption(_itemId, storeId, _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent, CalculationOptions.Monthly); //bal.CalculateAMC(_itemId, storeId, _dtCurrent.Month, _dtCurrent.Year); //Builder.CalculateAverageConsumption(_itemId, storeId,dtCurrent.Subtract(TimeSpan.FromDays(180)),dtCurrent,CalculationOptions.Monthly);
                //bal.CalculateAMC(_itemId, storeId, _dtCurrent.Month, _dtCurrent.Year);
                Int64 issue = iss.GetIssuedQuantityByMonth(_itemId, storeId, _dtCurrent.Month, _dtCurrent.Year);
                decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                mos = Decimal.Round(mos, 1);

                string[] str = { drStr["StoreName"].ToString(), ((soh != 0) ? soh.ToString("#,###") : "0"), ((amc != 0) ? amc.ToString("#,###") : "0"), ((issue != 0) ? issue.ToString("#,###") : "0"), mos.ToString() };
                dtbl.Rows.Add(str);
            }

            foreach (DataRow drDus in dtDus.Rows)
            {
                int duid = Convert.ToInt32(drDus["ID"]);
                Int64 soh = bal.GetDUSOH(_itemId, duid, _dtCurrent.Month, _dtCurrent.Year);
                double amc = Builder.CalculateAverageConsumption(_itemId, duid, _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent, CalculationOptions.Monthly);//bal.CalculateDUAMC(_itemId, duid, _dtCurrent.Month, _dtCurrent.Year, 0);
                Int64 issue = iss.GetDUIssueByMonth(_itemId, duid, _dtCurrent.Month, _dtCurrent.Year);
                decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                mos = Decimal.Round(mos, 1);

                string[] str = { drDus["Name"].ToString(), ((soh != 0) ? soh.ToString("#,###") : "0"), ((amc != 0) ? amc.ToString("#,###") : "0"), ((issue != 0) ? issue.ToString("#,###") : "0"), mos.ToString() };
                dtbl.Rows.Add(str);
            }

            gridDispensaryView.DataSource = dtbl;
        }

        private void BinCardTransaction_Load(object sender, EventArgs e)
        {
            DataTable dtyears = Items.AllYears();

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            //CALENDAR:
            foreach (DataRow drYears in dtyears.Rows)
            {
                if (drYears["year"] != DBNull.Value)
                {
                    int yr = Convert.ToInt32(drYears["year"]);
                    cboYear.Items.Add(yr);
                }
            }
            bool added = true;
            for (int x = 0; x < cboYear.Items.Count; x++)//to check if the current year is included or not
            {
                if (Convert.ToInt64(cboYear.Items[x]) == _year)
                {
                    added = false;
                    break;
                }
            }
            if (added)
            {
                cboYear.Items.Add(_year);
            }
            cboYear.SelectedItem = _year;

            var itemunit = new ItemUnit();
            var allunits = itemunit.GetAllUnits();
            unitBindingSource.DataSource = allunits.DefaultView;

            var unitcolumn = ((GridView)gridItemsList.MainView).Columns[11];
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    unitcolumn.Visible = false;
                    break;
                case 2:
                    unitcolumn.Visible = true;
                    break;
                default:
                    unitcolumn.Visible = true;
                    break;
            }

            PopulateBinCardYearCombo();
            cboFiscalYear.SelectedItem = _year;
            BLL.Items itm = new Items();
            DataTable dtItm = itm.GetItemById(_itemId);
            string itemName = dtItm.Rows[0]["ItemName"].ToString() + " - " + dtItm.Rows[0]["DosageForm"].ToString() + " - " + dtItm.Rows[0]["Strength"].ToString();
            txtItemName.Text = itemName;
            txtitmName.Text = itemName;
            toolTip1.SetToolTip(txtitmName, itemName);
            lblBUnit.Text = dtItm.Rows[0]["Unit"].ToString();
            this.Text = itemName + " Detail Report";


            ReceivingUnits dus = new ReceivingUnits();
            DataTable dtDU = dus.GetApplicableDUs(_itemId, _storeId);
            Stores stor = new Stores();
            stor.LoadByPrimaryKey(_storeId);
            object[] objS = { 0, stor.StoreName, "", "" };
            dtDU.Rows.Add(objS);
            cboDU.DataSource = dtDU;
            cboDU.SelectedIndex = (cboDU.Items.Count - 1);
            cboDU.Text = "Select DU";

            try
            {
                txtFreeItem.Text = (itm.IsFree) ? "Yes" : "No";
                txtRefrigerated.Text = (itm.Refrigeratored) ? "Yes" : "No";
                txtPediatric.Text = (itm.Pediatric) ? "Yes" : "No";

            }
            catch
            {
            }

         

            int du = ((cboDU.SelectedValue != null) ? Convert.ToInt32(cboDU.SelectedValue) : 0);
            GenerateCharts(0);
            ItemStockStatus();

            //GenerateBinCard();
            GenerateBinCardNew();
            PopulateTransaction();

            tabControl1.SelectedTabPageIndex = _tabInd;
            _first = 1;
            lblItemID.Text = _itemId.ToString();

            PopulateLogisticSummary();

        }

        private void PopulateBinCardYearCombo()
        {
            if (cboFiscalYear.Properties.Items.Count > 0)
            {
                cboFiscalYear.SelectedIndex = cboFiscalYear.Properties.Items.Count - 1;
                return; //The combo has already been populated.
            }
            int i = 0;
            foreach (DataRow dr in BLL.Items.AllFiscalYears().Rows)
            {
                cboFiscalYear.Properties.Items.Add(dr["Year"]);
                i++;
            }

            cboFiscalYear.SelectedIndex = i;
            cboFiscalYear.EditValue = EthiopianDate.EthiopianDate.Now.FiscalYear.ToString();
        }


        private void PopulateTransaction()
        {
            TimeSpan tt = new TimeSpan();
            Items itm = new Items();
            DateTime dtRec = itm.GetLastReceiveDate(_itemId, _storeId);
            DateTime dtIss = itm.GetLastIssuedDate(_itemId, _storeId);

            string noDays = "";

            tt = new TimeSpan(_dtCurrent.Ticks - dtRec.Ticks);
            noDays = (tt.TotalDays < 30000) ? dtRec.ToString("MM dd, yyyy") + " (" + tt.TotalDays.ToString() + " days ago)" : "Never";
            lblLastReceive.Text = noDays;
            lblLastRec.Text = noDays;

            tt = new TimeSpan(_dtCurrent.Ticks - dtIss.Ticks);
            noDays = (tt.TotalDays < 30000) ? dtIss.ToString("MM dd, yyyy") + " (" + tt.TotalDays.ToString() + " days ago)" : "Never";
            lblLastIssues.Text = noDays;
            lblLastIssue.Text = noDays;
        }

        private void ItemStockStatus()
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            Balance bal = new Balance();
            Items itm = new Items();
            //dtDate.Value = DateTime.Now;
            //DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            // int yr = ()?dtCurrent.Year : dtCurrent.Year -1;
            DataTable dtItm = itm.GetItemById(_itemId);
            string dosage = lblBUnit.Text;
            double amc = Builder.CalculateAverageConsumption(_itemId, _storeId, _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent, CalculationOptions.Monthly);//bal.CalculateAMC(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);
            Int64 soh = bal.GetSOH(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);
            double sohPrice = bal.GetSOHAmount(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);
            string sohPriStr = ((sohPrice != 0) ? sohPrice.ToString("C") + " ETB" : "0 ETB");
            // this can not be done cuz it works only for current year
            // Int64 soh = itm.GetSOHQtyAmount(itemId, storeId);

            double min = (amc * info.Min); //Int64 min = (amc * info.Min);
            double max = (amc * info.Max);  //Int64 max = (amc * info.Max);
            double eop = amc * (info.EOP + 0.25);
            double beloweop = amc * (info.EOP - 0.25);
            double reorder = max - soh;
            double mos = (amc > 0) ? (Convert.ToDouble(soh) / Convert.ToDouble(amc)) : 0;
            object[] obj = itm.GetExpiredQtyAmountItemsByID(_itemId, _storeId);
            Int64 expAmount = Convert.ToInt64(obj[0]);
            Double expCost = Convert.ToDouble(obj[1]);
            string expBirr = ((expCost != 0) ? " in ETB " + expCost.ToString("C") : " Price NA");
            object[] nearObj = itm.GetNearlyExpiredQtyAmountItemsByID(_itemId, _storeId);
            Int64 nearExpAmount = Convert.ToInt64(nearObj[0]);
            double nearExpCost = Convert.ToDouble(nearObj[1]);
            string nearExpBirr = ((nearExpCost != 0) ? " in ETB " + nearExpCost.ToString("C") : " Price NA");
            txtSOH.Text = (soh != 0) ? soh.ToString("#,###") + " - " + dosage + ", " + sohPriStr : "0 - " + dosage;
            txtAMC.Text = (amc != 0) ? amc.ToString("#,###") + " - " + dosage : "0" + " - " + dosage;
            txtMin.Text = (min != 0) ? min.ToString("#,###") + " - " + dosage : "0" + " - " + dosage;
            txtMax.Text = (max != 0) ? max.ToString("#,###") + " - " + dosage : "0" + " - " + dosage;
            txtMOS.Text = mos.ToString("#,###.0#");
            txtReorderAmount.Text = (reorder <= 0) ? "0 - " + dosage : reorder.ToString("#,###") + " - " + dosage;
            txtExpiredAmount.Text = (expAmount != 0) ? "Qty: " + expAmount.ToString("#,###") + " - " + dosage + expBirr : "0";
            txtNearExp.Text = (nearExpAmount != 0) ? nearExpAmount.ToString("#,###") + " - " + dosage + nearExpBirr : "0";

            DateTime dtTran = new DateTime();
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";

            TimeSpan tt = new TimeSpan();
            if (soh == 0)
            {
                lblstat.Text = "Stocked Out";
                lblStatus.Text = "Stocked Out";
                lblCurStatus.Text = "Stocked Out";
                dtTran = itm.GetLastIssuedDate(_itemId, _storeId);
                tt = new TimeSpan(_dtCurrent.Ticks - dtTran.Ticks);
                lblTime.Text = " For the past " + tt.TotalDays.ToString() + " Days";
            }
            else if (soh > max && max != 0)
            {
                lblstat.Text = "Over Stock";
                lblStatus.Text = "Over Stock";
                lblCurStatus.Text = "Over Stock";
                dtTran = itm.GetLastReceiveDate(_itemId, _storeId);
                tt = new TimeSpan(_dtCurrent.Ticks - dtTran.Ticks);
                lblTime.Text = " For the past " + tt.TotalDays.ToString() + " Days";
            }
            else if (soh > beloweop && soh <= eop)
            {
                lblstat.Text = "Near EOP";
                lblStatus.Text = "Near EOP";
                lblCurStatus.Text = "Near EOP";
                dtTran = itm.GetLastIssuedDate(_itemId, _storeId);
                tt = new TimeSpan(_dtCurrent.Ticks - dtTran.Ticks);
                lblTime.Text = " For the past " + tt.TotalDays.ToString() + " Days";
            }
            else if (soh > 0 && soh <= beloweop)
            {
                lblstat.Text = "Below EOP";
                lblStatus.Text = "Below EOP";
                lblCurStatus.Text = "Below EOP";
                dtTran = itm.GetLastIssuedDate(_itemId, _storeId);
                tt = new TimeSpan(_dtCurrent.Ticks - dtTran.Ticks);
                lblTime.Text = " For the past " + tt.TotalDays.ToString() + " Days";
            }
            else if (soh > eop && soh <= min)
            {
                lblstat.Text = "Below Min";
                lblStatus.Text = "Below Min";
                lblCurStatus.Text = "Below Min";
                dtTran = itm.GetLastIssuedDate(_itemId, _storeId);
                tt = new TimeSpan(_dtCurrent.Ticks - dtTran.Ticks);
                lblTime.Text = " For the past " + tt.TotalDays.ToString() + " Days";
            }
            else //if (soh> min && soh <= max)
            {
                lblstat.Text = "Normal";
                lblStatus.Text = "Normal";
                lblCurStatus.Text = "Normal";

            }
            //}
            //else
            //{
            //    lblCurStatus.Text = "Stocked Out";

            //    lblTime.Text = " Never been received!";
            //}

        }

        /* private void GenerateBinCard()
         {
             ReceiveDoc rec = new ReceiveDoc();
             IssueDoc iss = new IssueDoc();
             Disposal dis = new Disposal();
             DisposalReasons res = new DisposalReasons();
             Balance bal = new Balance();
             GeneralInfo info = new GeneralInfo();
             YearEnd yEnd = new YearEnd();
             Items itm = new Items();
             info.LoadAll();
             year = Convert.ToInt32(cboYear.SelectedItem);
            
             DataTable dtRec = rec.GetAllTransaction(itemId,storeId,dtCurrent.Month,year);
             DataTable dtIss = iss.GetTransactionByItemId(storeId, itemId, year);
             DataTable dtDis = dis.GetTransactionByItemId(storeId, itemId, year);

             Int64[] cStockout = { 0, 0, 0 };
             Int64[] cOverStock = { 0, 0, 0 };
             Int64[] cNearStockOut = { 0, 0, 0 };
             Int64[] cBelowMin = { 0, 0, 0 };


            
             //DateTime dtThree = dtCurrent.AddMonths(3);

             DataTable dtbin = new DataTable();
             string[] col = { "Date", "Ref. No", "Receive", "Issue", "Unit Price", "Balance", "Batch No", "Expiry Date","To / From"};
             foreach (string str in col)
             {
                 dtbin.Columns.Add(str);
             }
             int i = 0;
             Int64 bBalance = 0;
             dtDate.Value = DateTime.Now;
             dtDate.CustomFormat = "MM/dd/yyyy";
             dtCurrent = ConvertDate.DateConverter(dtDate.Text);
             bBalance = yEnd.GetBBalance(year, storeId, itemId,dtCurrent.Month);
             Int64 balanceAmount = bBalance;
             Int64 mincon = 0;
             Int64 maxcon = 0;
             double eopcon = 0;

             DateTime dtT = new DateTime();
             string balanceAm = "";


             txtBBalance.Text = bBalance.ToString();
             string ddDate = "";
             string batNo = "";
                 foreach (DataRow dvRec in dtRec.Rows)
                 {
                     i++;
                     if (Convert.ToInt32(dvRec["Transact"]) == 1)
                     {
                         rec.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
                         balanceAmount = balanceAmount + Convert.ToInt64(dvRec["Quantity"]);
                         balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                         itm.LoadByPrimaryKey(rec.ItemID);
                         if (itm.NeedExpiryBatch)
                         {
                             ddDate = rec.ExpDate.ToString("MMM dd,yyyy");
                             batNo = rec.BatchNo;
                         }
                         Supplier sup = new Supplier();
                         sup.LoadByPrimaryKey(rec.SupplierID);
                         object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), "", Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm, batNo, ddDate, sup.CompanyName};
                         dtbin.Rows.Add(obj);
                         //For stock Out
                         dtT = Convert.ToDateTime(dvRec["Date"]);
                         //int monb = (dtT.Month < 11) ? dtT.Month + 2 : ((dtT.Month == 11) ? 1 : 2);
                         //int yer = (dtT.Month < 11) ? dtT.Year : dtT.Year - 1;
                         Int64 bBal = bal.GetSOH(itemId, storeId, dtT.Month, dtT.Year);
                         Int64 bAmc = bal.CalculateAMC(itemId, storeId, dtT.Month, dtT.Year);

                         mincon = bAmc * info.Min;
                         maxcon = bAmc * info.Max;
                         eopcon = bAmc * info.EOP;

                         if (balanceAmount == 0)
                         {
                             if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                             {
                                 cStockout[0]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                             {
                                 cStockout[1]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                             {
                                 cStockout[2]++;
                             }
                         }
                         else if (balanceAmount > maxcon)
                         {
                             //For Over stock
                             if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                             {
                                 cOverStock[0]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                             {
                                 cOverStock[1]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                             {
                                 cOverStock[2]++;
                             }
                         }//For Below min
                         else if (balanceAmount > eopcon && balanceAmount <= mincon)
                         {
                             if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                             {
                                 cBelowMin[0]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                             {
                                 cBelowMin[1]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                             {
                                 cBelowMin[2]++;
                             }
                         }
                         else if (balanceAmount > 0 && balanceAmount < eopcon)
                         {
                             if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                             {
                                 cNearStockOut[0]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                             {
                                 cNearStockOut[1]++;
                             }
                             else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                             {
                                 cNearStockOut[2]++;
                             }
                         }
                     }else if(Convert.ToInt32(dvRec["Transact"]) == 0)
                     {
                         //DateTime dteIss = Convert.ToDateTime(drIss["Date"]);
                         //DateTime dteRec = Convert.ToDateTime(dvRec["Date"]);
                         //DateTime dTomorow = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day + 1);
                         //DateTime dteNextRec = (i <= dtRec.Rows.Count - 1) ? Convert.ToDateTime(dtRec.Rows[i]["Date"]) : dTomorow;
                         iss.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
                         try
                         {
                             rec.LoadByPrimaryKey(iss.RecievDocID);
                         }
                         catch
                         {
                             rec.GetTransactionByBatch(itemId, dvRec["BatchNo"].ToString(), storeId);
                         }

                         ReceivingUnits recUnit = new ReceivingUnits();
                         recUnit.LoadByPrimaryKey(iss.ReceivingUnitID);
                         string issuedTo = recUnit.Name;
                             balanceAmount = balanceAmount - Convert.ToInt64(dvRec["Quantity"]);

                         balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                         itm.LoadByPrimaryKey(iss.ItemID);
                         if (itm.NeedExpiryBatch)
                         {
                             ddDate = ((rec.RowCount > 0) ? rec.ExpDate.ToString("MMM dd,yyyy") : ""); ;
                             batNo = dvRec["BatchNo"].ToString(); //rec.BatchNo;
                         }
                         else
                         {
                             ddDate = "";
                             batNo = "";
                         }
                         object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], "", Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm,batNo, ddDate,issuedTo};
                         dtbin.Rows.Add(obj);
                         //For stock Out
                         dtT = Convert.ToDateTime(dvRec["Date"]);
                             //int monb1 = (dtT.Month < 11) ? dtT.Month + 2 : ((dtT.Month == 11) ? 1 : 2);
                             //int yer1 = (dtT.Month < 11) ? dtT.Year : dtT.Year - 1;
                            Int64 bBal = bal.GetSOH(itemId, storeId, dtT.Month, dtT.Year);
                             Int64 bAmc = bal.CalculateAMC(itemId, storeId, dtT.Month, dtT.Year);

                             mincon = bAmc * info.Min;
                             maxcon = bAmc * info.Max;
                             eopcon = bAmc * info.EOP;

                             if (balanceAmount == 0)
                             {
                                 if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                 {
                                     cStockout[0]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                 {
                                     cStockout[1]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                 {
                                     cStockout[2]++;
                                 }
                             }
                             else if (balanceAmount > maxcon)
                             {
                                 //For Over stock
                                 if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                 {
                                     cOverStock[0]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                 {
                                     cOverStock[1]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                 {
                                     cOverStock[2]++;
                                 }
                             }//For Below min
                             else if (balanceAmount > eopcon && balanceAmount <= mincon)
                             {
                                 if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                 {
                                     cBelowMin[0]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                 {
                                     cBelowMin[1]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                 {
                                     cBelowMin[2]++;
                                 }
                             }
                             else if (balanceAmount > 0 && balanceAmount < eopcon)
                             {
                                 if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                 {
                                     cNearStockOut[0]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                 {
                                     cNearStockOut[1]++;
                                 }
                                 else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                 {
                                     cNearStockOut[2]++;
                                 }
                             }


                         }



                         foreach (DataRow drDis in dtDis.Rows)
                         {
                             DateTime dteDis = Convert.ToDateTime(drDis["Date"]);
                             DateTime dteRec = Convert.ToDateTime(dvRec["Date"]);

                             res.LoadByPrimaryKey(Convert.ToInt32(drDis["ReasonId"]));
                             rec.GetTransactionByBatch(itemId,drDis["BatchNo"].ToString(),storeId);
                             DateTime dteNextRec = (i <= dtRec.Rows.Count - 1) ? Convert.ToDateTime(dtRec.Rows[i]["Date"]) : dtCurrent;
                             if ((dteRec <= dteDis) && (dteDis < dteNextRec))
                             {
                                 if (Convert.ToBoolean(drDis["Losses"]))
                                 {
                                     balanceAmount = balanceAmount - Convert.ToInt64(drDis["Quantity"]);
                                     balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                                     object[] objIss = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], "", Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason};
                                     dtbin.Rows.Add(objIss);

                                 }
                                 else
                                 {
                                     balanceAmount = balanceAmount + Convert.ToInt64(drDis["Quantity"]);
                                     balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                                     object[] objIss2 = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), "", Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason};
                                     dtbin.Rows.Add(objIss2);

                                 }

                                 dtT = Convert.ToDateTime(dvRec["Date"]);
                                 Int64 bAmc = bal.CalculateAMC(itemId, storeId, dtT.Month, dtT.Year);

                                 mincon = bAmc * info.Min;
                                 maxcon = bAmc * info.Max;
                                 eopcon = bAmc * info.EOP;
                                 if (balanceAmount == 0)
                                 {
                                     if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                     {
                                         cStockout[0]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                     {
                                         cStockout[1]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                     {
                                         cStockout[2]++;
                                     }
                                 }
                                 else if (balanceAmount > maxcon)
                                 {
                                     //For Over stock
                                     if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                     {
                                         cOverStock[0]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                     {
                                         cOverStock[1]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                     {
                                         cOverStock[2]++;
                                     }
                                 }//For Below min
                                 else if (balanceAmount > eopcon && balanceAmount <= mincon)
                                 {
                                     if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                     {
                                         cBelowMin[0]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                     {
                                         cBelowMin[1]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                     {
                                         cBelowMin[2]++;
                                     }
                                 }
                                 else if (balanceAmount > 0 && balanceAmount < eopcon)
                                 {
                                     if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(90)))
                                     {
                                         cNearStockOut[0]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(180)))
                                     {
                                         cNearStockOut[1]++;
                                     }
                                     else if (Convert.ToDateTime(dvRec["Date"]) <= dtCurrent && Convert.ToDateTime(dvRec["Date"]) >= dtCurrent.Subtract(TimeSpan.FromDays(360)))
                                     {
                                         cNearStockOut[2]++;
                                     }
                                 }


                             }
                         }



                     }
             transactionGrid.DataSource = dtbin;
             //Stock Out
             lblThreeStockout.Text = cStockout[0].ToString();
             lblSixStockOut.Text = (cStockout[0] + cStockout[1]).ToString();
             lblTwelveStockOut.Text = (cStockout[0] + cStockout[1] + cStockout[2]).ToString();
             //Over Stock
             lblThreeOverStock.Text = cOverStock[0].ToString();
             lblSixOverStock.Text = (cOverStock[0] + cOverStock[1]).ToString();
             lblTwelveOverStock.Text = (cOverStock[0] + cOverStock[1] + cOverStock[2]).ToString();
             //Near eop
             lblThreeNearStock.Text = cNearStockOut[0].ToString();
             lblSixNearStock.Text = (cNearStockOut[0] + cNearStockOut[1]).ToString();
             lblTwelveNear.Text = (cNearStockOut[0] + cNearStockOut[1] + cNearStockOut[2]).ToString();
             //Below Min
             lblThreeBelowMin.Text = cBelowMin[0].ToString();
             lblSixBelowMin.Text = (cBelowMin[0] + cBelowMin[1]).ToString();
             lblTwelveBelowMin.Text = (cBelowMin[0] + cBelowMin[1] + cBelowMin[2]).ToString();
         }
          */
        /// <summary>
        /// Generates the bin card transaction
        /// </summary>
        private void GenerateBinCard()
        {
            #region NewCode
            ////Get the beginning balance.
            //Int64 begBalance = 0;
            //YearEnd yearEnd = new YearEnd();
            //begBalance = yearEnd.GetBeginningBalance(_storeId, _itemId);
            //txtBBalance.Text = begBalance.ToString();

            ////Get the bin card.
            //Balance balance = new Balance();
            //gridItemsList.DataSource = balance.GetBinCard(_storeId, _itemId);
            //return; 
            #endregion
            #region Old Code
            ReceiveDoc rec = new ReceiveDoc();
            IssueDoc iss = new IssueDoc();
            Disposal dis = new Disposal();
            DisposalReasons res = new DisposalReasons();
            Balance bal = new Balance();
            GeneralInfo info = new GeneralInfo();
            YearEnd yEnd = new YearEnd();
            Items itm = new Items();
            info.LoadAll();
            if (cboFiscalYear.SelectedItem == null)
                PopulateBinCardYearCombo();
            //_year =  Convert.ToInt32(cboFiscalYear.SelectedItem);
            _year = Convert.ToInt32(cboYear.SelectedItem);
            int yer = _year;
            //int mth = (_year > _dtCurrent.Year) ? _dtCurrent.Month : 10;
            int mth = _dtCurrent.Month;
            EthiopianDate.EthiopianDate ethioDate = new EthiopianDate.EthiopianDate(_year, 1, 1);

            //if (_dtCurrent.Month < 11)
            //{
            //    yer = _year;
            //}
            //else
            //{
            //    yer = _year - 1;
            //}
            //DataTable dtRec = rec.GetAllTransaction(_itemId, _storeId, ethioDate.Month,ethioDate.Year);
            DataTable dtRec = rec.GetAllTransaction(_itemId, _storeId, ethioDate.FiscalYear);
            DataTable dtIss = iss.GetTransactionByItemId(_storeId, _itemId, ethioDate.FiscalYear);
            DataTable dtDis = dis.GetTransactionByItemId(_storeId, _itemId, ethioDate.FiscalYear);

            Int64[] cStockout = { 0, 0, 0 };
            Int64[] cOverStock = { 0, 0, 0 };
            Int64[] cNearStockOut = { 0, 0, 0 };
            Int64[] cBelowMin = { 0, 0, 0 };



            //DateTime dtThree = dtCurrent.AddMonths(3);

            DataTable dtbin = new DataTable();
            string[] col = { "Date", "RefNo", "Receive", "Issue", "Unit Price", "Balance", "Batch No", "Expiry Date", "ToFrom" };
            foreach (string str in col)
            {
                dtbin.Columns.Add(str);
            }
            int i = 0;
            Int64 bBalance = 0;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            //bBalance = yEnd.GetBBalance(_year, _storeId, _itemId, _dtCurrent.Month);
            bBalance = yEnd.GetBBalance(_year, _storeId, _itemId);
            Int64 balanceAmount = bBalance;

            DateTime dtT = new DateTime();
            string balanceAm = "";



            string ddDate = "";
            string batNo = "";
            foreach (DataRow dvRec in dtRec.Rows)
            {
                i++;
                if (Convert.ToInt32(dvRec["Transact"]) == 1)
                {
                    rec.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
                    if (dvRec["Quantity"] == DBNull.Value)
                    {
                        dvRec["Quantity"] = 0;
                    }
                    balanceAmount = balanceAmount + Convert.ToInt64(dvRec["Quantity"]);
                    balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                    itm.LoadByPrimaryKey(rec.ItemID);
                    if (itm.NeedExpiryBatch)
                    {
                        if (!rec.IsColumnNull("ExpDate"))
                        {
                            ddDate = rec.ExpDate.ToString("MMM dd,yyyy");
                            batNo = rec.BatchNo;
                        }
                    }
                    Supplier sup = new Supplier();
                    sup.LoadByPrimaryKey(rec.SupplierID);
                    object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), "", Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm, batNo, ddDate, sup.CompanyName };
                    dtbin.Rows.Add(obj);
                    //For stock Out
                    dtT = Convert.ToDateTime(dvRec["Date"]);

                }
                else if (Convert.ToInt32(dvRec["Transact"]) == 0)
                {
                    iss.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
                    try
                    {
                        rec.LoadByPrimaryKey(iss.RecievDocID);
                    }
                    catch
                    {
                        rec.GetTransactionByBatch(_itemId, dvRec["BatchNo"].ToString(), _storeId);
                    }

                    ReceivingUnits recUnit = new ReceivingUnits();
                    recUnit.LoadByPrimaryKey(iss.ReceivingUnitID);
                    string issuedTo = recUnit.Name;
                    balanceAmount = balanceAmount - Convert.ToInt64(dvRec["Quantity"]);

                    balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                    itm.LoadByPrimaryKey(iss.ItemID);
                    if (itm.NeedExpiryBatch)
                    {
                        ddDate = ((rec.RowCount > 0) ? rec.ExpDate.ToString("MMM dd,yyyy") : ""); ;
                        batNo = dvRec["BatchNo"].ToString(); //rec.BatchNo;
                    }
                    else
                    {
                        ddDate = "";
                        batNo = "";
                    }
                    object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], "", Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm, batNo, ddDate, issuedTo };
                    dtbin.Rows.Add(obj);
                    //For stock Out
                    dtT = Convert.ToDateTime(dvRec["Date"]);

                }

                foreach (DataRow drDis in dtDis.Rows)
                {
                    DateTime dteDis = Convert.ToDateTime(drDis["Date"]);
                    DateTime dteRec = Convert.ToDateTime(dvRec["Date"]);

                    res.LoadByPrimaryKey(Convert.ToInt32(drDis["ReasonId"]));
                    rec.GetTransactionByBatch(_itemId, drDis["BatchNo"].ToString(), _storeId);
                    DateTime dteNextRec = (i <= dtRec.Rows.Count - 1) ? Convert.ToDateTime(dtRec.Rows[i]["Date"]) : _dtCurrent;
                    if ((dteRec <= dteDis) && (dteDis < dteNextRec))
                    {
                        if (Convert.ToBoolean(drDis["Losses"]))
                        {
                            balanceAmount = balanceAmount - Convert.ToInt64(drDis["Quantity"]);
                            balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                            if (rec.RowCount > 0)
                            {
                                object[] objIss = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], "", Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason };
                                dtbin.Rows.Add(objIss);
                            }
                        }
                        else
                        {
                            balanceAmount = balanceAmount + Convert.ToInt64(drDis["Quantity"]);
                            balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
                            object[] objIss2 = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), "", Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason };
                            dtbin.Rows.Add(objIss2);

                        }

                        dtT = Convert.ToDateTime(dvRec["Date"]);

                    }
                }

            }

            gridItemsList.DataSource = dtbin;
            #endregion
        }

        //private void GenerateBinCardNew()
        //{
        //    ReceiveDoc rec = new ReceiveDoc();
        //    IssueDoc iss = new IssueDoc();
        //    Disposal dis = new Disposal();
        //    DisposalReasons res = new DisposalReasons();
        //    Balance bal = new Balance();
        //    GeneralInfo info = new GeneralInfo();
        //    YearEnd yEnd = new YearEnd();
        //    Items itm = new Items();
        //    info.LoadAll();
        //    if (cboFiscalYear.SelectedItem == null)
        //        PopulateBinCardYearCombo();
        //    _year = Convert.ToInt32(cboFiscalYear.SelectedItem);
        //    //_year = Convert.ToInt32(cboYear.SelectedItem);
        //    int yer = _year;
        //    //int mth = (_year > _dtCurrent.Year) ? _dtCurrent.Month : 10;
        //    int mth = _dtCurrent.Month;
        //    EthiopianDate.EthiopianDate ethioDate = new EthiopianDate.EthiopianDate(_year, 1, 1);

        //    //if (_dtCurrent.Month < 11)
        //    //{
        //    //    yer = _year;
        //    //}
        //    //else
        //    //{
        //    //    yer = _year - 1;
        //    //}
        //    //DataTable dtRec = rec.GetAllTransaction(_itemId, _storeId, ethioDate.Month,ethioDate.Year);
        //    DataTable dtRec = rec.GetAllTransaction(_itemId, _storeId, _year);
        //    DataTable dtIss = iss.GetTransactionByItemId(_storeId, _itemId, _year);
        //    DataTable dtDis = dis.GetTransactionByItemId(_storeId, _itemId, _year);

        //    Int64[] cStockout = { 0, 0, 0 };
        //    Int64[] cOverStock = { 0, 0, 0 };
        //    Int64[] cNearStockOut = { 0, 0, 0 };
        //    Int64[] cBelowMin = { 0, 0, 0 };



        //    //DateTime dtThree = dtCurrent.AddMonths(3);

        //    DataTable dtbin = new DataTable();
        //    string[] col = { "Date", "RefNo", "Receive", "Issue", "Unit Price", "Balance", "Batch No", "Expiry Date", "ToFrom" };
        //    foreach (string str in col)
        //    {
        //        dtbin.Columns.Add(str);
        //    }
        //    int i = 0;
        //    Int64 bBalance = 0;
        //    dtDate.Value = DateTime.Now;
        //    dtDate.CustomFormat = "MM/dd/yyyy";
        //    _dtCurrent = ConvertDate.DateConverter(dtDate.Text);
        //    //bBalance = yEnd.GetBBalance(_year, _storeId, _itemId, _dtCurrent.Month);
        //    bBalance = yEnd.GetBBalance(_year, _storeId, _itemId);
        //    Int64 balanceAmount = bBalance;

        //    DateTime dtT = new DateTime();
        //    string balanceAm = "";


        //    txtBBalance.Text = bBalance.ToString();
        //    string ddDate = "";
        //    string batNo = "";
        //    foreach (DataRow dvRec in dtRec.Rows)
        //    {
        //        i++;
        //        if (Convert.ToInt32(dvRec["Transact"]) == 1)
        //        {
        //            rec.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
        //            if (dvRec["Quantity"] == DBNull.Value)
        //            {
        //                dvRec["Quantity"] = 0;
        //            }
        //            balanceAmount = balanceAmount + Convert.ToInt64(dvRec["Quantity"]);
        //            balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
        //            itm.LoadByPrimaryKey(rec.ItemID);
        //            if (itm.NeedExpiryBatch)
        //            {
        //                if (!rec.IsColumnNull("ExpDate"))
        //                {
        //                    ddDate = rec.ExpDate.ToString("MMM dd,yyyy");
        //                    batNo = rec.BatchNo;
        //                }
        //            }
        //            Supplier sup = new Supplier();
        //            sup.LoadByPrimaryKey(rec.SupplierID);
        //            object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), "", Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm, batNo, ddDate, sup.CompanyName };
        //            dtbin.Rows.Add(obj);
        //            //For stock Out
        //            dtT = Convert.ToDateTime(dvRec["Date"]);

        //        }
        //        else if (Convert.ToInt32(dvRec["Transact"]) == 0)
        //        {
        //            iss.LoadByPrimaryKey(Convert.ToInt32(dvRec["ID"]));
        //            try
        //            {
        //                rec.LoadByPrimaryKey(iss.RecievDocID);
        //            }
        //            catch
        //            {
        //                rec.GetTransactionByBatch(_itemId, dvRec["BatchNo"].ToString(), _storeId);
        //            }

        //            ReceivingUnits recUnit = new ReceivingUnits();
        //            recUnit.LoadByPrimaryKey(iss.ReceivingUnitID);
        //            string issuedTo = recUnit.Name;
        //            balanceAmount = balanceAmount - Convert.ToInt64(dvRec["Quantity"]);

        //            balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
        //            itm.LoadByPrimaryKey(iss.ItemID);
        //            if (itm.NeedExpiryBatch)
        //            {
        //                ddDate = ((rec.RowCount > 0) ? rec.ExpDate.ToString("MMM dd,yyyy") : ""); ;
        //                batNo = dvRec["BatchNo"].ToString(); //rec.BatchNo;
        //            }
        //            else
        //            {
        //                ddDate = "";
        //                batNo = "";
        //            }
        //            object[] obj = { Convert.ToDateTime(dvRec["Date"]).ToString("MM dd,yyyy"), dvRec["RefNo"], "", Convert.ToInt64(dvRec["Quantity"]).ToString("#,###"), Convert.ToDouble(dvRec["Cost"]).ToString("C"), balanceAm, batNo, ddDate, issuedTo };
        //            dtbin.Rows.Add(obj);
        //            //For stock Out
        //            dtT = Convert.ToDateTime(dvRec["Date"]);

        //        }

        //        foreach (DataRow drDis in dtDis.Rows)
        //        {
        //            DateTime dteDis = Convert.ToDateTime(drDis["Date"]);
        //            DateTime dteRec = Convert.ToDateTime(dvRec["Date"]);

        //            res.LoadByPrimaryKey(Convert.ToInt32(drDis["ReasonId"]));
        //            rec.GetTransactionByBatch(_itemId, drDis["BatchNo"].ToString(), _storeId);
        //            DateTime dteNextRec = (i <= dtRec.Rows.Count - 1) ? Convert.ToDateTime(dtRec.Rows[i]["Date"]) : _dtCurrent.AddDays(1);
        //            if ((dteRec <= dteDis) && (dteDis < dteNextRec))
        //            {
        //                if (Convert.ToBoolean(drDis["Losses"]))
        //                {
        //                    balanceAmount = balanceAmount - Convert.ToInt64(drDis["Quantity"]);
        //                    balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
        //                    if (rec.RowCount > 0)
        //                    {
        //                        object[] objIss = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], "", Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason };
        //                        dtbin.Rows.Add(objIss);
        //                    }
        //                }
        //                else
        //                {
        //                    balanceAmount = balanceAmount + Convert.ToInt64(drDis["Quantity"]);
        //                    balanceAm = (balanceAmount > 0) ? balanceAmount.ToString("#,###") : "0";
        //                    object[] objIss2 = { Convert.ToDateTime(drDis["Date"]).ToString("MM dd,yyyy"), drDis["RefNo"], Convert.ToInt64(drDis["Quantity"]).ToString("#,###"), "", Convert.ToDouble(drDis["Cost"]).ToString("C"), balanceAm, drDis["BatchNo"], rec.ExpDate.ToString("MMM dd,yyyy"), res.Reason };
        //                    dtbin.Rows.Add(objIss2);

        //                }
        //                dtT = Convert.ToDateTime(dvRec["Date"]);

        //            }
        //        }

        //    }

        //    gridItemsList.DataSource = dtbin;
        //}

        /// <summary>
        /// uses the stored procedure rpt_BinCard
        /// </summary>
        private void GenerateBinCardNew()
        {
            //Get the bin card.
            var balance = new Balance();
            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    txtBBalance.Text = balance.GetBeginningBalance(Convert.ToInt32(cboFiscalYear.EditValue), _itemId, _storeId).ToString();
                    gridItemsList.DataSource = balance.GetBinCard(_storeId, _itemId,Convert.ToInt32(cboFiscalYear.EditValue));
                    break;
                case 2:
                    txtBBalance.Text = balance.GetBeginningBalanceByUnit(Convert.ToInt32(cboFiscalYear.EditValue), _itemId, _storeId,_unitID).ToString();
                    gridItemsList.DataSource = balance.GetBinCard2(_storeId, _itemId,Convert.ToInt32(cboFiscalYear.EditValue), _unitID);
                    break;
                case 3:
                    txtBBalance.Text = balance.GetBeginningBalanceByUnit(Convert.ToInt32(cboFiscalYear.EditValue), _itemId, _storeId,_unitID).ToString();
                    gridItemsList.DataSource = balance.GetBinCard2(_storeId, _itemId,Convert.ToInt32(cboFiscalYear.EditValue), _unitID);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Generates the charts one by one.
        /// </summary>
        /// <param name="du"></param>
        private void GenerateCharts(int du)
        {
            Balance bal = new Balance();
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            DataTable dtList = new DataTable();
            DataTable dtAmc = new DataTable();
            DataTable dtMOS = new DataTable();
            DataTable dtIss = new DataTable();
            DataTable dtRec = new DataTable();
            DataTable dtBB = new DataTable();
            //CALENDAR:
            //  DataTable dtCons = new DataTable();
            string[] co = { "Ham", "Neh", "Mes", "Tek", "Hed", "Tah", "Tir", "Yek", "Meg", "Miz", "Gen", "Sen" };

            //foreach(string s in co)
            //{
            dtList.Columns.Add("Month");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);

            dtMOS.Columns.Add("Month");
            dtMOS.Columns.Add("Value");
            dtMOS.Columns[1].DataType = typeof(decimal);

            dtAmc.Columns.Add("Month");
            dtAmc.Columns.Add("Value");
            dtAmc.Columns[1].DataType = typeof(Int64);

            dtIss.Columns.Add("Month");
            dtIss.Columns.Add("Value");
            dtIss.Columns[1].DataType = typeof(Int64);

            dtRec.Columns.Add("Month");
            dtRec.Columns.Add("Value");
            dtRec.Columns[1].DataType = typeof(Int64);

            dtBB.Columns.Add("Month");
            dtBB.Columns.Add("Value");
            dtBB.Columns[1].DataType = typeof(Int64);

            int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            long[] cons = new long[12];
            double[] amc = new double[12];
            long[] con = new long[12];
            long[] issval = new long[12];
            DataTable dtBal = new DataTable();
            IssueDoc issd = new IssueDoc();
            Items recd = new Items();
            YearEnd yEnd = new YearEnd();
            Int64 bb = yEnd.GetBBalance(_year, _storeId, _itemId, 10);
            object[] objBB = { "Ham", bb };
            dtBB.Rows.Add(objBB);
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            for (int i = 0; i < mon.Length; i++)
            {
                int cMonth = _dtCurrent.Month;
                //if (!(year == dtCurrent.Year && mon[i] > dtCurrent.Month && mon[i] < 11))
                if (((mon[i] == 11 || mon[i] == 12) && (mon[i] <= cMonth || _year == _dtCurrent.Year)) || (mon[i] < 11 && mon[i] <= cMonth && _year == _dtCurrent.Year))
                {
                    int yr = (mon[i] < 11) ? _year : _year - 1;
                    // dtBal = bal.GetSOH(itemId,storeId,mon[i],yr);
                    con[i] = ((du == 0) ? bal.GetSOH(_itemId, _storeId, mon[i], yr) : bal.GetDUSOH(_itemId, du, mon[i], yr));
                    object xSOH = null;
                    if (con[i] == 0)
                    {
                        for (int li = i; li >= 0; li--)
                        {
                            if (con[li] != 0)
                            {
                                xSOH = 0;
                                break;
                            }
                        }
                    }
                    else
                        xSOH = con[i];
                    object[] str = { co[i], xSOH };
                    amc[i] = ((du == 0) ? Builder.CalculateAverageConsumption(_itemId, _storeId, _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent, CalculationOptions.Monthly) : bal.CalculateDUAMC(_itemId, du, mon[i], yr, 0));//bal.CalculateAMC(_itemId, _storeId, mon[i], yr) 
                    object xAmc = null;
                    if (amc[i] == 0)
                    {
                        for (int li = i; li >= 0; li--)
                        {
                            if (amc[li] != 0)
                            {
                                xAmc = 0;
                                break;
                            }
                        }
                    }
                    else
                        xAmc = amc[i];
                    object[] objAmc = { co[i], xAmc };

                    // for mos check the diff b/n null and zero
                    // And also mos = soh/amc right???
                    decimal mos = (amc[i] > 0) ? (Convert.ToDecimal(con[i]) / Convert.ToDecimal(amc[i])) : 0;
                    object[] objMos = { co[i], mos };
                    int fYear = (mon[i] < 11) ? yr : yr - 1;

                    issval[i] = ((du == 0) ? issd.GetIssuedQuantityByMonth(_itemId, _storeId, mon[i], yr) : issd.GetDUConsumptionByMonth(_itemId, du, mon[i], yr));
                    object xIss = null;
                    if (issval[i] == 0)
                    {
                        for (int li = i; li >= 0; li--)
                        {
                            if (issval[li] != 0)
                            {
                                xIss = 0;
                                break;
                            }
                        }
                    }
                    else
                        xIss = issval[i];
                    object[] objIss = { co[i], xIss };

                    Int64 recVal = ((du == 0) ? recd.GetQuantityReceiveByItemPerMonth(mon[i], _itemId, _storeId, yr) : issd.GetDUReceiveByMonth(_itemId, du, mon[i], yr));
                    object[] objrec = { co[i], recVal };

                    dtList.Rows.Add(str);
                    dtAmc.Rows.Add(objAmc);
                    dtMOS.Rows.Add(objMos);
                    dtIss.Rows.Add(objIss);
                    dtRec.Rows.Add(objrec);
                }
            }


            // string[] str = { ((cons[0] != 0) ? cons[0].ToString("") : "0"), ((cons[1] != 0) ? cons[1].ToString() : "0"), ((cons[2] != 0) ? cons[2].ToString() : "0"), ((cons[3] != 0) ? cons[3].ToString() : "0"), ((cons[4] != 0) ? cons[4].ToString() : "0"), ((cons[5] != 0) ? cons[5].ToString() : "0"), ((cons[6] != 0) ? cons[6].ToString() : "0"), ((cons[7] != 0) ? cons[7].ToString() : "0"), ((cons[8] != 0) ? cons[8].ToString() : "0"), ((cons[9] != 0) ? cons[9].ToString() : "0"), ((cons[10] != 0) ? cons[10].ToString() : "0"), ((cons[11] != 0) ? cons[11].ToString() : "0")};
            chartAmc.Series.Clear(); //AMC
            chartComp.Series.Clear();//Activity
            chartBar.Series.Clear(); //SOH
            chartMOS.Series.Clear(); // MOS
            consuTrend.Series.Clear();

            Series ser = new Series("Stock On Hand", ViewType.Line);
            ser.DataSource = dtList;
            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Month";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            ser.PointOptions.ValueNumericOptions.Precision = 0;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });

            chartBar.Series.Add(ser);
            ((XYDiagram)chartBar.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartBar.Diagram).AxisY.NumericOptions.Precision = 0;

            Series serB = new Series("Begining Balance", ViewType.Bar);
            serB.DataSource = dtBB;
            serB.ArgumentScaleType = ScaleType.Qualitative;
            serB.ArgumentDataMember = "Month";
            serB.ValueScaleType = ScaleType.Numerical;
            serB.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            serB.PointOptions.ValueNumericOptions.Precision = 0;
            serB.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serB);

            Series serRec = new Series("Received Qty", ViewType.Bar);
            serRec.DataSource = dtRec;
            serRec.ArgumentScaleType = ScaleType.Qualitative;
            serRec.ArgumentDataMember = "Month";
            serRec.ValueScaleType = ScaleType.Numerical;
            serRec.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            serRec.PointOptions.ValueNumericOptions.Precision = 0;
            serRec.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serRec);

            Series serAmc = new Series("AMC", ViewType.Line);
            serAmc.DataSource = dtAmc;
            serAmc.ArgumentScaleType = ScaleType.Qualitative;
            serAmc.ArgumentDataMember = "Month";
            serAmc.ValueScaleType = ScaleType.Numerical;
            serAmc.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            serAmc.PointOptions.ValueNumericOptions.Precision = 0;
            serAmc.ValueDataMembers.AddRange(new string[] { "Value" });
            chartAmc.Series.Add(serAmc);
            ((XYDiagram)chartAmc.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartAmc.Diagram).AxisY.NumericOptions.Precision = 0;

            Series serIss = new Series("Issue Qty", ViewType.Bar);
            serIss.DataSource = dtIss;
            serIss.ArgumentScaleType = ScaleType.Qualitative;
            serIss.ArgumentDataMember = "Month";
            serIss.ValueScaleType = ScaleType.Numerical;
            serIss.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            serIss.PointOptions.ValueNumericOptions.Precision = 0;
            serIss.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serIss);

            //Int64 amcCurent = bal.CalculateAMC(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);
            double amcCurent = Builder.CalculateAverageConsumption(_itemId, _storeId,
                                                                   _dtCurrent.Subtract(TimeSpan.FromDays(180)),
                                                                   _dtCurrent, CalculationOptions.Monthly);
            double min = info.Min * amcCurent;
            double max = info.Max * amcCurent;
            Int64 nearEOP = Convert.ToInt64(amcCurent * (info.EOP + 0.25));
            ConstantLine target = new ConstantLine();
            ConstantLine targetEOP = new ConstantLine();
            target.AxisValue = min;
            //which min and max to show month
            ((XYDiagram)chartComp.Diagram).AxisY.ConstantLines.Clear();
            target.Visible = true;
            target.Title.Text = "Current Min value is " + Convert.ToInt64(target.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            target.Color = Color.Red;
            target.LineStyle.Thickness = 2;
            target.LegendText = "Min";
            ((XYDiagram)chartComp.Diagram).AxisY.ConstantLines.Add(target);

            targetEOP = new ConstantLine();
            targetEOP.AxisValue = nearEOP;
            //which min and max to show month
            //((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Clear();
            targetEOP.Visible = true;
            targetEOP.Title.Text = "Current EOP value is " + Convert.ToInt64(targetEOP.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            targetEOP.Color = Color.Yellow;
            targetEOP.LineStyle.Thickness = 2;
            targetEOP.LegendText = "EOP";
            ((XYDiagram)chartComp.Diagram).AxisY.ConstantLines.Add(targetEOP);

            ConstantLine targetMax = new ConstantLine();
            targetMax.AxisValue = max;
            //which min and max to show month
            targetMax.Visible = true;
            targetMax.Title.Text = "Current Max value is " + Convert.ToInt64(targetMax.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            targetMax.Color = Color.Blue;
            targetMax.LineStyle.Thickness = 2;
            targetMax.LegendText = "Max";
            ((XYDiagram)chartComp.Diagram).AxisY.ConstantLines.Add(targetMax);

            Series sercons = new Series("Consumption", ViewType.Line);
            sercons.DataSource = dtIss;
            sercons.ArgumentScaleType = ScaleType.Qualitative;
            sercons.ArgumentDataMember = "Month";
            sercons.ValueScaleType = ScaleType.Numerical;
            sercons.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            sercons.PointOptions.ValueNumericOptions.Precision = 0;
            sercons.ValueDataMembers.AddRange(new string[] { "Value" });
            consuTrend.Series.Add(sercons);
            ((XYDiagram)consuTrend.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)consuTrend.Diagram).AxisY.NumericOptions.Precision = 0;


            Series serSOH = new Series("SOH", ViewType.Bar);
            serSOH.DataSource = dtList;
            serSOH.ArgumentScaleType = ScaleType.Qualitative;
            serSOH.ArgumentDataMember = "Month";
            serSOH.ValueScaleType = ScaleType.Numerical;
            serSOH.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartComp.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartComp.Diagram).AxisY.NumericOptions.Precision = 0;
            serSOH.PointOptions.ValueNumericOptions.Precision = 0;

            serSOH.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serSOH);

            Series serMos = new Series("Month Of Stock", ViewType.Line);
            serMos.DataSource = dtMOS;
            serMos.ArgumentScaleType = ScaleType.Qualitative;
            serMos.ArgumentDataMember = "Month";
            serMos.ValueScaleType = ScaleType.Numerical;
            serMos.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
            serMos.PointOptions.ValueNumericOptions.Precision = 1;
            serMos.ValueDataMembers.AddRange(new string[] { "Value" });

            chartMOS.Series.Add(serMos);
            if (Convert.ToInt32(((XYDiagram)chartMOS.Diagram).AxisY.Range.MaxValue) <= 12)
            {
                ((XYDiagram)chartMOS.Diagram).AxisY.Range.MaxValue = 12;
            }


            //Int64 soh = bal.GetSOH(itemId,storeId,dtCurrent.Month,year);
            //if (bal.RowCount > 0)
            //{
            //Int64 amcCurent = bal.CalculateAMC(_itemId, _storeId, _dtCurrent.Month, _year);
            amcCurent = Builder.CalculateAverageConsumption(_itemId, _storeId,
                                                                  _dtCurrent.Subtract(TimeSpan.FromDays(180)),
                                                                  _dtCurrent, CalculationOptions.Monthly);
            min = info.Min * amcCurent;
            max = info.Max * amcCurent;
            nearEOP = Convert.ToInt64(amcCurent * (info.EOP + 0.25));
            target = new ConstantLine();
            target.AxisValue = min;
            //which min and max to show month
            ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Clear();
            target.Visible = true;
            target.Title.Text = "Current Min value is " + Convert.ToInt64(target.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            target.Color = Color.Red;
            target.LineStyle.Thickness = 2;
            target.LegendText = "Min";
            ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Add(target);

            targetEOP = new ConstantLine();
            targetEOP.AxisValue = nearEOP;
            //which min and max to show month
            //((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Clear();
            targetEOP.Visible = true;
            targetEOP.Title.Text = "Current EOP value is " + Convert.ToInt64(targetEOP.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            targetEOP.Color = Color.Yellow;
            targetEOP.LineStyle.Thickness = 2;
            targetEOP.LegendText = "EOP";
            ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Add(targetEOP);

            targetMax = new ConstantLine();
            targetMax.AxisValue = max;
            //which min and max to show month
            targetMax.Visible = true;
            targetMax.Title.Text = "Current Max value is " + Convert.ToInt64(targetMax.AxisValue).ToString("#,###") + " " + lblBUnit.Text;
            targetMax.Color = Color.Blue;
            targetMax.LineStyle.Thickness = 2;
            targetMax.LegendText = "Max";
            ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Add(targetMax);

            ConstantLine targetMos = new ConstantLine();
            ConstantLine targetMosMin = new ConstantLine();
            ((XYDiagram)chartMOS.Diagram).AxisY.ConstantLines.Clear();
            targetMos = new ConstantLine();
            targetMos.AxisValue = info.Max;
            //which min and max to show month
            targetMos.Visible = true;
            targetMos.Title.Text = "Current Max is " + info.Max.ToString() + " months";
            targetMos.Color = Color.Blue;
            targetMos.LineStyle.Thickness = 2;
            targetMos.LegendText = "Max";
            ((XYDiagram)chartMOS.Diagram).AxisY.ConstantLines.Add(targetMos);

            targetMosMin = new ConstantLine();
            targetMosMin.AxisValue = info.Min;
            //which min and max to show month
            targetMosMin.Visible = true;
            targetMosMin.Title.Text = "Current Min is " + info.Min.ToString() + " months";
            targetMosMin.Color = Color.Red;
            targetMosMin.LineStyle.Thickness = 2;
            targetMosMin.LegendText = "Max";
            ((XYDiagram)chartMOS.Diagram).AxisY.ConstantLines.Add(targetMosMin);
            //}

            // Generate the pie Chart for the Current SOH and EXpired Drugs

            ReceiveDoc rec = new ReceiveDoc();
            chartPie.Series.Clear();
            Items itm = new Items();
            object[] objExp = itm.GetExpiredQtyAmountItemsByID(_itemId, _storeId);
            Int64 expAmount = Convert.ToInt64(objExp[0]);
            Double expCost = Convert.ToDouble(objExp[1]);

            object[] nearObj = itm.GetNearlyExpiredQtyAmountItemsByID(_itemId, _storeId);
            Int64 nearExpAmount = Convert.ToInt64(nearObj[0]);
            double nearExpCost = Convert.ToDouble(nearObj[1]);

            Int64 soh = bal.GetSOH(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);
            double sohPrice = bal.GetSOHAmount(_itemId, _storeId, _dtCurrent.Month, _dtCurrent.Year);

            Int64 normal = (soh - nearExpAmount - expAmount);
            Int64 nearExpiry = nearExpAmount;
            Int64 expired = expAmount;


            object[] obj = { normal, nearExpiry, expired };

            DataTable dtSOHList = new DataTable();
            dtSOHList.Columns.Add("Type");
            dtSOHList.Columns.Add("Value");
            dtSOHList.Columns[1].DataType = typeof(Int64);
            double normalPrice = (sohPrice - nearExpCost - expAmount);


            object[] oo = { "Normal : " + normalPrice.ToString("C"), obj[0] };
            dtSOHList.Rows.Add(oo);

            object[] oo3 = { "Expired : " + expCost.ToString("C"), obj[2] };
            dtSOHList.Rows.Add(oo3);

            object[] oo2 = { "Near Expiry : " + nearExpCost.ToString("C"), obj[1] };
            dtSOHList.Rows.Add(oo2);



            Series serExpired = new Series("pie", ViewType.Pie3D);
            if (!(Convert.ToInt32(obj[0]) == 0 && Convert.ToInt32(obj[1]) == 0 && Convert.ToInt32(obj[2]) == 0))
            {
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
                // ((PiePointOptions)serExpired.PointOptions).Separator = " , ";
                chartPie.Series.Add(serExpired);
                chartPie.Size = new System.Drawing.Size(1000, 500);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            _year = Convert.ToInt32(cboYear.SelectedItem);
            int du = ((cboDU.SelectedValue != null) ? Convert.ToInt32(cboDU.SelectedValue) : 0);
            GenerateCharts(du);
            ItemStockStatus();
            //cboFiscalYear.SelectedItem = cboYear.SelectedItem;
            PopulateTransaction();
        }

        /// <summary>
        /// When the last 12 months check box is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckPast_CheckedChanged(object sender, EventArgs e)
        {
            // cboYear.SelectedItem = dtCurrent.Year;

            if (ckPast.Checked)
            {
                GenerateChartsPastMonths();
            }
            else
            {
                int du = ((cboDU.SelectedValue != null) ? Convert.ToInt32(cboDU.SelectedValue) : 0);
                GenerateCharts(du);
            }
        }

        /// <summary>
        /// Generates Past 12 Months charts
        /// </summary>
        private void GenerateChartsPastMonths()
        {
            Balance bal = new Balance();
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            DataTable dtList = new DataTable();
            DataTable dtAmc = new DataTable();
            DataTable dtMOS = new DataTable();
            DataTable dtIss = new DataTable();
            DataTable dtRec = new DataTable();
            DataTable dtBB = new DataTable();


            //foreach(string s in co)
            //{
            dtList.Columns.Add("Month");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);

            dtMOS.Columns.Add("Month");
            dtMOS.Columns.Add("Value");
            dtMOS.Columns[1].DataType = typeof(Int32);

            dtAmc.Columns.Add("Month");
            dtAmc.Columns.Add("Value");
            dtAmc.Columns[1].DataType = typeof(Int64);

            dtIss.Columns.Add("Month");
            dtIss.Columns.Add("Value");
            dtIss.Columns[1].DataType = typeof(Int64);

            dtRec.Columns.Add("Month");
            dtRec.Columns.Add("Value");
            dtRec.Columns[1].DataType = typeof(Int64);

            dtBB.Columns.Add("Month");
            dtBB.Columns.Add("Value");
            dtBB.Columns[1].DataType = typeof(Int64);

            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            DateTime dtPast = _dtCurrent.AddMonths(-11);
            //CALENDAR:
            string[] wer = { "Mes", "Tek", "Hed", "Tah", "Tir", "Yek", "Meg", "Miz", "Gen", "Sen", "Ham", "Neh" };
            string[] co = new string[12];
            int[] mon = new int[12];
            int[] yr = new int[12];
            int intialM = dtPast.Month;
            int j = 0;
            while (dtPast <= _dtCurrent && j < 12)
            {
                //mon[j] = intialM;
                //co[j] = wer[intialM-1];
                //yr[j] = (intialM < 11)?dtPast.Year: dtPast.Year +1;
                //dtPast = dtPast.AddMonths(1);
                //intialM = dtPast.Month;
                mon[j] = dtPast.Month;
                co[j] = wer[intialM - 1];
                yr[j] = dtPast.Year;
                dtPast = dtPast.AddMonths(1);
                intialM = dtPast.Month;
                j++;
            }
            //{ 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            long[] cons = new long[12];
            long[] amc = new long[12];
            DataTable dtBal = new DataTable();
            IssueDoc issd = new IssueDoc();
            Items recd = new Items();

            YearEnd yEnd = new YearEnd();
            Int64 bb = yEnd.GetBBalance(_year, _storeId, _itemId, 10);
            object[] objBB = { "Ham", bb };
            dtBB.Rows.Add(objBB);

            for (int i = 0; i < mon.Length; i++)
            {
                Int64 con = bal.GetSOH(_itemId, _storeId, mon[i], yr[i]);
                object[] str = { co[i], con };
                amc[i] = bal.CalculateAMC(_itemId, _storeId, mon[i], yr[i]);
                object[] objAmc = { co[i], amc[i] };
                decimal mos = (amc[i] > 0) ? (Convert.ToDecimal(con) / Convert.ToDecimal(amc[i])) : 0;
                mos = Decimal.Round(mos, 1);

                object[] objMos = { co[i], mos };
                Int64 issval = issd.GetIssuedQuantityByMonth(_itemId, _storeId, mon[i], yr[i]);
                object[] objIss = { co[i], issval };

                Int64 recVal = recd.GetQuantityReceiveByItemPerMonth(mon[i], _itemId, _storeId, yr[i]);
                object[] objrec = { co[i], recVal };

                dtList.Rows.Add(str);
                dtAmc.Rows.Add(objAmc);
                dtMOS.Rows.Add(objMos);
                dtIss.Rows.Add(objIss);
                dtRec.Rows.Add(objrec);
                //}
            }
            // string[] str = { ((cons[0] != 0) ? cons[0].ToString("") : "0"), ((cons[1] != 0) ? cons[1].ToString() : "0"), ((cons[2] != 0) ? cons[2].ToString() : "0"), ((cons[3] != 0) ? cons[3].ToString() : "0"), ((cons[4] != 0) ? cons[4].ToString() : "0"), ((cons[5] != 0) ? cons[5].ToString() : "0"), ((cons[6] != 0) ? cons[6].ToString() : "0"), ((cons[7] != 0) ? cons[7].ToString() : "0"), ((cons[8] != 0) ? cons[8].ToString() : "0"), ((cons[9] != 0) ? cons[9].ToString() : "0"), ((cons[10] != 0) ? cons[10].ToString() : "0"), ((cons[11] != 0) ? cons[11].ToString() : "0")};
            chartAmc.Series.Clear();
            chartComp.Series.Clear();
            chartBar.Series.Clear();
            chartMOS.Series.Clear();
            consuTrend.Series.Clear();

            Series ser = new Series("Stock On Hand", ViewType.Line);
            ser.DataSource = dtList;
            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Month";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            chartBar.Series.Add(ser);


            Series serB = new Series("Begining Balance", ViewType.Bar);
            serB.DataSource = dtBB;
            serB.ArgumentScaleType = ScaleType.Qualitative;
            serB.ArgumentDataMember = "Month";
            serB.ValueScaleType = ScaleType.Numerical;
            serB.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            serB.PointOptions.ValueNumericOptions.Precision = 0;
            serB.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serB);


            Series serRec = new Series("Received Qty", ViewType.Bar);
            serRec.DataSource = dtRec;
            serRec.ArgumentScaleType = ScaleType.Qualitative;
            serRec.ArgumentDataMember = "Month";
            serRec.ValueScaleType = ScaleType.Numerical;
            serRec.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serRec);



            Series serAmc = new Series("Average Monthly Consumption", ViewType.Line);
            serAmc.DataSource = dtAmc;
            serAmc.ArgumentScaleType = ScaleType.Qualitative;
            serAmc.ArgumentDataMember = "Month";
            serAmc.ValueScaleType = ScaleType.Numerical;
            serAmc.ValueDataMembers.AddRange(new string[] { "Value" });
            chartAmc.Series.Add(serAmc);

            Series serIss = new Series("Issue Qty", ViewType.Bar);
            serIss.DataSource = dtIss;
            serIss.ArgumentScaleType = ScaleType.Qualitative;
            serIss.ArgumentDataMember = "Month";
            serIss.ValueScaleType = ScaleType.Numerical;
            serIss.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serIss);


            Series serSOH = new Series("SOH", ViewType.Bar);
            serSOH.DataSource = dtList;
            serSOH.ArgumentScaleType = ScaleType.Qualitative;
            serSOH.ArgumentDataMember = "Month";
            serSOH.ValueScaleType = ScaleType.Numerical;
            serSOH.ValueDataMembers.AddRange(new string[] { "Value" });
            chartComp.Series.Add(serSOH);

            Series sercons = new Series("Consumption Trend", ViewType.Line);
            sercons.DataSource = dtIss;
            sercons.ArgumentScaleType = ScaleType.Qualitative;
            sercons.ArgumentDataMember = "Month";
            sercons.ValueScaleType = ScaleType.Numerical;
            sercons.ValueDataMembers.AddRange(new string[] { "Value" });
            consuTrend.Series.Add(sercons);

            Series serMos = new Series("Month Of Stock", ViewType.Line);
            serMos.DataSource = dtMOS;
            serMos.ArgumentScaleType = ScaleType.Qualitative;
            serMos.ArgumentDataMember = "Month";
            serMos.ValueScaleType = ScaleType.Numerical;
            serMos.ValueDataMembers.AddRange(new string[] { "Value" });

            chartMOS.Series.Add(serMos);
            ((XYDiagram)chartMOS.Diagram).AxisY.Range.MaxValue = 12;

            Int64 amcCurent = bal.CalculateAMC(_itemId, _storeId, _dtCurrent.Month, _year);
            //Int64 soh = bal.GetSOH(itemId,storeId,dtCurrent.Month,year);
            //if (bal.RowCount > 0)
            //{
            Int64 min = info.Min * amcCurent;
            Int64 max = info.Max * amcCurent;
            ConstantLine target = new ConstantLine();
            target.AxisValue = min;
            //which min and max to show month
            ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Clear();
            target.Visible = true;
            target.Title.Text = "Current Min value is " + target.AxisValue.ToString() + " " + lblBUnit.Text;
            target.Color = Color.Red;
            target.LineStyle.Thickness = 2;
            // ((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Add(target);

            ConstantLine targetMax = new ConstantLine();
            targetMax.AxisValue = max;
            //which min and max to show month
            targetMax.Visible = true;
            targetMax.Title.Text = "Current Max value is " + targetMax.AxisValue.ToString() + " " + lblBUnit.Text;
            targetMax.Color = Color.Blue;
            targetMax.LineStyle.Thickness = 2;
            //((XYDiagram)chartBar.Diagram).AxisY.ConstantLines.Add(targetMax);
            //}
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            //Graphics g1 = this.CreateGraphics();
            //Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            //Graphics g2 = Graphics.FromImage(MyImage);
            //IntPtr dc1 = g1.GetHdc();
            //IntPtr dc2 = g2.GetHdc();
            //BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            //g1.ReleaseHdc(dc1);
            //g2.ReleaseHdc(dc2);
            //MyImage.Save(@"c:\PrintPage.jpg", ImageFormat.Jpeg);
            //FileStream fileStream = new FileStream(@"c:\PrintPage.jpg", FileMode.Open, FileAccess.Read);
            //StartPrint(fileStream, "Image");
            //fileStream.Close();
            //if (System.IO.File.Exists(@"c:\PrintPage.jpg"))
            //{
            //    System.IO.File.Delete(@"c:\PrintPage.jpg");
            //}

            if (tabControl1.SelectedTabPageIndex == 1)
            {
                printableComponentLink1.Component = gridItemsList;
            }
            else if (tabControl1.SelectedTabPageIndex == 0)
            {
                //printableComponentLink1.Component = chartComp;
            }
            else if (tabControl1.SelectedTabPageIndex == 2)
            {
                printableComponentLink1.Component = chartBar;
            }
            else if (tabControl1.SelectedTabPageIndex == 3)
            {
                printableComponentLink1.Component = consuTrend;
            }
            else if (tabControl1.SelectedTabPageIndex == 4)
            {
                printableComponentLink1.Component = chartAmc;
            }
            else if (tabControl1.SelectedTabPageIndex == 5)
            {
                printableComponentLink1.Component = chartMOS;
            }
            else if (tabControl1.SelectedTabPageIndex == 6)
            {
                printableComponentLink1.Component = chartComp;
            }
            else if (tabControl1.SelectedTabPageIndex == 7)
            {
                printableComponentLink1.Component = chartPie;
            }
            else if (tabControl1.SelectedTabPageIndex == 8)
            {
                //printableComponentLink1.Component = chartComp;
            }
            else if (tabControl1.SelectedTabPageIndex == 9)
            {
                printableComponentLink1.Component = chartPie;
            }
            else
            {
                printableComponentLink1.Component = chartComp;
            }


            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();


        }

        /// <summary>
        /// For the printable component link, we are setting up a header.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            string[] header = { txtitmName.Text, "Date: " + dtDate.Text, " Basic Unit: " + lblBUnit.Text };
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
        }

        /// <summary>
        /// Starts printing
        /// </summary>
        /// <param name="streamToPrint">The stream that will be printed</param>
        /// <param name="streamType">The type of the stream</param>
        public void StartPrint(Stream streamToPrint, string streamType)
        {
            this.printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            this._streamToPrint = streamToPrint;
            this._streamType = streamType;
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

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(this._streamToPrint);
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

        private void DetailSoh()
        {
            //CALENDAR:
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = new DateTime();// Convert.ToDateTime(dtDate.Text);
            try
            {
                dtCurrent = Convert.ToDateTime(dtDate.Text);
            }
            catch
            {
                string dtValid = "";
                string yer = "";
                if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("12/30/" + yer);
                }
                else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("2/28/" + yer);
                }
            }

            ReceivingUnits du = new ReceivingUnits();
            DataTable dtDus = du.GetApplicableDUsAll(_itemId);
            int col = 0;
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStores = stor.DefaultView.ToTable();

            foreach (DataRow drStr in dtStores.Rows)
            {
                int storeId = Convert.ToInt32(drStr["ID"]);
                //Int64 soh = bal.GetSOH(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateAMC(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 issue = iss.GetIssuedQuantityByMonth(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);

                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? dtCurrent.Year - 1 : dtCurrent.Year;
                    if (!(yr == dtCurrent.Year && mon[i] > dtCurrent.Month && mon[i] < 11))
                    {

                        cons[i] = bal.GetSOH(_itemId, storeId, mon[i], yr);
                    }
                    else
                        cons[i] = 0;
                }

                string[] str = { drStr["StoreName"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);

                    col = 0;
                }
                else
                {
                    col++;
                }
                //lstTrendSoh.Items.Add(lstItm);
            }
            //lstTrendSoh.Items.Add(new ListViewItem());
            foreach (DataRow drDus in dtDus.Rows)
            {
                int duid = Convert.ToInt32(drDus["ID"]);
                //Int64 soh = bal.GetDUSOH(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateDUAMC(itemId, duid, dtCurrent.Month, dtCurrent.Year, 0);
                //Int64 issue = iss.GetDUIssueByMonth(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);
                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? dtCurrent.Year - 1 : dtCurrent.Year;
                    cons[i] = bal.GetDUSOH(_itemId, duid, mon[i], yr);
                }

                string[] str = { drDus["Name"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                // lstTrendSoh.Items.Add(lstItm);
            }
        }

        private void DetailAmc()
        {
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            ReceivingUnits du = new ReceivingUnits();
            DataTable dtDus = du.GetApplicableDUsAll(_itemId);
            int col = 0;
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStores = stor.DefaultView.ToTable();
            //lstTrendAmc.Items.Clear();
            foreach (DataRow drStr in dtStores.Rows)
            {
                int storeId = Convert.ToInt32(drStr["ID"]);
                //Int64 soh = bal.GetSOH(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateAMC(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 issue = iss.GetIssuedQuantityByMonth(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);

                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    if (!(yr == _dtCurrent.Year && mon[i] > _dtCurrent.Month && mon[i] < 11))
                    {

                        cons[i] = bal.CalculateAMC(_itemId, storeId, mon[i], yr);
                    }
                    else
                        cons[i] = 0;
                }

                string[] str = { drStr["StoreName"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);

                    col = 0;
                }
                else
                {
                    col++;
                }
                //lstTrendAmc.Items.Add(lstItm);
            }
            //lstTrendAmc.Items.Add(new ListViewItem());
            foreach (DataRow drDus in dtDus.Rows)
            {
                int duid = Convert.ToInt32(drDus["ID"]);
                //Int64 soh = bal.GetDUSOH(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateDUAMC(itemId, duid, dtCurrent.Month, dtCurrent.Year, 0);
                //Int64 issue = iss.GetDUIssueByMonth(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);
                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    if (!(yr == _dtCurrent.Year && mon[i] > _dtCurrent.Month && mon[i] < 11))
                    {
                        cons[i] = bal.CalculateDUAMC(_itemId, duid, mon[i], yr, 0);
                    }
                    else
                        cons[i] = 0;
                }

                string[] str = { drDus["Name"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                //  lstTrendAmc.Items.Add(lstItm);
            }
        }

        private void DetailConsumption()
        {
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //  DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            ReceivingUnits du = new ReceivingUnits();
            DataTable dtDus = du.GetApplicableDUsAll(_itemId);
            int col = 0;
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStores = stor.DefaultView.ToTable();
            //lstTrendCons.Items.Clear();
            foreach (DataRow drStr in dtStores.Rows)
            {
                int storeId = Convert.ToInt32(drStr["ID"]);
                //Int64 soh = bal.GetSOH(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateAMC(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 issue = iss.GetIssuedQuantityByMonth(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);

                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    if (!(yr == _dtCurrent.Year && mon[i] > _dtCurrent.Month && mon[i] < 11))
                    {

                        cons[i] = iss.GetIssuedQuantityByMonth(_itemId, storeId, mon[i], yr);
                    }
                    else
                        cons[i] = 0;
                }

                string[] str = { drStr["StoreName"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);

                    col = 0;
                }
                else
                {
                    col++;
                }
                // lstTrendCons.Items.Add(lstItm);
            }
            //  lstTrendCons.Items.Add(new ListViewItem());
            foreach (DataRow drDus in dtDus.Rows)
            {
                int duid = Convert.ToInt32(drDus["ID"]);
                //Int64 soh = bal.GetDUSOH(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateDUAMC(itemId, duid, dtCurrent.Month, dtCurrent.Year, 0);
                //Int64 issue = iss.GetDUIssueByMonth(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);
                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                long[] cons = new long[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    cons[i] = iss.GetDUIssueByMonth(_itemId, duid, mon[i], yr);
                }

                string[] str = { drDus["Name"].ToString(), ((cons[0] != 0) ? cons[0].ToString("#,###") : "0"), ((cons[1] != 0) ? cons[1].ToString("#,###") : "0"), ((cons[2] != 0) ? cons[2].ToString("#,###") : "0"), ((cons[3] != 0) ? cons[3].ToString("#,###") : "0"), ((cons[4] != 0) ? cons[4].ToString("#,###") : "0"), ((cons[5] != 0) ? cons[5].ToString("#,###") : "0"), ((cons[6] != 0) ? cons[6].ToString("#,###") : "0"), ((cons[7] != 0) ? cons[7].ToString("#,###") : "0"), ((cons[8] != 0) ? cons[8].ToString("#,###") : "0"), ((cons[9] != 0) ? cons[9].ToString("#,###") : "0"), ((cons[10] != 0) ? cons[10].ToString("#,###") : "0"), ((cons[11] != 0) ? cons[11].ToString("#,###") : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                // lstTrendCons.Items.Add(lstItm);
            }
        }

        private void DetailMos()
        {
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            // DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);           

            ReceivingUnits du = new ReceivingUnits();
            DataTable dtDus = du.GetApplicableDUsAll(_itemId);
            int col = 0;
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStores = stor.DefaultView.ToTable();
            //  lstTrendMos.Items.Clear();
            foreach (DataRow drStr in dtStores.Rows)
            {
                int storeId = Convert.ToInt32(drStr["ID"]);
                //Int64 soh = bal.GetSOH(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateAMC(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //Int64 issue = iss.GetIssuedQuantityByMonth(itemId, storeId, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);

                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                decimal[] cons = new decimal[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    if (!(yr == _dtCurrent.Year && mon[i] > _dtCurrent.Month && mon[i] < 11))
                    {
                        Int64 soh = bal.GetSOH(_itemId, storeId, mon[i], yr);
                        double amc = Builder.CalculateAverageConsumption(_itemId, _storeId,
                                                                        _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent,
                                                                        CalculationOptions.Monthly);
                        decimal mos = ((amc != 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                        cons[i] = Decimal.Round(mos, 1);
                    }
                    else
                        cons[i] = 0;
                }

                string[] str = { drStr["StoreName"].ToString(), ((cons[0] != 0) ? cons[0].ToString() : "0"), ((cons[1] != 0) ? cons[1].ToString() : "0"), ((cons[2] != 0) ? cons[2].ToString() : "0"), ((cons[3] != 0) ? cons[3].ToString() : "0"), ((cons[4] != 0) ? cons[4].ToString() : "0"), ((cons[5] != 0) ? cons[5].ToString() : "0"), ((cons[6] != 0) ? cons[6].ToString() : "0"), ((cons[7] != 0) ? cons[7].ToString() : "0"), ((cons[8] != 0) ? cons[8].ToString() : "0"), ((cons[9] != 0) ? cons[9].ToString() : "0"), ((cons[10] != 0) ? cons[10].ToString() : "0"), ((cons[11] != 0) ? cons[11].ToString() : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);

                    col = 0;
                }
                else
                {
                    col++;
                }
                //  lstTrendMos.Items.Add(lstItm);
            }
            //  lstTrendMos.Items.Add(new ListViewItem());
            foreach (DataRow drDus in dtDus.Rows)
            {
                int duid = Convert.ToInt32(drDus["ID"]);
                //Int64 soh = bal.GetDUSOH(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //Int64 amc = bal.CalculateDUAMC(itemId, duid, dtCurrent.Month, dtCurrent.Year, 0);
                //Int64 issue = iss.GetDUIssueByMonth(itemId, duid, dtCurrent.Month, dtCurrent.Year);
                //decimal mos = ((amc > 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                //mos = Decimal.Round(mos, 1);
                int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                decimal[] cons = new decimal[12];
                for (int i = 0; i < mon.Length; i++)
                {
                    int yr = (mon[i] > 10) ? _dtCurrent.Year - 1 : _dtCurrent.Year;
                    Int64 soh = bal.GetDUSOH(_itemId, duid, mon[i], yr);
                    double amc = Builder.CalculateAverageConsumption(_itemId, duid, _dtCurrent.Subtract(TimeSpan.FromDays(180)), _dtCurrent, CalculationOptions.Monthly);//bal.CalculateDUAMC(_itemId, duid, mon[i], yr, 0);
                    decimal mos = ((amc != 0) ? Convert.ToDecimal(soh) / Convert.ToDecimal(amc) : 0);
                    cons[i] = Decimal.Round(mos, 1);
                }

                string[] str = { drDus["Name"].ToString(), ((cons[0] != 0) ? cons[0].ToString() : "0"), ((cons[1] != 0) ? cons[1].ToString() : "0"), ((cons[2] != 0) ? cons[2].ToString() : "0"), ((cons[3] != 0) ? cons[3].ToString() : "0"), ((cons[4] != 0) ? cons[4].ToString() : "0"), ((cons[5] != 0) ? cons[5].ToString() : "0"), ((cons[6] != 0) ? cons[6].ToString() : "0"), ((cons[7] != 0) ? cons[7].ToString() : "0"), ((cons[8] != 0) ? cons[8].ToString() : "0"), ((cons[9] != 0) ? cons[9].ToString() : "0"), ((cons[10] != 0) ? cons[10].ToString() : "0"), ((cons[11] != 0) ? cons[11].ToString() : "0") };
                ListViewItem lstItm = new ListViewItem(str);

                if (col != 0)
                {
                    lstItm.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                // lstTrendMos.Items.Add(lstItm);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // grTrendAmc.Visible = !grTrendAmc.Visible;
            //if (grTrendAmc.Visible)
            //{
            //    lkDetailAmc.Text = "Hide Detail";
            //    DetailAmc();
            //}
            //else
            //    lkDetailAmc.Text = "Show Detail";
        }

        private void lkDetailMos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //grTrendMos.Visible = !grTrendMos.Visible;
            //if (grTrendMos.Visible)
            //{
            //    lkDetailMos.Text = "Hide Detail";
            //    DetailMos();
            //}
            //else
            //    lkDetailMos.Text = "Show Detail";
        }

        private void lkDetailCons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //grTrendCons.Visible = !grTrendCons.Visible;
            //if (grTrendCons.Visible)
            //{
            //    lkDetailCons.Text = "Hide Detail";
            //    DetailConsumption();
            //}
            //else
            //    lkDetailCons.Text = "Show Detail";
        }

        /// <summary>
        /// Based on the selected tab, we want to change the visibility of the controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = tabControl1.SelectedTabPageIndex;
            switch (selected)
            {
                case 1:
                    ckPast.Hide();
                    //cboYear.Hide();
                    cboDU.Hide();
                    break;
                case 0:
                    ckPast.Hide();
                    cboYear.Hide();
                    cboDU.Hide();
                    break;
                case 7:
                    ckPast.Hide();
                    cboYear.Hide();
                    cboDU.Hide();
                    break;
                case 8:
                    ckPast.Hide();
                    cboYear.Hide();
                    cboDU.Hide();
                    break;
                default:
                    ckPast.Show();
                    cboYear.Show();
                    cboDU.Show();
                    break;
            }
        }

        private void cboDU_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDU.SelectedValue != null && _first != 0)
            {
                int du = Convert.ToInt32(cboDU.SelectedValue);
                GenerateCharts(du);
            }
        }

        private void lkShowTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // groupSohDetail.Visible = !groupSohDetail.Visible;
            // lkShowTable.Text = ((groupSohDetail.Visible) ?"Hide Detail" : "Show Detail");
            //if(groupSohDetail.Visible)
            //    DetailSoh();

        }

        private void cboFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateBinCardNew();
        }
    }
}