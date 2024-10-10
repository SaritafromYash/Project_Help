USE [EduhubDB]
GO

/****** Object:  Table [dbo].[Training]    Script Date: 09-10-2024 18:48:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Training](
	[TrainingId] [int] NOT NULL,
	[TrainingName] [nvarchar](50) NOT NULL,
	[fees] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Training] ADD  CONSTRAINT [DF_traingId]  DEFAULT (NEXT VALUE FOR [userno]) FOR [TrainingId]
GO


