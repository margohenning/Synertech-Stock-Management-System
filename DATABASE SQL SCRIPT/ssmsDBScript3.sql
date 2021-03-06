USE [master]
GO
/****** Object:  Database [ssms]    Script Date: 08/30/2017 00:08:13 ******/
CREATE DATABASE [ssms] ON  PRIMARY 
( NAME = N'ssms', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ssms.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ssms_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ssms_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ssms] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ssms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ssms] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ssms] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ssms] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ssms] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ssms] SET ARITHABORT OFF
GO
ALTER DATABASE [ssms] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ssms] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ssms] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ssms] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ssms] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ssms] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ssms] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ssms] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ssms] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ssms] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ssms] SET  DISABLE_BROKER
GO
ALTER DATABASE [ssms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ssms] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ssms] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ssms] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ssms] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ssms] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ssms] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ssms] SET  READ_WRITE
GO
ALTER DATABASE [ssms] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ssms] SET  MULTI_USER
GO
ALTER DATABASE [ssms] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ssms] SET DB_CHAINING OFF
GO
USE [ssms]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
/****** Object:  Table [dbo].[Store]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [varchar](200) NOT NULL,
	[StoreLocation] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Barcode]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barcode](
	[BarcodeID] [int] IDENTITY(1,1) NOT NULL,
	[BarcodeNumber] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BarcodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](200) NOT NULL,
	[CategoryDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](200) NOT NULL,
	[BrandDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/30/2017 00:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserIdentityNumber] [varchar](200) NOT NULL,
	[UserName] [varchar](200) NOT NULL,
	[UserSurname] [varchar](200) NOT NULL,
	[UserEmail] [varchar](200) NOT NULL,
	[UserPassword] [varchar](200) NOT NULL,
	[UserAdmin] [bit] NOT NULL,
	[UserActivated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@UserActivated bit, 
	@UserAdmin bit, 
	@UserEmail varchar(200), 
	@UserIdentityNumber varchar(200), 
	@UserName varchar(200), 
	@UserPassword varchar(200), 
	@UserSurname varchar(200), 
	@UserID int
AS
BEGIN
Update dbo.[User] set  [UserActivated] = @UserActivated , [UserAdmin] = @UserAdmin , [UserEmail] = @UserEmail , [UserIdentityNumber] = @UserIdentityNumber , [UserName] = @UserName , [UserPassword] = @UserPassword , [UserSurname] = @UserSurname  where [UserID] = @UserID 
END
GO
/****** Object:  StoredProcedure [dbo].[Updatesysdiagrams]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Updatesysdiagrams]
	@definition varbinary(max), 
	@name nvarchar(128), 
	@principal_id int, 
	@version int, 
	@diagram_id int
AS
BEGIN
Update dbo.[sysdiagrams] set  [definition] = @definition , [name] = @name , [principal_id] = @principal_id , [version] = @version  where [diagram_id] = @diagram_id 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStore]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStore]
	@StoreLocation varchar(200), 
	@StoreName varchar(200), 
	@StoreID int
AS
BEGIN
Update dbo.[Store] set  [StoreLocation] = @StoreLocation , [StoreName] = @StoreName  where [StoreID] = @StoreID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBarcode]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBarcode]
	@BarcodeID int
AS
BEGIN
Delete from dbo.[Barcode] where [BarcodeID] = @BarcodeID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
	@CategoryID int
AS
BEGIN
Delete from dbo.[Category] where [CategoryID] = @CategoryID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBrand]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBrand]
	@BrandID int
AS
BEGIN
Delete from dbo.[Brand] where [BrandID] = @BrandID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@UserID int
AS
BEGIN
Delete from dbo.[User] where [UserID] = @UserID 
END
GO
/****** Object:  StoredProcedure [dbo].[Deletesysdiagrams]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Deletesysdiagrams]
	@diagram_id int
AS
BEGIN
Delete from dbo.[sysdiagrams] where [diagram_id] = @diagram_id 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteStore]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStore]
	@StoreID int
AS
BEGIN
Delete from dbo.[Store] where [StoreID] = @StoreID 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBarcode]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBarcode]
	@BarcodeNumber varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Barcode]([BarcodeNumber])
values (@BarcodeNumber)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
	@CategoryDescription varchar(300), 
	@CategoryName varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Category]([CategoryDescription],[CategoryName])
values (@CategoryDescription,@CategoryName)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertBrand]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBrand]
	@BrandDescription varchar(300), 
	@BrandName varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Brand]([BrandDescription],[BrandName])
values (@BrandDescription,@BrandName)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBarcode]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBarcode]
	@BarcodeNumber varchar(200), 
	@BarcodeID int
AS
BEGIN
Update dbo.[Barcode] set  [BarcodeNumber] = @BarcodeNumber  where [BarcodeID] = @BarcodeID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategory]
	@CategoryDescription varchar(300), 
	@CategoryName varchar(200), 
	@CategoryID int
AS
BEGIN
Update dbo.[Category] set  [CategoryDescription] = @CategoryDescription , [CategoryName] = @CategoryName  where [CategoryID] = @CategoryID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBrand]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBrand]
	@BrandDescription varchar(300), 
	@BrandName varchar(200), 
	@BrandID int
AS
BEGIN
Update dbo.[Brand] set  [BrandDescription] = @BrandDescription , [BrandName] = @BrandName  where [BrandID] = @BrandID 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
	@UserActivated bit, 
	@UserAdmin bit, 
	@UserEmail varchar(200), 
	@UserIdentityNumber varchar(200), 
	@UserName varchar(200), 
	@UserPassword varchar(200), 
	@UserSurname varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[User]([UserActivated],[UserAdmin],[UserEmail],[UserIdentityNumber],[UserName],[UserPassword],[UserSurname])
values (@UserActivated,@UserAdmin,@UserEmail,@UserIdentityNumber,@UserName,@UserPassword,@UserSurname)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[Insertsysdiagrams]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insertsysdiagrams]
	@definition varbinary(max), 
	@name nvarchar(128), 
	@principal_id int, 
	@version int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[sysdiagrams]([definition],[name],[principal_id],[version])
values (@definition,@name,@principal_id,@version)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertStore]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStore]
	@StoreLocation varchar(200), 
	@StoreName varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Store]([StoreLocation],[StoreName])
values (@StoreLocation,@StoreName)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](200) NOT NULL,
	[ProductDescription] [varchar](200) NOT NULL,
	[BarcodeID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingsID] [int] IDENTITY(1,1) NOT NULL,
	[SettingsName] [varchar](200) NOT NULL,
	[SettingsSelect] [bit] NOT NULL,
	[StoreID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reader](
	[ReaderID] [int] IDENTITY(1,1) NOT NULL,
	[IPaddress] [varchar](200) NOT NULL,
	[NumAntennas] [int] NOT NULL,
	[SettingsID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReaderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[TagEPC] [varchar](200) NOT NULL,
	[ItemStatus] [bit] NOT NULL,
	[ProductID] [int] NOT NULL,
	[StoreID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertSettings]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSettings]
	@SettingsName varchar(200), 
	@SettingsSelect bit, 
	@StoreID int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Settings]([SettingsName],[SettingsSelect],[StoreID])
values (@SettingsName,@SettingsSelect,@StoreID)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProduct]
	@BarcodeID int, 
	@BrandID int, 
	@CategoryID int, 
	@ProductDescription varchar(200), 
	@ProductName varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Product]([BarcodeID],[BrandID],[CategoryID],[ProductDescription],[ProductName])
values (@BarcodeID,@BrandID,@CategoryID,@ProductDescription,@ProductName)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
	@ProductID int
AS
BEGIN
Delete from dbo.[Product] where [ProductID] = @ProductID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSettings]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSettings]
	@SettingsID int
AS
BEGIN
Delete from dbo.[Settings] where [SettingsID] = @SettingsID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSettings]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSettings]
	@SettingsName varchar(200), 
	@SettingsSelect bit, 
	@StoreID int, 
	@SettingsID int
AS
BEGIN
Update dbo.[Settings] set  [SettingsName] = @SettingsName , [SettingsSelect] = @SettingsSelect , [StoreID] = @StoreID  where [SettingsID] = @SettingsID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
	@BarcodeID int, 
	@BrandID int, 
	@CategoryID int, 
	@ProductDescription varchar(200), 
	@ProductName varchar(200), 
	@ProductID int
AS
BEGIN
Update dbo.[Product] set  [BarcodeID] = @BarcodeID , [BrandID] = @BrandID , [CategoryID] = @CategoryID , [ProductDescription] = @ProductDescription , [ProductName] = @ProductName  where [ProductID] = @ProductID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateItem]
	@ItemStatus bit, 
	@ProductID int, 
	@StoreID int, 
	@TagEPC varchar(200), 
	@ItemID int
AS
BEGIN
Update dbo.[Item] set  [ItemStatus] = @ItemStatus , [ProductID] = @ProductID , [StoreID] = @StoreID , [TagEPC] = @TagEPC  where [ItemID] = @ItemID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateReader]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateReader]
	@IPaddress varchar(200), 
	@NumAntennas int, 
	@SettingsID int, 
	@ReaderID int
AS
BEGIN
Update dbo.[Reader] set  [IPaddress] = @IPaddress , [NumAntennas] = @NumAntennas , [SettingsID] = @SettingsID  where [ReaderID] = @ReaderID 
END
GO
/****** Object:  Table [dbo].[BookOut]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookOut](
	[BookOutID] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](300) NOT NULL,
	[Project] [varchar](200) NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookOutID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Antenna]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antenna](
	[AntennaID] [int] IDENTITY(1,1) NOT NULL,
	[TxPower] [decimal](18, 0) NOT NULL,
	[RxPower] [decimal](18, 0) NOT NULL,
	[AntennaNumber] [int] NOT NULL,
	[ReaderID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AntennaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteReader]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteReader]
	@ReaderID int
AS
BEGIN
Delete from dbo.[Reader] where [ReaderID] = @ReaderID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteItem]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteItem]
	@ItemID int
AS
BEGIN
Delete from dbo.[Item] where [ItemID] = @ItemID 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertItem]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertItem]
	@ItemStatus bit, 
	@ProductID int, 
	@StoreID int, 
	@TagEPC varchar(200),
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Item]([ItemStatus],[ProductID],[StoreID],[TagEPC])
values (@ItemStatus,@ProductID,@StoreID,@TagEPC)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertReader]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertReader]
	@IPaddress varchar(200), 
	@NumAntennas int, 
	@SettingsID int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Reader]([IPaddress],[NumAntennas],[SettingsID])
values (@IPaddress,@NumAntennas,@SettingsID)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBookOut]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBookOut]
	@Date datetime, 
	@ItemID int, 
	@Project varchar(200), 
	@Reason varchar(300), 
	@UserID int, 
	@BookOutID int
AS
BEGIN
Update dbo.[BookOut] set  [Date] = @Date , [ItemID] = @ItemID , [Project] = @Project , [Reason] = @Reason , [UserID] = @UserID  where [BookOutID] = @BookOutID 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAntenna]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAntenna]
	@AntennaNumber int, 
	@ReaderID int, 
	@RxPower decimal, 
	@TxPower decimal, 
	@AntennaID int
AS
BEGIN
Update dbo.[Antenna] set  [AntennaNumber] = @AntennaNumber , [ReaderID] = @ReaderID , [RxPower] = @RxPower , [TxPower] = @TxPower  where [AntennaID] = @AntennaID 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBookOut]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBookOut]
	@Date datetime, 
	@ItemID int, 
	@Project varchar(200), 
	@Reason varchar(300), 
	@UserID int,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[BookOut]([Date],[ItemID],[Project],[Reason],[UserID])
values (@Date,@ItemID,@Project,@Reason,@UserID)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertAntenna]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAntenna]
	@AntennaNumber int, 
	@ReaderID int, 
	@RxPower decimal, 
	@TxPower decimal,
	@ID INT OUT
AS
BEGIN

Insert into dbo.[Antenna]([AntennaNumber],[ReaderID],[RxPower],[TxPower])
values (@AntennaNumber,@ReaderID,@RxPower,@TxPower)

set @ID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBookOut]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBookOut]
	@BookOutID int
AS
BEGIN
Delete from dbo.[BookOut] where [BookOutID] = @BookOutID 
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAntenna]    Script Date: 08/30/2017 00:08:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAntenna]
	@AntennaID int
AS
BEGIN
Delete from dbo.[Antenna] where [AntennaID] = @AntennaID 
END
GO
/****** Object:  ForeignKey [FK_ItemBarcode]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_ItemBarcode] FOREIGN KEY([BarcodeID])
REFERENCES [dbo].[Barcode] ([BarcodeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_ItemBarcode]
GO
/****** Object:  ForeignKey [FK_ItemBrand]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_ItemBrand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_ItemBrand]
GO
/****** Object:  ForeignKey [FK_ItemCategory]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_ItemCategory]
GO
/****** Object:  ForeignKey [FK_StoreSettings]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Settings]  WITH CHECK ADD  CONSTRAINT [FK_StoreSettings] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreID])
GO
ALTER TABLE [dbo].[Settings] CHECK CONSTRAINT [FK_StoreSettings]
GO
/****** Object:  ForeignKey [FK_SettingsReader]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Reader]  WITH CHECK ADD  CONSTRAINT [FK_SettingsReader] FOREIGN KEY([SettingsID])
REFERENCES [dbo].[Settings] ([SettingsID])
GO
ALTER TABLE [dbo].[Reader] CHECK CONSTRAINT [FK_SettingsReader]
GO
/****** Object:  ForeignKey [FK_ItemProduct]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemProduct] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemProduct]
GO
/****** Object:  ForeignKey [FK_ItemStore]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_ItemStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_ItemStore]
GO
/****** Object:  ForeignKey [FK_BookOutItem]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[BookOut]  WITH CHECK ADD  CONSTRAINT [FK_BookOutItem] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO
ALTER TABLE [dbo].[BookOut] CHECK CONSTRAINT [FK_BookOutItem]
GO
/****** Object:  ForeignKey [FK_BookOutUSer]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[BookOut]  WITH CHECK ADD  CONSTRAINT [FK_BookOutUSer] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[BookOut] CHECK CONSTRAINT [FK_BookOutUSer]
GO
/****** Object:  ForeignKey [FK_AntennaReader]    Script Date: 08/30/2017 00:08:14 ******/
ALTER TABLE [dbo].[Antenna]  WITH CHECK ADD  CONSTRAINT [FK_AntennaReader] FOREIGN KEY([ReaderID])
REFERENCES [dbo].[Reader] ([ReaderID])
GO
ALTER TABLE [dbo].[Antenna] CHECK CONSTRAINT [FK_AntennaReader]
GO
