import React, { useState } from "react";
import Button from "../../Button/Button"; 
import Header from "../../Header/Header";
import Input from "../../Input/Input"; //importando o componente que irei usar

const TestePage = () => {
  const [total, setTotal] = useState();
  const [n1, setN1] = useState();
  const [n2, setN2] = useState();

  function handlerCalcular(e) { //chamar submit no form
    e.preventDefault();
    setTotal(parseFloat(n1) + parseFloat(n2)); //transforma em numero
  }
  return (
    <>
      <h1>Calculadora</h1>
      <form onSubmit={handlerCalcular}>
        <Input tipo="number" valor={n1} id="numero1" nome="numero1" dicaCampo="Primeiro Número" fnAltera={setN1}/> {/*chamando o componente criado para renderizar na tela*/}
        <Input tipo="number" valor={n2} id="numero2" nome="numero2" dicaCampo="Segundo Número" fnAltera={setN2}/>
        <Button tipo="submit" textoBotao="Somar"/>
        <p>Resultado: <strong>{total}</strong></p>
      </form>
    </>
  );
};

export default TestePage;
