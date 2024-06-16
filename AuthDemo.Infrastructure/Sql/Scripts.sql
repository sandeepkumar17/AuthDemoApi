USE [master]
GO
/****** Object:  Database [AuthDemoDB] ******/
CREATE DATABASE [AuthDemoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuthDemoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AuthDemoDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuthDemoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\AuthDemoDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

USE [AuthDemoDB]
GO
/****** Object:  Table [dbo].[User] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [UserName], [Password]) VALUES (1, N'Test', N'User1', N'tuser1', N'password1')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [UserName], [Password]) VALUES (2, N'Test', N'User2', N'tuser2', N'password2')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

USE [master]
GO
ALTER DATABASE [AuthDemoDB] SET  READ_WRITE 
GO