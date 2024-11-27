import { useState } from 'react';
import { createPortal } from 'react-dom';
import { useNavigate,useLocation } from 'react-router-dom';
import { useAuth } from '../hooks/useAuth';
import useAxiosPrivate from '../hooks/useAxiosPrivate';
import { AuthService } from '../services/AuthService';
import styles from './Navbar.module.css';
import LogoutModal from '../features/authentication/components/modals/LogoutModal';

const Navbar = () => {
    const location = useLocation()
    const navigate = useNavigate()
    const setAuth = useAuth(state => state.setAuth)
    const axiosPrivate = useAxiosPrivate()

    const [showModalExitConfirm,setShowModalExitConfirm] = useState(false)

    const handleRedirectTo = (redirectPartUrl) =>{
        if(location.pathname != redirectPartUrl)
            navigate(`${redirectPartUrl}`)
    }

    const handleLogout = async () =>{
        const result = await AuthService.logout(axiosPrivate)
        if(!result.isError) {
            setAuth({
                id: "",
                email: "",
                username: "",
                roles: [],
                accessToken: "",
                avatarPath: ""
            })
            navigate("/login",{replace:true})
        } 
    }

    return (
        <aside className={styles.sidebar_block}>
            <div className={styles.sidebar_container}>
                <div className={styles.sidebar_menu}>
                        <div className={styles.menu_options_container}>
                            <div className={`${styles.menu_option} ${location.pathname.includes("/home/myplants") ? styles.active_option : ""}`}
                            onClick={()=>handleRedirectTo("/home/myplants")}>
                                <i className="fa-solid fa-seedling"></i>
                            </div>
                            <div className={`${styles.menu_option} ${location.pathname.includes("/home/history")? styles.active_option : ""}`}
                            onClick={()=>handleRedirectTo("/home/history")}>
                                <i class="fa-solid fa-calendar-days"></i>
                            </div>
                            <div className={`${styles.menu_option} ${location.pathname == "/home/myprofile"? styles.active_option : ""}`}
                            onClick={()=>handleRedirectTo("/home/myprofile")}>
                                <i className="fa-solid fa-user"></i>
                            </div>
                            <div className={`${styles.menu_option} ${styles.mobile_option_list}`}
                            onClick={() => setShowModalExitConfirm(true)}>
                            <i className="fa-solid fa-right-from-bracket"></i>
                        </div>
                        </div>
                        <div className={`${styles.menu_option} ${styles.mobile_option}`}
                        onClick={() => setShowModalExitConfirm(true)}>
                            <i className="fa-solid fa-right-from-bracket"></i>
                        </div>
                </div>
            </div>
            {showModalExitConfirm && createPortal(
            <LogoutModal closeModal={() => setShowModalExitConfirm(false)} logout={handleLogout}/>,
            document.body
            )}
        </aside>
    )
}

export default Navbar


