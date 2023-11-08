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

            <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit officiis, porro quis, odio esse placeat quia inventore impedit exercitationem iusto veniam quasi repudiandae repellat corporis quisquam molestiae doloremque eius! Doloribus.</p>
        </div>
        </section>
    );
};

export default VisionSection;