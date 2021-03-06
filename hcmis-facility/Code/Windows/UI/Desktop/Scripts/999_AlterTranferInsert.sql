ALTER PROCEDURE [dbo].[proc_TransferInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@BatchNo varchar(50) = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@FromStoreID int =NULL,
	@ToStoreID int =NULL,
	@RefNo varchar(50) = NULL,
	@EurDate datetime = NULL,
	@UnitID int =Null,
	@ApprovedBy nvarchar(100) = NULL,
	@TransferRequestedBy nvarchar(100) = NULL,
	@TransferReason text = NULL,
    @RecID int= NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Transfer]
	(
	    [ItemID],
		[BatchNo],
		[Quantity],
		[Date],
		[FromStoreID],
		[ToStoreID],
		[RefNo],
		[EurDate],
		[UnitID],
		[ApprovedBy],
		[TransferRequestedBy],
		[TransferReason],
        [RecID]
	)
	VALUES
	(
	    @ItemID,
		@BatchNo,
		@Quantity,
		@Date,
		@FromStoreID,
		@ToStoreID,
		@RefNo,
		@EurDate,
		@UnitID,
		@ApprovedBy,
		@TransferRequestedBy,
		@TransferReason,
        @RecID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END

SET ANSI_NULLS ON