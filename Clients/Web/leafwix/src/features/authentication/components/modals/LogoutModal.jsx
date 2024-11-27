import { useState } from "react"
import styles from "./LogoutModal.module.css"


const LogoutModal = ({closeModal, logout}) => {
    const [isLoading,setIsLoading] = useState(false)

    const handleLogout = async () =>{
        setIsLoading(true);
        logout()
        setIsLoading(false);
    }
   
    return (
        <div className={styles.modal}>
                <div className={styles.center}>
                    <div className={styles.modal_container}>
                        <div className={styles.control_panel}>
                            <p className={styles.title}>Logout</p>
                            <i className={`fa-solid fa-rectangle-xmark ${styles.close}`} onClick={closeModal}></i>
                        </div>
                        <div className={styles.info_container}>
                            <label className={styles.info_title}>Are you sure you want to exit?</label>
                        </div>
                        <div className={styles.action_panel}>
                            {
                                isLoading
                                ? <div className={styles.loader}></div>
                                : <>
                                 <button className={styles.yes_button} onClick={handleLogout}>Yes</button>
                            <button className={styles.no_button} onClick={closeModal}>No</button>
                            </>
                            }
                        </div>
                        
                    </div>
                </div>
            </div>
    )
}

export default LogoutModal;