import React, { useState } from 'react';

const Input = (props) => {
    // const [meuValor, setValor] = useState();
    return (
        <div>
           <input type={props.tipo} placeholder={props.dicaCampo} id={props.id} name={props.nome} value={props.valor} onChange={(e)=>{
            // setValor(e.target.value) valor atual do componente
            props.fnAltera(e.target.value)//valor do input
           }}/> 
           <span>{props.valor}</span>
        </div>
    );
};

export default Input;