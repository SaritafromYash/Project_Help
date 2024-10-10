USE [EduhubDB]
GO

/****** Object:  Table [dbo].[Enquiries]    Script Date: 09-10-2024 18:45:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enquiries](
	[EnquiryId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Subject] [varchar](30) NULL,
	[Message] [varchar](130) NOT NULL,
	[EnquieryDate] [datetime2](7) NULL,
	[Status] [varchar](30) NULL,
	[Response] [varchar](30) NULL,
 CONSTRAINT [PK_Enquiries] PRIMARY KEY CLUSTERED 
(
	[EnquiryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


