import React from "react";
import "./TableEp.css";
import editPen from "../../../assets/images/images/edit-pen.svg";
import trashDelete from "../../../assets/images/images/trash-delete.svg";

const TableEp = ({ dados, fnUpdate, fnDelete, eventDate}) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Tipo de Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Instituição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Data
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((dados) => {
            return (
                <tr className="table-data__head-row" key={dados.idEvento}>
            <td className="table-data__data table-data__data--little"> {dados.nomeEvento}</td>
            <td className="table-data__data table-data__data--little"> {dados.descricao}</td>
            <td className="table-data__data table-data__data--little"> {dados.idInstituicao}</td>
            <td className="table-data__data table-data__data--little"> {dados.idTipoEvento}</td>
            <td className="table-data__data table-data__data--little"> {dados.dataEvento}</td>
            {/* {(new Date(eventDate).toLocaleDateString())} */}

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={editPen}
                alt=""
                onClick={() => {
                  fnUpdate(dados.idEvento);
                }}
              />
            </td>

            <td className="table-data__data table-data__data--little">
              <img
                className="table-data__icon"
                src={trashDelete}
                alt=""
                onClick={() => {
                  fnDelete(dados.idEvento);
                }}
              />
            </td>
          </tr>
            )
        })}
      </tbody>
    </table>
  );
};

export default TableEp;
