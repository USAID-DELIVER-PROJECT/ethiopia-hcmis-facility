ALTER PROCEDURE [dbo].[proc_ReceivingUnitsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
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
	FROM [ReceivingUnits]

	SET @Err = @@Error

	RETURN @Err
END