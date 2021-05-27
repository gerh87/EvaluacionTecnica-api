USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_GetCityById')
BEGIN
	DROP PROCEDURE  MVFT_GetCityById
END 
GO

CREATE PROCEDURE MVFT_GetCityById (
	@cityId INT
)AS
BEGIN
	SELECT 
		c.CityID,
		c.CountryID,
		c.CityName 
	FROM Cities c
	WHERE c.CityID = @cityId
END