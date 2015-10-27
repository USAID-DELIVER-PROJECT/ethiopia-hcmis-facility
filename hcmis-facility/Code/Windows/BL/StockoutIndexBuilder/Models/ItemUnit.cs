using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
   [Table("ItemUnit")]
   public class ItemUnit
    {
        [Key]
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int QtyPerUnit { get; set; }
        public string Text { get; set; }

       
    }
}
