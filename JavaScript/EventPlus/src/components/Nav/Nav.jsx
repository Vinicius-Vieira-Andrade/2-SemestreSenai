import React from "react";
import { Link } from "react-router-dom";
import "./Nav.css";
import logoMobile from "../../assets/images/images/logo-white.svg";
import logoDesktop from "../../assets/images/images/logo-pink.svg";

const Nav = ({ setExibeNavbar, exibeNavbar }) => {
  return (
    <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
      <span
        className="navbar__close"
        onClick={() => {
          setExibeNavbar(false);
        }}
      >
        x
      </span>
      <Link to="">
        <img
          className="eventlogo__logo-image"
          src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
          alt="Event Plus Logo"
        />
      </Link>

      <div className="navbar__items-box">
        <Link to="/" className="navbar__item">Home</Link>
        <Link to="/tipo-evento" className="navbar__item">Tipo Eventos</Link>
        <Link to="/evento" className="navbar__item">Eventos</Link>
        <Link to="/login" className="navbar__item">Login</Link>
        <Link to="/teste" className="navbar__item">Teste</Link>
      </div>
    </nav>
  );
};
export default Nav;
