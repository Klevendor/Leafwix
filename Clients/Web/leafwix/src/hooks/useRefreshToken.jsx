import { useAuth } from "./useAuth";
import { AuthService } from "../services/AuthService";

const useRefreshToken = () =>{
    const setAuth = useAuth(state => state.setAuth);

    const refresh = async () =>{

        const response = await AuthService.refreshToken();
        if(!response.isError)
        {
            setAuth(
                {
                    id: response?.dataOrError?.id,
                    email: response?.dataOrError?.email,
                    username: response?.dataOrError?.userName,
                    roles: response?.dataOrError?.roles,
                    accessToken: response?.dataOrError?.token,
                    avatarPath: response?.dataOrError?.avatarImagePath
                }
            );
            return response?.dataOrError?.token
        } else {
            return ""
        }
    }
    return refresh; 
};

export default useRefreshToken;