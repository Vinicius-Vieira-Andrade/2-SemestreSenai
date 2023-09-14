insert into Estudio (IdEstudio, Nome) values (NEWID(), 'Bethesda'), (NewID(), 'Rockstar')



insert into TipoUsuario (IdTipoUsuario, Título) values (NEWID(),'Administrador'), (NEWID(), 'Comum')

insert into Usuario (IdUsuario, Email, Senha, IdTipoUsuario) values (NEWID(), 'admin@admin.com', 'admin', 'C4E25AE8-F1A0-4D77-9BCC-0ED0191F5210'),
(NEWID(), 'comum@comum.com', 'comum', 'C6BDB325-B22F-4E2B-B87E-64AE53669855')

insert into Jogo (IdJogo, Nome, Descricao, DataLancamento, Preço, IdEstudio)
values (NEWID(), 'GTA V', 'Jogo de mundo aberto', '08/09/2013', 10.00, '2F86E4C6-527F-4C8B-B5BE-D4C457E99C66'), 
(NEWID(), 'Skyrim', 'Jogo de mundo aberto RPG Fantasia', '07/10/2011', 20.00, '64EACEE0-0798-4FA9-AB93-58FBF542681C')




select * from TipoUsuario
select * from Estudio
select * from Usuario
select * from Jogo
