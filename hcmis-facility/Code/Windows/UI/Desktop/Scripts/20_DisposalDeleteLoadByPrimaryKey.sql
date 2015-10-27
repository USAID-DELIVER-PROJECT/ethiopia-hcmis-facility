Create PROCEDURE [dbo].[proc_DisposalDeleteLoadByPrimaryKey]
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
		[StoreId],
		[ReasonId],
		[Quantity],
		[Date],
		[ApprovedBy],
		[Losses],
		[BatchNo],
		[Remark],
		[Cost],
		[RefNo],
		[EurDate],
		[RecID]
	FROM [DisposalDelete]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
