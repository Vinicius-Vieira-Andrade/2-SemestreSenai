--DDL
--cria o banco
create database Exercicio_1_1
--usa o banco
use Exercicio_1_1

--cria tabelas
create table Pessoa
(
	IdPessoa int primary key identity,
	Nome varchar(20) not null,
	CNH char(10) not null unique
)

create table Telefone
(
	IdTelefone int primary key identity,
	IdPessoa int foreign key references Pessoa (IdPessoa) not null,
	Telefone varchar(20) not null unique
)

create table Email
(
	IdEmail int primary key identity,
	IdPessoa int foreign key references Pessoa (IdPessoa) not null,
	Email varchar(30) not null unique
)

select * from Pessoa
select * from Telefone
select * from Email