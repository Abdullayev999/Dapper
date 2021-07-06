CREATE DATABASE MailingsDb

GO
USE MailingsDb

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	
	CONSTRAINT CK_Cities_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Cities_Name UNIQUE([Name])
)  

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	
	CONSTRAINT CK_Countries_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Countries_Name UNIQUE([Name])
) 
 
CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FullName NVARCHAR(30) NOT NULL,
	DateOfBith DATE NOT NULL,
	Gender NVARCHAR(10) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
	CountryId INT NOT NULL,
	CityId INT NOT NULL,  

	CONSTRAINT CK_Clients_FullName CHECK(FullName!=' '),
	CONSTRAINT CK_Clients_Email CHECK(Email!=' '),
	CONSTRAINT CK_Clients_Gender CHECK(Gender IN ('Female','Male')),
	CONSTRAINT CK_Clients_DateOfBith CHECK(18<=Year(GETDATE())-Year(DateOfBith)),
	CONSTRAINT UQ_Clients_FullName UNIQUE(FullName) ,
	CONSTRAINT FK_Clients_CountryId FOREIGN KEY (CountryId) REFERENCES Countries(Id),
	CONSTRAINT FK_Clients_CityId FOREIGN KEY (CityId) REFERENCES Cities(Id)
) 
 
CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	
	CONSTRAINT CK_Categories_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Categories_Name UNIQUE([Name])
) 
 
CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL, 
	CategoryId INT NOT NULL,
	
	CONSTRAINT CK_Products_Name CHECK([Name]!=' '),
	CONSTRAINT UQ_Products_Name UNIQUE([Name]),
	CONSTRAINT FK_Products_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id) 
) 

CREATE TABLE InterestedBuyers
(
   Id INT PRIMARY KEY IDENTITY,
   ClientId INT NOT NULL,
   CategoryId INT NOT NULL,

   CONSTRAINT FK_InterestedBuyers_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(Id) ,
   CONSTRAINT FK_InterestedBuyers_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id) 
)  
 
CREATE TABLE Promotions
(
	 Id INT PRIMARY KEY IDENTITY,
	 [Percent] INT NOT NULL,
	 [StartDate] Date NOT NULL,
	 [EndDate] Date NOT NULL,
	 CountryId INT NOT NULL, 
	 ProducId INT NOT NULL,
	 
	 CONSTRAINT FK_Promotions_CountryId FOREIGN KEY (CountryId) REFERENCES Countries(Id),
	 CONSTRAINT FK_Promotions_ProducId FOREIGN KEY (ProducId) REFERENCES Products(Id),
	 CONSTRAINT CK_Promotions_EndDate CHECK([StartDate]<[EndDate]),
	 CONSTRAINT CK_Promotions_Percent CHECK([Percent]>0) 
)


INSERT INTO Cities ([Name]) VALUES ('Moscow')
INSERT INTO Cities ([Name]) VALUES ('Kiev')  
INSERT INTO Cities ([Name]) VALUES ('Baku')
INSERT INTO Cities ([Name]) VALUES ('Sankt-Piterburg')
INSERT INTO Cities ([Name]) VALUES ('Xarkov')  
INSERT INTO Cities ([Name]) VALUES ('Genece')
INSERT INTO Cities ([Name]) VALUES ('Xirdalan')


INSERT INTO Countries ([Name]) VALUES ('Azerbaijan')
INSERT INTO Countries ([Name]) VALUES ('Ukraine')  
INSERT INTO Countries ([Name]) VALUES ('Russian')


insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Valentino Flannigan', '1981-09-24', 'Female', 'vflannigan0@joomla.org', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Ricca Jammes', '1992-12-26', 'Male', 'rjammes1@nbcnews.com', 2, 5);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Wake Polland', '1968-09-26', 'Male', 'wpolland2@shinystat.com', 1, 6);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Reine Rediers', '1991-05-10', 'Male', 'rrediers3@oracle.com', 2, 5);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Lance Maestrini', '1997-01-21', 'Male', 'lmaestrini4@amazon.de', 3, 4);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Harlin Rowet', '1989-01-06', 'Female', 'hrowet5@webmd.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Nehemiah Guillart', '1986-05-12', 'Female', 'nguillart6@businesswire.com', 2, 5);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Kiley Selwyn', '2001-02-15', 'Male', 'kselwyn7@xing.com', 3, 4);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Nicolai Duckering', '1999-05-23', 'Male', 'nduckering8@lulu.com', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Beryle Widmore', '1968-02-16', 'Female', 'bwidmore9@usnews.com', 2, 5);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Ynes Kepe', '1975-09-07', 'Female', 'ykepea@princeton.edu', 1, 6);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Annetta Spenley', '1970-07-13', 'Female', 'aspenleyb@cornell.edu', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Cindra Raimbauld', '1993-02-21', 'Female', 'craimbauldc@cnbc.com', 2, 5);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Ursuline Sills', '1977-10-20', 'Female', 'usillsd@last.fm', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Devina Lockie', '1999-08-24', 'Female', 'dlockiee@pen.io', 1, 6);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Morrie Bestwick', '1977-01-29', 'Female', 'mbestwickf@jalbum.net', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Rhona Sussams', '2001-05-12', 'Female', 'rsussamsg@devhub.com', 1, 6);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Alyce Petrashov', '1997-08-03', 'Female', 'apetrashovh@nydailynews.com', 3, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Winfred Kenefick', '1995-08-15', 'Male', 'wkeneficki@foxnews.com', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Amitie Giaomozzo', '1971-03-10', 'Male', 'agiaomozzoj@yelp.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Geoffrey Emptage', '1995-02-12', 'Female', 'gemptagek@samsung.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Hesther Glasspoole', '1999-03-29', 'Male', 'hglasspoolel@wsj.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Jewel Simons', '1976-02-24', 'Male', 'jsimonsm@noaa.gov', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Clarey Dryburgh', '1983-01-04', 'Male', 'cdryburghn@newyorker.com', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Nikolas Cowdrey', '1974-04-03', 'Male', 'ncowdreyo@fema.gov', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Colman Inge', '1994-10-22', 'Male', 'cingep@boston.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Lotty O''Scanlan', '1970-07-18', 'Female', 'loscanlanq@dailymail.co.uk', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Natalee Van der Mark', '1999-08-19', 'Female', 'nvanr@hugedomains.com', 3, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Felicity Mullarkey', '1999-01-05', 'Female', 'fmullarkeys@cisco.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Lorenza Anten', '1972-07-16', 'Male', 'lantent@hostgator.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Licha Pybus', '1993-05-09', 'Female', 'lpybusu@prnewswire.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Pincus McLemon', '1982-03-27', 'Male', 'pmclemonv@illinois.edu', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Mariya Clare', '1979-01-19', 'Male', 'mclarew@virginia.edu', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Candida Wedlock', '1970-12-24', 'Female', 'cwedlockx@dailymail.co.uk', 3, 4);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Orv Darlison', '1996-01-21', 'Female', 'odarlisony@ask.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Starr Pilipyak', '1987-05-27', 'Male', 'spilipyakz@pinterest.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Faunie Smallpiece', '1983-11-16', 'Female', 'fsmallpiece10@facebook.com', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Rollo Blay', '1984-05-29', 'Male', 'rblay11@gov.uk', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Graham Brimblecombe', '1999-10-07', 'Male', 'gbrimblecombe12@weather.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Andrea Joontjes', '1999-01-05', 'Female', 'ajoontjes13@craigslist.org', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Perla Caneo', '1993-07-30', 'Male', 'pcaneo14@tumblr.com', 1, 3);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Eloise Phillps', '1987-07-14', 'Female', 'ephillps15@theglobeandmail.com', 3, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Tisha Shakelade', '1984-09-29', 'Male', 'tshakelade16@nhs.uk', 1, 7);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Cristin Brussell', '1974-04-21', 'Male', 'cbrussell17@usgs.gov', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Marleen Pietzner', '1991-07-17', 'Female', 'mpietzner18@t.co', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Gilbert Maneylaws', '2000-05-15', 'Male', 'gmaneylaws19@csmonitor.com', 2, 2);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Thornie Dalby', '1996-04-05', 'Male', 'tdalby1a@reverbnation.com', 3, 4);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Dunc Muggleton', '1966-03-16', 'Female', 'dmuggleton1b@purevolume.com', 1, 7);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Sadie Shellsheere', '1979-08-31', 'Female', 'sshellsheere1c@eepurl.com', 3, 1);
insert into Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values ('Crichton Overstone', '1977-02-09', 'Female', 'coverstone1d@chronoengine.com', 1, 3);

 
INSERT INTO Categories ([Name]) VALUES ('Mobile')
INSERT INTO Categories ([Name]) VALUES ('Cars')
INSERT INTO Categories ([Name]) VALUES ('Noutbooks')

 
INSERT INTO Products ([Name],CategoryId) VALUES ('MI 9',1)
INSERT INTO Products ([Name],CategoryId) VALUES ('Galaxy s10',1)
INSERT INTO Products ([Name],CategoryId) VALUES ('Iphone 12',1)
INSERT INTO Products ([Name],CategoryId) VALUES ('Nokia 62:33',1)


INSERT INTO Products ([Name],CategoryId) VALUES ('Sonata',2)
INSERT INTO Products ([Name],CategoryId) VALUES ('Optima',2)
INSERT INTO Products ([Name],CategoryId) VALUES ('x-Trail',2)
INSERT INTO Products ([Name],CategoryId) VALUES ('Camry',2)
INSERT INTO Products ([Name],CategoryId) VALUES ('Corolla',2)
INSERT INTO Products ([Name],CategoryId) VALUES ('Sportage',2)

INSERT INTO Products ([Name],CategoryId) VALUES ('Acer NITRO',3)
INSERT INTO Products ([Name],CategoryId) VALUES ('MSI GF63',3)
INSERT INTO Products ([Name],CategoryId) VALUES ('Lenovo 55z900',3)
INSERT INTO Products ([Name],CategoryId) VALUES ('Asus 700tb',3)


INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,1)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,1)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,2)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,3)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,4)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,5)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,6)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,7)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,8)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,9)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,10) 
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,1)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,11)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,12)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,13)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,14)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,15)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,16)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,17)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,18)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,19)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,20)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,21)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,22)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,23)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,24)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,25)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,26)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,27)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,28)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,29)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,30)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,31)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,31)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (1,32)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (2,33)
INSERT INTO InterestedBuyers (CategoryId,ClientId) VALUES (3,34)



INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2020-01-10','2020-02-10',1,1)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2020-02-11','2020-03-12',2,2)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2019-06-10','2019-06-20',3,3)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2020-05-01','2020-06-10',1,4)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2021-08-22','2021-09-17',1,5)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2021-04-10','2021-05-10',3,6)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2021-07-10','2021-08-15',1,7)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2020-02-02','2020-03-20',2,8)
INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (10,'2020-09-2','2020-10-4',3,8)

