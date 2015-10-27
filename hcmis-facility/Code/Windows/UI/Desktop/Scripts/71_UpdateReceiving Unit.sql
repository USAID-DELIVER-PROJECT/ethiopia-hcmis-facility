ALTER PROCEDURE [dbo].[proc_ReceivingUnitsUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@Phone varchar(50) = NULL,
	@Woreda varchar(50) = NULL,
	@Route int = NULL,
	@Min float = NULL,
	@Max float = NULL,
	@IsActive bit = NULL,
	@Region varchar(50) = NULL,
	@Zone varchar(50) = NULL,
	@FacilityType varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ReceivingUnits]
	SET
		[Name] = @Name,
		[Description] = @Description,
		[Phone] = @Phone,
		[Woreda] = @Woreda,
		[Route] = @Route,
		[Min] = @Min,
		[Max] = @Max,
		[IsActive] = @IsActive,
		[Region] = @Region,
		[Zone] = @Zone,
		[FacilityType] = @FacilityType
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END