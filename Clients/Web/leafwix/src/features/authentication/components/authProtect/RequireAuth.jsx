import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../../../../hooks/useAuth";

const RequireAuth = ({allowedRoles}) =>{
    const auth = useAuth(state => state.auth);

    return (
        auth?.roles?.find(role => allowedRoles?.includes(role))
        ? <Outlet/> 
        : <Navigate to="/login" replace/>
    )
}

export default RequireAuth;