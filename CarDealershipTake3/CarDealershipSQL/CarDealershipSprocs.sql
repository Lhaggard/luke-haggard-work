USE CarDealership
IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAllVehicles'
)
BEGIN
	DROP PROCEDURE GetAllVehicles
	END
	GO
		CREATE PROCEDURE GetAllVehicles

		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		v.VehicleDescription,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId

		GO


		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'Get20MostExpensive'
)
BEGIN
	DROP PROCEDURE Get20MostExpensive
	END
	GO
		CREATE PROCEDURE Get20MostExpensive

		AS
		SELECT TOP 20  v.SalePrice,
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SalePrice,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		v.VehicleDescription,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		ORDER BY v.SalePrice
		GO



		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAllAvailableVehicles'
)
BEGIN
	DROP PROCEDURE GetAllAvailableVehicles
	END
	GO
		CREATE PROCEDURE GetAllAvailableVehicles
		
		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE v.IsSold = 0
		GO

		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetNewVehicles'
)
BEGIN
	DROP PROCEDURE GetNewVehicles
	END
	GO
		CREATE PROCEDURE GetNewVehicles(@FilteredBy varchar(64))
			
		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE ma.Make  LIKE '%' + @FilteredBy  +'%' OR
		mo.Model  LIKE  '%' + @FilteredBy  +'%' OR
		v.[Year] LIKE '%' + @FilteredBy  +'%'AND
		 v.IsNew = 1
		GO

			
		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetUsedVehicles'
)
BEGIN
	DROP PROCEDURE GetUsedVehicles
	END
	GO
		CREATE PROCEDURE GetUsedVehicles
		(
		@FilteredBy varchar(64)
		)
			
		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE ma.Make  LIKE '%' + @FilteredBy  +'%' OR
		mo.Model  LIKE  '%' + @FilteredBy  +'%' OR
		v.[Year] LIKE '%' + @FilteredBy  +'%'AND
		 v.IsNew = 0
		GO



				IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetByPrice'
)
BEGIN
	DROP PROCEDURE GetByPrice
	END
	GO
		CREATE PROCEDURE GetByPrice
		(
		@MinPrice int,
		@MaxPrice int
		)
			
		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE v.SalePrice >= @MinPrice AND v.SalePrice <= @MaxPrice
		GO

						IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetVehicle'
)
BEGIN
	DROP PROCEDURE GetVehicle
	END
	GO
		CREATE PROCEDURE GetVehicle
		(
		@InventoryNumber int
		)
			
		AS

		SELECT 
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE v.InventoryNumber = @InventoryNumber
		GO


						IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddVehicle'
)
BEGIN
	DROP PROCEDURE AddVehicle
	END
	GO
		CREATE PROCEDURE AddVehicle
		(
		@Year int,
		@SalePrice int, 
		@MSRP int,
		@Milage int,
		@VIN char(17),
		@Description varchar(256),	
		@PicturePath varchar(256),
		@IsManual bit,
		@IsNew bit,
		@IsSold bit,
		@IsFeatured bit,
		@Make varchar(64),
		@ModelId int,
		@InteriorColor varchar(64),
		@ExteriorColor varchar(64),
		@BodyStyle varchar(64)
		)

		AS
		INSERT INTO Vehicles([Year],SalePrice,MSRP,Mileage,VIN,VehicleDescription,PicturePath,IsManualTransmision,
		IsNew, IsFeatured, IsSold, ModelId, InteriorColorId, ExteriorColorId, BodyId)
		VALUES ( @Year,
		@SalePrice, 
		@MSRP,
		@Milage,
		@VIN,
		@Description,	
		@PicturePath,
		@IsManual,
		@IsNew,
		@IsSold,
		@IsFeatured,
		@ModelId,
		(SELECT InteriorColorId FROM InteriorColors WHERE @InteriorColor = InteriorColor),
		(SELECT ExteriorColorId FROM ExteriorColors WHERE @ExteriorColor = ExteriorColor),
		(SELECT BodyID FROM BodyStyles WHERE @BodyStyle = BodyStyle))
		
		GO

						IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DeleteVehicle'
)
BEGIN
	DROP PROCEDURE DeleteVehicle
	END
	GO
		CREATE PROCEDURE DeleteVehicle
		(
		@InventoryNumber int
		)
		AS
		DELETE FROM Vehicles WHERE InventoryNumber = @InventoryNumber
		GO

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddMake'
)
BEGIN
	DROP PROCEDURE AddMake
	END
	GO
	CREATE PROCEDURE AddMake
	(
	@Make varchar(64),
	@AddedBy varchar(64)
	)
	AS

	INSERT INTO Makes(Make,AddedBy,DateAdded)
	VALUES(@Make,@AddedBy,GETDATE())
	GO

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddModel'
)
BEGIN
	DROP PROCEDURE AddModel
	END
	GO
	CREATE PROCEDURE AddModel
	(
	@Model varchar(64),
	@Make int,
	@AddedBy varchar(64)
	)
	AS

	INSERT INTO Models(Model,AddedBy,DateAdded,MakeId)
	VALUES(@Model,@AddedBy,GETDATE(),@Make)
	GO

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetAllSalesInformation'
)
BEGIN
	DROP PROCEDURE GetAllSalesInformation
	END
	GO
	CREATE PROCEDURE GetAllSalesInformation

	AS
	SELECT
	s.[Name],
	s.CustomerEmail,
	s.Phone,
	s.Street1,
	s.Street2,
	s.City,
	s.StateId,
	s.Zipcode,
	s.PurchasePrice,
	s.PurchaseDate,
	u.Email,
	v.InventoryNumber,
	p.PurchaseType

	FROM SalesInformation s 
	INNER JOIN AspNetUsers u on s.UserId = u.Id
	INNER JOIN Vehicles v on s.InventoryId = v.InventoryNumber
	INNER JOIN PurchaseTypes p on s.PurchaseTypeId = p.PurchaseTypeId
	GO

	
	        IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetSalesByDate'
)
BEGIN
    DROP PROCEDURE GetSalesByDate
    END
    GO
    CREATE PROCEDURE GetSalesByDate
    (
    @StartDate date,
    @EndDate date,
    @User varchar(256)
    )
    AS
    SELECT
	
    SUM(s.PurchasePrice)'ValueOfSales',
    COUNT(*)'TotalSold',
	s.UserId


    FROM SalesInformation s 
    WHERE s.PurchaseDate BETWEEN @StartDate AND @EndDate
    AND (s.UserId LIKE CONCAT('%', @User, '%'))
	GROUP BY s.UserId
    GO
    EXEC GetSalesByDate '1999-04-04', '2999-04-04',''

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'DeleteSpecial'
)
BEGIN
	DROP PROCEDURE DeleteSpecial
	END
	GO
		CREATE PROCEDURE DeleteSpecial
		(
		@SpecialId int
		)
		AS
		DELETE FROM Specials WHERE SpecialId = @SpecialId
		GO

					IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddSpecial'
)
BEGIN
	DROP PROCEDURE AddSpecial
	END
	GO
	CREATE PROCEDURE AddSpecial
	(
	@Title varchar(64),
	@Description varchar(256)
	)
	AS

	INSERT INTO Specials(Title,[Description])
	VALUES(@Title,@Description)
	GO

						IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetSpecials'
)
BEGIN
	DROP PROCEDURE GetSpecials
	END
	GO
		CREATE PROCEDURE GetSpecials		
			
		AS

		SELECT 
		s.Title,
		s.[Description],
		s.SpecialId

		FROM Specials s
		GO

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetMakes'
)
BEGIN
	DROP PROCEDURE GetMakes
	END
	GO
		CREATE PROCEDURE GetMakes		
			
		AS

		SELECT 
		m.DateAdded,
		m.AddedBy,
		m.Make,
		m.MakeId

		FROM Makes m
		GO

		
							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetModels'
)
BEGIN
	DROP PROCEDURE GetModels
	END
	GO
		CREATE PROCEDURE GetModels	
			
		AS

		SELECT 
		m.Model,
		m.AddedBy,
		m.DateAdded,
		m.ModelId,
		ma.Make

		FROM Models m
		INNER JOIN Makes ma ON m.MakeId = ma.MakeId
		GO

								IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetInventory'
)
BEGIN
	DROP PROCEDURE GetInventory
	END
	GO
		CREATE PROCEDURE GetInventory	
			
		AS

		SELECT 
		v.[Year],v.IsNew,mo.Model,ma.Make,
		COUNT(*)'NumberInStock',SUM(v.MSRP)'TotalValue'
		
		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma on mo.MakeId = ma.MakeId
		GROUP BY isNew,Make, Model,[Year]
		GO


		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'UpdateVehicle'
)
BEGIN
	DROP PROCEDURE UpdateVehicle
	END
	GO
		CREATE PROCEDURE UpdateVehicle
		@InventoryNumber int,
		@BodyStyle varchar(64),
		@IsManualTransmision bit,
		@VIN varchar(17),
		@SalePrice int,
		@MSRP int,
		@VehicleDescription varchar(256),
		@ModelId int,
		@Year int,
		@InteriorColor varchar(64),
		@ExteriorColor varchar(64),
		@IsNew bit,
		@Mileage int,
		@PicturePath varchar (256) null,
		@IsFeatured bit,
		@IsSold bit

		AS
		DECLARE @ECI int;
		SET @ECI = (SELECT ExteriorColorId FROM ExteriorColors WHERE @ExteriorColor = ExteriorColor);
		DECLARE @ICI int;
		SET @ICI = (SELECT InteriorColorId FROM InteriorColors WHERE @InteriorColor = InteriorColor);
		DECLARE @BI int;
		SET @BI = (SELECT BodyId FROM BodyStyles WHERE @BodyStyle = BodyStyle);
		UPDATE Vehicles 
		SET   BodyId = @BI, IsManualTransmision = @IsManualTransmision,
		VIN =@VIN, SalePrice = @SalePrice, MSRP = @MSRP, VehicleDescription = @VehicleDescription, ModelId = @ModelId,
		[Year] = @Year, InteriorColorId = @ICI, ExteriorColorId = @ECI, IsNew = @IsNew, Mileage = @Mileage, PicturePath = @PicturePath,
		IsFeatured = @IsFeatured, IsSold = @IsSold
		WHERE Vehicles.InventoryNumber = @InventoryNumber

			GO

				IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetFeatured'
)
BEGIN
	DROP PROCEDURE GetFeatured
	END
	GO
		CREATE PROCEDURE GetFeatured

		AS
		SELECT
		v.InventoryNumber,
		v.IsManualTransmision,
		v.VIN,
		v.SALEPRICE,
		v.MSRP,
		v.VehicleDescription,
		v.[Year],
		v.IsNew,
		v.Mileage,
		v.PicturePath,
		v.IsFeatured,
		ma.Make,
		mo.Model,
		ec.ExteriorColor,
		ic.InteriorColor,
		b.BodyStyle,
		v.IsSold

		FROM Vehicles v
		INNER JOIN Models mo ON v.ModelId = mo.ModelId
		INNER JOIN Makes ma ON mo.MakeId = ma.MakeId
		INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
		INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
		INNER JOIN BodyStyles b on b.BodyId = v.BodyId
		WHERE v.IsFeatured = 1
		GO

		
				IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetBodyStyles'
)
BEGIN
	DROP PROCEDURE GetBodyStyles
	END
	GO
		CREATE PROCEDURE GetBodyStyles
		AS
		SELECT
		b.BodyStyle,
		b.BodyId
		From BodyStyles b
