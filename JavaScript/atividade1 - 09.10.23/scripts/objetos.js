let eduardo = {
    nome: "Eduardo",
    idade: 41,
    altura: 1.67
};


eduardo.peso = 89;

let carlos = new Object();

carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque"



let pessoas = []; //array vazio
pessoas.push(carlos);
pessoas.push(eduardo);

console.log(pessoas);


//exibir o nome das pessoas utilizando o foreach
pessoas.forEach(function(p, i) { //USANDO FUNCTION
    console.log(`Nome da ${i + 1}ª pessoa: ${p.nome},`);
});

console.log();

pessoas.forEach((p, i) => { //USANDO LAMBDA
    console.log(`Nome da ${i + 1}ª pessoa: ${p.nome},`);
});
