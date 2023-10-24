const urlLocal = "http://localhost:3000/contatos"

async function chamaCep() {
    const cep = document.getElementById("cep").value
    try {
        const url = await fetch(`https://viacep.com.br/ws/${cep}/json/`)
        const dados = await url.json();
        dadosCampo(dados);

    } catch (error) {
        erroDados()
    }

    function dadosCampo(dados) {
        document.getElementById("nome").value
        document.getElementById("sobrenome").value
        document.getElementById("email").value
        document.getElementById("pais").value
        document.getElementById("ddd").value = dados.ddd
        document.getElementById("telefone").value
        document.getElementById("rua").value = dados.logradouro
        document.getElementById("numero").value
        document.getElementById("complemento").value = dados.complemento
        document.getElementById("bairro").value = dados.bairro
        document.getElementById("cidade").value = dados.localidade
        document.getElementById("UF").value = dados.uf
        document.getElementById("anotacoes").value

        console.log(dados);
    }

    function erroDados() {
        document.getElementById("ddd").value = "!!!"
        document.getElementById("rua").value = "!!!"
        document.getElementById("complemento").value = "!!!"
        document.getElementById("bairro").value = "!!!"
        document.getElementById("cidade").value = "!!!"
        document.getElementById("UF").value = "!!!"

        console.log("Erro na API");
    }
}

function limparCampos() {
    document.getElementById("cep").value = ""
    document.getElementById("nome").value = ""
    document.getElementById("sobrenome").value = ""
    document.getElementById("email").value = ""
    document.getElementById("pais").value = ""
    document.getElementById("ddd").value = ""
    document.getElementById("telefone").value = ""
    document.getElementById("rua").value = ""
    document.getElementById("numero").value = ""
    document.getElementById("complemento").value = ""
    document.getElementById("bairro").value = ""
    document.getElementById("cidade").value = ""
    document.getElementById("UF").value = ""
    document.getElementById("anotacoes").value = ""
}

async function cadastrarContatos(e) {
    e.preventDefault();
    const nome = document.getElementById("nome").value
    const cep = document.getElementById("cep").value
    const sobrenome = document.getElementById("sobrenome").value
    const email = document.getElementById("email").value
    const pais = document.getElementById("pais").value
    const ddd = document.getElementById("ddd").value
    const telefone = document.getElementById("telefone").value
    const rua = document.getElementById("rua").value
    const numero = document.getElementById("numero").value
    const complemento = document.getElementById("complemento").value
    const bairro = document.getElementById("bairro").value
    const cidade = document.getElementById("cidade").value
    const UF = document.getElementById("UF").value
    const anotacoes = document.getElementById("anotacoes").value

    const dados = {
        nome, cep, sobrenome, email, pais, ddd, telefone, rua, numero, complemento, bairro, cidade, UF, anotacoes
    }

    try {
        const promise = await fetch(urlLocal, {
            body: JSON.stringify(dados),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });
        const retur = promise.json();
        console.log(retur);
    } catch (error) {
        alert(`Deu erro! ${error}`)
    }
}

