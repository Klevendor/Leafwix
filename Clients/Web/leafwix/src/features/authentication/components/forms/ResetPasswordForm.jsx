import { useState, useEffect } from 'react'
import styles from "./ResetPasswordForm.module.css"
import { useLocation, useNavigate } from 'react-router-dom'
import { AuthService } from '../../../../services/AuthService'
import { ValidationService } from '../../../../services/ValidationService'
import useAxiosPrivate from '../../../../hooks/useAxiosPrivate'

const ResetPasswordForm = () => {
    const navigate = useNavigate()
    const axiosPrivate = useAxiosPrivate()
    const search = useLocation().search

    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState('')

    const [password, setPassword] = useState('')
    const [confirmPassword, setConfirmPassword] = useState('')

    const [token,setToken] = useState("")
    const [email,setEmail] = useState("")

    useEffect(()=>{
        setToken(new URLSearchParams(search).get("token"));
        setEmail(new URLSearchParams(search).get("email"));
      },[])

    useEffect(()=>{
       setError("")
    },[password,confirmPassword])

    const handleResetPassword = async () =>{
        const validationResult = await ValidationService.validateResetPasswordForm(password,confirmPassword)
        if(!validationResult.isValid)
        {
            setError(validationResult.error)
            return
        }

        setIsLoading(true)
        const result = await AuthService.resetPassword(axiosPrivate, {email: email, newPassword: password, token: token})
        if(result.isError) {
            setError(result.dataOrError)
        }
        else {
            navigate("/login",{replace:true})
        }
        setIsLoading(false)
    }

    return <div className={styles.resetpassword_container}>
        <div className={styles.resetpassword_form}>
            <div className={styles.titles_container}>
                <div className={styles.form_title_container}>
                    <h1 className={styles.title}>Reset password</h1>
                </div>
                <div className={styles.form_subtitle_container}>
                    <h1 className={styles.subtitle}>Enter new password and confirm it</h1>
                </div>
            </div>
            <div className={styles.form}>
                <div className={styles.fields}>
                <div className={styles.form_input_block}>
                        <label htmlFor="password" className={styles.label}>Password</label>
                        <input id="password" className={styles.input} type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                    </div>
                    <div className={styles.form_input_block}>
                        <label htmlFor="confirmPassword" className={styles.label}>Confirm password</label>
                        <input id="confirmPassword" className={styles.input} type="password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} />
                    </div>
                </div>

                <div className={styles.info_block}>
                    <div className={styles.error_container}>
                        <p className={`${styles.error} ${error ? "" : styles.error_hidden}`}>{error}</p>
                    </div>
                </div>
                <div className={styles.actions}>
                    {isLoading ? <div className={styles.loader}></div>
                        : <button className={styles.button_reset_password} onClick={handleResetPassword}>Reset</button>}
                </div>
            </div>
        </div>
    </div>
}

export default ResetPasswordForm