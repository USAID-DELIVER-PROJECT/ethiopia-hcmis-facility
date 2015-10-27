using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class ItemPriceOnlyReport : XtraForm
    {
        public ItemPriceOnlyReport()
        {
            InitializeComponent();
        }

        public ItemPriceOnlyReport(string fltr)
        {
            InitializeComponent();
            filter = fltr;
        }

        string filter = "All";
        int catID = 0;
        private int unitID = 0;
        DateTime dtCur = new DateTime();
        String SelectedType = "Drug";
        bool IsReady = false;

        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateCatTree(SelectedType);

            lkCommodityTypes.Properties.DataSource = BLL.Type.GetAllTypes();
            lkCommodityTypes.ItemIndex = 0;

            var itemunit = new ItemUnit();
            var allunits = itemunit.GetAllUnits();
            unitBindingSource.DataSource = allunits.DefaultView;

            var stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;

            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = dtCur.Month;
            int year = ((currentMont < 11) ? dtCur.Year : dtCur.Year + 1);
            // this is just a try
            if (currentMont >= 11)
            {
                currentMont -= 11;
            }

            var dtyears = Items.AllYears();

            cboStores.ItemIndex = 0;
            cboYear.Properties.DataSource = dtyears;
            cboYear.EditValue = year;
            if (cboYear.Properties.Columns.Count > 0)
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;

            IsReady = true;
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            if (IsReady)
            {
                if (cboStores.EditValue != null)
                {
                    int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;

                    var recDoc = new ReceiveDoc();
                    var dtBal = new DataTable();

                    switch (VisibilitySetting.HandleUnits)
                    {
                        case 1:
                            dtBal = (DataTable)recDoc.GetItemsWithPrice(storeId, Convert.ToInt32(lkCommodityTypes.EditValue));
                            break;
                        case 2:
                            dtBal = (DataTable)recDoc.GetItemsWithPrice(storeId, Convert.ToInt32(lkCommodityTypes.EditValue));
                            break;
                        default:
                            dtBal = (DataTable)recDoc.GetItemsWithPrice(storeId, Convert.ToInt32(lkCommodityTypes.EditValue));
                            break;
                    }

                    gridItemsChoice.DataSource = dtBal;
                }
            }
        }

        private void PopulateCatTree(String Type)
        {
            if (Type == "Drug")
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

        private void treeCategory_Click(object sender, EventArgs e)
        {
            string value = treeCategory.Selection[0].GetValue("ID").ToString();
            int categoryId = Convert.ToInt32(value.Substring(1));
            catID = categoryId;
            gridItemChoiceView.ClearSelection();
            gridItemChoiceView.SelectRow(0);
        }

        private void cboMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var gregDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, Convert.ToInt32(cboMonth.EditValue), Convert.ToInt32(cboYear.EditValue)));
                if ((lkCommodityTypes.EditValue != null) && (cboYear.EditValue != null) && (cboMonth.EditValue != null))
                {
                    gridItemChoiceView.ActiveFilterString = " TypeID = " + Convert.ToInt32(lkCommodityTypes.EditValue) + " AND Year = " + gregDate.Year + " AND Month = " + gregDate.Month;
                }
                else if ((cboYear.EditValue != null) && (cboMonth.EditValue != null))
                {
                    gridItemChoiceView.ActiveFilterString = " Year = " + gregDate.Year + " AND Month = " + gregDate.Month;
                }
            }
            catch (Exception)
            {

            }
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCur = ConvertDate.DateConverter(dtDate.Text);
            int currentMont = dtCur.Month;
            int currentYear = dtCur.Year;
            if (currentMont >= 11)
            {
                currentYear++;
                currentMont -= 10;
            }
            else
            {
                currentMont += 2;
            }
            int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            string[] mon = { "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene", "Hamle", "Nehase"};
            int i = 0; //currentMont;
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
            for (int j = i; j >= 0; j--)
            {
                object[] obj = { val[j], mon[j] };
                dtMonths.Rows.Add(obj);
            }
            cboMonth.Properties.DataSource = dtMonths;
            cboMonth.ItemIndex = -1;

            try
            {
                var gregDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, Convert.ToInt32(cboMonth.EditValue), Convert.ToInt32(cboYear.EditValue)));
                if ((lkCommodityTypes.EditValue != null) && (cboYear.EditValue != null) && (cboMonth.EditValue != null))
                {
                    gridItemChoiceView.ActiveFilterString = " TypeID = " + Convert.ToInt32(lkCommodityTypes.EditValue) + " AND Year = " + gregDate.Year + " AND Month = " + gregDate.Month;
                }
                else if ((cboYear.EditValue != null) && (cboMonth.EditValue != null))
                {
                    gridItemChoiceView.ActiveFilterString = " Year = " + gregDate.Year + " AND Month = " + gregDate.Month;
                }
                else if ((cboYear.EditValue != null))
                {
                    gridItemChoiceView.ActiveFilterString = " Year = " + gregDate.Year;
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1}", txtItemName.Text, (int)(lkCommodityTypes.EditValue ?? 0));
        }

        private void gridItemsChoice_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr == null) return;
            int itemId = Convert.ToInt32(dr["ID"]);
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCur = ConvertDate.DateConverter(dtDate.Text);
            int month = Convert.ToInt32(cboMonth.EditValue);
            int year = (month < 11) ? Convert.ToInt32(cboYear.EditValue) : Convert.ToInt32(cboYear.EditValue);

            switch (VisibilitySetting.HandleUnits)
            {
                case 2:
                    {
                        unitID = Convert.ToInt32(dr["UnitID"]);
                        var con1 = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0,
                                                        unitID); //ethioDate.FiscalYear
                        con1.ShowDialog();
                    }
                    break;
                case 3:
                    {
                        unitID = Convert.ToInt32(dr["UnitID"]);
                        var con1 = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue), year, 0,
                                                        unitID); //ethioDate.FiscalYear
                        con1.ShowDialog();
                    }
                    break;
                default:
                    {
                        var con = new ItemDetailReport(itemId, Convert.ToInt32(cboStores.EditValue),
                                                                    year, 0);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsChoice.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //printableComponentLink1.PrintDlg();
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(printableComponentLink1_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }

        private void printableComponentLink1_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();

            string[] header =
                {"Price Only Report",
                    info.HospitalName, "Date: " + dtDate.Text,
                    "Store: " + cboStores.Text
                };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 200, 100),
                                                    BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 20, 200, 100),
                                                    BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 40, 200, 100),
                                                    BorderSide.None);
            TextBrick brick3 = e.Graph.DrawString(header[3], Color.DarkBlue, new RectangleF(0, 60, 200, 100),
                                                    BorderSide.None);
        }

        private void lkCommodityTypes_EditValueChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} ",
                                                                    Convert.ToInt32(lkCommodityTypes.EditValue));
        }
    }
}