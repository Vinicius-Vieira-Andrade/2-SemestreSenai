--DML inserir dados nas tabelas
insert into Pessoa(Nome, CNH)
values ('Eduardo', '1234567890'), 
('Elis', '2987654321')
--insert into Pessoa 
--values ('Vinicius', '1234567888')

insert into Telefone (IdPessoa, Numero)
values (5, '123445')

insert into Email (IdPessoa, Endereco)
values (6, 'elis@gmail.com'), (5, 'Edu@ardo.com')

select * from Telefone
select * from Pessoa
select * from Email