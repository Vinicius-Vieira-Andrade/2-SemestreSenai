CREATE  DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO

CREATE TABLE Estudio
(
	IdEstudio INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Jogo
(
	IdJogo INT PRIMARY KEY IDENTITY
	,IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
	,Nome VARCHAR(100) NOT NULL
	,Descricao VARCHAR(100) NOT NULL
	,DataLancamento DATE NOT NULL
	,Valor SMALLMONEY NOT NULL
);
GO

CREATE TABLE TiposUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
	,Email VARCHAR(100) NOT NULL UNIQUE
	,Senha VARCHAR (100) NOT NULL
);
GO

select * from Jogo