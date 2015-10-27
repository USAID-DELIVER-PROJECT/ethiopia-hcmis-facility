using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class DosageFormRepository
    {
       StockoutEntities context =new StockoutEntities();
       public List<DosageForm> GetAll()
       {
           return context.DosageForms.ToList();
       }

       public void Update(DosageForm dosageForm)
       {
           context.Entry(dosageForm).State = EntityState.Modified;
           context.SaveChanges();
       }
    }
}
