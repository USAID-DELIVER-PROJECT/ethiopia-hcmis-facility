using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory.Forms.ActivityLogs
{
    /// <summary>
    /// Shows a log of the PickLists
    /// </summary>
    public partial class LogPickList : XtraForm
    {
        public LogPickList()
        {
            InitializeComponent();
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {
            ReceivingUnits rec = new ReceivingUnits();
            DataTable drRec = rec.GetAllApplicableDU();
            cboIssuedTo.Properties.DataSource = drRec;
            cboIssuedTo.ItemIndex = -1;//.SelectedIndex = -1;
            cboIssuedTo.Text = @"Select Issue Location";

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.Properties.DataSource = stor.DefaultView;
            cboStores.ItemIndex = 0;
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null)
            {
                IssueDoc iss = new IssueDoc();
                //TODO: To be implemented

               // DataTable dtRec = iss.GetDistinctIssueDocments(Convert.ToInt32(cboStores.EditValue));
               // /*PopulateDocument(dtRec);*/lstTree.DataSource = dtRec;
               // DateTime dt1 = new DateTime();
               // DateTime dt2 = new DateTime();
               // CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
               // dtDate.Value = DateTime.Now;
               // dtDate.CustomFormat = "MM/dd/yyyy";
               // DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
               // int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
               // dt1 = new DateTime(yr, 11, 1);
               // dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
               // dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dt1, dt2);
               // lblIssDate.Text = "Current Year";
               //gridIssues.DataSource = dtRec;
            }
        }

        private void cboIssuedTo_EditValueChanged(object sender, EventArgs e)
        {
            if (cboIssuedTo.EditValue!= null && cboStores.EditValue != null)
            {
                //TODO:To be implemented
                //IssueDoc iss = new IssueDoc();
                //DataTable dtRec = new DataTable();

                //dtRec = iss.GetTransactionByReceivingUnit(Convert.ToInt32(cboStores.EditValue),Convert.ToInt32(cboIssuedTo.EditValue));
                //gridIssues.DataSource = dtRec;
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            //TODO: to be implemented
            //IssueDoc iss = new IssueDoc();
            //DataTable dtRec = new DataTable();
            //dtFrom.CustomFormat = "MM/dd/yyyy";
            //dtTo.CustomFormat = "MM/dd/yyyy";
            //DateTime dteFrom = new DateTime();
            //DateTime dteTo = new DateTime();
            
            //dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            //dteTo = ConvertDate.DateConverter(dtTo.Text);
           
            //if (dteFrom < dteTo)
            //{
            //    dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), dteFrom,dteTo);
            //}
            //else
            //{
            //    dtRec = iss.GetAllTransaction(Convert.ToInt32(cboStores.EditValue));
            //}
            //*PopulateTransaction(dtRec);*/gridIssues.DataSource = dtRec;
        }
        private void button1_Click(object sender, EventArgs e)
        {
         
            SaveFileDialog saveDlg = new SaveFileDialog {Filter = @"Microsoft Excel | *.xls"};

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridIssues.MainView.ExportToXls(saveDlg.FileName);
            }
        }

      
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            pcl.CreateReportHeaderArea += this.pcl_CreateReportHeaderArea;
            pcl.Component = gridIssues;
            pcl.Landscape = true;

            pcl.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }

        private void pcl_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          Value = DateTime.Now,
                                                          CustomFormat = "MM/dd/yyyy"
                                                      };
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            string header = info.HospitalName + " Issue Activity Log " + dtCurrent.ToString("MM dd,yyyy");

            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 500, 40),
            DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void lstTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx
                                                      {
                                                          CustomFormat = "MM/dd/yyyy",
                                                          Value = DateTime.Now
                                                      };
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);

            if (dr == null) return;

            //lstTransactions.Items.Clear();                
            IssueDoc iss = new IssueDoc();
            DataTable dtRec;
            if (dr["ParentID"] == DBNull.Value)
            {
                EthiopianDate.EthiopianDate ethiopianDate = new EthiopianDate.EthiopianDate(Convert.ToInt32(dr["ID"]), 1, 1);
                dtRec = iss.GetTransactionByDateRange(Convert.ToInt32(cboStores.EditValue), ethiopianDate.StartOfFiscalYear.ToGregorianDate(), ethiopianDate.EndOfFiscalYear.ToGregorianDate());
                string dateString = dr["RefNo"].ToString();
                lblIssDate.Text = dateString;
            }
            else
            {
                //dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(cboStores.EditValue), dr["Date"].ToString());
                dtRec = iss.GetTransactionByRefNo(dr["RefNo"].ToString(),Convert.ToDateTime(dr["Date"]));
                lblIssDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
            }
            gridIssues.DataSource = dtRec;
        }
    
    }
}