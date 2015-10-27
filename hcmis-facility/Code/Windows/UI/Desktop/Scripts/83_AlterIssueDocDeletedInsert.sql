ALTER PROCEDURE [dbo].[proc_IssueDocDeletedInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@ReceivingUnitID int = NULL,
	@LocalBatchNo varchar(50) = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@IsTransfer bit = NULL,
	@IssuedBy varchar(50) = NULL,
	@Remark text = NULL,
	@RefNo varchar(50) = NULL,
	@BatchNo varchar(50) = NULL,
	@IsApproved bit = NULL,
	@Cost float = NULL,
	@NoOfPack int = NULL,
	@QtyPerPack int = NULL,
	@DUSOH bigint = NULL,
	@DURequestedQty bigint = NULL,
	@RecomendedQty bigint = NULL,
	@RecievDocID int = NULL,
	@EurDate datetime = NULL,
	@OrderID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [IssueDocDeleted]
	(
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
	)
	VALUES
	(
	    @ID,
		@ItemID,
		@StoreId,
		@ReceivingUnitID,
		@LocalBatchNo,
		@Quantity,
		@Date,
		@IsTransfer,
		@IssuedBy,
		@Remark,
		@RefNo,
		@BatchNo,
		@IsApproved,
		@Cost,
		@NoOfPack,
		@QtyPerPack,
		@DUSOH,
		@DURequestedQty,
		@RecomendedQty,
		@RecievDocID,
		@EurDate,
		@OrderID
	)
	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END



