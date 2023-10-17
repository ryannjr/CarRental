import React, {FC, useState} from 'react';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';
interface NavButtonProps{
    label: string,
    link: string,
    handleClick?: React.MouseEventHandler
}


const NavButton: FC<NavButtonProps> = (props: NavButtonProps) => {
    const [clicked, setClicked] = useState(false);

    return(
        <Link to = {props.link}>
            <button onClick={props.handleClick} 
            className="text-black font-bold border-none outline-nonepx-4 py-2 transition duration-300 ease-in-out ">
                {props.label}
            </button>
        </Link>

    );
} 

export default NavButton;