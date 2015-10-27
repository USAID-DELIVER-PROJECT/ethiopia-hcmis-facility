using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction logic for the ItemReport form
    /// </summary>
    public partial class ConsumptionByUnits : XtraForm
    {
        public ConsumptionByUnits()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Initialilze the form with a filter on the grid
        /// </summary>
        /// <param name="fltr"></param>
        public ConsumptionByUnits(string fltr)
        {
            InitializeComponent();
            _filter = fltr;
        }

        readonly string _filter = "All";
        int _catId = 0;
        DateTime _dtCur = new DateTime();
        String _selectedType = "Drug";
        bool _isReady = false;

        /// <summary>
        /// Loads the form and loads the lookups and the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            //CALENDAR:
            PopulateCatTree(_selectedType);

            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.EditValue = 0;


            string[] arr = new string[] {"All", "Stock Out", "Below EOP", "Near EOP", "Normal", "Over Stocked"};
            cboIssuedTo.Properties.DataSource = arr;

            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = _dtCur.Month;
            //int year = ((currentMont < 11) ? _dtCur.Year : _dtCur.Year + 1);
            int year = _dtCur.Year;
            // this is just a try
            //if (currentMont >= 11)
            //{
            //    currentMont -= 11;
            //}

            
            DataTable dtyears = Items.AllYears();
            //if (year == _dtCur.Year + 1)
            //{
            //    object[] objYear = { year };
            //    dtyears.Rows.Add(objYear);
            //}
            cboYear.Properties.DataSource = dtyears;
            cboYear.EditValue = year;
            if(cboYear.Properties.Columns.Count > 0) 
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
            

            //Programs prog = new Programs();
            //DataTable dtProg = prog.GetSubPrograms();
            //object[] objProg = { 0, "All Programs", "", 0, "" };
            //dtProg.Rows.Add(objProg);
            //cboSubProgram.Properties.DataSource = dtProg;
            //cboSubProgram.ItemIndex = -1;
            //cboSubProgram.Text = "Select Program";

            ReceivingUnits rec = new ReceivingUnits();
            DataTable drRec = rec.GetAllApplicableDU();
            cboDUnits.Properties.DataSource = drRec;
            cboDUnits.Properties.DisplayMember = "Name";
            cboDUnits.Properties.ValueMember = "ID";
            cboDUnits.EditValue = 1;

            this._isReady = true;
            PopulateGrid();
        }

        /// <summary>
        /// Populate the items grid using the background worker
        /// </summary>
        private void PopulateGrid()
        {
            if (!_isReady)
                return;

            if ((cboYear.EditValue == null) ||  (cboStores.EditValue == null))
                return;

            int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
            int year = Convert.ToInt32(cboYear.EditValue);

            // different criteria for different options like suply and drug
           // int programID = ((cboSubProgram.EditValue != null) ? Convert.ToInt32(cboSubProgram.EditValue) : 0);

            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync(new int[] { storeId, year, 0 });
            }
        }

        /// <summary>
        /// Populate the tree category (Drugs or Supply Category)
        /// </summary>
        /// <param name="type">"Drug" - Gets Categories, Otherwise, SupplyCategories are loaded</param>
        private void PopulateCatTree(String type)
        {
            if (type == "Drug")
            {
                Category cat = new Category();
                treeCategory.DataSource = cat.GetCategoryTree();
            }
            else
            {
                SupplyCategory subCat = new SupplyCategory();
                treeCategory.DataSource = subCat.GetAllSupplyCategories();
            }
        }

        /// <summary>
        /// Handles the click event of the treeCategory object and updates the form according to the value of the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));
            _catId = categoryId;
            Items itm = new Items();
            string filterString = "";
            string isStock = "";
            //if (ckExcNeverIssued.Checked)
            //    isStock = "[EverReceived] != '0' AND [Issued] != 0 AND ";
            //else 
                if (ckExclude.Checked)
                    isStock = "[EverReceived] != '0' AND ";
            else
                isStock = "";
            
            switch (value.Substring(0, 1))
            {
                case "S":
                    filterString = isStock + "[SubCategoryID] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;
                    // toolStripButtonAddItems.Enabled = true;
                    break;
                case "C":
                case "U":
                    filterString = isStock + "[CategoryId] = " + categoryId.ToString();
                    gridItemChoiceView.ActiveFilterString = filterString;
                    //toolStripButtonAddItems.Enabled = false;
                    break;
                case "P":
                    gridItemChoiceView.ActiveFilterString =  isStock;
                    // toolStripButtonAddItems.Enabled = false;
                    break;
            }
            //lblState.Text = treeCategory.Selection[0].GetValue("Name").ToString();
            gridItemChoiceView.ClearSelection();
            gridItemChoiceView.SelectRow(0);
            //PopulateItemList(dtItem);
        }

        /// <summary>
        /// Updates the forms based on the chosen month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            // 
            //cboStores.ItemIndex = 0;
            //PopulateGrid();
        }
        
        /// <summary>
        /// Update the form based on the store selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboYear.EditValue != null && cboStores.EditValue != null)
            {
                PopulateGrid();
            }
        }

        /// <summary>
        /// Updates the grid based on the chosen status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (cboIssuedTo.EditValue == null) 
        //        return;

        //    if (cboIssuedTo.EditValue.ToString() != "All")
        //    {
        //        if (cboIssuedTo.EditValue.ToString() == "Stock Out")
        //        {
        //            gridItemChoiceView.ActiveFilterString = "([SOH] != '0' or [AMC] != '0' or [EverReceived] != '0') and [Status] = 'Stock Out'";
        //        }
        //        else
        //        {
        //            gridItemChoiceView.ActiveFilterString = "[Status] Like '" + cboIssuedTo.EditValue.ToString() + "'";
        //        }
        //    }
        //    else
        //    {
        //        gridItemChoiceView.ActiveFilterString = "[SOH] != '0' or [AMC] != '0' or [EverReceived] != '0'";
        //    }
        //}

        /// <summary>
        /// Updates the form based on the year that is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            //dtDate.Value = DateTime.Now;
            //dtDate.CustomFormat = "MM/dd/yyyy";
            //_dtCur = ConvertDate.DateConverter(dtDate.Text);
            //int currentMont = _dtCur.Month;
            //int currentYear = _dtCur.Year; //CALENDAR:
            if (cboYear.EditValue != null && cboStores.EditValue != null)
            {
                PopulateGrid();
            }
        }

        /// <summary>
        /// Filters the grid based on the ckExclude value (Exclude never received items)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            //ckExcNeverIssued.Enabled = ckExclude.Checked;
            gridItemChoiceView.ActiveFilterString = ckExclude.Checked ? "[EverReceived] != '0'" : "";
        }

        /// <summary>
        /// Filters the grid based on the ckExclude value (Exclude never issued items)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExcNeverIssued_CheckedChanged_1(object sender, EventArgs e)
        {
           // gridItemChoiceView.ActiveFilterString = ckExcNeverIssued.Checked ? "[EverReceived] != '0' AND [Issued] != 0" : "[EverReceived] != '0'";
        }

        /// <summary>
        /// Filter the grid based on the txtItemName value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = "[FullItemName] Like '" + txtItemName.Text + "%'";  
        }

        /// <summary>
        /// When the sub program changes, the grid gets updated accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            //PopulateGrid();
        }
        
        private void cboIssuedTo_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboIssuedTo.SelectedValue != null)
            //{
            //    int duid = Convert.ToInt32(cboIssuedTo.SelectedValue);
            //    int month = Convert.ToInt32(cboMonth.SelectedValue);
            //    DataTable dtItm = new DataTable();
            //    Items itm = new Items();
            //    int duId = Convert.ToInt32(cboIssuedTo.SelectedValue);
            //    dtItm = itm.GetItemsByDU(duId);
            //    PopulateItemListByMonthDU(dtItm,month);
            //}
        }

        /// <summary>
        /// Hanldes the selected index changed of the radio button group and filters the cat tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_selectedType = radioGroup1.EditValue.ToString();
            //PopulateCatTree(_selectedType);
            //PopulateGrid();
        }

        /// <summary>
        /// Open the detailed information for an item when the user double clicks on the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemsChoice_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr == null)
                return;

            int itemId = Convert.ToInt32(dr["ID"]);
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);

            int month =_dtCur.Month;
            //int year = (month < 11) ? Convert.ToInt32(cboYear.EditValue) : Convert.ToInt32(cboYear.EditValue);
            int year = Convert.ToInt32(cboYear.EditValue);
            EthiopianDate.EthiopianDate ethioDate=new EthiopianDate.EthiopianDate(year,month,30);
            
            //ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
            ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);//ethioDate.FiscalYear
            con.ShowDialog();
        }
        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        /// <summary>
        /// Gets the balance of all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Balance bal = new Balance();

            int[] arr = (int [])e.Argument;

            int storeId = arr[0], year= arr[1], programID=arr[2];

            //if (year == EthiopianDate.EthiopianDate.Now.Year + 1)
            //{
            //    month = 1; //When we're sending the month as 1 if the year has been incremented (Fiscal year = year + 1 if month > 10)
            //}

            DataTable dtBal = bal.ConsumptionByUnit(storeId, year, programID, bw);
            e.Result = dtBal;
        }

        /// <summary>
        /// Updates the grid after the thread has finished executing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemsChoice.DataSource = (DataTable)e.Result;
            string issuedto = cboDUnits.EditValue.ToString();
            //if (ckExclude.Checked)
            gridItemChoiceView.ActiveFilterString = "[IssuedTo] = '" + issuedto + "'";
        }

        /// <summary>
        /// Exports the grid to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsChoice.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The Consumption report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        /// <summary>
        /// Shows a print preview of the grid content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            pcl.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            pcl.CreateDocument();
            pcl.ShowPreview();
        }

        /// <summary>
        /// Creates a marginal header area for the pcl object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            string[] header = { info.HospitalName , "Date:"  + dtDate.Text, "Store: " + cboStores.Text };
            pcl.Landscape = true;
            pcl.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
        }

        private void cboDUnits_EditValueChanged(object sender, EventArgs e)
        {
           gridItemChoiceView.ActiveFilterString = string.Format("[IssuedTo] = '{0}'", (int)(cboDUnits.EditValue));
        }

        private void lkCommodityTypes_EditValueChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = string.Format("[TypeID] = '{0}'", (int)(lkCommodityTypes.EditValue));
        }
    }
}