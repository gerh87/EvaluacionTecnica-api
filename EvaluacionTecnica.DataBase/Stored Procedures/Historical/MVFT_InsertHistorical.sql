USE MVFEvaluacionTecnicaPH
GO
IF EXISTS (SELECT 1 FROM sysobjects WHERE type = 'P' AND name = 'MVFT_InsertHistorical')
BEGIN
	DROP PROCEDURE  MVFT_InsertHistorical
END 
GO
CREATE PROCEDURE MVFT_InsertHistorical (
	@cityId INT,
	@temp DECIMAL(6,1),
	@thermalSensation DECIMAL(6,1),
	@historicalId INT OUTPUT
)AS
BEGIN
		INSERT INTO Historical (
			CityID,
			Temperature,
			ThermalSensation,
			CreateDate
		)
		VALUES(
			@cityId,
			@temp,
			@thermalSensation,
			GETDATE()
		)

		
		SET @historicalId = @@IDENTITY
END