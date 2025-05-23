USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_EnrolledStudents]    Script Date: 09-10-2024 18:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
-- =============================================
ALTER PROCEDURE [dbo].[SP_EnrolledStudents] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	SELECT e.EnrollmentId,u.UserId, u.Email, u.UserName, c.Title, c.courseStartDate, c.courseEndDate,e.status
FROM Users u
INNER JOIN Enrollments e ON u.UserId = e.UserId
INNER JOIN Courses c ON e.CourseId = c.CourseId
WHERE u.UserRole = 'Student'
AND e.Status = 'active'
END