GO


							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetModelsByMake'
)
BEGIN
	DROP PROCEDURE GetModelsByMake
	END
	GO
		CREATE PROCEDURE GetModelsByMake (
		@Id int
		)			
		AS

		SELECT 
		m.Model,
		m.ModelId,
		m.AddedBy,
		m.DateAdded,
		ma.Make

		FROM Models m
		INNER JOIN Makes ma ON m.MakeId = ma.MakeId
		WHERE ma.MakeId = @Id
		GO

			IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetExterior'
)
BEGIN
	DROP PROCEDURE GetExterior
	END
	GO
		CREATE PROCEDURE GetExterior
		AS
		SELECT
		e.ExteriorColor,
		e.ExteriorColorId
		From ExteriorColors e
GO


		IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetInterior'
)
BEGIN
	DROP PROCEDURE GetInterior
	END
	GO
		CREATE PROCEDURE GetInterior
		AS
		SELECT
		i.InteriorColor,
		i.InteriorColorID
		From InteriorColors i
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUsers')
      DROP PROCEDURE GetUsers
GO

CREATE PROCEDURE GetUsers
AS
BEGIN 
	SELECT a.Id, a.Email
	FROM AspNetUsers a
END
GO
	

	IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'SearchVehicles')
     DROP PROCEDURE SearchVehicles
