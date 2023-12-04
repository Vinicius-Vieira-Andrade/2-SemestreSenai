import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../pages/HomePage/HomePage";
import EventoPage from "../pages/EventoPage/EventoPage";
import LoginPage from "../pages/LoginPage/LoginPage";
import TipoEvento from "../pages/TipoEvento/TipoEvento";
import TestePage from "../pages/TestePage/TestePage";
import Header from "../components/Header/Header";
import Footer from "../components/Footer/Footer";
import { PrivateRoute } from "./PrivateRoute";
import EventoAlunoPage from "../pages/EventoAlunoPage/EventoAlunoPage";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header /> {/* em todas as telas o header será aplicado! */}
      <Routes>
        <Route element={<LoginPage />} path="/login" />
        <Route element={<HomePage />} path="/" exact />
        <Route element={<TestePage />} path="/teste" />

        <Route
          path="/evento"
          element={
            //ROTA PRIVADA, SÓ SERÁ POSSÍVEL ACESSAR ESTANDO LOGADO
            <PrivateRoute>
              <EventoPage />
            </PrivateRoute>
          }
        />
        <Route
          path="/tipo-evento"
          element={
            <PrivateRoute redirectTo="/">
              <TipoEvento />
            </PrivateRoute>
          }
        />
        <Route
          path="/evento-aluno"
          element={
            //ROTA PRIVADA, SÓ SERÁ POSSÍVEL ACESSAR ESTANDO LOGADO
            <PrivateRoute>
              <EventoAlunoPage />
            </PrivateRoute>
          }
        />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
