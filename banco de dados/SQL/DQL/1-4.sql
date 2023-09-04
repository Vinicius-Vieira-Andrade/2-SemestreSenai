-- listar todos os usuários administradores, sem exibir suas senhas

select 
Usuario.Nome,
Usuario.Permissao,
Usuario.Email
from
Usuario

where Usuario.Permissao = 'Administrador'

----------------------------------------------------------------------------------------------------------------

-- listar todos os álbuns lançados após um determinado ano de lançamento

select
Album.Titulo as [Titulo do Albúm],
Artista.Nome as [Nome do Artista],
Album.Ativo,
Album.lancamento as [Lançamento],
Album.Tempo_Duracao as [Tempo de Duração],
Album.Localizacao

from
Album 
left join Artista on Album.IdArtista = Artista.IdArtista

where lancamento = '2001/09/11'

----------------------------------------------------------------------------------------------------

-- listar os dados de um usuário através do e-mail e senha

Select
Usuario.Nome [Usuário],
Usuario.Permissao,
Usuario.Email

from
Usuario

where Email = 'Vini@senai.com' AND Senha = '123'

------------------------------------------------------------------------------------------------------------

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum

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