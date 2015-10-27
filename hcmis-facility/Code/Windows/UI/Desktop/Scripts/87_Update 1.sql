
/*
   Tuesday, October 02, 20124:10:56 PM
   User: 
   Server: TOSHIBA-PC\SQLEXPRESS
   Database: E:\SHERAROHCDB\PHARMINVENTORY.MDF
   Application: 
*/

IF EXISTS (select 1 from sys.Objects where Object_ID = Object_ID(N'FK_Items_INN'))
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_INN
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Type
	(
	ID int NOT NULL,
	Name varchar(50) NULL,
	Description varchar(50) NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.Type)
	 EXEC('INSERT INTO dbo.Tmp_Type (ID, Name, Description)
		SELECT ID, Name, Description FROM dbo.Type WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Product
	DROP CONSTRAINT FK_INN_Type
GO
DROP TABLE dbo.Type
GO
EXECUTE sp_rename N'dbo.Tmp_Type', N'Type', 'OBJECT' 
GO
ALTER TABLE dbo.Type ADD CONSTRAINT
	PK_Type PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT


select Has_Perms_By_Name(N'dbo.Type', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Type', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Type', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	FK_INN_Type FOREIGN KEY
	(
	TypeID
	) REFERENCES dbo.Type
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vwGetAllItems]
AS
SELECT DISTINCT 
					  dbo.Items.ID, ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.DosageForm.Form, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, 
					  dbo.Product.IIN AS ItemName, dbo.Product.ATC, dbo.Items.Strength, dbo.Items.ABC AS ABCID, dbo.ABC.Value AS ABC, dbo.VEN.Value AS VEN, 
					  dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.IsDiscontinued, dbo.Items.EDL, dbo.Items.Refrigeratored, dbo.Items.Pediatric, dbo.Items.DosageFormID, 
					  dbo.DosageForm.Form AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo.Product.TypeID, 
					  dbo.Type.Name, dbo.Items.StockCodeDACA, dbo.Items.Code, dbo.Items.NeedExpiryBatch, dbo.Items.StorageTypeID, 
					  dbo.Items.NearExpiryTrigger, dbo.SubCategory.CategoryId, PC.SubCategoryID
FROM				  
					  dbo.Product join dbo.Items ON dbo.Items.IINID = dbo.Product.ID INNER JOIN
					  dbo.DosageForm  ON dbo.DosageForm.ID = dbo.Items.DosageFormID left JOIN
					  dbo.ABC ON  dbo.Items.ABC =dbo.ABC.ID left JOIN
					  dbo.VEN ON dbo.Items.VEN = dbo.VEN.ID INNER JOIN
					  dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID INNER JOIN
					  dbo.[Type] ON dbo.Product.TypeID = dbo.Type.ID left JOIN
					  (select ItemID,max(SubCategoryID) SubCategoryID from dbo.ProductsCategory Group By ItemID) as PC ON dbo.Items.ID = PC.ItemId INNER JOIN
					  dbo.SubCategory ON PC.SubCategoryID = dbo.SubCategory.ID AND (dbo.Product.TypeID = 1 or dbo.Product.TypeID = 7)

Union  
SELECT DISTINCT 
					  dbo.Items.ID, ISNULL(dbo.Product.IIN, '') + ' - ' + ISNULL(dbo.Items.Strength, '') AS FullItemName, 
					  dbo.Product.IIN AS ItemName, dbo.Product.ATC, dbo.Items.Strength, dbo.Items.ABC AS ABCID, null AS ABC, null AS VEN, 
					  dbo.Items.VEN AS VENID, dbo.Items.IsFree, dbo.Items.IsDiscontinued, dbo.Items.EDL, dbo.Items.Refrigeratored, dbo.Items.Pediatric, dbo.Items.DosageFormID, 
					  null AS DosageForm, dbo.Items.UnitID, dbo.Unit.Unit, dbo.Items.StockCode, dbo.Items.IINID, dbo.Items.IsInHospitalList, dbo.Product.TypeID, 
					  dbo.Type.Name, dbo.Items.StockCodeDACA, dbo.Items.Code, dbo.Items.NeedExpiryBatch, dbo.Items.StorageTypeID, 
					  dbo.Items.NearExpiryTrigger,dbo.SupplyCategory.ParentId as CategoryID ,dbo.ItemSupplyCategory.CategoryID as SubCategoryID 
FROM        
					  dbo.Items   JOIN
				
					  dbo.Unit ON dbo.Items.UnitID = dbo.Unit.ID  JOIN
					  dbo.Product ON dbo.Items.IINID = dbo.Product.ID inner JOIN
					  dbo.Type ON dbo.Product.TypeID = dbo.Type.ID inner JOIN
					  dbo.ItemSupplyCategory ON dbo.Items.ID = dbo.ItemSupplyCategory.ItemID inner JOIN
					 dbo.SupplyCategory on dbo.ItemSupplyCategory.CategoryID = dbo.SupplyCategory.ID 
					 and (dbo.Product.TypeID <> 1 and dbo.Product.TypeID <> 7)
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

 
 


/*
   Tuesday, October 02, 20121:19:49 PM
   User: 
   Server: toshiba-pc\sqlexpress
   Database: E:\BELETESHACHEWDB\PHARMINVENTORY.MDF
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_VEN
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VEN', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VEN', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VEN', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_Unit
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Unit', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Unit', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Unit', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_StorageType
GO
COMMIT
select Has_Perms_By_Name(N'dbo.StorageType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.StorageType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.StorageType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_DosageForm
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DosageForm', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DosageForm', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DosageForm', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Items
	DROP CONSTRAINT FK_Items_ABC
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ABC', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ABC', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ABC', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO

COMMIT
select Has_Perms_By_Name(N'dbo.Product', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Product', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO

IF EXISTS (select 1 from sys.Objects where Object_ID = Object_ID(N'DF_Items_IsInHospitalList'))
ALTER TABLE dbo.Items
	DROP CONSTRAINT DF_Items_IsInHospitalList
GO
CREATE TABLE dbo.Tmp_Items
	(
	ID int NOT NULL IDENTITY (1, 1),
	StockCode varchar(50) NULL,
	Strength varchar(1500) NULL,
	DosageFormID int NULL,
	UnitID int NULL,
	VEN int NULL,
	ABC int NULL,
	IsFree bit NULL,
	IsDiscontinued bit NULL,
	Cost decimal(18, 0) NULL,
	EDL bit NULL,
	Refrigeratored bit NULL,
	Pediatric bit NULL,
	IINID int NULL,
	IsInHospitalList bit NULL,
	NeedExpiryBatch bit NULL,
	Code varchar(50) NULL,
	StockCodeDACA varchar(50) NULL,
	NearExpiryTrigger float(53) NULL,
	StorageTypeID int NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.Tmp_Items ADD CONSTRAINT
	DF_Items_IsInHospitalList DEFAULT ((1)) FOR IsInHospitalList
GO
SET IDENTITY_INSERT dbo.Tmp_Items ON
GO
IF EXISTS(SELECT * FROM dbo.Items)
	 EXEC('INSERT INTO dbo.Tmp_Items (ID, StockCode, Strength, DosageFormID, UnitID, VEN, ABC, IsFree, IsDiscontinued, Cost, EDL, Refrigeratored, Pediatric, IINID, IsInHospitalList, NeedExpiryBatch, Code, StockCodeDACA, NearExpiryTrigger, StorageTypeID)
		SELECT ID, StockCode, Strength, DosageFormID, UnitID, VEN, ABC, IsFree, IsDiscontinued, Cost, EDL, Refrigeratored, Pediatric, IINID, IsInHospitalList, NeedExpiryBatch, Code, StockCodeDACA, NearExpiryTrigger, StorageTypeID FROM dbo.Items WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Items OFF
GO

ALTER TABLE dbo.ReceiveDoc
	DROP CONSTRAINT FK_ReceiveDoc_Items
GO

IF EXISTS (select 1 from sys.Objects where Object_ID = Object_ID(N'FK_ItemShelf_Items'))
ALTER TABLE dbo.ItemShelf
	DROP CONSTRAINT FK_ItemShelf_Items
GO

ALTER TABLE dbo.ItemManufacturer
	DROP CONSTRAINT FK_ItemManufacturer_Items
GO
ALTER TABLE dbo.Disposal
	DROP CONSTRAINT FK_Disposal_Items
GO
ALTER TABLE dbo.ProgramProduct
	DROP CONSTRAINT FK_ProgramProduct_Items
GO
ALTER TABLE dbo.ItemSupplier
	DROP CONSTRAINT FK_ItemSupplier_Items
GO
ALTER TABLE dbo.ItemSupplyCategory
	DROP CONSTRAINT FK_ItemSupplyCategory_Items
GO
ALTER TABLE dbo.OrderDetail
	DROP CONSTRAINT FK_OrderDetail_Items
GO
ALTER TABLE dbo.Balance
	DROP CONSTRAINT FK_Balance_Items
GO
ALTER TABLE dbo.YearEnd
	DROP CONSTRAINT FK_YearEnd_Items
GO
ALTER TABLE dbo.IssueDoc
	DROP CONSTRAINT FK_IssueDoc_Items
GO
ALTER TABLE dbo.RRFDetail
	DROP CONSTRAINT FK_RRFDetail_Items
GO
DROP TABLE dbo.Items
GO
EXECUTE sp_rename N'dbo.Tmp_Items', N'Items', 'OBJECT' 
GO
ALTER TABLE dbo.Items ADD CONSTRAINT
	PK_ITem PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Items ADD CONSTRAINT
	FK_Items_INN FOREIGN KEY
	(
	IINID
	) REFERENCES dbo.Product
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Items WITH NOCHECK ADD CONSTRAINT
	FK_Items_ABC FOREIGN KEY
	(
	ABC
	) REFERENCES dbo.ABC
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Items WITH NOCHECK ADD CONSTRAINT
	FK_Items_DosageForm FOREIGN KEY
	(
	DosageFormID
	) REFERENCES dbo.DosageForm
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Items WITH NOCHECK ADD CONSTRAINT
	FK_Items_StorageType FOREIGN KEY
	(
	StorageTypeID
	) REFERENCES dbo.StorageType
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Items WITH NOCHECK ADD CONSTRAINT
	FK_Items_Unit FOREIGN KEY
	(
	UnitID
	) REFERENCES dbo.Unit
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Items WITH NOCHECK ADD CONSTRAINT
	FK_Items_VEN FOREIGN KEY
	(
	VEN
	) REFERENCES dbo.VEN
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Items', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Items', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Items', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.RRFDetail ADD CONSTRAINT
	FK_RRFDetail_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.RRFDetail', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.RRFDetail', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.RRFDetail', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.IssueDoc ADD CONSTRAINT
	FK_IssueDoc_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IssueDoc', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IssueDoc', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IssueDoc', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.YearEnd ADD CONSTRAINT
	FK_YearEnd_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.YearEnd', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.YearEnd', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.YearEnd', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Balance ADD CONSTRAINT
	FK_Balance_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Balance', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Balance', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Balance', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.OrderDetail ADD CONSTRAINT
	FK_OrderDetail_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.OrderDetail', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.OrderDetail', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.OrderDetail', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ItemSupplyCategory ADD CONSTRAINT
	FK_ItemSupplyCategory_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ItemSupplyCategory', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ItemSupplyCategory', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ItemSupplyCategory', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ItemSupplier ADD CONSTRAINT
	FK_ItemSupplier_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ItemSupplier', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ItemSupplier', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ItemSupplier', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProgramProduct ADD CONSTRAINT
	FK_ProgramProduct_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ProgramProduct', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ProgramProduct', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ProgramProduct', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Disposal ADD CONSTRAINT
	FK_Disposal_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Disposal', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Disposal', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Disposal', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ItemManufacturer ADD CONSTRAINT
	FK_ItemManufacturer_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ItemManufacturer', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ItemManufacturer', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ItemManufacturer', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ItemShelf ADD CONSTRAINT
	FK_ItemShelf_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ItemShelf', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ItemShelf', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ItemShelf', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.ReceiveDoc ADD CONSTRAINT
	FK_ReceiveDoc_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ReceiveDoc', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ReceiveDoc', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ReceiveDoc', 'Object', 'CONTROL') as Contr_Per 


ALTER TABLE [dbo].[ProductsCategory] DROP CONSTRAINT [FK_ProductsCategory_SubCategory]
GO

Insert into [Type] (ID, Name) values (7, 'Pharmaceuticals')
Insert into [Type] (ID, Name) values (8, 'Medical Supplies')
Insert into [Type] (ID, Name) values (9, 'Medical Equipment')
Insert into [Type] (ID, Name) values (10, 'Chemicals & Reagents')

UPDATE Product set TypeID = 7 where TypeID = 1
GO
UPDATE Product set TypeID = 8 where TypeID = 2
GO
UPDATE Product set TypeID = 9 where TypeID = 3
GO
UPDATE Product set TypeID = 10 where TypeID = 4
GO
DELETE [Type]  where ID = 1
GO

DELETE [Type]  where ID = 2
GO
DELETE [Type]  where ID = 3
GO

DELETE [Type]  where ID = 4
GO
Update Items set IsInHospitalList = 1 where ID in (select ItemID from ReceiveDoc)
GO
update dbo.GeneralInfo set HospitalContact = 0 
GO

IF EXISTS (select 1 from sys.Objects where Object_ID = Object_ID(N'RPT_BinCard'))
	DROP  PROC RPT_BinCard

GO
Create PROC [dbo].[Rpt_BinCard]
    @StoreID as int,
    @ItemID as int,
    @Year as int   
AS
 
declare @rangedate datetime
declare @todate datetime
declare @fromdate datetime
declare @endyear int
 
select @endyear = @year;
select @fromdate = cast(('11/1/' +  cast((@year - 1) as varchar) )  as datetime)
select @todate = cast(('10/30/' +  cast((@year) as varchar) )  as datetime)
 
select * into #tmp from 
(
-- select the received item
select rd.ID, rd.ItemID, ISNULL(rd.RefNo,'') as RefNo , ISNULL(rd.Date,'') as [Date], ISNULL(rd.BatchNo,'')as [BatchNo], (rd.Quantity - isnull((SELECT SUM(d.Quantity) from Disposal d where d.RecID = rd.ID and Losses = 0) ,0)) as Received, Issued = 0, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * rd.Quantity, 0) as TotalPrice, Balance = 0 , ISNULL(ExpDate,'') ExpDate,Precedance = 1,ToFrom = (SELECT CompanyName from Supplier where ID = rd.SupplierID) from ReceiveDoc rd where ItemID = @ItemID and StoreID=@StoreID and rd.[Date] between @fromdate and @todate
Union
-- select the issued item
select id.ID, rd.ItemID, ISNULL(id.RefNo,'') , ISNULL(id.Date,''), ISNULL(rd.BatchNo,''), Received = 0, ISNULL(id.Quantity,'') as Issued, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * id.Quantity, 0) as TotalPrice, Balance = 0 , ISNULL(ExpDate,''), Precedance = 3 ,ToFrom = (SELECT Name from ReceivingUnits where ID = id.ReceivingUnitID) from IssueDoc id join ReceiveDoc rd on id.RecievDocID = rd.ID where id.ItemID = @ItemID  and id.StoreID=@StoreID and rd.StoreID=@StoreID  and id.[Date] between @fromdate and @todate
Union
-- select the Lost
select d.ID, rd.ItemID, ISNULL(d.RefNo,'') , ISNULL(d.Date,''), ISNULL(rd.BatchNo,''), Received = 0,ISNULL( d.Quantity,0) as Issued, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * d.Quantity, 0) as TotalPrice, Balance = 0, ExpDate  , Precedance = 4, ToFrom = (SELECT cast (Reason as Varchar) from DisposalReasons where ID = d.ReasonId) from Disposal d join ReceiveDoc rd on d.RecID = rd.ID where d.ItemID = @ItemID  and d.StoreID=@StoreID  and d.Losses = 1 and d.[Date] between @fromdate and @todate
Union
-- select the Found/Adjusted
select d.ID, rd.ItemID, ISNULL(d.RefNo,'') , ISNULL(d.Date,''), ISNULL(rd.BatchNo,''), ISNULL(d.Quantity,0) as Received, Issued = null, ISNULL(rd.Cost,0) UnitPrice, ISNULL(rd.Cost * d.Quantity, 0) as TotalPrice, Balance = 0, ExpDate ,Precedance = 2, ToFrom = (SELECT cast(Reason as Varchar) from DisposalReasons where ID = d.ReasonId) from Disposal d join ReceiveDoc rd on d.RecID = rd.ID where d.ItemID = @ItemID  and d.StoreID=@StoreID  and d.Losses = 0  and d.[Date] between @fromdate and @todate
-- return the table.
) results order by [Date], Precedance
 
DECLARE @Balance as int
set @Balance = 0
select  @Balance = ISNULL(ye.PhysicalInventory,0) from YearEnd ye where ye.Year = @year and ye.StoreID = @StoreID 
 
update t set  Balance = ISNULL(Received,0) - ISNULL(Issued, 0) from #tmp t 
 
 
select * from #tmp
order by [Date],Precedance
GO