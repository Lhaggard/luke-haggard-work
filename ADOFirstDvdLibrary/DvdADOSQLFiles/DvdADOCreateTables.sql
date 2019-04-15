USE DvdADO

IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Dvds')
	DROP TABLE Dvds
	GO

	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Directors')
	DROP TABLE Directors
	GO

	IF EXISTS (SELECT * FROM sys.tables WHERE NAME='Ratings')
	DROP TABLE Ratings
	GO



	Create TABLE Ratings
	(
	RatingId int PRIMARY KEY IDENTITY not null,
	RatingValue varchar(5) not null
	)

	Create TABLE Directors
	(
	DirectorId int PRIMARY KEY IDENTITY not null,
	DirectorName varchar(64) not null
	)

	CREATE TABLE Dvds (
	DvdId int PRIMARY KEY IDENTITY not null,
	Title varchar(64) not null,
	ReleaseYear int,
	Notes varchar(256),
	DirectorId int foreign key references Directors(DirectorId),
	RatingId int foreign key references Ratings(RatingId),

	)

	INSERT INTO Directors(DirectorName) VALUES
	( 'Freddy')
	GO


	INSERT INTO Ratings(RatingValue) Values
	('G'),
	('PG'),
	('PG-13'),
	('R')
	GO


	INSERT INTO Dvds( Title, ReleaseYear, Notes, DirectorId, RatingId) VALUES
	('A Dvd', 2019,null,1,1),
	('Dvd 2', 2019, null,1,1)
	GO

	SELECT
	d.DvdId,
	d.Title,
	d.ReleaseYear,
	d.Notes,
	e.DirectorName,
	r.RatingValue
	FROM Dvds d
		INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
		INNER JOIN Ratings r on d.RatingId = r.RatingId


		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByTitle'
)
BEGIN
	DROP PROCEDURE SearchByTitle
	END
	GO
		CREATE PROCEDURE SearchByTitle(@Title varchar(64))

		AS

		SELECT Title, DvdId, ReleaseYear, Notes, DirectorId, RatingId
		FROM Dvds
		WHERE Title LIKE '%' + @Title + '%'

		GO