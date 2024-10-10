USE [EduhubDB]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 09-10-2024 18:45:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NULL,
	[Description] [varchar](30) NULL,
	[CourseStartDate] [datetime2](7) NOT NULL,
	[CourseEndDate] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[Category] [varchar](30) NULL,
	[Level] [varchar](30) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


