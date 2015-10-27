
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;
using System.ComponentModel;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction logic for BalanceReport Form
    /// </summary>
    public partial class CostReport : Form
    {
        public CostReport()
        {
            InitializeComponent();
        }

        String _selectedType = "Drug";
        bool _isReady = false;
        DateTime _dtCur;
       
        /// <summary>
        /// Load the dropdowns and the category tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);

            var type = new BLL.Type();
            var alltypes = type.GetAllCategory();
            lkCategory.Properties.DataSource = alltypes;
            lkCategory.Properties.DisplayMember = "Name";
            lkCategory.Properties.ValueMember = "ID";
            lkCategory.ItemIndex = 0;

            var stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCur = ConvertDate.DateConverter(dtDate.Text);
            dtTo.Value = DateTime.Now;
           // int yearFrom = ((_dtCur.Month == 11 && _dtCur.Month == 12) ? _dtCur.Year : _dtCur.Year - 1 );
            int currYear = (EthiopianDate.EthiopianDate.Now.Month < 11) ? EthiopianDate.EthiopianDate.Now.Year - 1 : EthiopianDate.EthiopianDate.Now.Year;
            dtFrom.Value = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, 11, currYear));

            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            //string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            //layoutControlGroup3.Text = "Cost Report " + dRange;
            if (dt1 == dt2)
            {
                dt1 = ((dt1.Month == 11 || dt1.Month == 12) ? new DateTime(dt1.Year, 11, 1) : new DateTime(dt1.Year - 1, 11, 1));
                //dRange = "For Year " + dt1.Year.ToString();
            }
            this._isReady = true;

            txtFromDate.Text = dt1.ToShortDateString();

            PopulateItemList();
        }
        /// <summary>
        /// Populates the category tree with drugs or supply categories based on the supplied parameter
        /// </summary>
        /// <param name="type">"Drug" - To get drugs, Otherwise, Supply Categories are filled out</param>
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
        /// Populates the list of items in the gridItemsList
        /// </summary>
        private void PopulateItemList()
        {
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            //gridItemsList.DataSource = bal.CostBalanceByYear(storeId, dtCurrent.Year, dtCurrent.Month,);
            //if (ckExclude.Checked)
            //    gridItemListView.ActiveFilterString = "[Received] != '0'";          
            if (!_isReady)
                return;

            //if ((cboYear.EditValue == null) || (cboMonth.EditValue == null) || (cboStores.EditValue == null))
            //    return;

            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            int month = dtCurrent.Month;
            
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            if (dt1 == dt2)
            {
                dRange = "For Year " + dt1.Year.ToString();
            }
            layoutControlGroup3.Text = "Cost Report " + dRange;
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync(new int[] { storeId, month });
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemsList.DataSource = (DataTable)e.Result;
            if (ckExclude.Checked)
                gridItemListView.ActiveFilterString = string.Format("[Received] != '0'and [TypeID]={0}", Convert.ToInt32(lkCategory.EditValue));
        }

        /// <summary>
        /// Gets the balance of all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var bal = new Balance();

            int[] arr = (int[])e.Argument;

            int storeId = arr[0], month = arr[1]; // year = arr[2], quarter = arr[3];
            
            dtFrom.CustomFormat = "MM/dd/yyyy";
            DateTime dt1 = ConvertDate.DateConverter(dtFrom.Text);
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dt2 = ConvertDate.DateConverter(dtTo.Text);
            //string dRange = "From " + dtFrom.Text + " to " + dtTo.Text;
            //layoutControlGroup3.Text = "Cost Report " + dRange;
            if (dt1 == dt2)
            { 
                dt1 = ((dt1.Month == 11 || dt1.Month == 12)? new DateTime(dt1.Year, 11,1) : new DateTime(dt1.Year -1,11,1));
                //dRange = "For Year " + dt1.Year.ToString();
            }
            
            var dtBal = bal.TransactionReport(storeId, dt1,dt2, _selectedType, bw);
            e.Result = dtBal;
            //txtFromDate.Text = dt1.ToShortDateString();
        }


        /// <summary>
        /// Updates the form based on the selection on the treeCategory (Does filtering)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));

            Items itm = new Items();
            string filterString = "";
            switch (value.Substring(0, 1))
            {
                case "S":
                    filterString = "[SubCategoryID] = " + categoryId.ToString();
                    gridItemListView.ActiveFilterString = filterString;
                    break;
                case "C":
                case "U":
                    filterString = "[CategoryId] = " + categoryId.ToString();
                    gridItemListView.ActiveFilterString = filterString;
                    break;
                case "P":
                    gridItemListView.ActiveFilterString = "";
                    break;
            }

            gridItemListView.ClearSelection();
        }
        
        /// <summary>
        /// Handles the selected value changed event of the cboStores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
               PopulateItemList();
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
        /// Opens the detailed item report for the chosen item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemListView_DoubleClick(object sender, EventArgs e)
        {
            var view = sender as GridView;
            DataRow dr = view.GetFocusedDataRow();
            if (view != null && VisibilitySetting.HandleUnits==1)
            {
                if (dr != null)
                {
                    dtDate.Value = DateTime.Now;
                    dtDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
                    var month = dtCur.Month;
                    var year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
                    var itemId = Convert.ToInt32(dr["ID"]);
                    var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year, 0);
                    con.ShowDialog();
                }
            }
            else if(view != null && VisibilitySetting.HandleUnits==2)
            {
                if (dr != null)
                {
                    dtDate.Value = DateTime.Now;
                    dtDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
                    var month = dtCur.Month;
                    var year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
                    var itemId = Convert.ToInt32(dr["ID"]);
                    var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year, 0, Convert.ToInt32(dr["ID"]));
                    con.ShowDialog();
                }
            }
            else if (view != null && VisibilitySetting.HandleUnits == 3)
            {
               if (dr != null)
                {
                    dtDate.Value = DateTime.Now;
                    dtDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
                    var month = dtCur.Month;
                    var year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
                    var itemId = Convert.ToInt32(dr["ID"]);
                    var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year, 0, Convert.ToInt32(dr["ID"]));
                    con.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Shows print preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(printableComponentLink1_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
           // printableComponentLink1.ShowPreviewDialog();
        }

        /// <summary>
        /// Exports to XLS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            //string fileName = MainWindow.GetNewFileName("xls");
            //gridItemsList.ExportToXls(fileName);
            //MainWindow.OpenInExcel(fileName);
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsList.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The cost report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Excludes never received items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            string fil = ((ckExclude.Checked) ? "[Received] != '0'" : "");
            gridItemListView.ActiveFilterString = fil;
        }

        /// <summary>
        /// Populate the items based on the choice of the radio buttons (Drugs or Supplies)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDrug_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                _selectedType = rdDrug.EditValue.ToString();
                
                PopulateItemList();
                PopulateCatTree(_selectedType);
            }
        }

        /// <summary>
        /// Filters the grid based on the text in the txtItemName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = "[FullItemName] like '" + txtItemName.Text + "%'";
        }

       

        /// <summary>
        /// Populates the items based on the chosen program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
           // PopulateByProgram();
        }

        private void gridItemsList_Click(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)//&& cboYear.SelectedValue != null)
            {
                PopulateItemList();
            }
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();
            string[] header = { info.HospitalName, "From Date:" + txtFromDate.Text, "To Date:" + dtTo.Text, "Store: " + cboStores.Text, "Printed Date:" + dtTo.Text };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
            TextBrick brick3= e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(0, 60, 200, 100), BorderSide.None);
        }

      
    }
}