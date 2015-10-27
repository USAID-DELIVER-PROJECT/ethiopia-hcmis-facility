using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using PharmInventory.Forms.Modals;
using StockoutIndexBuilder;

namespace PharmInventory
{
    public partial class ECLS : Form
    {
        public ECLS()
        {
            InitializeComponent();
        }
     

        private void ManageItems_Load(object sender, EventArgs e)
        {

            DataTable dtMonths = new DataTable();
            dtMonths.Columns.Add("Value");
            dtMonths.Columns.Add("Month");
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime xx = new DateTime();
            try
            {
                xx = Convert.ToDateTime(dtDate.Text);
            }
            catch {
               
                    string dtValid = "";
                    string yer = "";
                    if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        xx = Convert.ToDateTime("12/30/" + yer);
                    }
                    else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        xx = Convert.ToDateTime("2/28/" + yer);
                    }
            }
            int currentMont = xx.Month;

            int[] val = {11,12,1,2,3,4,5,6,7,8,9,10 };
            string[] mon = { "Hamle", "Nehase", "Meskerem", "Tikemt", "Hedar", "Tahsas", "Tir", "Yekatit", "Megabit", "Miziya", "Genbot", "Sene" };
            int i = 0; //currentMont;
            //object[] oo = {currentMont,"Current Month" };
            //dtMonths.Rows.Add(oo);
            for (i = 0; i < val.Length; i++)
            {
                if (val[i] == currentMont)
                {
                    break;
                }
            }
            for (int j = i; j >= 0; j--)
            {
                object[] obj = { val[j], mon[j] };
                dtMonths.Rows.Add(obj);
            }
            cboMonth.DataSource = dtMonths;

