ALTER PROCEDURE [dbo].[proc_ItemsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StockCode],
		[Strength],
		[DosageFormID],
		[UnitID],
		[VEN],
		[ABC],
		[IsFree],
		[IsDiscontinued],
		[Cost],
		[EDL],
		[Refrigeratored],
		[Pediatric],
		[IINID],
		[IsInHospitalList],
		[NeedExpiryBatch],
		[Code],
		[StockCodeDACA],
		[NearExpiryTrigger],
		[StorageTypeID],
		[DSItemID]
	FROM [Items]

	SET @Err = @@Error

	RETURN @Err
END
