ALTER PROCEDURE [dbo].[proc_YearEndLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreID],
		[Year],
		[BBalance],
		[EBalance],
		[PhysicalInventory],
		[Remark],
		[Month],
		[EndingPrice],
		[PhysicalInventoryPrice],
		[BBPrice],
		[BatchNo],
		[AutomaticallyEntered],
		[UnitID],
		[QtyPerPack]
	FROM [YearEnd]

	SET @Err = @@Error

	RETURN @Err
END
