-- DQL

use HealthClinic_Tarde


select
Consulta.IdConsulta [Id da consulta],
Usuario.Nome as [Nome do paciente],
Paciente.RG,
Feedback.Descricao as [Feedback],
Feedback.Exibe,
concat (MedicoUsuario.Nome, ' - ', Medico.CRM, ' - ', Especialidade.TituloEspecialidade) as [Dados do Médico],
Consulta.Prontuario,
Consulta.[Data],
Consulta.Horario

from
Consulta
left join Paciente on Paciente.IdPaciente = Consulta.IdPaciente
left join Medico on Medico.IdMedico = Consulta.IdMedico
left join Feedback on Feedback.IdFeedback = Consulta.IdFeedback
left join Especialidade on Especialidade.IdEspecialidade = Medico.IdEspecialidade
left join Usuario as MedicoUsuario on Medico.IdUsuario = MedicoUsuario.IdUsuario
left join Usuario on Paciente.IdUsuario = Usuario.IdUsuario


create function BuscaMedico
(
	@Especialidade varchar(100)
)
returns table
as
return
(
	select MedicoUsuario.Nome as Médico, 
	Especialidade.TituloEspecialidade as Especialidade
	from Especialidade
	inner join Medico on Medico.IdEspecialidade = Especialidade.IdEspecialidade
	inner join Usuario as MedicoUsuario on Medico.IdUsuario = MedicoUsuario.IdUsuario
	where Especialidade.TituloEspecialidade = @Especialidade
);

select * from BuscaMedico ('otorrinolaringologista');
select * from BuscaMedico ('cardiologista');


select * from Consulta
select * from Paciente
select * from Medico
select * from Especialidade
select * from Feedback
select * from Usuario
select * from TipoUsuario
select * from Clinica