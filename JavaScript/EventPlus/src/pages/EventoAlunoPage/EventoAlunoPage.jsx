import React, { useContext, useEffect, useState } from "react";
import Header from "../../components/Header/Header";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import {
  SelectTipoEventos,
  Select,
} from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api from "../../Services/Services";

import "./EventoAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

const EventoAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  const [idTipoEvento, setIdTipoEvento] = useState("1");
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState(""); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext); //recupera os dados do usuario

  useEffect(() => {
    loadEventsType();
  }, [tipoEvento, userData]);

  const verificaPresenca = (arrayAllEvento, eventsUser) => {
    for (let x = 0; x < arrayAllEvento.length; x++) {
      //para cada evento (todos)

      //verifica se o aluno está participando do evento atual
      for (let i = 0; i < eventsUser.length; i++) {
        //verifica em meus eventos
        if (arrayAllEvento[x].idEvento === eventsUser[i].idEvento) {
          arrayAllEvento[x].situacao = true;
          arrayAllEvento[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break;
        }
      }
    }
    //devolve o array modificado
    return arrayAllEvento;
  };

  async function loadEventsType() {
    setShowSpinner(true);
    try {
      const retorno = await api.get(`/Evento`);
      const retornoPresencas = await api.get(
        `/PresencaEvento/ListarMinhasPresencas/${userData.userId}`
      );
      if (tipoEvento === "1") {
        //todos eventos

        verificaPresenca(retorno.data, retornoPresencas.data);

        setEventos(retorno.data);
      } else {
        //meus evento
        let arrayEvento = [];
        retornoPresencas.data.forEach((element) => {
          arrayEvento.push({
            ...element.evento,
            idPresencaEvento: element.idPresencaEvento,
            situacao: element.situacao,
          });
          setEventos(arrayEvento);
        });
      }
    } catch (error) {
      console.log("moio");
    }
    setShowSpinner(false);
  }

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idEvent, idUser) {
    // try {
    //   const promise = await api.get(`ComentarioEvento/BuscaPorIdUsuario`, {
    //     idEvento: idEvent,
    //     idUsuario: idUser
    //   })
    // } catch (error) {
    // }
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const postMyComentary = (obj) => {
    try {
      console.log(obj);
    } catch (error) {
      console.log("erro" + error);
    }
  };

  const commentaryRemove = (idEvento) => {
    try {
      console.log(idEvento);
    } catch (error) {
      console.log("erro:" + error);
    }
  };

  async function handleConnect(idEvent, idPresent, connect = false) {
    if (connect === true) {
      try {
        await api.post("/PresencaEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });
        loadEventsType();
      } catch (error) {
        console.log("Erro ao conectar" + error);
      }
      return;
    }
    //unconnect
    try {
      await api.delete(`/PresencaEvento/${idPresent}`);
      loadEventsType();
    } catch (error) {
      console.log("Erro ao desconectar" + error);
    }
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={() => {
            commentaryRemove();
          }}
          fnPost={() => {
            postMyComentary();
          }}
        />
      ) : null}
    </>
  );
};

export default EventoAlunoPage;
