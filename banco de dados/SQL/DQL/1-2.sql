--DQL

--- listar todos os alugueis 
--mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
select 
Aluguel.DataInicial,
Aluguel.DataFinal,
Cliente.Nome,
Modelo.Modelo
from
Aluguel
inner join Cliente
on Aluguel.IdCliente = Cliente.IdCliente 
inner join Veiculo 
on Aluguel.IdVeiculo = Veiculo.IdVeiculo
inner join Modelo
on Modelo.IdModelo = Veiculo.IdModelo;


--- listar os alugueis de um determinado
--cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
select 
Aluguel.DataInicial,
Aluguel.DataFinal,
Cliente.Nome,
Modelo.Modelo
from
Aluguel
inner join Cliente
on Aluguel.IdCliente = Cliente.IdCliente 
inner join Veiculo 
on Aluguel.IdVeiculo = Veiculo.IdVeiculo
inner join Modelo
on Modelo.IdModelo = Veiculo.IdModelo

Where Cliente.nome = 'Vinicius'






select * from Marca
select * from Modelo
select * from Empresa
select * from Cliente
select * from Veiculo
select * from Aluguel