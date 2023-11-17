import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider, Routes, } from "react-router-dom";
import Home from "./pages/Home";
import About from "./pages/About";
import React from "react";
import RootElement from "./RootElement";
import Cars from "./pages/Cars";
import Register from "./pages/Register";
import Login from "./pages/Login";
import CarDetails from "./components/CarDetails";
import Profile from "./pages/Profile";
import Rentals from "./pages/Rentals";
import NotFound from "./pages/NotFound";
import SuccessStripe from "./pages/SuccessStripe";
import CancelStripe from "./pages/CancelStripe";

const Router = createBrowserRouter(
    createRoutesFromElements(
        <Route path="/" element={<RootElement/>} >
            <Route index element={<Home/>}/>
            <Route path = "cars">
                <Route index element={<Cars/>}/>
                <Route path = "details/:id" element = {<CarDetails/>}/>
            </Route>
            <Route path="about" element={<About />} />
            <Route path="register" element={<Register/>}/>
            <Route path="login" element={<Login/>}/>
            <Route path = "profile" element= {<Profile/>}/>
            <Route path = "rentals" element= {<Rentals/>}/>
            <Route path = "*" element = {<NotFound/>}/>
            <Route path = "success" element = {<SuccessStripe/>}/>
            <Route path = "cancel" element = {<CancelStripe/>}/>
        </Route>
    )
);


export default Router;