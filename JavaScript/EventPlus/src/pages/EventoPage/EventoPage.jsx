import React, { useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import "./EventoPage.css";
import Container from "../../components/Container/Container";
import { Button, Input } from "../../components/FormComponents/FormComponents";
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
        const retorno = await api.get(`/Evento`)
        setEventos(retorno.data)
    } catch (error) {
        console.log('moio');
    }
  }

  useEffect(() => {
    getEventos();
  }, [])

  async function handlePost(e) {
    //parar o submit do form
    e.preventDefault();

    //chamar api
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titleEvento });

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

  async function handleUpdate(e) {
    e.preventDefault();
    try {
      //salvar dados
      const retorno = await api.put(`/TiposEvento/` + idEvento, {
        titulo: titleEvento,
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
      const retornoGet = await api.get(`/TiposEvento`);
      setTipoEventos(retornoGet.data); //atualiza o state da tabela
      editActionAbort(); //limpa o state do titulo e id
    } catch (error) {
      alert("Deu ruim no update");
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("");
    setIdEvento(null);
  }

  return (
    <MainContent>
      <Container>
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
                        id={'evento'}
                        name={'evento'}
                        placeholder={'Evento'}
                        type={'text'}
                        required='required'
                        value={titleEvento}
                        manipulationFunction= {(e) => {
                            setTitulo(e.target.value)
                        }}
                    />
                    <Input 
                        id={'descricao'}
                        name={'descricao'}
                        placeholder={'Descrição'}
                        type={'text'}
                        required='required'
                        value={description}
                        manipulationFunction= {(e) => {
                            setDescription(e.target.value)
                        }}
                    />
                    <Input 
                        id={'tipoEvento'}
                        name={'tipoEvento'}
                        placeholder={'Tipo de Evento'}
                        type={'text'}
                        required='required'
                        value={tipoEventos}
                        manipulationFunction= {(e) => {
                            setEventos(e.target.value)
                        }}
                    />
                    <Input 
                        id={'instituicao'}
                        name={'instituicao'}
                        placeholder={'Instituição'}
                        type={'text'}
                        required='required'
                        value={instituicao}
                        manipulationFunction= {(e) => {
                            setEventos(e.target.value)
                        }}
                    />
                    <Input 
                        id={'data'}
                        name={'data'}
                        placeholder={'dd/mm/aaaa'}
                        type={'date'}
                        required='required'
                        value={data}
                        manipulationFunction= {(e) => {
                            setData(e.target.value)
                        }}
                    />
                    {/* <span>{titulo}</span> */}

                    <Button 
                        id={"cadastrar"}
                        name={"cadastrar"}
                        type={"submit"}
                        textButton={"Cadastrar"}
                        additionalClass={"button-component"}
                    />
                  </>
                ) : (
                  <>
                    {/* tela de edição */}
                    <Input 
                        id={'evento'}
                        name={'evento'}
                        placeholder={'Evento'}
                        type={'text'}
                        required='required'
                        value={titleEvento}
                        manipulationFunction= {(e) => {
                            setTitulo(e.target.value)
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
                        textButton={"Cancelar"}
                        additionalClass={"button-component--middle"}
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
            // fnUpdate={}
            // fnDelete={}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventoPage;
