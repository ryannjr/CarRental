import React, {useState} from 'react';

const About = () => {
    const [name, setName] = useState("ABOUT");

    return (
        <div>{name}</div>
    );
}

export default About;