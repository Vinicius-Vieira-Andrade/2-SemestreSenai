--CRIA BANCO DE DADOS DDL
CREATE DATABASE BANCOVINICIUS;

----------------------------------------------------------------------

USE BANCOVINICIUS; --COMANDO PARA USAR O BANCO "BANCOVINICIUS" DDL

----------------------------------------------------------------------

--COMANDO DE CRIAR TABELA
CREATE TABLE Funcionarios (
	IdFuncionario int primary key identity,
	Nome varchar(10)
);

----------------------------------------------------------------------

Create table Empresas (
	IdEmpresas int primary key identity,
	idFuncionario int foreign key references Funcionarios(IdFuncionario), --referencia e mostra o caminho de quem vem como FK
	Nome char(20)
);

----------------------------------------------------------------------

--ALTER TABLE
alter table Funcionarios 
add Cpf varchar(11) --adiciona coluna

alter table Funcionarios -- remove/drop a coluna
drop column Cpf;

----------------------------------------------------------------------

--Remove a tabela empresas
drop table Funcionarios

----------------------------------------------------------------------
--remove o banco de dados (Cuidado!!!!!)
Drop database BANCOVINICIUS

