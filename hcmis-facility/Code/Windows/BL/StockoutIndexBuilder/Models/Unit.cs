using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
   [Table("Unit")]
   public class Unit
    {
       [Key]
       public int ID { get; set; }
       [Column("Unit")]
       public string UnitName { get; set; }
     
    }
}
