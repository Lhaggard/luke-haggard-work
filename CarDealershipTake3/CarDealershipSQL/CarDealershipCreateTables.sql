use CarDealership

IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Specials')
	DROP TABLE Specials
	GO

	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='ContactInformation')
	DROP TABLE ContactInformation
	GO


IF EXISTS (SELECT * FROM sys.tables WHERE NAME='SalesInformation')
	DROP TABLE SalesInformation
	GO

	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='PurchaseTypes')
	DROP TABLE PurchaseTypes
	GO

IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Vehicles')
	DROP TABLE Vehicles
	GO

	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='BodyStyles')
	DROP TABLE BodyStyles
	GO


	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Models')
	DROP TABLE Models
	GO


	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Makes')
	DROP TABLE Makes
	GO


	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='InteriorColors')
	DROP TABLE InteriorColors
	GO


	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='ExteriorColors')
	DROP TABLE ExteriorColors
	GO


	CREATE TABLE ExteriorColors
(
ExteriorColorId int PRIMARY KEY IDENTITY not null,
ExteriorColor varchar(64)
)


	CREATE TABLE InteriorColors
(
InteriorColorID int PRIMARY KEY IDENTITY not null,
InteriorColor varchar(64)
)

	CREATE TABLE Makes
(
MakeId int PRIMARY KEY IDENTITY not null,
Make varchar(64) not null,
AddedBy varchar(64),
DateAdded date
)

CREATE TABLE Models
(
ModelId int PRIMARY KEY IDENTITY not null,
MakeId int FOREIGN KEY REFERENCES Makes(MakeId) not null,
AddedBy varchar(64),
DateAdded date,
Model varchar(64) not null
)
CREATE TABLE BodyStyles
(
BodyId int PRIMARY KEY IDENTITY not null,
BodyStyle varchar(64)
)


CREATE TABLE Vehicles
(
InventoryNumber int PRIMARY KEY IDENTITY not null,
BodyId int FOREIGN KEY REFERENCES Bodystyles(BodyId) not null,
IsManualTransmision bit,
VIN varchar(17),
SalePrice int,
MSRP int,
VehicleDescription varchar(512),
ModelId int Foreign KEY REFERENCES Models(ModelId) not null,
[Year] int,
InteriorColorId int FOREIGN KEY REFERENCES InteriorColors(InteriorColorId) not null,
ExteriorColorId int FOREIGN KEY REFERENCES ExteriorColors(ExteriorColorId) not null,
IsNew bit,
Mileage int,
PicturePath varchar(256),
IsFeatured bit,
IsSold bit
)

CREATE TABLE PurchaseTypes
(
PurchaseTypeId int PRIMARY KEY IDENTITY not null,
PurchaseType varchar(64),
)


CREATE TABLE SalesInformation
(
[Name] varchar(64),
CustomerEmail varchar(64),
Phone varchar(64),
Street1 varchar(64),
Street2 varchar(64),
City varchar(64),
StateId varchar(2),
Zipcode int,
PurchasePrice int,
PurchaseDate date,
SaleId int PRIMARY KEY IDENTITY not null,
UserId nvarchar(256) FOREIGN KEY REFERENCES AspNetUsers(UserName) not null,
InventoryId int FOREIGN KEY REFERENCES Vehicles(InventoryNumber) not null,
PurchaseTypeId int FOREIGN KEY REFERENCES PurchaseTypes(PurchaseTypeId) not null
)

CREATE TABLE Specials
(
SpecialId int PRIMARY KEY IDENTITY not null,
[Description] varchar(512),
Title varchar(124)
)

INSERT INTO Specials([Description], Title)
VALUES('A Great Deal!','Its A Deal')

INSERT INTO Specials([Description], Title)
VALUES('Another Great Deal!','Its Another Deal')

INSERT INTO Specials([Description], Title)
VALUES('A Great Deal!','Its A Deal')

INSERT INTO ExteriorColors(ExteriorColor)
VALUES('Brass')

INSERT INTO ExteriorColors(ExteriorColor)
VALUES('Black')

INSERT INTO ExteriorColors(ExteriorColor)
VALUES('Wood')

INSERT INTO InteriorColors(InteriorColor)
VALUES('Red')

INSERT INTO InteriorColors(InteriorColor)
VALUES('Green')

INSERT INTO InteriorColors(InteriorColor)
VALUES('Purple')

INSERT INTO Makes(Make)
VALUES('Thermoplan')

INSERT INTO Makes(Make)
VALUES('Thunder & Colt')

