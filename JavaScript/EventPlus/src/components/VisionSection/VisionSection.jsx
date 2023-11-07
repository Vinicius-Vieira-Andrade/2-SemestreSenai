import React from 'react';
import './VisionSection.css'
import Title from '../Title/Title';

const VisionSection = () => {
    return (
        <section className='vision'>
        <div className='vision__box'>
            <Title 
            titleText={"Visão"}
            color="white"
            additionalClass='vision__title'
            />

            <p className='vision__text'>Lorem</p>
        </div>
        </section>
    );
};

export default VisionSection;