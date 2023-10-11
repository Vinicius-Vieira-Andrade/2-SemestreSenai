 function calcular() {
            event.preventDefault();
            //Entrada de dados/guardando valor do formulário nas variáveis
            let numero1 = parseFloat(document.getElementById("numero1").value);
            let numero2 = parseFloat(document.getElementById("numero2").value);
            let result;
            let op = document.getElementById("operacao").value;


            if (isNaN(numero1) || isNaN(numero2))
            {
                alert("Preencha todos os campos corretamente!");
                return; //para o programa
            }


            //com switch case
            switch (op) {
                case "+":
                    result = somar(numero1, numero2)
                    break;
                case "-":
                    result = subtrair(numero1, numero2)
                    break;
                case "*":
                    result = multiplicar(numero1, numero2)
                    break;
                case "/":
                    result = divisao(numero1, numero2)
                    break;
                default: result = 'Operação inválida! Selecione uma operação válida!!!'
                    break;
            }
            document.getElementById('resultado').innerText = result  //innerText = Resultado será o texto escrito na tag EXEMPLO: Resultado:  || innerHTML = Resultado será a tag com o texto EXEMPLO: <p>Resultado: <strong id="resultado"></strong></p>

            //com if/else
            // if (op == '+') {
            //     result = somar(numero1, numero2)
            //     console.log(`Resultado: ${result}`);
            // }

            // else if (op == '-') {
            //     result = subtrair(numero1, numero2)
            //     console.log(`Resultado: ${result}`);
            // }

            // else if (op == '*') {
            //     result = multiplicar(numero1, numero2)
            //     console.log(`Resultado: ${result}`)
            // }

            // let result = parseFloat(numero1) + parseFloat(numero2);
            // alert(`Resultado: ${result}`)

        }//fim da funcao calcular


        //funções para calcular
        function somar(x, y) {
            return (x + y).toFixed(2);//number
        }

        function subtrair(x, y) {
            return (x - y).toFixed(2);
        }

        function multiplicar(x, y) {
            return (x * y).toFixed(2);
        }

        function divisao(x, y) {
            //validar divisão por 0
            if (y == 0) {
                return "Não é possível dividir por 0"
            }
            return (x / y).toFixed(2);
        }
