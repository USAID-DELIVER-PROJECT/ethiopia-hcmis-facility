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
    public partial class OtherItemReport : XtraForm
    {
        public OtherItemReport()
        {
            InitializeComponent();
        }

        public OtherItemReport(string fltr)
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

            string[] arr = {"All",
            "Stock Out",
            "Below EOP",
            "Near EOP",
            "Normal",
            "Over Stocked"};

            cboStatus.Properties.DataSource = arr;

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

            cboYear.Properties.DataSource = dtyears;
            cboYear.EditValue = year;
            if (cboYear.Properties.Columns.Count > 0)
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
            var prog = new Programs();
            var dtProg = new DataTable();
            dtProg = prog.GetSubPrograms();
            object[] objProg = { 0, "All Programs", "", 0, "" };
            dtProg.Rows.Add(objProg);
            cboSubProgram.Properties.DataSource = dtProg;
            cboSubProgram.ItemIndex = -1;
            cboSubProgram.Text = "Select Program";

            var rec = new ReceivingUnits();
            var drRec = rec.GetAllApplicableDU();
            cboIssuedTo.Properties.DataSource = drRec;
            cboIssuedTo.ItemIndex = -1;
            cboIssuedTo.Text = "Select Issue Location";
            IsReady = true;

            var unitcolumn = ((GridView)gridItemsChoice.MainView).Columns[15];
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
            PopulateGrid();


        }


        private void PopulateGrid()
        {
            if (IsReady)
            {
                if ((cboYear.EditValue != null) && (cboMonth.EditValue != null) && (cboStores.EditValue != null))
                {
                    int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 1;
                    int month = Convert.ToInt32(cboMonth.EditValue);
                    int year = Convert.ToInt32(cboYear.EditValue);

                    //translate the month selection to the appropriate month values

                    if (month > 2)
                    {
                        month -= 2;
                    }
                    else
                    {
                        month += 10;
                    }

                    // different criteri for different options like suply and drug
                    int programID = ((cboSubProgram.EditValue != null) ? Convert.ToInt32(cboSubProgram.EditValue) : 0);
                    int commodityType = Convert.ToInt32(lkCommodityTypes.EditValue);
                    if (!bw.IsBusy)
                    {
                        bw.RunWorkerAsync(new int[] { storeId, month, year, programID, commodityType });
                    }
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
            // 
            cboStores.ItemIndex = 0;
            PopulateGrid();
        }



        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStatus.EditValue != null)
            {
                if (cboStatus.EditValue.ToString() != "All")
                {
                    if (cboStatus.EditValue.ToString() == "Stock Out")
                    {
                        gridItemChoiceView.ActiveFilterString = "([SOH] != '0' or [AMC] != '0' or [EverReceived] != '0') and [Status] = 'Stock Out'";
                        // gridItemChoiceView.Columns[14].Visible = true;
                    }
                    else
                    {
                        gridItemChoiceView.ActiveFilterString = "[Status] Like '" + cboStatus.EditValue.ToString() + "'";
                    }
                }
                else
                {
                    gridItemChoiceView.ActiveFilterString = "[SOH] != '0' or [AMC] != '0' or [Received] != '0'";
                }
            }
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
            string[] mon = { "Hamle", "Nehase", "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene" };
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
            cboMonth.ItemIndex = 0;
            //cboMonth_SelectedValueChanged(null, null);
            PopulateGrid();
        }


        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%' And [TypeID] = {1}", txtItemName.Text, (int)(lkCommodityTypes.EditValue ?? 0));
        }

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



        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedType = radioGroup1.EditValue.ToString();
            PopulateCatTree(SelectedType);
            PopulateGrid();
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var bal = new Balance();
            var dtBal = new DataTable();

            int[] arr = (int[])e.Argument;

            int storeId = arr[0], month = arr[1], year = arr[2], programID = arr[3], commodityTypeID = arr[4];

            switch (VisibilitySetting.HandleUnits)
            {
                case 1:
                    if (filter == "Stock Out" && ckExclude.Checked)
                    {                        
                        dtBal = bal.BalanceOfAllItemsForStockStatus(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    }
                    else if (filter == "Stock Out" && !ckExclude.Checked)
                    {
                        dtBal = bal.BalanceOfAllItemsForStockStatus(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    }
                    else if (filter == "Over Stocked" && ckExclude.Checked)
                    {
                        dtBal = bal.BalanceOfAllItemsForStockStatus(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    }
                    else if (filter == "Over Stocked" && !ckExclude.Checked)
                    {
                        dtBal = bal.BalanceOfAllItemsForStockStatus(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    }

                    e.Result = dtBal;
                    break;
                case 2:
                    dtBal = (DataTable)bal.BalanceOfAllItemsUsingUnit(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    e.Result = dtBal;
                   break;
                default:
                    dtBal = (DataTable)bal.BalanceOfAllItemsUsingUnit(storeId, year, month, SelectedType, programID, commodityTypeID, dtCur, bw);
                    e.Result = dtBal;
                   break;
            }
            //  e.Result = dtBal;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemsChoice.DataSource = (DataTable)e.Result;
            if (filter == "Stock Out" && ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Stock Out' && [EverReceived] = 1");
            }
            else if (filter == "Stock Out" && !ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Stock Out'");
            }
            else if (filter == "Over Stocked" && ckExclude.Checked)
            {
                
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Over Stocked' && [EverReceived] == 1");
            }
            else if (filter == "Over Stocked" && !ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Over Stocked'");
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
     


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridItemsChoice.MainView.ExportToXls(saveDlg.FileName);
                XtraMessageBox.Show("The stock status report has been exported", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            switch (filter)
            {
                case "Over Stocked":
                    {
                        string[] header =
                            {"Over Stocked Items Report",
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
                    break;
                case "Stock Out":
                    {
                        string[] header =
                            {
                                "Stocked Out Items Report",
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
                    break;
            }
        }

        private void lkCommodityTypes_EditValueChanged(object sender, EventArgs e)
        {
            if (filter == "Stock Out" && cboStores.EditValue !=null && ckExclude.Checked)
            {
               // PopulateGrid();
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and [Status]='Stock Out'and [EverReceived]==1",
                                                                      Convert.ToInt32(lkCommodityTypes.EditValue));
            }

            else if (filter == "Stock Out" && cboStores.EditValue != null && !ckExclude.Checked)
            {
                //PopulateGrid();
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and [Status]='Stock Out'",
                                                                      Convert.ToInt32(lkCommodityTypes.EditValue));
            }
            else if (filter == "Over Stocked" && cboStores.EditValue != null && ckExclude.Checked)
            {
                //PopulateGrid();
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and [Status]='Over Stocked'and [EverReceived]==1",
                                                                      Convert.ToInt32(lkCommodityTypes.EditValue));
            }
            else if (filter == "Over Stocked" && cboStores.EditValue != null && !ckExclude.Checked)
            {
               // PopulateGrid();
                gridItemChoiceView.ActiveFilterString = String.Format("TypeID={0} and [Status]='Over Stocked'",
                                                                      Convert.ToInt32(lkCommodityTypes.EditValue));
            }
        }

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (filter == "Stock Out" && ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Stock Out' && [EverReceived] == 1");
            }
            else if (filter == "Stock Out" && !ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Stock Out'");
            }
            else if (filter == "Over Stocked" && ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Over Stocked' && [EverReceived] == 1");
            }
            else if (filter == "Over Stocked" && !ckExclude.Checked)
            {
                gridItemChoiceView.ActiveFilterString = String.Format("[Status] == 'Over Stocked'");
            }
        }

    }
}