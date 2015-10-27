using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Transfer : _Transfer
    {
        public Transfer()
        {

        }

        public DataTable GetTransfered( int recid,int itemId, int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("select * from Transfer where ItemID ={0} And FromStoreID={1} and RecID={2}", itemId,
                                              storeId,recid));
            return this.DataTable;

        }

        public DataTable GetTransactionByDateRange(int storeId, DateTime dt1, DateTime dt2)
        {
            this.FlushData();
            string query = String.Format("SELECT *, ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo ," +
                                         " (rd.Cost * QtyPerPack) as PackPrice, datediff(day, EurDate, ExpDate) as DBER " +
                                         "FROM Transfer rd join vwGetAllItems vw on rd.ItemID = vw.ID join ItemUnit iu on rd.UnitID =iu.ID WHERE ToStoreID = {0} " +
                                         "AND (Date BETWEEN '{1}' AND '{2}' )" +
                                         " ORDER BY Date DESC", storeId, dt1.ToShortDateString(),
                                         dt2.ToShortDateString());
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        public DataTable GetTransactionByRefNo(string refNo, int storeId, string dt)
        {
            this.FlushData();
            string query =
                String.Format(
                    "SELECT *,ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo  FROM Transfer rd join vwGetAllItems vw on rd.ItemID = vw.ID  WHERE (RefNo = '{0}' AND Date = '{2}') AND ToStoreID = {1} ORDER BY Date DESC",
                    refNo, storeId, dt);
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

        public DataTable GetDistinctRecDocments(int storeId)
        {
            this.FlushData();
            string query =
                String.Format(
                    "SELECT DISTINCT RefNo as RefNo, Date, ToStoreID,  cast (Year(Date) as varchar) as ParentID, rtrim(RefNo) + cast(Date as varchar) as ID FROM Transfer WHERE ToStoreID = {0} ORDER BY Date DESC",
                    storeId);
            this.LoadFromRawSql(query);
            DataTable dtbl = this.DataTable;
            this.LoadFromRawSql("select distinct Year(Date) as Year from Transfer order by year(Date) DESC");
            while (!this.EOF)
                //The following is added for the benefit of tree control and having parents there.
            {
                DataRowView drv = dtbl.DefaultView.AddNew();
                drv["RefNo"] = drv["ID"] = (this.DataRow["Year"].ToString());
                this.MoveNext();
            }
            return dtbl;
        }

        public DataTable GetAllTransaction(int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("SELECT *, ROW_NUMBER() OVER (ORDER BY Date DESC) as RowNo , (rd.Cost * QtyPerPack) as PackPrice, datediff(day, EurDate, ExpDate) as DBER FROM Transfer rd join vwGetAllItems vw on rd.ItemID = vw.ID WHERE ToStoreID = {0} ORDER BY Date DESC", storeId));
            return this.DataTable;
        }

    
}
}
