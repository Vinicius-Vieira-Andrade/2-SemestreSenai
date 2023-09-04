--DML
 /*use [Event+ Tarde]

insert into [Tipo De Usuario] (TituloTipoUsuario)
values ('Administrador'), ('Comum')

insert into [Tipos De Evento] (TituloTipoEvento)
values ('Redes'), ('Dev') 

insert into Instituicao (CNPJ, Endereco, NomeFantasia)
values ('12345678910111', 'Rua Niteroi, 180', 'DevSchool') */

/*insert into Usuario (IdTipoUsuario, Nome, Email, Senha)
values (2, 'Matheus Paladino', 'matheus@math.com', '12345'), (1, 'Vinicius Vieira', 'vini@vini.com', '54321')*/

/*insert into Evento (IdInstituicao, IdTiposEvento, Nome, Descricao, [Data de Evento], [Horario do Evento])
values (1, 1, 'Introdução ao Linux', 'Neste curso teremos a aula introdutória sobre linux, suas características e funções', '2023-12-23', '15:20:00'), 
(1, 2, 'Introdução a banco de dados', 'Neste curso teremos a aula introdutória ao banco de dados', '2024-01-02', '14:00:00')*/

/*insert into [Presencas do Evento] (IdUsuario, IdEvento, Confirmação)
values (1, 2, 0), (2, 1, 1)*/

/*insert into ComentarioEvento (IdEvento, IdUsuario, Descricao, Exibe)
values (2, 1, 'Esse evento promete!!', 1), (1, 2, 'Ansioso pelo evento!', 0)*/


select * from [Tipo De Usuario]
select * from [Tipos De Evento]
select * from ComentarioEvento
select * from Usuario
select * from Evento
select * from [Presencas do Evento]
select * from Instituicao