USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_GetAllCountries')
BEGIN
	DROP PROCEDURE  MVFT_GetAllCountries
END 
GO
CREATE PROCEDURE MVFT_GetAllCountries 
AS
BEGIN
	SELECT 
		c.CountryID,
		c.CountryName
	FROM Countries c
END