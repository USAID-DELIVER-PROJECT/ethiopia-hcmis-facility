using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class ItemUnit :_ItemUnit
    {
       public ItemUnit()
       {
           
       }

       public DataTable GetAllUnits()
       {
           var units = new ItemUnit();
           units.LoadFromRawSql("select * from ItemUnit");
           return units.DataTable;
       }

       public DataTable LoadFromSQl(int itemid)
       {
           var units = new ItemUnit();
           units.LoadFromRawSql(string.Format("select * from ItemUnit where ItemID={0}", itemid));
           return units.DataTable;
       }


    }
}