INSERT INTO Makes(Make)
VALUES('Raven Industries')

INSERT INTO Makes(Make)
VALUES('Zeppelin Luftschifftechnik')

INSERT INTO Makes(Make)
VALUES('NightRider')

INSERT INTO MODELS(MakeId,Model)
Values(1,'Albatross')

INSERT INTO MODELS(MakeId,Model)
Values(1,'Paradox')

INSERT INTO MODELS(MakeId,Model)
Values(1,'Herald')

INSERT INTO MODELS(MakeId,Model)
Values(2,'Clydesdale')

INSERT INTO MODELS(MakeId,Model)
Values(2,'Mustang')

INSERT INTO MODELS(MakeId,Model)
Values(2,'Gypsy')

INSERT INTO MODELS(MakeId,Model)
Values(3,'Annabel')

INSERT INTO MODELS(MakeId,Model)
Values(3,'Alone')

INSERT INTO MODELS(MakeId,Model)
Values(3,'Dream')

INSERT INTO MODELS(MakeId,Model)
Values(4,'Fernweh')

INSERT INTO MODELS(MakeId,Model)
Values(4,'Lz-219')

INSERT INTO MODELS(MakeId,Model)
Values(4,'Weltshmerz')

INSERT INTO MODELS(MakeId,Model)
Values(5,'Nightingale')

INSERT INTO MODELS(MakeId,Model)
Values(5,'Nightmare')

INSERT INTO MODELS(MakeId,Model)
Values(5,'Nightfall')

INSERT INTO BodyStyles(BodyStyle)
VALUES('Dirigible')

INSERT INTO BodyStyles(BodyStyle)
VALUES('Airship')

INSERT INTO BodyStyles(BodyStyle)
VALUES('Blimp')

INSERT INTO BodyStyles(BodyStyle)
VALUES('Aerostat')

INSERT INTO BodyStyles(BodyStyle)
VALUES('Balloon')

INSERT INTO Vehicles(BodyId,IsManualTransmision,Vin,SalePrice, MSRP,VehicleDescription,ModelId,[Year],InteriorColorId,ExteriorColorId,IsNew,Mileage,PicturePath,IsFeatured,IsSold)
VALUES (1,1,'1FALP6539TK196548',11995,12995,'Its nice',1,2003,1,1,1,1,null,1,0)

INSERT INTO Vehicles(BodyId,IsManualTransmision,Vin,SalePrice, MSRP,VehicleDescription,ModelId,[Year],InteriorColorId,ExteriorColorId,IsNew,Mileage,PicturePath,IsFeatured,IsSold)
VALUES (2,1,'WBADE6322VBW51982',11995,12995,'Its nice',2,2003,1,1,1,1,null,1,0)

INSERT INTO Vehicles(BodyId,IsManualTransmision,Vin,SalePrice, MSRP,VehicleDescription,ModelId,[Year],InteriorColorId,ExteriorColorId,IsNew,Mileage,PicturePath,IsFeatured,IsSold)
VALUES (1,1,'1FALP6539TK196548',11995,12995,'Its nice',1,2003,1,1,0,1,null,1,0)

INSERT INTO Vehicles(BodyId,IsManualTransmision,Vin,SalePrice, MSRP,VehicleDescription,ModelId,[Year],InteriorColorId,ExteriorColorId,IsNew,Mileage,PicturePath,IsFeatured,IsSold)
VALUES (2,1,'WBADE6322VBW51982',11995,12995,'Its nice',2,2003,1,1,0,1,null,1,0)

INSERT INTO Vehicles(BodyId,IsManualTransmision,Vin,SalePrice, MSRP,VehicleDescription,ModelId,[Year],InteriorColorId,ExteriorColorId,IsNew,Mileage,PicturePath,IsFeatured,IsSold)
VALUES (3,2,'WBADE6322VBW51982',11995,12995,'Its nice',6,2003,3,3,0,1,null,1,0)

INSERT INTO PurchaseTypes(PurchaseType)
VALUES('Bank Finance')

INSERT INTO PurchaseTypes(PurchaseType)
VALUES('Dealer Finance')

INSERT INTO PurchaseTypes(PurchaseType)
VALUES('Cash')

INSERT INTO SalesInformation([Name],CustomerEmail,Phone,Street1,City,StateId,Zipcode,PurchasePrice,PurchaseDate,UserId,InventoryId,PurchaseTypeId)
VALUES('Fred','fred@fred.com','8019232834','a street','a city','UT',85555,11995,GETDATE(), 'admin@admin.com', 3,1)