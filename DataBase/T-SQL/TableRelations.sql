use MinionsTest2
-- Problem 1.	One-To-One Relationship
CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY IDENTITY(101,1),
	[PassportNumber] CHAR(8) NOT NULL
)

INSERT INTO [Passports]([PassportNumber])
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID])
)

INSERT INTO Persons([FirstName],[Salary],[PassportID])
VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[EstablishedOn] DATE
)

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(20) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY
	REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers]([Name],[EstablishedOn])
VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO [Models]([Name],[ManufacturerID])
VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

SELECT * FROM Models
SELECT * FROM [Manufacturers]

--Problem 3.	Many-To-Many Relationship

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL, 
)

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(20) NOT NULL, 
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT,
	[ExamID] INT,
	CONSTRAINT PK_SudentExam
	PRIMARY KEY([StudentID],[ExamID]),
	CONSTRAINT FK_SudentExam_Student
	FOREIGN KEY ([StudentID]) 
	REFERENCES [Students]([StudentID]),
	CONSTRAINT FK_SudentExam_Exam
	FOREIGN KEY ([ExamID])
	REFERENCES [Exams]([ExamID])
)

INSERT INTO Students([Name])
VALUES 
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams([StudentID],[ExamID])
VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

--Problem 4.	Self-Referencing 

CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(20) NOT NULL, 
	[ManagerID] INT FOREIGN KEY 
	REFERENCES [Teachers]([TeacherID]),
)

INSERT INTO [Teachers]([Name],[ManagerID])
VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)

--Problem 5.	Online Store Database

CREATE TABLE [Cities](
	[CityId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE [Customers](
	[CustomerId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityId])
)

CREATE TABLE [Orders](
	[OrderId]  INT PRIMARY KEY IDENTITY,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([CustomerId])
)

CREATE TABLE [ItemTypes](
	[ItemTypeId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE [Items](
	[ItemId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeId] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeId])
)

CREATE TABLE [OrderItems](
	[OrderId] INT,
	[ItemId] INT,
	CONSTRAINT PK_OrdersItems
	Primary KEY([OrderId],[ItemId]),
	CONSTRAINT FK_OrdersItems_Orders
	FOREIGN KEY([OrderId])
	REFERENCES [Orders]([OrderId]),
	CONSTRAINT FK_OrdersItems_Items
	FOREIGN KEY ([ItemId])
	REFERENCES [Items]([ItemId])
)
