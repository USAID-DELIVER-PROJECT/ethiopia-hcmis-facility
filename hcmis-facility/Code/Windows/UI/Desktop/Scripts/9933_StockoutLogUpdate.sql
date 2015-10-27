CREATE PROCEDURE [dbo].[proc_StockoutLogUpdate]
(
	@ID int,
	@StoreID int = NULL,
	@ItemID int,
	@StartDate datetime,
	@EndDate datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [StockoutLog]
	SET
		[StoreID] = @StoreID,
		[ItemID] = @ItemID,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END