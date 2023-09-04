--DQL

--listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
select
Veterinario.Nome,
Veterinario.CRMV,
Clinica.IdClinica,
Clinica.Endere�o

from
Veterinario inner join Clinica on Veterinario.IdClinica = Clinica.IdClinica;

----------------------------------------------------------------------------------------------------

--- listar todas as ra�as que come�am com a letra S
Select
*

from
Raca

where
Ra�a LIKE 's%' --Come�a com S

---------------------------------------------------------------------------------------------------------------

-- listar todos os tipos de pet que terminam com a letra O

Select
*

from
Tipo_de_pet

where
Descri��o LIKE '%o'

----------------------------------------------------------------------------------------------------
--- listar todos os pets mostrando os nomes dos seus donos

select
Pet.Nome,
Dono.Nome

from
Pet inner join Dono on Pet.IdDono = Dono.IdDono

---------------------------------------------------------------------------------------------------

--- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, 
--a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido

Select
Veterinario.Nome as [Nome do Veterinario], 
Pet.Nome as [Nome do Pet],
Raca.Ra�a as [Ra�a do Pet],
Tipo_de_pet.Descri��o as [Tipo do Pet],
Dono.Nome as [Nome do Dono],
Clinica.Nome as [Nome da Clinica]

from
Atendimento 
inner join Veterinario on Atendimento.IdVeterinario = Veterinario.IdVeterinario
inner join Pet on Atendimento.IdPet = Pet.IdPet
inner join Dono on Dono.IdDono = Pet.IdDono
inner join Raca on Raca.IdRaca = Pet.IdRaca
inner join Tipo_de_pet on Tipo_de_pet.IdTipoPet = Pet.IdTipoPet
inner join Clinica on Clinica.IdClinica = Veterinario.IdClinica



select * from Tipo_de_pet
select * from Dono
select * from Raca
select * from Clinica
select * from Veterinario
select * from Atendimento
select * from Pet

