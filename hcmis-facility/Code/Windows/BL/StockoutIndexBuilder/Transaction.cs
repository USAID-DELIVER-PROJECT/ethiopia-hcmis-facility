using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder
{
    enum TransactionType
    {
        Receipt = 0,
        Issue = 1,
        Disposal = 2,
        Adjustment = 3
    }

    class Transaction
    {
        public int TransactionID { get; set; }
        public TransactionType TransactionType { get; set; }
        public long? Quantity { get; set; }
        public DateTime? Date { get; set; }
        internal int TransactionTypeCode
        {
            set { this.TransactionType = (TransactionType)value; }
        }
    }
}
