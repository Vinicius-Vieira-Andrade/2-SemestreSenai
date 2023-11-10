import React, { useEffect, useState } from "react";
import Banner from "../../Banner/Banner";
import ContactSection from "../../ContactSection/ContactSection";
import Container from "../../Container/Container";
import MainContent from "../../MainContent/MainContent";
import NextEvent from "../../NextEvent/NextEvent";
import Title from "../../Title/Title";
import VisionSection from "../../VisionSection/VisionSection";
import "./HomePage.css";
import api from "../../../Services/Services";

const HomePage = () => {

  useEffect(() => {
    async function getProximosEventos() {
      try {
        const promise = await api.get("/Evento/ListarProximos") //pega os dados da api

    

        console.log(promise.data); //mostra os dados da api 
        setNextEvents(promise.data)

      } catch (error) {
        alert("Deu ruim na api");
      }
    }

    getProximosEventos(); //chama o método
    console.log('a home foi montada!!!');
  }, [])


 
  const [nextEvents, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />

      {/*PRÓXIMOS EVENTOS*/}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            {/*chaves permitindo usar javascript*/}
            {nextEvents.map((e) => {
              return(
                <NextEvent
                title={e.nomeEvento}
                description={e.descricao} //substr quantos caracteres terei
                eventDate={e.dataEvento}
                idEvento={e.idEvento}
              />
              )
            })}
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
