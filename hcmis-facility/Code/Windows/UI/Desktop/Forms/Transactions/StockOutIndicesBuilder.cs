using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using System.Linq;
using DevExpress.XtraEditors;
using PharmInventory.ViewModels;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.Transactions
{
    public partial class StockOutIndicesBuilder : DevExpress.XtraEditors.XtraForm
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        private readonly StoreRepository _storerepository = new StoreRepository();
        private readonly ReceiveDocRepository receiveDocRepository = new ReceiveDocRepository();
        List<ItemViewModel> _dataSource = new List<ItemViewModel>();
        public StockOutIndicesBuilder()
        {
            InitializeComponent();
            this.TopLevel = false;
            LoadAllItems();
        }

        void LoadAllItems()
        {
            btnBuildIndexer.Enabled = false;
            var allstockouts = _repository.GetAll().LastOrDefault();
            if (allstockouts != null) 
                lbllastindexedtime.Text = allstockouts.LastIndexedTime.ToString();
            var allItems = receiveDocRepository.RecievedItems().Select(m => m.Item).Distinct().ToList();
            itemsBindingSource.DataSource = ItemViewModelCollection.Create(allItems);
            var allstores = _storerepository.AllStores();
            storebindingSource.DataSource = allstores;
        }

        private void backgroundIndexer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _repository.DeleteAll();
            _dataSource = itemsBindingSource.DataSource as List<ItemViewModel>;
            double percentage = 0;
            if (_dataSource != null)
            {
                if (lkStore.EditValue != null)
                {
                    foreach (var item in _dataSource)
                    {
                        StockoutIndexBuilder.Builder.BuildIndex(item.ItemId, (int) lkStore.EditValue);
                        item.Indexed = true;
                        itemsBindingSource.DataSource = _dataSource;
                        var newValue = 100.0/_dataSource.Count;
                        percentage += newValue;
                        backgroundIndexer.ReportProgress(Convert.ToInt32(percentage));
                    }
                }
            }
        }


        private void btnBuildIndexer_Click(object sender, System.EventArgs e)
        {
            IndexAllItems();
        }

        private void IndexAllItems()
        {
            backgroundIndexer.RunWorkerAsync();
        }

        private void backgroundIndexer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressIndex.Value = e.ProgressPercentage;
        }

        private void backgroundIndexer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            itemsBindingSource.DataSource = null;
            itemsBindingSource.DataSource = _dataSource;
            XtraMessageBox.Show(String.Format("Indexing Completed for all items."));
            progressIndex.Value = 0;
        }

        private void lkStore_EditValueChanged(object sender, EventArgs e)
        {
            btnBuildIndexer.Enabled = true;
        }

    }
}