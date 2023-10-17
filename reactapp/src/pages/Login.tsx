import React, { useState } from 'react';
import AuthForm from '../components/AuthForm';

const Login = () => {
    const [name, setName] = useState("LOGIN");

    return (
        <AuthForm isLogin = {true}/>
    );
}

export default Login;