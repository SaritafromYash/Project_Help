USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCourse]    Script Date: 09-10-2024 18:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_UpdateCourse]
(@courseid int ,@title varchar(20) , @description varchar(20),
@startDate date , @endDate date,@cateogory varchar(20),
@level varchar(20))
as
 begin
 update Courses set Title=@title,Description=@description,CourseStartDate=@startDate,CourseEndDate=@endDate,Category=@cateogory,Level=@level where CourseId =@courseId
 end
  