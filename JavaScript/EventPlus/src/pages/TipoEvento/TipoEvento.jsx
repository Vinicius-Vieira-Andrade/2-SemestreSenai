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

import Notification from "../../components/Notification/Notification";

const TipoEvento = () => {
  const [frmEdit, setFrmEdit] = useState(false); //está em modo edição?
  const [titulo, setTitulo] = useState("");
  const [notifyUser, setNotifyUser] = useState({});
  const [tipoEventos, setTipoEventos] = useState([]);

  useEffect(() => {
    async function getTipoEventos() {
      try {
        const promise = await api.get(`/TiposEvento`);
        console.log(promise); //exibe console
        setTipoEventos(promise.data);
      } catch (error) {
        console.log("Moiô");
      }
    }
    getTipoEventos();
  }, [tipoEventos]);

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
      const retorno = await api.post("/TiposEvento", { titulo });

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      setTitulo(""); //limpa a variavel
    } catch (error) {
      console.log("Deu ruim na API");
      console.log(error);
    }
  }

  //FUNÇÕES DE EDITAR CADASTRO

  //MUDA TELA PARA ATUALIZAÇÃO
  function showUpdateForm() {
    setFrmEdit(true);
  }

  //ATUALIZAÇÃO DOS DADOS
  function handleUpdate(id) {
    try {
      const
    } catch (error) {
      
    }
  }

  //CANCELA AÇÃO ATUALIZAÇÃO
  function editActionAbort() {
    alert("cancelar acao");
  }

  async function handlerDelete(id) {
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);
      // const promise = await api.get(`/TiposEvento`);
    } catch (error) {
      console.log("não apagou hahah");
    }
    handlerDelete(id);
  }

  //CONTEUDO VISUAL DA PAGINA
  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
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
                /*Cadastrar*/
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
                  <span>{titulo}</span>

                  <Button
                    id={"cadastrar"}
                    name={"cadastrar"}
                    type={"submit"}
                    className={"button-component"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <>
                  {/* /Atualizar */}
                  <Button
                    id={"Editar"}
                    name={"editar"}
                    type={"submit"}
                    className={"button-component"}
                    textButton={"Editar"}
                  />

                  <Button
                    id={"Cancelar"}
                    name={"cancelar"}
                    type={"reset"}
                    className={"button-component"}
                    textButton={"cancelar"}
                  />
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
