using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MyGeneration.dOOdads;

namespace DAL
{
    public abstract class _Stockout:SqlClientEntity
    {
		public _Stockout()
		{
			this.QuerySource = "Stockout";
			this.MappingName = "Stockout";

		}	

		//=================================================================
		//  public Overrides void AddNew()
		//=================================================================
		//
		//=================================================================
		public override void AddNew()
		{
			base.AddNew();
			
		}
		
		
		public override void FlushData()
		{
			this._whereClause = null;
			this._aggregateClause = null;
			base.FlushData();
		}

        //public bool LoadAll() 
        //{
        //    ListDictionary parameters = null;
			
        //    return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_StockoutLoadAll]", parameters);
        //}
	
		public virtual bool LoadByPrimaryKey(int ID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.ID, ID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_StockoutLoadByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter ID
			{
				get
				{
					return new SqlParameter("@ID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter StoreID
			{
				get
				{
					return new SqlParameter("@StoreID", SqlDbType.VarChar, 50);
				}
			}
			
			public static SqlParameter ItemID
			{
				get
				{
                    return new SqlParameter("@ItemID", SqlDbType.Text, 2147483647);
				}
			}
            public static SqlParameter StartDate
            {
                get
                {
                    return new SqlParameter("@StartDate", SqlDbType.Text, 2147483647);
                }
            }
            public static SqlParameter EndDate
            {
                get
                {
                    return new SqlParameter("@EndDate", SqlDbType.Text, 2147483647);
                }
            }

			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string ID = "ID";
            public const string StoreID = "StoreID";
            public const string ItemID = "ItemID";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _Stockout.PropertyNames.ID;
					ht[StoreID] = _Stockout.PropertyNames.StoreID;
					ht[ItemID] = _Stockout.PropertyNames.ItemID;
                    ht[StartDate] = _Stockout.PropertyNames.StartDate;
                    ht[EndDate] = _Stockout.PropertyNames.EndDate;
				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;

        }
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string ID = "ID";
            public const string StoreID = "StoreID";
            public const string ItemID = "ItemID";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _Stockout.ColumnNames.ID;
                    ht[StoreID] = _Stockout.ColumnNames.StoreID;
                    ht[ItemID] = _Stockout.ColumnNames.ItemID;
                    ht[StartDate] = _Stockout.ColumnNames.StartDate;
                    ht[EndDate] = _Stockout.ColumnNames.EndDate;
				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string ID = "s_ID";
            public const string Value = "s_Value";
            public const string Description = "s_Description";

		}
		#endregion		
		
		#region Properties
	
		public virtual int ID
	    {
			get
	        {
				return base.Getint(ColumnNames.ID);
			}
			set
	        {
				base.Setint(ColumnNames.ID, value);
			}
		}

		public virtual string StoreID
	    {
			get
	        {
                return base.Getstring(ColumnNames.StoreID);
			}
			set
	        {
                base.Setstring(ColumnNames.StoreID, value);
			}
		}

		public virtual string ItemID
	    {
			get
	        {
				return base.Getstring(ColumnNames.ItemID);
			}
			set
	        {
				base.Setstring(ColumnNames.ItemID, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_ID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ID) ? string.Empty : base.GetintAsString(ColumnNames.ID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ID);
				else
					this.ID = base.SetintAsString(ColumnNames.ID, value);
			}
		}

		public virtual string s_Value
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Value) ? string.Empty : base.GetstringAsString(ColumnNames.Value);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Value);
				else
					this.StoreID= base.SetstringAsString(ColumnNames.Value, value);
			}
		}

		public virtual string s_Description
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Description) ? string.Empty : base.GetstringAsString(ColumnNames.Description);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Description);
				else
					this.ItemID = base.SetstringAsString(ColumnNames.Description, value);
			}
		}


		#endregion		
	
		#region Where Clause
		public class WhereClause
		{
			public WhereClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffWhereParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffWhereParameter(this);
					}

					return _tearOff;
				}
			}

			#region WhereParameter TearOff's
			public class TearOffWhereParameter
			{
				public TearOffWhereParameter(WhereClause clause)
				{
					this._clause = clause;
				}
				
				
				public WhereParameter ID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ID, Parameters.ID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter StoreID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.StoreID, Parameters.StoreID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ItemID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ItemID, Parameters.ItemID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

                public WhereParameter StartDate
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ItemID, Parameters.StartDate);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter EndDate
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ItemID, Parameters.EndDate);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter ID
		    {
				get
		        {
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public WhereParameter StoreID
		    {
				get
		        {
					if(_Value_W == null)
	        	    {
						_Value_W = TearOff.StoreID;
					}
					return _Value_W;
				}
			}

            public WhereParameter ItemID
		    {
				get
		        {
					if(_Description_W == null)
	        	    {
						_Description_W = TearOff.ItemID;
					}
					return _Description_W;
				}
			}

			private WhereParameter _ID_W = null;
			private WhereParameter _Value_W = null;
			private WhereParameter _Description_W = null;

			public void WhereClauseReset()
			{
				_ID_W = null;
				_Value_W = null;
				_Description_W = null;

				this._entity.Query.FlushWhereParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffWhereParameter _tearOff;
			
		}
	
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
				{
					_whereClause = new WhereClause(this);
				}
		
				return _whereClause;
			}
		}
		
		private WhereClause _whereClause = null;	
		#endregion
	
		#region Aggregate Clause
		public class AggregateClause
		{
			public AggregateClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffAggregateParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffAggregateParameter(this);
					}

					return _tearOff;
				}
			}

			#region AggregateParameter TearOff's
			public class TearOffAggregateParameter
			{
				public TearOffAggregateParameter(AggregateClause clause)
				{
					this._clause = clause;
				}
				
				
				public AggregateParameter ID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ID, Parameters.ID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Value
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Value, Parameters.Value);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Description
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Description, Parameters.Description);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter ID
		    {
				get
		        {
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public AggregateParameter Value
		    {
				get
		        {
					if(_Value_W == null)
	        	    {
						_Value_W = TearOff.Value;
					}
					return _Value_W;
				}
			}

			public AggregateParameter Description
		    {
				get
		        {
					if(_Description_W == null)
	        	    {
						_Description_W = TearOff.Description;
					}
					return _Description_W;
				}
			}

			private AggregateParameter _ID_W = null;
			private AggregateParameter _Value_W = null;
			private AggregateParameter _Description_W = null;

			public void AggregateClauseReset()
			{
				_ID_W = null;
				_Value_W = null;
				_Description_W = null;

				this._entity.Query.FlushAggregateParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
	
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
				{
					_aggregateClause = new AggregateClause(this);
				}
		
				return _aggregateClause;
			}
		}
		
		private AggregateClause _aggregateClause = null;	
		#endregion

        protected override IDbCommand GetInsertCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_StockoutInsert]";

            CreateParameters(cmd);

            SqlParameter p;
            p = cmd.Parameters[Parameters.ID.ParameterName];
            p.Direction = ParameterDirection.Output;

            return cmd;
        }

        private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.ID);
			p.SourceColumn = ColumnNames.ID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Value);
			p.SourceColumn = ColumnNames.Value;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Description);
			p.SourceColumn = ColumnNames.Description;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
