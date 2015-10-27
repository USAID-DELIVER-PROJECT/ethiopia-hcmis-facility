
/****** Object:  StoredProcedure [dbo].[proc_ATCUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ATCUpdate]
(
	@ID int,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ATC]
	SET
		[Name] = @Name
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ATCLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ATCLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [ATC]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ATCLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ATCLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [ATC]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ATCInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ATCInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ATC]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ATCDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ATCDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ATC]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedRackUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedRackUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@RackID int = NULL,
	@IsFixed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemPrefferedRack]
	SET
		[ItemID] = @ItemID,
		[RackID] = @RackID,
		[IsFixed] = @IsFixed
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedRackLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedRackLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[RackID],
		[IsFixed]
	FROM [ItemPrefferedRack]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedRackLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedRackLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[RackID],
		[IsFixed]
	FROM [ItemPrefferedRack]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedRackInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedRackInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@RackID int = NULL,
	@IsFixed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemPrefferedRack]
	(
		[ItemID],
		[RackID],
		[IsFixed]
	)
	VALUES
	(
		@ItemID,
		@RackID,
		@IsFixed
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedRackDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedRackDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemPrefferedRack]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemStorageTypeUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemStorageTypeUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemStorageType]
	SET
		[ItemID] = @ItemID,
		[StorageTypeID] = @StorageTypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemStorageTypeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemStorageTypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StorageTypeID]
	FROM [ItemStorageType]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemStorageTypeLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemStorageTypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StorageTypeID]
	FROM [ItemStorageType]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemStorageTypeInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemStorageTypeInsert]
(
	@ID int,
	@ItemID int = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemStorageType]
	(
		[ID],
		[ItemID],
		[StorageTypeID]
	)
	VALUES
	(
		@ID,
		@ItemID,
		@StorageTypeID
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemStorageTypeDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemStorageTypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemStorageType]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemShelfUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemShelfUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@ShelfID int = NULL,
	@IsEmpty bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemShelf]
	SET
		[ItemID] = @ItemID,
		[ShelfID] = @ShelfID,
		[IsEmpty] = @IsEmpty
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemShelfLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemShelfLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ShelfID],
		[IsEmpty]
	FROM [ItemShelf]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemShelfLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemShelfLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ShelfID],
		[IsEmpty]
	FROM [ItemShelf]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemShelfInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemShelfInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@ShelfID int = NULL,
	@IsEmpty bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemShelf]
	(
		[ItemID],
		[ShelfID],
		[IsEmpty]
	)
	VALUES
	(
		@ItemID,
		@ShelfID,
		@IsEmpty
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemShelfDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemShelfDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemShelf]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_INNUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_INNUpdate]
(
	@ID int,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [INN]
	SET
		[IIN] = @IIN,
		[ATC] = @ATC,
		[Description] = @Description,
		[TypeID] = @TypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_INNLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_INNLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [INN]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_INNLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_INNLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [INN]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_INNInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_INNInsert]
(
	@ID int = NULL output,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [INN]
	(
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	)
	VALUES
	(
		@IIN,
		@ATC,
		@Description,
		@TypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_INNDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_INNDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [INN]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_EMLUpdate]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_EMLUpdate]
(
	@ID int,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [EML]
	SET
		[Name] = @Name
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_EMLLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_EMLLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [EML]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_EMLLoadAll]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_EMLLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [EML]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_EMLInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_EMLInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [EML]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_EMLDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_EMLDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [EML]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PresentationFormUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PresentationFormUpdate]
(
	@ID int,
	@Form varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PresentationForm]
	SET
		[Form] = @Form,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PresentationFormLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PresentationFormLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Form],
		[Description]
	FROM [PresentationForm]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PresentationFormLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PresentationFormLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Form],
		[Description]
	FROM [PresentationForm]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PresentationFormInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PresentationFormInsert]
(
	@ID int = NULL output,
	@Form varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PresentationForm]
	(
		[Form],
		[Description]
	)
	VALUES
	(
		@Form,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PresentationFormDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PresentationFormDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PresentationForm]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalleteUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalleteUpdate]
(
	@ID int,
	@PalletNo varchar(50) = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Pallete]
	SET
		[PalletNo] = @PalletNo,
		[StorageTypeID] = @StorageTypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalleteLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalleteLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletNo],
		[StorageTypeID]
	FROM [Pallete]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalleteLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalleteLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletNo],
		[StorageTypeID]
	FROM [Pallete]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalleteInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalleteInsert]
(
	@ID int,
	@PalletNo varchar(50) = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Pallete]
	(
		[ID],
		[PalletNo],
		[StorageTypeID]
	)
	VALUES
	(
		@ID,
		@PalletNo,
		@StorageTypeID
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalleteDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalleteDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Pallete]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturerLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturerLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [Manufacturer]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturerLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturerLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name]
	FROM [Manufacturer]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturerInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturerInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Manufacturer]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturerDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturerDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Manufacturer]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LossesUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_LossesUpdate]
(
	@ID int,
	@ProductID int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@StoreId int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Losses]
	SET
		[ProductID] = @ProductID,
		[Quantity] = @Quantity,
		[Date] = @Date,
		[StoreId] = @StoreId
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LossesLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_LossesLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ProductID],
		[Quantity],
		[Date],
		[StoreId]
	FROM [Losses]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LossesLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_LossesLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ProductID],
		[Quantity],
		[Date],
		[StoreId]
	FROM [Losses]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LossesInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_LossesInsert]
(
	@ID int = NULL output,
	@ProductID int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@StoreId int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Losses]
	(
		[ProductID],
		[Quantity],
		[Date],
		[StoreId]
	)
	VALUES
	(
		@ProductID,
		@Quantity,
		@Date,
		@StoreId
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_LossesDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_LossesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Losses]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturesUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturesUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@CountryOfOrigin varchar(50) = NULL,
	@PFSAManufCode varchar(50) = NULL,
	@Phone varchar(50) = NULL,
	@Address varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Manufactures]
	SET
		[Name] = @Name,
		[CountryOfOrigin] = @CountryOfOrigin,
		[PFSAManufCode] = @PFSAManufCode,
		[Phone] = @Phone,
		[Address] = @Address
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturesLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturesLoadByPrimaryKey]
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
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	FROM [Manufactures]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturesLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturesLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	FROM [Manufactures]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturesInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturesInsert]
(
	@ID int,
	@Name varchar(50) = NULL,
	@CountryOfOrigin varchar(50) = NULL,
	@PFSAManufCode varchar(50) = NULL,
	@Phone varchar(50) = NULL,
	@Address varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Manufactures]
	(
		[ID],
		[Name],
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	)
	VALUES
	(
		@ID,
		@Name,
		@CountryOfOrigin,
		@PFSAManufCode,
		@Phone,
		@Address
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturesDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturesDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Manufactures]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturerUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturerUpdate]
(
	@ID int,
	@Name varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Manufacturer]
	SET
		[Name] = @Name
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalleteUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalleteUpdate]
(
	@ID int,
	@ReceiveID int = NULL,
	@PalletID int = NULL,
	@ReceivedQuantity bigint = NULL,
	@Balance bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ReceivePallete]
	SET
		[ReceiveID] = @ReceiveID,
		[PalletID] = @PalletID,
		[ReceivedQuantity] = @ReceivedQuantity,
		[Balance] = @Balance
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalleteLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalleteLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	FROM [ReceivePallete]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalleteLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalleteLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	FROM [ReceivePallete]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalleteInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalleteInsert]
(
	@ID int = NULL output,
	@ReceiveID int = NULL,
	@PalletID int = NULL,
	@ReceivedQuantity bigint = NULL,
	@Balance bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceivePallete]
	(
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	)
	VALUES
	(
		@ReceiveID,
		@PalletID,
		@ReceivedQuantity,
		@Balance
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalleteDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalleteDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ReceivePallete]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramLoadByPrimaryKey]
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
	FROM [Program]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[Description]
	FROM [Program]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Program]
	(
		[Name],
		[Description]
	)
	VALUES
	(
		@Name,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Program]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsUpdate]
(
	@ID int,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Products]
	SET
		[IIN] = @IIN,
		[ATC] = @ATC,
		[Description] = @Description,
		[TypeID] = @TypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [Products]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [Products]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsInsert]
(
	@ID int = NULL output,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Products]
	(
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	)
	VALUES
	(
		@IIN,
		@ATC,
		@Description,
		@TypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductShelfUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductShelfUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@ShelfID int = NULL,
	@IsEmpty bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ProductShelf]
	SET
		[ItemID] = @ItemID,
		[ShelfID] = @ShelfID,
		[IsEmpty] = @IsEmpty
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductShelfLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductShelfLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ShelfID],
		[IsEmpty]
	FROM [ProductShelf]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductShelfLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductShelfLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ShelfID],
		[IsEmpty]
	FROM [ProductShelf]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductShelfInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductShelfInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@ShelfID int = NULL,
	@IsEmpty bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ProductShelf]
	(
		[ItemID],
		[ShelfID],
		[IsEmpty]
	)
	VALUES
	(
		@ItemID,
		@ShelfID,
		@IsEmpty
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductShelfDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductShelfDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ProductShelf]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Products]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Program]
	SET
		[Name] = @Name,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingStatusUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingStatusUpdate]
(
	@ID int,
	@Status varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ReceivingStatus]
	SET
		[Status] = @Status
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingStatusLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingStatusLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Status]
	FROM [ReceivingStatus]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingStatusLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingStatusLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Status]
	FROM [ReceivingStatus]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingStatusInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingStatusInsert]
(
	@ID int = NULL output,
	@Status varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceivingStatus]
	(
		[Status]
	)
	VALUES
	(
		@Status
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingStatusDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingStatusDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ReceivingStatus]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFUpdate]
(
	@ID int,
	@FromMonth int,
	@FromYear int,
	@ToMonth int,
	@ToYear int,
	@DateOfSubmission datetime = NULL,
	@LastRRFStatus varchar(100) = NULL,
	@RRFType int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [RRF]
	SET
		[FromMonth] = @FromMonth,
		[FromYear] = @FromYear,
		[ToMonth] = @ToMonth,
		[ToYear] = @ToYear,
		[DateOfSubmission] = @DateOfSubmission,
		[LastRRFStatus] = @LastRRFStatus,
		[RRFType] = @RRFType
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[FromMonth],
		[FromYear],
		[ToMonth],
		[ToYear],
		[DateOfSubmission],
		[LastRRFStatus],
		[RRFType]
	FROM [RRF]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[FromMonth],
		[FromYear],
		[ToMonth],
		[ToYear],
		[DateOfSubmission],
		[LastRRFStatus],
		[RRFType]
	FROM [RRF]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFInsert]
(
	@ID int = NULL output,
	@FromMonth int,
	@FromYear int,
	@ToMonth int,
	@ToYear int,
	@DateOfSubmission datetime = NULL,
	@LastRRFStatus varchar(100) = NULL,
	@RRFType int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [RRF]
	(
		[FromMonth],
		[FromYear],
		[ToMonth],
		[ToYear],
		[DateOfSubmission],
		[LastRRFStatus],
		[RRFType]
	)
	VALUES
	(
		@FromMonth,
		@FromYear,
		@ToMonth,
		@ToYear,
		@DateOfSubmission,
		@LastRRFStatus,
		@RRFType
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [RRF]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RouteUpdate]
(
	@RouteID int,
	@Name nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Route]
	SET
		[Name] = @Name
	WHERE
		[RouteID] = @RouteID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RouteLoadByPrimaryKey]
(
	@RouteID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[RouteID],
		[Name]
	FROM [Route]
	WHERE
		([RouteID] = @RouteID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RouteLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[RouteID],
		[Name]
	FROM [Route]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RouteInsert]
(
	@RouteID int = NULL output,
	@Name nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Route]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)

	SET @Err = @@Error

	SELECT @RouteID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RouteDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RouteDelete]
(
	@RouteID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Route]
	WHERE
		[RouteID] = @RouteID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RegionUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RegionUpdate]
(
	@ID int,
	@RegionName varchar(50) = NULL,
	@RegionCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Region]
	SET
		[RegionName] = @RegionName,
		[RegionCode] = @RegionCode
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RegionLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RegionLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[RegionName],
		[RegionCode]
	FROM [Region]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RegionLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RegionLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[RegionName],
		[RegionCode]
	FROM [Region]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RegionInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RegionInsert]
(
	@ID int = NULL output,
	@RegionName varchar(50) = NULL,
	@RegionCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Region]
	(
		[RegionName],
		[RegionCode]
	)
	VALUES
	(
		@RegionName,
		@RegionCode
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RegionDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RegionDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Region]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramsUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramsUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@ParentID int = NULL,
	@ProgramCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Programs]
	SET
		[Name] = @Name,
		[Description] = @Description,
		[ParentID] = @ParentID,
		[ProgramCode] = @ProgramCode
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramsLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramsLoadByPrimaryKey]
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
		[Description],
		[ParentID],
		[ProgramCode]
	FROM [Programs]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramsLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[Description],
		[ParentID],
		[ProgramCode]
	FROM [Programs]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramsInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramsInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@ParentID int = NULL,
	@ProgramCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Programs]
	(
		[Name],
		[Description],
		[ParentID],
		[ProgramCode]
	)
	VALUES
	(
		@Name,
		@Description,
		@ParentID,
		@ProgramCode
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramsDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Programs]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RackStatusUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RackStatusUpdate]
(
	@ID int,
	@Status varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [RackStatus]
	SET
		[Status] = @Status,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RackStatusLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RackStatusLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Status],
		[Description]
	FROM [RackStatus]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RackStatusLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RackStatusLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Status],
		[Description]
	FROM [RackStatus]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RackStatusInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RackStatusInsert]
(
	@ID int,
	@Status varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [RackStatus]
	(
		[ID],
		[Status],
		[Description]
	)
	VALUES
	(
		@ID,
		@Status,
		@Description
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RackStatusDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RackStatusDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [RackStatus]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturersUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturersUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@CountryOfOrigin varchar(50) = NULL,
	@PFSAManufCode varchar(50) = NULL,
	@Phone varchar(50) = NULL,
	@Address varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Manufacturers]
	SET
		[Name] = @Name,
		[CountryOfOrigin] = @CountryOfOrigin,
		[PFSAManufCode] = @PFSAManufCode,
		[Phone] = @Phone,
		[Address] = @Address
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturersLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturersLoadByPrimaryKey]
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
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	FROM [Manufacturers]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturersLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturersLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	FROM [Manufacturers]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturersInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturersInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@CountryOfOrigin varchar(50) = NULL,
	@PFSAManufCode varchar(50) = NULL,
	@Phone varchar(50) = NULL,
	@Address varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Manufacturers]
	(
		[Name],
		[CountryOfOrigin],
		[PFSAManufCode],
		[Phone],
		[Address]
	)
	VALUES
	(
		@Name,
		@CountryOfOrigin,
		@PFSAManufCode,
		@Phone,
		@Address
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ManufacturersDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ManufacturersDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Manufacturers]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderStatusUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderStatusUpdate]
(
	@ID int,
	@OrderStatus varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [OrderStatus]
	SET
		[OrderStatus] = @OrderStatus,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderStatusLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderStatusLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderStatus],
		[Description]
	FROM [OrderStatus]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderStatusLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderStatusLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderStatus],
		[Description]
	FROM [OrderStatus]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderStatusInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderStatusInsert]
(
	@ID int,
	@OrderStatus varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [OrderStatus]
	(
		[ID],
		[OrderStatus],
		[Description]
	)
	VALUES
	(
		@ID,
		@OrderStatus,
		@Description
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderStatusDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderStatusDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [OrderStatus]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Pallet]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletNo],
		[StorageTypeID]
	FROM [Pallet]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletNo],
		[StorageTypeID]
	FROM [Pallet]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletInsert]
(
	@ID int = NULL output,
	@PalletNo int = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Pallet]
	(
		[PalletNo],
		[StorageTypeID]
	)
	VALUES
	(
		@PalletNo,
		@StorageTypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PhysicalStoreUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PhysicalStoreUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@Length float = NULL,
	@DoorSide int = NULL,
	@DoorSize float = NULL,
	@DistanceFromCornor float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PhysicalStore]
	SET
		[Name] = @Name,
		[Width] = @Width,
		[Height] = @Height,
		[Length] = @Length,
		[DoorSide] = @DoorSide,
		[DoorSize] = @DoorSize,
		[DistanceFromCornor] = @DistanceFromCornor
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PhysicalStoreLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PhysicalStoreLoadByPrimaryKey]
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
		[Width],
		[Height],
		[Length],
		[DoorSide],
		[DoorSize],
		[DistanceFromCornor]
	FROM [PhysicalStore]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PhysicalStoreLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PhysicalStoreLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Name],
		[Width],
		[Height],
		[Length],
		[DoorSide],
		[DoorSize],
		[DistanceFromCornor]
	FROM [PhysicalStore]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PhysicalStoreInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PhysicalStoreInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@Length float = NULL,
	@DoorSide int = NULL,
	@DoorSize float = NULL,
	@DistanceFromCornor float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PhysicalStore]
	(
		[Name],
		[Width],
		[Height],
		[Length],
		[DoorSide],
		[DoorSize],
		[DistanceFromCornor]
	)
	VALUES
	(
		@Name,
		@Width,
		@Height,
		@Length,
		@DoorSide,
		@DoorSize,
		@DistanceFromCornor
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PhysicalStoreDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PhysicalStoreDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PhysicalStore]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletUpdate]
(
	@ID int,
	@PalletNo int = NULL,
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Pallet]
	SET
		[PalletNo] = @PalletNo,
		[StorageTypeID] = @StorageTypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StorageTypeUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StorageTypeUpdate]
(
	@ID int,
	@StorageTypeName varchar(50) = NULL,
	@IsSubTypeOf int = NULL,
	@Prefix varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [StorageType]
	SET
		[StorageTypeName] = @StorageTypeName,
		[IsSubTypeOf] = @IsSubTypeOf,
		[Prefix] = @Prefix
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StorageTypeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StorageTypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StorageTypeName],
		[IsSubTypeOf],
		[Prefix]
	FROM [StorageType]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StorageTypeLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StorageTypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StorageTypeName],
		[IsSubTypeOf],
		[Prefix]
	FROM [StorageType]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StorageTypeInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StorageTypeInsert]
(
	@ID int = NULL output,
	@StorageTypeName varchar(50) = NULL,
	@IsSubTypeOf int = NULL,
	@Prefix varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [StorageType]
	(
		[StorageTypeName],
		[IsSubTypeOf],
		[Prefix]
	)
	VALUES
	(
		@StorageTypeName,
		@IsSubTypeOf,
		@Prefix
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StorageTypeDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StorageTypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [StorageType]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserTypeUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserTypeUpdate]
(
	@ID int,
	@Type varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [UserType]
	SET
		[Type] = @Type
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserTypeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserTypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Type]
	FROM [UserType]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserTypeLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserTypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Type]
	FROM [UserType]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserTypeInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserTypeInsert]
(
	@ID int = NULL output,
	@Type varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [UserType]
	(
		[Type]
	)
	VALUES
	(
		@Type
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserTypeDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserTypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [UserType]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UnitUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UnitUpdate]
(
	@ID int,
	@Unit varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Unit]
	SET
		[Unit] = @Unit,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UnitLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UnitLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Unit],
		[Description]
	FROM [Unit]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UnitLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UnitLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Unit],
		[Description]
	FROM [Unit]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UnitInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UnitInsert]
(
	@ID int = NULL output,
	@Unit varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Unit]
	(
		[Unit],
		[Description]
	)
	VALUES
	(
		@Unit,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UnitDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UnitDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Unit]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TypeUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_TypeUpdate]
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
/****** Object:  StoredProcedure [dbo].[proc_TypeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_TypeLoadByPrimaryKey]
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
/****** Object:  StoredProcedure [dbo].[proc_TypeLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_TypeLoadAll]
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
/****** Object:  StoredProcedure [dbo].[proc_TypeInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_TypeInsert]
(
	@ID int = NULL output,
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
		[Name],
		[Description]
	)
	VALUES
	(
		@Name,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TypeDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_TypeDelete]
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
/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplyCategoryUpdate]
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
/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplyCategoryLoadByPrimaryKey]
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
/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplyCategoryLoadAll]
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
/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplyCategoryInsert]
(
	@ID int = NULL output,
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
		[Name],
		[ParentId],
		[Code]
	)
	VALUES
	(
		@Name,
		@ParentId,
		@Code
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SupplyCategoryDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplyCategoryDelete]
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
/****** Object:  StoredProcedure [dbo].[proc_SupplierUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplierUpdate]
(
	@ID int,
	@CompanyName varchar(50) = NULL,
	@Address varchar(50) = NULL,
	@Telephone varchar(50) = NULL,
	@ContactPerson varchar(50) = NULL,
	@Mobile varchar(50) = NULL,
	@CompanyInfo varchar(50) = NULL,
	@IsActive bit = NULL,
	@Email varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Supplier]
	SET
		[CompanyName] = @CompanyName,
		[Address] = @Address,
		[Telephone] = @Telephone,
		[ContactPerson] = @ContactPerson,
		[Mobile] = @Mobile,
		[CompanyInfo] = @CompanyInfo,
		[IsActive] = @IsActive,
		[Email] = @Email
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SupplierLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplierLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CompanyName],
		[Address],
		[Telephone],
		[ContactPerson],
		[Mobile],
		[CompanyInfo],
		[IsActive],
		[Email]
	FROM [Supplier]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SupplierLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplierLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CompanyName],
		[Address],
		[Telephone],
		[ContactPerson],
		[Mobile],
		[CompanyInfo],
		[IsActive],
		[Email]
	FROM [Supplier]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SupplierInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplierInsert]
(
	@ID int = NULL output,
	@CompanyName varchar(50) = NULL,
	@Address varchar(50) = NULL,
	@Telephone varchar(50) = NULL,
	@ContactPerson varchar(50) = NULL,
	@Mobile varchar(50) = NULL,
	@CompanyInfo varchar(50) = NULL,
	@IsActive bit = NULL,
	@Email varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Supplier]
	(
		[CompanyName],
		[Address],
		[Telephone],
		[ContactPerson],
		[Mobile],
		[CompanyInfo],
		[IsActive],
		[Email]
	)
	VALUES
	(
		@CompanyName,
		@Address,
		@Telephone,
		@ContactPerson,
		@Mobile,
		@CompanyInfo,
		@IsActive,
		@Email
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SupplierDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SupplierDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Supplier]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_VENUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_VENUpdate]
(
	@ID int,
	@Value varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [VEN]
	SET
		[Value] = @Value,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_VENLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_VENLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Value],
		[Description]
	FROM [VEN]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_VENLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_VENLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Value],
		[Description]
	FROM [VEN]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_VENInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_VENInsert]
(
	@ID int = NULL output,
	@Value varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [VEN]
	(
		[Value],
		[Description]
	)
	VALUES
	(
		@Value,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_VENDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_VENDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [VEN]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalReasonsUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalReasonsUpdate]
(
	@ID int,
	@Reason text = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [DisposalReasons]
	SET
		[Reason] = @Reason,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalReasonsLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalReasonsLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Reason],
		[Description]
	FROM [DisposalReasons]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalReasonsLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalReasonsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Reason],
		[Description]
	FROM [DisposalReasons]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalReasonsInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalReasonsInsert]
(
	@ID int = NULL output,
	@Reason text = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [DisposalReasons]
	(
		[Reason],
		[Description]
	)
	VALUES
	(
		@Reason,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalReasonsDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalReasonsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [DisposalReasons]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DUsItemListLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DUsItemListLoadByPrimaryKey]
(
	@ItemID int,
	@DUID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ItemID],
		[DUID]
	FROM [DUsItemList]
	WHERE
		([ItemID] = @ItemID) AND
		([DUID] = @DUID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DUsItemListLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DUsItemListLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ItemID],
		[DUID]
	FROM [DUsItemList]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DUsItemListInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DUsItemListInsert]
(
	@ItemID int,
	@DUID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [DUsItemList]
	(
		[ItemID],
		[DUID]
	)
	VALUES
	(
		@ItemID,
		@DUID
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DUsItemListDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DUsItemListDelete]
(
	@ItemID int,
	@DUID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [DUsItemList]
	WHERE
		[ItemID] = @ItemID AND
		[DUID] = @DUID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DosageFormUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DosageFormUpdate]
(
	@ID int,
	@Form varchar(50) = NULL,
	@Description text = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [DosageForm]
	SET
		[Form] = @Form,
		[Description] = @Description,
		[TypeID] = @TypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DosageFormLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DosageFormLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Form],
		[Description],
		[TypeID]
	FROM [DosageForm]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DosageFormLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DosageFormLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Form],
		[Description],
		[TypeID]
	FROM [DosageForm]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DosageFormInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DosageFormInsert]
(
	@ID int = NULL output,
	@Form varchar(50) = NULL,
	@Description text = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [DosageForm]
	(
		[Form],
		[Description],
		[TypeID]
	)
	VALUES
	(
		@Form,
		@Description,
		@TypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DosageFormDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DosageFormDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [DosageForm]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GeneralInfoUpdate]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_GeneralInfoUpdate]
(
	@ID int,
	@HospitalName varchar(50) = NULL,
	@Woreda int = NULL,
	@Zone int = NULL,
	@Region int = NULL,
	@Telephone varchar(50) = NULL,
	@HospitalContact varchar(50) = NULL,
	@LeadTime int = NULL,
	@Min int = NULL,
	@Max int = NULL,
	@SafteyStock int = NULL,
	@AMCRange int = NULL,
	@ReviewPeriod int = NULL,
	@EOP float = NULL,
	@Description text = NULL,
	@IsEven bit = NULL,
	@Logo varchar(50) = NULL,
	@DUMin float = NULL,
	@DUMax float = NULL,
	@DUAMCRange int = NULL,
	@LastBackUp datetime = NULL,
	@FacilityID int = NULL,
	@LastSync datetime = NULL,
	@DSUpdateFrequency varchar(50) = NULL,
	@RRFStatusUpdateFrequency varchar(50) = NULL,
	@RRFStatusFirstUpdateAfter varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [GeneralInfo]
	SET
		[HospitalName] = @HospitalName,
		[Woreda] = @Woreda,
		[Zone] = @Zone,
		[Region] = @Region,
		[Telephone] = @Telephone,
		[HospitalContact] = @HospitalContact,
		[LeadTime] = @LeadTime,
		[Min] = @Min,
		[Max] = @Max,
		[SafteyStock] = @SafteyStock,
		[AMCRange] = @AMCRange,
		[ReviewPeriod] = @ReviewPeriod,
		[EOP] = @EOP,
		[Description] = @Description,
		[IsEven] = @IsEven,
		[Logo] = @Logo,
		[DUMin] = @DUMin,
		[DUMax] = @DUMax,
		[DUAMCRange] = @DUAMCRange,
		[LastBackUp] = @LastBackUp,
		[FacilityID] = @FacilityID,
		[LastSync] = @LastSync,
		[DSUpdateFrequency] = @DSUpdateFrequency,
		[RRFStatusUpdateFrequency] = @RRFStatusUpdateFrequency,
		[RRFStatusFirstUpdateAfter] = @RRFStatusFirstUpdateAfter
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GeneralInfoLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_GeneralInfoLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[HospitalName],
		[Woreda],
		[Zone],
		[Region],
		[Telephone],
		[HospitalContact],
		[LeadTime],
		[Min],
		[Max],
		[SafteyStock],
		[AMCRange],
		[ReviewPeriod],
		[EOP],
		[Description],
		[IsEven],
		[Logo],
		[DUMin],
		[DUMax],
		[DUAMCRange],
		[LastBackUp],
		[FacilityID],
		[LastSync],
		[DSUpdateFrequency],
		[RRFStatusUpdateFrequency],
		[RRFStatusFirstUpdateAfter]
	FROM [GeneralInfo]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GeneralInfoLoadAll]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_GeneralInfoLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[HospitalName],
		[Woreda],
		[Zone],
		[Region],
		[Telephone],
		[HospitalContact],
		[LeadTime],
		[Min],
		[Max],
		[SafteyStock],
		[AMCRange],
		[ReviewPeriod],
		[EOP],
		[Description],
		[IsEven],
		[Logo],
		[DUMin],
		[DUMax],
		[DUAMCRange],
		[LastBackUp],
		[FacilityID],
		[LastSync],
		[DSUpdateFrequency],
		[RRFStatusUpdateFrequency],
		[RRFStatusFirstUpdateAfter]
	FROM [GeneralInfo]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GeneralInfoInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_GeneralInfoInsert]
(
	@ID int = NULL output,
	@HospitalName varchar(50) = NULL,
	@Woreda int = NULL,
	@Zone int = NULL,
	@Region int = NULL,
	@Telephone varchar(50) = NULL,
	@HospitalContact varchar(50) = NULL,
	@LeadTime int = NULL,
	@Min int = NULL,
	@Max int = NULL,
	@SafteyStock int = NULL,
	@AMCRange int = NULL,
	@ReviewPeriod int = NULL,
	@EOP float = NULL,
	@Description text = NULL,
	@IsEven bit = NULL,
	@Logo varchar(50) = NULL,
	@DUMin float = NULL,
	@DUMax float = NULL,
	@DUAMCRange int = NULL,
	@LastBackUp datetime = NULL,
	@FacilityID int = NULL,
	@LastSync datetime = NULL,
	@DSUpdateFrequency varchar(50) = NULL,
	@RRFStatusUpdateFrequency varchar(50) = NULL,
	@RRFStatusFirstUpdateAfter varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [GeneralInfo]
	(
		[HospitalName],
		[Woreda],
		[Zone],
		[Region],
		[Telephone],
		[HospitalContact],
		[LeadTime],
		[Min],
		[Max],
		[SafteyStock],
		[AMCRange],
		[ReviewPeriod],
		[EOP],
		[Description],
		[IsEven],
		[Logo],
		[DUMin],
		[DUMax],
		[DUAMCRange],
		[LastBackUp],
		[FacilityID],
		[LastSync],
		[DSUpdateFrequency],
		[RRFStatusUpdateFrequency],
		[RRFStatusFirstUpdateAfter]
	)
	VALUES
	(
		@HospitalName,
		@Woreda,
		@Zone,
		@Region,
		@Telephone,
		@HospitalContact,
		@LeadTime,
		@Min,
		@Max,
		@SafteyStock,
		@AMCRange,
		@ReviewPeriod,
		@EOP,
		@Description,
		@IsEven,
		@Logo,
		@DUMin,
		@DUMax,
		@DUAMCRange,
		@LastBackUp,
		@FacilityID,
		@LastSync,
		@DSUpdateFrequency,
		@RRFStatusUpdateFrequency,
		@RRFStatusFirstUpdateAfter
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_GeneralInfoDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_GeneralInfoDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [GeneralInfo]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeUpdate]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@ExchageTypeID int = NULL,
	@From int = NULL,
	@To int = NULL,
	@Quantity int = NULL,
	@RecIDIssued int = NULL,
	@RecIDReceived int = NULL,
	@Date datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Exchange]
	SET
		[ItemID] = @ItemID,
		[ExchageTypeID] = @ExchageTypeID,
		[From] = @From,
		[To] = @To,
		[Quantity] = @Quantity,
		[RecIDIssued] = @RecIDIssued,
		[RecIDReceived] = @RecIDReceived,
		[Date] = @Date
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeTypeUpdate]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeTypeUpdate]
(
	@ID int,
	@Type varchar(50) = NULL,
	@Description varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ExchangeType]
	SET
		[Type] = @Type,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeTypeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeTypeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Type],
		[Description]
	FROM [ExchangeType]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeTypeLoadAll]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeTypeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Type],
		[Description]
	FROM [ExchangeType]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeTypeInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeTypeInsert]
(
	@ID int = NULL output,
	@Type varchar(50) = NULL,
	@Description varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ExchangeType]
	(
		[Type],
		[Description]
	)
	VALUES
	(
		@Type,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeTypeDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeTypeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ExchangeType]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ExchageTypeID],
		[From],
		[To],
		[Quantity],
		[RecIDIssued],
		[RecIDReceived],
		[Date]
	FROM [Exchange]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeLoadAll]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ExchageTypeID],
		[From],
		[To],
		[Quantity],
		[RecIDIssued],
		[RecIDReceived],
		[Date]
	FROM [Exchange]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@ExchageTypeID int = NULL,
	@From int = NULL,
	@To int = NULL,
	@Quantity int = NULL,
	@RecIDIssued int = NULL,
	@RecIDReceived int = NULL,
	@Date datetime = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Exchange]
	(
		[ItemID],
		[ExchageTypeID],
		[From],
		[To],
		[Quantity],
		[RecIDIssued],
		[RecIDReceived],
		[Date]
	)
	VALUES
	(
		@ItemID,
		@ExchageTypeID,
		@From,
		@To,
		@Quantity,
		@RecIDIssued,
		@RecIDReceived,
		@Date
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ExchangeDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ExchangeDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Exchange]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_InternalTransferUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_InternalTransferUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@FromPalletLocationID int = NULL,
	@ToPalletLocationID int = NULL,
	@BatchNumber varchar(50) = NULL,
	@ExpireDate datetime = NULL,
	@ReceiveDocID int = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@QtyPerPack int = NULL,
	@Packs int = NULL,
	@QuantityInBU bigint = NULL,
	@Type varchar(50) = NULL,
	@IssuedDate datetime = NULL,
	@ConfirmedDate datetime = NULL,
	@Status int = NULL,
	@PrintNumber int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [InternalTransfer]
	SET
		[ItemID] = @ItemID,
		[FromPalletLocationID] = @FromPalletLocationID,
		[ToPalletLocationID] = @ToPalletLocationID,
		[BatchNumber] = @BatchNumber,
		[ExpireDate] = @ExpireDate,
		[ReceiveDocID] = @ReceiveDocID,
		[ManufacturerID] = @ManufacturerID,
		[BoxLevel] = @BoxLevel,
		[QtyPerPack] = @QtyPerPack,
		[Packs] = @Packs,
		[QuantityInBU] = @QuantityInBU,
		[Type] = @Type,
		[IssuedDate] = @IssuedDate,
		[ConfirmedDate] = @ConfirmedDate,
		[Status] = @Status,
		[PrintNumber] = @PrintNumber
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_InternalTransferLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_InternalTransferLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[FromPalletLocationID],
		[ToPalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[Type],
		[IssuedDate],
		[ConfirmedDate],
		[Status],
		[PrintNumber]
	FROM [InternalTransfer]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_InternalTransferLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_InternalTransferLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[FromPalletLocationID],
		[ToPalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[Type],
		[IssuedDate],
		[ConfirmedDate],
		[Status],
		[PrintNumber]
	FROM [InternalTransfer]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_InternalTransferInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_InternalTransferInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@FromPalletLocationID int = NULL,
	@ToPalletLocationID int = NULL,
	@BatchNumber varchar(50) = NULL,
	@ExpireDate datetime = NULL,
	@ReceiveDocID int = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@QtyPerPack int = NULL,
	@Packs int = NULL,
	@QuantityInBU bigint = NULL,
	@Type varchar(50) = NULL,
	@IssuedDate datetime = NULL,
	@ConfirmedDate datetime = NULL,
	@Status int = NULL,
	@PrintNumber int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [InternalTransfer]
	(
		[ItemID],
		[FromPalletLocationID],
		[ToPalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[Type],
		[IssuedDate],
		[ConfirmedDate],
		[Status],
		[PrintNumber]
	)
	VALUES
	(
		@ItemID,
		@FromPalletLocationID,
		@ToPalletLocationID,
		@BatchNumber,
		@ExpireDate,
		@ReceiveDocID,
		@ManufacturerID,
		@BoxLevel,
		@QtyPerPack,
		@Packs,
		@QuantityInBU,
		@Type,
		@IssuedDate,
		@ConfirmedDate,
		@Status,
		@PrintNumber
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_InternalTransferDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_InternalTransferDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [InternalTransfer]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ABCUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ABCUpdate]
(
	@ID int,
	@Value varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ABC]
	SET
		[Value] = @Value,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ABCLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ABCLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Value],
		[Description]
	FROM [ABC]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ABCLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ABCLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Value],
		[Description]
	FROM [ABC]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ABCInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ABCInsert]
(
	@ID int = NULL output,
	@Value varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ABC]
	(
		[Value],
		[Description]
	)
	VALUES
	(
		@Value,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ABCDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ABCDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ABC]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_CategoryUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_CategoryUpdate]
(
	@ID int,
	@CategoryName varchar(50) = NULL,
	@CategoryCode varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Category]
	SET
		[CategoryName] = @CategoryName,
		[CategoryCode] = @CategoryCode,
		[Description] = @Description
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_CategoryLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_CategoryLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CategoryName],
		[CategoryCode],
		[Description]
	FROM [Category]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_CategoryLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_CategoryLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CategoryName],
		[CategoryCode],
		[Description]
	FROM [Category]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_CategoryInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_CategoryInsert]
(
	@ID int = NULL output,
	@CategoryName varchar(50) = NULL,
	@CategoryCode varchar(50) = NULL,
	@Description text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Category]
	(
		[CategoryName],
		[CategoryCode],
		[Description]
	)
	VALUES
	(
		@CategoryName,
		@CategoryCode,
		@Description
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_CategoryDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_CategoryDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Category]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserUpdate]
(
	@ID int,
	@FullName varchar(50) = NULL,
	@Address varchar(50) = NULL,
	@Mobile varchar(50) = NULL,
	@UserName varchar(50) = NULL,
	@Password varchar(50) = NULL,
	@UserType int = NULL,
	@Active bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [User]
	SET
		[FullName] = @FullName,
		[Address] = @Address,
		[Mobile] = @Mobile,
		[UserName] = @UserName,
		[Password] = @Password,
		[UserType] = @UserType,
		[Active] = @Active
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ShelfCode],
		[StoreID],
		[Rows],
		[Columns],
		[CoordinateX],
		[CoordinateY],
		[Rotation],
		[Length],
		[Width],
		[Height],
		[ShelfStorageType],
		[ShelfType]
	FROM [Shelf]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ShelfCode],
		[StoreID],
		[Rows],
		[Columns],
		[CoordinateX],
		[CoordinateY],
		[Rotation],
		[Length],
		[Width],
		[Height],
		[ShelfStorageType],
		[ShelfType]
	FROM [Shelf]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfInsert]
(
	@ID int = NULL output,
	@ShelfCode varchar(50) = NULL,
	@StoreID int = NULL,
	@Rows int = NULL,
	@Columns int = NULL,
	@CoordinateX float = NULL,
	@CoordinateY float = NULL,
	@Rotation float = NULL,
	@Length float = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@ShelfStorageType int = NULL,
	@ShelfType varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Shelf]
	(
		[ShelfCode],
		[StoreID],
		[Rows],
		[Columns],
		[CoordinateX],
		[CoordinateY],
		[Rotation],
		[Length],
		[Width],
		[Height],
		[ShelfStorageType],
		[ShelfType]
	)
	VALUES
	(
		@ShelfCode,
		@StoreID,
		@Rows,
		@Columns,
		@CoordinateX,
		@CoordinateY,
		@Rotation,
		@Length,
		@Width,
		@Height,
		@ShelfStorageType,
		@ShelfType
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Shelf]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ZoneUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ZoneUpdate]
(
	@ID int,
	@ZoneName varchar(50) = NULL,
	@RegionId int = NULL,
	@ZoneCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Zone]
	SET
		[ZoneName] = @ZoneName,
		[RegionId] = @RegionId,
		[ZoneCode] = @ZoneCode
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ZoneLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ZoneLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ZoneName],
		[RegionId],
		[ZoneCode]
	FROM [Zone]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ZoneLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ZoneLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ZoneName],
		[RegionId],
		[ZoneCode]
	FROM [Zone]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ZoneInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ZoneInsert]
(
	@ID int = NULL output,
	@ZoneName varchar(50) = NULL,
	@RegionId int = NULL,
	@ZoneCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Zone]
	(
		[ZoneName],
		[RegionId],
		[ZoneCode]
	)
	VALUES
	(
		@ZoneName,
		@RegionId,
		@ZoneCode
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ZoneDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ZoneDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Zone]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SubCategoryUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SubCategoryUpdate]
(
	@ID int,
	@CategoryId int = NULL,
	@SubCategoryName varchar(50) = NULL,
	@SubCategoryCode varchar(50) = NULL,
	@Description text = NULL,
	@ParentID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [SubCategory]
	SET
		[CategoryId] = @CategoryId,
		[SubCategoryName] = @SubCategoryName,
		[SubCategoryCode] = @SubCategoryCode,
		[Description] = @Description,
		[ParentID] = @ParentID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SubCategoryLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SubCategoryLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CategoryId],
		[SubCategoryName],
		[SubCategoryCode],
		[Description],
		[ParentID]
	FROM [SubCategory]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SubCategoryLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SubCategoryLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[CategoryId],
		[SubCategoryName],
		[SubCategoryCode],
		[Description],
		[ParentID]
	FROM [SubCategory]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SubCategoryInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SubCategoryInsert]
(
	@ID int = NULL output,
	@CategoryId int = NULL,
	@SubCategoryName varchar(50) = NULL,
	@SubCategoryCode varchar(50) = NULL,
	@Description text = NULL,
	@ParentID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [SubCategory]
	(
		[CategoryId],
		[SubCategoryName],
		[SubCategoryCode],
		[Description],
		[ParentID]
	)
	VALUES
	(
		@CategoryId,
		@SubCategoryName,
		@SubCategoryCode,
		@Description,
		@ParentID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_SubCategoryDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_SubCategoryDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [SubCategory]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StoresUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StoresUpdate]
(
	@ID int,
	@HospitalID int = NULL,
	@StoreName varchar(50) = NULL,
	@IsActive bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Stores]
	SET
		[HospitalID] = @HospitalID,
		[StoreName] = @StoreName,
		[IsActive] = @IsActive
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StoresLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StoresLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[HospitalID],
		[StoreName],
		[IsActive]
	FROM [Stores]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StoresLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StoresLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[HospitalID],
		[StoreName],
		[IsActive]
	FROM [Stores]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StoresInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StoresInsert]
(
	@ID int = NULL output,
	@HospitalID int = NULL,
	@StoreName varchar(50) = NULL,
	@IsActive bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Stores]
	(
		[HospitalID],
		[StoreName],
		[IsActive]
	)
	VALUES
	(
		@HospitalID,
		@StoreName,
		@IsActive
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_StoresDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_StoresDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Stores]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[FullName],
		[Address],
		[Mobile],
		[UserName],
		[Password],
		[UserType],
		[Active]
	FROM [User]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[FullName],
		[Address],
		[Mobile],
		[UserName],
		[Password],
		[UserType],
		[Active]
	FROM [User]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserInsert]
(
	@ID int = NULL output,
	@FullName varchar(50) = NULL,
	@Address varchar(50) = NULL,
	@Mobile varchar(50) = NULL,
	@UserName varchar(50) = NULL,
	@Password varchar(50) = NULL,
	@UserType int = NULL,
	@Active bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [User]
	(
		[FullName],
		[Address],
		[Mobile],
		[UserName],
		[Password],
		[UserType],
		[Active]
	)
	VALUES
	(
		@FullName,
		@Address,
		@Mobile,
		@UserName,
		@Password,
		@UserType,
		@Active
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_UserDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_UserDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [User]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfUpdate]
(
	@ID int,
	@ShelfCode varchar(50) = NULL,
	@StoreID int = NULL,
	@Rows int = NULL,
	@Columns int = NULL,
	@CoordinateX float = NULL,
	@CoordinateY float = NULL,
	@Rotation float = NULL,
	@Length float = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@ShelfStorageType int = NULL,
	@ShelfType varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Shelf]
	SET
		[ShelfCode] = @ShelfCode,
		[StoreID] = @StoreID,
		[Rows] = @Rows,
		[Columns] = @Columns,
		[CoordinateX] = @CoordinateX,
		[CoordinateY] = @CoordinateY,
		[Rotation] = @Rotation,
		[Length] = @Length,
		[Width] = @Width,
		[Height] = @Height,
		[ShelfStorageType] = @ShelfStorageType,
		[ShelfType] = @ShelfType
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [Product]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	FROM [Product]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductInsert]
(
	@ID int = NULL output,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Product]
	(
		[IIN],
		[ATC],
		[Description],
		[TypeID]
	)
	VALUES
	(
		@IIN,
		@ATC,
		@Description,
		@TypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Product]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductUpdate]
(
	@ID int,
	@IIN varchar(1500) = NULL,
	@ATC varchar(50) = NULL,
	@Description varchar(1500) = NULL,
	@TypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Product]
	SET
		[IIN] = @IIN,
		[ATC] = @ATC,
		[Description] = @Description,
		[TypeID] = @TypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WoredaUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_WoredaUpdate]
(
	@ID int,
	@WoredaName varchar(50) = NULL,
	@ZoneID int = NULL,
	@WoredaCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Woreda]
	SET
		[WoredaName] = @WoredaName,
		[ZoneID] = @ZoneID,
		[WoredaCode] = @WoredaCode
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WoredaLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_WoredaLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[WoredaName],
		[ZoneID],
		[WoredaCode]
	FROM [Woreda]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WoredaLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_WoredaLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[WoredaName],
		[ZoneID],
		[WoredaCode]
	FROM [Woreda]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WoredaInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_WoredaInsert]
(
	@ID int = NULL output,
	@WoredaName varchar(50) = NULL,
	@ZoneID int = NULL,
	@WoredaCode varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Woreda]
	(
		[WoredaName],
		[ZoneID],
		[WoredaCode]
	)
	VALUES
	(
		@WoredaName,
		@ZoneID,
		@WoredaCode
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_WoredaDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_WoredaDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Woreda]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsCategoryUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsCategoryUpdate]
(
	@ID int,
	@SubCategoryID int = NULL,
	@ItemId int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ProductsCategory]
	SET
		[SubCategoryID] = @SubCategoryID,
		[ItemId] = @ItemId
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsCategoryLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsCategoryLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[SubCategoryID],
		[ItemId]
	FROM [ProductsCategory]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsCategoryLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsCategoryLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[SubCategoryID],
		[ItemId]
	FROM [ProductsCategory]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsCategoryInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsCategoryInsert]
(
	@ID int = NULL output,
	@SubCategoryID int = NULL,
	@ItemId int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ProductsCategory]
	(
		[SubCategoryID],
		[ItemId]
	)
	VALUES
	(
		@SubCategoryID,
		@ItemId
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProductsCategoryDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProductsCategoryDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ProductsCategory]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLocationUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLocationUpdate]
(
	@ID int,
	@Label varchar(50) = NULL,
	@ShelfID int = NULL,
	@Row int = NULL,
	@Column int = NULL,
	@StorageTypeID int = NULL,
	@IsFullSize bit,
	@IsEnabled bit = NULL,
	@RackStatusID int = NULL,
	@PalletID int = NULL,
	@PercentUsed float = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@Length float = NULL,
	@Confirmed bit = NULL,
	@IsExtended bit,
	@ExtendedRows int = NULL,
	@AvailableVolume float,
	@UsedVolume float
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PalletLocation]
	SET
		[Label] = @Label,
		[ShelfID] = @ShelfID,
		[Row] = @Row,
		[Column] = @Column,
		[StorageTypeID] = @StorageTypeID,
		[IsFullSize] = @IsFullSize,
		[IsEnabled] = @IsEnabled,
		[RackStatusID] = @RackStatusID,
		[PalletID] = @PalletID,
		[PercentUsed] = @PercentUsed,
		[Width] = @Width,
		[Height] = @Height,
		[Length] = @Length,
		[Confirmed] = @Confirmed,
		[IsExtended] = @IsExtended,
		[ExtendedRows] = @ExtendedRows,
		[AvailableVolume] = @AvailableVolume,
		[UsedVolume] = @UsedVolume
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLocationLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLocationLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Label],
		[ShelfID],
		[Row],
		[Column],
		[StorageTypeID],
		[IsFullSize],
		[IsEnabled],
		[RackStatusID],
		[PalletID],
		[PercentUsed],
		[Width],
		[Height],
		[Length],
		[Confirmed],
		[IsExtended],
		[ExtendedRows],
		[AvailableVolume],
		[UsedVolume]
	FROM [PalletLocation]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLocationLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLocationLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Label],
		[ShelfID],
		[Row],
		[Column],
		[StorageTypeID],
		[IsFullSize],
		[IsEnabled],
		[RackStatusID],
		[PalletID],
		[PercentUsed],
		[Width],
		[Height],
		[Length],
		[Confirmed],
		[IsExtended],
		[ExtendedRows],
		[AvailableVolume],
		[UsedVolume]
	FROM [PalletLocation]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLocationInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLocationInsert]
(
	@ID int = NULL output,
	@Label varchar(50) = NULL,
	@ShelfID int = NULL,
	@Row int = NULL,
	@Column int = NULL,
	@StorageTypeID int = NULL,
	@IsFullSize bit,
	@IsEnabled bit = NULL,
	@RackStatusID int = NULL,
	@PalletID int = NULL,
	@PercentUsed float = NULL,
	@Width float = NULL,
	@Height float = NULL,
	@Length float = NULL,
	@Confirmed bit = NULL,
	@IsExtended bit,
	@ExtendedRows int = NULL,
	@AvailableVolume float,
	@UsedVolume float
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PalletLocation]
	(
		[Label],
		[ShelfID],
		[Row],
		[Column],
		[StorageTypeID],
		[IsFullSize],
		[IsEnabled],
		[RackStatusID],
		[PalletID],
		[PercentUsed],
		[Width],
		[Height],
		[Length],
		[Confirmed],
		[IsExtended],
		[ExtendedRows],
		[AvailableVolume],
		[UsedVolume]
	)
	VALUES
	(
		@Label,
		@ShelfID,
		@Row,
		@Column,
		@StorageTypeID,
		@IsFullSize,
		@IsEnabled,
		@RackStatusID,
		@PalletID,
		@PercentUsed,
		@Width,
		@Height,
		@Length,
		@Confirmed,
		@IsExtended,
		@ExtendedRows,
		@AvailableVolume,
		@UsedVolume
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PalletLocationDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PalletLocationDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PalletLocation]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemsUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemsUpdate]
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
	@StorageTypeID int = NULL
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
		[StorageTypeID] = @StorageTypeID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfRowColumnUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfRowColumnUpdate]
(
	@ID int,
	@Label varchar(50) = NULL,
	@ShelfID int = NULL,
	@Index int = NULL,
	@Dimension float = NULL,
	@Type varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ShelfRowColumn]
	SET
		[Label] = @Label,
		[ShelfID] = @ShelfID,
		[Index] = @Index,
		[Dimension] = @Dimension,
		[Type] = @Type
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfRowColumnLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfRowColumnLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Label],
		[ShelfID],
		[Index],
		[Dimension],
		[Type]
	FROM [ShelfRowColumn]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfRowColumnLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfRowColumnLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[Label],
		[ShelfID],
		[Index],
		[Dimension],
		[Type]
	FROM [ShelfRowColumn]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfRowColumnInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfRowColumnInsert]
(
	@ID int = NULL output,
	@Label varchar(50) = NULL,
	@ShelfID int = NULL,
	@Index int = NULL,
	@Dimension float = NULL,
	@Type varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ShelfRowColumn]
	(
		[Label],
		[ShelfID],
		[Index],
		[Dimension],
		[Type]
	)
	VALUES
	(
		@Label,
		@ShelfID,
		@Index,
		@Dimension,
		@Type
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ShelfRowColumnDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ShelfRowColumnDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ShelfRowColumn]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemsLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemsLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StockCode],
		[Strength],
		[DosageFormID],
		[UnitID],
		[VEN],
		[ABC],
		[IsFree],
		[IsDiscontinued],
		[Cost],
		[EDL],
		[Refrigeratored],
		[Pediatric],
		[IINID],
		[IsInHospitalList],
		[NeedExpiryBatch],
		[Code],
		[StockCodeDACA],
		[NearExpiryTrigger],
		[StorageTypeID]
	FROM [Items]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemsLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemsLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[StockCode],
		[Strength],
		[DosageFormID],
		[UnitID],
		[VEN],
		[ABC],
		[IsFree],
		[IsDiscontinued],
		[Cost],
		[EDL],
		[Refrigeratored],
		[Pediatric],
		[IINID],
		[IsInHospitalList],
		[NeedExpiryBatch],
		[Code],
		[StockCodeDACA],
		[NearExpiryTrigger],
		[StorageTypeID]
	FROM [Items]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemsInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemsInsert]
(
	@ID int = NULL output,
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
	@StorageTypeID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Items]
	(
		[StockCode],
		[Strength],
		[DosageFormID],
		[UnitID],
		[VEN],
		[ABC],
		[IsFree],
		[IsDiscontinued],
		[Cost],
		[EDL],
		[Refrigeratored],
		[Pediatric],
		[IINID],
		[IsInHospitalList],
		[NeedExpiryBatch],
		[Code],
		[StockCodeDACA],
		[NearExpiryTrigger],
		[StorageTypeID]
	)
	VALUES
	(
		@StockCode,
		@Strength,
		@DosageFormID,
		@UnitID,
		@VEN,
		@ABC,
		@IsFree,
		@IsDiscontinued,
		@Cost,
		@EDL,
		@Refrigeratored,
		@Pediatric,
		@IINID,
		@IsInHospitalList,
		@NeedExpiryBatch,
		@Code,
		@StockCodeDACA,
		@NearExpiryTrigger,
		@StorageTypeID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemsDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Items]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HalfPalletLocationUpdate]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_HalfPalletLocationUpdate]
(
	@ID int,
	@PalletLocationID int = NULL,
	@Label varchar(50) = NULL,
	@PalleteID int = NULL,
	@Confirmed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [HalfPalletLocation]
	SET
		[PalletLocationID] = @PalletLocationID,
		[Label] = @Label,
		[PalleteID] = @PalleteID,
		[Confirmed] = @Confirmed
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HalfPalletLocationLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_HalfPalletLocationLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletLocationID],
		[Label],
		[PalleteID],
		[Confirmed]
	FROM [HalfPalletLocation]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HalfPalletLocationLoadAll]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_HalfPalletLocationLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletLocationID],
		[Label],
		[PalleteID],
		[Confirmed]
	FROM [HalfPalletLocation]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HalfPalletLocationInsert]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_HalfPalletLocationInsert]
(
	@ID int,
	@PalletLocationID int = NULL,
	@Label varchar(50) = NULL,
	@PalleteID int = NULL,
	@Confirmed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [HalfPalletLocation]
	(
		[ID],
		[PalletLocationID],
		[Label],
		[PalleteID],
		[Confirmed]
	)
	VALUES
	(
		@ID,
		@PalletLocationID,
		@Label,
		@PalleteID,
		@Confirmed
	)

	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_HalfPalletLocationDelete]    Script Date: 11/20/2011 14:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_HalfPalletLocationDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [HalfPalletLocation]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@ReasonId int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ApprovedBy varchar(50) = NULL,
	@Losses bit = NULL,
	@BatchNo varchar(50) = NULL,
	@Remark text = NULL,
	@Cost float = NULL,
	@RefNo varchar(50) = NULL,
	@EurDate datetime = NULL,
	@RecID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Disposal]
	SET
		[ItemID] = @ItemID,
		[StoreId] = @StoreId,
		[ReasonId] = @ReasonId,
		[Quantity] = @Quantity,
		[Date] = @Date,
		[ApprovedBy] = @ApprovedBy,
		[Losses] = @Losses,
		[BatchNo] = @BatchNo,
		[Remark] = @Remark,
		[Cost] = @Cost,
		[RefNo] = @RefNo,
		[EurDate] = @EurDate,
		[RecID] = @RecID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreId],
		[ReasonId],
		[Quantity],
		[Date],
		[ApprovedBy],
		[Losses],
		[BatchNo],
		[Remark],
		[Cost],
		[RefNo],
		[EurDate],
		[RecID]
	FROM [Disposal]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreId],
		[ReasonId],
		[Quantity],
		[Date],
		[ApprovedBy],
		[Losses],
		[BatchNo],
		[Remark],
		[Cost],
		[RefNo],
		[EurDate],
		[RecID]
	FROM [Disposal]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@ReasonId int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ApprovedBy varchar(50) = NULL,
	@Losses bit = NULL,
	@BatchNo varchar(50) = NULL,
	@Remark text = NULL,
	@Cost float = NULL,
	@RefNo varchar(50) = NULL,
	@EurDate datetime = NULL,
	@RecID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Disposal]
	(
		[ItemID],
		[StoreId],
		[ReasonId],
		[Quantity],
		[Date],
		[ApprovedBy],
		[Losses],
		[BatchNo],
		[Remark],
		[Cost],
		[RefNo],
		[EurDate],
		[RecID]
	)
	VALUES
	(
		@ItemID,
		@StoreId,
		@ReasonId,
		@Quantity,
		@Date,
		@ApprovedBy,
		@Losses,
		@BatchNo,
		@Remark,
		@Cost,
		@RefNo,
		@EurDate,
		@RecID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_DisposalDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_DisposalDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Disposal]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedLocationUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedLocationUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@PalletLocationID int = NULL,
	@IsFixed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemPrefferedLocation]
	SET
		[ItemID] = @ItemID,
		[PalletLocationID] = @PalletLocationID,
		[IsFixed] = @IsFixed
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedLocationLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedLocationLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[PalletLocationID],
		[IsFixed]
	FROM [ItemPrefferedLocation]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedLocationLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedLocationLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[PalletLocationID],
		[IsFixed]
	FROM [ItemPrefferedLocation]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedLocationInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedLocationInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@PalletLocationID int = NULL,
	@IsFixed bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemPrefferedLocation]
	(
		[ItemID],
		[PalletLocationID],
		[IsFixed]
	)
	VALUES
	(
		@ItemID,
		@PalletLocationID,
		@IsFixed
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemPrefferedLocationDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemPrefferedLocationDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemPrefferedLocation]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemManufacturerUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemManufacturerUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@ManufacturerID int = NULL,
	@PackageLevel int = NULL,
	@QuantityPerLevel int = NULL,
	@IsssuingDefault bit = NULL,
	@RecevingDefault bit = NULL,
	@BoxWidth float = NULL,
	@BoxHeight float = NULL,
	@BoxLength float = NULL,
	@BrandName varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemManufacturer]
	SET
		[ItemID] = @ItemID,
		[ManufacturerID] = @ManufacturerID,
		[PackageLevel] = @PackageLevel,
		[QuantityPerLevel] = @QuantityPerLevel,
		[IsssuingDefault] = @IsssuingDefault,
		[RecevingDefault] = @RecevingDefault,
		[BoxWidth] = @BoxWidth,
		[BoxHeight] = @BoxHeight,
		[BoxLength] = @BoxLength,
		[BrandName] = @BrandName
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemManufacturerLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemManufacturerLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ManufacturerID],
		[PackageLevel],
		[QuantityPerLevel],
		[IsssuingDefault],
		[RecevingDefault],
		[BoxWidth],
		[BoxHeight],
		[BoxLength],
		[BrandName]
	FROM [ItemManufacturer]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemManufacturerLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemManufacturerLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[ManufacturerID],
		[PackageLevel],
		[QuantityPerLevel],
		[IsssuingDefault],
		[RecevingDefault],
		[BoxWidth],
		[BoxHeight],
		[BoxLength],
		[BrandName]
	FROM [ItemManufacturer]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemManufacturerInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemManufacturerInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@ManufacturerID int = NULL,
	@PackageLevel int = NULL,
	@QuantityPerLevel int = NULL,
	@IsssuingDefault bit = NULL,
	@RecevingDefault bit = NULL,
	@BoxWidth float = NULL,
	@BoxHeight float = NULL,
	@BoxLength float = NULL,
	@BrandName varchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemManufacturer]
	(
		[ItemID],
		[ManufacturerID],
		[PackageLevel],
		[QuantityPerLevel],
		[IsssuingDefault],
		[RecevingDefault],
		[BoxWidth],
		[BoxHeight],
		[BoxLength],
		[BrandName]
	)
	VALUES
	(
		@ItemID,
		@ManufacturerID,
		@PackageLevel,
		@QuantityPerLevel,
		@IsssuingDefault,
		@RecevingDefault,
		@BoxWidth,
		@BoxHeight,
		@BoxLength,
		@BrandName
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemManufacturerDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemManufacturerDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemManufacturer]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BalanceUpdate]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_BalanceUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@LastDate datetime = NULL,
	@SOH bigint = NULL,
	@PhysicalCount bigint = NULL,
	@Month int = NULL,
	@Year int = NULL,
	@AMC bigint = NULL,
	@SOHCost float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Balance]
	SET
		[ItemID] = @ItemID,
		[StoreId] = @StoreId,
		[LastDate] = @LastDate,
		[SOH] = @SOH,
		[PhysicalCount] = @PhysicalCount,
		[Month] = @Month,
		[Year] = @Year,
		[AMC] = @AMC,
		[SOHCost] = @SOHCost
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BalanceLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_BalanceLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreId],
		[LastDate],
		[SOH],
		[PhysicalCount],
		[Month],
		[Year],
		[AMC],
		[SOHCost]
	FROM [Balance]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BalanceLoadAll]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_BalanceLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreId],
		[LastDate],
		[SOH],
		[PhysicalCount],
		[Month],
		[Year],
		[AMC],
		[SOHCost]
	FROM [Balance]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BalanceInsert]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_BalanceInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@StoreId int = NULL,
	@LastDate datetime = NULL,
	@SOH bigint = NULL,
	@PhysicalCount bigint = NULL,
	@Month int = NULL,
	@Year int = NULL,
	@AMC bigint = NULL,
	@SOHCost float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Balance]
	(
		[ItemID],
		[StoreId],
		[LastDate],
		[SOH],
		[PhysicalCount],
		[Month],
		[Year],
		[AMC],
		[SOHCost]
	)
	VALUES
	(
		@ItemID,
		@StoreId,
		@LastDate,
		@SOH,
		@PhysicalCount,
		@Month,
		@Year,
		@AMC,
		@SOHCost
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_BalanceDelete]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_BalanceDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Balance]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YearEndUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_YearEndUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@StoreID int = NULL,
	@Year int = NULL,
	@BBalance bigint = NULL,
	@EBalance bigint = NULL,
	@PhysicalInventory bigint = NULL,
	@Remark varchar(50) = NULL,
	@Month int = NULL,
	@EndingPrice decimal(18,0) = NULL,
	@PhysicalInventoryPrice decimal(18,0) = NULL,
	@BBPrice decimal(18,0) = NULL,
	@BatchNo varchar(50) = NULL,
	@AutomaticallyEntered bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [YearEnd]
	SET
		[ItemID] = @ItemID,
		[StoreID] = @StoreID,
		[Year] = @Year,
		[BBalance] = @BBalance,
		[EBalance] = @EBalance,
		[PhysicalInventory] = @PhysicalInventory,
		[Remark] = @Remark,
		[Month] = @Month,
		[EndingPrice] = @EndingPrice,
		[PhysicalInventoryPrice] = @PhysicalInventoryPrice,
		[BBPrice] = @BBPrice,
		[BatchNo] = @BatchNo,
		[AutomaticallyEntered] = @AutomaticallyEntered
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YearEndLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_YearEndLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreID],
		[Year],
		[BBalance],
		[EBalance],
		[PhysicalInventory],
		[Remark],
		[Month],
		[EndingPrice],
		[PhysicalInventoryPrice],
		[BBPrice],
		[BatchNo],
		[AutomaticallyEntered]
	FROM [YearEnd]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YearEndLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_YearEndLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[StoreID],
		[Year],
		[BBalance],
		[EBalance],
		[PhysicalInventory],
		[Remark],
		[Month],
		[EndingPrice],
		[PhysicalInventoryPrice],
		[BBPrice],
		[BatchNo],
		[AutomaticallyEntered]
	FROM [YearEnd]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YearEndInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_YearEndInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@StoreID int = NULL,
	@Year int = NULL,
	@BBalance bigint = NULL,
	@EBalance bigint = NULL,
	@PhysicalInventory bigint = NULL,
	@Remark varchar(50) = NULL,
	@Month int = NULL,
	@EndingPrice decimal(18,0) = NULL,
	@PhysicalInventoryPrice decimal(18,0) = NULL,
	@BBPrice decimal(18,0) = NULL,
	@BatchNo varchar(50) = NULL,
	@AutomaticallyEntered bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [YearEnd]
	(
		[ItemID],
		[StoreID],
		[Year],
		[BBalance],
		[EBalance],
		[PhysicalInventory],
		[Remark],
		[Month],
		[EndingPrice],
		[PhysicalInventoryPrice],
		[BBPrice],
		[BatchNo],
		[AutomaticallyEntered]
	)
	VALUES
	(
		@ItemID,
		@StoreID,
		@Year,
		@BBalance,
		@EBalance,
		@PhysicalInventory,
		@Remark,
		@Month,
		@EndingPrice,
		@PhysicalInventoryPrice,
		@BBPrice,
		@BatchNo,
		@AutomaticallyEntered
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_YearEndDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_YearEndDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [YearEnd]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplyCategoryUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplyCategoryUpdate]
(
	@ID int,
	@ItemID int = NULL,
	@CategoryID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemSupplyCategory]
	SET
		[ItemID] = @ItemID,
		[CategoryID] = @CategoryID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplyCategoryLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplyCategoryLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[CategoryID]
	FROM [ItemSupplyCategory]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplyCategoryLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplyCategoryLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ItemID],
		[CategoryID]
	FROM [ItemSupplyCategory]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplyCategoryInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplyCategoryInsert]
(
	@ID int = NULL output,
	@ItemID int = NULL,
	@CategoryID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemSupplyCategory]
	(
		[ItemID],
		[CategoryID]
	)
	VALUES
	(
		@ItemID,
		@CategoryID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplyCategoryDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplyCategoryDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemSupplyCategory]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplierUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplierUpdate]
(
	@ID int,
	@SupplierID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ItemSupplier]
	SET
		[SupplierID] = @SupplierID,
		[ItemID] = @ItemID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplierLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplierLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[SupplierID],
		[ItemID]
	FROM [ItemSupplier]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplierLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplierLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[SupplierID],
		[ItemID]
	FROM [ItemSupplier]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplierInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplierInsert]
(
	@ID int = NULL output,
	@SupplierID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ItemSupplier]
	(
		[SupplierID],
		[ItemID]
	)
	VALUES
	(
		@SupplierID,
		@ItemID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ItemSupplierDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ItemSupplierDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ItemSupplier]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickFaceUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickFaceUpdate]
(
	@ID int,
	@PalletLocationID int = NULL,
	@DesignatedItem int = NULL,
	@Balance int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PickFace]
	SET
		[PalletLocationID] = @PalletLocationID,
		[DesignatedItem] = @DesignatedItem,
		[Balance] = @Balance
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickFaceLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickFaceLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletLocationID],
		[DesignatedItem],
		[Balance]
	FROM [PickFace]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickFaceLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickFaceLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PalletLocationID],
		[DesignatedItem],
		[Balance]
	FROM [PickFace]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickFaceInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickFaceInsert]
(
	@ID int = NULL output,
	@PalletLocationID int = NULL,
	@DesignatedItem int = NULL,
	@Balance int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PickFace]
	(
		[PalletLocationID],
		[DesignatedItem],
		[Balance]
	)
	VALUES
	(
		@PalletLocationID,
		@DesignatedItem,
		@Balance
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickFaceDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickFaceDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PickFace]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramProductUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramProductUpdate]
(
	@ID int,
	@ProgramID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ProgramProduct]
	SET
		[ProgramID] = @ProgramID,
		[ItemID] = @ItemID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramProductLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ProgramID],
		[ItemID]
	FROM [ProgramProduct]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramProductLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramProductLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ProgramID],
		[ItemID]
	FROM [ProgramProduct]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramProductInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramProductInsert]
(
	@ID int = NULL output,
	@ProgramID int = NULL,
	@ItemID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ProgramProduct]
	(
		[ProgramID],
		[ItemID]
	)
	VALUES
	(
		@ProgramID,
		@ItemID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ProgramProductDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ProgramProductDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ProgramProduct]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceiveDocUpdate]
(
	@ID int,
	@BatchNo varchar(50) = NULL,
	@ItemID int = NULL,
	@SupplierID int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ExpDate datetime = NULL,
	@Out bit = NULL,
	@ReceivedStatus int = NULL,
	@ReceivedBy varchar(50) = NULL,
	@Remark text = NULL,
	@StoreID int = NULL,
	@LocalBatchNo varchar(50) = NULL,
	@RefNo varchar(50) = NULL,
	@Cost float = NULL,
	@IsApproved bit = NULL,
	@QuantityLeft bigint = NULL,
	@NoOfPack int = NULL,
	@QtyPerPack int = NULL,
	@EurDate datetime = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@SubProgramID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ReceiveDoc]
	SET
		[BatchNo] = @BatchNo,
		[ItemID] = @ItemID,
		[SupplierID] = @SupplierID,
		[Quantity] = @Quantity,
		[Date] = @Date,
		[ExpDate] = @ExpDate,
		[Out] = @Out,
		[ReceivedStatus] = @ReceivedStatus,
		[ReceivedBy] = @ReceivedBy,
		[Remark] = @Remark,
		[StoreID] = @StoreID,
		[LocalBatchNo] = @LocalBatchNo,
		[RefNo] = @RefNo,
		[Cost] = @Cost,
		[IsApproved] = @IsApproved,
		[QuantityLeft] = @QuantityLeft,
		[NoOfPack] = @NoOfPack,
		[QtyPerPack] = @QtyPerPack,
		[EurDate] = @EurDate,
		[ManufacturerID] = @ManufacturerID,
		[BoxLevel] = @BoxLevel
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END


SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceiveDocLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[BatchNo],
		[ItemID],
		[SupplierID],
		[Quantity],
		[Date],
		[ExpDate],
		[Out],
		[ReceivedStatus],
		[ReceivedBy],
		[Remark],
		[StoreID],
		[LocalBatchNo],
		[RefNo],
		[Cost],
		[IsApproved],
		[QuantityLeft],
		[NoOfPack],
		[QtyPerPack],
		[EurDate],
		[ManufacturerID],
		[BoxLevel],
		[SubProgramID]
	FROM [ReceiveDoc]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END


SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceiveDocLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[BatchNo],
		[ItemID],
		[SupplierID],
		[Quantity],
		[Date],
		[ExpDate],
		[Out],
		[ReceivedStatus],
		[ReceivedBy],
		[Remark],
		[StoreID],
		[LocalBatchNo],
		[RefNo],
		[Cost],
		[IsApproved],
		[QuantityLeft],
		[NoOfPack],
		[QtyPerPack],
		[EurDate],
		[ManufacturerID],
		[BoxLevel],
		[SubProgramID]
	FROM [ReceiveDoc]

	SET @Err = @@Error

	RETURN @Err
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceiveDocInsert]
(
	@ID int = NULL output,
	@BatchNo varchar(50) = NULL,
	@ItemID int = NULL,
	@SupplierID int = NULL,
	@Quantity bigint = NULL,
	@Date datetime = NULL,
	@ExpDate datetime = NULL,
	@Out bit = NULL,
	@ReceivedStatus int = NULL,
	@ReceivedBy varchar(50) = NULL,
	@Remark text = NULL,
	@StoreID int = NULL,
	@LocalBatchNo varchar(50) = NULL,
	@RefNo varchar(50) = NULL,
	@Cost float = NULL,
	@IsApproved bit = NULL,
	@QuantityLeft bigint = NULL,
	@NoOfPack int = NULL,
	@QtyPerPack int = NULL,
	@EurDate datetime = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@SubProgramID int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceiveDoc]
	(
		[BatchNo],
		[ItemID],
		[SupplierID],
		[Quantity],
		[Date],
		[ExpDate],
		[Out],
		[ReceivedStatus],
		[ReceivedBy],
		[Remark],
		[StoreID],
		[LocalBatchNo],
		[RefNo],
		[Cost],
		[IsApproved],
		[QuantityLeft],
		[NoOfPack],
		[QtyPerPack],
		[EurDate],
		[ManufacturerID],
		[BoxLevel],
		[SubProgramID]
	)
	VALUES
	(
		@BatchNo,
		@ItemID,
		@SupplierID,
		@Quantity,
		@Date,
		@ExpDate,
		@Out,
		@ReceivedStatus,
		@ReceivedBy,
		@Remark,
		@StoreID,
		@LocalBatchNo,
		@RefNo,
		@Cost,
		@IsApproved,
		@QuantityLeft,
		@NoOfPack,
		@QtyPerPack,
		@EurDate,
		@ManufacturerID,
		@BoxLevel,
		@SubProgramID
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END


SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceiveDocDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceiveDocDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ReceiveDoc]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END

SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingUnitsUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingUnitsUpdate]
(
	@ID int,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@Phone varchar(50) = NULL,
	@Woreda int = NULL,
	@Route int = NULL,
	@Min float = NULL,
	@Max float = NULL,
	@IsActive bit = NULL
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
		[IsActive] = @IsActive
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingUnitsLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingUnitsLoadByPrimaryKey]
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
		[Description],
		[Phone],
		[Woreda],
		[Route],
		[Min],
		[Max],
		[IsActive]
	FROM [ReceivingUnits]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingUnitsLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingUnitsLoadAll]
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
		[IsActive]
	FROM [ReceivingUnits]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingUnitsInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingUnitsInsert]
(
	@ID int = NULL output,
	@Name varchar(50) = NULL,
	@Description text = NULL,
	@Phone varchar(50) = NULL,
	@Woreda int = NULL,
	@Route int = NULL,
	@Min float = NULL,
	@Max float = NULL,
	@IsActive bit = NULL
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
		[IsActive]
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
		@IsActive
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivingUnitsDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivingUnitsDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ReceivingUnits]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDetailUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDetailUpdate]
(
	@ID int,
	@RRFID int = NULL,
	@StoreID int = NULL,
	@ItemID int = NULL,
	@RequestedQuantity int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [RRFDetail]
	SET
		[RRFID] = @RRFID,
		[StoreID] = @StoreID,
		[ItemID] = @ItemID,
		[RequestedQuantity] = @RequestedQuantity
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDetailLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDetailLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[RRFID],
		[StoreID],
		[ItemID],
		[RequestedQuantity]
	FROM [RRFDetail]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDetailLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDetailLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[RRFID],
		[StoreID],
		[ItemID],
		[RequestedQuantity]
	FROM [RRFDetail]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDetailInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDetailInsert]
(
	@ID int = NULL output,
	@RRFID int = NULL,
	@StoreID int = NULL,
	@ItemID int = NULL,
	@RequestedQuantity int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [RRFDetail]
	(
		[RRFID],
		[StoreID],
		[ItemID],
		[RequestedQuantity]
	)
	VALUES
	(
		@RRFID,
		@StoreID,
		@ItemID,
		@RequestedQuantity
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_RRFDetailDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_RRFDetailDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [RRFDetail]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalletUpdate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalletUpdate]
(
	@ID int,
	@ReceiveID int = NULL,
	@PalletID int = NULL,
	@ReceivedQuantity bigint = NULL,
	@Balance bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [ReceivePallet]
	SET
		[ReceiveID] = @ReceiveID,
		[PalletID] = @PalletID,
		[ReceivedQuantity] = @ReceivedQuantity,
		[Balance] = @Balance
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalletLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalletLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	FROM [ReceivePallet]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalletLoadAll]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalletLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	FROM [ReceivePallet]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalletInsert]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalletInsert]
(
	@ID int = NULL output,
	@ReceiveID int = NULL,
	@PalletID int = NULL,
	@ReceivedQuantity bigint = NULL,
	@Balance bigint = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [ReceivePallet]
	(
		[ReceiveID],
		[PalletID],
		[ReceivedQuantity],
		[Balance]
	)
	VALUES
	(
		@ReceiveID,
		@PalletID,
		@ReceivedQuantity,
		@Balance
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_ReceivePalletDelete]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_ReceivePalletDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [ReceivePallet]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Order]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderUpdate]
(
	@ID int,
	@OrderStatusID int,
	@RequestedBy int,
	@Date datetime = NULL,
	@EurDate datetime = NULL,
	@RefNo varchar(50) = NULL,
	@Remark text = NULL,
	@FromStore int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Order]
	SET
		[OrderStatusID] = @OrderStatusID,
		[RequestedBy] = @RequestedBy,
		[Date] = @Date,
		[EurDate] = @EurDate,
		[RefNo] = @RefNo,
		[Remark] = @Remark,
		[FromStore] = @FromStore
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderStatusID],
		[RequestedBy],
		[Date],
		[EurDate],
		[RefNo],
		[Remark],
		[FromStore]
	FROM [Order]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderStatusID],
		[RequestedBy],
		[Date],
		[EurDate],
		[RefNo],
		[Remark],
		[FromStore]
	FROM [Order]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderInsert]
(
	@ID int = NULL output,
	@OrderStatusID int,
	@RequestedBy int,
	@Date datetime = NULL,
	@EurDate datetime = NULL,
	@RefNo varchar(50) = NULL,
	@Remark text = NULL,
	@FromStore int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Order]
	(
		[OrderStatusID],
		[RequestedBy],
		[Date],
		[EurDate],
		[RefNo],
		[Remark],
		[FromStore]
	)
	VALUES
	(
		@OrderStatusID,
		@RequestedBy,
		@Date,
		@EurDate,
		@RefNo,
		@Remark,
		@FromStore
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_IssueDocUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_IssueDocUpdate]
(
	@ID int,
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

	UPDATE [IssueDoc]
	SET
		[ItemID] = @ItemID,
		[StoreId] = @StoreId,
		[ReceivingUnitID] = @ReceivingUnitID,
		[LocalBatchNo] = @LocalBatchNo,
		[Quantity] = @Quantity,
		[Date] = @Date,
		[IsTransfer] = @IsTransfer,
		[IssuedBy] = @IssuedBy,
		[Remark] = @Remark,
		[RefNo] = @RefNo,
		[BatchNo] = @BatchNo,
		[IsApproved] = @IsApproved,
		[Cost] = @Cost,
		[NoOfPack] = @NoOfPack,
		[QtyPerPack] = @QtyPerPack,
		[DUSOH] = @DUSOH,
		[DURequestedQty] = @DURequestedQty,
		[RecomendedQty] = @RecomendedQty,
		[RecievDocID] = @RecievDocID,
		[EurDate] = @EurDate,
		[OrderID] = @OrderID
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_IssueDocLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_IssueDocLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
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
	FROM [IssueDoc]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_IssueDocLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_IssueDocLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
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
	FROM [IssueDoc]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_IssueDocInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_IssueDocInsert]
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
	INTO [IssueDoc]
	(
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
GO
/****** Object:  StoredProcedure [dbo].[proc_IssueDocDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_IssueDocDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [IssueDoc]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionDetails]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Alter date: <Alter Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[GetTransactionDetails]
	-- Add the parameters for the stored procedure here
	  @storeid int,
	  @todate datetime,
	  @fromdate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	select t.*
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as Received, 
		isnull(rd.Quantity,0) as ReceivedQty, isnull(rd.Price,0) as ReceivedPrice, isnull(rd.QuantityLeft,0) as QuantityLeft, 
		isnull(id.Quantity,0) as IssuedQty, isnull(id.Price,0) as IssuedPrice,
		vw.ID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type, p.ID as ProgramID, p.Name as ProgramName 
		from vwGetAllItems vw left join ProgramProduct pp on vw.ID = pp.ItemID left join Programs p on pp.ProgramID = p.ID left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft, SUM(Quantity * Cost) Price from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity, SUM(Quantity * Cost) Price from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		
		where vw.IsInHospitalList = 1) t order by t.FullItemName
END
GO
/****** Object:  StoredProcedure [dbo].[GetMonthlyConsumptionByUnits]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Alter date: <Alter Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[GetMonthlyConsumptionByUnits] 
	-- Add the parameters for the stored procedure here
	@year int, 
	@storeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @todate datetime
	declare @fromdate datetime
	declare @tempdate datetime
	declare @pyr int
	
	select @tempdate =  cast('10/30/' + cast(@year as varchar) as datetime)
	select @todate = cast(@tempdate as datetime)
	select @fromdate = cast('11/1/' + (cast((@year - 1) as varchar)) as datetime)
	select @pyr = @year - 1


    -- Insert statements for procedure here
    Select *  from(
select PivTable.ItemId,IssuedTo, IssueLocation, isnull([11],0) as [11],isnull([12],0) as [12] , isnull([1],0) as [1],isnull([2],0) as [2],isnull([3],0) as [3],isnull([4],0) as [4],isnull([5],0) as [5],
	isnull([6],0) as [6], isnull([7],0) as [7],isnull([8],0) as [8],isnull([9],0) as [9],isnull([10],0) as [10], storeId,
	case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived, vw.*
	--( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH
from vwGetAllItems vw left outer join(
select ItemId, MONTH(DATE)as mon, StoreId, Quantity, rUnits.ID as IssuedTo, rUnits.Name as IssueLocation 
from IssueDoc idc join ReceivingUnits rUnits on idc.ReceivingUnitID = runits.ID
where StoreId = @StoreId and ((YEAR(Date) = @Year and MONTH(Date) != 11 and MONTH(Date) != 12) or (YEAR(Date) = @pyr and (MONTH(Date) = 11 )) or (YEAR(Date) = @pyr and MONTH(Date) = 12) )) as IssDoc
pivot (
Sum(Quantity) for mon in ([11],[12],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10])
) as pivTable on ItemID = vw.ID
where vw.IsInHospitalList = 1 ) as x
where EverReceived != 0
order by FullItemName

END
GO
/****** Object:  StoredProcedure [dbo].[GetConsumptionTrendByMonth]    Script Date: 11/20/2011 14:07:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Alter date: <Alter Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[GetConsumptionTrendByMonth] 
	-- Add the parameters for the stored procedure here
	@year int, 
	@storeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @todate datetime
	declare @fromdate datetime
	declare @tempdate datetime
	declare @pyr int
	
	select @tempdate =  cast('10/30/' + cast(@year as varchar) as datetime)
	select @todate = cast(@tempdate as datetime)
	select @fromdate = cast('11/1/' + (cast((@year - 1) as varchar)) as datetime)
	select @pyr = @year - 1


    -- Insert statements for procedure here
select PivTable.ItemId, isnull([11],0) as [11],isnull([12],0) as [12] , isnull([1],0) as [1],isnull([2],0) as [2],isnull([3],0) as [3],isnull([4],0) as [4],isnull([5],0) as [5],
	isnull([6],0) as [6], isnull([7],0) as [7],isnull([8],0) as [8],isnull([9],0) as [9],isnull([10],0) as [10], storeId,
	case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived,
	( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, vw.*
from vwGetAllItems vw left outer join(
select ItemId, MONTH(DATE)as mon, StoreId, Quantity
from IssueDoc where StoreId = @StoreId and ((YEAR(Date) = @Year and MONTH(Date) != 11 and MONTH(Date) != 12) or (YEAR(Date) = @pyr and (MONTH(Date) = 11 )) or (YEAR(Date) = @pyr and MONTH(Date) = 12) )) as IssDoc
pivot (
Sum(Quantity) for mon in ([11],[12],[1],[2],[3],[4],[5],[6],[7],[8],[9],[10])
) as pivTable on ItemID = vw.ID
left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc 
		where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		left join
		(select ItemID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = Year(@fromdate)  group by ItemID ) as bb on bb.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 1 group by ItemID ) as loss on loss.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 0 group by ItemID ) as adj on adj.ItemID = vw.ID 
where vw.IsInHospitalList = 1 
order by vw.FullItemName
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDetailUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDetailUpdate]
(
	@ID int,
	@OrderID int,
	@ItemID int,
	@Pack int = NULL,
	@QtyPerPack int = NULL,
	@Quantity bigint = NULL,
	@ApprovedQuantity bigint = NULL,
	@Remark text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [OrderDetail]
	SET
		[OrderID] = @OrderID,
		[ItemID] = @ItemID,
		[Pack] = @Pack,
		[QtyPerPack] = @QtyPerPack,
		[Quantity] = @Quantity,
		[ApprovedQuantity] = @ApprovedQuantity,
		[Remark] = @Remark
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDetailLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDetailLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderID],
		[ItemID],
		[Pack],
		[QtyPerPack],
		[Quantity],
		[ApprovedQuantity],
		[Remark]
	FROM [OrderDetail]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDetailLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDetailLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderID],
		[ItemID],
		[Pack],
		[QtyPerPack],
		[Quantity],
		[ApprovedQuantity],
		[Remark]
	FROM [OrderDetail]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDetailInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDetailInsert]
(
	@ID int = NULL output,
	@OrderID int,
	@ItemID int,
	@Pack int = NULL,
	@QtyPerPack int = NULL,
	@Quantity bigint = NULL,
	@ApprovedQuantity bigint = NULL,
	@Remark text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [OrderDetail]
	(
		[OrderID],
		[ItemID],
		[Pack],
		[QtyPerPack],
		[Quantity],
		[ApprovedQuantity],
		[Remark]
	)
	VALUES
	(
		@OrderID,
		@ItemID,
		@Pack,
		@QtyPerPack,
		@Quantity,
		@ApprovedQuantity,
		@Remark
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_OrderDetailDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_OrderDetailDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [OrderDetail]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListUpdate]
(
	@ID int,
	@OrderID int = NULL,
	@PickType varchar(50) = NULL,
	@IssuedDate datetime = NULL,
	@IsConfirmed bit = NULL,
	@Remark text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PickList]
	SET
		[OrderID] = @OrderID,
		[PickType] = @PickType,
		[IssuedDate] = @IssuedDate,
		[IsConfirmed] = @IsConfirmed,
		[Remark] = @Remark
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderID],
		[PickType],
		[IssuedDate],
		[IsConfirmed],
		[Remark]
	FROM [PickList]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[OrderID],
		[PickType],
		[IssuedDate],
		[IsConfirmed],
		[Remark]
	FROM [PickList]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListInsert]
(
	@ID int = NULL output,
	@OrderID int = NULL,
	@PickType varchar(50) = NULL,
	@IssuedDate datetime = NULL,
	@IsConfirmed bit = NULL,
	@Remark text = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PickList]
	(
		[OrderID],
		[PickType],
		[IssuedDate],
		[IsConfirmed],
		[Remark]
	)
	VALUES
	(
		@OrderID,
		@PickType,
		@IssuedDate,
		@IsConfirmed,
		@Remark
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PickList]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[SOHByDate]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[SOHByDate]
	-- Add the parameters for the stored procedure here
	
	@storeid int,
	@date1 datetime,
	@amcrange int,
	@min int,
	@max int,
	@eop float
AS
BEGIN
	declare @tempdate varchar(20)

	declare @rangedate datetime
	declare @todate datetime
	declare @fromdate datetime
	declare @year int
	select @year = year(@date1)
	
	select @fromdate = cast('11/1/' + (cast((@year - 1) as varchar) ) as datetime)
	

	select @todate = @date1
	select @rangedate = dateadd(month,0 -@amcrange,@todate)
	
	select t.*, [Status] = case 
		when t.SOH is null or t.SOH = 0  then 'Stock Out'  
		when t.SOH < t.EOP then 'Below EOP'  
		when t.SOH <  (t.EOP * 1.25) then 'Near EOP'
		when t.SOH > t.[Max] and t.AMC > 0 then 'Over Stocked' 
		else 'Normal' 
		end
	from
	(select 
		case when ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived, isnull(rd.Quantity,0) as Received, isnull(rd.QuantityLeft,0) as QuantityLeft, isnull(id.Quantity,0) as Issued, isnull(loss.Quantity,0) as Lost, isnull(adj.Quantity,0) as Adjusted , isnull(amc.Quantity,0) as AMC ,( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, isnull(amc.Quantity * @min, 0) as Min, isnull(amc.Quantity * @max,0) as Max, isnull(amc.Quantity * @eop,0) as EOP,isnull(ed.Quantity,0) as Expired , vw.ID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type 
		from vwGetAllItems vw left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc where StoreID = @storeid and ((year(date) = @year - 1 and month(date) > 10) or  (year(Date) = @year and Date <= @date1 )) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and ((year(date) = @year - 1 and month(date) > 10) or  (year(Date) = @year and Date <= @date1 )) group by ItemID ) as id on id.ItemID = vw.ID 
		left join
		(select ItemID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = @year - 1  group by ItemID ) as bb on bb.ItemID = vw.ID 
		left join
		(select ItemID , sum(QuantityLeft) Quantity from ReceiveDoc where StoreID = @storeid and ExpDate < GETDATE() group by ItemID ) as ed on ed.ItemID = vw.ID 
		left join
		(select ItemID , cast( (cast(sum(Quantity)as float) / @amcrange ) as int) Quantity from IssueDoc where StoreID = @storeid and Date between @rangedate and @todate group by ItemID ) as amc on amc.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and ((year(date) = @year - 1 and month(date) > 10) or  (year(Date) = @year and Date <= @date1 )) and Losses = 1 group by ItemID ) as loss on loss.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and ((year(date) = @year - 1 and month(date) > 10) or  (year(Date) = @year and Date <= @date1 )) and Losses = 0 group by ItemID ) as adj on adj.ItemID = vw.ID 
		where vw.IsInHospitalList = 1) 
		t order by t.FullItemName
END
GO
/****** Object:  StoredProcedure [dbo].[SOH]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[SOH]
	@storeid int,
	@month int,
	@year int,
	@days int
AS
BEGIN
	declare @tempdate varchar(20)
	
	declare @amcrange int
	declare @min int
	declare @max int
	declare @eop float

	select  @amcrange = AMCRange,@eop = EOP, @min = MIN, @max = MAX from GeneralInfo 
	
	declare @rangedate datetime
	declare @todate datetime
	declare @fromdate datetime
	
	
	select @tempdate = cast(@month as varchar) + '/' + cast(@days as varchar) + '/' + cast(@year as varchar) 
	select @todate = cast(@tempdate as datetime)
	select @fromdate = case
				when MONTH(@todate)<=10 then cast('11/1/' + (cast((@year - 1) as varchar) ) as datetime)
				else cast('11/1/' + (cast((@year) as varchar) ) as datetime)
				end	
	select @rangedate = dateadd(month,0-@amcrange,@todate)
				
	select t.*, [Status] = case 
		when t.SOH is null or t.SOH = 0  then 'Stock Out'  
		when t.SOH < t.EOP then 'Below EOP'  
		when t.SOH <  (t.EOP * 1.25) then 'Near EOP' 
		when t.SOH > t.[Max] and t.AMC > 0 then 'Over Stocked' 
		else 'Normal' 
		end,
		(t.SOH - (t.Expired)) as Dispatchable
	from
	(select 
		case when vw.ID in (select distinct ItemID from ReceiveDoc where StoreID = @storeid) then 1 else 0 end as EverReceived, isnull(rd.Quantity,0) as Received, isnull(rd.QuantityLeft,0) as QuantityLeft, isnull(id.Quantity,0) as Issued,isnull(id2.Quantity,0) as IssuedMonth, isnull(loss.Quantity,0) as Lost, isnull(adj.Quantity,0) as Adjusted , isnull(amc.Quantity,0) as AMC ,( isnull(bb.Quantity,0) + isnull(rd.Quantity,0) + isnull(adj.Quantity,0) - isnull(id.Quantity,0) - isnull(loss.Quantity,0)) as SOH, isnull(amc.Quantity * @min, 0) as Min, isnull(amc.Quantity * @max,0) as Max, isnull(amc.Quantity * @eop,0) as EOP,isnull(ed.Quantity,0) as Expired,ISNULL(nEx.Quantity,0) as NearExpiry , vw.ID, vw.FullItemName,vw.StockCode, vw.Unit,vw.Name as Type, p.ID as ProgramID, p.Name as ProgramName
		, ld.LastIssueDate as LastIssueDate 
		from vwGetAllItems vw left join ProgramProduct pp on vw.ID = pp.ItemID left join Programs p on pp.ProgramID = p.ID left join 
		(select ItemID , sum(Quantity) Quantity, sum(QuantityLeft) QuantityLeft from ReceiveDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as rd on rd.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (date between @fromdate and @todate) group by ItemID ) as id on id.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from IssueDoc where StoreID = @storeid and (year(date) = @year and MONTH(date) = @month) group by ItemID ) as id2 on id2.ItemID = vw.ID 
		left join
		(select ItemID , sum(PhysicalInventory) Quantity from YearEnd where StoreID = @storeid and Year = Year(@fromdate)  group by ItemID ) as bb on bb.ItemID = vw.ID 
		left join
		(select ItemID , sum(QuantityLeft) Quantity from ReceiveDoc where StoreID = @storeid and ExpDate < GETDATE() group by ItemID ) as ed on ed.ItemID = vw.ID 
		left join
		(select ItemID , sum(QuantityLeft) Quantity from ReceiveDoc rd join vwGetAllItems v on rd.ItemID=v.ID where StoreID = @storeid and ExpDate between GETDATE() and DATEADD(day,v.NearExpiryTrigger,GETDATE()) group by ItemID ) as nEx on nEx.ItemID = vw.ID		
		left join
		(select ItemID , cast( (cast(sum(Quantity)as float) / @amcrange ) as int) Quantity from IssueDoc where StoreID = @storeid and Date between @rangedate and @todate group by ItemID ) as amc on amc.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 1 group by ItemID ) as loss on loss.ItemID = vw.ID 
		left join
		(select ItemID , sum(Quantity) Quantity from Disposal where StoreID = @storeid and (date between @fromdate and @todate) and Losses = 0 group by ItemID ) as adj on adj.ItemID = vw.ID 
		left join 
		(select max(Date) as LastIssueDate, ItemID from IssueDoc where StoreId = @storeid Group by ItemId ) as ld on vw.ID = ld.ItemID
		where vw.IsInHospitalList = 1) 
		t order by t.FullItemName
END
GO
/****** Object:  StoredProcedure [dbo].[SOHByPrograms]    Script Date: 11/20/2011 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP procedure [dbo].[SOHByPrograms]
GO

Create Procedure [dbo].[SOHByPrograms]
--When the SOH procedure changes, the SOHByPrograms procedure may have to change the column names if the changes introduce new columns.
	@storeid int,
	@progID int,
	@month int,
	@year int,
	@days int

AS
BEGIN

Create table #tmp
(
EverReceived bit, 
Received float,
QuantityLeft float,
Issued float, 
IssuedMonth int,
Lost float, 
Adjusted  float, 
AMC  float,
SOH float, 
[Min] float, 
[Max]  float, 
EOP float,
Expired float,
NearExpiry  float, 
[ID] int, 
FullItemName nvarchar(255),
StockCode nvarchar(255), 
Unit nvarchar(255),
[Type] nvarchar (255), 
ProgramID int, 
ProgramName nvarchar(255),
LastIssueDate Datetime,
[Status] nvarchar(255),
Dispatchable nvarchar(255)
)

insert into #tmp
exec SOH @storeID,@month,@year,@days

select * from #tmp where ProgramID=@progID

drop table #tmp
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDetailUpdate]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDetailUpdate]
(
	@ID int,
	@PickListID int = NULL,
	@ItemID int = NULL,
	@PalletLocationID int = NULL,
	@BatchNumber varchar(50) = NULL,
	@ExpireDate datetime = NULL,
	@ReceiveDocID int = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@QtyPerPack int = NULL,
	@Packs int = NULL,
	@QuantityInBU bigint = NULL,
	@ReceivePalletID int = NULL,
	@Cost float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [PickListDetail]
	SET
		[PickListID] = @PickListID,
		[ItemID] = @ItemID,
		[PalletLocationID] = @PalletLocationID,
		[BatchNumber] = @BatchNumber,
		[ExpireDate] = @ExpireDate,
		[ReceiveDocID] = @ReceiveDocID,
		[ManufacturerID] = @ManufacturerID,
		[BoxLevel] = @BoxLevel,
		[QtyPerPack] = @QtyPerPack,
		[Packs] = @Packs,
		[QuantityInBU] = @QuantityInBU,
		[ReceivePalletID] = @ReceivePalletID,
		[Cost] = @Cost
	WHERE
		[ID] = @ID


	SET @Err = @@Error


	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDetailLoadByPrimaryKey]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDetailLoadByPrimaryKey]
(
	@ID int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PickListID],
		[ItemID],
		[PalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[ReceivePalletID],
		[Cost]
	FROM [PickListDetail]
	WHERE
		([ID] = @ID)

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDetailLoadAll]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDetailLoadAll]
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[ID],
		[PickListID],
		[ItemID],
		[PalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[ReceivePalletID],
		[Cost]
	FROM [PickListDetail]

	SET @Err = @@Error

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDetailInsert]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDetailInsert]
(
	@ID int = NULL output,
	@PickListID int = NULL,
	@ItemID int = NULL,
	@PalletLocationID int = NULL,
	@BatchNumber varchar(50) = NULL,
	@ExpireDate datetime = NULL,
	@ReceiveDocID int = NULL,
	@ManufacturerID int = NULL,
	@BoxLevel int = NULL,
	@QtyPerPack int = NULL,
	@Packs int = NULL,
	@QuantityInBU bigint = NULL,
	@ReceivePalletID int = NULL,
	@Cost float = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [PickListDetail]
	(
		[PickListID],
		[ItemID],
		[PalletLocationID],
		[BatchNumber],
		[ExpireDate],
		[ReceiveDocID],
		[ManufacturerID],
		[BoxLevel],
		[QtyPerPack],
		[Packs],
		[QuantityInBU],
		[ReceivePalletID],
		[Cost]
	)
	VALUES
	(
		@PickListID,
		@ItemID,
		@PalletLocationID,
		@BatchNumber,
		@ExpireDate,
		@ReceiveDocID,
		@ManufacturerID,
		@BoxLevel,
		@QtyPerPack,
		@Packs,
		@QuantityInBU,
		@ReceivePalletID,
		@Cost
	)

	SET @Err = @@Error

	SELECT @ID = SCOPE_IDENTITY()

	RETURN @Err
END
GO
/****** Object:  StoredProcedure [dbo].[proc_PickListDetailDelete]    Script Date: 11/20/2011 14:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[proc_PickListDetailDelete]
(
	@ID int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [PickListDetail]
	WHERE
		[ID] = @ID
	SET @Err = @@Error

	RETURN @Err
END
GO
