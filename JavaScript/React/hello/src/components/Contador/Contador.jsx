import React, { useState } from "react";
import './Contador.css';

const Contador = () => {

    const [contador, setContador] = useState(0) //setContador é uma função que irá alterar o valor da variavel contador, o useState é o valor inicial que o contador vai ter

    function handleIncrementar() { //lógica de incrementar
        setContador(contador + 1);
    }

    function handleDecrementar() { //lógica de decrementar
        contador > 0 ? setContador(contador - 1) : alert('Não é possivel decrementar 0') //validação, se for maior que zero, ele decrementa, não pode decrementar 0
    }

    return (
        <>
            <p>{contador}</p>
            <button onClick={() => { handleIncrementar() }}>INCREMENTAR</button> {/*usando arrow function/lambda podendo passar um parametro*/}
            <button onClick={handleDecrementar}>DECREMENTAR</button> {/*sem passar parametro, forma mais basica*/}
        </>
    );
}

export default Contador;