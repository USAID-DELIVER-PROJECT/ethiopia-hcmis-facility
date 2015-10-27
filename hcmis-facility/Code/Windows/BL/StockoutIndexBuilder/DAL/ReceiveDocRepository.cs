using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
   public class ReceiveDocRepository
    {
       StockoutEntities Context = new StockoutEntities();
       public List<ReceiveDoc> RecievedItems()
       {
          return Context.ReceiveDocs.ToList();
       }

       public IEnumerable<ReceiveDoc> GetReceivedItemUnit(int receivedocid)
       {
           return Context.ReceiveDocs.Where(m => m.ID == receivedocid);
       }


    }
}
