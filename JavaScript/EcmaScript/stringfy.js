const objeto = {
    nome: 'Vinicius',
    idade: 20,
    presenca: false,
}


//o stringfy cria uma "cópia" do objeto que passei como parâmetro
const objetoAsJson = JSON.stringify(objeto, null, 2) 
//esse "null" e esse "2" são parâmetros que podem ser usados dessas forma no stringfy para auxiliar na leitura do console log no console do meu html, é um macete para "identar" o código lá no html, sem eles funcionaria normalmenteA


//nesse exemplo acontece o mesmo do exemplo de cima, mas usando uma tratativa para presenca aparecer como sim ou nao ao inves de true e false ;) o parametro key tem a mesma funcao do null. mesmo nao sendo utilizada, se tirarmos ela desse contexto, quando formos no console. a impressao nao estara "identada"
const objetoAsJson2 = JSON.stringify(objeto, (key, value) => (typeof value === 'boolean' ? (value ? 'sim' : 'não') : value), 2);

console.log(objetoAsJson);
console.log(objetoAsJson2);