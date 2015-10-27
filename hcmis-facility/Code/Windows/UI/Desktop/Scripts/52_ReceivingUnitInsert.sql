ALTER PROCEDURE [dbo].[proc_ReceivingUnitsInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@Phone varchar(50) = NULL,
	@Woreda varchar(50) = NULL,
	@Route int = NULL,
	@Min float = NULL,
	@Max float = NULL,
	@IsActive bit = NULL,
	@Region varchar(50)=NULL,
	@Zone varchar(50)=NULL,
	@FacilityType varchar(50)=NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceivingUnits]
	(
		[Name],
		[Description],
		[Phone],
		[Woreda],
		[Route],
		[Min],
		[Max],
		[IsActive],
		[Region],
		[Zone],
		[FacilityType]
	)
	VALUES
	(
		@Name,
		@Description,
		@Phone,
		@Woreda,
		@Route,
		@Min,
		@Max,
		@IsActive,
		@Region,
		@Zone,
		@FacilityType 
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
