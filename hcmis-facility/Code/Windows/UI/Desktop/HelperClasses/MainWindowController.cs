using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.Forms.ActivityLogs;
using PharmInventory.Forms.Modals;
using PharmInventory.Forms.Profiles;
using PharmInventory.Forms.Reports;
using PharmInventory.Forms.Transactions;
using PharmInventory.Forms.Trends;
using PharmInventory.Forms.UtilitiesAndForms;
using System;
using PharmInventory.HelperClasses;


namespace PharmInventory
{
    partial class MainWindow
    {
        /// <summary>
        /// Shows or hides menu items based on the rights of the user
        /// </summary>
        private void ShowAccessLevel()
        {
            LoggedinId = _userId;
            User us = new User();
            us.LoadByPrimaryKey(_userId);
            int usType = us.UserType;
            IsAdmin = false;
            switch (usType)
            {
                case 1://Reader
                    menuStrip2.Items[0].Visible = true;
                    menuStrip2.Items[1].Visible = false;
                    menuStrip2.Items[2].Visible = true;
                    menuStrip2.Items[3].Visible = true;
                    menuStrip2.Items[4].Visible = false;
                    menuStrip2.Items[5].Visible = false;
                    menuStrip2.Items[6].Visible = false;
                    menuStrip2.Items[7].Visible = true;
                    navBarFacilitySettings.Visible = false;
                    navBarPipeline.Visible = false;
                    break;
                case 2://Editor
                    menuStrip2.Items[0].Visible = true;
                    menuStrip2.Items[1].Visible = true;
                    menuStrip2.Items[2].Visible = true;
                    menuStrip2.Items[3].Visible = true;
                    menuStrip2.Items[4].Visible = true;
                    menuStrip2.Items[5].Visible = false;
                    menuStrip2.Items[6].Visible = false;
                    menuStrip2.Items[7].Visible = true;
                    navBarFacilitySettings.Visible = false;
                    navBarPipeline.Visible = false;
                    break;
                case 4://Hospital Admin
                    menuStrip2.Items[0].Visible = true;
                    menuStrip2.Items[1].Visible = true;
                    menuStrip2.Items[2].Visible = true;
                    menuStrip2.Items[3].Visible = true;
                    menuStrip2.Items[4].Visible = true;
                    menuStrip2.Items[5].Visible = false;
                    menuStrip2.Items[6].Visible = false;
                    menuStrip2.Items[7].Visible = true;
                    navBarFacilitySettings.Visible = true;
                    navBarPipeline.Visible = true;
                    break;
                case 5://System Admin
                    IsAdmin = true;
                    menuStrip2.Items[0].Visible = true;
                    menuStrip2.Items[1].Visible = true;
                    menuStrip2.Items[2].Visible = true;
                    menuStrip2.Items[3].Visible = true;
                    menuStrip2.Items[4].Visible = true;
                    menuStrip2.Items[5].Visible = true;
                    menuStrip2.Items[6].Visible = true;
                    menuStrip2.Items[7].Visible = true;
                    navBarFacilitySettings.Visible = true;
                    navBarPipeline.Visible = true;
                    break;
            }

            //Form f = null;
            //f = new ReceivingForm();
            //AddTab("Receiving Form", f);

            
            LoadForm("Receives");
            


            // toolStripStatusLabel1.Text = "Logged in as " + us.FullName;
            this.Visible = true;
        }

