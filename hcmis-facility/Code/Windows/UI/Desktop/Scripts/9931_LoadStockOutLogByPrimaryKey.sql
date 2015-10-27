CREATE PROCEDURE [dbo].[proc_StockoutLogLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StoreID],
		[ItemID],
		[StartDate],
		[EndDate]
	FROM [StockoutLog]

	SET @Err = @@Error

	RETURN @Err
END