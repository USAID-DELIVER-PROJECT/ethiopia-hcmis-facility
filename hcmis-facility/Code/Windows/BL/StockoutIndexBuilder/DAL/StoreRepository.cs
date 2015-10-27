using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
    public class StoreRepository
    {
      StockoutEntities Context = new StockoutEntities();

      public List<Store> AllStores()
        {
            return Context.Stores.ToList();
        }
    }
}
