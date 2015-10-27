using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmInventory.HelperClasses
{
  public class FeSetting
    {
        public int RecordId { get; set; }
        public string Name { get; set; }

        public List<FeSetting> GetFeLookup()
        {
            return new List<FeSetting> 
            { 
                new FeSetting { RecordId = 1, Name = "Default" }, 
                new FeSetting { RecordId = 2, Name = "Vaccine Handle Unit" }, 
                new FeSetting { RecordId = 3, Name = "Other Handle Unit" } 
            };
        }
    }
}
