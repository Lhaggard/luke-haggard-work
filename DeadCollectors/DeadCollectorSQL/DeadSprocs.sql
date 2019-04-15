Use DeadCollector

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetApprovedPosts'
)
BEGIN
	DROP PROCEDURE GetApprovedPosts
	END
	GO
		CREATE PROCEDURE GetApprovedPosts
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail,
		p.PicturePath

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE p.IsApproved = 1
		ORDER BY p.PostId DESC
		GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetPendingPosts'
)
BEGIN
	DROP PROCEDURE GetPendingPosts
	END
	GO
		CREATE PROCEDURE GetPendingPosts
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		p.UserEmail,
		c.Category,
		p.PicturePath
		

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE p.IsApproved = 0
		ORDER BY p.PostId 
		GO
		exec GetPendingPosts

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetPost'
)
BEGIN
	DROP PROCEDURE GetPost
	END
	GO
		CREATE PROCEDURE GetPost(@PostId int)
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		p.UserEmail,
		p.PicturePath,
		c.Category

		
		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE p.PostId = @PostId
		GO
		exec GetPost 1
		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByTag'
)

BEGIN
	DROP PROCEDURE SearchByTag
	END
	GO
		CREATE PROCEDURE SearchByTag
		(
		@Tag varchar(128)
		)
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		p.UserEmail,
		c.Category

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE 
		p.Post LIKE '%' + @Tag + '%'
		GO

			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddPost'
)
BEGIN
	DROP PROCEDURE AddPost
	END
	GO
		CREATE PROCEDURE AddPost
		(
		@Post varchar(max),
		@IsApproved bit,
		@CategoryId int,
		@PostedBy nvarchar(128),
		@PicturePath NVARCHAR(256)
		)
		AS
	 
	 INSERT INTO Posts(Post, DatePosted, IsApproved, CategoryId, UserEmail, PicturePath)
	 VALUES(@Post,GetDate(),@IsApproved,@CategoryId,
	 (SELECT Id FROM AspNetUsers WHERE AspNetUsers.Email = @PostedBy), @PicturePath)
	 GO

	 
			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'UpdatePost'
)
BEGIN
	DROP PROCEDURE UpdatePost
	END
	GO
		CREATE PROCEDURE UpdatePost
		(
		@PostId int,
		@Post varchar(max),
		@IsApproved bit,
		@Category varchar(64),
		@UserEmail nvarchar(128),
		@PicturePath nvarchar(256)
		)
		AS
		DECLARE @CI int;
	 SET @CI  = (SELECT CategoryId FROM Categories WHERE Categories.Category = @Category)
	 UPDATE Posts
	SET Post = @Post,  IsApproved = @IsApproved,CategoryId =@CI
	WHERE PostId = @PostId
	 GO


	 
			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DeletePost'
)
BEGIN
	DROP PROCEDURE DeletePost
	END
	GO
		CREATE PROCEDURE DeletePost
		(@PostId int)
		AS
		DELETE FROM Posts WHERE PostId = @PostId
		GO


			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'SearchByCategory'
)

BEGIN
	DROP PROCEDURE SearchByCategory
	END
	GO
		CREATE PROCEDURE SearchByCategory
		(
		@Category varchar(128),
		@Tag varchar(128)
		)
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail,
		p.PicturePath

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE 
		p.IsApproved = 1 AND
	c.Category LIKE '%' +@Category+ '%' AND
		p.Post LIKE '%' + @Tag + '%'
		GO

			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'OrderNewestFirst'
)

BEGIN
	DROP PROCEDURE OrderNewestFirst
	END
	GO
		CREATE PROCEDURE OrderNewestFirst
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		ORDER BY p.DatePosted;
		GO


				IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'OrderOldestFirst'
)

BEGIN
	DROP PROCEDURE OrderOldestFirst
	END
	GO
		CREATE PROCEDURE OrderOldestFirst
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		ORDER BY p.DatePosted DESC;
		GO

				IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetThreeMostRecentPosts'
)

BEGIN
	DROP PROCEDURE GetThreeMostRecentPosts
	END
	GO
		CREATE PROCEDURE GetThreeMostRecentPosts
		AS
		SELECT TOP(3)
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail
		
		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE p.IsApproved = 1
		ORDER BY p.PostId DESC;

		GO
		exec GetThreeMostRecentPosts

					IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetCategories'
)

BEGIN
	DROP PROCEDURE GetCategories
	END
	GO
		CREATE PROCEDURE GetCategories
		AS
		SELECT
		c.Category,
		c.CategoryId
		From Categories c
		GO

		
					IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'ApprovePost'
)

BEGIN
	DROP PROCEDURE ApprovePost
	END
	GO
		CREATE PROCEDURE ApprovePost(@PostId int)
		AS
		 UPDATE Posts
		 SET IsApproved = 1
		 WHERE PostId = @PostId
		GO		


					IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAllCategories'
)

BEGIN
	DROP PROCEDURE GetAllCategories
	END
	GO
	CREATE PROCEDURE GetAllCategories
	AS 
	SELECT
	c.Category,
	c.CategoryId
	FROM Categories c
	GO
	exec GetAllCategories

	IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'NextPostId'
)
BEGIN
	DROP PROCEDURE NextPostId
	END
	GO
		CREATE PROCEDURE NextPostId
		AS
		SELECT
		CAST(IDENT_CURRENT('Posts') + IDENT_INCR('Posts') AS INT)
		AS
		'NextPostId'
		GO


		
	IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAboutUs'
)
BEGIN
	DROP PROCEDURE GetAboutUs
	END
	GO
		CREATE PROCEDURE GetAboutUs
		AS
		SELECT
		About 
		FROM
		AboutUs
		GO


			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'EditAboutUs'
)
BEGIN
	DROP PROCEDURE EditAboutUs
	END
	GO
		CREATE PROCEDURE EditAboutUs
		(
		@About nvarchar(max)
		)
		AS
		UPDATE AboutUs
	    SET About = @About
		GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetRoles')
      DROP PROCEDURE GetRoles
GO

CREATE PROCEDURE GetRoles
AS
BEGIN
	SELECT *
	FROM AspNetRoles
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUsers')
      DROP PROCEDURE GetUsers
GO

CREATE PROCEDURE GetUsers
AS
BEGIN 
	SELECT anu.Id, anu.Email
	FROM AspNetUsers anu
END
GO

IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetRejectedPosts'
)
BEGIN
	DROP PROCEDURE GetRejectedPosts
	END
	GO
		CREATE PROCEDURE GetRejectedPosts(@UserEmail nvarchar(128))
		AS
		SELECT
		p.Post,
		p.PostId,
		p.DatePosted,
		p.IsApproved,
		c.Category,
		p.UserEmail,
		p.PicturePath,
		p.Rejected

		FROM Posts p
		INNER JOIN Categories c ON   p.CategoryId = c.CategoryId
		WHERE p.Rejected = 1 AND
		p.UserEmail = @UserEmail
		ORDER BY p.PostId DESC
		GO