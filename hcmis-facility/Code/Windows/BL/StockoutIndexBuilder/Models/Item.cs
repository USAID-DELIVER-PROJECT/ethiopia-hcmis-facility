using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StockoutIndexBuilder.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public string StockCode { get; set; }
        public string Strength  { get; set; }
        public int? DosageFormId { get; set; }
        [ForeignKey("Product")]
        public int? IINID { get; set; }
        public int? DSItemID { get; set; }

        [NotMapped]
        public string FullItemName { get; set; }

        public virtual ICollection<Stockout> Stockouts { get; set; }
        public virtual Product  Product { get; set; }
       
        
    }
}
