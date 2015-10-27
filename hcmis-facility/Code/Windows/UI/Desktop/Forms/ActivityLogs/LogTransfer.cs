using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.ActivityLogs
{
    public partial class LogTransfer : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRec;
        private readonly CalendarLib.DateTimePickerEx _dtDate = new CalendarLib.DateTimePickerEx();
        public LogTransfer()
        {
            InitializeComponent();
        }

        private void LogTransfer_Load(object sender, EventArgs e)
        {
            var stor = new Stores();
            stor.GetActiveStores();
           // lkFromStore.ItemIndex = 0;
            storeBindingSource.DataSource = stor.DefaultView;

          
            var itemunit = new ItemUnit();
            var units = itemunit.GetAllUnits();
            unitBindingSource.DataSource = units.DefaultView;



            // bind the supplier lookup for the grid.
            
            var unitcolumn = ((GridView)gridControl1.MainView).Columns[4];
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


            lkToStore.Properties.DataSource = stor.DefaultView;
            lkToStore.ItemIndex = 0;
            // bind the current dates

            try
            {
                var dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.Nodes[0].FirstNode);
                if (dr == null) return;
                var rec = new Transfer();
                if (dr["ParentID"] == DBNull.Value)
                {
                    // int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    var dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                    var dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                    dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(lkToStore.EditValue), dt1, dt2);
                    lblTransferedDate.Text = dr["RefNo"].ToString();
                }
                else
                {
                    dtRec = rec.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(lkToStore.EditValue), dr["Date"].ToString());
                    lblTransferedDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
                }
                gridControl1.DataSource = dtRec;
            }
            catch (Exception ex)
            {

            }
        }

        
        private void PopulateDocuments(DataTable dataTable)
        {
            lstTree.DataSource = dataTable;
            lstTree.ExpandAll();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            var rec = new Transfer();
            dtFrom.CustomFormat = "MM/dd/yyyy";
            dtTo.CustomFormat = "MM/dd/yyyy";

            DateTime dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            DateTime dteTo = ConvertDate.DateConverter(dtTo.Text);

            DataTable dtRec = dteFrom < dteTo
                                  ? rec.GetTransactionByDateRange(Convert.ToInt32(lkToStore.EditValue), dteFrom, dteTo)
                                  : rec.GetAllTransaction(Convert.ToInt32(lkToStore.EditValue));
            gridControl1.DataSource = dtRec;
            dtFrom.CustomFormat = "MMMM dd, yyyy";
            dtTo.CustomFormat = "MMMM dd, yyyy";
        }

        private void lkToStore_EditValueChanged(object sender, EventArgs e)
        {
            if (lkToStore.EditValue == null) return;
            var rec = new Transfer();
            dtRec = rec.GetDistinctRecDocments(Convert.ToInt32(lkToStore.EditValue));

            PopulateDocuments(dtRec);
        }

        private void lstTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var dtDate = new CalendarLib.DateTimePickerEx
            {
                CustomFormat = "MM/dd/yyyy",
                Value = DateTime.Now
            };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            var dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);
            if (dr == null) return;

            var rec = new Transfer();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                DateTime dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                DateTime dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                dtRec = rec.GetTransactionByDateRange(Convert.ToInt32(lkToStore.EditValue), dt1, dt2);
                lblTransferedDate.Text = dr["RefNo"].ToString();
            }
            else
            {
                dtRec = rec.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(lkToStore.EditValue), dr["Date"].ToString());
              lblTransferedDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }

            gridControl1.DataSource = dtRec;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            pcl.CreateReportHeaderArea += this.pcl_CreateReportHeaderArea;

            pcl.Component = gridControl1;
            pcl.Landscape = true;

            pcl.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }

        private void pcl_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();
            var dtDate = new CalendarLib.DateTimePickerEx
            {
                Value = DateTime.Now,
                CustomFormat = "MM/dd/yyyy"
            };
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            // original header
            // string header = info.HospitalName + " Receive Activity Log " + dtCurrent.ToString("MM dd,yyyy");
            // header with reference number
            string refNumber = lstTree.FocusedNode.GetDisplayText("RefNo");
            string header = info.HospitalName + " Transfer Activity Log \n" + dtCurrent.ToString("MM dd,yyyy") +
                            "   RefNo " + refNumber;

            TextBrick brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 500, 40),
                                                 DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var fileName = MainWindow.GetNewFileName("xls");
            gridControl1.ExportToXls(fileName);
            MainWindow.OpenInExcel(fileName);

        }
    }
}