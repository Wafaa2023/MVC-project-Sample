USE [master]
GO
/****** Object:  Database [WafaaDatabase]    Script Date: 22/09/2019 04:39:55 م ******/
CREATE DATABASE [WafaaDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WafaaDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\WafaaDatabase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WafaaDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\WafaaDatabase_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WafaaDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WafaaDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WafaaDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WafaaDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WafaaDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WafaaDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WafaaDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [WafaaDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WafaaDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WafaaDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WafaaDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WafaaDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WafaaDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WafaaDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WafaaDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WafaaDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WafaaDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WafaaDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WafaaDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WafaaDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WafaaDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WafaaDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WafaaDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WafaaDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WafaaDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [WafaaDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [WafaaDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WafaaDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WafaaDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WafaaDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WafaaDatabase', N'ON'
GO
USE [WafaaDatabase]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Details]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_Header_Id] [int] NULL,
	[Item_Id] [int] NULL,
	[Qty] [int] NULL,
	[Price] [money] NULL,
	[Total] [money] NULL,
 CONSTRAINT [PK_Invoice_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice_Header]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Header](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Number] [int] NULL,
	[Customer_Id] [int] NULL,
	[Payment_Method_Id] [int] NULL,
	[Total] [money] NULL,
	[DiscountPercentage] [float] NULL,
	[NetTotal] [money] NULL,
 CONSTRAINT [PK_Invoice_Header] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Mobile], [Address]) VALUES (7, N'Wafaa', N'01126436534', N'alex')
INSERT [dbo].[Customer] ([Id], [Name], [Mobile], [Address]) VALUES (8, N'Maged', N'01322222222', N'egypt')
INSERT [dbo].[Customer] ([Id], [Name], [Mobile], [Address]) VALUES (9, N'Malik', N'0106543234', N'alex')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Invoice_Details] ON 

INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (1, 38, 5, 1, 1500.0000, 1500.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (2, 38, 7, 1, 2000.0000, 2000.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (4, 40, 7, 3, 2000.0000, 6000.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (5, 41, 4, 3, 1000.0000, 3000.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (6, 41, 7, 2, 2000.0000, 4000.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (7, 39, 6, 2, 500.0000, 1000.0000)
INSERT [dbo].[Invoice_Details] ([Id], [Invoice_Header_Id], [Item_Id], [Qty], [Price], [Total]) VALUES (8, 39, 8, 1, 300.0000, 300.0000)
SET IDENTITY_INSERT [dbo].[Invoice_Details] OFF
SET IDENTITY_INSERT [dbo].[Invoice_Header] ON 

INSERT [dbo].[Invoice_Header] ([Id], [Date], [Number], [Customer_Id], [Payment_Method_Id], [Total], [DiscountPercentage], [NetTotal]) VALUES (38, CAST(N'2019-09-22T00:00:00.000' AS DateTime), 1, 7, 1, 3500.0000, 50, 1750.0000)
INSERT [dbo].[Invoice_Header] ([Id], [Date], [Number], [Customer_Id], [Payment_Method_Id], [Total], [DiscountPercentage], [NetTotal]) VALUES (39, CAST(N'2019-09-22T00:00:00.000' AS DateTime), 2, 7, 1, 1300.0000, 50, 650.0000)
INSERT [dbo].[Invoice_Header] ([Id], [Date], [Number], [Customer_Id], [Payment_Method_Id], [Total], [DiscountPercentage], [NetTotal]) VALUES (40, CAST(N'2019-09-22T00:00:00.000' AS DateTime), 3, 7, 1, 6000.0000, 50, 3000.0000)
INSERT [dbo].[Invoice_Header] ([Id], [Date], [Number], [Customer_Id], [Payment_Method_Id], [Total], [DiscountPercentage], [NetTotal]) VALUES (41, CAST(N'2019-09-22T00:00:00.000' AS DateTime), 4, 7, 1, 7000.0000, 50, 3500.0000)
SET IDENTITY_INSERT [dbo].[Invoice_Header] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [Name], [Price]) VALUES (4, N'Red Dress', 1000.0000)
INSERT [dbo].[Item] ([Id], [Name], [Price]) VALUES (5, N'Blue Dress', 1500.0000)
INSERT [dbo].[Item] ([Id], [Name], [Price]) VALUES (6, N'White Dress', 500.0000)
INSERT [dbo].[Item] ([Id], [Name], [Price]) VALUES (7, N'Orange Dress', 2000.0000)
INSERT [dbo].[Item] ([Id], [Name], [Price]) VALUES (8, N'Test Item1', 300.0000)
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 

INSERT [dbo].[PaymentMethod] ([Id], [Name]) VALUES (1, N'Cash')
INSERT [dbo].[PaymentMethod] ([Id], [Name]) VALUES (2, N'Installment')
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Details_Invoice_Header] FOREIGN KEY([Invoice_Header_Id])
REFERENCES [dbo].[Invoice_Header] ([Id])
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [FK_Invoice_Details_Invoice_Header]
GO
ALTER TABLE [dbo].[Invoice_Details]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Details_Item] FOREIGN KEY([Item_Id])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[Invoice_Details] CHECK CONSTRAINT [FK_Invoice_Details_Item]
GO
ALTER TABLE [dbo].[Invoice_Header]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Header_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Invoice_Header] CHECK CONSTRAINT [FK_Invoice_Header_Customer]
GO
ALTER TABLE [dbo].[Invoice_Header]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Header_PaymentMethod] FOREIGN KEY([Payment_Method_Id])
REFERENCES [dbo].[PaymentMethod] ([Id])
GO
ALTER TABLE [dbo].[Invoice_Header] CHECK CONSTRAINT [FK_Invoice_Header_PaymentMethod]
GO
/****** Object:  StoredProcedure [dbo].[GetNextInvoiceId]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNextInvoiceId] 
	-- Add the parameters for the stored procedure here
 @id int
AS
BEGIN
	select Top(1)Id from Invoice_Header where Id in(select Max(Id)from Invoice_Header  where Id > @id) 
END

GO
/****** Object:  StoredProcedure [dbo].[GetPerInvoiceId]    Script Date: 22/09/2019 04:39:55 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPerInvoiceId] 
	-- Add the parameters for the stored procedure here
 @id int
AS
BEGIN
	select Top(1)Id from Invoice_Header where Id in(select Max(Id)from Invoice_Header  where Id < @id) 
END

GO
USE [master]
GO
ALTER DATABASE [WafaaDatabase] SET  READ_WRITE 
GO
