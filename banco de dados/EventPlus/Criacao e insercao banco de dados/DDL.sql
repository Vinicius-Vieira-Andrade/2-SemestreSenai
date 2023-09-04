--DDL
--Criar banco de dados
/*Create database [Event+ Tarde]
use [Event+ Tarde]*/

--criar tabelas
create table [Tipo De Usuario]
(
	IdTipoUsuario int primary key identity,
	TituloTipoUsuario varchar(30) not null unique
)

create table [Tipos De Evento]
(
	IdTiposEvento int primary key identity,
	TituloTipoEvento varchar (30) not null
)

--alter table [Tipos De Evento] add unique (TituloTipoEvento) --adiciona unique na column

create table Instituicao
(
	IdInstituicao int primary key identity,
	CNPJ char (14) not null unique,
	Endereco varchar(200) not null,
	NomeFantasia varchar (50) not null
)


create table Usuario
(
	IdUsuario int primary key identity,
	IdTipoUsuario int foreign key references [Tipo De Usuario](IdTipoUsuario) not null,
	Nome varchar(30) not null,
	Email varchar(50) not null unique,
	Senha varchar(20) not null
)

create table Evento
(
	IdEvento int primary key identity,
	IdInstituicao int foreign key references Instituicao(IdInstituicao) not null,
	IdTiposEvento int foreign key references [Tipos De Evento](IdTiposEvento) not null,
	Nome varchar(100) not null,
	Descricao varchar(150) not null,
	[Data de Evento] date not null, --data
	[Horario do Evento] time not null --horario
)

create table [Presencas do Evento]
(
	IdPresencaEvento int primary key identity,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	IdEvento int foreign key references Evento(IdEvento) not null,
	Confirmação bit default(0) --o valor padrao é 'não' outro valor será positivo
)

create table ComentarioEvento
(
	IdComentario int primary key identity,
	IdEvento int foreign key references Evento(IdEvento) not null,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	Descricao varchar(200) not null,
	Exibe bit default(0)
)



