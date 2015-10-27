ALTER PROCEDURE [dbo].[proc_ItemsUpdate]
(
	@ID int,
	@StockCode varchar(50) = NULL,
	@Strength varchar(1500) = NULL,
	@DosageFormID int = NULL,
	@UnitID int = NULL,
	@VEN int = NULL,
	@ABC int = NULL,
	@IsFree bit = NULL,
	@IsDiscontinued bit = NULL,
	@Cost decimal(18,0) = NULL,
	@EDL bit = NULL,
	@Refrigeratored bit = NULL,
	@Pediatric bit = NULL,
	@IINID int = NULL,
	@IsInHospitalList bit = NULL,
	@NeedExpiryBatch bit = NULL,
	@Code varchar(50) = NULL,
	@StockCodeDACA varchar(50) = NULL,
	@NearExpiryTrigger float = NULL,
	@StorageTypeID int = NULL,
	@DSItemID int =null
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Items]
	SET
		[StockCode] = @StockCode,
		[Strength] = @Strength,
		[DosageFormID] = @DosageFormID,
		[UnitID] = @UnitID,
		[VEN] = @VEN,
		[ABC] = @ABC,
		[IsFree] = @IsFree,
		[IsDiscontinued] = @IsDiscontinued,
		[Cost] = @Cost,
		[EDL] = @EDL,
		[Refrigeratored] = @Refrigeratored,
		[Pediatric] = @Pediatric,
		[IINID] = @IINID,
		[IsInHospitalList] = @IsInHospitalList,
		[NeedExpiryBatch] = @NeedExpiryBatch,
		[Code] = @Code,
		[StockCodeDACA] = @StockCodeDACA,
		[NearExpiryTrigger] = @NearExpiryTrigger,
		[StorageTypeID] = @StorageTypeID,
		[DSItemID] =@DSItemID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END