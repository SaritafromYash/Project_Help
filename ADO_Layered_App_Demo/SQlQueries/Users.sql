USE [EduhubDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 09-10-2024 18:48:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[UserName] [varchar](30) NULL,
	[MobileNumber] [varchar](30) NULL,
	[UserRole] [varchar](30) NULL,
	[ProfileImage] [varchar](30) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


