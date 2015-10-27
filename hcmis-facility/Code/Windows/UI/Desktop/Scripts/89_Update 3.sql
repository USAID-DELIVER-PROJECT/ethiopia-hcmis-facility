
/****** Object:  StoredProcedure [dbo].[proc_TypeInsert]    Script Date: 10/2/2012 7:11:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[proc_TypeInsert]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Type]
	(
		[ID],
		[Name],
		[Description]
	)
	VALUES
	(
		@ID,
		@Name,
		@Description
	)

	SET @Err = @@Error


	RETURN @Err
END

GO


/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryInsert]    Script Date: 10/2/2012 7:53:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[proc_SupplyCategoryInsert]
(
	@ID int,
	@Name varchar(50) = NULL,
	@ParentId int = NULL,
	@Code varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [SupplyCategory]
	(
		[ID],
		[Name],
		[ParentId],
		[Code]
	)
	VALUES
	(
		@ID,
		@Name,
		@ParentId,
		@Code
	)

	SET @Err = @@Error


	RETURN @Err
END

GO