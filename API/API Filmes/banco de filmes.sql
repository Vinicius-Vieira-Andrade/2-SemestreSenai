
CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

select * from Filme

insert into Genero (Nome)
values ('Terror')

insert into Filme (IdGenero, Titulo)
values (2, 'Anaconda')

select * from Genero
select * from Filme


select Filme.Titulo, Genero.Nome

from Filme
inner join Genero on Filme.IdGenero = Genero.IdGenero

select * from Usuario
insert into Usuario values ('admin@admin.com', '12345', 'Admin')
