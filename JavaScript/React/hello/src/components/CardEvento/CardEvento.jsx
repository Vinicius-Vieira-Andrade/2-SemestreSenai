import React from "react";

import "../../App.css";
import "./CardEvento.css";

const CardEvento = (props) => {
  return (
    <div className="card-evento">
      <h2 className="card-evento__titulo">{props.tituloTexto}</h2>
      <p className="card-evento__descricao">{props.descricaoTexto}</p>
      <button className={`card-evento__conectar ${props.disabled ? 'card-evento__conectar--disabled' : ''}`}>
        {props.botaoTexto}
      </button>
    </div>
  );
};

export default CardEvento;
