using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class UnitRepository
    {
       StockoutEntities _context = new StockoutEntities();

       public IEnumerable<ItemUnit> GetAll()
       {
           return _context.Units.ToList();
       }

       public IEnumerable<ItemUnit> GetUnitsByItemId(int ItemID)
       {
           return _context.Units.Where(m=>m.ItemID==ItemID).ToList();
       }

      }
}
