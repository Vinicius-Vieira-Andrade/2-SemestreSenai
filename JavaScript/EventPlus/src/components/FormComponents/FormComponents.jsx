import React from "react";
import "./FormComponents.css";

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
  return (
    <input
      type={type}
      id={id}
      name={name}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};



//SELECT
export const SelectTipoEventos = ({
    dados = [],
    id,
    name,
    required, 
    additionalClass = "",
    manipulationFunction,
    value
}) => {
    return (
    <select
      name={name}
      required={required}
      id={id}
      className={`input-component ${additionalClass}`}
      onChange={manipulationFunction}
      value={value}
    >
      <option value="select1">Selecione um tipo de evento</option>
      {dados.map((opt) => {
        return <option key={opt.idTipoEvento} value={opt.idTipoEvento}>{opt.titulo}</option>;
      })}
    </select>
  );
};


export const Select = ({
  id,
  name,
  required,
  dados = [],
  additionalClass = "",
  manipulationFunction,
  defaultValue,
}) => {
  return (
    <select
      id={id}
      name={name}
      required={required}
      className={`input-component ${additionalClass}`}
      onChange={manipulationFunction}
      value={defaultValue}
      // name="tipo-evento-select"
      // className="input-component"
    >
      <option value="">Selecione</option>
      {dados.map((opt) => {
        return <option key={opt.value} value={opt.value}>{`${opt.text}`}</option>;
      })}
    </select>
  );
};



export const SelectInstituicao = ({
    dados,
    id,
    name,
    required, 
    additionalClass = "",
    manipulationFunction,
    value
}) => {
    return (
    <select
      name={name}
      required={required}
      id={id}
      className={`input-component ${additionalClass}`}
      onChange={manipulationFunction}
      value={value}
    >
      <option value="select2">Selecione uma instituição</option>
      {dados.map((opt) => {
        return <option key={opt.idInstituicao} value={opt.idInstituicao}>{opt.nomeFantasia}</option>;
      })}
    </select>
  );
};

//componente dinâmico
export const Button = ({
  manipulationFunction,
  textButton,
  id,
  name,
  type,
  additionalClass,
}) => {
  return (
    <button
      onClick={manipulationFunction}
      type={type}
      name={name}
      id={id}
      className={`button-component ${additionalClass}`}
    >
      {textButton}
    </button>
    //↓↓↓↓
    //caso adicione uma classe adicional
  );
};
