//do prof
const evento = {
    dataEvento: new Date(),
    descricao: "Venha aprender JavaScript e todo seu poder!!",
    titulo: "Mão na massa EcmaScript",
    presenca: true,
    comentario: "Gostei do evento"
}


//REST
                                        //guarda o restante das propriedades? kkkkkk??
const { dataEvento, descricao, titulo, ...resto } = evento;

console.log(dataEvento);
console.log(descricao);
console.log(titulo);
console.log(resto);
//REST


// console.log(`
//     Evento: ${titulo}
//     Descrição: ${descricao}
//     Data: ${dataEvento}
//      Presença: ${presenca ? "Confirmada": "Não confirmada"}
//      Comentário: ${comentario}
// `);