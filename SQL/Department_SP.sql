USE [TSKBTestCaseDb]
GO
/****** Object:  StoredProcedure [dbo].[List_Department]    Script Date: 5.08.2023 18:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[List_Department]
	@DepartmentId INT = NULL

AS	
BEGIN
	Select 
		Id,
		DepartmentCode,
		DepartmentName
	From Departments
	Where (@DepartmentId IS NULL OR Id = @DepartmentId)
	AND IsDeleted = 0;
END
