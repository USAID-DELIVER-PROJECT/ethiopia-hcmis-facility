using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction logic for BalanceReport Form
    /// </summary>
    public partial class BalanceReport : Form
    {
        public BalanceReport()
        {
            InitializeComponent();
        }

        String _selectedType = "Drug";

        /// <summary>
        /// Load the dropdowns and the category tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);

            Programs prog = new Programs();
            DataTable dtProg = prog.GetSubPrograms();
            object[] objProg = { 0, "All Programs", "", 0, "" };
            dtProg.Rows.Add(objProg);
            cboSubProgram.DataSource = dtProg;
            cboSubProgram.SelectedIndex = -1;
            cboSubProgram.Text = "Select Program";

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;
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
            Balance bal = new Balance();
            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 1;
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            gridItemsList.DataSource = bal.BalanceAllItems(storeId,dtCurrent.Year,dtCurrent.Month,_selectedType);
            if (ckExclude.Checked)
                gridItemListView.ActiveFilterString = "[Received] != '0'";          
        }

        /// <summary>
        /// Populates Item list based on the supplied table
        /// </summary>
        /// <param name="dtTable"></param>
        private void PopulateItemList(DataTable dtTable)
        {
            //TODO: Check this to make sure we are getting the required results.
            gridItemsList.DataSource = dtTable;
            if (ckExclude.Checked)
                gridItemListView.ActiveFilterString = "[Received] != '0'";
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
            GridView view = sender as GridView;
            if (view != null)
            {
                DataRow dr = view.GetFocusedDataRow();
                if (dr != null)
                {
                    dtDate.Value = DateTime.Now;
                    dtDate.CustomFormat = "MM/dd/yyyy";
                    DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
                    int month = dtCur.Month;
                    int year = (month < 11) ? dtCur.Year : dtCur.Year + 1;
                    int itemId = Convert.ToInt32(dr["ID"]);
                    ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.SelectedValue), year, 0);
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
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
            //printableComponentLink1.ShowPreviewDialog();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            string[] header = { info.HospitalName , "Date: " + dtDate.Text, "Store: " + cboStores.Text };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
        }

        /// <summary>
        /// Exports to XLS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("xls");
            gridItemsList.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
        }

        /// <summary>
        /// Excludes never received items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = ckExclude.Checked ? "[Received] != '0'" : "";
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

        private void PopulateByProgram()
        {
            if (cboSubProgram.SelectedValue != null && cboStores.SelectedValue != null)
            {
                Items itm = new Items();
                DataTable dtItem;
                if (Convert.ToInt32(cboSubProgram.SelectedValue) > 0)
                {
                    if (rdDrug.EditValue!=null)
                        dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItemsByProgram(Convert.ToInt32(cboSubProgram.SelectedValue), Convert.ToInt32(cboStores.SelectedValue)) : itm.GetItemsByProgram(Convert.ToInt32(cboSubProgram.SelectedValue)));
                    else
                        dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedSuppliesByProgram(Convert.ToInt32(cboSubProgram.SelectedValue), Convert.ToInt32(cboStores.SelectedValue)) : itm.GetSupplyByProgram(Convert.ToInt32(cboSubProgram.SelectedValue)));
                }
                else
                {
                    if (rdDrug.EditValue!=null)
                        dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedItems(Convert.ToInt32(cboStores.SelectedValue),Convert.ToInt32(lkCommodityTypes.EditValue)) : itm.GetAllItems(1));
                    else
                        dtItem = ((ckExclude.Checked) ? itm.ExcludeNeverReceivedSupply(Convert.ToInt32(cboStores.SelectedValue)) : itm.GetAllSupply());
                }
                PopulateItemList(dtItem);
            }
        }

        /// <summary>
        /// Populates the items based on the chosen program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubProgram_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateByProgram();
        }

      
    }
}