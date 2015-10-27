using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
  [Table("vwGetAllItems")]
    public class vwGetAllItems
    {
        public int ID { get; set; }
        public string FullItemName { get; set; }
    }
}
