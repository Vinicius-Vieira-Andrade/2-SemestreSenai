--DDL
--create database HealthClinic_Tarde
--go;

use HealthClinic_Tarde
--go;


create table TipoUsuario 
(
	IdTipoUsuario int primary key identity,
	TituloTipoUsuario varchar(50) not null unique
)

create table Usuario
(
	IdUsuario int primary key identity,
	IdTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario) not null,
	Email varchar(60) not null unique,
	Senha varchar(40) not null,
	Nome varchar(40) not null
)

create table Especialidade
(
	IdEspecialidade int primary key identity,
	TituloEspecialidade varchar(60) not null unique
)

create table Clinica
(
	IdClinica int primary key identity,
	Endereco varchar(100) not null,
	RazaoSocial varchar(77) not null unique,
	NomeFantasia varchar(50) not null,
	CNPJ varchar(14) not null unique
)

create table Feedback
(
	IdFeedback int primary key identity,
	Descricao varchar(150),
	Exibe bit Default(0),
)

create table Paciente
(
	IdPaciente int primary key identity,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	Telefone varchar(25) not null,
	RG varchar(10) not null,
	Idade varchar(3) not null
)

create table Medico
(
	IdMedico int primary key identity,
	IdUsuario int foreign key references Usuario(IdUsuario) not null,
	IdEspecialidade int foreign key references Especialidade(IdEspecialidade) not null,
	IdClinica int foreign key references Clinica(IdClinica) not null,
	CRM varchar(12) not null unique,
)

create table Consulta
(
	IdConsulta int primary key identity,
	IdPaciente int foreign key references Paciente(IdPaciente) not null,
	IdFeedback int foreign key references Feedback(IdFeedback) not null,
	IdMedico int foreign key references Medico(IdMedico) not null,
	Prontuario varchar(200) not null,
	[Data] date not null,
	Horario time not null
)