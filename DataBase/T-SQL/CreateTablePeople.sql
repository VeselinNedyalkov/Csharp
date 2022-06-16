CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] ='m' OR [Gender] ='f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography])
	VALUES
	('Gosho',NULL,1.85,75.2,'m','1985-11-01','The story'),
	('Ivan',NULL,1.85,75.2,'m','1985-11-01','The story'),
	('Petio',NULL,1.85,75.2,'m','1985-11-01','The story'),
	('Maria',NULL,1.85,75.2,'f','1985-11-01','The story'),
	('Stanislava',NULL,1.85,75.2,'f','1985-11-01','The story')
