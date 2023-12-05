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
    const verificaPresenca = (arrayAllEvento, eventsUser) => {
      for (let x = 0; x < arrayAllEvento.length; x++) { //para cada evento (todos)

        //verifica se o aluno está participando do evento atual
        for (let i = 0; i < eventsUser.length; i++) { //verifica em meus eventos
          if (arrayAllEvento[x].idEvento === eventsUser[i].idEvento) {
            arrayAllEvento[x].situacao = true;
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
        if (tipoEvento === "1") {
          //todos eventos
          const retorno = await api.get(`/Evento`);
          const retornoPresencas = await api.get(
            `/PresencaEvento/ListarMinhasPresencas/${userData.userId}`
          );

          const dadosCarimbados = verificaPresenca(retorno.data,retornoPresencas.data)
          console.clear();
          console.log('dados marcados');
          console.log(dadosCarimbados);

          setEventos(retorno.data);
        } else {
          //meus evento
          let arrayEvento = [];
          const retornoPresencas = await api.get(
            `/PresencaEvento/ListarMinhasPresencas/${userData.userId}`
          );
          retornoPresencas.data.forEach((element) => {
            arrayEvento.push(element.evento);
            setEventos(arrayEvento);
          });
        }
      } catch (error) {
        console.log("moio");
      }
      setShowSpinner(false);
    }

    loadEventsType();
  }, [tipoEvento]);

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
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
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventoAlunoPage;
