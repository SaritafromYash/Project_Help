USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddCourse]    Script Date: 09-10-2024 18:40:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_AddCourse]
(@title varchar(20) , @description varchar(20),
@startDate date , @endDate date,@cateogory varchar(20),
@level varchar(20))
as
 begin
 insert into Courses(Title,Description,CourseStartDate,CourseEndDate,Category,Level) values (@title,@description,@startDate,@endDate,@cateogory,@level)
 end
  