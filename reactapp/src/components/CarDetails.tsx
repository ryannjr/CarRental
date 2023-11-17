import React, {FC, useEffect, useState} from 'react';
import { useParams, useLocation, useNavigate, redirect} from 'react-router-dom';
import axios from 'axios';
import {FaCarSide} from "react-icons/fa6";
import {TbManualGearbox} from "react-icons/tb";
import {MdColorLens} from "react-icons/md";
import {IoMdPerson} from "react-icons/io";
import { DateRangePicker } from "@mui/x-date-pickers-pro/DateRangePicker";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import dayjs from 'dayjs';
import { DatePicker, DesktopDatePicker } from '@mui/x-date-pickers';
import jwt_decode from 'jwt-decode';
import { Stripe, loadStripe } from '@stripe/stripe-js';

interface CarProps{
    id: number,
    brand: string,
    model: string,
    type: string, 
    transmission: string,
    capacity: number,
    colour: string,
    price: number,
    year: number,
    description: string
    image: string

}


const today = dayjs();
const tomorrow = dayjs().add(1, "day");

const CarDetails = (props: CarProps) => { 
    const {id} = useParams();
    const [uID, setUID] = useState("")
    const [car, setCar] = useState<CarProps>();
    const [startTime, setStartTime] = useState(today);
    const [endTime, setEndTime] = useState(tomorrow);
    const [amount, setAmount] = useState(endTime.diff(startTime, "day"));
    const [image, setImage] = useState(null);
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        var token = localStorage.getItem("token");
        if(token !== null) {
            const token_obj = jwt_decode(token);
            setUID(token_obj.userID);
        }
    })

    useEffect(() => {
        const getCarById = async() => {
            try{
                const res = await axios.get(`https://localhost:7207/api/cars/${id}`);
                setCar(res.data);
            } catch(e){ 
                console.log(e);
            }
        }
        getCarById();
    }, []);

    useEffect(() => {
        setAmount(endTime.diff(startTime, "day") + 1);
    }, [startTime, endTime]);

    const handleClick = async() => {
        setLoading(true);

        if(uID == ""){
            setTimeout(() => {
                navigate("/login");
            }, 500);
        }

        try{
            const now = dayjs().format('YYYY-MM-DDTHH:mm:ss');
            const returnTime = dayjs().add(amount).format('YYYY-MM-DDTHH:mm:ss');

            const rental = await axios.post("https://localhost:7207/api/rentals", 
                {
                    "startTime": now,
                    "endTime": returnTime,
                    "rentalPrice": car ? amount * car.price : 0,
                    "carId": id,
                    "userId": uID
                }
            );
            
            const payment = await axios.post("https://localhost:7207/api/payment/create-checkout", rental.data);
            console.log(payment.data);

            const stripe = await loadStripe("pk_test_51NCcoSIsKVpzm8uHHmwlilzcbSaeOAhVvmdrFzVk5K4bkXjrf7xb0DNRiht6IUiAf3IxGiyuoLN59ELKmtE33NUc00ksADdSrU");
            await stripe.redirectToCheckout({sessionId: payment.data});
            


        } catch(err) {
            console.log(err)
        }
    }
        

    return (
    <div className="flex flex-row mt-20 mb-32">
        <div className='flex w-1/3 justify-center'>
            <div className="bg-white rounded border-4 border-black flex w-[500px]"></div>
        </div>

        <div className='flex flex-col items-center justify-center w-1/3'>
            <div className='flex flex-row gap-3 font-mooli font-extrabold'>
                <h1 className='text-4xl'>{car?.brand}</h1>
                <h1 className='text-4xl'>{car?.model}</h1>  
            </div>
            <div className=" mt-4 rounded-sm bg-slate-100 border-2 border-black px-6 py-1">
                <h1 className="text-md font-bold ">{car?.year}</h1>
            </div>

            <div className="flex flex-row gap-1 mt-6">
                <div className='flex flex-row justify-center items-center gap-1'>
                    <FaCarSide className="text-md text-black"/>
                    <h1 className='text-sm font-bold'>{car?.type}</h1>
                    <h1>I</h1>
                </div>
                <div className='flex flex-row justify-center items-center gap-1'>
                    <IoMdPerson className="text-md text-black"/>
                    <h1 className='text-sm font-bold'>{car?.capacity} person(s)</h1>
                    <h1>I</h1>
                </div>
                <div className='flex flex-row justify-center items-center gap-1'>
                    <TbManualGearbox className="text-md text-black"/>
                    <h1 className='text-sm font-bold'>{car?.transmission}</h1>
                    <h1>I</h1>
                </div>
                <div className='flex flex-row justify-center items-center gap-1'>
                    <MdColorLens className="text-md text-black"/>
                    <h1 className='text-sm font-bold'>{car?.colour}</h1>
                    <h1></h1>
                </div>
            </div>
            <div className="mt-10">
                <h1 className="text-lg">
                    {car?.description}
                </h1>
            </div>
        </div>
        <div className='flex items-center justify-center w-1/3'>
            <div className="flex flex-col items-center justify-center w-1/2 border-2 rounded-md border-black">

                <div className='mt-5 w-full flex flex-col items-center justify-center'>
                    <h1 className='font-open font-bold text-3xl '>Order Now</h1>
                    <h1 className='font-open mt-4 text-2xl font-semibold'>${car?.price}<span className="font-open text-sm">/day</span></h1>
                </div>
                <div className="flex flex-col mt-10 mb-10">
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <div className='mb-5'>
                            <DesktopDatePicker label = "Pick-Up" disablePast = {true} value={startTime} 
                                onChange={(time) => time && setStartTime(time)}/>
                        </div>
                        <div className='mt-5'>
                            <DatePicker label = "Return" disablePast = {true} minDate={startTime}
                                value={endTime} onChange = {(time) => time && setEndTime(time)}/>
                        </div>
                    </LocalizationProvider>
                </div>
                <div className='mt-10 mb-5'>
                    <h1 className="font-open text-xl font-bold"> ~${amount * car?.price}</h1>
                </div>
                <div className="flex rounded border-emerald-700 border-2 w-1/2 justify-center mb-10 h-10
                    bg-emerald-700 hover:bg-emerald-900 hover:border-emerald-900 text-white font-mooli">
                    <button onClick = {handleClick} className='w-full h-full font-mukta text-md'>CHECKOUT</button>
                </div>

            </div>

        </div>
    </div>);
}


export default CarDetails;