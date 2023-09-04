-- listar todos os usu�rios administradores, sem exibir suas senhas

select 
Usuario.Nome,
Usuario.Permissao,
Usuario.Email
from
Usuario

where Usuario.Permissao = 'Administrador'

----------------------------------------------------------------------------------------------------------------

-- listar todos os �lbuns lan�ados ap�s um determinado ano de lan�amento

select
Album.Titulo as [Titulo do Alb�m],
Artista.Nome as [Nome do Artista],
Album.Ativo,
Album.lancamento as [Lan�amento],
Album.Tempo_Duracao as [Tempo de Dura��o],
Album.Localizacao

from
Album 
left join Artista on Album.IdArtista = Artista.IdArtista

where lancamento = '2001/09/11'

----------------------------------------------------------------------------------------------------

-- listar os dados de um usu�rio atrav�s do e-mail e senha

Select
Usuario.Nome [Usu�rio],
Usuario.Permissao,
Usuario.Email

from
Usuario

where Email = 'Vini@senai.com' AND Senha = '123'

------------------------------------------------------------------------------------------------------------

-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum

Select
Album.titulo as [Titulo do Album],
Artista.Nome as [Nome do Artista],
Estilo.Nome as [Estilo Musical],
Album.Ativo

from
AlbumEstilo 
inner join Album on AlbumEstilo.IdAlbum = Album.IdAlbum
inner join Estilo on AlbumEstilo.IdEstilo = Estilo.IdEstilo
inner join Artista on Artista.IdArtista = Album.IdArtista

where Album.Ativo = 'Sim'







select * from Album
select * from Estilo
select * from AlbumEstilo
select * from Usuario
select * from Artista