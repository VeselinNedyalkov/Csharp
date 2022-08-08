
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

