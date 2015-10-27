using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
    [Table("DosageForm")]
   public class DosageForm
    {
        [Key]
        public int ID { get; set; }
        public string  Form { get; set; }
        public string Description { get; set; }
        public int? TypeID { get; set; }
        public int? DSID { get; set; }

    }
}
