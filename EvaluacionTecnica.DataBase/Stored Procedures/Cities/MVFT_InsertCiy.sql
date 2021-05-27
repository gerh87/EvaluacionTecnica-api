USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_InsertCiy')
BEGIN
	DROP PROCEDURE  MVFT_InsertCiy
END 
GO
CREATE PROCEDURE MVFT_InsertCiy(
	@countryId INT,
	@cityName VARCHAR(30),
	@cityId INT OUTPUT
)AS
BEGIN
	INSERT INTO Cities (
		CountryID,
		CityName
	)VALUES(
		@countryId,
		@cityName
	)

	SET @cityId = @@IDENTITY
END