GO

CREATE PROCEDURE SearchVehicles(
    @SearchTerm varchar(max),
    @MinPrice int,
    @MaxPrice int,
    @StartDate int,
    @EndDate int,
	@Condition bit
)
AS
BEGIN
    SELECT TOP(20) v.InventoryNumber, v.[Year], v.ModelID, b.BodyStyle, 
	v.IsManualTransmision, ec.ExteriorColor, v.InteriorColorID, v.Mileage, 
	v.VIN, v.SalePrice, v.MSRP, v.PicturePath, v.VehicleDescription, ic.InteriorColor,
	v.IsFeatured, v.IsNew, v.IsSold, mo.Model, ma.Make
    FROM Vehicles v
    INNER JOIN Models mo ON v.ModelID = mo.ModelID
    INNER JOIN Makes ma ON mo.MakeID = ma.MakeID
	INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
	INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
	INNER JOIN BodyStyles b on b.BodyId = v.BodyId
    WHERE v.[Year] BETWEEN @StartDate AND @EndDate AND
          v.SalePrice BETWEEN @MinPrice AND @MaxPrice AND
          v.IsNew = @Condition AND
		  v.IsSold = 0 AND
          (v.[Year] LIKE CONCAT('%', @SearchTerm, '%') OR
          ma.Make LIKE CONCAT('%', @SearchTerm, '%') OR
          mo.Model LIKE CONCAT('%', @SearchTerm, '%'))
    ORDER BY v.MSRP DESC
