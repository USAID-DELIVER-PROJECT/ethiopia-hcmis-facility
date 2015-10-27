CREATE PROCEDURE [dbo].[proc_ItemUnitInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@QtyPerUnit int = NULL,
	@Text varchar(50)=NULL
	)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemUnit]
	(
		[ItemID],
		[QtyPerUnit],
		[Text]
	)
	VALUES
	(
		@ItemID,
		@QtyPerUnit,
		@Text
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END