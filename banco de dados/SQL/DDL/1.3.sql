--DDL
create database Exercicio_3_3

Use Exercicio_3_3


create table Raca 
(
	IdRaca int primary key identity,
	Raça varchar (20) not null unique
)

create table Tipo_de_pet
(
	IdTipoPet int primary key identity,
	Descrição varchar (40) not null
)

create table Dono
(
	IdDono int primary key identity,
	Nome varchar(20) not null,
	Telefone varchar(15) not null,
	Endereço varchar(70) not null
)

create table Clinica
(
	IdClinica int primary key identity,
	Endereço varchar(70) not null
)

Create table Veterinario
(
	IdVeterinario int primary key identity,
	IdClinica int foreign key references Clinica(IdClinica) not null,
	Nome varchar(20) not null,
	CRMV varchar(10) not null unique
)

Create table Pet
(
	IdPet int primary key identity,
	IdClinica int foreign key references Clinica(IdClinica) not null,
	IdTipoPet int foreign key references Tipo_de_pet(IdTipoPet) not null,
	IdRaca int foreign key references Raca(IdRaca) not null,
	IdDono int foreign key references Dono(IdDono) not null,
	Nome varchar(20) not null,
	Nascimento varchar(10) not null
)

create table Atendimento
(
	IdAtendimento int primary key identity,
	IdPet int foreign key references Pet(IdPet) not null,
	IdVeterinario int foreign key references Veterinario(IdVeterinario) not null,
	[Data] date not null,
	Valor varchar(10) not null
)

select * from Tipo_de_pet
select * from Dono
select * from Raca
select * from Clinica
select * from Veterinario
select * from Atendimento
select * from Pet