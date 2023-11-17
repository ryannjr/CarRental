import React, {FC} from 'react';
import { Link, NavLink, Outlet, useNavigate, useLocation} from 'react-router-dom';

interface CarProps{

    Car: {
        id: number,
        brand: string,
        model: string,
        type: string, 
        colour: string,
        price: number,
        year: number,
        description: string
    },
    location?: boolean

}

const CarCard = ({Car, location}: CarProps) => {
    return(
        <div>
            <Outlet/>
            <div className="w-96 h-72 m-8 border-gray-950 rounded-md border-2 flex-shrink-0 none min-w-48">

                {/* CAR IMAGE*/}
                <div className="mb-24">
                    <h1> IMAGE </h1>
                </div>

                {/* CAR DETAILS */}
                <div className="mt-4"> 
                    <div className="flex justify-center flex-col items-center">
                        <h1 className = "font-open text-2xl font-semibold">{Car.brand}</h1>
                        <div className="flex flex-row gap-2">
                            <h1 className="font-open text-lg">{Car.model}</h1>
                            <h1>|</h1>
                            <h1 className="font-open text-lg">{Car.type}</h1>
                        </div>
                    </div>


                    <div className="flex justify-center mt-8">
                        <Link 
                        to = {`details/${Car.id}`} className="border-gray-950 rounded-sm border-2 bg-white text-black" 
                            >View Details</Link>
                    </div>
                </div>
            </div>
        </div>

    );
}


export default CarCard;