using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraEditors;
using CommCtrl;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using PharmInventory.RRFLookUpService;
using PharmInventory.RRFTransactionService;
using PharmInventory.Reports;
using PharmInventory.RRFService;
using PharmInventory.HelperClasses;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using EthiopianDate;
using PharmInventory.ViewModels;
using Order = PharmInventory.RRFTransactionService.Order;

namespace PharmInventory.Forms.Reports
{
    public partial class RRFForm : XtraForm
    {
        private int _storeID;
        private int _requestedquantity;
        private int _fromYear;
        private int _toYear;
        private int _fromMonth;
        private int _toMonth;
        private int _programID;
        private DataTable tblRRF;
        private DataTable tblrrf;

        private bool _standardRRF = true;
        public const int ExpiryTreshHold =60;

        private const int STANDARD_ORDER = 1; //PLITS ID
        private const int EMERGENCY_ORDER = 2; //PLITS ID

        public RRFForm()
        {
            InitializeComponent();
        }

        private void RRFForm_Load(object sender, EventArgs e)
        {
            btnAutoPushToPFSA.Enabled = false;
            btnSendEmergencyOrder.Enabled = false;
            var unitcolumn = ((GridView) gridItemsChoice.MainView).Columns[2];
            var unitcolumn1 = ((GridView) gridItemsChoice.MainView).Columns[13];
            layoutControlItem18.Visibility =LayoutVisibility.Never;
            switch (VisibilitySetting.HandleUnits)
            {
                case 3:
                    unitcolumn.Visible = false;
                    unitcolumn1.Visible = true;
                    break;
                case 2:
                    unitcolumn.Visible = false;
                    unitcolumn1.Visible = true;
                    break;
                default:
                    unitcolumn.Visible = true;
                    unitcolumn1.Visible = false;
                    break;
            }

            var unit = new ItemUnit();
            var units = unit.GetAllUnits();
            unitsBindingSource.DataSource = units.DefaultView;

            var type = new BLL.Type();
            var alltypes = type.GetAllCategory();
            categorybindingSource.DataSource = alltypes.DefaultView;
            
            var program = new Programs();
            var programs = program.GetSubPrograms();
            cboProgram.Properties.DataSource = programs;
            cboProgram.Properties.DisplayMember = "Name";
            cboProgram.Properties.ValueMember = "ID";


            var orderstatus = new PharmInventory.HelperClasses.OrderStatus();
            orderbindingSource.DataSource = orderstatus.GetRRFOrders();
            lkorderstatus.Properties.DataSource = orderbindingSource;
            lkorderstatus.Properties.ValueMember = "RecordId";
            lkorderstatus.Properties.DisplayMember = "Name";

            PopulateTheMonthCombos(cboFromMonth);
            PopulateTheMonthCombos(cboToMonth);
            PopulateTheYearCombo(cboFromYear);
            PopulateTheYearCombo(cboToYear);
            var stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            PopulateRRFs();

            WindowVisibility(false);
            EnableDisableStatusCheck();

            var prog = new Programs();
            prog.GetSubPrograms();
            cboProgram.Properties.DataSource = prog.DefaultView;
            cboProgram.EditValue = 1000;

        }

        private void PopulateRRFs()
        {
            RRF rrf = new RRF();
            grdRRF.DataSource = rrf.GetSavedRRFForDisplay();
            tblrrf = rrf.GetSavedRRFForDisplay();
            grdRRF.RefreshDataSource();
        }

        private void SetEndingMonthAndYear(int startingMonth, int startingYear)
        {
            if (startingMonth <= 11)
            {
                cboToMonth.EditValue = startingMonth + 1;
                cboToYear.EditValue = startingYear;
            }

            else
                //If the starting month is the 12th month. (The period will be from Nehassie of last year - Meskerem of the next year)
            {
                cboToMonth.EditValue = 1;
                cboToYear.EditValue = startingYear + 1;
            }
        }

        private static int GetStartingMonth(int currentMonth)
        {
            int startingMonth;
            if (currentMonth > 2)
            {
                startingMonth = currentMonth - 2;
            }
            else
            {
                startingMonth = 12 - currentMonth - 1;
            }

            return startingMonth;
        }

        private static int GetStartingYear(int currentMonth, int currentYear)
        {
            if (currentMonth <= 2)
            {
                return currentYear - 1;
            }
            return currentYear;
        }


