import React, {FC, useEffect, useState} from 'react';
import TextField from "@mui/material/TextField";
import { FormControl, IconButton, InputAdornment, InputLabel, OutlinedInput } from '@mui/material';
import { Visibility }from '@mui/icons-material';
import { VisibilityOff } from "@mui/icons-material/";
import PasswordField from './PasswordField';
import { Link, useNavigate } from 'react-router-dom';
import { RegisterValidator } from '../validators/register.validator';
import axios from 'axios';

interface Errors{
    firstName: string[]; 
    lastName: string[];
    email: string[];
    password: string[];
    confirmPassword: string[]
}

const RegisterForm = () => {
    const navigate = useNavigate();
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [errors, setErrors] = useState<Errors>();
    const [showPassword, setShowPassword] = React.useState(false);


    const handleClickShowPassword = () => setShowPassword((show) => !show);
    const handleMouseDownPassword = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
    };

    const handleClick = () => {
        const errors = RegisterValidator(firstName, lastName, email, password, confirmPassword);
        setErrors(err => ({...err, ...errors}));
    }

    const registerUser = async() => {
        const data = {
            "firstName": firstName,
            "lastName": lastName,
            "email": email,
            "password": password,
            "confirmPassword": confirmPassword
        }

        try{
            const res = await axios.post("https://localhost:7207/api/auth/register", data);
            console.log(res)
            setTimeout(() => navigate("/login"), 1000);
        } catch (err){
        }
    }

    useEffect(() => {
        const valid = () => {
            return errors?.confirmPassword.length == 0 && errors?.password.length == 0 && errors?.email.length == 0 
            && errors?.firstName.length == 0 && errors?.lastName.length == 0;
        }

        if(valid()){
            registerUser();
        }
    }, [errors]);
    return(
        <div className='mt-36 flex justify-center items-center'>
            <div className="flex flex-col justify-center items-center border-2 rounded-lg shadow-md w-1/4 py-10">
                <div>
                    <h1 className="text-2xl font-open font-bold ">Register</h1>
                </div>

                <div className="w-full flex flex-col justify-center items-center mt-8">
                    <div className="flex flex-col w-80 mb-4">
                        <TextField 
                            value = {firstName} 
                            onChange = {(e) => setFirstName(e.target.value)}
                            label = "Firstname" />
                        <h1 className='text-sm text-red-600 '>{errors?.firstName ? errors.firstName[0] : ""}</h1>
                    </div>

                    <div className="flex flex-col w-80 mb-4">
                        <TextField 
                            value = {lastName}
                            onChange={(e) => setLastName(e.target.value)}
                            label = "Lastname" />
                        <h1 className='text-sm text-red-600 '>{errors?.lastName ? errors.lastName[0] : ""}</h1>
                    </div>

                    <div className="flex flex-col w-80 mb-4">
                        <TextField 
                            value = {email} 
                            onChange = {(e) => setEmail(e.target.value)}
                            label = "Email"
                        />
                        <h1 className='text-sm text-red-600 '>{errors?.email ? errors.email[0] : ""}</h1>
                    </div>
                    <div className="flex flex-col w-80 mb-4">
                        <PasswordField 
                            value = {password} 
                            handleChange = {(e) => setPassword(e.target.value)}
                            label = "Password"
                        />
                        <h1 className='text-sm text-red-600 '>{errors?.password ? errors.password[0] : ""}</h1>
                    </div>    

                    <div className="flex flex-col w-80 mb-4">
                        <PasswordField 
                            value = {confirmPassword}
                            handleChange={(e) => setConfirmPassword(e.target.value)}
                            label = "Confirm"/>
                            <h1 className='text-sm text-red-600 '>{errors?.confirmPassword ? errors.confirmPassword[0] : ""}</h1>
                    </div>

                </div>
                <div className="flex rounded-md bg-emerald-600 hover:bg-emerald-700 w-80 h-14 justify-center items-center 
                    mt-10">
                    <button
                        onClick={handleClick} 
                        className="w-full h-14 font-mukta text-md text-white">
                        REGISTER
                    </button>
                </div>
            </div>
        </div>

    )
}

export default RegisterForm;