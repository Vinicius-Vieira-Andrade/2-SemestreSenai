import React, { useEffect, useState } from "react";
import Title from "../../components/Title/Title";
import "./TipoEvento.css";
import MainContent from "../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import EventTypeImage from "../../assets/images/images/tipo-evento.svg";
import Container from "../../components/Container/Container";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api from "../../Services/Services";
import TableTp from "./TableTp/TableTp";

import Spinner from "../../components/Spinner/Spinner";
import Notification from "../../components/Notification/Notification";

const TipoEvento = () => {
  const [frmEdit, setFrmEdit] = useState(false); //está em modo edição?
  const [titulo, setTitulo] = useState("");
  const [notifyUser, setNotifyUser] = useState({});
  const [tipoEventos, setTipoEventos] = useState([]);
  const [idEvento, setIdEvento] = useState(null);
  const [showSpinner, setShowSpinner] = useState(false);
  // const [idTipoEvento, setIdTipoEvento] = useState(null);


  async function getTipoEventos() {
    setShowSpinner(true);
    try {
      const promise = await api.get(`/TiposEvento`);
      console.log(promise); //exibe console
      setTipoEventos(promise.data);
    } catch (error) {
      console.log("Moiô");
    }
    setShowSpinner(false);
  }

  useEffect(() => {
    getTipoEventos();
  }, []);

  

  async function handlePost(e) {
    //parar o submit do form
    e.preventDefault();

    //validar 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O título deve ser maior que três caracteres");
      return;
    }

    //chamar api
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      getTipoEventos();
      setTitulo(""); //limpa a variavel
    } catch (error) {
      console.log("Deu ruim na API");
      console.log(error);
    }
  }

  //FUNÇÕES DE EDITAR CADASTRO

  //MUDA TELA PARA ATUALIZAÇÃO
  async function showUpdateForm(id) {
    setFrmEdit(true);
    try {
      const promise = await api.get(`/TiposEvento/` + id);
      setTitulo(promise.data.titulo);
      setIdEvento(promise.data.idTipoEvento);

      //  setIdTipoEvento(tipoEventos.find((tipoEvento) => tipoEvento.idTipoEvento === idElemento).idTipoEvento);
      //  setTitulo(tipoEventos.titulo)
    } catch (error) {
      alert("deu ruim");
    }
  }

  //ATUALIZAÇÃO DOS DADOS
  async function handleUpdate(e) {
    e.preventDefault();
    try {
      //salvar dados
      const retorno = await api.put(`/TiposEvento/` + idEvento, {
        titulo: titulo,
      });

      getTipoEventos();

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });


      //atualizar o state (api get)
      const retornoGet = await api.get(`/TiposEvento`);
      setTipoEventos(retornoGet.data); //atualiza o state da tabela
      cancelaEdit(); //limpa o state do titulo e id
    } catch (error) {
      alert("Deu ruim no update");
    }
  }

  //CANCELA AÇÃO ATUALIZAÇÃO E RESETA O STATE
  function cancelaEdit() {
    setFrmEdit(false);
    setTitulo("");
    setIdEvento(null);
  }

  async function handlerDelete(id) {
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);
      // const promise = await api.get(`/TiposEvento`);
      getTipoEventos();
    } catch (error) {
      console.log("não apagou hahah");
    }
    
  }

  //CONTEUDO VISUAL DA PAGINA
  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      {/* CADASTRO TIPO DE EVENTOS */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página Tipos de Eventos"}
              className="margem-acima"
            />
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
                    id={"titulo"}
                    name={"titulo"}
                    type={"text"}
                    required={"required"}
                    placeholder={"Título"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  {/* <span>{titulo}</span> */}

                  <Button
                    id={"cadastrar"}
                    name={"cadastrar"}
                    type={"submit"}
                    className={"button-component"}
                    textButton={"Cadastrar"}
                    manipulationFunction={handlePost}
                  />
                </>
              ) : (
                <>
                  {/* tela de edição */}
                  <Input
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    type={"text"}
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />

                  <div className="buttons-editbox">
                    <Button
                      id={"atualizar"}
                      name={"atualizar"}
                      type={"submit"}
                      textButton={"Atualizar"}
                      additionalClass={"button-component--middle"}
                    />

                    <Button
                      id={"cancelar"}
                      name={"cancelar"}
                      type={"reset"}
                      additionalClass={"button-component--middle"}
                      textButton={"Cancelar"}
                      manipulationFunction={cancelaEdit}
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/*LISTAGEM DE TIPOS DE EVENTOS */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de tipo de eventos"} color="white" />
          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handlerDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};
export default TipoEvento;
