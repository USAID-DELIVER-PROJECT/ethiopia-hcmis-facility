using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class ItemsRepository
    {
       readonly StockoutEntities context = new StockoutEntities();

        public List<Item> AllItems()
        {
            return context.Items.ToList();
        }

        public List<Item> AllItemsList()
        {
            var items = context.Items.ToList();
            foreach (var item in items)
            {
                var name = context.VwGetAllItemses.SingleOrDefault(m => m.ID == item.ID);
                if (name != null) item.FullItemName= name.FullItemName;
            }
            return items;

        }

        public void Update(Item item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
