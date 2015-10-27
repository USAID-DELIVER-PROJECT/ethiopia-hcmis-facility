using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class UnitsRepository
    {
       StockoutEntities context =new StockoutEntities();
       public List<Unit> GetAll()
       {
           return context.Unit.ToList();
       }

       public void Update(Unit unit)
       {
           context.Entry(unit).State = EntityState.Modified;
           context.SaveChanges();
       }
    } 
}
