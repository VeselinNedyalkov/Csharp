--01. Find Names of All Employees by First Name
SELECT FirstName , LastName
	FROM Employees
	WHERE FirstName LIKE 'Sa%'

--02. Find Names of All Employees by Last Name
SELECT FirstName , LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess
SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN ( 3, 10) AND
	YEAR([HireDate]) BETWEEN 1995 and 2005

--04. Find All Employees Except Engineers
SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN (5,6)
	ORDER BY [Name]

--06. Find Towns Starting With
SELECT TownID ,  [Name]
	FROM Towns
	WHERE LEFT([Name] ,1) IN ('M','K','B','E')
	ORDER BY [Name]

--07. Find Towns Not Starting With
SELECT TownID ,  [Name]
	FROM Towns
	WHERE LEFT([Name],1) NOT IN ('R','B','D')
	ORDER BY [Name]

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 
	AS SELECT [FirstName],[LastName]
	FROM Employees
	WHERE YEAR([HireDate]) > 2000

--09. Length of Last Name
SELECT [FirstName],[LastName]
	FROM Employees
	WHERE LEN([LastName]) = 5

--10. Rank Employees by Salary
SELECT [EmployeeID],[FirstName],[LastName],[Salary],
	DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Rank
	FROM Employees AS e
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--11. Find All Employees with Rank 2
SELECT *
	FROM 
		(SELECT [EmployeeID],[FirstName],[LastName],[Salary],
		DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Rank
		FROM Employees AS e
		WHERE [Salary] BETWEEN 10000 AND 50000)
	AS RankingEmplyees
	WHERE RankingEmplyees.Rank = 2
	ORDER BY Salary DESC

--12. Countries Holding 'A'
USE Geography

SELECT [CountryName],[IsoCode]
	FROM [Countries]
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode]
	
--13. Mix of Peak and River Names
SELECT  p.PeakName,r.RiverName,
	LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName)-1) , r.RiverName)) AS Mix
	FROM Rivers AS r , Peaks AS p
	WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
	ORDER BY Mix

--14. Games From 2011 and 2012 Year
USE Diablo

SELECT TOP(50) [Name] , FORMAT([Start] , 'yyyy-MM-dd') as date
	FROM [Games]
	WHERE YEAR([Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start] , [Name]

--Problem 15.	 User Email Providers

SELECT [Username],
	SUBSTRING([Email],CHARINDEX('@',[Email]) + 1,LEN([Email])) AS [Provider]
	FROM Users
	ORDER BY [Provider] , [Username]

--16. Get Users with IPAddress Like Pattern


		
