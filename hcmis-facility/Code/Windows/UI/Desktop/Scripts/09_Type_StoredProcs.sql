/****** Object:  StoredProcedure [proc_TypeLoadByPrimaryKey]    Script Date: 12/19/2011 2:13:29 AM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_TypeLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_TypeLoadByPrimaryKey];
GO

CREATE PROCEDURE [proc_TypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[Description]
	FROM [Type]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_TypeLoadByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: proc_TypeLoadByPrimaryKey Error on Creation'
GO

/****** Object:  StoredProcedure [proc_TypeLoadAll]    Script Date: 12/19/2011 2:13:29 AM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_TypeLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_TypeLoadAll];
GO

CREATE PROCEDURE [proc_TypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[Description]
	FROM [Type]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_TypeLoadAll Succeeded'
ELSE PRINT 'Procedure Creation: proc_TypeLoadAll Error on Creation'
GO

/****** Object:  StoredProcedure [proc_TypeUpdate]    Script Date: 12/19/2011 2:13:29 AM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_TypeUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_TypeUpdate];
GO

CREATE PROCEDURE [proc_TypeUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Type]
	SET
		[Name] = @Name,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_TypeUpdate Succeeded'
ELSE PRINT 'Procedure Creation: proc_TypeUpdate Error on Creation'
GO




/****** Object:  StoredProcedure [proc_TypeInsert]    Script Date: 12/19/2011 2:13:29 AM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_TypeInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_TypeInsert];
GO

CREATE PROCEDURE [proc_TypeInsert]
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


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_TypeInsert Succeeded'
ELSE PRINT 'Procedure Creation: proc_TypeInsert Error on Creation'
GO

/****** Object:  StoredProcedure [proc_TypeDelete]    Script Date: 12/19/2011 2:13:29 AM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_TypeDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_TypeDelete];
GO

CREATE PROCEDURE [proc_TypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Type]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_TypeDelete Succeeded'
ELSE PRINT 'Procedure Creation: proc_TypeDelete Error on Creation'
GO


