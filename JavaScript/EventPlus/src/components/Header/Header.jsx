import React, { useState } from "react";
import "./Header.css";
import Container from "../Container/Container";
import Nav from "../Nav/Nav";
import PerfilUsuario from "../PerfilUsuario/PerfilUsuario";
import menuBar from "../../assets/images/images/menubar.png";

const Header = () => {
  const [exibeNavbar, setExibeNavbar] = useState(false);
  

  return (
    <header className="headerpage">
      <Container>
        <div className="header-flex">
          <img
          className="headerpage__menubar"
            src={menuBar}
            alt="Imagem menu de barras, server para exibir ou esconder o menu no smartphone."
            onClick={() => {
              setExibeNavbar(true);
            }}
          />

          <Nav setExibeNavbar={setExibeNavbar} //estou enviando as funcoes para a nav, entao no fim posso usa-las la no componente nav, oq esta entre as chaves é a funcao em si. o nome pouco importa, poderia ser batatinha
          exibeNavbar={exibeNavbar} />

          <PerfilUsuario />
        </div>
      </Container>
    </header>
  );
};

export default Header;
