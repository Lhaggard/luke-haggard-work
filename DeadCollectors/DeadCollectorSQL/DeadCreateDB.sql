USE master 
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DeadCollector')
DROP DATABASE DeadCollector

CREATE DATABASE DeadCollector
GO
