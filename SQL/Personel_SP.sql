USE [TSKBTestCaseDb]
GO
/****** Object:  StoredProcedure [dbo].[List_Personel]    Script Date: 5.08.2023 18:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[List_Personel]
	@DepartmentId INT = NULL,
	@PersonelId INT = NULL,
	@StartDate DATETIME = NULL
	
AS
BEGIN
	SELECT
		p.Id,
        p.RegistrationNumber,
        p.PersonelName,
        p.PersonelSurname,
        p.Department,
        p.StartDate,
        p.EndDate,
        p.Mail,
        p.Gender,
        p.MobilePhoneNumber,
        p.HomePhoneNumber,
		d.DepartmentName,
		d.DepartmentCode
	FROM Personels p (NOLOCK)
	JOIN Departments d (NOLOCK) on p.Department = d.Id
	WHERE (@DepartmentId IS NULL OR d.Id = @DepartmentId)
	AND (@PersonelId IS NULL OR p.Id = @PersonelId)
	AND  (@StartDate IS NULL OR CONVERT(Date, p.StartDate) >= CONVERT(date, @StartDate))
	AND p.IsDeleted = 0;

END
