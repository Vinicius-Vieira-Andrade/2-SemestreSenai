import React from "react";
import "./NextEvent.css";
import { formataDataDbToView } from "../../Utils/stringFunction";
import { Tooltip } from 'react-tooltip'



const NextEvent = ( {title, description, eventDate, idEvento} ) => {

    function conectar(idEvento) {
        alert(`Acho que ${idEvento}`)
    }


  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <p
        className="event-card__description"
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
         >
          <Tooltip id={idEvento} className="tooltip"/>
          {description.substr(0.16)}...
      </p>
      {/* <p className="event-card__description">{(new Date(eventDate).toLocaleDateString())}</p> FAZ TUDO QUE FIZEMOS COM O "STRINGFUNCTION.JS" SÓ QUE EM UMA LINHA, BEM MELHOR!!! */}
      <p className="event-card__description">{formataDataDbToView(eventDate)}</p>
                                              {/*usa a função que formata a data la do "stringFunction.js", para aqui na prop data*/}
      <a onClick={() => {conectar(idEvento)}} href="" className="event-card__connect-link">Conectar</a>
    </article>
  );
};

export default NextEvent;
