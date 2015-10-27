/****** Object:  StoredProcedure [proc_SupplyCategoryLoadByPrimaryKey]    Script Date: 11/28/2011 11:02:44 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_SupplyCategoryLoadByPrimaryKey]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_SupplyCategoryLoadByPrimaryKey];
GO

CREATE PROCEDURE [proc_SupplyCategoryLoadByPrimaryKey]
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
		[ParentId],
		[Code]
	FROM [SupplyCategory]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_SupplyCategoryLoadByPrimaryKey Succeeded'
ELSE PRINT 'Procedure Creation: proc_SupplyCategoryLoadByPrimaryKey Error on Creation'
GO

/****** Object:  StoredProcedure [proc_SupplyCategoryLoadAll]    Script Date: 11/28/2011 11:02:44 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_SupplyCategoryLoadAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_SupplyCategoryLoadAll];
GO

CREATE PROCEDURE [proc_SupplyCategoryLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[ParentId],
		[Code]
	FROM [SupplyCategory]

	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_SupplyCategoryLoadAll Succeeded'
ELSE PRINT 'Procedure Creation: proc_SupplyCategoryLoadAll Error on Creation'
GO

/****** Object:  StoredProcedure [proc_SupplyCategoryUpdate]    Script Date: 11/28/2011 11:02:44 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_SupplyCategoryUpdate]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_SupplyCategoryUpdate];
GO

CREATE PROCEDURE [proc_SupplyCategoryUpdate]
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

	UPDATE [SupplyCategory]
	SET
		[Name] = @Name,
		[ParentId] = @ParentId,
		[Code] = @Code
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_SupplyCategoryUpdate Succeeded'
ELSE PRINT 'Procedure Creation: proc_SupplyCategoryUpdate Error on Creation'
GO




/****** Object:  StoredProcedure [proc_SupplyCategoryInsert]    Script Date: 11/28/2011 11:02:44 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_SupplyCategoryInsert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_SupplyCategoryInsert];
GO

CREATE PROCEDURE [proc_SupplyCategoryInsert]
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


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_SupplyCategoryInsert Succeeded'
ELSE PRINT 'Procedure Creation: proc_SupplyCategoryInsert Error on Creation'
GO

/****** Object:  StoredProcedure [proc_SupplyCategoryDelete]    Script Date: 11/28/2011 11:02:44 PM ******/
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[proc_SupplyCategoryDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
    DROP PROCEDURE [proc_SupplyCategoryDelete];
GO

CREATE PROCEDURE [proc_SupplyCategoryDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [SupplyCategory]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO


-- Display the status of Proc creation
IF (@@Error = 0) PRINT 'Procedure Creation: proc_SupplyCategoryDelete Succeeded'
ELSE PRINT 'Procedure Creation: proc_SupplyCategoryDelete Error on Creation'
GO


