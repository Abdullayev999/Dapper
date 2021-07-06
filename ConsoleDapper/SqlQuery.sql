CREATE DATABASE DapperDB

GO
USE DapperDB


CREATE TABLE Department
(
	Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    Country NVARCHAR(30) NOT NULL
)

CREATE TABLE Person
(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	DepartmentId INT NOT NULL,

	CONSTRAINT FK_Person_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Department(Id)
)


INSERT INTO Department ([Name],Country) VALUES ('Java','Azerbaijan')
INSERT INTO Department ([Name],Country) VALUES ('C++','Russian')
INSERT INTO Department ([Name],Country) VALUES ('C#','Germany')

INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Abdullayev Farid',25,1)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Abdullayev Cavid',28,2)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Qurbanova Ceran',24,3)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Hesen Hesenov',21,1)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Qara Qarayev',29,2)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Orxan Orxanov',27,3)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Oktay Esedov',22,3)
INSERT INTO Person (FullName,Age,DepartmentId) VALUES ('Zakir Hesenv',20,3)


SELECT * FROM Person
JOIN Department ON Person.DepartmentId = Department.Id


CREATE PROCEDURE AppendedAgeAllPersons
@age INT = 1
AS
BEGIN
 UPDATE Person SET Age = Age + @age
END