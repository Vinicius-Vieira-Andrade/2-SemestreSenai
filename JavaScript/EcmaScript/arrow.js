const somar = function (x, y) { //expressao anonima
    return x + y;
}

console.log(somar(20, 20));


const subtrair = (x, y) => { //expressao anonima
    return x - y;
}

console.log(subtrair(50, 20))


// const dobro = (numero) => {
//     return numero * 2
// }
//OU
const dobro = numero => numero * 2  //quando tem um parametro podemos retirar os parenteses e nesse caso tiramos o return tbm

console.log(dobro(10))


const buenasTardes = () => { console.log("Good tarde") }

buenasTardes();



const convidados = ["Vinicius", "Paladino", "Mikael", "Kauan", "Lucca"];


convidados.forEach((p, i) => {
    console.log(`${i + 1}º convidado: ${p}`);
});





const listaPessoas = [
    { nome: "Vinicius", idade: 20 },
    { nome: "Heitor", idade: 16 },
    { nome: "Mateus Paladino", idade: 17 },
]

listaPessoas.forEach(p => {
    console.log(`convidado: ${p.nome}`);
});