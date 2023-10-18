//map - novo array modificado
//filter - retorna um novo array apenas com elemrntos que atenderem a uma condicao
//reduce -


//MAP
const numeros = [104, 23, 300, 4, 5]

const dobro = numeros.map( (nDeNumero) => {
    return nDeNumero * 2
} );


console.log(numeros);
console.log(dobro);


//FILTER
const numbers = [1 ,2 ,4, 6, 54, 700];

const maior10 = numbers.filter( (e) => {
    return  e > 10
} );

console.log(numbers);
console.log(maior10);


//REDUCES - 
const nuu = [1 ,2 ,4, 6, 54, 700]

const somar = nuu.reduce( (valorInicial, n) => {
    return valorInicial + n
}, 400)// << esse é o valor inicial nesse caso 400 que somará com os numeros dentro do array

console.log(somar);




//exemplo utilizavel no event

const comentarios = [
    {comentario: "blablabla", exibe: true},
    {comentario: "evento brabooo", exibe: true},
    {comentario: "evento m%$%#$", exibe: false},
]


const comentarios0k = comentarios.filter( (c) => {

    return c.exibe == true
})

comentarios0k.forEach(c => {
    console.log(c.comentario);
});