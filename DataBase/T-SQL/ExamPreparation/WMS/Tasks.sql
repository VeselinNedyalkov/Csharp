
--03. Update
UPDATE [Jobs]
set MechanicId = 3, Status = 'In Progress'
WHERE [Status] = 'Pending'

--04. Delete
DELETE [dbo].[OrderParts]
WHERE OrderId = 19

DELETE [dbo].[Orders]
WHERE OrderId = 19

--05. Mechanic Assignments
SELECT m.FirstName + ' ' + m.LastName,
		j.Status,
		j.IssueDate
FROM  [dbo].[Mechanics] AS m
JOIN Jobs AS j on j.MechanicId = m.MechanicId
ORDER BY M.MechanicId , j.IssueDate , j.JobId

--06. Current Clients
SELECT c.FirstName + ' ' + c.LastName,
	DATEDIFF(DAy , [IssueDate] , '24 April 2017') as d,
	j.Status
	FROM [dbo].[Jobs] AS j
	JOIN Clients AS c ON c.ClientId = j.ClientId
	WHERE Status != 'Finished'
ORDER BY d DESC , c.ClientId

--07. Mechanic Performance
SELECT m.FirstName + ' ' + m.LastName,
	AVG(DATEDIFF(DAY, [IssueDate] , [FinishDate] ))
	FROM [dbo].[Mechanics] AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	GROUP BY j.MechanicId , m.FirstName + ' ' + m.LastName
	ORDER BY j.MechanicId
	
--08. Available Mechanics
--SELECT  m.FirstName + ' ' + m.LastName
-- FROM Mechanics AS m
-- LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
-- WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
--						FROM Jobs
--						Where [Status]  != 'Finished' AND MechanicId = m.MechanicId
--						GROUP BY MechanicId, [Status]) IS NULL
--GROUP BY m.MechanicId, m.FirstName + ' ' + m.LastName

   SELECT m.FirstName + ' ' + m.LastName AS fullName
     FROM [Mechanics] AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    WHERE j.Status = 'Finished' AND j.Status IS NULL
	GROUP BY m.FirstName + ' ' + m.LastName , m.MechanicId
	ORDER BY m.MechanicId
	
--09. Past Expenses
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS TotalOrder
	FROM Jobs as j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
	WHERE Status = 'Finished'
	GROUP BY j.JobId
	ORDER BY TotalOrder DESC , j.JobId
