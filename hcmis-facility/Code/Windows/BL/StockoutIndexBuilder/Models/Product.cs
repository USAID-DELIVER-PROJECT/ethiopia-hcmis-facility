using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
  [Table("Product")]
  public class Product
    {
      [Key]
      public int ID { get; set; }
      public string IIN { get; set; }
      public string ATC { get; set; }
      public string Description { get; set; }
      public int TypeID { get; set; }
     }
}
