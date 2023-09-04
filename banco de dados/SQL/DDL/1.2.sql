--DDL
create database ExercicioTarde_1_2

use ExercicioTarde_1_2

create table Cliente
(
	IdCliente int primary key identity,
	CPF varchar(14) unique not null,
	Nome varchar(20) not null
)

create table Marca
(
	IdMarca int primary key identity,
	Nome_Da_Marca varchar(15) unique not null 
)

create table Modelo
(
	IdModelo int primary key identity,
	Modelo varchar (15) not null
)

create table Empresa
(
	IdEmpresa int primary key identity,
	Nome varchar (33) unique not null
)

create table Veiculo
(
	IdVeiculo int primary key identity,
	IdMarca int foreign key references Marca(IdMarca),
	IdModelo int foreign key references Modelo(IdModelo),
	IdEmpresa int foreign key references Empresa(IdEmpresa),
	Placa char (8) unique not null
)

Create table Aluguel
(
	IdAluguel int primary key identity,
	IdVeiculo int foreign key references Veiculo(IdVeiculo) not null,
	IdCliente int foreign key references Cliente(IdCliente) not null,
	[Data] date not null,
	Valor varchar(50) not null
)

alter table Aluguel
add DataInicial varchar(14),
DataFinal varchar(14)

select * from Veiculo
select * from Cliente
select * from Aluguel
