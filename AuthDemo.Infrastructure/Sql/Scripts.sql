
/****** Check and Drop table [dbo].[User] ******/
IF OBJECT_ID('[dbo].[User]', 'U') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[User]
END

/****** Create Table [dbo].[User] ******/
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

/****** Insert Into Table [dbo].[User] ******/
INSERT INTO [dbo].[User]
SELECT 'Test', 'User1', 'tuser1', 'password1'
UNION ALL
SELECT 'Test', 'User2', 'tuser2', 'password2'

