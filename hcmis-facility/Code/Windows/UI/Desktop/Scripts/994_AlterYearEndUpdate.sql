ALTER PROCEDURE [dbo].[proc_YearEndUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@StoreID int = NULL,
	@Year int = NULL,
	@BBalance bigint = NULL,
	@EBalance bigint = NULL,
	@PhysicalInventory bigint = NULL,
	@Remark varchar(50) = NULL,
	@Month int = NULL,
	@EndingPrice decimal(18,0) = NULL,
	@PhysicalInventoryPrice decimal(18,0) = NULL,
	@BBPrice decimal(18,0) = NULL,
	@BatchNo varchar(50) = NULL,
	@AutomaticallyEntered bit = NULL,
	@UnitID int =NULL,
	@QtyPerPack int =NULL
	)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [YearEnd]
	SET
		[ItemID] = @ItemID,
		[StoreID] = @StoreID,
		[Year] = @Year,
		[BBalance] = @BBalance,
		[EBalance] = @EBalance,
		[PhysicalInventory] = @PhysicalInventory,
		[Remark] = @Remark,
		[Month] = @Month,
		[EndingPrice] = @EndingPrice,
		[PhysicalInventoryPrice] = @PhysicalInventoryPrice,
		[BBPrice] = @BBPrice,
		[BatchNo] = @BatchNo,
		[AutomaticallyEntered] = @AutomaticallyEntered,
		[UnitID]= @UnitID,
		[QtyPerPack] =@QtyPerPack
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END


