async function chamaCep() {
    const cep = document.getElementById("cep").value

    try {
        const url = await fetch(`https://viacep.com.br/ws/${cep}/json/`)
        const dados = await url.json();

        dadosCampo(dados);

    } catch (error) {
      //???
    }

    function dadosCampo(dados) {
        document.getElementById("nome").value
        document.getElementById("sobrenome").value
        document.getElementById("email").value
        document.getElementById("pais").value
        document.getElementById("ddd").value = dados.ddd
        document.getElementById("telefone").value
        document.getElementById("cep").value = dados.cep
        document.getElementById("rua").value = dados.logradouro
        document.getElementById("numero").value
        document.getElementById("complemento").value = dados.complemento
        document.getElementById("bairro").value = dados.bairro
        document.getElementById("cidade").value = dados.localidade
        document.getElementById("UF").value = dados.uf
        document.getElementById("anotacoes").value

        console.log(dados);
    }

    function limpaCampo(dados) {
        
    }
}