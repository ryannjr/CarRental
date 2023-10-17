import axios from "axios"

const BASE = "https://localhost:7207/api/";

export const isJwtValid = async(token)  =>  {
    try{
        const validJwt = await axios.post(BASE + "auth/verify", 
            {
                refreshToken: token
            }
        );
        console.log(validJwt);
        return validJwt
    } catch(err){
        return false
    }
}