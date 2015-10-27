CREATE PROCEDURE [dbo].[proc_StockoutLogDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [StockoutLog]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END