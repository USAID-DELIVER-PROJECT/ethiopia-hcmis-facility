using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
    [Table("Stores")]
    public class Store
    {
        [Key]
        public int ID { get; set; }
        public string StoreName { get; set; }
        public bool IsActive { get; set; }
    }
}
