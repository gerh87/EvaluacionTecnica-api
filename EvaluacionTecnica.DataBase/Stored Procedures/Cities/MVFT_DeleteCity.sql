USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_DeleteCity')
BEGIN
	DROP PROCEDURE  MVFT_DeleteCity
END 
GO

CREATE PROCEDURE MVFT_DeleteCity (
	@cityId INT
)AS
BEGIN
	DELETE FROM Cities WHERE CityID = @cityId
END