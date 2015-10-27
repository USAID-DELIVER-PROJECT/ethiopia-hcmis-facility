using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
    public class vwGetAllItemsRepository
    {
        StockoutEntities _context = new StockoutEntities();

        public List<vwGetAllItems> AllItems()
        {
            return _context.VwGetAllItemses.ToList();
        }

        public IQueryable<vwGetAllItems> FindBy(int itemID)
        {
            return _context.VwGetAllItemses.Where(m=>m.ID ==itemID);
        }
    }
}
