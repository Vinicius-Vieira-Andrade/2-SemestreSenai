use master
go
create database dbTarefas
go
use dbTarefas
go
create table Usuario(
	Codigo int identity(1,1) primary key,
	Nome varchar(80) not null,
	Email varchar(80) not null,
	Usuario varchar(20) not null,
	Senha varchar(30)  null,
	Telefone varchar(15) not null,
	Foto varbinary(max) not null,
)


Select * from Usuario