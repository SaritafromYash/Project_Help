USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCourses]    Script Date: 09-10-2024 18:43:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE  [dbo].[sp_GetAllCourses]
	
AS
BEGIN
	Select CourseId, Title, description, courseStartDate, courseEndDate, UserId, Category, Level from courses;
END
