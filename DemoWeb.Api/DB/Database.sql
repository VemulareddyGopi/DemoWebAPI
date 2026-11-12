USE [Sirithara]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12-11-2026 20:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12-11-2026 20:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 12-11-2026 20:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12-11-2026 20:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Message] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[DOB] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20261111165116_Initialdb', N'10.0.15')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [Stock], [ProductTypeId], [Status]) VALUES (1, N'Fancy Saree', CAST(1000.00 AS Decimal(18, 2)), 20, 1, 1)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [Stock], [ProductTypeId], [Status]) VALUES (3, N'Designer Saree', CAST(1500.00 AS Decimal(18, 2)), 30, 1, 1)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [Stock], [ProductTypeId], [Status]) VALUES (4, N'Silk Saree', CAST(1800.00 AS Decimal(18, 2)), 40, 1, 1)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [Stock], [ProductTypeId], [Status]) VALUES (5, N'Dress Top', CAST(500.00 AS Decimal(18, 2)), 30, 2, 1)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [Stock], [ProductTypeId], [Status]) VALUES (6, N'Paint', CAST(200.00 AS Decimal(18, 2)), 10, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 
GO
INSERT [dbo].[ProductTypes] ([ProductTypeId], [Type], [Status]) VALUES (1, N'Sarees', 1)
GO
INSERT [dbo].[ProductTypes] ([ProductTypeId], [Type], [Status]) VALUES (2, N'Dress', 1)
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Message], [Status], [DOB]) VALUES (1, N'Gopi', N'alice@example.com', N'XXXXXXXXXXXXXXXXX', 1, CAST(N'1993-09-07' AS Date))
GO
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Message], [Status], [DOB]) VALUES (2, N'Gopi', N'alice@example.com', N'XXXXXXXXXXXXXXXXX', 1, CAST(N'1993-09-07' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
