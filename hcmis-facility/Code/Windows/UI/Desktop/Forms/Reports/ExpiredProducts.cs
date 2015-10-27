using System;
using System.Data;
using System.Drawing;
using System.Windows.Documents;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PharmInventory.Forms.Modals;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.Reports
{
    /// <summary>
    /// Interaction Logic for the ExpiredProducts Form
    /// </summary>
    public partial class ExpiredProducts : XtraForm
    {
        public ExpiredProducts()
        {
            InitializeComponent();
        }

        private DateTime _dtCurrent = new DateTime();
        private String _selectedType = "Drug";

        /// <summary>
        /// Loads the lookups and the category tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(_selectedType);
            DataTable table = new DataTable();
            table = BLL.Type.GetAllTypes();
            DataRow row = table.NewRow();
            row["ID"] = "0";
            row["Name"] = "All";
            table.Rows.InsertAt(row, 0);

            lkCommodityTypes.Properties.DataSource = table;
            lkCommodityTypes.ItemIndex = 0;

            PopulateCatTree(_selectedType);

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            _dtCurrent = ConvertDate.DateConverter(dtDate.Text);

          
            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;

            DataTable dtYear = Items.AllYearsReport();
            DataRow roww = dtYear.NewRow();
            roww["year"] = "All";
            dtYear.Rows.InsertAt(roww, 0);
            cboYear.Properties.DataSource = dtYear;
            cboYear.ItemIndex = 0;
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
            if (cboStores.EditValue != null)
            {
                int currentMonth = EthiopianDate.EthiopianDate.Now.Month;
                var expDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, currentMonth, Convert.ToInt32(cboYear.EditValue)));

                Items itm = new Items();
                DataTable dtItem = itm.GetExpiredItemsByBatch(Convert.ToInt32(cboStores.EditValue));
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
            printableComponentLink1.CreateMarginalHeaderArea +=
                new CreateAreaEventHandler(printableComponentLink1_CreateMarginalHeaderArea);
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
            string fileName = MainWindow.GetNewFileName("xls");
            gridItemsList.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);
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
                    ItemDetailReport con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0);
                    con.ShowDialog();
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

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();
            string[] header = {info.HospitalName, "Store: " + cboStores.Text, "Printed Date:" + dtDate.Text};
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100),
                                                 BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100),
                                                  BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100),
                                                  BorderSide.None);
        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {
            gridItemListView.ActiveFilterString = "[FullItemName] like '" + txtItemName.Text + "%'";
        }

        private void lkCommodityTypes_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int currentMonth = EthiopianDate.EthiopianDate.Now.Month;
                if (lkCommodityTypes.EditValue != null)
                {
                    if (cboYear.EditValue != null)
                    {
                        if ((lkCommodityTypes.EditValue.ToString() != "0") && (cboYear.EditValue.ToString() != "All"))
                        {
                            var gregDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, currentMonth, Convert.ToInt32(cboYear.EditValue)));
                            gridItemListView.ActiveFilterString = " TypeID = " + Convert.ToInt32(lkCommodityTypes.EditValue) + " AND Year = " + gregDate.Year;
                        }
                        else if ((lkCommodityTypes.EditValue.ToString() == "0") && (cboYear.EditValue.ToString() != "All"))
                        {
                            var gregDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, currentMonth, Convert.ToInt32(cboYear.EditValue)));
                            gridItemListView.ActiveFilterString = " Year = " + gregDate.Year;
                        }
                        else if ((lkCommodityTypes.EditValue.ToString() != "0") && (cboYear.EditValue.ToString() == "All"))
                        {
                            gridItemListView.ActiveFilterString = " TypeID = " + Convert.ToInt32(lkCommodityTypes.EditValue);
                        }
                        else
                        {
                            gridItemListView.ActiveFilterString = "";
                        }
                    }
                    else
                    {
                        if (lkCommodityTypes.EditValue.ToString() != "0")
                        {
                            gridItemListView.ActiveFilterString = " TypeID = " + Convert.ToInt32(lkCommodityTypes.EditValue);
                        }
                        else
                        {
                            gridItemListView.ActiveFilterString = "";
                        }
                    }
                }
                else if (cboYear.EditValue != null)
                {
                    if (cboYear.EditValue.ToString() != "All")
                    {
                        var gregDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, currentMonth, Convert.ToInt32(cboYear.EditValue)));
                        gridItemListView.ActiveFilterString = " Year = " + gregDate.Year;
                    }
                    else
                    {
                        gridItemListView.ActiveFilterString = "";
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
