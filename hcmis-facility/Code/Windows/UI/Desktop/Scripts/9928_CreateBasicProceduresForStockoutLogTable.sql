CREATE PROCEDURE [dbo].[proc_StockoutLogInsert]
(
	@ID int = NULL output,
	@StoreID int = NULL,
	@ItemID int,
	@StartDate datetime,
	@EndDate datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [StockoutLog]
	(
		[StoreID],
		[ItemID],
		[StartDate],
		[EndDate]
	)
	VALUES
	(
		@StoreID,
		@ItemID,
		@StartDate,
		@EndDate
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END