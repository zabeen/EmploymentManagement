/****** Object:  StoredProcedure [dbo].[SP_AddContributionToEmployeePensionFunds]    Script Date: 04/09/2018 15:40:33 ******/

CREATE PROCEDURE[dbo].[SP_AddContributionToEmployeePensionFunds]
       @SalaryPercentageToContribute decimal (4,2)
AS
    UPDATE EmployeePensions
    SET

       TotalContribution = TotalContribution + @SalaryPercentageToContribute* e.Salary/100,
       LastContributionDate = GETDATE()

    FROM EmployeePensions p
    JOIN Employees e

    ON p.EmployeeId = e.EmployeeId