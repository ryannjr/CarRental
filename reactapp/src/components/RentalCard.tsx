import React, {FC} from 'react';
import { Link, NavLink, Outlet, useNavigate, useLocation} from 'react-router-dom';

interface RentalProps{
    Rental:{
        id: number,
        carId: number,
        userId: number,
        startTime: Date,
        endTime: Date,
        rentalPrice: number,
        car: null,
        user: null
    }
}

const RentalCard = ({Rental}: RentalProps) => {
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
                        <h1 className = "font-open text-2xl font-semibold"></h1>
                        <div className="flex flex-row gap-2">
                            <h1 className="font-open text-lg"></h1>
                            <h1>|</h1>
                            <h1 className="font-open text-lg"></h1>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    );
}


export default RentalCard;