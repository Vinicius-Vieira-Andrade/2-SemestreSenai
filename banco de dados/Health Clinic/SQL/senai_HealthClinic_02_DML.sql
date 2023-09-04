-- DML

use HealthClinic_Tarde

insert into TipoUsuario (TituloTipoUsuario)
values ('Paciente'), ('Administrador'), ('Medico')

insert into Usuario (IdTipoUsuario, Email, Senha, nome)
values (3, 'lucca@medico', '123', 'lucca'), (1, 'math@paciente', '123', 'Matheus'), (2, 'vini@admin', '123', 'Vinicius')

insert into Especialidade (TituloEspecialidade)
values ('otorrinolaringologista')

insert into Clinica (Endereco, RazaoSocial, NomeFantasia, CNPJ)
values ('rua niteroi', 'Health Clinic', 'Htc', '12345678912345')

insert into Feedback (Descricao, Exibe)
values ('otimo atendimento', 0), ('péssimo atendimento', 1)

insert into Paciente (IdUsuario, Telefone, RG, Idade)
values (3, '11960741382', '356585573', '19'), (2, '1196523658', '123654789', '16')

insert into Medico (IdUsuario, IdEspecialidade, IdClinica, CRM)
values (1, 1, 1, 'crm/sp 52345')


insert into Consulta (IdPaciente, IdFeedback, IdMedico, Prontuario, [Data], Horario)
values (1, 2, 1, 'Nome: vini, Agravante: dor de garganta, Idade: 19 anos', '2023/08/18', '15:00:00'),
(2, 1, 1, 'Nome: matheus, Agravante: dor de ouvido, Idade: 16 anos', '2023/08/25', '13:00:00')


select * from TipoUsuario
select * from Usuario
select * from Especialidade
select * from Clinica
select * from Feedback
select * from Paciente
select * from Medico
select * from Consulta