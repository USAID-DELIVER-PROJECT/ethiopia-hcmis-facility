CREATE PROCEDURE [dbo].[proc_ItemUnitLoadByPrimaryKey]
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
		[QtyPerUnit],
		[Text]
		
	FROM [ItemUnit]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END