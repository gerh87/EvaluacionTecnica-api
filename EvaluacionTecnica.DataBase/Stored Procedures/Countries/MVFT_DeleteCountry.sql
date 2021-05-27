USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_DeleteCountry')
BEGIN
	DROP PROCEDURE  MVFT_DeleteCountry
END 
GO

CREATE PROCEDURE MVFT_DeleteCountry (
	@countryId INT
)AS
BEGIN

	DELETE FROM Countries
	WHERE CountryID = @countryId
END