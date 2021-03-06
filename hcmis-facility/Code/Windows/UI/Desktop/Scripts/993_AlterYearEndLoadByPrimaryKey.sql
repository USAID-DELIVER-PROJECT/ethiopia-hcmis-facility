ALTER PROCEDURE [dbo].[proc_YearEndLoadByPrimaryKey]
(
	@ID int
)
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
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
