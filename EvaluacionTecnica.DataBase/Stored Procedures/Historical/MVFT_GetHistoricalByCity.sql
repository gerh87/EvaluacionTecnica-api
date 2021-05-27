USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_GetHistoricalByCity')
BEGIN
	DROP PROCEDURE  MVFT_GetHistoricalByCity
END 
GO

CREATE PROCEDURE MVFT_GetHistoricalByCity (
	@cityID INT
)AS
BEGIN
	SELECT 
		c.CityName,
		co.CountryName,
		h.Temperature,
		h.ThermalSensation,
		h.CreateDate
	FROM Historical h
	INNER JOIN Cities c ON c.CityID = h.CityID
	INNER JOIN Countries co ON co.CountryID = c.CountryID
	WHERE h.CityID = @cityID
	
END