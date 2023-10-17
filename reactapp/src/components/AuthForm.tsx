import React, {FC, useEffect, useState} from 'react';
import TextField from "@mui/material/TextField";
import { FormControl, IconButton, InputAdornment, InputLabel, OutlinedInput } from '@mui/material';
import { Visibility }from '@mui/icons-material';
import { VisibilityOff } from "@mui/icons-material/";
import PasswordField from './PasswordField';
import { Link } from 'react-router-dom';
import { RegisterValidator } from '../validators/register.validator';
import axios from 'axios';
import RegisterForm from './RegisterForm';
import LoginForm from './LoginForm';


interface props{
    isLogin: boolean
}

interface Errors{
    firstName: string[]; 
    lastName: string[];
    email: string[];
    password: string[];
    confirmPassword: string[]
}

const AuthForm = (props: props) => {

    return(
        <>
            {props.isLogin ? <LoginForm/> : <RegisterForm/>}
        </>
    );
}

export default AuthForm;