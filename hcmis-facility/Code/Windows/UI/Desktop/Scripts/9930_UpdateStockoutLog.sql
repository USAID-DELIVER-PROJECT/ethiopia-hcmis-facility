CREATE PROCEDURE [dbo].[proc_StockoutLogLoadByPrimaryKey]
(
	@ID int
)
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
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END