--DDL
Create database ExercicioTarde_4_4
Use ExercicioTarde_4_4

create table Artista
(
	IdArtista int primary key identity,
	Nome varchar (15) not null unique
)

create table Album
(
	IdAlbum int primary key identity,
	IdArtista int foreign key references Artista(IdArtista) not null,
	Ativo Char(3) not null,
	titulo varchar(18) not null unique,
	Lancamento date not null,
	Tempo_Duracao varchar(8),
	Localizacao varchar(20) not null
)

Create table Estilo
(
	IdEstilo int primary key identity,
	Nome varchar(15) not null
)

create table Usuario
(
	IdUser int primary key identity,
	Nome varchar (15) not null,
	Permissao varchar (14) not null,
	Email varchar(30) not null unique,
	Senha varchar (15) not null
)

create table AlbumEstilo
(
	IdAlbumEstilo int primary key identity,
	IdAlbum int foreign key references Album(IdAlbum),
	IdEstilo int foreign key references Estilo(IdEstilo)
)

select * from Album
select * from Estilo
select * from AlbumEstilo
select * from Usuario
select * from Artista