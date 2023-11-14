import React, { useState } from "react";
import Title from "../../components/Title/Title";
import "./TipoEvento.css";
import MainContent from "../../components/MainContent/MainContent";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import EventTypeImage from "../../assets/images/images/tipo-evento.svg";
import Container from "../../components/Container/Container";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import api from "../../Services/Services";

const TipoEvento = () => {
  const [frmEdit, setFrmEdit] = useState(false); //está em modo edição?
  const [titulo, setTitulo] = useState("");

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
      console.log("cadastrado com sucesso");
      console.log(retorno.data);
      setTitulo(""); //limpa a variavel

    } catch (error) {
      console.log("Deu ruim na API");
      console.log(error);
    }
  }

  function handleUpdate() {
    //funcao de atualizar
    console.log("Bora Atualizar");
  }
  return (
    <MainContent>
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
                /*Atualizar*/ <p>Tela de Edição</p>
              )}
            </form>
          </div>
        </Container>
      </section>
    </MainContent>
  );
};
export default TipoEvento;
