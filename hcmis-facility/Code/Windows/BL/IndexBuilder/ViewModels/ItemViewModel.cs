using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace IndexBuilder.ViewModels
{
    public class ItemViewModel
    {
        private bool _indexed = false;
        public ItemViewModel()
        {

        }

        public ItemViewModel(Item item)
        {
            ItemID = item.ID;
            StockCode = item.StockCode;
            DosageFormID = item.DosageFormID;
            Strength = item.Strength;

        }
        public int ItemID { get; set; }        
        public string StockCode { get; set; }
        public int DosageFormID { get; set; }
        public string Strength { get; set; }
        public bool Indexed 
        {
            get { return _indexed; }
            set { _indexed = value; }
        }
    }
}
