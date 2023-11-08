import React from 'react';
import Title from '../Title/Title';
import './ContactSection.css';
import contatoMap from '../../assets/images/images/contato-map.png';

const ContactSection = () => {
    return (
        <section className='contato'>
       <Title titleText={'Contato'}/>
       <div className="contato__endereco-box">
        <img 
            src={contatoMap} 
            alt="Imagem ilustrativa de um mapa"
            className='contato__img-map' />

            <p>Rua Niterói, 180 - Centro <br />
            Sào Caetano do Sul - SP <br />
            <a href="tel:+551142252000"
            className='contato__telefone'
            >(11) 4225-2000</a>
            </p>
       </div>

        </section>
    );
};

export default ContactSection;