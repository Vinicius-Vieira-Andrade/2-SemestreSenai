import React from "react";
import Banner from "../../Banner/Banner";
import MainContent from "../../MainContent/MainContent";
import VisionSection from "../../VisionSection/VisionSection";
import "./HomePage.css";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />
      <VisionSection />
    </MainContent>
  );
};

export default HomePage;
