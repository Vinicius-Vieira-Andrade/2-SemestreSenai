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
    const situation = gerarSituacao(imc)


    //objeto gerado
    const Pessoa = { nome: nome, altura: altura, peso: peso, imc: imc, situacao: situation };

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
}



