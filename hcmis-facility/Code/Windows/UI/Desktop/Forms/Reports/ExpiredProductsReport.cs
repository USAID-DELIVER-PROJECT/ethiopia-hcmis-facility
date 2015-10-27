using System;
using System.Data;
using System.Drawing;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;
using System.Windows.Forms;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction Logic for the ExpiredProducts Form
    /// </summary>
    public partial class ExpiredProductsReport : XtraForm
    {
        public ExpiredProductsReport()
        {
            InitializeComponent();
        }
        
        String _selectedType = "Drug";

        /// <summary>
        /// Loads the lookups and the category tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);

            var rec = new DisposalReasons();
            var dtDis = rec.GetAvailableReasons();
            //object[] objRec = { 0, "All Reasons", "" };
            //dtDis.Rows.Add(objRec);
            cboReasons.Properties.DataSource = dtDis;
            cboReasons.Properties.DisplayMember = "Reason";
            cboReasons.Properties.ValueMember = "ID";
           //  cboReasons.ItemIndex = 0;
         
            //cboStores.ItemIndex = 0;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCur = ConvertDate.DateConverter(dtDate.Text);
            int month = dtCur.Month;
            int year;
            if (month < 11) year = dtCur.Year;
            else year = dtCur.Year + 1;

            DataTable dtyears = Items.AllYears();
            cmbYear.Properties.DataSource = dtyears;
            cmbYear.EditValue = year;
            if (cmbYear.Properties.Columns.Count > 0)
                cmbYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
            //cmbYear.EditValue 
            var stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;
            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;
        }

        /// <summary>
        /// Populates the treeCategory with Drug or Supply based on the specified parameter
        /// </summary>
        /// <param name="type">"Drug" - loads category, Otherwise, SupplyCategory gets loaded</param>
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
        /// Populates the gridItemsList with the table supplied.
        /// </summary>
        /// <param name="dtItem"></param>
        private void PopulateItemList(DataTable dtItem)
        {
            gridItemsList.DataSource = dtItem;
        }

        /// <summary>
        /// Handles the changed event of the store combo bo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboStores.EditValue != null)
            {
                int year = Convert.ToInt32(cmbYear.EditValue);
                int reasonId;
                reasonId = cboReasons.EditValue == null ? 0 : Convert.ToInt32(cboReasons.EditValue);
                var itm = new Items();
               // _selectedType = rdDrug.EditValue.ToString();
                //DataTable dtItem = ((_selectedType == "Drug") ? itm.GetExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue)) : itm.GetExpiredSupplysByBatch(Convert.ToInt32(cboStores.EditValue)));
                var dtItem = itm.GetAllExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue), year, reasonId ,Convert.ToInt32(lkCommodityTypes.EditValue));
               // DataTable dtItem = itm.GetExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCommodityTypes.EditValue));
               // DataTable dtItem = itm.GetExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCommodityTypes.EditValue), Convert.ToInt32(cboReasons.EditValue));
               // DataTable dtItem = itm.GetExpiredItems(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCommodityTypes.EditValue));
                PopulateItemList(dtItem);
            }
        }

        /// <summary>
        /// Shows print preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton1_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(printableComponentLink1_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        /// <summary>
        /// Exports to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsList.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("Loss / Adjustment report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Filters the grid based on the text value in txtItemName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = "[FullItemName] like '" + txtItemName.Text + "%'";
        }

        /// <summary>
        /// Updates the form based on the selections on the treeCategory
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
                    // TOFIX: i disabled this because i didn't get the time to fix it :) just enable it and trace back.
                    filterString = "[CategoryID] = " + categoryId.ToString();
                    gridItemListView.ActiveFilterString = filterString;

                    break;
                case "P":
                    // dtItem = itm.GetAllItem();
                    gridItemListView.ActiveFilterString = "";
                    break;
            }

            gridItemListView.ClearSelection();
        }

        /// <summary>
        /// Handles the changed event of the radio group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                Items itm = new Items();
                _selectedType = rdDrug.EditValue.ToString();
                DataTable dtItem = itm.GetExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCommodityTypes.EditValue), Convert.ToInt32(cboReasons.EditValue));//
                PopulateItemList(dtItem);
                PopulateCatTree(_selectedType);
            }
        }

        /// <summary>
        /// Opens detailed item information form for the chosen item.
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
                    //ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                    //con.ShowDialog();
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();
            string[] header = { info.HospitalName ,"Store: " + cboStores.Text , "Printed Date: " + dtDate.Text  };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100), BorderSide.None);
         }

        private void cboReasons_EditValueChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = string.Format("ReasonID={0}", Convert.ToInt32(cboReasons.EditValue));
        }



    }
}