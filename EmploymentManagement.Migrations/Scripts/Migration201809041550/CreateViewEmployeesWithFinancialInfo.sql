/****** Object:  View [dbo].[View_EmployeesWithFinancialInfo]    Script Date: 04/09/2018 15:40:33 ******/

CREATE VIEW[dbo].[View_EmployeesWithFinancialInfo] As
	SELECT
		e.FirstName + ' ' + e.LastName AS FullName,
		jp.JobPosition,
		CAST(e.Salary AS money) AS Salary,
		CAST(ep.TotalContribution AS money) AS PensionFundBalance
	FROM Employees e
	JOIN EmployeePensions ep
	ON e.EmployeeId = ep.EmployeeId
	JOIN JobPositions jp
	ON e.JobPositionId = jp.JobPositionId
GO