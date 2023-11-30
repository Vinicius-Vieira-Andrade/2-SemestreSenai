import React, { useContext, useEffect, useState } from "react";
import Banner from "../../components/Banner/Banner";
import ContactSection from "../../components/ContactSection/ContactSection";
import Container from "../../components/Container/Container";
import MainContent from "../../components/MainContent/MainContent";
import NextEvent from "../../components/NextEvent/NextEvent";
import Title from "../../components/Title/Title";
import VisionSection from "../../components/VisionSection/VisionSection";
import api from "../../Services/Services";

import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "swiper/css/pagination";
import { Pagination } from "swiper/modules";

import "./HomePage.css";
import { UserContext } from "../../context/AuthContext";

const HomePage = () => {
  const { userData } = useContext(UserContext);

  console.log("DADOS DO USUARIO");
  console.log(userData);

  useEffect(() => {
    async function getProximosEventos() {
      try {
        const promise = await api.get("/Evento/ListarProximos"); //pega os dados da api

        console.log(promise.data); //mostra os dados da api
        setNextEvents(promise.data);
      } catch (error) {
        console.log("Deu ruim na api");
      }
    }

    getProximosEventos(); //chama o método
    console.log("a home foi montada!!!");
  }, []);

  const [nextEvents, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />

      {/*PRÓXIMOS EVENTOS*/}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />

          <div className="events-box">
            <Swiper
              spaceBetween={20}
              slidesPerView={ window.innerWidth > 992 ? 3 : 1}
              pagination={{ dynamicBullet: true, clickable: true }}
              modules={[Pagination]}
              className="mySwiper"
            >
              {/*chaves permitindo usar javascript*/}
              {nextEvents.map((e) => {
                return (
                  <SwiperSlide>
                    <NextEvent
                      title={e.nomeEvento}
                      description={e.descricao} //substr quantos caracteres terei
                      eventDate={e.dataEvento}
                      idEvento={e.idEvento}
                    />
                  </SwiperSlide>
                );
              })}
            </Swiper>
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
