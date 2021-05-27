USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_GetAllCities')
BEGIN
	DROP PROCEDURE  MVFT_GetAllCities
END 
GO
CREATE PROCEDURE MVFT_GetAllCities
AS
BEGIN
	SELECT 
		c.CityID,
		c.CountryID,
		c.CityName,
		co.CountryName
	FROM Cities c
	INNER JOIN Countries co 
	ON c.CountryID = co.CountryID

END
GO