using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction logic for the Pipeline Form.
    /// </summary>
    public partial class Pipeline : XtraForm
    {
        public Pipeline()
        {
            InitializeComponent();
        }

        readonly GeneralInfo _pipeline = new GeneralInfo();
        int _pipelineId = 0;

        /// <summary>
        /// Loads the lookups and 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pipeline_Load(object sender, EventArgs e)
        {
            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            for (int i = 1; i <= 12; i++)
            {
                object[] obj = { i, (i + " Month") };
                dtMonths.Rows.Add(obj);
            }
            cboLeadTime.DataSource = dtMonths;

            DataTable dtMonths2 = new DataTable();
            dtMonths2.Columns.Add("Value");
            dtMonths2.Columns.Add("Month");
            for (int i = 1; i <= 12; i++)
            {
                object[] obj = { i, (i + " Month") };
                dtMonths2.Rows.Add(obj);
            }

            cboSafety.DataSource = dtMonths2;

            DataTable dtMonths3 = new DataTable();
            dtMonths3.Columns.Add("Value");
            dtMonths3.Columns.Add("Month");
            for (int i = 1; i <= 12; i++)
            {
                object[] obj = { i, (i + " Month") };
                dtMonths3.Rows.Add(obj);
            }

            cboReview.DataSource = dtMonths3;

            DataTable dtEOP = new DataTable();
            dtEOP.Columns.Add("Value");
            dtEOP.Columns.Add("Month");
            //object[] obj01 = { 0.25, "1 Weeks" };
            //dtEOP.Rows.Add(obj01);
            object[] obj0 = { 0.5, "2 Weeks" };
            dtEOP.Rows.Add(obj0);
            object[] obj1 = { 0.75, ("3 Weeks") };
            dtEOP.Rows.Add(obj1);
            object[] obj2 = { 1, (1 + " Month") };
            dtEOP.Rows.Add(obj2);
            object[] obj3 = { 2, (2 + " Month") };
            dtEOP.Rows.Add(obj3);
            cboEOP.DataSource = dtEOP;

            //DataTable dtdumin = new DataTable();
            //dtdumin.Columns.Add("Value");
            //dtdumin.Columns.Add("Month");
            //object[] objdumin01 = { 0.25, "1 Weeks" };
            //dtdumin.Rows.Add(objdumin01);
            //object[] objdumin0 = { 0.5, "2 Weeks" };
            //dtdumin.Rows.Add(objdumin0);
            //object[] objdumin1 = { 0.75, ("3 Weeks") };
            //dtdumin.Rows.Add(objdumin1);
            //object[] objdumin2 = { 1, (1 + " Month") };
            //dtdumin.Rows.Add(objdumin2);
            //object[] objdumin3 = { 2, (2 + " Month") };
            //dtdumin.Rows.Add(objdumin3);
            //cboDUMin.DataSource = dtdumin;

            //DataTable dtdumax = new DataTable();
            //dtdumax.Columns.Add("Value");
            //dtdumax.Columns.Add("Month");
            //object[] objdumax01 = { 0.25, "1 Weeks" };
            //dtdumax.Rows.Add(objdumax01);
            //object[] objdumax010 = { 0.5, "2 Weeks" };
            //dtdumax.Rows.Add(objdumax010);
            //object[] objdumax011 = { 0.75, ("3 Weeks") };
            //dtdumax.Rows.Add(objdumax011);
            //object[] objdumax012 = { 1, (1 + " Month") };
            //dtdumax.Rows.Add(objdumax012);
            //object[] objdumax013 = { 2, (2 + " Month") };
            //dtdumax.Rows.Add(objdumax013);
            //cboDUMax.DataSource = dtdumax;

            DataTable dtAmcRange = new DataTable();
            dtAmcRange.Columns.Add("Value");
            dtAmcRange.Columns.Add("Month");
            object[] objamcR00 = { 1, (1 + " Month") };
            dtAmcRange.Rows.Add(objamcR00);
            object[] objamcR01 = { 3, (3 + " Month") };
            dtAmcRange.Rows.Add(objamcR01);
            object[] objamcR010 = { 6, (6 + " Month") };
            dtAmcRange.Rows.Add(objamcR010);
            object[] objamcR011 = { 12, (12 + " Month") };
            dtAmcRange.Rows.Add(objamcR011);
            cboAmcRange.DataSource = dtAmcRange;

            PopulateFields();
        }

        /// <summary>
        /// Populates the fields in the form
        /// </summary>
        private void PopulateFields()
        {
            _pipeline.LoadAll();
            cboLeadTime.SelectedValue = _pipeline.LeadTime.ToString();
            cboSafety.SelectedValue = _pipeline.SafteyStock.ToString();
            cboReview.SelectedValue = _pipeline.ReviewPeriod.ToString();
            cboEOP.SelectedValue = _pipeline.EOP.ToString();
            txtMin.Text = _pipeline.Min.ToString() + " Month";
            txtmax.Text = _pipeline.Max.ToString() + " Month";

            cboAmcRange.SelectedValue = _pipeline.AMCRange.ToString();
            rdEven.Checked = _pipeline.IsEven;
            rdOdd.Checked = !_pipeline.IsEven;
            _pipelineId = _pipeline.ID;
        }

        /// <summary>
        /// Handles save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show("Are You sure you want to apply these Settings?", "Confirmation",
                                MessageBoxButtons.YesNo) != DialogResult.Yes) 
                return;

            if (_pipelineId == 0) 
                return;

            _pipeline.LoadByPrimaryKey(_pipelineId);
            _pipeline.SafteyStock = Convert.ToInt32(cboSafety.SelectedValue);
            _pipeline.LeadTime = Convert.ToInt32(cboLeadTime.SelectedValue);
            _pipeline.ReviewPeriod = Convert.ToInt32(cboReview.SelectedValue);
            _pipeline.Max = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue) + Convert.ToInt32(cboReview.SelectedValue);
            _pipeline.Min = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue);
            _pipeline.EOP = Convert.ToDouble(cboEOP.SelectedValue);
            _pipeline.IsEven = rdEven.Checked;
            _pipeline.DUMin = Convert.ToDouble(cboDUMin.SelectedValue);
            _pipeline.DUMax = Convert.ToDouble(cboDUMax.SelectedValue);
            _pipeline.AMCRange = Convert.ToInt32(cboAmcRange.SelectedValue);
            
            _pipeline.Save();

            PopulateFields();

            bwAMCCalculate.RunWorkerAsync();
        }

        /// <summary>
        /// Populates fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateFields();
        }

        /// <summary>
        /// Calculate the Min and Max when the cboReview is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboReview_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalculateMinMax();
        }

        /// <summary>
        /// Calculates the min and max values
        /// </summary>
        private void CalculateMinMax()
        {
            if (cboLeadTime.SelectedValue != null && cboSafety.SelectedValue != null)
            {
                int min = Convert.ToInt32(cboLeadTime.SelectedValue) + Convert.ToInt32(cboSafety.SelectedValue);
                txtMin.Text = min.ToString() + " Month";
                if (cboReview.SelectedValue != null)
                {
                    int max = Convert.ToInt32(cboReview.SelectedValue) + min;
                    txtmax.Text = max.ToString() + " Month";
                }
            }
        }

        private void bwAMCCalculate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            HelperClasses.CalculateAMC calcAMC = new HelperClasses.CalculateAMC();
            calcAMC.BuildAMC(true);
        }
    }
}