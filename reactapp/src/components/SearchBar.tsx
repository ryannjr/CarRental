import React, {FC, useState} from 'react';
import axios from 'axios';
import { Input, InputGroup, InputLeftElement } from '@chakra-ui/react'
import { TbBrandToyota } from "react-icons/tb";


interface props{
    placeholder: string,

}

const SearchBar = (props: props) => {
    const [brand, setBrand] = useState("");

    return(

        <div className="flex relative top-4 rounded-md border-red-500 ">
            <input placeholder="Brand"></input>
        </div>
    );
}

export default SearchBar;