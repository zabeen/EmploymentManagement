 INSERT INTO JobPositions(JobPosition)
 VALUES ('Director'), ('Manager'), ('Supervisor'), ('Customer Service Agent')
 GO
 
 INSERT INTO PensionProviders(ProviderName, IsDefault)
 VALUES ('PensionsRUs', 1), ('BestPensionsEva', NULL)
 GO
 
 INSERT INTO Employees(FirstName, LastName, DateOfBirth, Salary, JobPositionId)
 SELECT 'Sarah', 'Singh', '1970-01-01', 125000.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Director'
 UNION
 SELECT 'Mo', 'Man', '1975-06-25', 55000.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Manager'
 UNION
 SELECT 'Patricia', 'Patel', '1984-10-11', 35000.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Supervisor'
 UNION
 SELECT 'Bob', 'Bobinson', '1995-12-22', 25000.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Customer Service Agent'
 UNION
 SELECT 'Mary', 'Murphy', '1965-09-03', 58500.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Manager'
 UNION
 SELECT 'Zebedee', 'Zeeshan', '1989-11-01', 34500.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Supervisor'
 UNION
 SELECT 'Kate', 'Krunch', '1992-07-04', 26200.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Customer Service Agent'
 GO
 
 INSERT INTO EmployeePensions (EmployeeId, PensionProviderId)
 SELECT EmployeeId, p.PensionProviderId
 FROM Employees e
 CROSS JOIN PensionProviders p
 WHERE p.IsDefault = 1
 GO
 
 UPDATE EmployeePensions
 SET PensionProviderId = (SELECT PensionProviderId FROM PensionProviders WHERE ProviderName = 'BestPensionsEva')
 FROM EmployeePensions ep
 JOIN Employees e
 ON ep.EmployeeId = e.EmployeeId
 WHERE (e.FirstName = 'Sarah' AND e.LastName = 'Singh') OR (e.FirstName = 'Kate' AND e.LastName = 'Krunch')
 GO
 
 UPDATE EmployeePensions
 SET TotalContribution = TotalContribution + 5*e.Salary/100
 FROM EmployeePensions p
 JOIN Employees e
 ON p.EmployeeId = e.EmployeeId
 GO
 
 -- No pension employee
 INSERT INTO Employees(FirstName, LastName, DateOfBirth, Salary, JobPositionId)
 SELECT 'Norris', 'NoPension', '1999-06-30', 22000.00, JobPositionId
 FROM JobPositions
 WHERE JobPosition = 'Customer Service Agent'
 GO