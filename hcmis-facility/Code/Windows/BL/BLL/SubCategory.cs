
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DAL;
using System.Data;

namespace BLL
{
	public class SubCategory : _SubCategory
	{
		public SubCategory()
		{
		
		}

        public DataTable GetSubCategory(int categoryId)
        {
            this.FlushData();
            this.Where.WhereClauseReset();
            this.Where.CategoryId.Value = categoryId;
            //this.Where.ParentID.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.And;
            //this.Where.ParentID.Value = 0;
            this.Query.Load();
            return this.DataTable;
        }

        public DataTable GetSubCategoryByID(int categoryId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("SELECT * FROM vwGetCategory WHERE ID = {0}",categoryId));
            return this.DataTable;
        }

        public DataTable GetSubCategoryOfItem(int itemId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("SELECT * FROM vwGetItemsByCategory WHERE ID = {0}", itemId));
            return this.DataTable;
        }
	}
}