USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCoursebyuserid]    Script Date: 09-10-2024 18:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCoursebyuserid]
@userid int
AS
BEGIN
	Select CourseId, Title, description, courseStartDate, courseEndDate, UserId, Category, Level from courses where UserId = @userid;
END
