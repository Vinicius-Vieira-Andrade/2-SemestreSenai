import React from 'react';
import './FormComponents.css';

//componente dinâmico
export const Input = ({
    type,
    id,
    value,
    required,
    additionalClass = "",
    name,
    placeholder,
    manipulationFunction
}) => {
    return(
        <input 
        type={type} 
        id={id}
        name={name}
        value={value}
        required={required}
        className={`input-component ${additionalClass}`}
        placeholder={placeholder}
        onChange={manipulationFunction}
        autoComplete='off'
        />
    )

}










//componente dinâmico
export const Button = ({ manipulationFunction, textButton, id, name, type, additionalClass }) => {
    return(
        <button onClick={manipulationFunction} type={type} name={name} id={id} className={`button-component ${additionalClass}`} >{textButton}</button>
                                                                                //↓↓↓↓
                                                                    //caso adicione uma classe adicional
    )
}