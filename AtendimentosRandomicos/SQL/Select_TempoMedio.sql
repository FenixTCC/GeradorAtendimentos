-- Select Teste
SELECT idHospital, idEspecialidade, SUM(tempoAtendimento) AS SomaTempoAtendimentos, COUNT(*) AS TotalAtendimentos,
SUM(tempoAtendimento) / COUNT(*) AS TempoMedioAtendimento,
dbo.FN_ConverterMinutosParaHoras(SUM(tempoAtendimento) / COUNT(*)) AS TempoMedioConvertido
FROM Atendimentos
GROUP BY idHospital, idEspecialidade ORDER BY idHospital

CREATE FUNCTION FN_ConverterMinutosParaHoras (@TempoMedio INT)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @TEMPOHORA INT, @TEMPOMINUTO INT, @TEMPOFORMATADO VARCHAR(10)

	SELECT @TEMPOHORA = @TempoMedio / 60
	SELECT @TEMPOMINUTO = @TempoMedio % 60 

	IF @TEMPOMINUTO < 10
	BEGIN
		SELECT @TEMPOFORMATADO = CONCAT(@TEMPOHORA, ':0', @TEMPOMINUTO)
	END
	ELSE
	BEGIN
		SELECT @TEMPOFORMATADO = CONCAT(@TEMPOHORA, ':', @TEMPOMINUTO)
	END

	RETURN @TEMPOFORMATADO

END