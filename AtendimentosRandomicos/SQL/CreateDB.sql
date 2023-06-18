-- DB Teste
CREATE TABLE Atendimentos(
senhaAtendimento VARCHAR (25) NOT NULL,
idAtendimento INT NOT NULL,
idHospital INT NOT NULL,
idEspecialidade INT NOT NULL,
idTriagem INT NOT NULL,
idAssociado INT NOT NULL,
tempoAtendimento INT NOT NULL

CONSTRAINT Atendimentos_PK PRIMARY KEY (senhaAtendimento)
)