import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "./components/pages/HomePage/HomePage";
import EventoPage from "./components/pages/EventoPage/EventoPage";
import LoginPage from "./components/pages/LoginPage/LoginPage";
import TipoEvento from "./components/pages/TipoEvento/TipoEvento";
import TestePage from "./components/pages/TestePage/TestePage";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header /> {/* em todas as telas o header será aplicado! */}
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<EventoPage />} path="/evento" />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<TipoEvento />} path="/tipo-evento" />
        <Route element={<TestePage />} path="/teste" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
