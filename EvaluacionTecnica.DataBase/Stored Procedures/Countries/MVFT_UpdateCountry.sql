USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_UpdateCountry')
BEGIN
	DROP PROCEDURE  MVFT_UpdateCountry
END 
GO
CREATE PROCEDURE MVFT_UpdateCountry (
	@countryId INT,
	@countryName VARCHAR(30)
)AS
BEGIN
	UPDATE c SET c.CountryName = @countryName
	FROM Countries c 
	WHERE c.CountryID = @countryId

	SELECT 
		c.CountryID,
		c.CountryName
	FROM Countries c
	WHERE c.CountryID = @countryId
END