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
CREATE TABLE dbo.Tmp_Transfer
	(
	ID int NOT NULL IDENTITY (1, 1),
	ItemID int NULL,
	BatchNo varchar(50) NULL,
	Quantity bigint NULL,
	UnitID int NOT NULL,
	FromStoreID int NULL,
	ToStoreID int NULL,
	RefNo varchar(50) NULL,
	Date datetime NULL,
	EurDate datetime NULL,
	TransferRequestedBy nvarchar(100) NULL,
	TransferReason text NULL,
	ApprovedBy nvarchar(100) NULL,
	RecID int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
ALTER TABLE dbo.Tmp_Transfer SET (LOCK_ESCALATION = TABLE)
SET IDENTITY_INSERT dbo.Tmp_Transfer ON
IF EXISTS(SELECT * FROM dbo.Transfer)
	 EXEC('INSERT INTO dbo.Tmp_Transfer (ID, ItemID, BatchNo, Quantity, UnitID, FromStoreID, ToStoreID, RefNo, Date, EurDate, TransferRequestedBy, TransferReason, ApprovedBy, RecID)
		SELECT ID, ItemID, BatchNo, Quantity, UnitID, FromStoreID, ToStoreID, RefNo, Date, EurDate, TransferRequestedBy, TransferReason, ApprovedBy, RecID FROM dbo.Transfer WITH (HOLDLOCK TABLOCKX)')
SET IDENTITY_INSERT dbo.Tmp_Transfer OFF
DROP TABLE dbo.Transfer
EXECUTE sp_rename N'dbo.Tmp_Transfer', N'Transfer', 'OBJECT' 
ALTER TABLE dbo.Transfer ADD CONSTRAINT
	PK_Transfer PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

COMMIT
