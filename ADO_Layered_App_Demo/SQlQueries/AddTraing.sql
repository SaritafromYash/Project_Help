USE [EduhubDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_addTraining]    Script Date: 09-10-2024 18:42:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_addTraining] (@trainingname nvarchar(50), @fees decimal(12,0))
AS
BEGIN
  DECLARE @seqValue int;
  SELECT @seqValue = NEXT VALUE FOR dbo.userno;  -- Replace with your sequence name

  INSERT INTO Training (trainingId,Trainingname, fees)
  VALUES (@seqValue, @trainingname, @fees);

 
END