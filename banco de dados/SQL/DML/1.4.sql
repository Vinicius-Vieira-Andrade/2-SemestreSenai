--DML
insert into Usuario (Nome, Permissao, Email, Senha)
values ('Vini', 'Comum', 'Vini@senai.com', '123'), ('Rafael', 'Administrador', 'Rafa@Rafa.com', '321')

insert into Artista (Nome)
values ('P.O.D'), ('Veigh')

insert into Estilo (Nome)
values ('Trap'), ('Metal')

insert into Album (IdArtista, Ativo, Titulo, Lancamento, Tempo_Duracao, Localizacao)
values (1, 'Sim', 'Satellite', '11/09/2001', '55min', 'Estados Unidos'), 
(2, 'Sim', 'Dos prédios', '18/11/2022', '59min', 'Brasil')

update Album
set Ativo = 'Sim' where IdAlbum = 2

insert into Album
values (1, 'Não', 'The Warriors EP', '15/11/2005', '55min', 'Estados Unidos')

insert into AlbumEstilo (IdAlbum, IdEstilo)
values (1, 2), (2, 1)

insert into AlbumEstilo (IdAlbum, IdEstilo)
values (4, 2)


select * from Album
select * from Estilo
select * from AlbumEstilo
select * from Usuario
select * from Artista

sp_rename 'Album.titulo', 'Titulo', 'COLUMN'; --Altera nome da coluna "titulo" para "Titulo" na tabela "Album"