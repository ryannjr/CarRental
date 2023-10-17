import React, { useState, useEffect } from 'react';
import Footer from '../components/Footer';
import axios from 'axios';
import CarCard from '../components/CarCard';
import SearchBar from '../components/SearchBar';

const Cars = () => {
    const [name, setName] = useState("CARS");
    const [allCars, setAllCars] = useState([]);

    useEffect(() => {
        const getAllCars = async() => {
            const cars = await axios.get("https://localhost:7207/api/cars/get-all")
            .then(res => res.data)
            .then((data) => setAllCars(data));
        }
        getAllCars();
    }, );


    return (
        <div className="flex flex-col">
            <div className=" text-black flex justify-center pt-5">
                {/*<SearchBar placeholder='Brand'/>*/}
            </div>
            <div className='flex flex-row overflow-x-auto'>
                {allCars.filter((item, index) => index <= allCars.length / 2).map((car, index) => 
                    <CarCard key = {index} Car={car}/>
                )}
            </div>
            <div className='flex flex-row overflow-x-auto'>
            {allCars.filter((item, index) => index > allCars.length / 2).map((car, index) => 
                    <CarCard key = {index} Car={car}/>
                )}
            </div>
        </div>

    );
}

export default Cars;