CREATE PROCEDURE [dbo].[proc_ItemUnitLoadAll]
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

	SET @Err = @@Error

	RETURN @Err
END