END
GO


	IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'SalesSearchVehicles')
     DROP PROCEDURE SalesSearchVehicles
GO

CREATE PROCEDURE SalesSearchVehicles(
    @SearchTerm varchar(max),
    @MinPrice int,
    @MaxPrice int,
    @StartDate int,
    @EndDate int
)
AS
BEGIN
    SELECT TOP(20) v.InventoryNumber, v.[Year], v.ModelID, b.BodyStyle, 
	v.IsManualTransmision, ec.ExteriorColor, v.InteriorColorID, v.Mileage, 
	v.VIN, v.SalePrice, v.MSRP, v.PicturePath, v.VehicleDescription, ic.InteriorColor,
	v.IsFeatured, v.IsNew, v.IsSold, mo.Model, ma.Make
    FROM Vehicles v
    INNER JOIN Models mo ON v.ModelID = mo.ModelID
    INNER JOIN Makes ma ON mo.MakeID = ma.MakeID
	INNER JOIN ExteriorColors ec on ec.ExteriorColorId = v.ExteriorColorId
	INNER JOIN InteriorColors ic on ic.InteriorColorID = v.InteriorColorId
	INNER JOIN BodyStyles b on b.BodyId = v.BodyId
    WHERE v.[Year] BETWEEN @StartDate AND @EndDate AND
          v.SalePrice BETWEEN @MinPrice AND @MaxPrice AND
		  v.IsSold = 0 AND
          (v.[Year] LIKE CONCAT('%', @SearchTerm, '%') OR
          ma.Make LIKE CONCAT('%', @SearchTerm, '%') OR
          mo.Model LIKE CONCAT('%', @SearchTerm, '%'))
    ORDER BY v.MSRP DESC
END
GO


	IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
  WHERE ROUTINE_NAME = 'GetPurchaseTypes')
     DROP PROCEDURE GetPurchaseTypes
GO

CREATE PROCEDURE GetPurchaseTypes
AS
SELECT 
p.PurchaseType,
p.PurchaseTypeId
FROM PurchaseTypes p
GO

							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'AddSale'
)
BEGIN
	DROP PROCEDURE AddSale
	END
	GO
	CREATE PROCEDURE AddSale
	(
	@Name varchar(64),
	@Email nvarchar(128),
	@Phone int,
	@Street1 nvarchar(128),
	@Street2 nvarchar(128),
	@City nvarchar(128),
	@StateId char(2),
	@ZipCode int,
	@PurchasePrice int,
	@PurchaseTypeId int,
	@SoldBy nvarchar(128),
	@InventoryNumber int
	)
	AS	
	INSERT INTO SalesInformation(
	[Name],
	CustomerEmail,
	Phone,
	Street1,
	Street2,
	City,
	StateId,
	Zipcode,
	PurchasePrice,
    PurchaseDate,
	InventoryId,
	PurchaseTypeId,
	UserId
)
	VALUES(
	@Name,
	@Email,
	@Phone,
	@Street1,
	@Street2,
	@City,
	@StateId,
	@ZipCode,
	@PurchasePrice,
	GETDATE(),
	@InventoryNumber,
	@PurchaseTypeId,
	@SoldBy
	)
	
	UPDATE Vehicles
	SET IsSold = 1
	WHERE InventoryNumber = @InventoryNumber
	GO


							IF EXISTS (
    SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
    WHERE ROUTINE_NAME = 'GetNextInventoryNumber'
)
BEGIN
	DROP PROCEDURE GetNextInventoryNumber
	END
	GO
	CREATE PROCEDURE GetNextInventoryNumber
	AS
	SELECT
		CAST(IDENT_CURRENT('Vehicles') + IDENT_INCR('Vehicles') AS INT)
		AS
		'NextInventoryNumber'
		GO

	