using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmInventory.ViewModels
{
    public class FacilityOrderViewModel
    {
        public int FacilityID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RRFTransactionService.Order[] Orders { get; set; }
    }
}
