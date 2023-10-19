const camisaLacoste =
{
    descrição: "Camiseta Lacoste",
    preço: 399.99,
    marca: "Lacoste",
    tamanho: "G",
    cor: "Vermelho",
    promoção: true
}

const descricao = camisaLacoste.descrição;
const preco = camisaLacoste.preço;


console.log(`Produto: ${descricao}, Preço: ${preco}`)

console.log();
console.log();


const { descrição, preço, promoção  } = camisaLacoste; //vira 3 constantes, propriedades pegas do objeto = DESTRUCTURING!



console.log(`Produto: ${descricao},
Preço: R$${preco},
Promoção: ${promoção? "Sim" : "Não"} 
`);

const evento = {
    dataEvento: new Date(2023, 09, 06),
    descricaoEvento: "Brasil Games Show",
    titulo: "BGS",
    presenca: true,
    comentario: "sjaldijaoifhsofhsoghodgifjf"
}

const {dataEvento, descricaoEvento, titulo, presenca, comentario} = evento; //DESTRUCTURING

console.log(`Evento: ${titulo},
Descrição: ${descricaoEvento},
Data do Evento: ${dataEvento},
Comentário: ${comentario},
Presença: ${presenca? "Sim" : "Não"}
`);