        /// <summary>
        /// Loads a form to the panel
        /// </summary>
        /// <param name="tag">The tag of the button - Here is stored what type of form is supposed to be opened</param>
        private void LoadForm(string tag)
        {
            var yEnd = new YearEnd();
            if (yEnd.InventoryRequired(false))
            {
                switch (VisibilitySetting.HandleUnits)
                {
                    case 1:
                        yEnd.GenerateAutomaticInventory();
                        break;
                    case 2:
                        yEnd.GenerateAutomaticInventoryByUnit();
                        break;
                    case 3:
                        yEnd.GenerateAutomaticInventoryByUnit();
                        break;
                }
            }
            
            Form frm;
            switch (tag)
            {
                case "Receives":
                    frm = new ReceivingForm();
                    AddTab("Receiving Form", frm);
                    break;
                case "Issues":
                    frm = new IssueForm();
                    AddTab("Issue Form", frm);
                    break;
                case "AMCs":
                    frm = new AMCView();
                    AddTab("AMC Report", frm);
                    break;
                case "menuItemPriceOnlyReport":
                    frm = new ItemPriceOnlyReport();
                    AddTab("Item Price Only", frm);
                    break;
                case "stockoutindexer":
                    frm = new StockOutIndicesBuilder();
                    AddTab("Stockout Indices Builder",frm);
                    break;
                case "Facility Settings":
                    frm = new Hospital();
                    AddTab("Facility Settings", frm);
                    break;
                case "Drug List":
                    frm = new ManageItems();
                    AddTab("Manage Drug List", frm);
                    break;
                case "Supplies List":
                    //frm = new ManageItems();
                    frm = new ManageSupplies();
                    AddTab("Manage Supplies List", frm);
                    break;
               case "Item Consolidator":
                    //frm = new ManageItems();
                    frm = new ItemConsolidator();
                    AddTab("Update Items List From The Directory Service", frm);
                    break;
              
                case "Customize Druglist":
                    frm = new CustomDrugList();
                    AddTab("Customize Drug List", frm);
                    break;
                case "System Settings":
                    frm = new SystemSetting();
                    AddTab("System Settings", frm);
                    break;
                case "Facility Details":
                    frm = new HospitalSettings();
                    AddTab("Facility Details", frm);
                    break;
                case "User Accounts":
                    frm = new UserAccounts();
                    AddTab("Manage Users", frm);
                    break;
                case "Pipeline":
                    frm = new Pipeline();
                    AddTab("Pipeline", frm);
                    break;
                case "Change Password":
                    frm = new ChangePassword(UserId);
                    AddTab("Change Password", frm);
                    break;
                    break;
                case "Transfer Log":
                    frm = new LogTransfer();
                    AddTab("Transfer Log", frm);
                    break;
                case "Losses/Adjustment":
                    frm = new LossesAdjustment();
                    AddTab("Losses and Adjustment", frm);
                    break;
                case "Receive Log":
                    frm = new LogReceive();
                    AddTab("Receive Transaction Log", frm);
                    break;
                case "Issue Log":
                    frm = new LogIssues();
                    AddTab("Issue Transaction Log", frm);
                    break;
                case "Adjustment Log":
                    frm = new LogAdjustment();
                    AddTab("Loss / Adjustment Transaction Log", frm);
                    break;
                case "Inventory Log":
                    frm = new LogInventory();
                    AddTab("Inventory Log", frm);
                    break;
                case "Stock Status":
                    frm = new ItemReport();
                    AddTab("Stock Status", frm);
                    break;
                case "Over Stocked":
                    frm = new OtherItemReport("Over Stocked");
                    AddTab("Over Stock Items", frm);
                    break;
                case "Transfers":
                    frm = new TransferForm();
                    AddTab("Transfer Form", frm);
                    break;
                case "Stock Out":
                    frm = new OtherItemReport("Stock Out");
                    AddTab("Stocked Out Items", frm);
                    break;
                case "ConsumptionTrend":
                    frm = new ConsumptionTrendReport();
                    AddTab("Consumption Trend", frm);
                    break;
                case "Issues By Receiving Unit":
                    frm = new IssuesByDep();
                    AddTab("Issues By Receiving Unit", frm);
                    break;
                case "Expired Products":
                    frm = new ExpiredProducts();
                    AddTab("Expired Products", frm);
                    break;
                case "Near Expiry":
                    frm = new NearlyExpired();
                    AddTab("Near Expiry Products", frm);
                    break;
                case "SOH Trend":
                    frm = new SOHTrend();
                    AddTab("SOH Trend", frm);
                    break;
                case "Receive Trend":
                    frm = new ReceiveTrend();
                    AddTab("Receive Trend", frm);
                    break;
                case "Balance":
                    frm = new BalanceReport();
                    AddTab("Balance", frm);
                    break;
                case "Summary Report":
                    frm = new GeneralReport();
                    AddTab("Summary Report", frm);
                    break;
                case "Cost Summary":
                    frm = new GeneralCostChart();
                    AddTab("Cost Summary", frm);
                    break;
                case "Summary Chart":
                    frm = new GeneralChart();
                    AddTab("General Chart", frm);
                    break;
                case "ECLS":
                    frm = new ECLS();
                    AddTab("CS Stock Status", frm);
                    break;
                case "Year End Process":
                    frm = new YearEndProcess();
                    AddTab("Inventory", frm);
                    break;
                case "Default Year End Process":
                    frm = new YearEndProcess(true);
                    AddTab("Inventory", frm);
                    break;
                case "Stock Expiry Status":
                    frm = new GeneralExpiryChart();
                    AddTab("Stock Expiry Status", frm);
                    break;
                case "DataBase":
                    frm = new DatabaseActions();
                    AddTab("Database Actions", frm);
                    break;
                case "PDA":
                    frm = new ItemReport();
                    AddTab("Stock Status", frm);
                    break;
                case "Consumables List":
                    frm = new ManageSupplies();
                    AddTab("Supplies List", frm);
                    break;
                case "RRF Form":
                    frm = new RRFForm();
                    AddTab("Report and Requisition Form", frm);
                    break;
                case "LossReport":
                    frm = new ExpiredProductsReport();
                    AddTab("Loss / Adjustment Reporting View", frm);
                    break;
                case "CostReport":
                    frm = new CostReport();
                    AddTab("Cost Report", frm);
                    break;
                case "ConsumptionByUnit" :
                    frm = new ConsumptionByUnits();
                    AddTab("Consumption By Dispensary Unit", frm);
                    break;
                case "About":
                    Program.ShowHCMISVersionInfoMessageBox();
                    break;

            }
        }



        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // MainWindow
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Name = "MainWindow";
        //    this.Load += new System.EventHandler(this.MainWindow_Load);
        //    this.ResumeLayout(false);

        //}

        //private void MainWindow_Load(object sender, System.EventArgs e)
        //{

        //}
    }
}