            Stores stor = new Stores();
            stor.GetActiveStores();
            cboStores.DataSource = stor.DefaultView;

            

        }

        private void cboMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedValue != null)
            {

                dtDate.Value = DateTime.Now;
                dtDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = new DateTime(); // Convert.ToDateTime(dtDate.Text);
                try
                {
                    dtCur = Convert.ToDateTime(dtDate.Text);
                }
                catch
                {
                    string dtValid = "";
                    string yer = "";
                    if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("12/30/" + yer);
                    }
                    else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("2/28/" + yer);
                    }
                }
                int month = Convert.ToInt32(cboMonth.SelectedValue);
                int year = (month < 11) ? dtCur.Year : dtCur.Year - 1;

                Programs prog = new Programs();
                prog.GetProgramByName("Family Planning");
                Items itm = new Items();
                DataTable dtItem = itm.GetItemsByProgram(prog.ID);
                lblState.Text = "Contraceptive Items";
                lstItem.Columns[7].Text = "Issued";
                PopulateItemListByMonth(dtItem, month,year);
            }

        }

        public void PopulateItemListByMonth(DataTable dtItem,int month,int year)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtItem.Rows.Count;

            GeneralInfo pipline = new GeneralInfo();
            pipline.LoadAll();
            int min = pipline.Min;
            int max = pipline.Max;
            double eop = pipline.EOP;
            int storeId = (cboStores.SelectedValue != null)?Convert.ToInt32(cboStores.SelectedValue):1;
            
            lstItem.Items.Clear();

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = new DateTime();// Convert.ToDateTime(dtDate.Text);
            try
            {
                dtCurrent = Convert.ToDateTime(dtDate.Text);
            }
            catch
            {
                string dtValid = "";
                string yer = "";
                if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("12/30/" + yer);
                }
                else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                {
                    dtValid = dtDate.Text;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("2/28/" + yer);
                }
            }
            month = (month < 11)? month +2: ((month ==11)?1:2);
            int yyr = (month < 11)? dtCurrent.Year: dtCurrent.Year -1;

            int count = 1;
            Balance bal = new Balance();
            IssueDoc iss = new IssueDoc();
            foreach (DataRow dr in dtItem.Rows)
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString();
                
                int yer = (month < 11) ? year : year - 1;
                double AMC = Builder.CalculateAverageConsumption(Convert.ToInt32(dr["ID"]), storeId,dtCurrent.Subtract(TimeSpan.FromDays(180)),dtCurrent,CalculationOptions.Monthly);//bal.CalculateAMC(Convert.ToInt32(dr["ID"]), storeId, month, yer);
                double MinCon = AMC * min;
                double maxCon = AMC * max;
                double eopCon = AMC * (eop + 0.25);
                Int64 SOH = bal.GetSOH(Convert.ToInt32(dr["ID"]), storeId, month, yer);
                decimal MOS = (AMC != 0) ? (Convert.ToDecimal(SOH) / Convert.ToDecimal(AMC)) : 0;
                MOS = Decimal.Round(MOS, 1);

                double reorder = (maxCon > SOH) ? maxCon - SOH : 0;
                string status = (SOH <= eopCon && SOH > 0) ? "Near EOP" : ((SOH > maxCon && maxCon != 0) ? "Excess Stock" : ((SOH <= 0) ? "Stock Out" : "Normal"));
                //Int64 issuedQuant = iss.GetIssuedQuantityByMonth(Convert.ToInt32(dr["ID"]),storeId, month,yer);
                Int64 issuedQuant = iss.GetIssuedQuantity(Convert.ToInt32(dr["ID"]), storeId, yer);
                string[] str = { count.ToString(), itemName, ((SOH != 0)?SOH.ToString("#,###"): "0"), ((AMC != 0)?AMC.ToString("#,###"):"0"), MOS.ToString(), ((MinCon != 0)?MinCon.ToString("#,###"): "0"), ((maxCon != 0)?maxCon.ToString("#,###"):"0"), ((issuedQuant!= 0)?issuedQuant.ToString("#,###"):"0"), status, ((reorder!= 0)?reorder.ToString("#,###"):"0") };
                ListViewItem listItem = new ListViewItem(str);
                listItem.Tag = dr["ID"];
                //if (col != 0)
                //{
                //    listItem.BackColor = Color.FromArgb(233, 247, 248);
                //    col = 0;
                //}
                //else
                //{
                //    col++;
                //}
                
                string stat = "";
                if(cboStatus.SelectedItem != null)
                    stat = cboStatus.SelectedItem.ToString();

                switch (stat)
                {
                    case "Near EOP":
                        if (SOH <= eopCon && SOH > 0)
                        {
                            listItem.BackColor = Color.FromArgb(255, 255, 153);
                            lstItem.Items.Add(listItem);
                            count++;
                        }
                        break;
                    case "Normal":
                        if (SOH > eopCon && SOH < maxCon)
                        {
                            lstItem.Items.Add(listItem);
                            count++;
                        }
                        break;
                    case "Stock Out":
                        if (SOH <= 0)
                        {
                            listItem.BackColor = Color.FromArgb(246, 168, 168);
                            lstItem.Items.Add(listItem);
                            count++;
                        }
                        break;
                    case "Excess Stock":
                        if (SOH > maxCon && maxCon != 0)
                        {
                            listItem.BackColor = Color.FromArgb(163, 209, 255);
                            lstItem.Items.Add(listItem);
                            count++;
                        }
                        break;
                    default:
                        if (SOH <= eopCon && SOH > 0)
                            listItem.BackColor = Color.FromArgb(255, 255, 153);
                        else if (SOH > maxCon && maxCon != 0)
                            listItem.BackColor = Color.FromArgb(163, 209, 255);
                        else if (SOH <= 0)
                            listItem.BackColor = Color.FromArgb(246, 168, 168);
                        lstItem.Items.Add(listItem);
                        count++;
                        break;
                }
                progressBar1.PerformStep();
                
            }
            progressBar1.Visible = false;
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedItem != null)
            {
                Items itm = new Items();
                DataTable dtItm = itm.GetAllItems(1);
              //  PopulateItemListByMonth(dtItm,Convert.ToInt32(cboMonth.SelectedValue),DateTime.Now.Year);
            }
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
            {
                dtDate.Value = DateTime.Now;
                dtDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = new DateTime();// Convert.ToDateTime(dtDate.Text);
                try
                {
                    dtCur = Convert.ToDateTime(dtDate.Text);
                }
                catch
                {
                    string dtValid = "";
                    string yer = "";
                    if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("12/30/" + yer);
                    }
                    else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("2/28/" + yer);
                    }
                }
                int month = Convert.ToInt32(cboMonth.SelectedValue);
                int year = (month < 11) ? dtCur.Year : dtCur.Year - 1;

                Programs prog = new Programs();
                prog.GetProgramByName("Family Planning");
                Items itm = new Items();
                DataTable dtItm = itm.GetItemsByProgram(prog.ID);
                PopulateItemListByMonth(dtItm, month,year);
               // PopulateItemListBlance(dtItm);
            }
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedItem != null)
            {
                dtDate.Value = DateTime.Now;
                dtDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = new DateTime();// Convert.ToDateTime(dtDate.Text);
                try
                {
                    dtCur = Convert.ToDateTime(dtDate.Text);
                }
                catch
                {
                    string dtValid = "";
                    string yer = "";
                    if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("12/30/" + yer);
                    }
                    else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("2/28/" + yer);
                    }
                }
                int month = Convert.ToInt32(cboMonth.SelectedValue);
                int year = (month < 11) ? dtCur.Year : dtCur.Year - 1;

                Programs prog = new Programs();
                prog.GetProgramByName("Family Planning");
                Items itm = new Items();
                DataTable dtItm = itm.GetItemsByProgram(prog.ID);
                PopulateItemListByMonth(dtItm,month,year);
            }
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            //DateTime dtCur = Convert.ToDateTime();
            string[] header = {info.HospitalName,cboStores.Text,"Contraceptive Stock Status","YEAR: " + dtDate.Text,cboMonth.Text };
            MainWindow.ExportToExcel(lstItem,header);
        }

        private void lstItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItem.SelectedItems[0].Tag != null)
            {
                dtDate.Value = DateTime.Now;
                dtDate.CustomFormat = "MM/dd/yyyy";
                DateTime dtCur = new DateTime();// Convert.ToDateTime(dtDate.Text);
                try
                {
                    dtCur = Convert.ToDateTime(dtDate.Text);
                }
                catch
                {
                    string dtValid = "";
                    string yer = "";
                    if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 13)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("12/30/" + yer);
                    }
                    else if (Convert.ToInt32(dtDate.Text.Substring(0, 2)) == 2)
                    {
                        dtValid = dtDate.Text;
                        yer = dtValid.Substring(dtValid.Length - 4, 4);
                        dtCur = Convert.ToDateTime("2/28/" + yer);
                    }
                }
                int month = Convert.ToInt32(cboMonth.SelectedValue);
                int year = (month < 11) ? dtCur.Year : dtCur.Year - 1;

                int itemId = Convert.ToInt32(lstItem.SelectedItems[0].Tag);
                ItemDetailReport con = new ItemDetailReport(itemId,Convert.ToInt32(cboStores.SelectedValue),year,0);
                con.ShowDialog();
            }
        }

        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void xpButton1_Click_1(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();
            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";

            string header = info.HospitalName + " Contraceptive Items " + cboStores.Text + " Date: " + dtDate.Text + " (" + cboMonth.Text + ")";
            lstItem.Title = header;
            lstItem.FitToPage = true;
            lstItem.Print();
        }

        
    }
}