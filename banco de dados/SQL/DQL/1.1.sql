--DQL
--listar as pessoa em ordem alfabetica reversa, mostrando seus telefones, emails
--e CNHs



--script sem  usar join

--chama o nome, numero, email, e a cnh das tabelas em que elas est�o armazenadas
select 
	Pessoa.Nome,
	Telefone.Telefone,
	Email.Email,
	Pessoa.CNH --o "AS" da um apelido � coluna, mas n�o muda o nome dela por essencia

--de quais tabelas quero q venha os dados
from
	Pessoa,
	Email,
	Telefone --de quais tabelas quero q venha os dados

--where p/ especificar que o id de tabela pessoa � o mesmo da tabela email
where
	Pessoa.IdPessoa = Email.IdPessoa
	AND Pessoa.IdPessoa = Telefone.IdPessoa

--ordernar pelo nome/ordem reversa
order by Nome DESC
/*ordenar pelo nome/ordem alfab�tica
order by Nome*/

select * from Pessoa

;


