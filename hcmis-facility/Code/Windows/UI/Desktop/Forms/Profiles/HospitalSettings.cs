using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction logic for the HospitalSettings 
    /// </summary>
    public partial class HospitalSettings : XtraForm
    {
        public HospitalSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the drop downs and tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HospitalSettings_Load(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            sup.LoadAll();
            PopulateSupplier(sup);

            Stores str = new Stores();
            str.LoadAll();
            PopulateStores(str);

            Shelf slf = new Shelf();
            DataTable dtSlf = slf.GetShelves();
            PopulateShelves(dtSlf.DefaultView);

            ReceivingUnits recUnit = new ReceivingUnits();
            recUnit.LoadAll();
            PopulateReceivingUnit(recUnit);

            DataTable dtdumin = new DataTable();
            dtdumin.Columns.Add("Value");
            dtdumin.Columns.Add("Month");
            object[] objdumin01 = { 0.25, "1 Weeks" };
            dtdumin.Rows.Add(objdumin01);
            object[] objdumin0 = { 0.5, "2 Weeks" };
            dtdumin.Rows.Add(objdumin0);
            object[] objdumin1 = { 0.75, ("3 Weeks") };
            dtdumin.Rows.Add(objdumin1);
            object[] objdumin2 = { 1, (1 + " Month") };
            dtdumin.Rows.Add(objdumin2);
            object[] objdumin3 = { 2, (2 + " Month") };
            dtdumin.Rows.Add(objdumin3);
            cboDUMin.DataSource = dtdumin;

            DataTable dtdumax = new DataTable();
            dtdumax.Columns.Add("Value");
            dtdumax.Columns.Add("Month");
            object[] objdumax01 = { 0.25, "1 Weeks" };
            dtdumax.Rows.Add(objdumax01);
            object[] objdumax010 = { 0.5, "2 Weeks" };
            dtdumax.Rows.Add(objdumax010);
            object[] objdumax011 = { 0.75, ("3 Weeks") };
            dtdumax.Rows.Add(objdumax011);
            object[] objdumax012 = { 1, (1 + " Month") };
            dtdumax.Rows.Add(objdumax012);
            object[] objdumax013 = { 2, (2 + " Month") };
            dtdumax.Rows.Add(objdumax013);
            cboDUMax.DataSource = dtdumax;

        }

        #region  Supplier

        private int _shelfId = 0;
        int _supplierId = 0;
        string _sortSupplier = "ASC";

        /// <summary>
        /// Populates the lstSuppliers with the supplied Suppliers
        /// </summary>
        /// <param name="sup"></param>
        private void PopulateSupplier(Supplier sup)
        {
            lstSuppliers.DataSource = sup.DefaultView;
        }

 

        /// <summary>
        /// Saves supplier information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplierSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text != "" && cboCompanyInfo.SelectedItem != null)
            {
                Supplier sup = new Supplier();
                if (_supplierId != 0)
                    sup.LoadByPrimaryKey(_supplierId);
                else
                    sup.AddNew();
                sup.CompanyInfo = cboCompanyInfo.SelectedItem.ToString();
                sup.CompanyName = txtCompanyName.Text;
                sup.Address = txtAddress.Text;
                sup.ContactPerson = txtContactPerson.Text;
                sup.Telephone = txtTelephone.Text;
                sup.IsActive = ckIsActive.Checked;
                sup.Mobile = txtMobile.Text;
                sup.Email = txtEmail.Text;
                sup.Save();
                sup.LoadAll();
                PopulateSupplier(sup);
                ResetSupplier();
                XtraMessageBox.Show("Supplier Record Updated.", "Confirmation", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            else
            {
                txtCompanyName.BackColor = Color.FromArgb(251, 214, 214);
            }

           
        }

        /// <summary>
        /// Cancels the save (Resets the supplier info)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetSupplier();
        }

        /// <summary>
        /// Resets the fields related to the supplier information
        /// </summary>
        private void ResetSupplier()
        {
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtMobile.Text = "";
            txtTelephone.Text = "";
            ckIsActive.Checked = true;
            _supplierId = 0;
            cboCompanyInfo.SelectedItem = "";
            txtEmail.Text = "";
            btnSupplierSave.Text = "Save";
            txtCompanyName.BackColor = Color.White;
        }

        
        #endregion

        #region Stores

        int _storeId = 0;
        string _sortStore = "ASC";

        /// <summary>
        /// Populates lstStores based stores supplied
        /// </summary>
        /// <param name="str"></param>
        private void PopulateStores(Stores str)
        {

            lstStores.Items.Clear();
            int count = 1;
            int col = 0;
            foreach (DataRowView dv in str.DefaultView)
            {
                string[] st = { count.ToString(), dv["StoreName"].ToString(), "" };
                ListViewItem lst = new ListViewItem(st) {Tag = dv["ID"]};
                if (col != 0)
                {
                    lst.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                    col++;
                lstStores.Items.Add(lst);
                count++;
            }
        }

        /// <summary>
        /// Handles the selectIndexChangedEvent of the lstStores
        /// Updates the store information based on the selected store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStores.SelectedItems.Count > 0)
            {
                int selected = Convert.ToInt32(lstStores.SelectedItems[0].Tag);
                Stores str = new Stores();
                str.LoadByPrimaryKey(selected);
                txtStore.Text = str.StoreName;
                chkStoreIsActive.Checked = str.IsColumnNull("IsActive") ? true : str.IsActive;

                _storeId = str.ID;
                btnStoresSave.Text = "Update";
            }
        }

        /// <summary>
        /// Saves store information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStoresSave_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "")
            {
                Stores str = new Stores();
                if (_storeId != 0)
                    str.LoadByPrimaryKey(_storeId);
                else
                    str.AddNew();
                str.StoreName = txtStore.Text;
                str.IsActive = chkStoreIsActive.Checked;
                str.Save();
                str.LoadAll();
                PopulateStores(str);
                ResetStores();
            }
            else
            {
                txtStore.BackColor = Color.FromArgb(251, 214, 214);
            }
            XtraMessageBox.Show("Store Record Updated.", "Confirmation", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        private void xpButton7_Click(object sender, EventArgs e)
        {
            ResetStores();
        }

        private void xpButton8_Click(object sender, EventArgs e)
        {
            ResetStores();
        }

        /// <summary>
        /// Resets the store related information on the form
        /// </summary>
        private void ResetStores()
        {
            txtStore.Text = "";
            _storeId = 0;
            btnStoresSave.Text = "Save";
            txtStore.BackColor = Color.White;
        }

        /// <summary>
        /// Handles the sorting when the user clicks on the lstStores columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstStores_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Stores str = new Stores();
            str.LoadAll();
            if (_sortStore == "ASC")
            {
                str.Sort = "StoreName ASC";
                _sortStore = "DESC";
            }
            else
            {
                str.Sort = "StoreName DESC";
                _sortStore = "ASC";
            }
            PopulateStores(str);
        }

        #endregion

        #region Shelf

        /// <summary>
        /// Populates the shelf information
        /// </summary>
        /// <param name="dtSlf"></param>
        private void PopulateShelves(DataView dtSlf)
        {
            int count = 1;
            int col = 0;
            lstShelfs.Items.Clear();
            foreach (DataRow dv in dtSlf.ToTable().Rows)
            {
                string[] st = { count.ToString(), dv["ShelfCode"].ToString(), dv["ShelfType"].ToString(), "", "" };
                ListViewItem lst = new ListViewItem(st) {Tag = dv["ID"]};
                if (col != 0)
                {
                    lst.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                    col++;
                lstShelfs.Items.Add(lst);
                count++;
            }

            Stores str = new Stores();
            str.LoadAll();
            cboStore.DataSource = str.DefaultView;

        }

        /// <summary>
        /// Update the form based on the selected shelf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstShelfs.SelectedItems.Count > 0)
            {
                int selected = Convert.ToInt32(lstShelfs.SelectedItems[0].Tag);
                Shelf slf = new Shelf();
                slf.LoadByPrimaryKey(selected);
                txtShelf.Text = slf.ShelfCode;
                cboStore.SelectedValue = slf.StoreID.ToString();
                if (slf.IsColumnNull("ShelfStorageType"))
                {
                    slf.ShelfStorageType = 1;
                }

                cboType.SelectedValue = slf.ShelfStorageType;

                _shelfId = slf.ID;
                btnLocationsave.Text = "Update";
            }
        }

        private void xpButton10_Click(object sender, EventArgs e)
        {
            ResetLocations();
        }

        private void xpButton12_Click(object sender, EventArgs e)
        {
            Shelf slf = new Shelf();
            
            if(txtShelf.Text=="")
            {
                XtraMessageBox.Show("Please enter the bin code", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }

            if (_shelfId != 0)
                slf.LoadByPrimaryKey(_shelfId);
            else
                slf.AddNew();
            slf.ShelfCode = txtShelf.Text;
            //slf.ShelfStorageType = int.Parse(cboType.SelectedItem.ToString());
            slf.Save();
            DataTable dtSlf = slf.GetShelves();
            PopulateShelves(dtSlf.DefaultView);
            ResetLocations();
            XtraMessageBox.Show("Bin Location Record Updated.", "Confirmation", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Resets locations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton11_Click(object sender, EventArgs e)
        {
            ResetLocations();
        }

        /// <summary>
        /// Resets the location related fields on the form
        /// </summary>
        private void ResetLocations()
        {
            txtShelf.Text = "";
            txtPhyStore.Text = "";
            _shelfId = 0;
            cboStore.SelectedIndex = -1;
            cboType.SelectedIndex = 3;
            btnLocationsave.Text = "Save";
        }
        private int _sortColumn = -1;

        /// <summary>
        /// Handles sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstShelfs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //int clicked = e.Column;
            if (e.Column != _sortColumn)
            {
                _sortColumn = e.Column;
                lstShelfs.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstShelfs.Sorting = ((lstShelfs.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
            }
            int num = 0;
            switch (e.Column)
            {
                case 0:
                    num = 0;
                    break;
                default:
                    num = 1;
                    break;
            }
            this.lstShelfs.ListViewItemSorter = new ListViewItemComparer(e.Column, lstShelfs.Sorting, num);
            //this.lstItem.Sorting = ((lstItem.Sorting == SortOrder.Ascending)? SortOrder.Descending : SortOrder.Ascending);
            lstShelfs.Sort();
        }


        /// <summary>
        /// Change the formatting of txtCompanyName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            txtCompanyName.BackColor = Color.White;
        }

        /// <summary>
        /// Resets supplier related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            ResetSupplier();
        }

        #endregion

        #region Receiving Unit

        int _receivingUnitId = 0;
        string _sortIssueLoca = "ASC";

        /// <summary>
        /// Populates receiving units
        /// </summary>
        /// <param name="recUnit"></param>
        private void PopulateReceivingUnit(ReceivingUnits recUnit)
        {
            int count = 1;
            int col = 0;
            lstReceivingUnit.Items.Clear();

            foreach (DataRowView dv in recUnit.DefaultView)
            {
                string dumin = "";
                string dumax = "";
                if (dv["Min"] != DBNull.Value)
                {
                    double min = Convert.ToDouble(dv["Min"]);
                    if (min == 0.25)
                        dumin = "1 Weeks";
                    else if (min == 0.5)
                        dumin = "2 Weeks";
                    else if (min == 0.75)
                        dumin = "3 Weeks";
                    else if (min == 1)
                        dumin = "1 Month";
                    else if (min == 2)
                        dumin = "2 Month";
                    else
                        dumin = "";
                }

                if (dv["Max"] != DBNull.Value)
                {
                    double max = Convert.ToDouble(dv["Max"]);
                    if (max == 0.25)
                        dumax = "1 Weeks";
                    else if (max == 0.5)
                        dumax = "2 Weeks";
                    else if (max == 0.75)
                        dumax = "3 Weeks";
                    else if (max == 1)
                        dumax = "1 Month";
                    else if (max == 2)
                        dumax = "2 Month";
                    else
                        dumax = "";
                }

                string[] str = { count.ToString(), dv["Name"].ToString(), dv["Phone"].ToString(), dumin, dumax };
                ListViewItem lst = new ListViewItem(str) {Tag = dv["ID"]};
                if (col != 0)
                {
                    lst.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                    col++;
                lstReceivingUnit.Items.Add(lst);
                count++;

            }
        }

        /// <summary>
        /// Handles the Index Changed event of the receiving unit list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstReceivingUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReceivingUnit.SelectedItems.Count > 0)
            {
                int selected = Convert.ToInt32(lstReceivingUnit.SelectedItems[0].Tag);
                ReceivingUnits recUnit = new ReceivingUnits();
                recUnit.LoadByPrimaryKey(selected);
                txtReceivingUnit.Text = recUnit.Name;
                memoEdit1.Text = recUnit.Description;
                txtPhone.Text = recUnit.Phone;
                txtWoreda.Text = recUnit.Woreda;
                txtRegion.Text = recUnit.Region;
                txtZone.Text = recUnit.Zone;
                txtType.Text = recUnit.FacilityType;
                chkIsDispensaryActive.Checked = recUnit.IsColumnNull("IsActive") ? true : recUnit.IsActive;
                _receivingUnitId = recUnit.ID;
                try
                {
                    cboDUMax.SelectedValue = recUnit.Max.ToString();
                    cboDUMin.SelectedValue = recUnit.Min.ToString();
                }
                catch { }
                btnIssueSave.Text = "Update";
            }
        }

        /// <summary>
        /// Resets issues locations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton13_Click(object sender, EventArgs e)
        {
            ResetIssuesLocation();
        }

        /// <summary>
        /// Saves the receiving unit related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIssueSave_Click(object sender, EventArgs e)
        {
            if(txtReceivingUnit.Text=="")
            {
                XtraMessageBox.Show("Please enter the name of the receiving unit", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            
            ReceivingUnits recUnit = new ReceivingUnits();
            if (_receivingUnitId != 0)
            {
                recUnit.LoadByPrimaryKey(_receivingUnitId);
                recUnit.Name = txtReceivingUnit.Text;
                recUnit.Phone = txtPhone.Text;
                recUnit.Description = memoEdit1.Text;
                recUnit.IsActive = chkIsDispensaryActive.Checked;
                recUnit.Min = Convert.ToDouble(cboDUMin.SelectedValue);
                recUnit.Max = Convert.ToDouble(cboDUMax.SelectedValue);
                recUnit.Woreda = txtWoreda.Text;
                recUnit.Region = txtRegion.Text;
                recUnit.Zone = txtZone.Text;
                recUnit.FacilityType = txtType.Text;
                recUnit.Save();
              

                //recUnit.Save();

                XtraMessageBox.Show("Issue Location Record Updated.", "Confirmation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            else
            {
                recUnit.AddNew();
                recUnit.Name = txtReceivingUnit.Text;
                recUnit.Phone = txtPhone.Text;
                recUnit.Description = memoEdit1.Text;
                recUnit.IsActive = chkIsDispensaryActive.Checked;
                recUnit.Min = Convert.ToDouble(cboDUMin.SelectedValue);
                recUnit.Max = Convert.ToDouble(cboDUMax.SelectedValue);
                recUnit.Woreda = txtWoreda.Text;
                recUnit.Region = txtRegion.Text;
                recUnit.Zone = txtZone.Text;
                recUnit.FacilityType = txtType.Text;
                recUnit.Save();
                recUnit.LoadAll();
                PopulateReceivingUnit(recUnit);
                ResetIssuesLocation();
                XtraMessageBox.Show("Issue Location Record Saved.", "Confirmation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Resets receviing unit related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpButton14_Click(object sender, EventArgs e)
        {
            ResetIssuesLocation();
        }

        /// <summary>
        /// Resets the receiving unit related information
        /// </summary>
        private void ResetIssuesLocation()
        {
            memoEdit1.Text = "";
            txtPhone.Text = "";
            txtReceivingUnit.Text = "";
            txtRegion.Text = "";
            txtZone.Text = "";
            txtWoreda.Text = "";
            txtType.Text = "";
            _receivingUnitId = 0;
            btnIssueSave.Text = "Save";
        }

        /// <summary>
        /// Handles sorting for the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstReceivingUnit_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ReceivingUnits recUnit = new ReceivingUnits();
            recUnit.LoadAll();
            if (_sortIssueLoca == "ASC")
            {
                recUnit.Sort = "Name ASC";
                _sortIssueLoca = "DESC";
            }
            else
            {
                recUnit.Sort = "Name DESC";
                _sortIssueLoca = "ASC";
            }
            PopulateReceivingUnit(recUnit);
        }

        #endregion

        private void viewSupplies_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewSupplies.GetFocusedDataRow();
            if (dr != null)
            {
                int selected = Convert.ToInt32(dr["ID"]);
                Supplier sup = new Supplier();
                sup.LoadByPrimaryKey(selected);
                txtCompanyName.Text = sup.CompanyName;
                 txtAddress.Text = sup.Address;
                txtContactPerson.Text = sup.ContactPerson;
                txtMobile.Text = sup.Mobile;
                txtTelephone.Text = sup.Telephone;
                txtEmail.Text = sup.Email;
                ckIsActive.Checked = sup.IsColumnNull("IsActive")?false: sup.IsActive;
                _supplierId = sup.ID;
                cboCompanyInfo.SelectedItem = sup.CompanyInfo;
                btnSupplierSave.Text = "Update";
            }
        }


    }

}