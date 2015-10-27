using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmInventory.HelperClasses
{
    public class OrderStatus
    {
        public int RecordId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Returns list of possible sex values for binding using BindingSource controls.
        /// </summary>
        /// <returns>Enumerable lis to Sex (Male and Female values)</returns>
        public List<OrderStatus> GetRRFOrders()
        {
            return new List<OrderStatus> { new OrderStatus { RecordId = 1, Name = "Standard" }, new OrderStatus { RecordId = 2, Name = "Below EOP" } };
        }
    }
}
