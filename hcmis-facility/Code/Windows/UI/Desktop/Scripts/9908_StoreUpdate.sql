ALTER PROCEDURE [dbo].[proc_StoresUpdate]
(
	@ID int,
	@HospitalID int = NULL,
	@StoreName varchar(50) = NULL,
	@IsActive bit = NULL,
    @SupplierID int =Null,
	@ReceivingUnitID int = Null
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Stores]
	SET
		[HospitalID] = @HospitalID,
		[StoreName] = @StoreName,
		[IsActive] = @IsActive,
		[SupplierID] =@SupplierID,
		[ReceivingUnitID] =@ReceivingUnitID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
