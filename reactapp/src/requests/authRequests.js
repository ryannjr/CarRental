import axios from "axios"

const BASE = "https://localhost:7207/api/";

export const isJwtValid = async(token)  =>  {
    try{
        const validJwt = await axios.post(BASE + "auth/verify-access", 
            {
                accessToken: token
            }
        );
        return validJwt.data
    } catch(err){
        return false
    }
}

export const isRefreshValid = async(token)  =>  {
    try{
        const validRefresh = await axios.post(BASE + "auth/verify-refresh", 
            {
                refreshToken: token
            }
        );
        return validRefresh.data
    } catch(err){
        return false
    }
}

export const refreshToken = async(refreshToken) => {
    try{
        const refresh = await axios.post(BASE + "auth/refresh", 
        {
            refreshToken: refreshToken
        });
        return refresh.data;
    } catch(err) {
        console.log(err);
    }
}

