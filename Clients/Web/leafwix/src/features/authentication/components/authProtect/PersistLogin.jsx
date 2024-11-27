import { Outlet } from "react-router-dom";
import { useState, useEffect } from "react";
import useRefreshToken from "../../../../hooks/useRefreshToken";
import { useAuth } from "../../../../hooks/useAuth";
import Loading from "../../../../components/Loading";

const PersistLogin = () => {
    const [isLoading, setIsLoading] = useState(true)
    const refresh = useRefreshToken();
    const auth = useAuth(state => state.auth);

    const verifyRefreshToken = async () => {
        try {
            await refresh();
        }
        catch (err) {
            console.log(err);
        }
        finally {
            setIsLoading(false)
        }
    }

    useEffect(() => {
        !auth?.accessToken ? verifyRefreshToken() : setIsLoading(false)
    }, [])
    
    return (
        <>  
            {  isLoading ? <Loading/>: <Outlet />}
        </>
    )
}

export default PersistLogin;