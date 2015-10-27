using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class ProductRepository
    {
      StockoutEntities context =new StockoutEntities();

       public List<Product> GetAll()
       {
           return context.Products.ToList();
       }

       public void Update(Product product)
       {
           context.Entry(product).State = EntityState.Modified;
           context.SaveChanges();
       }
    }
}
