using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction logic for the ItemReport form
    /// </summary>
    public partial class ItemReport : XtraForm
    {
        public ItemReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialilze the form with a filter on the grid
        /// </summary>
        /// <param name="fltr"></param>
        public ItemReport(string fltr)
        {
            InitializeComponent();
            _filter = fltr;
        }

        readonly string _filter = "All";
        int _catId = 0;
        DateTime _dtCur = new DateTime();
        String _selectedType = "Drug";
        bool _isReady = false;
        private int unitID = 0;

        /// <summary>
        /// Loads the form and loads the lookups and the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
        CALENDAR:
            PopulateCatTree(_selectedType);

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            // lkCommodityTypes.ItemIndex = 0;

            string[] arr = new string[] { "All", "Stock Out", "Below EOP", "Near EOP", "Normal", "Over Stocked" };
            cboStatus.Properties.DataSource = arr;

            var itemunit = new ItemUnit();
            var allunits = itemunit.GetAllUnits();
            unitBindingSource.DataSource = allunits.DefaultView;

            var dtMonths = new DataTable();
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

            var unitcolumn = ((GridView)gridItemsChoice.MainView).Columns[17];
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

            DataTable dtyears = Items.AllYears();
            //if (year == _dtCur.Year + 1)
            //{
            //    object[] objYear = { year };
            //    dtyears.Rows.Add(objYear);
            //}
            cboYear.Properties.DataSource = dtyears;
            cboYear.EditValue = year;
            if (cboYear.Properties.Columns.Count > 0)
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
            Programs prog = new Programs();
            DataTable dtProg = prog.GetSubPrograms();
            object[] objProg = { 0, "All Programs", "", 0, "" };
            dtProg.Rows.Add(objProg);
            cboSubProgram.Properties.DataSource = dtProg;
            cboSubProgram.ItemIndex = -1;
            cboSubProgram.Text = "Select Program";

            ReceivingUnits rec = new ReceivingUnits();
            DataTable drRec = rec.GetAllApplicableDU();
            cboIssuedTo.Properties.DataSource = drRec;
            cboIssuedTo.ItemIndex = -1;
            cboIssuedTo.Text = "Select Issue Location";

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

            if ((cboYear.EditValue == null) || (cboMonth.EditValue == null) || (cboStores.EditValue == null))
                return;

            int storeId;
            if (cboStores.EditValue == null) storeId = 1;
            else storeId = Convert.ToInt32(cboStores.EditValue);
            int month = Convert.ToInt32(cboMonth.EditValue);
            int year = Convert.ToInt32(cboYear.EditValue);

            // different criteria for different options like suply and drug
            int programID = ((cboSubProgram.EditValue != null) ? Convert.ToInt32(cboSubProgram.EditValue) : 0);
            int commodityType = Convert.ToInt32(lkCommodityTypes.EditValue);
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync(new int[] { storeId, month, year, programID, commodityType });
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
            if (ckExcNeverIssued.Checked)
                isStock = "[EverReceived] != '0' AND [Issued] != 0 AND ";
            else if (ckExclude.Checked)
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
                    gridItemChoiceView.ActiveFilterString = isStock;
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
            cboStores.ItemIndex = 0;
            PopulateGrid();
        }

        /// <summary>
        /// Update the form based on the store selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        /// <summary>
        /// Updates the grid based on the chosen status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStatus.EditValue == null)
                return;

            if (cboStatus.EditValue.ToString() != "All")
            {
                if (cboStatus.EditValue.ToString() == "Stock Out")
                {
                    gridItemChoiceView.ActiveFilterString = "([SOH] != '0' or [AMC] != '0' or [EverReceived] != '0') and [Status] = 'Stock Out'";
                }
                else
                {
                    gridItemChoiceView.ActiveFilterString = "[Status] Like '" + cboStatus.EditValue.ToString() + "'";
                }
            }
            else
            {
                gridItemChoiceView.ActiveFilterString = "[SOH] != '0' or [AMC] != '0' or [EverReceived] != '0'";
            }
        }

        /// <summary>
        /// Updates the form based on the year that is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = _dtCur.Month;
            int currentYear = _dtCur.Year; //CALENDAR:
            //if (currentMont >= 11)
            //{
            //    currentYear++;
            //    currentMont -= 10;
            //}
            //else
            //{
            //    currentMont += 2;
            //}

            //string[] mon = { "Hamle", "Nehase", "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene" };

            int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            string[] mon = { "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene", "Hamle", "Nehase" };
            int i; //currentMont;
            if (Convert.ToInt32(cboYear.EditValue) == currentYear)
            {
                for (i = 0; i < val.Length; i++)
                {
                    if (val[i] == currentMont)
                    {
                        break;
                    }
                }
            }
            else
            {
                i = val.Length - 1;
            }
            int j;
            //for (int j = i; j >= 0; j--)
            for (j = 0; j <= i; j++)
            {
                object[] obj = { val[j], mon[j] };
                dtMonths.Rows.Add(obj);
            }

            cboMonth.Properties.DataSource = dtMonths;

            if (Convert.ToInt32(cboYear.EditValue) != currentYear)
            {
                cboMonth.ItemIndex = 0;
            }
            else
            {
                cboMonth.ItemIndex = j;
            }

            //cboMonth_SelectedValueChanged(null, null);
            PopulateGrid();
        }

        /// <summary>
        /// Filters the grid based on the ckExclude value (Exclude never received items)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            ckExcNeverIssued.Enabled = ckExclude.Checked;
            if (ckExclude.Checked)
                //gridItemChoiceView.ActiveFilterString =
                //   string.Format("[EverReceived] != '0' or SOH != '0' or TypeID={0}",
                //                 (int) lkCommodityTypes.EditValue);
                gridItemChoiceView.ActiveFilterString = "SOH != '0' or [EverReceived] !='0' or AMC!= '0'";

            else
                gridItemChoiceView.ActiveFilterString = "";
        }

        /// <summary>
        /// Filters the grid based on the ckExclude value (Exclude never issued items)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExcNeverIssued_CheckedChanged_1(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = ckExcNeverIssued.Checked ? "Issued != 0" : "[EverReceived] != '0' or SOH != '0'";
        }

        /// <summary>
        /// Filter the grid based on the txtItemName value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (lkCommodityTypes.EditValue == null)
                gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%'", txtItemName.Text);
            else
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1}",
                                                                      txtItemName.Text, (int)(lkCommodityTypes.EditValue));
            }
        }

        /// <summary>
        /// When the sub program changes, the grid gets updated accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
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
            _selectedType = radioGroup1.EditValue.ToString();
            PopulateCatTree(_selectedType);
            PopulateGrid();
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

            int month = Convert.ToInt32(cboMonth.EditValue);
            //int year = (month < 11) ? Convert.ToInt32(cboYear.EditValue) : Convert.ToInt32(cboYear.EditValue);
            int year = Convert.ToInt32(cboYear.EditValue);
            var ethioDate = new EthiopianDate.EthiopianDate(year, month, 30);

            switch (VisibilitySetting.HandleUnits)
            {
                case 2:
                    {
                        unitID = Convert.ToInt32(dr["UnitID"]);
                        var con1 = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0, unitID);//ethioDate.FiscalYear
                        con1.ShowDialog();
                    }
                    break;
                case 3:
                    {
                        unitID = Convert.ToInt32(dr["UnitID"]);
                        var con1 = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0, unitID);//ethioDate.FiscalYear
                        con1.ShowDialog();
                    }
                    break;
                default:
                    {

                        //ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                        ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                        //ethioDate.FiscalYear
                        con.ShowDialog();
                    }
                    break;
            }
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

            int[] arr = (int[])e.Argument;

            int storeId = arr[0], month = arr[1], year = arr[2], programID = arr[3], commodityTypeID = arr[4];

            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    {
                        var dtBal = bal.BalanceOfAllItemsForStockStatus(storeId, year, month, _selectedType, programID, commodityTypeID,
                                                          _dtCur, bw);
                        e.Result = dtBal;
                    }
                    break;
                case 2:
                    {
                        var dtBal = bal.BalanceOfAllItemsUsingUnit(storeId, year, month, _selectedType, programID, commodityTypeID,
                                                          _dtCur, bw);
                        e.Result = dtBal;
                    }
                    break;
                case 3:
                    {
                        var dtBal = bal.BalanceOfAllItemsUsingUnit(storeId, year, month, _selectedType, programID, commodityTypeID,
                                                          _dtCur, bw);
                        e.Result = dtBal;
                    }
                    break;
            }
        }

        /// <summary>
        /// Updates the grid after the thread has finished executing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemsChoice.DataSource = e.Result;
            cboStatus.EditValue = _filter;
            if (ckExclude.Checked)
                gridItemChoiceView.ActiveFilterString =
                    string.Format("[EverReceived] != '0' or SOH != '0' or AMC != '0'");
            else
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0}", Convert.ToInt32(lkCommodityTypes.EditValue));
        }

        /// <summary>
        /// Exports the grid to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog { Filter = "Microsoft Excel | *.xls" };

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsChoice.MainView.ExportToXls(saveDlg.FileName);
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
            string[] header = { info.HospitalName, "Date: " + dtDate.Text, "Store: " + cboStores.Text };
            pcl.Landscape = true;
            pcl.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
          }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            string criteria = string.Empty;

            if (lkCommodityTypes != null)
            {
                if (cboStatus.EditValue != null)
                {
                    if (cboStatus.EditValue.ToString() != "All")
                    {
                        if (cboStatus.EditValue.ToString() == "Stock Out")
                        {
                            criteria = "([SOH] != '0' or [AMC] != '0' or [EverReceived] != '0') and [Status] = 'Stock Out' and [TypeID] = " + Convert.ToInt32(lkCommodityTypes.EditValue);
                            gridItemChoiceView.ActiveFilterString = criteria;
                            // gridItemChoiceView.Columns[14].Visible = true;
                        }
                        else
                        {
                            criteria = "[Status] Like '" + cboStatus.EditValue.ToString() + "' and [TypeID] = " + Convert.ToInt32(lkCommodityTypes.EditValue);
                            gridItemChoiceView.ActiveFilterString = criteria;
                        }
                    }
                    else
                    {
                        criteria = "[SOH] != '0' or [AMC] != '0' or [Received] != '0' and [TypeID] = " + Convert.ToInt32(lkCommodityTypes.EditValue);
                        gridItemChoiceView.ActiveFilterString = criteria;
                    }
                }
                else
                {
                    criteria = string.Format("TypeID={0}", Convert.ToInt32(lkCommodityTypes.EditValue));
                    gridItemChoiceView.ActiveFilterString = criteria;
                }
            }
        }
    }
}