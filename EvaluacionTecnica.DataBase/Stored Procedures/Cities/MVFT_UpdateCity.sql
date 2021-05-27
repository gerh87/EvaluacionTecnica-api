USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_UpdateCity')
BEGIN
	DROP PROCEDURE  MVFT_UpdateCity
END 
GO
CREATE PROCEDURE MVFT_UpdateCity (
	@cityId INT,
	@countryId INT,
	@cityName VARCHAR(30)
)AS
BEGIN 
	UPDATE c SET 
	c.CountryID = @countryId,
	c.CityName = @cityName
	FROM Cities c
	WHERE c.CityID = @cityId
	
	SELECT 
		c.CityID,
		c.CountryID,
		c.CityName 
	FROM Cities c
	WHERE c.CityID = @cityId
END