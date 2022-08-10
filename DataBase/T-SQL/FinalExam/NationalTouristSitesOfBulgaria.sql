--CREATE DATABASE
--CREATE DATABASE NationalTouristSitesOfBulgaria
--USE NationalTouristSitesOfBulgaria
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Locations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50),
)

CREATE TABLE Sites
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT CHECK(Age BETWEEN  0 AND 120) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20),
)

CREATE TABLE SitesTourists
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
	PRIMARY KEY (TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE TouristsBonusPrizes
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
	PRIMARY KEY (TouristId, BonusPrizeId)
)

----02. Insert
INSERT INTO Tourists
VALUES
('Borislava Kazakova',	52,	'+359896354244' ,	'Bulgaria',	NULL ),
('Peter Bosh',48,'+447911844141' ,	'UK',	NULL),
('Martin Smith',29,	'+353863818592' ,	'Ireland',	'Bronze badge'),
('Svilen Dobrev',49,'+359986584786' ,	'Bulgaria', 'Silver badge'),
('Kremena Popova',38,'+359893298604' ,	'Bulgaria',	NULL)

INSERT INTO Sites
VALUES
('Ustra fortress',90,7,'X'),
('Karlanovo Pyramids',65,	7,	NULL),
('The Tomb of Tsar Sevt',63,	8,'V BC'),
('Sinite Kamani Natural Park',17,	1,	NULL),
('St. Petka of Bulgaria – Rupite',92,	6,'1994')

----03. Update

UPDATE [dbo].[Sites]
SET [Establishment] = '(not defined)'
WHERE [Establishment] IS NULL

----04. Delete
DELETE FROM TouristsBonusPrizes
WHERE [BonusPrizeId] = 5

DELETE FROM[dbo].[BonusPrizes]
WHERE [Name] = 'Sleeping bag'

----05. Tourists
SELECT [Name],[Age],[PhoneNumber],[Nationality]
FROM [dbo].[Tourists]
ORDER BY [Nationality],  [Age] DESC, [Name]

----06. Sites with Their Location and Category
SELECT s.Name AS [Site], l.Name AS [Location] ,[Establishment], c.Name AS [Category]
FROM [dbo].[Sites] AS s
LEFT JOIN  [dbo].[Locations] AS l ON s.LocationId = l.Id
LEFT JOIN [dbo].[Categories] AS c ON s.CategoryId = c.Id
ORDER BY [Category] DESC , [Location] , [Site]

----07. Count of Sites in Sofia Province
SELECT l.Province , l.Municipality,l.[Name] , COUNT(s.LocationId) AS CountOfSites
FROM  [dbo].[Locations] AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE  [Province] = 'Sofia'
GROUP BY l.Province , l.Municipality , l.[Name]
ORDER BY CountOfSites DESC , l.[Name]

----08. Tourist Sites established BC
SELECT s.[Name] , l.[Name], l.Municipality,l.Province ,s.Establishment
FROM [dbo].[Sites] AS s
JOIN Locations AS l ON l.Id = s.LocationId
WHERE s.[Name] NOT LIKE 'B%' AND s.[Name] NOT LIKE 'M%' AND s.[Name] NOT LIKE 'D%'
AND Establishment LIKE '%BC'
ORDER BY s.[Name]

----09. Tourists with their Bonus Prizes
SELECT t.[Name] ,  t.Age , t.PhoneNumber , t.Nationality , 
IIF((b.[Name] IS NULL ), '(no bonus prize)' , b.[Name]) AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tb ON t.Id = tb.TouristId
LEFT JOIN BonusPrizes AS b ON b.Id = tb.BonusPrizeId
ORDER BY t.[Name]

----10. Tourists visiting History & Archaeology sites
SELECT DISTINCT  SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name])) AS [Name]  
, t.Nationality , t.Age, t.PhoneNumber
FROM [Tourists] as t
JOIN SitesTourists AS st ON t.Id = st.TouristId
JOIN Sites AS s ON s.Id = st.SiteId
JOIN Categories AS c ON c.Id = s.CategoryId
WHERE c.[Name] LIKE 'History and archaeology'
ORDER BY [Name]

----11. Tourists Count on a Tourist Site
----which receives a tourist site and returns the count of tourists, who have visited it.
GO

CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT
AS
BEGIN 
RETURN (SELECT COUNT(st.TouristId)
FROM [dbo].[Sites] AS s
JOIN SitesTourists AS st ON s.Id = st.SiteId
WHERE s.[Name] =  @Site
)
END

GO
SELECT dbo.udf_GetTouristsCountOnATouristSite('Regional History Museum – Vratsa')


--12. Annual Reward Lottery
CREATE OR ALTER PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN

SELECT t.[Name] AS [Name] ,
IIF((COUNT(s.Id) >= 100) , 'Gold badge' 
, IIF((COUNT(s.Id) >= 50) , 'Silver badge' 
,IIF((COUNT(s.Id) >= 25), 'Bronze badge'
, NULL))) AS Reward

FROM Tourists AS t
JOIN SitesTourists AS st ON t.Id = st.TouristId
JOIN Sites AS s ON st.SiteId = s.Id

WHERE t.[Name] LIKE @TouristName

GROUP BY t.[Name]

END

EXEC usp_AnnualRewardLottery 'Brus Brown'

