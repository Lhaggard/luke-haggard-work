USE master 
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='CarDealership')
DROP DATABASE CarDealership

CREATE DATABASE CarDealership
GO
