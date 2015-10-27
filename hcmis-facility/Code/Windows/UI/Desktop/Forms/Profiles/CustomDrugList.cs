using System;
using System.Data;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.Forms.Modals;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction logic for CustomDrugList form
    /// For customization of Drug list
    /// </summary>
    public partial class CustomDrugList : XtraForm
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomDrugList()
        {
            InitializeComponent();
        }

        int _catId = 0;        
        readonly Items _itm = new Items();

        /// <summary>
        /// Populates the tree, loads the dropdowns and populates the item list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {            
            //Programs prog = new Programs();
            //DataTable dtProg = prog.GetSubPrograms();
            //object[] objProg = { 0, "All", "", 0, "" };
            //dtProg.Rows.Add(objProg);
            //cboPrograms.Properties.DataSource = dtProg;
            //cboPrograms.ItemIndex = -1;
            //cboPrograms.Text = "Select SubProgram";
            lkCategories.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCategories.ItemIndex = 0;
            ImportItems();
        }

        private void ImportItems()
        {
            PopulateItemList(_itm.GetAllItem());
        }
                
        /// <summary>
        /// Fills the gridItemsChoice with data supplied in the table
        /// </summary>
        /// <param name="dtItem">Data Table whose content is to be filled inside the gridItemsChoice</param>
        private void PopulateItemList(DataTable dtItem)
        {
            gridItemsChoice.DataSource = dtItem;
            dtItem.DefaultView.Sort = "No";
        }

        /// <summary>
        /// Filters the grid based on the text inside the txtItemName text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
           gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1}", txtItemName.Text,(int)(lkCategories.EditValue ?? 0));
        }

        /// <summary>
        /// Opens the ItemPolicy form to make changes on the selected item and refreshes the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnEdit_Click(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr != null)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                ItemPolicy addItm = new ItemPolicy(itemId, true);
                addItm.ShowDialog();
                ImportItems();
            }
        }

        /// <summary>
        /// Exports the grid to pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnExportToPdf_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("pdf");
            gridItemsChoice.ExportToPdf(fileName);
            MainWindow.OpenInPdf(fileName);
        }

        /// <summary>
        /// Exports the grid to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnExportToXls_Click(object sender, EventArgs e)
        {
            string fileName = MainWindow.GetNewFileName("xls");
            gridItemsChoice.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
        }

        /// <summary>
        /// Shows print preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnShowPrintPreview_Click(object sender, EventArgs e)
        {
            gridItemsChoice.ShowPrintPreview();
        }


        private void toolBtnRefresh_Click(object sender, EventArgs e)
        {
            ImportItems();
        }

        /// <summary>
        /// Opens the ItemPolicy Form and updates the form afterwards.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridItemsChoice_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr != null)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                ItemPolicy addItm = new ItemPolicy(itemId, true);
                addItm.ShowDialog();
                ImportItems();
            }
        }

        /// <summary>
        /// Saves the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            int itemId = Convert.ToInt32(dr["ID"]);
            _itm.LoadByPrimaryKey(itemId);
            _itm.Save();
        }

        /// <summary>
        /// Handles the edit value changed event of the cboPrograms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPrograms_EditValueChanged(object sender, EventArgs e)
        {
            //PopulateByProgram();
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
           gridItemChoiceView.ActiveFilterString = string.Format("TypeID={0}", Convert.ToInt32(lkCategories.EditValue));
         
        }

        private void gridItemChoiceView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}