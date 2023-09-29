select * from Clinica
select * from TipoUsuario
select * from Usuario

insert into TipoUsuario (IdTipoUsuario, TituloTipoUsuario)
values (NEWID(), 'Administrador'), (NEWID(), 'Médico'), (NEWID(), 'Paciente')

