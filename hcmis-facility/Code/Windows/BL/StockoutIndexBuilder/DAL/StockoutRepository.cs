using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
    public class StockoutRepository
    {
        StockoutEntities Context = new StockoutEntities();

        public void Add(Stockout stockout)
        {
            Context.Stockouts.Add(stockout);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<Stockout> stockouts)
        {
            foreach (var stockout in stockouts)
            {
               stockout.LastIndexedTime = DateTime.Now;
               Context.Stockouts.Add(stockout);
            }
            Context.SaveChanges();
        }
        public void convertdate (IEnumerable<Stockout> stockouts)
        {
            foreach (var stockout in stockouts)
            {
                Context.Stockouts.Add(stockout);
            }
            Context.SaveChanges();
        }
        void Remove(Stockout stockout)
        {
            Context.Stockouts.Remove(stockout);
        }

        public IEnumerable<Stockout> GetStockoutsByItem(int itemId)
        {
            return Context.Stockouts.Where(m => m.ItemID == itemId).AsEnumerable();
        }

        public IEnumerable<Stockout> GetStockoutsByItemandStore(int itemId,int storeID)
        {
            return Context.Stockouts.Where(m => m.ItemID == itemId && m.StoreID ==storeID).AsEnumerable();
            
        }

        public void Delete(Stockout stockout)
        {
            this.Remove(stockout);
            Context.SaveChanges();
        }


        public IEnumerable<Stockout> GetAll()
        {
            return Context.Stockouts.AsEnumerable();
        }

        public void DeleteAll()
        {
            foreach (var item in Context.Stockouts)
            {
                this.Remove(item);
            }
            Context.SaveChanges();
        }
        public void Update(Stockout stockout)
        {
            Context.Entry(stockout).State = EntityState.Modified;
             Context.SaveChanges();
        }


        public List<Item> AllItems()
        {
            return Context.Items.ToList();
        }

       
    }
}
