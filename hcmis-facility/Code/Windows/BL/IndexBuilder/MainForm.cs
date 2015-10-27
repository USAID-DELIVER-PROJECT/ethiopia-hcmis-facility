using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockoutIndexBuilder.DAL;
using IndexBuilder.ViewModels;

namespace IndexBuilder.cs
{
    public partial class BuildIndicesView : Form
    {
        private readonly StockoutRepository _repository = new StockoutRepository();
        List<ItemViewModel> _dataSource = new List<ItemViewModel>();
        public BuildIndicesView()
        {
            InitializeComponent();
            LoadAllItems();
        }

        void LoadAllItems()
        {
            var allItems = _repository.AllItems().Where(m => m.ID < 500);
            itemsBindingSource.DataSource = ItemViewModelCollection.Create(allItems);
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            IndexAllItems();
        }

        private void IndexAllItems()
        {
            backgroundIndexer.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundIndexer_DoWork(object sender, DoWorkEventArgs e)
        {
            _repository.DeleteAll();
            _dataSource = itemsBindingSource.DataSource as List<ItemViewModel>;
            double percentage = 0;
            foreach (var item in _dataSource)
            {                
                StockoutIndexBuilder.Builder.BuildIndex(((ItemViewModel)item).ItemID);
                item.Indexed = true;
                itemsBindingSource.DataSource = _dataSource;
                var newValue = 100.0 / _dataSource.Count;
                percentage += newValue;
                backgroundIndexer.ReportProgress(Convert.ToInt32(percentage));
            }
            //lblStatus.Text = String.Format("Completed index for {0} items successfully.", _dataSource.Count);            
           
        }

        private void backgroundIndexer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressIndex.Value = e.ProgressPercentage;
        }

        private void backgroundIndexer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            itemsBindingSource.DataSource = null;
            itemsBindingSource.DataSource = _dataSource;
            MessageBox.Show(String.Format("Indexing Completed for {0} items.", _dataSource.Count));
            progressIndex.Value = 0;
        }        
    }
}
