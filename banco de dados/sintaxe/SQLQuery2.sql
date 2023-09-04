--DML adiciona valores na tabela funcionario nas colunas nome
Insert into Funcionarios(Nome)
values ('allan');

--Atualiza com condicao, se o nome fosse igual allan eles seria mudado para ellen
update Funcionarios
set Nome = 'Ellen' where Nome = 'allan';

select * from Funcionarios
select * from Empresas


--remove o dado cujo o id seja igual a 3
delete from Funcionarios where IdFuncionario = 3;

insert into Empresas(idFuncionario, Nome)
values (4, 'Senai');