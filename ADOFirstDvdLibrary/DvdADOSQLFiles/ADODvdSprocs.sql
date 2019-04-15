USE DvdADO

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

		SELECT d.Title, d.DvdId, d.ReleaseYear, d.Notes, e.DirectorName, r.RatingValue
		FROM Dvds d
		INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
		INNER JOIN Ratings r ON d.RatingId = r.RatingId
		WHERE Title LIKE '%' +@Title+ '%'

		GO

	
		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByDirector'
)
BEGIN
	DROP PROCEDURE SearchByDirector
	END
	GO
		CREATE PROCEDURE SearchByDirector(@DirectorName varchar(64))

		AS

		SELECT d.Title, d.DvdId, d.ReleaseYear, d.Notes, d.DirectorId, d.RatingId, e.DirectorName, r.RatingValue
		FROM Dvds d 
		INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
		INNER JOIN Ratings r ON d.RatingId = r.RatingId
		WHERE e.DirectorName LIKE '%' +@DirectorName+ '%'

		GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DvdInsert'
)
BEGIN
	DROP PROCEDURE DvdInsert
	END
	GO
		CREATE PROCEDURE DvdInsert
		@Title varchar(64),
		@ReleaseYear int,
		@Notes varchar(256),
		@DirectorName varchar(64),
		@RatingValue varchar(5)

		AS

		IF NOT EXISTS( SELECT DirectorName FROM Directors WHERE DirectorName = @DirectorName)
		BEGIN
			INSERT INTO Directors(DirectorName) VALUES(@DirectorName) 
		END
		INSERT INTO Dvds(DirectorId, RatingId, Title, ReleaseYear, Notes)
		VALUES ((Select  DirectorId FROM Directors WHERE @DirectorName = DirectorName),
		 (Select RatingId From Ratings Where  @RatingValue = RatingValue), @Title, @ReleaseYear, @Notes)
			
	GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DeleteDvd'
)
BEGIN
	DROP PROCEDURE DeleteDvd
	END
	GO
	
	Create PROCEDURE DeleteDvd(
	@DvdId int
	)
	AS
	DELETE  FROM Dvds WHERE DvdId = @DvdId
	GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'UpdateDvd'
)
BEGIN
	DROP PROCEDURE UpdateDvd
	END
	GO
		CREATE PROCEDURE UpdateDvd
		@DvdId int ,
		@Title varchar(64),
		@ReleaseYear int,
		@Notes varchar(256),
		@DirectorName varchar(64),
		@RatingValue varchar(5)

		AS

		IF NOT EXISTS( SELECT DirectorName FROM Directors WHERE DirectorName = @DirectorName)
		BEGIN
			INSERT INTO Directors(DirectorName) VALUES(@DirectorName) 
		END
		Declare @DI int;
		SET @DI = (Select  DirectorId FROM Directors WHERE @DirectorName = DirectorName);
		Declare @RI int;
		SET @RI =(Select RatingId From Ratings Where  @RatingValue = RatingValue);
		UPDATE Dvds
		SET Title = @Title, ReleaseYear = @ReleaseYear,Notes =@Notes, DirectorId = @DI, RatingId = @RI
		 WHERE DvdId = @DvdId
		 GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAll'
)
BEGIN
	DROP PROCEDURE GetAll
	END
	GO
	CREATE PROCEDURE GetAll

	AS

	SELECT
	d.DvdId,
	 d.Title,
	  d.ReleaseYear,
	 d.Notes,
	 e.DirectorId,
     e.DirectorName,
     r.RatingValue,
	 r.RatingId
	 FROM Dvds d 
	 INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
	 INNER JOIN Ratings r on d.RatingId = r.RatingId
	 GO

	 
		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetById'
)
BEGIN
	DROP PROCEDURE GetById
	END
	GO
	CREATE PROCEDURE GetById(
	@DvdId int
	)

	AS

	SELECT
	 d.Title,
	  d.ReleaseYear,
	  d.DvdId,
	 d.Notes,
	 e.DirectorId,
     e.DirectorName,
	 r.RatingId,
     r.RatingValue 
	 FROM Dvds d 
	 INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
	 INNER JOIN Ratings r on d.RatingId = r.RatingId
	 WHERE d.DvdId = @DvDId
	 GO



	 	IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByYear'
)
BEGIN
	DROP PROCEDURE SearchByYear
	END
	GO
		CREATE PROCEDURE SearchByYear(@ReleaseYear int)

		AS

		SELECT d.Title, d.DvdId, d.ReleaseYear, d.Notes, d.DirectorId, d.RatingId, e.DirectorName, r.RatingValue
		FROM Dvds d 
		INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
		INNER JOIN Ratings r ON d.RatingId = r.RatingId
		WHERE d.ReleaseYear = @ReleaseYear

		GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByRating'
)
BEGIN
	DROP PROCEDURE SearchByRating
	END
	GO
		CREATE PROCEDURE SearchByRating(@RatingValue varchar(64))

		AS

		SELECT d.Title, d.DvdId, d.ReleaseYear, d.Notes, d.DirectorId, d.RatingId, e.DirectorName, r.RatingValue
		FROM Dvds d 
		INNER JOIN Directors e ON d.DirectorId = e.DirectorId	
		INNER JOIN Ratings r ON d.RatingId = r.RatingId
		WHERE r.RatingValue LIKE  @RatingValue

		GO