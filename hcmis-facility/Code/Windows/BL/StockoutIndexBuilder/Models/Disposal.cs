using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StockoutIndexBuilder.Models
{
    [Table("Disposal")]
    public class Disposal
    {
        [Key]        
        public int ID { get; set; }
        public int ItemID { get; set; }
        public long? Quantity { get; set; }
        [Column("EurDate")]
        public DateTime? Date { get; set; }
        public int StoreID { get; set; }
        [Column("Losses")]
        public bool? IsLoss { get; set; }
        public int? UnitID { get; set; }
    }
}
