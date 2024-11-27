import { useEffect } from "react";
import { useAuth } from "./useAuth";
import useRefreshToken from "./useRefreshToken";
import { baseAxios } from "../lib/Axios";

const useAxiosPrivate = () =>{
    const refresh = useRefreshToken();
    const auth = useAuth(state => state.auth);

    useEffect(() =>{

        const requestIntercept = baseAxios.interceptors.request.use(
            config => {
                if (!config.headers["Authorization"]){
                    config.headers["Authorization"] = `Bearer ${auth.accessToken}`
                }
                return config;
            }, (error) => Promise.reject(error)

        );

        const responseIntercept = baseAxios.interceptors.response.use(
            response => response,
            async (error) => {
                const prevRequest = error?.config;
                if(error?.response?.status === 401 && !prevRequest?._retry){
                    prevRequest._retry = true;
                    const accessToken = await refresh();
                    prevRequest.headers["Authorization"] = `Bearer ${accessToken}`;
                    return baseAxios(prevRequest);
                }
                return Promise.reject(error);
            }
        );

        return () =>{
            baseAxios.interceptors.request.eject(requestIntercept);
            baseAxios.interceptors.response.eject(responseIntercept);
        }

    },[auth,refresh])

    return baseAxios;
}

export default useAxiosPrivate;