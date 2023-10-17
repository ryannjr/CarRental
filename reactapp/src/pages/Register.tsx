import React, { useState } from 'react';
import AuthForm from '../components/AuthForm';
const Register = () => {
    const [name, setName] = useState("REGISTER");

    return (
        <AuthForm isLogin = {false}/>
    );
}

export default Register;