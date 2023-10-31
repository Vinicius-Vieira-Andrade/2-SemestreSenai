import React from "react";
//import dos componentes de rota 'import BrowserRouter' adicionar o 'Router' e 'Route'
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";

//import das páginas
const Rotas = () => {
  return (
    //criar a estrutura de rotas
    <BrowserRouter>
      <Routes>
        <Route element={<HomePage />} path='/' exact /> 
        <Route element={<LoginPage />} path='/login' /> {/*quando acessar no url o "/login" ele me renderiza a "LoginPage"*/}
        <Route element={<ProdutoPage />} path='/produtos' />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
