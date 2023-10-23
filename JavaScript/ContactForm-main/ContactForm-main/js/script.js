async function chamaCep() {
    const cep = document.getElementById("cep").value

    try {
        const url = await fetch(`https://viacep.com.br/ws/${cep}/json/`)
        const dados = await url.json()

    } catch (error) {
        document.getElementById("erro").innerText = "CEP inválido";
    }

    function dadosCampo(dados) {
        document.getElementById("nome").value
        document.getElementById("sobrenome").value
        document.getElementById("email").value
        document.getElementById("pais").value
        document.getElementById("ddd").value
        document.getElementById("telefone").value
        document.getElementById("cep").value
        document.getElementById("rua").value
        document.getElementById("numero").value
        document.getElementById("rua").value
        document.getElementById("complemento").value
    }
}