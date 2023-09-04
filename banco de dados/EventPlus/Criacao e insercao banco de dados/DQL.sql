--DQL

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Titulo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
*/

select
[Tipo De Usuario].TituloTipoUsuario as [Tipo de Usu�rio],
Usuario.Nome as [Nome do Usu�rio],
ComentarioEvento.Descricao as [Descri��o do Evento],
case when [Presencas do Evento].Confirma��o = 1 then 'Confirmado' else 'N�o confirmado' end as Presen�a,
Evento.[Data de Evento],
concat (Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) as [Local],
[Tipos De Evento].TituloTipoEvento as [Tipo do Evento],
Evento.Nome as [Nome do Evento],
Evento.Descricao as [Descri��o do Evento]


from
Usuario
inner join [Tipo De Usuario]
on Usuario.IdTipoUsuario = [Tipo De Usuario].IdTipoUsuario
inner join ComentarioEvento 
on Usuario.IdUsuario = ComentarioEvento.IdUsuario
left join [Presencas do Evento]
on Usuario.IdUsuario = [Presencas do Evento].IdUsuario,

Evento 
inner join Instituicao
on Evento.IdInstituicao = Instituicao.IdInstituicao
inner join [Tipos De Evento]
on Evento.IdTiposEvento = [Tipos De Evento].IdTiposEvento

order by Usuario.IdUsuario





select * from [Tipo De Usuario]
select * from [Tipos De Evento]
select * from ComentarioEvento
select * from Usuario
select * from Evento
select * from [Presencas do Evento]
select * from Instituicao