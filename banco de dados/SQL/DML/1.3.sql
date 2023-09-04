--DML
insert into Tipo_de_pet (Descrição)
values ('Cachorro'), ('Gato')

insert into Dono (Nome, Telefone, Endereço)
values ('Vinicius', '1234-5662', 'rua a'), ('Guilherme', '9876-9876', 'rua b')

insert into Raca (Raça)
values ('Rotweiler'), ('Siamês')


insert into Clinica (Endereço)
values ('rua 1')

insert into Veterinario (IdClinica, Nome, CRMV)
values (1, 'João', '12345'), (1, 'Leticia', '54321')

insert into Pet (IdClinica, IdTipoPet, IdRaca, IdDono, Nome, Nascimento)
values (1, 1, 1, 2, 'Thor', '06/10/2003'), (1, 2, 2, 2, 'Loki', '10/06/2003')
insert into Pet (IdClinica, IdTipoPet, IdRaca, IdDono, Nome, Nascimento)
values (1, 5, 3, 1, 'Curupira', '31/10/2003')

insert into Atendimento (IdPet, IdVeterinario, [Data], Valor)
values ( 1, 2, '2023/12/20', '500')

insert into Atendimento (IdPet, IdVeterinario, [Data], Valor)
values ( 5, 1, '2023/03/30', '700')

update Clinica
set Nome = 'MancoPet' where IdClinica = 1 --adiciona valor a coluna nome da tabela Clinica

alter table Atendimento
add Descricao varchar(20)

update Atendimento
set Descricao = 'lorem ipsun'

select * from Tipo_de_pet
select * from Dono
select * from Raca
select * from Clinica
select * from Veterinario
select * from Atendimento
select * from Pet