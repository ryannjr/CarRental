import React, { FC, useEffect } from 'react';
import Router from "./router";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./App.css"
import axios from 'axios';
import {isJwtValid} from "./requests/authRequests";


const App: FC = () => {

    return (
        <div className = "bg-DARK_THEME-BACKGROUND">
            <RouterProvider router={Router}/>
        </div>
    );
}


export default App;