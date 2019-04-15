if exists(select * from sys.databases where name = N'HotelReservations')
begin
	DROP DATABASE DvdLibraryADO;
end
go

create database DvdLibraryADO
go

use DvdLibraryADO
go

create table Director
(
directorId int PRIMARY KEY,
[name] varchar(64)
)
go

create table Rating
(
ratingId int PRIMARY KEY,
value varchar(6)
)
go

create table Dvd
(
dvdId int PRIMARY KEY,
title varchar(64),
releaseYear int,
directorId int FOREIGN KEY REFERENCES Director(directorId),
ratingId int FOREIGN KEY REFERENCES Rating(ratingId),
notes varchar(256)
)
go