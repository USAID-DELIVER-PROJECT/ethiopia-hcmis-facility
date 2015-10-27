using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;
namespace DAL
{
   public abstract class _Transfer :SqlClientEntity
    {
       public _Transfer()
       {
           this.QuerySource = "Transfer";
           this.MappingName = "Transfer";
       }

       public override void FlushData()
       {
           this._whereClause = null;
           this._aggregateClause = null;
           base.FlushData();
       }

       //=================================================================
       //  	public Function LoadAll() As Boolean
       //=================================================================
       //  Loads all of the records in the database, and sets the currentRow to the first row
       //=================================================================
       public bool LoadAll()
       {
           ListDictionary parameters = null;

           return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_TransferLoadAll]", parameters);
       }

       //=================================================================
       // public Overridable Function LoadByPrimaryKey()  As Boolean
       //=================================================================
       //  Loads a single row of via the primary key
       //=================================================================
       public virtual bool LoadByPrimaryKey(int ID)
       {
           ListDictionary parameters = new ListDictionary();
           parameters.Add(_Transfer.Parameters.ID, ID);


           return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_TransferLoadByPrimaryKey]", parameters);
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

           public static SqlParameter ItemID
           {
               get
               {
                   return new SqlParameter("@ItemID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter BatchNo
           {
               get
               {
                   return new SqlParameter("@BatchNo", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter Quantity
           {
               get
               {
                   return new SqlParameter("@Quantity", SqlDbType.BigInt, 0);
               }
           }

           public static SqlParameter UnitID
           {
               get
               {
                   return new SqlParameter("@UnitID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter FromStoreID
           {
               get
               {
                   return new SqlParameter("@FromStoreID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter ToStoreID
           {
               get
               {
                   return new SqlParameter("@ToStoreID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter RefNo
           {
               get
               {
                   return new SqlParameter("@RefNo", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter Date
           {
               get
               {
                   return new SqlParameter("@Date", SqlDbType.DateTime, 0);
               }
           }

           public static SqlParameter EurDate
           {
               get
               {
                   return new SqlParameter("@EurDate", SqlDbType.DateTime, 0);
               }
           }

           public static SqlParameter TransferRequestedBy
           {
               get
               {
                   return new SqlParameter("@TransferRequestedBy", SqlDbType.NVarChar, 100);
               }
           }

           public static SqlParameter TransferReason
           {
               get
               {
                   return new SqlParameter("@TransferReason", SqlDbType.Text, 2147483647);
               }
           }

           public static SqlParameter ApprovedBy
           {
               get
               {
                   return new SqlParameter("@ApprovedBy", SqlDbType.NVarChar, 100);
               }
           }

           public static SqlParameter RecID
           {
               get
               {
                   return new SqlParameter("@RecID", SqlDbType.Int, 0);
               }
           }
            
       }
       #endregion

       #region ColumnNames
       public class ColumnNames
       {
           public const string ID = "ID";
           public const string ItemID = "ItemID";
           public const string BatchNo = "BatchNo";
           public const string Quantity = "Quantity";
           public const string UnitID = "UnitID";
           public const string FromStoreID = "FromStoreID";
           public const string ToStoreID = "ToStoreID";
           public const string RefNo = "RefNo";
           public const string Date = "Date";
           public const string EurDate = "EurDate";
           public const string TransferRequestedBy = "TransferRequestedBy";
           public const string TransferReason = "TransferReason";
           public const string ApprovedBy = "ApprovedBy";
           public const string RecID = "RecID";

           static public string ToPropertyName(string columnName)
           {
               if (ht == null)
               {
                   ht = new Hashtable();

                   ht[ID] = _Transfer.PropertyNames.ID;
                   ht[BatchNo] = _Transfer.PropertyNames.BatchNo;
                   ht[ItemID] = _Transfer.PropertyNames.ItemID;
                   ht[Quantity] = _Transfer.PropertyNames.Quantity;
                   ht[UnitID] = _Transfer.PropertyNames.UnitID;
                   ht[Date] = _Transfer.PropertyNames.Date;
                   ht[FromStoreID] = _Transfer.PropertyNames.FromStoreID;
                   ht[ToStoreID] = _Transfer.PropertyNames.ToStoreID;
                   ht[RefNo] = _Transfer.PropertyNames.RefNo;
                   ht[EurDate] = _Transfer.PropertyNames.EurDate;
                   ht[TransferReason] = _Transfer.PropertyNames.TransferReason;
                   ht[TransferRequestedBy] = _Transfer.PropertyNames.TransferRequestedBy;
                   ht[ApprovedBy] = _Transfer.PropertyNames.ApprovedBy;
                   ht[RecID] = _Transfer.PropertyNames.RecID;

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
           public const string BatchNo = "BatchNo";
           public const string ItemID = "ItemID";
           public const string Quantity = "Quantity";
           public const string Date = "Date";
           public const string FromStoreID = "FromStoreID";
           public const string ToStoreID = "ToStoreID";
           public const string RefNo = "RefNo";
           public const string EurDate = "EurDate";
           public const string UnitID = "UnitID";
           public const string TransferRequestedBy = "TransferRequestedBy";
           public const string TransferReason = "TransferReason";
           public const string ApprovedBy = "ApprovedBy";
           public const string RecID = "RecID";

           static public string ToColumnName(string propertyName)
           {
               if (ht == null)
               {
                   ht = new Hashtable();

                   ht[ID] = _Transfer.ColumnNames.ID;
                   ht[BatchNo] = _Transfer.ColumnNames.BatchNo;
                   ht[ItemID] = _Transfer.ColumnNames.ItemID;
                   ht[Quantity] = _Transfer.ColumnNames.Quantity;
                   ht[Date] = _Transfer.ColumnNames.Date;
                   ht[FromStoreID] = _Transfer.ColumnNames.FromStoreID;
                   ht[ToStoreID] = _Transfer.ColumnNames.ToStoreID;
                   ht[TransferReason] = _Transfer.ColumnNames.TransferReason;
                   ht[RefNo] = _Transfer.ColumnNames.RefNo;
                   ht[TransferRequestedBy] = _Transfer.ColumnNames.TransferRequestedBy;
                   ht[ApprovedBy] = _Transfer.ColumnNames.ApprovedBy;
                   ht[EurDate] = _Transfer.ColumnNames.EurDate;
                   ht[UnitID] = _Transfer.ColumnNames.UnitID;
                   ht[RecID] = _Transfer.ColumnNames.RecID;
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
           public const string BatchNo = "s_BatchNo";
           public const string ItemID = "s_ItemID";
           public const string Quantity = "s_Quantity";
           public const string Date = "s_Date";
           public const string FromStoreID = "s_FromStoreID";
           public const string ToStoreID = "s_ToStoreID";
           public const string RefNo = "s_RefNo";
           public const string TransferReason = "s_TransferReason";
           public const string ApprovedBy = "s_ApprovedBy";
           public const string TransferRequestedBy = "s_TransferRequestedBy";
           public const string EurDate = "s_EurDate";
           public const string UnitID = "s_UnitID";
           public const string RecID = "s_RecID";
       }
       #endregion

       #region Properties

       public virtual int ID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ID, value);
           }
       }

       public virtual string BatchNo
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.BatchNo);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.BatchNo, value);
           }
       }

       public virtual int ItemID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ItemID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ItemID, value);
           }
       }

       public virtual string TransferRequestedBy
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.TransferRequestedBy);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.TransferRequestedBy, value);
           }
       }

       public virtual long Quantity
       {
           get
           {
               return base.Getlong(_Transfer.ColumnNames.Quantity);
           }
           set
           {
               base.Setlong(_Transfer.ColumnNames.Quantity, value);
           }
       }

       public virtual DateTime Date
       {
           get
           {
               return base.GetDateTime(_Transfer.ColumnNames.Date);
           }
           set
           {
               base.SetDateTime(_Transfer.ColumnNames.Date, value);
           }
       }

       public virtual string ApprovedBy
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.ApprovedBy);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.ApprovedBy, value);
           }
       }

       public virtual string TransferReason
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.TransferReason);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.TransferReason, value);
           }
       }

       public virtual int FromStoreID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.FromStoreID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.FromStoreID, value);
           }
       }

       public virtual int ToStoreID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ToStoreID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ToStoreID, value);
           }
       }

       public virtual string RefNo
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.RefNo);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.RefNo, value);
           }
       }

       public virtual DateTime EurDate
       {
           get
           {
               return base.GetDateTime(_Transfer.ColumnNames.EurDate);
           }
           set
           {
               base.SetDateTime(_Transfer.ColumnNames.EurDate, value);
           }
       }

       public virtual int UnitID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.UnitID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.UnitID, value);
           }
       }

       public virtual int RecID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.RecID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.RecID, value);
           }
       }

       #endregion

       #region String Properties

       public virtual string s_ID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ID);
               else
                   this.ID = base.SetintAsString(_Transfer.ColumnNames.ID, value);
           }
       }

       public virtual string s_BatchNo
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.BatchNo) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.BatchNo);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.BatchNo);
               else
                   this.BatchNo = base.SetstringAsString(_Transfer.ColumnNames.BatchNo, value);
           }
       }

       public virtual string s_ItemID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ItemID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ItemID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ItemID);
               else
                   this.ItemID = base.SetintAsString(_Transfer.ColumnNames.ItemID, value);
           }
       }

       public virtual string s_TransferReason
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.TransferReason) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.TransferReason);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.TransferReason);
               else
                   this.TransferReason = base.SetstringAsString(_Transfer.ColumnNames.TransferReason, value);
           }
       }

       public virtual string s_Quantity
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Quantity) ? string.Empty : base.GetlongAsString(_Transfer.ColumnNames.Quantity);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Quantity);
               else
                   this.Quantity = base.SetlongAsString(_Transfer.ColumnNames.Quantity, value);
           }
       }

       public virtual string s_Date
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Date) ? string.Empty : base.GetDateTimeAsString(_Transfer.ColumnNames.Date);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Date);
               else
                   this.Date = base.SetDateTimeAsString(_Transfer.ColumnNames.Date, value);
           }
       }

       public virtual string s_TransferRequestedBy
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.TransferRequestedBy) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.TransferRequestedBy);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.TransferRequestedBy);
               else
                   this.TransferRequestedBy = base.SetstringAsString(_Transfer.ColumnNames.TransferRequestedBy, value);
           }
       }
    
       public virtual string s_ApprovedBy
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ApprovedBy) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.ApprovedBy);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ApprovedBy);
               else
                   this.ApprovedBy = base.SetstringAsString(_Transfer.ColumnNames.ApprovedBy, value);
           }
       }

       public virtual string s_FromStoreID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.FromStoreID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.FromStoreID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.FromStoreID);
               else
                   this.FromStoreID = base.SetintAsString(_Transfer.ColumnNames.FromStoreID, value);
           }
       }

       public virtual string s_ToStoreID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ToStoreID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ToStoreID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ToStoreID);
               else
                   this.ToStoreID = base.SetintAsString(_Transfer.ColumnNames.ToStoreID, value);
           }
       }

       public virtual string s_RefNo
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.RefNo) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.RefNo);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.RefNo);
               else
                   this.RefNo = base.SetstringAsString(_Transfer.ColumnNames.RefNo, value);
           }
       }

       public virtual string s_EurDate
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.EurDate) ? string.Empty : base.GetDateTimeAsString(_Transfer.ColumnNames.EurDate);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.EurDate);
               else
                   this.EurDate = base.SetDateTimeAsString(_Transfer.ColumnNames.EurDate, value);
           }
       }

       public virtual string s_UnitID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.UnitID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.UnitID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.UnitID);
               else
                   this.UnitID = base.SetintAsString(_Transfer.ColumnNames.UnitID, value);
           }
       }

       public virtual string s_RecID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.RecID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.RecID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.RecID);
               else
                   this.RecID = base.SetintAsString(_Transfer.ColumnNames.RecID, value);
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

           public _Transfer.WhereClause.TearOffWhereParameter TearOff
           {
               get
               {
                   if (_tearOff == null)
                   {
                       _tearOff = new _Transfer.WhereClause.TearOffWhereParameter(this);
                   }

                   return _tearOff;
               }
           }

           #region WhereParameter TearOff's
           public class TearOffWhereParameter
           {
               public TearOffWhereParameter(_Transfer.WhereClause clause)
               {
                   this._clause = clause;
               }


               public WhereParameter ID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ID, _Transfer.Parameters.ID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter BatchNo
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.BatchNo, _Transfer.Parameters.BatchNo);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ItemID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ItemID, _Transfer.Parameters.ItemID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Quantity
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Quantity, _Transfer.Parameters.Quantity);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Date
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Date, _Transfer.Parameters.Date);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ApprovedBy
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ApprovedBy, _Transfer.Parameters.ApprovedBy);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter TransferRequestedBy    
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.TransferRequestedBy, _Transfer.Parameters.TransferRequestedBy);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter FromStoreID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.FromStoreID, _Transfer.Parameters.FromStoreID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ToStoreID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ToStoreID, _Transfer.Parameters.ToStoreID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter RefNo
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.RefNo, _Transfer.Parameters.RefNo);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter TransferReason
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.TransferReason, _Transfer.Parameters.TransferReason);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter EurDate
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.EurDate, _Transfer.Parameters.EurDate);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter UnitID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.UnitID, _Transfer.Parameters.UnitID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter RecID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.RecID, _Transfer.Parameters.RecID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }



               private _Transfer.WhereClause _clause;
           }
           #endregion

           public WhereParameter ID
           {
               get
               {
                   if (_ID_W == null)
                   {
                       _ID_W = TearOff.ID;
                   }
                   return _ID_W;
               }
           }

           public WhereParameter BatchNo
           {
               get
               {
                   if (_BatchNo_W == null)
                   {
                       _BatchNo_W = TearOff.BatchNo;
                   }
                   return _BatchNo_W;
               }
           }

           public WhereParameter ItemID
           {
               get
               {
                   if (_ItemID_W == null)
                   {
                       _ItemID_W = TearOff.ItemID;
                   }
                   return _ItemID_W;
               }
           }

          public WhereParameter Quantity
           {
               get
               {
                   if (_Quantity_W == null)
                   {
                       _Quantity_W = TearOff.Quantity;
                   }
                   return _Quantity_W;
               }
           }

           public WhereParameter Date
           {
               get
               {
                   if (_Date_W == null)
                   {
                       _Date_W = TearOff.Date;
                   }
                   return _Date_W;
               }
           }

           public WhereParameter ApprovedBy
           {
               get
               {
                   if (_ApprovedBy_W == null)
                   {
                       _ApprovedBy_W = TearOff.ApprovedBy;
                   }
                   return _ApprovedBy_W;
               }
           }

           public WhereParameter TransferRequestedBy
           {
               get
               {
                   if (_TransferRequestedBy_W == null)
                   {
                       _TransferRequestedBy_W = TearOff.TransferRequestedBy;
                   }
                   return _TransferRequestedBy_W;
               }
           }

           public WhereParameter TransferReason
           {
               get
               {
                   if (_TransferReason_W == null)
                   {
                       _TransferReason_W = TearOff.TransferReason;
                   }
                   return _TransferReason_W;
               }
           }

           public WhereParameter FromStoreID
           {
               get
               {
                   if (_FromStoreID_W == null)
                   {
                       _FromStoreID_W = TearOff.FromStoreID;
                   }
                   return _FromStoreID_W;
               }
           }

           public WhereParameter ToStoreID
           {
               get
               {
                   if (_ToStoreID_W == null)
                   {
                       _ToStoreID_W = TearOff.ToStoreID;
                   }
                   return _ToStoreID_W;
               }
           }

           public WhereParameter RefNo
           {
               get
               {
                   if (_RefNo_W == null)
                   {
                       _RefNo_W = TearOff.RefNo;
                   }
                   return _RefNo_W;
               }
           }
  
           public WhereParameter UnitID
           {
               get
               {
                   if (_UnitID_W == null)
                   {
                       _UnitID_W = TearOff.UnitID;
                   }
                   return _UnitID_W;
               }
           }

           public WhereParameter EurDate
           {
               get
               {
                   if (_EurDate_W == null)
                   {
                       _EurDate_W = TearOff.EurDate;
                   }
                   return _EurDate_W;
               }
           }

           public WhereParameter RecID
           {
               get
               {
                   if (_RecID_W == null)
                   {
                       _RecID_W = TearOff.RecID;
                   }
                   return _RecID_W;
               }
           }

          
         
           private WhereParameter _ID_W = null;
           private WhereParameter _BatchNo_W = null;
           private WhereParameter _ItemID_W = null;
           private WhereParameter _Quantity_W = null;
           private WhereParameter _Date_W = null;
           private WhereParameter _TransferReason_W = null;
           private WhereParameter _TransferRequestedBy_W = null;
           private WhereParameter _FromStoreID_W = null;
           private WhereParameter _ToStoreID_W = null;
           private WhereParameter _RefNo_W = null;
           private WhereParameter _EurDate_W = null;
           private WhereParameter _ApprovedBy_W = null;
           private WhereParameter _UnitID_W = null;
           private WhereParameter _RecID_W = null;

           public void WhereClauseReset()
           {
               _ID_W = null;
               _BatchNo_W = null;
               _ItemID_W = null;
               _Quantity_W = null;
               _Date_W = null;
               _FromStoreID_W = null;
               _ToStoreID_W = null;
               _TransferReason_W = null;
               _RefNo_W = null;
               _TransferRequestedBy_W = null;
               _EurDate_W = null;
               _ApprovedBy_W = null;
               _UnitID_W = null;
               _RecID_W= null;

               this._entity.Query.FlushWhereParameters();

           }

           private BusinessEntity _entity;
           private _Transfer.WhereClause.TearOffWhereParameter _tearOff;

       }

       public _Transfer.WhereClause Where
       {
           get
           {
               if (_whereClause == null)
               {
                   _whereClause = new _Transfer.WhereClause(this);
               }

               return _whereClause;
           }
       }

       private _Transfer.WhereClause _whereClause = null;
       #endregion

       #region Aggregate Clause
       public class AggregateClause
       {
           public AggregateClause(BusinessEntity entity)
           {
               this._entity = entity;
           }

           public _Transfer.AggregateClause.TearOffAggregateParameter TearOff
           {
               get
               {
                   if (_tearOff == null)
                   {
                       _tearOff = new _Transfer.AggregateClause.TearOffAggregateParameter(this);
                   }

                   return _tearOff;
               }
           }

           #region AggregateParameter TearOff's
           public class TearOffAggregateParameter
           {
               public TearOffAggregateParameter(_Transfer.AggregateClause clause)
               {
                   this._clause = clause;
               }


               public AggregateParameter ID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ID, _Transfer.Parameters.ID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter BatchNo
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.BatchNo, _Transfer.Parameters.BatchNo);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ItemID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ItemID, _Transfer.Parameters.ItemID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter TransferRequestedBy
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.TransferRequestedBy, _Transfer.Parameters.TransferRequestedBy);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Quantity
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Quantity, _Transfer.Parameters.Quantity);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Date
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Date, _Transfer.Parameters.Date);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter TransferReason
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.TransferReason, _Transfer.Parameters.TransferReason);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ApprovedBy
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ApprovedBy, _Transfer.Parameters.ApprovedBy);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               
               public AggregateParameter FromStoreID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.FromStoreID, _Transfer.Parameters.FromStoreID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ToStoreID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ToStoreID, _Transfer.Parameters.ToStoreID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

             public AggregateParameter RefNo
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.RefNo, _Transfer.Parameters.RefNo);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

             
              
               public AggregateParameter EurDate
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.EurDate, _Transfer.Parameters.EurDate);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }


               public AggregateParameter UnitID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.UnitID, _Transfer.Parameters.UnitID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter RecID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.RecID, _Transfer.Parameters.RecID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               private _Transfer.AggregateClause _clause;
           }
           #endregion

           public AggregateParameter ID
           {
               get
               {
                   if (_ID_W == null)
                   {
                       _ID_W = TearOff.ID;
                   }
                   return _ID_W;
               }
           }

           public AggregateParameter BatchNo
           {
               get
               {
                   if (_BatchNo_W == null)
                   {
                       _BatchNo_W = TearOff.BatchNo;
                   }
                   return _BatchNo_W;
               }
           }

           public AggregateParameter ItemID
           {
               get
               {
                   if (_ItemID_W == null)
                   {
                       _ItemID_W = TearOff.ItemID;
                   }
                   return _ItemID_W;
               }
           }

           public AggregateParameter Quantity
           {
               get
               {
                   if (_Quantity_W == null)
                   {
                       _Quantity_W = TearOff.Quantity;
                   }
                   return _Quantity_W;
               }
           }

           public AggregateParameter Date
           {
               get
               {
                   if (_Date_W == null)
                   {
                       _Date_W = TearOff.Date;
                   }
                   return _Date_W;
               }
           }

           public AggregateParameter TransferReason
           {
               get
               {
                   if (_TransferReason_W == null)
                   {
                       _TransferReason_W = TearOff.TransferReason;
                   }
                   return _TransferReason_W;
               }
           }

           public AggregateParameter ApprovedBy
           {
               get
               {
                   if (_ApprovedBy_W == null)
                   {
                       _ApprovedBy_W = TearOff.ApprovedBy;
                   }
                   return _ApprovedBy_W;
               }
           }

           public AggregateParameter TransferRequestedBy
           {
               get
               {
                   if (_TransferRequestedBy_W == null)
                   {
                       _TransferRequestedBy_W = TearOff.TransferRequestedBy;
                   }
                   return _TransferRequestedBy_W;
               }
           }

           public AggregateParameter FromStoreID
           {
               get
               {
                   if (_FromStoreID_W == null)
                   {
                       _FromStoreID_W = TearOff.FromStoreID;
                   }
                   return _FromStoreID_W;
               }
           }

           public AggregateParameter ToStoreID
           {
               get
               {
                   if (_ToStoreID_W == null)
                   {
                       _ToStoreID_W = TearOff.ToStoreID;
                   }
                   return _ToStoreID_W;
               }
           }

           public AggregateParameter RefNo
           {
               get
               {
                   if (_RefNo_W == null)
                   {
                       _RefNo_W = TearOff.RefNo;
                   }
                   return _RefNo_W;
               }
           }

           public AggregateParameter UnitID
           {
               get
               {
                   if (_UnitID_W == null)
                   {
                       _UnitID_W = TearOff.UnitID;
                   }
                   return _UnitID_W;
               }
           }

           public AggregateParameter EurDate
           {
               get
               {
                   if (_EurDate_W == null)
                   {
                       _EurDate_W = TearOff.EurDate;
                   }
                   return _EurDate_W;
               }
           }

           public AggregateParameter RecID
           {
               get
               {
                   if (_RecID_W == null)
                   {
                       _RecID_W = TearOff.RecID;
                   }
                   return _RecID_W;
               }
           }

       
           private AggregateParameter _ID_W = null;
           private AggregateParameter _BatchNo_W = null;
           private AggregateParameter _ItemID_W = null;
           private AggregateParameter _Quantity_W = null;
           private AggregateParameter _Date_W = null;
           private AggregateParameter _TransferRequestedBy_W = null;
           private AggregateParameter _TransferReason_W = null;
           private AggregateParameter _ApprovedBy_W = null;
           private AggregateParameter _FromStoreID_W = null;
           private AggregateParameter _ToStoreID_W = null;
           private AggregateParameter _RefNo_W = null;
           private AggregateParameter _EurDate_W = null;
           private AggregateParameter _UnitID_W = null;
           private AggregateParameter _RecID_W = null;
           public void AggregateClauseReset()
           {
               _ID_W = null;
               _BatchNo_W = null;
               _ItemID_W = null;
               _TransferReason_W = null;
               _Quantity_W = null;
               _Date_W = null;
               _TransferRequestedBy_W = null;
               _ApprovedBy_W = null;
               _FromStoreID_W = null;
               _ToStoreID_W = null;
               _RefNo_W = null;
               _EurDate_W = null;
               _UnitID_W = null;
               _RecID_W = null;
               this._entity.Query.FlushAggregateParameters();

           }

           private BusinessEntity _entity;
           private _Transfer.AggregateClause.TearOffAggregateParameter _tearOff;

       }

       public _Transfer.AggregateClause Aggregate
       {
           get
           {
               if (_aggregateClause == null)
               {
                   _aggregateClause = new _Transfer.AggregateClause(this);
               }

               return _aggregateClause;
           }
       }

       private _Transfer.AggregateClause _aggregateClause = null;
       #endregion

       protected override IDbCommand GetInsertCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferInsert]";

           CreateParameters(cmd);

           SqlParameter p;
           p = cmd.Parameters[_Transfer.Parameters.ID.ParameterName];
           p.Direction = ParameterDirection.Output;

           return cmd;
       }

       protected override IDbCommand GetUpdateCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferUpdate]";

           CreateParameters(cmd);

           return cmd;
       }

       protected override IDbCommand GetDeleteCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferDelete]";

           SqlParameter p;
           p = cmd.Parameters.Add(_Transfer.Parameters.ID);
           p.SourceColumn = _Transfer.ColumnNames.ID;
           p.SourceVersion = DataRowVersion.Current;


           return cmd;
       }

       private IDbCommand CreateParameters(SqlCommand cmd)
       {
           SqlParameter p;

           p = cmd.Parameters.Add(_Transfer.Parameters.ID);
           p.SourceColumn = _Transfer.ColumnNames.ID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.BatchNo);
           p.SourceColumn = ColumnNames.BatchNo;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ItemID);
           p.SourceColumn = ColumnNames.ItemID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.TransferReason);
           p.SourceColumn = ColumnNames.TransferReason;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Quantity);
           p.SourceColumn = ColumnNames.Quantity;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Date);
           p.SourceColumn = ColumnNames.Date;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ApprovedBy);
           p.SourceColumn = ColumnNames.ApprovedBy;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.TransferRequestedBy);
           p.SourceColumn = ColumnNames.TransferRequestedBy;
           p.SourceVersion = DataRowVersion.Current;

          p = cmd.Parameters.Add(Parameters.FromStoreID);
           p.SourceColumn = ColumnNames.FromStoreID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ToStoreID);
           p.SourceColumn = ColumnNames.ToStoreID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.RefNo);
           p.SourceColumn = ColumnNames.RefNo;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.UnitID);
           p.SourceColumn = ColumnNames.UnitID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.EurDate);
           p.SourceColumn = ColumnNames.EurDate;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.RecID);
           p.SourceColumn = ColumnNames.RecID;
           p.SourceVersion = DataRowVersion.Current;

          return cmd;
       }
    }
}
