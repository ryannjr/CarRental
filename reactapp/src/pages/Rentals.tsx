import axios from 'axios';
import React, {useEffect, useState} from 'react';
import RentalCard from '../components/RentalCard';

const Rentals = () => {
    const [name, setName] = useState("RENTALS");
    const [allRentals, setAllRentals] = useState([]);
    useEffect(() => {
        const getAllCars = async() => {
            const userId = localStorage.getItem("id");
            const rentals = await axios.get(`https://localhost:7207/api/rentals/get-by-id/${userId}`);
            setAllRentals(rentals.data);
        }
        getAllCars();
    }, );



    return (
        <div className='mt-40 flex flex-row overflow-x-auto'>
            {allRentals.map((rental, index) => <RentalCard key = {index} Rental={rental}/>)}
        </div>
    );
}
export default Rentals;