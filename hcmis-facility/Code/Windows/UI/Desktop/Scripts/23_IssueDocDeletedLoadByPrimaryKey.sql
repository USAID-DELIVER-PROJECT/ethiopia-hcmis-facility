Create PROCEDURE [dbo].[proc_IssueDocDeletedLoadByPrimaryKey]
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
		[ReceivingUnitID],
		[LocalBatchNo],
		[Quantity],
		[Date],
		[IsTransfer],
		[IssuedBy],
		[Remark],
		[RefNo],
		[BatchNo],
		[IsApproved],
		[Cost],
		[NoOfPack],
		[QtyPerPack],
		[DUSOH],
		[DURequestedQty],
		[RecomendedQty],
		[RecievDocID],
		[EurDate],
		[OrderID]
	FROM [IssueDocDeleted]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
