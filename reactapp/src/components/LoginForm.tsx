import React, {FC, useState, useEffect} from 'react';
import TextField from "@mui/material/TextField";
import { FormControl, IconButton, InputAdornment, InputLabel, OutlinedInput } from '@mui/material';
import { Visibility }from '@mui/icons-material';
import { VisibilityOff } from "@mui/icons-material/";
import PasswordField from './PasswordField';
import { Link, useNavigate} from 'react-router-dom';
import { RegisterValidator } from '../validators/register.validator';
import axios from 'axios';
import { LoginValidator } from '../validators/login.validator';

interface Errors{
    email: string[];
    password: string[];

}

const LoginForm = () => {

    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errors, setErrors] = useState<Errors>();

    const handleClick = () => {
        const errors = LoginValidator(email, password);
        setErrors(err => ({...err, ...errors}));
    }

    const loginUser = async() => {
        const data = {
            "email": email,
            "password": password
        }

        try {
            const res = await axios.post("https://localhost:7207/api/auth/login", data);
            window.localStorage.setItem("token", res.data.accessToken);
            setTimeout(() => navigate("/"), 1000);
        } catch (err) {
            console.log(err);
        }
    }

    useEffect(() => {
        const valid = () => {
            return errors?.password.length == 0 && errors?.email.length == 0 
        }

        if(valid()){
            loginUser();
        }

    }, [errors])

    return(
        <div className='mt-52 flex justify-center items-center'>
            <div className="flex flex-col justify-center items-center border-2 rounded-lg shadow-md w-1/4 py-14">
                <div className='mb-6'>
                    <h1 className="text-2xl font-open font-bold">Login</h1>
                </div>
            
                <div className="w-full flex flex-col justify-center items-center mt-8">
                    <div className="flex flex-col w-80 mb-4">
                        <TextField 
                            value = {email} 
                            onChange = {(e) => setEmail(e.target.value)}
                            label = "Email" />
                        <h1 className='text-sm text-red-600 '>{errors?.email ? errors.email[0] : ""}</h1>
                    </div>

                    <div className="flex flex-col w-80 mt-4">
                        <PasswordField 
                            value = {password} 
                            handleChange = {(e) => setPassword(e.target.value)}
                            label = "Password"
                        />
                        <h1 className='text-sm text-red-600 '>{errors?.password ? errors.password[0] : ""}</h1>
                    </div>   
                </div>

                <div className="flex rounded-md bg-blue-600 hover:bg-blue-700 w-80 h-14 justify-center items-center 
                    mt-14">
                    <button
                        onClick={handleClick}
                        className="w-full h-14 font-mukta text-md text-white">
                        LOGIN
                    </button>
                </div>
            </div>
        </div>
    );
}


export default LoginForm;