import React, {FC} from 'react';
import { Link } from 'react-router-dom';
import { Button} from '@mui/material';
import {ImUserPlus} from "react-icons/im";
import { makeStyles, Theme } from '@mui/material';
import {IoMdLogIn} from 'react-icons/io';

interface AuthButtonProps{
    isLogin: boolean
    handleClick: React.MouseEventHandler
}


const AuthButton: FC<AuthButtonProps> = ({isLogin, handleClick}: AuthButtonProps) => {
    return(
    <>
        {isLogin ? 
            <div className=''>
                <Button onClick = {handleClick} variant = "contained" startIcon = {<IoMdLogIn/>} color='primary'>
                    <Link to = 'login'>LOGIN</Link>
                </Button>
            </div>
        :         
            <div className="font-open">
                <Button onClick = {handleClick} variant = "contained" startIcon = {<ImUserPlus/>} color='success'>
                    <Link to = 'register'>SIGNUP</Link>
                </Button>
            </div>
        }
    </>
    );
}




export default AuthButton;