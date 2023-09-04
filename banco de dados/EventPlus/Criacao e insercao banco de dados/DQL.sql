--DQL

-- Criar script para consulta exibindo os seguintes dados

/*Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Titulo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
*/

select
[Tipo De Usuario].TituloTipoUsuario as [Tipo de Usuário],
Usuario.Nome as [Nome do Usuário],
ComentarioEvento.Descricao as [Descrição do Evento],
case when [Presencas do Evento].Confirmação = 1 then 'Confirmado' else 'Não confirmado' end as Presença,
Evento.[Data de Evento],
concat (Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) as [Local],
[Tipos De Evento].TituloTipoEvento as [Tipo do Evento],
Evento.Nome as [Nome do Evento],
Evento.Descricao as [Descrição do Evento]


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