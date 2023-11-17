import React, {FC, useState} from 'react';
import {FaSnapchatGhost, FaFacebookSquare, FaTwitter, FaYoutube} from "react-icons/fa";
import {PiInstagramLogoFill} from "react-icons/pi"




const Footer: FC = () => {

    const [click, setClick] = useState(true);
    const fakeClick = () =>{
        setClick(click => !click);
    }

    return(
        <footer className=" bg-THEME-LIGHT_GRAY flex flex-row ">
            <div className="flex justify-center items-center w-1/2 h-24">
                <h1 className="text-black font-bold font-mukta">© 2023 | AKT Car Rental, Inc. All Rights Reserved.</h1>
            </div>

            <div className="flex flex-row justify-center gap-10 items-center w-1/2">
                <FaSnapchatGhost onClick={fakeClick} className="cursor-pointer w-6 h-6 text-black hover:scale-125"/>
                <PiInstagramLogoFill onClick={fakeClick} className="cursor-pointer w-6 h-6 text-black hover:scale-125"/>
                <FaFacebookSquare onClick={fakeClick} className="cursor-pointer w-6 h-6 text-black hover:scale-125"/>
                <FaTwitter onClick={fakeClick} className="cursor-pointer w-6 h-6 text-black hover:scale-125"/>
                <FaYoutube onClick={fakeClick} className="cursor-pointer w-6 h-6 text-black hover:scale-125"/>
            </div>
        </footer>
    );
}


export default Footer;