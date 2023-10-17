import React, { useState } from 'react';
import GetStartedBtn from '../components/GetStartedBtn';

const Home = () => {
    const [name, setName] = useState("AKT");

    return (
        <div className='w-full h-screen'>
            <div className="z-10 bg-rs7 h-screen bg-cover ">
                <div className='relative top-14'>
                    <div className='flex justify-center'>
                        <h1 className="select-none text-open text-7xl font-mooli font-bold text-transparent bg-clip-text bg-gradient-to-r from-slate-600 to-gray-500">
                            Where Adventure Meets the Road.
                        </h1>
                    </div>
                    <div className='flex justify-center relative top-96'>
                        <GetStartedBtn/>
                    </div>
                </div>
            </div>
        </div>

        /* 
        <div className='-z-20'>
            <div className='z-10 flex justify-center items-center align-middle bg'>
                <div className="bg-slate-700 flex justify-center items-center">
                    Where Adventure Meets the Road
                </div>
            </div>
            <div className="blur-[0.8px] pointer-events-none -z-30"> <img src = {RS7} alt = "Audi RS7"/> </div>

        </div>
        */
    );
}

export default Home;