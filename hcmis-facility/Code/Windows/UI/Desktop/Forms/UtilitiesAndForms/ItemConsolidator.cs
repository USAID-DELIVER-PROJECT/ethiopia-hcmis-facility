using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StockoutIndexBuilder.DAL;
using StockoutIndexBuilder.Models;

namespace PharmInventory.Forms.UtilitiesAndForms
{
    public partial class ItemConsolidator : DevExpress.XtraEditors.XtraForm
    {
        ItemsRepository _itemsRepository =new ItemsRepository();
        public ItemConsolidator()
        {
            InitializeComponent();
        }

        private void ItemConsolidator_Load(object sender, EventArgs e)
        {
            var allitems = _itemsRepository.AllItemsList();
            itemsBindingSource.DataSource = allitems;
            
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var selecteditems = gridView1.GetFocusedRow();
            _itemsRepository.Update((Item) selecteditems);

        }
    }
}