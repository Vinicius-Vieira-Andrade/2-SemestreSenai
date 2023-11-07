import React, { useState } from "react";
import "./Header.css";
import Container from "../Container/Container";
import Nav from "../Nav/Nav";
import PerfilUsuario from "../PerfilUsuario/PerfilUsuario";
import menuBar from "../../assets/images/images/menubar.png";

const Header = () => {
  const [exibeNavbar, setExibeNavbar] = useState(false);
  console.log(`Exibe a navbar? ${exibeNavbar}`);

  return (
    <header className="headerpage">
      <Container>
        <div className="header-flex">
          <img
          className="hamburguer"
            src={menuBar}
            alt="Imagem menu de barras, server para exibir ou esconder o menu no smartphone."
            onClick={() => {
              setExibeNavbar(true);
            }}
          />

          <Nav setExibeNavbar={setExibeNavbar} //estou enviando as funcoes para a nav, entao no fim posso usa-las la no componente nav
          exibeNavbar={exibeNavbar} />

          <PerfilUsuario />
        </div>
      </Container>
    </header>
  );
};

export default Header;