        private void PopulateList()
        {
            _storeID = Convert.ToInt32(cboStores.EditValue);
            _programID = Convert.ToInt32(cboProgram.EditValue);
            Items itm = new Items();

            _fromMonth = int.Parse(cboFromMonth.EditValue.ToString());
            _toMonth = int.Parse(cboToMonth.EditValue.ToString());
            _toYear = int.Parse(cboToYear.EditValue.ToString());
            _fromYear = int.Parse(cboFromYear.EditValue.ToString());

            if (_standardRRF && VisibilitySetting.HandleUnits == 1)
            {
                tblRRF = itm.GetRRFReportWithOutUnit(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            }

            else if (_standardRRF && VisibilitySetting.HandleUnits == 2)
            {
                tblRRF = itm.GetRRFReportByUnit(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            }

            else if (_standardRRF && VisibilitySetting.HandleUnits == 3)
            {
                tblRRF = itm.GetRRFReportByUnit(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            }
            else
            {
                tblRRF = itm.GetEmergencyRRFReport(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            }
            gridItemsChoice.DataSource = tblRRF;

            ChooseGridView();
        }


        private static void PopulateTheYearCombo(ComboBoxEdit combo)
        {
            int[] years = new int[25];
            for (int i = 0; i < 25; i++)
            {
                years[i] = 2003 + i;
            }
            combo.Properties.Items.AddRange(years);
        }


        private static void PopulateTheMonthCombos(ComboBoxEdit combo)
        {
            int[] months = new int[12];
            for (int i = 0; i < 12; i++)
            {
                months[i] = i + 1;
            }
            combo.Properties.Items.AddRange(months);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;
            PopulateList();
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //// TOFIX here,
            //// First day of 2003 is the first day of start of RRF
            //DateTime startDate = EthDate.EthiopianToGregorian("1/1/2003");
            //if (dtFrom.Value.Subtract(startDate).Days < 0)
            //{
            //    dtFrom.CustomFormat = "d/MM/yyyy";
            //    dtFrom.Value = startDate;
            //}
            //cboStores_SelectedValueChanged(null, null);
            //dtFrom.CustomFormat = "MMMM dd, yyyy";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (VisibilitySetting.HandleUnits == 3) chkCalculateInPacks.Enabled = false;
            chkCalculateInPacks.Checked = false;
            if (
                XtraMessageBox.Show("Are you sure you want to save and print the RRF?", "Confirm",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SaveRRF();
            var ginfo = new GeneralInfo();
            ginfo.LoadAll();
            var ethioDateFrom = new EthiopianDate.EthiopianDate(_fromYear, _fromMonth, 1);
            var ethioDateTo = new EthiopianDate.EthiopianDate(_toYear, _toMonth, 30);
            var rrfReport = new RRFReport
                                {
                                    FacilityName = {Text = ginfo.HospitalName},
                                    Period =
                                        {
                                            Text =
                                                string.Format("{0}, {1} - {2}, {3}", ethioDateFrom.GetMonthName(),
                                                              ethioDateFrom.Year, ethioDateTo.GetMonthName(),
                                                              ethioDateTo.Year)
                                        },
                                    ProgramName = {Text = cboProgram.Text},
                                    categoryName = {Text = lkCategory.Text}
                                };

            var tbl = ((DataView) gridItemChoiceView.DataSource).Table;
            tbl.TableName = "DataTable1";
            var dtset = new DataSet();
            dtset.Tables.Add(tbl.Copy());
            rrfReport.DataSource = dtset;
            if (Convert.ToInt32(cboProgram.EditValue) == 0 && Convert.ToInt32(lkCategory.EditValue) == 0)
            {
                rrfReport.ShowPreviewDialog();
            }
            else if(Convert.ToInt32(lkCategory.EditValue) != 0)
            {
                rrfReport.FilterString = String.Format("ProgramID={0} and TypeID ={1}", Convert.ToInt32(cboProgram.EditValue) ,Convert.ToInt32(lkCategory.EditValue));
                rrfReport.ShowPreviewDialog();
            }
            else
            {
                rrfReport.FilterString = String.Format("ProgramID={0}", Convert.ToInt32(cboProgram.EditValue));
                rrfReport.ShowPreviewDialog();
            }
           
        }

        private void btnAutoPushToPFSA_Click(object sender, EventArgs e)
        {
            var orders = GetStandardRRFOrders();
            var serviceModel = CompileOrder(orders);
            Send(serviceModel);

        }

        private List<Order> GetEmergencyRRFOrders()
        {
            var client = new ServiceRRFLookupClient();
            var orders = new List<Order>();
            var ginfo = new GeneralInfo();
            ginfo.LoadAll();
            var dataView = gridItemChoiceView.DataSource as DataView;
            if (dataView != null)
            {
                dataView.RowFilter = gridItemChoiceView.ActiveFilterString;
                tblRRF = dataView.ToTable();
            }
            var periods = client.GetCurrentReportingPeriod(ginfo.FacilityID, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var form = client.GetForms(ginfo.FacilityID, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var rrfs = client.GetFacilityRRForm(ginfo.FacilityID, form[0].Id, periods[0].Id, 2, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var formCategories = rrfs.First().FormCategories;
            var chosenCategoryBody = formCategories.First(x => x.Id == 1); //Hard coding to be removed.
            var items = chosenCategoryBody.Pharmaceuticals; //Let's just store the items here (May not be required)

            var user = new User();
            user.LoadByPrimaryKey(MainWindow.LoggedinId);

            var order = new RRFTransactionService.Order
            {
                RequestCompletedDate = DateTime.Now, //Convert.ToDateTime(rrf["DateOfSubmissionEth"]),
                OrderCompletedBy = user.FullName,
                RequestVerifiedDate = DateTime.Now,
                OrderTypeId = EMERGENCY_ORDER,
                SubmittedBy = user.FullName,
                SubmittedDate = DateTime.Now,
                SupplyChainUnitId = ginfo.FacilityID,
                OrderStatus = 2, //TODO: hardcoding
                FormId = form[0].Id, //TODO: hardcoding
                ReportingPeriodId = periods[0].Id //TODO: hardcoding
            };

            var details = new List<RRFTransactionService.OrderDetail>();

            foreach (DataRow rrfLine in tblRRF.Rows)
            {
                var detail = new RRFTransactionService.OrderDetail();
                var hcmisItemID = Convert.ToInt32(rrfLine["DSItemID"]);
                var rrFormPharmaceutical = items.SingleOrDefault(x => x.PharmaceuticalId == hcmisItemID);
                if (rrFormPharmaceutical != null && Convert.ToString(rrfLine["Status"]) == "Below EOP")
                {
                        detail.BeginningBalance = Convert.ToInt32(rrfLine["BeginingBalance"]);
                        detail.EndingBalance = Convert.ToInt32(rrfLine["SOH"]);
                        detail.QuantityReceived = Convert.ToInt32(rrfLine["Received"]);
                        detail.QuantityOrdered = Convert.ToInt32(rrfLine["Quantity"]);
                        detail.LossAdjustment = Convert.ToInt32(rrfLine["LossAdj"]);
                        detail.ItemId = rrFormPharmaceutical.ItemId;
                        var rdDoc = new ReceiveDoc();
                        var disposal = new Disposal();
                        rdDoc.GetAllWithQuantityLeft(hcmisItemID, _storeID);
                        disposal.GetLossAdjustmentsForLastRrfPeriod(hcmisItemID, _storeID, periods[0].StartDate, periods[0].EndDate);
                        int receiveDocEntries = rdDoc.RowCount;
                        int disposalEntries = disposal.RowCount;

                        if (rdDoc.RowCount == 0 && detail.EndingBalance == 0)
                            detail.Expiries = null;

                        detail.Expiries = new Expiry[receiveDocEntries];
                        detail.Adjustments = new Adjustment[disposalEntries];

                        rdDoc.Rewind();
                        int expiryAmountTotal = 0;

                        for (int j = 0; j < receiveDocEntries; j++)
                        {
                            var exp = new Expiry
                            {
                                Amount = Convert.ToInt32(rdDoc.QuantityLeft)
                            };
                            expiryAmountTotal += exp.Amount;

                            exp.BatchNo = rdDoc.BatchNo;
                            exp.ExpiryDate = rdDoc.ExpDate;
                            //if (expiryAmountTotal >= detail.EndingBalance)//ToDo:By Heny
                            //    exp.Amount = exp.Amount - (expiryAmountTotal - detail.EndingBalance.Value);
                            //if (exp.ExpiryDate > (periods[0].EndDate.AddMonths(ExpiryTreshHold)))
                            //    exp.ExpiryDate = periods[0].EndDate.AddMonths(ExpiryTreshHold - 1);
                            //exp.ExpiryDate = rdDoc.ExpDate;
                            //detail.Expiries[j] = exp;`
                            //rdDoc.MoveNext();
                            //if (exp.ExpiryDate < DateTime.Today)
                            //{
                            //    exp.Amount = Convert.ToInt32(rdDoc.QuantityLeft);
                            //    exp.ExpiryDate = rdDoc.ExpDate;
                            //}

                            if (exp.ExpiryDate > periods[0].EndDate.AddDays(ExpiryTreshHold))
                                exp.Amount = Convert.ToInt32(rdDoc.QuantityLeft);
                            exp.ExpiryDate = periods[0].EndDate;
                            detail.Expiries[j] = exp;
                            rdDoc.MoveNext();
                        }

                        disposal.Rewind();

                        int lossadjamt = 0;
                        for (int j = 0; j < disposalEntries; j++)
                        {
                            var adj = new Adjustment
                            {
                                Amount = Convert.ToInt32(disposal.Quantity),
                                TypeId = 1,
                                ReasonId = 1
                            };
                            lossadjamt += adj.Amount;

                            if (lossadjamt >= detail.LossAdjustment)
                                detail.LossAdjustment = lossadjamt;

                            detail.Adjustments[j] = adj;
                            disposal.MoveNext();
                        }

                        var stockoutIndexedLists = StockoutIndexBuilder.Builder.GetStockOutHistory(hcmisItemID, _storeID);
                        var DOSPerStockOut = stockoutIndexedLists.Count();
                        detail.DaysOutOfStocks = new DaysOutOfStock[stockoutIndexedLists.Count()];

                        for (int j = 0; j < stockoutIndexedLists.Count(); j++)
                        {
                            var dos = new DaysOutOfStock {NumberOfDaysOutOfStock = 5, StockOutReasonId = 5};
                            detail.DaysOutOfStocks[j] = dos;
                        }
                 }
                else if (rrFormPharmaceutical != null && Convert.ToString(rrfLine["Status"]) != "Below EOP")
                {
                        detail.BeginningBalance = null;
                        detail.EndingBalance = null;
                        detail.QuantityReceived = null;
                        detail.QuantityOrdered = null;
                        detail.LossAdjustment = null;

                        detail.ItemId = rrFormPharmaceutical.ItemId;

                        var rdDoc = new ReceiveDoc();
                        var disposal = new Disposal();
                        rdDoc.GetAllWithQuantityLeft(hcmisItemID, _storeID);
                        disposal.GetLossAdjustmentsForLastRrfPeriod(hcmisItemID, _storeID, periods[0].StartDate,
                                                                    periods[0].EndDate);
                        int receiveDocEntries = rdDoc.RowCount;
                        int disposalEntries = disposal.RowCount;

                        if (rdDoc.RowCount == 0 && detail.EndingBalance == 0)
                            detail.Expiries = null;

                        detail.Expiries = new Expiry[receiveDocEntries];
                        detail.Adjustments = new Adjustment[disposalEntries];

                        rdDoc.Rewind();
                        int expiryAmountTotal = 0;

                        for (int j = 0; j < receiveDocEntries; j++)
                        {
                            var exp = new Expiry
                            {
                                Amount = Convert.ToInt32(rdDoc.QuantityLeft)
                            };
                            expiryAmountTotal += exp.Amount;

                            exp.BatchNo = rdDoc.BatchNo;
                            exp.ExpiryDate = rdDoc.ExpDate;
                            //if (expiryAmountTotal >= detail.EndingBalance)//ToDo:By Heny
                            //    exp.Amount = exp.Amount - (expiryAmountTotal - detail.EndingBalance.Value);
                            //if (exp.ExpiryDate > (periods[0].EndDate.AddMonths(ExpiryTreshHold)))
                            //    exp.ExpiryDate = periods[0].EndDate.AddMonths(ExpiryTreshHold - 1);
                            //exp.ExpiryDate = rdDoc.ExpDate;
                            //detail.Expiries[j] = exp;`
                            //rdDoc.MoveNext();
                            //if (exp.ExpiryDate < DateTime.Today)
                            //{
                            //    exp.Amount = Convert.ToInt32(rdDoc.QuantityLeft);
                            //    exp.ExpiryDate = rdDoc.ExpDate;
                            //}
                            if (exp.ExpiryDate > periods[0].EndDate.AddDays(ExpiryTreshHold))
                                exp.Amount = Convert.ToInt32(rdDoc.QuantityLeft);
                            exp.ExpiryDate = periods[0].EndDate;
                            detail.Expiries[j] = null;
                            rdDoc.MoveNext();
                        }

                        disposal.Rewind();

                        int lossadjamt = 0;
                        for (int j = 0; j < disposalEntries; j++)
                        {
                            var adj = new Adjustment
                            {
                                Amount = Convert.ToInt32(disposal.Quantity),
                                TypeId = 11,
                                ReasonId = 39
                            };
                            lossadjamt += adj.Amount;

                            if (lossadjamt >= detail.LossAdjustment)
                                detail.LossAdjustment = lossadjamt;

                            detail.Adjustments[j] = null;
                            disposal.MoveNext();
                        }

                        var stockoutIndexedLists = StockoutIndexBuilder.Builder.GetStockOutHistory(hcmisItemID, _storeID);
                        var DOSPerStockOut = stockoutIndexedLists.Count();
                        detail.DaysOutOfStocks = new DaysOutOfStock[stockoutIndexedLists.Count()];

                        for (int j = 0; j < stockoutIndexedLists.Count(); j++)
                        {
                            var dos = new DaysOutOfStock
                                          {
                                              NumberOfDaysOutOfStock = 5,
                                              StockOutReasonId = 5
                                          };
                            detail.DaysOutOfStocks[j] = null;
                        }
                    }
                details.Add(detail);
            }
            order.OrderDetails = details.ToArray();
            orders.Add(order);
            // loop through each record and create order & order details objects
            return orders;
        }

        private int SaveRRF()
        {
            var rrf = new RRF();
            if (rrf.RRFExists(_storeID, _fromYear, _fromMonth, _toYear, _toMonth))
            {
                if (XtraMessageBox.Show("RRF Exists on disk, are you sure you want to replace it?", "RRF Save",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return -1;
            }
            var rrfID = rrf.AddNewRRF(_storeID, _fromYear, _fromMonth, _toYear, _toMonth, true);
            var dtbl1 = new DataTable();
            if (gridItemChoiceView.DataSource != null) dtbl1 = ((DataView) gridItemChoiceView.DataSource).Table;
            foreach (DataRow dr in dtbl1.Rows)
            {
                var itemID = Convert.ToInt32(dr["ID"]);
                var requestedqty = Convert.ToInt32(dr["Quantity"]);
                var storeID = int.Parse(cboStores.EditValue.ToString());
                var rrfDetail = new RRFDetail();
                rrfDetail.AddNewRRFDetail(rrfID, storeID, itemID, requestedqty);
            }

            return rrf.ID;
        }


        public List<Order> GetStandardRRFOrders()
        {
            var client = new ServiceRRFLookupClient();
            var orders = new List<Order>();
            var ginfo = new GeneralInfo();
            ginfo.LoadAll();

            var dataView = gridItemChoiceView.DataSource as DataView;
            if (dataView != null)
            {
                dataView.RowFilter = gridItemChoiceView.ActiveFilterString;
                tblRRF = dataView.ToTable();
            }

            var periods = client.GetCurrentReportingPeriod(ginfo.FacilityID, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var form = client.GetForms(ginfo.FacilityID, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);

            var rrfs = client.GetFacilityRRForm(ginfo.FacilityID, form[0].Id, periods[0].Id, 1, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var formCategories = rrfs.First().FormCategories;
            var chosenCategoryBody = formCategories.First(x => x.Id == 1); //TODO:Hard coding to be removed.
            var items = chosenCategoryBody.Pharmaceuticals;

            var user = new User();
            user.LoadByPrimaryKey(MainWindow.LoggedinId);

            var order = new Order
                            {
                                RequestCompletedDate = DateTime.Now, 
                                OrderCompletedBy = user.FullName,
                                RequestVerifiedDate = DateTime.Now,
                                OrderTypeId = STANDARD_ORDER,
                                SubmittedBy = user.FullName,
                                SubmittedDate = DateTime.Now,
                                SupplyChainUnitId = ginfo.FacilityID,
                                OrderStatus = 1, //TODO: hardcoding
                                FormId = form[0].Id, //TODO: hardcoding
                                ReportingPeriodId = periods[0].Id //TODO: hardcoding
                            };


            var details = new List<RRFTransactionService.OrderDetail>();

            foreach (DataRow rrfLine in tblRRF.Rows)
            {
                var detail = new RRFTransactionService.OrderDetail();
                var hcmisItemID = Convert.ToInt32(rrfLine["DSItemID"]);
                var rrFormPharmaceutical = items.SingleOrDefault(x => x.PharmaceuticalId == hcmisItemID);
                if (rrFormPharmaceutical != null && Convert.ToString(rrfLine["Status"]) != "Below EOP")
                {
                        detail.BeginningBalance = Convert.ToInt32(rrfLine["BeginingBalance"]);
                        detail.EndingBalance = Convert.ToInt32(rrfLine["SOH"]);
                        detail.QuantityReceived = Convert.ToInt32(rrfLine["Received"]);
                        detail.QuantityOrdered = Convert.ToInt32(rrfLine["Quantity"]);
                        detail.LossAdjustment = Convert.ToInt32(rrfLine["LossAdj"]);
                        detail.ItemId = rrFormPharmaceutical.ItemId;
                        var rdDoc = new ReceiveDoc();
                        var disposal = new Disposal();

                        rdDoc.GetAllWithQuantityLeft(hcmisItemID, _storeID);
                        disposal.GetLossAdjustmentsForLastRrfPeriod(hcmisItemID, _storeID, periods[0].StartDate,
                                                                    periods[0].EndDate);
                        int receiveDocEntries = rdDoc.RowCount;
                        int disposalEntries = disposal.RowCount;

                        if (rdDoc.RowCount == 0 && detail.EndingBalance == 0)
                            detail.Expiries = null;

                        detail.Expiries = new Expiry[receiveDocEntries];
                        detail.Adjustments = new Adjustment[disposalEntries];

                        rdDoc.Rewind();
                        int expiryAmountTotal = 0;

                        for (int j = 0; j < receiveDocEntries; j++)
                        {
                            var exp = new Expiry
                                          {
                                              Amount = Convert.ToInt32(rdDoc.QuantityLeft)
                                          };
                            expiryAmountTotal += exp.Amount;

                            exp.BatchNo = rdDoc.BatchNo;
                            exp.ExpiryDate = rdDoc.ExpDate;
                            if(exp.ExpiryDate > periods[0].EndDate.AddDays(ExpiryTreshHold))
                                exp.Amount = Convert.ToInt32(rdDoc.QuantityLeft);
                                exp.ExpiryDate = periods[0].EndDate;
                            detail.Expiries[j] = exp;
                            rdDoc.MoveNext();
                        }

                        disposal.Rewind();

                        int lossadjamt = 0;
                        for (int j = 0; j < disposalEntries; j++)
                        {
                            var adj = new Adjustment
                            {
                                Amount = Convert.ToInt32(disposal.Quantity),
                                TypeId = 1,
                                ReasonId = 1
                            };
                            lossadjamt += adj.Amount;

                            if (lossadjamt >= detail.LossAdjustment)
                                detail.LossAdjustment = lossadjamt;

                            detail.Adjustments[j] = adj;
                            disposal.MoveNext();
                        }

                        var stockoutIndexedLists = StockoutIndexBuilder.Builder.GetStockOutHistory(hcmisItemID, _storeID);
                        var DOSPerStockOut = stockoutIndexedLists.Count();
                        detail.DaysOutOfStocks = new DaysOutOfStock[stockoutIndexedLists.Count()];

                        for (int j = 0; j < stockoutIndexedLists.Count(); j++)
                        {
                            var dos = new DaysOutOfStock
                                          {
                                              NumberOfDaysOutOfStock = 5,
                                              StockOutReasonId = 5
                                          };
                            detail.DaysOutOfStocks[j] = dos;
                        }
                }
                else if(rrFormPharmaceutical != null && Convert.ToString(rrfLine["Status"]) == "Below EOP")
                {
                        detail.BeginningBalance = null;
                        detail.EndingBalance = null;
                        detail.QuantityReceived = null;
                        detail.QuantityOrdered = null;
                        detail.LossAdjustment = null;
                        detail.ItemId = rrFormPharmaceutical.ItemId;

                        var rdDoc = new ReceiveDoc();
                        var disposal = new Disposal();
                        rdDoc.GetAllWithQuantityLeft(hcmisItemID, _storeID);
                        disposal.GetLossAdjustmentsForLastRrfPeriod(hcmisItemID, _storeID, periods[0].StartDate,periods[0].EndDate);
                       
                        int receiveDocEntries = rdDoc.RowCount;
                        int disposalEntries = disposal.RowCount;

                        if (rdDoc.RowCount == 0 && detail.EndingBalance == 0)
                            detail.Expiries = null;

                        detail.Expiries = new Expiry[receiveDocEntries];
                        detail.Adjustments = new Adjustment[disposalEntries];

                        rdDoc.Rewind();
                        int expiryAmountTotal = 0;
                        for (int j = 0; j < receiveDocEntries; j++)
                        {
                            var exp = new Expiry {Amount = Convert.ToInt32(rdDoc.QuantityLeft)};
                            expiryAmountTotal += exp.Amount;

                            exp.BatchNo = rdDoc.BatchNo;
                            exp.ExpiryDate = rdDoc.ExpDate;
                            if (expiryAmountTotal >= detail.EndingBalance)
                                if (detail.EndingBalance != null)
                                    exp.Amount = exp.Amount - (expiryAmountTotal - detail.EndingBalance.Value);
                            detail.Expiries[j] = null;
                            rdDoc.MoveNext();
                        }

                        disposal.Rewind();

                        int lossadjamt = 0;
                        for (int j = 0; j < disposalEntries; j++)
                        {
                            var adj = new Adjustment
                            {
                                Amount = Convert.ToInt32(disposal.Quantity),
                                TypeId = 11,
                                ReasonId = 39
                            };
                            lossadjamt += adj.Amount;

                            if (lossadjamt >= detail.LossAdjustment)
                                detail.LossAdjustment = lossadjamt;

                            detail.Adjustments[j] = null;
                            disposal.MoveNext();
                        }

                        var stockoutIndexedLists = StockoutIndexBuilder.Builder.GetStockOutHistory(hcmisItemID, _storeID);
                        var DOSPerStockOut = stockoutIndexedLists.Count();
                        detail.DaysOutOfStocks = new DaysOutOfStock[stockoutIndexedLists.Count()];

                        for (int j = 0; j < stockoutIndexedLists.Count(); j++)
                        {
                            var dos = new DaysOutOfStock();
                            dos.NumberOfDaysOutOfStock = 5;
                            dos.StockOutReasonId = 5;
                            detail.DaysOutOfStocks[j] = null;
                        }
                 }
                details.Add(detail);
            }
            order.OrderDetails = details.ToArray();
            orders.Add(order);
            // loop through each record and create order & order details objects
            return orders;
        }

        /// Compiles a RRF Order that will be used by Send() method
        /// </summary>
        /// <returns>FacilityOrderViewModel</returns>
        private FacilityOrderViewModel CompileOrder(List<Order> orders)
        {
            var ginfo = new GeneralInfo();
            ginfo.LoadAll();
            var fOrder = new FacilityOrderViewModel
                             {
                                 FacilityID = ginfo.FacilityID,
                                 Username = ginfo.ScmsWSUserName,
                                 Password = ginfo.ScmsWSPassword,
                                 Orders = orders.ToArray()
                             };
            return fOrder;
        }

        private void Send(FacilityOrderViewModel fOrder)
        {
            var client = new ServiceOrderClient();
            var ginfo = new GeneralInfo();
            ginfo.LoadAll();
            var result = client.SubmitFacilityOrders(ginfo.FacilityID, fOrder.Orders, ginfo.ScmsWSUserName, ginfo.ScmsWSPassword);
            var submitResult = result.FirstOrDefault();

            if (submitResult != null && submitResult.OrderIsValid)
            {
                XtraMessageBox.Show("RRF's Sent Successfully", "Confirmation");
            }
            else
            {
                if (submitResult != null && submitResult.OrderIsValid ==false)
                {
                    var summary = new RRF_Send_Result { gridControl1 = { DataSource = submitResult.ValidationMessages } };
                    summary.ShowDialog();
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rrfID"></param>
        private void SendRRF(int rrfID)
        {
            // Do the webservice magic here.
            GeneralInfo ginfo = new GeneralInfo();
            ginfo.LoadAll();

            chkCalculateInPacks.Checked = false;
            ChooseGridView();

            if (ginfo.IsColumnNull("FacilityID"))
            {
                XtraMessageBox.Show("The Facility ID Was not set, Please correct that and try again.");
                return;
            }

            int facilityID = ginfo.FacilityID;
            int startMonth = Convert.ToInt32(cboFromMonth.EditValue);
            int endMonth = Convert.ToInt32(cboToMonth.EditValue); //startMonth + 1;
            int fromYear = Convert.ToInt32(cboFromYear.EditValue);
            int toYear = Convert.ToInt32(cboToYear.EditValue);


            bool check;
            RRFService.ServiceSoapClient sc = new RRFService.ServiceSoapClient();
            try
            {
                check = sc.RRFExists(facilityID, toYear, startMonth, endMonth);
            }
            catch
            {
                XtraMessageBox.Show("There was a network Error, Please connect to the internet and try again.",
                                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (check)
            {
                check =
                    (XtraMessageBox.Show(
                        "Another Report has been submitted for the period you specified, Are you sure you would like to overwrite it?",
                        "Confirm Overwritting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                     System.Windows.Forms.DialogResult.Yes);
            }

            if (!check)
            {
                RRFService.RrfSubmission rsubmission = new RrfSubmission
                                                           {
                                                               StartMonth = startMonth,
                                                               EndMonth = endMonth,
                                                               Year = toYear,
                                                               FacilityId = facilityID,
                                                               FacilityName = ginfo.HospitalName,
                                                               Items = new List<RRFItem>()
                                                           };

                DataTable dtbl = ((DataView) gridItemChoiceView.DataSource).Table;

                foreach (DataRow dr in dtbl.Rows)
                {
                    BLL.Items item = new Items();
                    item.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));

                    if (!item.MappingID.HasValue)
                    {
                        continue;
                    }

                    RRFService.RRFItem itm = new RRFService.RRFItem()
                                                 {
                                                     ItemID = item.MappingID.Value //  Convert.ToInt32(dr["ID"])
                                                     ,
                                                     BBalance = Convert.ToInt32(dr["BeginingBalance"])
                                                     ,
                                                     EBalance = Convert.ToInt32(dr["SOH"])
                                                     ,
                                                     Consumption = Convert.ToInt32(dr["Issued"])
                                                     ,
                                                     LossAdjustment = Convert.ToInt32(dr["LossAdj"])
                                                     ,
                                                     Max = Convert.ToInt32(dr["Max"])
                                                     ,
                                                     Received = Convert.ToInt32(dr["Received"])
                                                     ,
                                                     Requested = Convert.ToInt32(dr["Quantity"])
                                                 };

                    rsubmission.Items.Add(itm);
                }

                sc = new RRFService.ServiceSoapClient();
                try
                {
                    rsubmission.ReportedBy = "";
                    if (sc.SubmitRRF(rsubmission))
                    {
                        XtraMessageBox.Show("The Request has been submitted to PFSA.", "Confirmation",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RRF rrf = new RRF();
                        rrf.LoadByPrimaryKey(rrfID);
                        rrf.DateOfSubmission = DateTime.Now;
                        rrf.LastRRFStatus = CheckRRFStatus(rrf.ID);
                        rrf.Save();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            ProgressCheckingVisibility(true);
            btnCheckStatus.Enabled = false;
            bwRRFStatusCheck.RunWorkerAsync();
        }

        private void ProgressCheckingVisibility(bool visible)
        {
            lcCheckingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void ProgressSubmitVisibility(bool visible)
        {
            lcSendingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private static string CheckRRFStatus(int rrfID)
        {
            GeneralInfo ginfo = new GeneralInfo();
            ginfo.LoadAll();

            if (ginfo.IsColumnNull("FacilityID"))
            {
                XtraMessageBox.Show("The Facility ID was not set, Please correct that and try again.");
                return "Unknown";
            }

            int facilityID = ginfo.FacilityID;
            RRF rrf = new RRF();
            rrf.LoadByPrimaryKey(rrfID);
            int startMonth = rrf.FromMonth; //Convert.ToInt32(cboFromMonth.EditValue);
            int endMonth = rrf.ToMonth; //Convert.ToInt32(cboToMonth.EditValue);
            //TODO: The Server side RRF reception will also have to handle the From/To Year values.
            int toYear = rrf.ToYear; //Convert.ToInt32(cboToYear.EditValue);
            int fromYear = rrf.FromYear; //Convert.ToInt32(cboFromYear.EditValue);

            RRFService.ServiceSoapClient sc = new RRFService.ServiceSoapClient();
            try
            {
                string rrfStatus = sc.GetRRFStatus(facilityID, toYear, startMonth, endMonth);
                    //TODO: The service as well needs to handle the From/To year value
                rrf.LastRRFStatus = rrfStatus;
                rrf.Save();
                return rrfStatus;
            }
            catch
            {
                XtraMessageBox.Show("There was a network Error, Please connect to the internet and try again.",
                                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
        }

        private void chkCalculateInPacks_CheckedChanged(object sender, EventArgs e)
        {
            ChooseGridView();
        }

        private void ChooseGridView()
        {

                    if (chkCalculateInPacks.Checked && lkCategory.EditValue == null && cboProgram.EditValue == null)
                    {
                        gridItemsChoice.MainView = grdViewInPacks;
                    }

                    else if (chkCalculateInPacks.Checked && lkCategory.EditValue != DBNull.Value &&
                             cboProgram.EditValue == null)
                    {
                        gridItemsChoice.MainView = grdViewInPacks;
                        grdViewInPacks.ActiveFilterString = String.Format("TypeID={0}",
                                                                          Convert.ToInt32(lkCategory.EditValue));
                    }
                    else if (chkCalculateInPacks.Checked && cboProgram.EditValue != DBNull.Value &&
                             lkCategory.EditValue == null)
                    {
                        gridItemsChoice.MainView = grdViewInPacks;
                        grdViewInPacks.ActiveFilterString = String.Format("ProgramID={0}",
                                                                          Convert.ToInt32(cboProgram.EditValue));
                    }

                    else if (chkCalculateInPacks.Checked && lkCategory.EditValue != null &&
                             cboProgram.EditValue != null)
                    {
                        gridItemsChoice.MainView = grdViewInPacks;
                        grdViewInPacks.ActiveFilterString = String.Format("TypeID={0} and ProgramID={1}",
                                                                          Convert.ToInt32(lkCategory.EditValue),
                                                                          Convert.ToInt32(cboProgram.EditValue));
                    }
                    else gridItemsChoice.MainView = gridItemChoiceView;
        }

        private void cboFromYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void cboFromMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void grdRRF_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grdViewRRFList.GetFocusedDataRow();
            if (dr == null)
                return;
            int rrfID = Convert.ToInt32(dr["ID"]);
            ShowRRFDetailWindow(rrfID);
            WindowVisibility(true);
        }

        private void ShowRRFDetailWindow(int rrfID)
        {
            Cursor = Cursors.WaitCursor;
            RRF rrf = new RRF();
            rrf.LoadByPrimaryKey(rrfID);
            cboFromMonth.EditValue = rrf.FromMonth;
            cboFromYear.EditValue = rrf.FromYear;
            cboToMonth.EditValue = rrf.ToMonth;
            cboToYear.EditValue = rrf.ToYear;
            cboStores.EditValue = rrf.RRFType;
            PopulateList();
           // Handle Edits here (Populate exact values from the database)
            if (!rrf.IsColumnNull("LastRRFStatus"))
            {
                if (rrf.LastRRFStatus == "" || rrf.LastRRFStatus.Contains("not") || rrf.LastRRFStatus.Contains("Not"))
                    btnAutoPushToPFSA.Enabled = false;
                }
            else
                btnAutoPushToPFSA.Enabled = false;
            Cursor = Cursors.Default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WindowVisibility(false);
        }

        private void WindowVisibility(bool rrfDetailVisible)
        {
            if (rrfDetailVisible)
            {
                lcRRFInformation.Visibility = LayoutVisibility.Always;
                lcRRFList.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcRRFInformation.Visibility = LayoutVisibility.Never;
                lcRRFList.Visibility = LayoutVisibility.Always;
            }

        }

        private void btnNewRRF_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var ethiopianDate = new EthiopianDate.EthiopianDate();
            int currentMonth = ethiopianDate.Month;
            int currentYear = ethiopianDate.Year;
            int startingMonth = GetStartingMonth(currentMonth);
            int startingYear = GetStartingYear(currentMonth, currentYear);
            cboFromMonth.EditValue = startingMonth;
            cboFromYear.EditValue = startingYear;
            SetEndingMonthAndYear(startingMonth, startingYear);
            cboStores.ItemIndex = 0;
            WindowVisibility(true);
            Cursor = Cursors.Default;

        }

        private void grdRRF_Click(object sender, EventArgs e)
        {
            EnableDisableStatusCheck();
        }

        private void EnableDisableStatusCheck()
        {
            try
            {

                btnCheckStatus.Enabled = grdViewRRFList.GetFocusedDataRow()["LastRRFStatus"].ToString() !=
                                         "Order Dispatched";
            }
            catch
            {
                btnCheckStatus.Enabled = false;
            }
        }

        private void bwRRFStatusCheck_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int rrfID = int.Parse(grdViewRRFList.GetFocusedDataRow()["ID"].ToString());
            string rrfStatus = CheckRRFStatus(rrfID);
            e.Result = rrfStatus;
        }

        private void bwRRFStatusCheck_RunWorkerCompleted(object sender,
                                                         System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnCheckStatus.Enabled = true;
            ProgressCheckingVisibility(false);

            if (e.Result.ToString() != "")
            {
                XtraMessageBox.Show(e.Result.ToString(), "RRF Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PopulateRRFs();
        }

        private void bwRRFSubmit_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void bwRRFSubmit_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //ProgressSubmitVisibility(false);
            //btnAutoPushToPFSA.Enabled = true;
        }

        private void cboProgram_EditValueChanged(object sender, EventArgs e)
        {
            if (lkCategory.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("ProgramID={0}",
                                                                      Convert.ToInt32(cboProgram.EditValue));
            }
            else if(lkCategory.EditValue !=null)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and ProgramID ={1}", Convert.ToInt32(lkCategory.EditValue),Convert.ToInt32(cboProgram.EditValue));
            }
        }


        private void gridItemChoiceView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn40")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
            if (e.Column.FieldName == "BeginingBalance")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
        }

        private void grdViewInPacks_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn41")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
            if (e.Column.FieldName == "gridColumn13")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
        }


        private void btnSendEmergencyOrder_Click(object sender, EventArgs e)
        {
            var orders = GetEmergencyRRFOrders();
            var serviceModel = CompileOrder(orders);
            Send(serviceModel);

        }

        private void lkCategory_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProgram.EditValue == null)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}",Convert.ToInt32(lkCategory.EditValue));
            }
            else if (cboProgram.EditValue != null)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("ProgramID={1} and TypeID={0}",Convert.ToInt32(lkCategory.EditValue), Convert.ToInt32(cboProgram.EditValue));
            }
        }

        private void lkorderstatus_EditValueChanged(object sender, EventArgs e)
        {
            if((int)lkorderstatus.EditValue==1)
            {
                btnAutoPushToPFSA.Enabled = true;
                btnSendEmergencyOrder.Enabled = false;
            }
            else if ((int)lkorderstatus.EditValue == 2)
            {
                btnSendEmergencyOrder.Enabled = true;
                btnAutoPushToPFSA.Enabled = false;
            }
        }

    }
}


