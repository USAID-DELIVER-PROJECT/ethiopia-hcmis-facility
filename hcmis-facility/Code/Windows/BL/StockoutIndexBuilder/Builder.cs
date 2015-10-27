using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StockoutIndexBuilder.Models;
using StockoutIndexBuilder.DAL;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace StockoutIndexBuilder
{
    public class Builder
    {
        public static void BuildIndex(int itemID)
        {
            var db = new StockoutEntities();
            var repository = new StockoutRepository();

            foreach (var storeId in db.Stores.Select(s => s.ID))
            {
                var stockouts = GetStockOutHistory(itemID, storeId);
                if (stockouts.Count > 0)
                    repository.AddRange(stockouts);

             }


        }

        public static void BuildIndex(int itemID, int storeId)
        {
            var repository = new StockoutRepository();
            var stockouts = GetStockOutHistory(itemID, storeId).ToList();
            if (stockouts.Count > 0)
              repository.AddRange(stockouts);
                   
                
        }

        public static List<Stockout> GetStockOutHistory(int itemID,int storeID)
        {
            var allTransactions = TransactionDates(itemID,storeID).OrderBy(m => m.Date).ToArray();
            var receipts = ReceiptsByItem(itemID,storeID).OrderBy(m => m.Date);
            var issues = IssuesByItem(itemID,storeID).OrderBy(m => m.Date);
            var disposals = DisposalsByItem(itemID,storeID).OrderBy(m => m.Date);
            var adjustments = AdjustmentsByItem(itemID, storeID).OrderBy(m => m.Date);

            var receiptsInnerJoin = (from transactionDate in allTransactions
                                     join receipt in receipts
                                     on new { transactionDate.TransactionID, transactionDate.Date, transactionDate.TransactionType } equals new { receipt.TransactionID, receipt.Date, receipt.TransactionType }
                                     into temp
                                     from receipt in temp.DefaultIfEmpty()
                                     select new Transaction
                                     {
                                         TransactionType = transactionDate.TransactionType,
                                         Date = transactionDate.Date,
                                         Quantity = receipt == null ? null : receipt.Quantity
                                     }).ToArray();

            var issuesInnerJoin = (from transactionDate in allTransactions
                                   join issue in issues
                                   on new { transactionDate.TransactionID, transactionDate.Date, transactionDate.TransactionType } equals new { issue.TransactionID, issue.Date, issue.TransactionType }
                                   into temp
                                   from issue in temp.DefaultIfEmpty()
                                   select new Transaction
                                   {
                                       TransactionType = transactionDate.TransactionType,
                                       Date = transactionDate.Date,
                                       Quantity = issue == null ? null : issue.Quantity
                                   }).ToArray();

            var disposalsInnerJoin = (from transactionDate in allTransactions
                                      join disposal in disposals
                                      on new { transactionDate.TransactionID, transactionDate.Date, transactionDate.TransactionType } equals new { disposal.TransactionID, disposal.Date, disposal.TransactionType }
                                      into temp
                                      from disposal in temp.DefaultIfEmpty()
                                      select new Transaction
                                      {
                                          TransactionType = transactionDate.TransactionType,
                                          Date = transactionDate.Date,
                                          Quantity = disposal == null ? null : disposal.Quantity
                                      }).ToArray();
            var adjustmentsInnerJoin = (from transactionDate in allTransactions
                                      join adjustment in adjustments
                                      on new { transactionDate.TransactionID, transactionDate.Date, transactionDate.TransactionType } equals new { adjustment.TransactionID, adjustment.Date, adjustment.TransactionType }
                                      into temp
                                      from adjustment in temp.DefaultIfEmpty()
                                      select new Transaction
                                      {
                                          TransactionType = transactionDate.TransactionType,
                                          Date = transactionDate.Date,
                                          Quantity = adjustment == null ? null : adjustment.Quantity
                                      }).ToArray();
            var stockOuts = new List<Stockout>();
            long? balance = 0;
            var stockOut = new Stockout() { ItemID = itemID, StoreID = storeID};
            var lastTransaction = allTransactions.LastOrDefault();
            for (int i = 0; i < allTransactions.Length; i++)
            {                
                switch (allTransactions[i].TransactionType)
                {   
                    case TransactionType.Receipt:
                        if (allTransactions[i].TransactionType != receiptsInnerJoin[i].TransactionType)
                            throw new Exception("Algorithm Error.");
                        if (balance == 0 && stockOut.StartDate != DateTime.Parse("1/1/0001"))
                        {
                            stockOut.EndDate = allTransactions[i].Date.Value;
                            stockOuts.Add(stockOut);
                            stockOut = new Stockout() { ItemID = itemID , StoreID = storeID};
                        }
                        balance += receiptsInnerJoin[i].Quantity;
                        break;
                    case TransactionType.Issue:
                        if (allTransactions[i].TransactionType != issuesInnerJoin[i].TransactionType)
                            throw new Exception("Algorithm Error!");
                        balance -= issuesInnerJoin[i].Quantity;
                        if (balance <= 0 && stockOut.StartDate != DateTime.Parse("1/1/0001"))
                        {
                            stockOut.StartDate = allTransactions[i].Date.Value;
                            balance = 0;
                        }
                            
                        break;
                    case TransactionType.Disposal:
                        if (allTransactions[i].TransactionType != disposalsInnerJoin[i].TransactionType)
                            throw new Exception("Algorithm Error!");
                        balance -= disposalsInnerJoin[i].Quantity;
                        if (balance <= 0)
                        {
                            stockOut.StartDate = allTransactions[i].Date.Value;
                            balance = 0;
                        }
                        break;
                    case TransactionType.Adjustment:
                        if (allTransactions[i].TransactionType != adjustmentsInnerJoin[i].TransactionType)
                            throw new Exception("Algorithm Error!");
                        if (balance == 0 && stockOut.StartDate != DateTime.Parse("1/1/0001"))
                        {
                            stockOut.EndDate = allTransactions[i].Date.Value;
                            stockOuts.Add(stockOut);
                            stockOut = new Stockout() { ItemID = itemID , StoreID = storeID};
                        }
                        balance += adjustmentsInnerJoin[i].Quantity;
                        break;
                    default:
                        break;
                }
            }
            if (stockOut.StartDate != DateTime.Parse("1/1/0001") && !stockOut.EndDate.HasValue)
            {
                stockOut.EndDate = DateTime.Today;
                stockOuts.Add(stockOut);
            }
            return stockOuts;
        }
        public static int GetStockOutDaysForRRF(int itemId, int storeId,DateTime endDate)
        {
            var startDate = endDate.Subtract(TimeSpan.FromDays(60));
            return Builder.CalculateStockoutDays(itemId, storeId, startDate, endDate);
        }
        #region Private static helper methods
        static List<Transaction> TransactionDates(int itemID,int storeID)
        {
            var db = new StockoutEntities();
            List<Transaction> dates = new List<Transaction>();

            dates.AddRange((from receipt in db.ReceiveDocs.Where(m => m.ItemID == itemID && m.StoreID==storeID).OrderBy(m => m.Date) select new Transaction { TransactionID = receipt.ID, Date = receipt.Date, TransactionTypeCode = (int)TransactionType.Receipt }).ToList()); // Receipts
            dates.AddRange((from issue in db.IssueDocs.Where(m => m.ItemID == itemID && m.StoreID ==storeID).OrderBy(m => m.Date) select new Transaction { TransactionID = issue.ID, Date = issue.Date, TransactionTypeCode = (int)TransactionType.Issue }).ToList()); // Issues
            dates.AddRange((from disposal in db.Disposals.Where(m => m.ItemID == itemID && m.StoreID ==storeID && (bool) m.IsLoss).OrderBy(m => m.Date) select new Transaction { TransactionID = disposal.ID, Date = disposal.Date, TransactionTypeCode = (int)TransactionType.Disposal }).ToList()); // Disposals
            dates.AddRange((from disposal in db.Disposals.Where(m => m.ItemID == itemID && m.StoreID == storeID && !(bool)m.IsLoss).OrderBy(m => m.Date) select new Transaction { TransactionID = disposal.ID, Date = disposal.Date, TransactionTypeCode = (int)TransactionType.Adjustment }).ToList()); // Adjustments
            return dates.OrderBy(m => m.Date).ToList();
        }

        static List<Transaction> IssuesByItem(int itemID, int storeID)
        {
            var db = new StockoutEntities();
            var issues = from issue in db.IssueDocs
                         where issue.ItemID == itemID && issue.StoreID == storeID
                         select new Transaction { TransactionID = issue.ID, TransactionTypeCode = (int)TransactionType.Issue, Date = issue.Date, Quantity = issue.Quantity };
            return issues.OrderBy(m => m.Date).ToList();
        }

        static List<Transaction> ReceiptsByItem(int itemID ,int storeID)
        {
            var db = new StockoutEntities();
            var receipts = from receipt in db.ReceiveDocs
                           where receipt.ItemID == itemID && receipt.StoreID == storeID
                           select new Transaction { TransactionID = receipt.ID, TransactionTypeCode = (int)TransactionType.Receipt, Date = receipt.Date, Quantity = receipt.Quantity };
            return receipts.ToList();
        }

        static List<Transaction> DisposalsByItem(int itemID ,int storeID)
        {
            var db = new StockoutEntities();
            var receipts = from disposal in db.Disposals
                           where disposal.ItemID == itemID && disposal.StoreID ==storeID && (bool)disposal.IsLoss
                           select new Transaction { TransactionID = disposal.ID, TransactionTypeCode = (int)TransactionType.Disposal, Date = disposal.Date, Quantity = disposal.Quantity };
            return receipts.ToList();
        }

        static List<Transaction> AdjustmentsByItem(int itemID, int storeID)
        {
            var db = new StockoutEntities();
            var receipts = from disposal in db.Disposals
                           where disposal.ItemID == itemID && disposal.StoreID == storeID && !(bool)disposal.IsLoss
                           select new Transaction { TransactionID = disposal.ID, TransactionTypeCode = (int)TransactionType.Adjustment, Date = disposal.Date, Quantity = disposal.Quantity };
            return receipts.ToList();
        }
        #endregion

        #region Calculate AMC;
        public static int CalculateStockoutDays(int itemId,int storeId, DateTime startDate, DateTime endDate)
        {
            var repository = new StockoutRepository();            
            var stockoutsInRange = repository.GetAll().Where(m => m.ItemID == itemId && m.StoreID ==storeId ).Where(m => m.StartDate < endDate && (m.EndDate == null || m.EndDate > startDate)).ToList();
            //var stockoutsOutOfRange = repository.GetAll().Where(m => m.ItemID == itemId && m.StoreID == storeId).Where(m => m.StartDate > startDate).ToList();

                foreach (var stockout in stockoutsInRange)
                {
                    if (stockout.StartDate < startDate)
                        stockout.StartDate = startDate;
                    if (stockout.EndDate == null)
                        stockout.EndDate = DateTime.Now;
                    else if (stockout.EndDate > endDate)
                        stockout.EndDate = endDate;
                }
                return Enumerable.Sum(stockoutsInRange, m => m.NumberOfDays);
        }


       public static double CachedAMC(int itemID, int storeID)
       {
           StockoutEntities context= new StockoutEntities();
           var amc = ((from v in context.AmcReports
                      where v.ItemID == itemID && v.StoreID == storeID
                      select v).FirstOrDefault() ?? new AmcReport()).AmcWithDOS;
           return amc;
       }

       public static double CalculateAverageConsumptionForMOS(int itemId, int storeId, DateTime startDate, DateTime endDate, CalculationOptions option)
       {
           var numberOfDays = endDate.Subtract(startDate).TotalDays;
           var totalCosumption =CalculateTotalConsumptionForMOS(itemId, storeId, startDate, endDate) * 1.0;
           switch (option)
           {
               case CalculationOptions.Daily:
                   return totalCosumption / numberOfDays;
                   break;
               case CalculationOptions.Weekly:
                   return totalCosumption / (numberOfDays / 7);
                   break;
               case CalculationOptions.Monthly:
                   return totalCosumption / (numberOfDays / 30);
                   break;
               case CalculationOptions.Quarterly:
                   return totalCosumption / (numberOfDays / 123);
                   break;
               case CalculationOptions.Annual:
                   return totalCosumption / (numberOfDays / 365);
                   break;
               default:
                   break;
           }
           return 0;
       }
       public static double CalculateAverageConsumption(int itemId,int storeId, DateTime startDate, DateTime endDate, CalculationOptions option)
        {
            var numberOfDays = endDate.Subtract(startDate).TotalDays;
            var totalCosumption = CalculateTotalConsumption(itemId,storeId, startDate, endDate) * 1.0;
            switch (option)
            {
                case CalculationOptions.Daily:
                    return totalCosumption / numberOfDays;
                    break;
                case CalculationOptions.Weekly:
                    return totalCosumption / (numberOfDays / 7);
                    break;
                case CalculationOptions.Monthly:
                    return totalCosumption / (numberOfDays / 30);
                    break;
                case CalculationOptions.Quarterly:
                    return totalCosumption / (numberOfDays / 123);
                    break;
                case CalculationOptions.Annual:
                    return totalCosumption / (numberOfDays / 365);
                    break;
                default:
                    break;
            }
            return 0;
        }


       public static double CalculateAverageConsumptionAMC(int itemId, int storeId, DateTime startDate, DateTime endDate, CalculationOptions option)
       {
           var numberOfDays = endDate.Subtract(startDate).TotalDays;
           var totalCosumption = CalculateTotalConsumptionAMC(itemId, storeId, startDate, endDate) * 1.0;
           switch (option)
           {
               case CalculationOptions.Daily:
                   return totalCosumption / numberOfDays;
                   break;
               case CalculationOptions.Weekly:
                   return totalCosumption / (numberOfDays / 7);
                   break;
               case CalculationOptions.Monthly:
                   return totalCosumption / (numberOfDays / 30);
                   break;
               case CalculationOptions.Quarterly:
                   return totalCosumption / (numberOfDays / 123);
                   break;
               case CalculationOptions.Annual:
                   return totalCosumption / (numberOfDays / 365);
                   break;
               default:
                   break;
           }
           return 0;
       }
       public static long CalculateTotalConsumptionForMOS(int itemId, int storeId, DateTime startDate, DateTime endDate)
       {
           var db = new StockoutEntities();
           var stockoutDays = CalculateStockoutDays(itemId, storeId, startDate, endDate);
           var allIssues = db.IssueDocs.Where(m => m.ItemID == itemId && m.StoreID == storeId || m.Date >= startDate && m.Date < endDate);//.Where(m => m.Date >= startDate && m.Date < endDate);
           //var allIssues = db.IssueDocs.Where(m => m.ItemID == itemId && m.StoreID == storeId && m.Date >= startDate && m.Date < endDate);//.Where(m => m.Date >= startDate && m.Date < endDate);
           if (!allIssues.Any())
               return 0;
           var totalConsumption = Enumerable.Sum(allIssues, issue => issue.Quantity);
           if (stockoutDays == 0)
               return totalConsumption;
           return totalConsumption + CalculateTotalConsumption(itemId, storeId, startDate.Subtract(TimeSpan.FromDays(stockoutDays)), startDate); ;
       }

        public static long CalculateTotalConsumption(int itemId,int storeId, DateTime startDate, DateTime endDate)
        {
            var db = new StockoutEntities();
            var amcrange = db.GenralInfos.First();
            var amcdays = amcrange.AMCRange*30;
            var stockoutDays = CalculateStockoutDays(itemId, storeId, startDate, endDate);
            var allIssues =db.IssueDocs.Where(m => m.ItemID == itemId && m.StoreID == storeId).Where(issue => issue.Date >= startDate && issue.Date < endDate);
            if (!allIssues.Any())
                return 0;
            var totalConsumption = Enumerable.Sum(allIssues, issue => issue.Quantity);
            if (stockoutDays == 0)
                return totalConsumption;
            return (totalConsumption + CalculateTotalConsumption(itemId, storeId, startDate.Subtract(TimeSpan.FromDays(stockoutDays)),startDate));
        }

        public static long CalculateTotalConsumptionAMC(int itemId, int storeId, DateTime startDate, DateTime endDate, int amcrange = 0, int stockoutDays = 0)
        {
            var db = new StockoutEntities();
            if (amcrange == 0)
            {
                amcrange = db.GenralInfos.First().AMCRange;
            }

            var amcdays = amcrange * 30;

            if (stockoutDays == 0)
            {
                stockoutDays = CalculateStockoutDays(itemId, storeId, startDate, endDate);
            }

            var allIssues = db.IssueDocs.Where(m => m.ItemID == itemId && m.StoreID == storeId).Where(issue => issue.Date >= startDate && issue.Date < endDate);
            if (!allIssues.Any())
                return 0;
            var totalConsumption = Enumerable.Sum(allIssues, issue => issue.Quantity) * amcdays;
            var daydiff = amcdays - stockoutDays;
            if (daydiff != 0)
            {
                return totalConsumption / daydiff;
            }
            return 0;
            //return 1;
        }

        public static long CalculateTotalConsumptionWithoutDOS(int itemId,int storeId, DateTime startDate, DateTime endDate)
        {
            var db = new StockoutEntities();
            var allIssues = db.IssueDocs.Where(m => m.ItemID == itemId && m.StoreID == storeId).Where(issue => issue.Date >= startDate && issue.Date < endDate);
            return Enumerable.Sum(allIssues, issue => issue.Quantity);
        }

        #endregion


        public static void RefreshAMCValues(int storeId, Dictionary<int,long> items,int unitId)
        {
            var context = new StockoutEntities();
            var genaralinfo = context.GenralInfos.First();
            var endDate = DateTime.Now;
            var startDate = endDate.Subtract(TimeSpan.FromDays(genaralinfo.AMCRange * 30));
            
            try
            {
              foreach (var row in items)
              {
                  if (row.Value == 0)
                  {
                      var stockOut = new Stockout()
                      {
                          ItemID = row.Key,
                          StoreID = storeId,
                          StartDate = DateTime.Now,
                          EndDate = null,
                          LastIndexedTime = DateTime.Now
                      };
                      context.Stockouts.Add(stockOut);
                      context.SaveChanges();
                  }
                  
                  var allItemIds = context.AmcReports.SingleOrDefault(m => m.ItemID == row.Key && m.StoreID == storeId && m.UnitID ==unitId);
                  if(allItemIds==null)
                  {
                     
                          var amcreport = new AmcReport
                                              {
                                                  ItemID = row.Key,
                                                  StoreID = storeId,
                                                  AmcRange = genaralinfo.AMCRange,
                                                  IssueInAmcRange =
                                                      CalculateTotalConsumptionWithoutDOS(row.Key, storeId, startDate,
                                                                                          DateTime.Today),
                                                  DaysOutOfStock =
                                                      CalculateStockoutDays(row.Key, storeId, startDate, endDate),
                                                  AmcWithDOS =
                                                      CalculateAverageConsumption(row.Key, storeId, startDate,endDate,CalculationOptions.Monthly),
                                                  AmcWithOutDOS = CalculateTotalConsumptionWithoutDOS(row.Key, storeId, startDate, endDate) / Convert.ToDouble(genaralinfo.AMCRange),
                                                  LastIndexedTime = DateTime.Now,
                                                  IssueWithDOS =Builder.CalculateTotalConsumption(row.Key, storeId, startDate, DateTime.Now),
                                                  UnitID = unitId
                                              };
                          context.AmcReports.Add(amcreport);
      }
                  // Update AMC value
                  else
                  {
                      allItemIds.IssueInAmcRange = CalculateTotalConsumptionWithoutDOS(row.Key, storeId, startDate,
                                                                             DateTime.Now);
                      allItemIds.DaysOutOfStock = CalculateStockoutDays(row.Key, storeId, startDate, DateTime.Now);
                      allItemIds.AmcWithDOS = CalculateAverageConsumption(row.Key, storeId, startDate, endDate,CalculationOptions.Monthly);
                      allItemIds.AmcWithOutDOS =CalculateTotalConsumptionWithoutDOS(row.Key, storeId, startDate, endDate)/Convert.ToDouble(genaralinfo.AMCRange);
                      allItemIds.IssueWithDOS = Builder.CalculateTotalConsumption(row.Key, storeId, startDate, DateTime.Now);
                      allItemIds.LastIndexedTime = DateTime.Now;
                      allItemIds.UnitID = unitId;
                  }

                  context.SaveChanges();

              }
                    
                
            }
            catch (DbUpdateException ex)
            {

                throw;
            }
        }

       

        private static object GetSOHAsOfDate(int itemId, int storeId, DateTime dateTime)
        {
            return new object(); 
        }
    }

    public enum CalculationOptions
    {
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Annual
    }
}
