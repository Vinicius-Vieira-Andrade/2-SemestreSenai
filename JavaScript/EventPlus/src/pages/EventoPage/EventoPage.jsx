import React, { useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import "./EventoPage.css";
import Container from "../../components/Container/Container";
import {
  Button,
  Input,
  Select,
  SelectInstituicao,
  SelectTipoEventos,
} from "../../components/FormComponents/FormComponents";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import api from "../../Services/Services";
import Notification from "../../components/Notification/Notification";
import EventTypeImage from "../../assets/images/images/evento.svg";
import TableEp from "./TableEp/TableEp";
import { useEffect } from "react";

const EventoPage = () => {
  const [titleEvento, setTitulo] = useState("");
  const [description, setDescription] = useState("");
  const [tipoEventos, setTipoEventos] = useState([]);
  const [instituicao, setInstituicao] = useState([]);
  const [data, setData] = useState("");

  const [frmEdit, setFrmEdit] = useState(false);
  const [eventos, setEventos] = useState([]);
  const [notifyUser, setNotifyUser] = useState({});
  const [idEvento, setIdEvento] = useState(null);
  const [showSpinner, setShowSpinner] = useState(false);

  async function getEventos() {
    try {
      const retorno = await api.get(`/Evento`);
      setEventos(retorno.data);
    } catch (error) {
      console.log("moio");
    }
  }

  async function getInstituicao() {
    try {
      const retorno = await api.get(`/Instituicao`);
      setInstituicao(retorno.data);
    } catch (error) {
      console.log("moio");
    }
  }

  async function getTipoEventos() {
    try {
      const rt = await api.get(`/TiposEvento`);
      setTipoEventos(rt.data);
    } catch (error) {
      alert("deu ruim");
    }
  }

  //sempre que renderizar page, vai chamar as func
  useEffect(() => {
    getEventos();
    getInstituicao();
    getTipoEventos();
  }, []);

  async function handlePost(e) {
    //parar o submit do form
    e.preventDefault();

    //chamar api
    try {
      const retorno = await api.post("/Evento", {
        nomeEvento: titleEvento,
        descricao: description,
        idTipoEvento: tipoEventos,
        idInstituicao: instituicao,
        dataEvento: data
      });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      getEventos();
      setDescription('')
      setTitulo('')
      setData('')

    } catch (error) {
      console.log("Deu ruim na API");
      console.log(error);
    }

    setTitulo(""); //limpa a variavel
    setDescription("");
    setData("");
  }

  async function handleUpdate(e) {
    e.preventDefault();
    try {
      const retorno = await api.put(`/Evento/` + idEvento, {
        titulo: titleEvento,
        descricao: description,
        idTipoEvento: tipoEventos,
        idInstituicao: instituicao,
        dataEvento: data
      });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      //atualizar o state (api get)
      const retornoGet = await api.get(`/Evento`);
      setEventos(retornoGet.data); //atualiza o state da tabela
      editActionAbort(); //limpa o state do titulo e id
    } catch (error) {
      alert("Deu ruim no update");
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setIdEvento(null);
    setTitulo("");
    setDescription("");
    setData("");
  }

  async function mostraUpdate(idElemento) {
    setFrmEdit(true);
    try {
      const promise = await api.get(`/Evento/` + idElemento);
      setTitulo(promise.data.titulo);
      setIdEvento(promise.data.idEvento);

      //  setIdTipoEvento(tipoEventos.find((tipoEvento) => tipoEvento.idTipoEvento === idElemento).idTipoEvento);
      //  setTitulo(tipoEventos.titulo)
    } catch (error) {
      alert("deu ruim");
    }
  }

  async function handlerDelete(id) {
    try {
      const retorno = await api.delete(`/Evento/${id}`);
      // const promise = await api.get(`/TiposEvento`);
      getEventos();
    } catch (error) {
      console.log("não apagou");
    }
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      <Container>
        <section className="cadastro-evento-section">
          <Container>
            <div className="cadastro-evento__box">
              <Title titleText={"Página de Eventos"} className="margem-acima" />
              <ImageIllustrator alterText={""} imageRender={EventTypeImage} />

              <form
                onSubmit={frmEdit ? handleUpdate : handlePost}
                className="ftipo-evento"
              >
                {/*Exclamação '!' indica negação, se não estiver em tela de edição*/}
                {!frmEdit ? (
                  /*Mostra tela de Cadastrar*/
                  <>
                    <Input
                      id={"evento"}
                      name={"evento"}
                      placeholder={"Evento"}
                      type={"text"}
                      required="required"
                      value={titleEvento}
                      manipulationFunction={(e) => {
                        setTitulo(e.target.value);
                      }}
                    />
                    <Input
                      id={"descricao"}
                      name={"descricao"}
                      placeholder={"Descrição"}
                      type={"text"}
                      required="required"
                      value={description}
                      manipulationFunction={(e) => {
                        setDescription(e.target.value);
                      }}
                    />

                    <SelectTipoEventos
                      dados={tipoEventos}
                      id="idTipoEVentos"
                      placeholder="Tipo de Eventos"
                      name="idTipoEventos"
                      manipulationFunction={(e) => {
                        setTipoEventos(e.target.value);
                      }}
                    />

                    <SelectInstituicao
                      dados={instituicao}
                      id="idInstituicao"
                      placeholder="Instituição"
                      name="idInstituicao"
                      manipulationFunction={(e) => {
                        setInstituicao(e.target.value);
                      }}
                    />

                    <Input
                      id={"data"}
                      name={"data"}
                      placeholder={"dd/mm/aaaa"}
                      type={"date"}
                      required="required"
                      value={data}
                      manipulationFunction={(e) => {
                        setData(e.target.value);
                      }}
                    />
                    {/* <span>{titulo}</span> */}

                    <Button
                      id={"cadastrar"}
                      name={"cadastrar"}
                      type={"submit"}
                      textButton={"Cadastrar"}
                      additionalClass={"button-component"}
                      manipulationFunction={handlePost}
                    />
                  </>
                ) : (
                  <>
                    {/* tela de edição */}
                    <Input
                      id={"evento"}
                      name={"evento"}
                      placeholder={"Evento"}
                      type={"text"}
                      required="required"
                      value={titleEvento}
                      manipulationFunction={(e) => {
                        setTitulo(e.target.value);
                      }}
                    />
                    <Input
                      id={"descricao"}
                      name={"descricao"}
                      placeholder={"Descrição"}
                      type={"text"}
                      required="required"
                      value={description}
                      manipulationFunction={(e) => {
                        setDescription(e.target.value);
                      }}
                    />
                    <SelectTipoEventos
                      dados={tipoEventos}
                      id="idTipoEVentos"
                      placeholder="Tipo de Eventos"
                      name="idTipoEventos"
                    />

                    <SelectInstituicao
                      dados={instituicao}
                      id="idInstituicao"
                      placeholder="Instituição"
                      name="idInstituicao"
                    />
                    <Input
                      id={"data"}
                      name={"data"}
                      placeholder={"dd/mm/aaaa"}
                      type={"date"}
                      required="required"
                      value={data}
                      manipulationFunction={(e) => {
                        setData(e.target.value);
                      }}
                    />

                    <div className="buttons-editbox">
                      <Button
                        id={"atualizar"}
                        name={"atualizar"}
                        type={"submit"}
                        textButton={"Atualizar"}
                        additionalClass={"button-component--middle"}
                        manipulationFunction={handleUpdate}
                      />

                      <Button
                        id={"cancelar"}
                        name={"cancelar"}
                        type={"reset"}
                        textButton={"Cancelar"}
                        additionalClass={"button-component--middle"}
                        manipulationFunction={editActionAbort}
                      />
                    </div>
                  </>
                )}
              </form>
            </div>
          </Container>
        </section>
      </Container>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de eventos"} color="white" />
          <TableEp
            dados={eventos}
            fnUpdate={mostraUpdate}
            fnDelete={handlerDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventoPage;
