--DML
insert into Modelo (Modelo)
Values ('X4'), ('Uno')

insert into Marca (Nome_Da_Marca)
values ('BMW'), ('Fiat')

insert into Empresa (Nome)
values ('Rent Carros')

insert into Cliente (CPF, Nome)
values ('1234567-89', 'Vinicius'), ('9876543-21', 'Matheus')

insert into Veiculo (IdMarca, IdEmpresa, IdModelo, Placa)
values (1, 1, 2, '12fg-321'), (2, 1, 1, '20ye-123')

insert into Aluguel (IdVeiculo, IdCliente, [Data], Valor)
values (5, 1, '2023/06/04', '700000'), (4, 2, '2023/10/06', '600000')

--adiciona coluna data inicial e data final na tabela aluguel
Update Aluguel
set DataInicial = '04/06/2023' where IdAluguel = 5
update Aluguel
set DataFinal = '18/06/2023' where IdAluguel = 5

Update Aluguel
set DataInicial = '06/10/2023' where IdAluguel = 6
update Aluguel
set DataFinal = '20/10/2023' where IdAluguel = 6



select * from Marca
select * from Modelo
select * from Empresa
select * from Cliente
select * from Veiculo
select * from Aluguel