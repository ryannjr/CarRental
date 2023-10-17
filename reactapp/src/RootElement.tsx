import React, { FC, useEffect, useState } from 'react';
import { Link, Outlet } from "react-router-dom";
import "./index.css";
import NavButton from './components/NavButton';
import AuthPopup from './components/AuthPopup';
import {ImCancelCircle} from "react-icons/im";
import AuthButton from './components/AuthButton';
import { RiAccountCircleFill} from "react-icons/ri";
import AKT from "./assets/AKT.png";
import Footer from './components/Footer';
import {FaPhone} from "react-icons/fa6";
import {IoMdMail} from "react-icons/io";
import axios from 'axios';
import { isJwtValid } from './requests/authRequests';

const RootElement: FC = () => {
    const [reveal, setReveal] = useState(false);

    const conceal = () => {
        setReveal(false);
    }

    const LoginRegisterBtn = () => {
        return(
            <>
                <RiAccountCircleFill className = "w-9 h-9 text-black cursor-pointer hover:scale-110" onClick={() => setReveal(reveal => !reveal)} />
            </>
        )
    }


    return (
        <div className='flex flex-col'>

            {/* TOP NAV */}
            <div className="flex flex-row bg-THEME-LIGHT_WHITE h-14 items-center">
                <div className="flex justify-center w-1/2">
                    <h1 className="text-black font-bold">Any Car. Any Time. Any Where.</h1>
                </div>
                <div className="flex flex-row justify-center w-1/2">
                    <div className="flex justify-center flex-row gap-2">
                        <FaPhone className="w-4 h-4 relative top-1 text-black"/>
                        <h1 className="text-black font-bold">777-777-7777</h1>
                    </div>

                    <div className="flex justify-center flex-row gap-2 pl-8">
                        <IoMdMail className="w-5 h-4 relative top-1 text-black"/>
                        <h1 className="text-black font-bold">inquiries@aktrentals.com</h1>
                    </div>
                </div>
            </div>

            {/* BOTTOM NAV */}
            <div className="flex justify-between items-center bg-THEME-WHITE h-24">

                {/* LOGO (HOME)*/}
                <div className='ml-5 select-none'>
                    <Link className="text-black" to="/"><img src={AKT} className="w-16 hover:scale-110"/></Link>
                </div>

                {/* INVENTORY BUTTON*/}
                <div>
                    <NavButton label = "INVENTORY" link="cars" />
                </div>

                {/*LOGIN/REGISTER*/}
                <div className='mr-5'>
                    <LoginRegisterBtn/>
                </div>
            </div>

            <main className=" bg-THEME-WHITE h-screen">
                <AuthPopup reveal = {reveal}>
                    <div className="flex flex-col bg-zinc-900/90 rounded-2xl border-2  w-80">

                        <div className="flex flex-row justify-center py-3">
                            <ImCancelCircle className = "text-white cursor-pointer transition transform hover:-rotate-90 text-lg relative left-32 hover:text-red-500"
                            onClick={() => setReveal(false)} />
                        </div>

                        <div className="flex flex-row">
                            <div className="flex flex-col px-4 py-2 w-full">
                                <div className="">
                                    <h1 className="text-sl text-slate-200 font-mukta justify-center flex pt-5">DONT HAVE AN ACCOUNT?</h1>
                                </div>

                                <div className='flex justify-center pt-2 pb-2'>
                                    <AuthButton handleClick = {conceal} isLogin = {false}/>
                                </div>
                            </div>
                        </div>

                        <div className="flex flex-row">
                            <div className="flex flex-col px-4 py-2 w-full">
                                <div className="">
                                    <h1 className="text-sl text-slate-200 font-mukta justify-center flex pt-5">ALREADY HAVE AN ACCOUNT?</h1>
                                </div>

                                <div className='flex justify-center pt-2 pb-10'>
                                    <AuthButton handleClick = {conceal} isLogin = {true}/>
                                </div>
                            </div>
                        </div>
                    </div>
                </AuthPopup>
                <Outlet/>
            </main>

            {/* FOOTER */}
            <Footer/>
        </div>
    );

}

export default RootElement;