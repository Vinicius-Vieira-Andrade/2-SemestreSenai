select * from Clinica
select * from TipoUsuario
select * from Usuario
select * from Especialidade
select * from Medico
select * from Paciente
select * from Feedback

insert into Especialidade
values (NEWID(), 'Cardiologista'), (NEWID(), 'Oftalmologista')

insert into TipoUsuario (IdTipoUsuario, TituloTipoUsuario)
values (NEWID(), 'Administrador'), (NEWID(), 'Médico'), (NEWID(), 'Paciente')

