using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
  public class AmcReportRepository
    {
      private readonly StockoutEntities context =new StockoutEntities();
      public void Add(AmcReport amcReport)
      {
          context.AmcReports.Add(amcReport);
          context.SaveChanges();
      }
      public void DeleteAll()
      {
          foreach (var item in context.AmcReports)
          {
              this.Remove(item);
          }
          context.SaveChanges();
      }
      void Remove(AmcReport amcreport)
      {
          context.AmcReports.Remove(amcreport);
      }
      public List<AmcReport> AllAmcReport()
      {
          var reports = context.AmcReports.OrderByDescending(m => m.LastIndexedTime).ToList();
          foreach (var amcReport in reports)
          {
              var name = context.VwGetAllItemses.SingleOrDefault(m => m.ID == amcReport.ItemID);
              if (name != null) amcReport.FullItemName = name.FullItemName;
          }
          return reports;

      }
      public void Update(AmcReport amcReport)
      {
           context.Entry(amcReport).State = EntityState.Modified;
           context.SaveChanges();
      }
    }
}
