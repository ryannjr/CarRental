import React, {FC} from 'react';
import {FaCheckCircle, FaHome} from "react-icons/fa";
import { Link } from 'react-router-dom';
const SuccessStripe: FC = () => {
    return(
        <div className='flex justify-center items-center align-middle text-center h-96'>
            
            <div className='flex flex-col justify-center border-2 rounded-md border-gray-300 w-1/4 h-96 mt-60'>
                <div className='flex flex-row justify-center items-center'>
                    <h1 className="text-bold text-2xl font-open">Purchase Complete</h1>
                    <FaCheckCircle className="text-green-500 ml-2 text-2xl"/>
                </div>

                <div className='flex flex-col justify-center items-center mt-10 gap-6 '>
                    <h1 className="text-bold text-xl font-open">Return Home</h1>
                    <Link to = "/">
                        <FaHome className="text-blue-800 ml-2 text-2xl justify-center items-center"/>
                    </Link>

                </div>

            </div>
        </div>
        );
}

export default SuccessStripe;