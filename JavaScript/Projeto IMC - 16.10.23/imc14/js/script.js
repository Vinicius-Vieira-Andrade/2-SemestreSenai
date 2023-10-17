function calcular() {
    event.preventDefault()


    let nome = document.getElementById("nome").value.trim()
    let altura = parseFloat(document.getElementById("altura").value)
    let peso = parseFloat(document.getElementById("peso").value)
    let situacao;

    if (isNaN(altura) || isNaN(peso) || nome == "") {
        alert("É necessário preencher todos os campos!")
        return;
    }


    const imc = calcularImc(altura, peso);
    const situation = gerarSituacao(imc);


    //objeto gerado
    const Pessoa = { nome, altura, peso, imc, situacao: situation };

    console.log(Pessoa);
    console.log(altura);
    console.log(peso);
    console.log(imc);
    console.log(situation);

    function calcularImc(altura, peso) {
        return (peso / Math.pow(altura, 2)).toFixed(2)
    }

    function gerarSituacao(imc) {

        if (imc < 18.5) {
            situacao = "Você está abaixo do peso!"
        }

        else if (imc >= 18.5 && imc <= 24.9) {
            situacao = "Você está com o peso regulado!"
        }

        else if (imc >= 25 && imc <= 29.9) {
            situacao = "Você está com excesso de peso!"
        }

        else if (imc >= 30 && imc <= 34.9) {
            situacao = "Você está com obesidade classe I"
        }

        else if (imc >= 35 && imc <= 39.9) {
            situacao = "Você está com obesidade classe II"
        }

        else {
            situacao = "Você está com obesidade classe III"
        }

        return situacao

    }


    const arrayPessoa = [];
    arrayPessoa.push(Pessoa) //guardo o objeto pessoas na lista

    const tableCorpo = document.getElementById("cadastro") //


    arrayPessoa.forEach((p) => {
        //linhas da tabela
        let linha = tableCorpo.insertRow();

        //células a ser preenchidas
        let tdNome = linha.insertCell();
        let tdAltura = linha.insertCell();
        let tdPeso = linha.insertCell();
        let tdImc = linha.insertCell();
        let tdSituacao = linha.insertCell();

        //valor que a célula vai receber
        tdNome.innerText = p.nome;
        tdAltura.innerText = p.altura;
        tdPeso.innerText = p.peso;
        tdImc.innerText = p.imc;
        tdSituacao.innerText = p.situacao;
    });





    // for (let index = 0; index < arrayPessoa.length; index++) {
    //     let linha = tableCorpo.insertRow();



    //     let tdNome = linha.insertCell();
    //     let tdAltura = linha.insertCell();
    //     let tdPeso = linha.insertCell();
    //     let tdImc = linha.insertCell();
    //     let tdSituacao = linha.insertCell();

    //     tdNome.innerText = arrayPessoa[index].nome;
    //     tdAltura.innerText = arrayPessoa[index].altura;
    //     tdPeso.innerText = arrayPessoa[index].peso;
    //     tdImc.innerText = arrayPessoa[index].imc;
    //     tdSituacao.innerText = arrayPessoa[index].situacao;

    // }

}



