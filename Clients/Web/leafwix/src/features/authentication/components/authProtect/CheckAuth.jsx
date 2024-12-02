import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../../../../hooks/useAuth";

const CheckAuth = () =>{
    const auth = useAuth(state => state.auth);

    return (
        auth?.accessToken && auth.accessToken !== ""
        ? <Navigate to="/home/myplants" replace/>
        : <Outlet/> 
    );
}

export default CheckAuth;