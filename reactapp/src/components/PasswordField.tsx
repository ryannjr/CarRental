import React, {FC} from 'react'
import TextField from "@mui/material/TextField";
import { FormControl, IconButton, InputAdornment, InputLabel, OutlinedInput } from '@mui/material';
import { Visibility }from '@mui/icons-material';
import { VisibilityOff } from "@mui/icons-material/";

interface props{
    label: string
    value: string
    handleChange: React.ChangeEventHandler<HTMLInputElement>
}

const PasswordField = (props: props) => {
    const [showPassword, setShowPassword] = React.useState(false);

    const handleClickShowPassword = () => setShowPassword((show) => !show);
  
    const handleMouseDownPassword = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
    };
    return(
        <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-adornment-password">{props.label}</InputLabel>
            <OutlinedInput 
                value = {props.value}
                onChange={props.handleChange}
                id="outlined-adornment-password"
                type={showPassword ? 'text' : 'password'}
                endAdornment={
                <InputAdornment position="end">
                    <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleClickShowPassword}
                    onMouseDown={handleMouseDownPassword}
                    edge="end"
                    >
                    {showPassword ? <VisibilityOff className='text-black' /> : <Visibility className='text-black' />}
                    </IconButton>
                </InputAdornment>
                }
                label="Password"
            />
        </FormControl>
    );
}

export default PasswordField;