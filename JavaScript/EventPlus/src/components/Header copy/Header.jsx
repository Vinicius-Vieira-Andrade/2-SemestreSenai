import React from 'react';
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <header>
            <nav>
                <Link to="/"> Home</Link>
                <br />
                <Link to="/tipo-evento"> Tipo Evento</Link>
                <br />
                <Link to="/evento"> Evento</Link>
                <br />
                <Link to="/login"> Login</Link>
                <br />
                <Link to="/teste"> Teste</Link>
            </nav>
        </header>
    );
};

export default Header;