import React from "react";
import Banner from "../../Banner/Banner";
import ContactSection from "../../ContactSection/ContactSection";
import Container from "../../Container/Container";
import MainContent from "../../MainContent/MainContent";
import NextEvent from "../../NextEvent/NextEvent";
import Title from "../../Title/Title";
import VisionSection from "../../VisionSection/VisionSection";
import "./HomePage.css";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />

      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            {/*PRÓXIMOS EVENTOS*/}
            <NextEvent
              title={"Evento Happy Hour"}
              description={"Evento Legal"}
              eventDate={"14/11/2023"}
              idEvento={"tá funfando"}
            />
            <NextEvent
              title={"Evento Happy Hour"}
              description={"Evento Legal"}
              eventDate={"14/11/2023"}
              idEvento={"tá funfando"}
            />
            <NextEvent
              title={"Evento Happy Hour"}
              description={"Evento Legal"}
              eventDate={"14/11/2023"}
              idEvento={"tá funfando"}
            />
            <NextEvent
              title={"Evento Happy Hour"}
              description={"Evento Legal"}
              eventDate={"14/11/2023"}
              idEvento={"tá funfando"}
            />
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
