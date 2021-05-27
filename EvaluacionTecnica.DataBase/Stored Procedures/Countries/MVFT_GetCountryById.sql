USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_GetCountryById')
BEGIN
	DROP PROCEDURE  MVFT_GetCountryById
END 
GO

CREATE PROCEDURE MVFT_GetCountryById (
	@countryId INT
)AS
BEGIN

	SELECT 
		c.CountryID,
		c.CountryName
	FROM Countries c
	WHERE c.CountryID = @countryId
END
