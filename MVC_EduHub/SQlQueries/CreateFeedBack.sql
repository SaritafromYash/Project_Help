USE [EduhubDB]
GO

/****** Object:  Table [dbo].[feedbacks]    Script Date: 09-10-2024 18:46:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[feedbacks](
	[FeedBackId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Feedbackmsg] [varchar](150) NULL,
	[feedbackdate] [datetime] NULL,
 CONSTRAINT [PK_feedbacks] PRIMARY KEY CLUSTERED 
(
	[FeedBackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


