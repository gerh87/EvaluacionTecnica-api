USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_InsertCountry')
BEGIN
	DROP PROCEDURE  MVFT_InsertCountry
END 
GO
CREATE PROCEDURE MVFT_InsertCountry(
	@countryName VARCHAR(30),
	@countryId INT OUTPUT
) AS
BEGIN
	INSERT INTO Countries (
		CountryName
	)Values (
		@countryName
	)

	SET @countryId = @@IDENTITY
END