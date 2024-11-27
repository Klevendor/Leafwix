import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { AuthService } from '../../../../services/AuthService'
import { ValidationService } from '../../../../services/ValidationService'
import styles from "./ForgotPasswordForm.module.css"
import useAxiosPrivate from '../../../../hooks/useAxiosPrivate'

const ForgotPasswordForm = () => {
    const navigate = useNavigate()
    const axiosPrivate = useAxiosPrivate()

    const [isPasswordReset, setIsPasswordReset] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [information, setInformation] = useState("")
    const [error, setError] = useState('')

    const [email, setEmail] = useState('')

    const handleForgotPassword = async () =>{
        const validationResult = await ValidationService.validateForgotPasswordForm(email)
        if(!validationResult.isValid)
        {
            setError(validationResult.error)
            return
        }

        setIsLoading(true)
        const result = await AuthService.forgotPassword(axiosPrivate, {email: email})
        if(result.isError) {
            setError(result.dataOrError)
        } 
        else {
            setInformation("Check your mailbox")
            setIsPasswordReset(true)
        }
        setIsLoading(false)
    }

    return <div className={styles.forgotpassword_container}>
        <div className={styles.forgotpassword_form}>
            <div className={styles.titles_container}>
                <div className={styles.form_title_container}>
                    <h1 className={styles.title}>Forgot password?</h1>
                </div>
                <div className={styles.form_subtitle_container}>
                    <h1 className={styles.subtitle}>No worries! Please enter your email and click restore!</h1>
                </div>
            </div>
            <div className={styles.form}>
                <div className={styles.fields}>
                    <div className={styles.form_input_block}>
                        <label htmlFor="email" className={styles.label}>Email</label>
                        <input id="email" className={styles.input} type="text" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </div>
                </div>

                <div className={styles.info_block}>
                    <div className={styles.error_container}>
                        {
                            isPasswordReset
                            ? <p className={`${styles.information} ${information ? "" : styles.error_hidden}`}>{information}</p>
                            : <p className={`${styles.error} ${error ? "" : styles.error_hidden}`}>{error}</p>
                        }
                    </div>
                </div>

                <div className={styles.actions}>
                    {isLoading ? <div className={styles.loader}></div>
                        : isPasswordReset
                            ? <button className={styles.button_reset_password} onClick={() => navigate("/login")}>Return</button>
                            : <button className={styles.button_reset_password} onClick={handleForgotPassword}>Send</button>}
                    <p className={styles.text_want_login}>Remember your password?</p>
                    <Link className={styles.link_color} to="/login">Login</Link>
                </div>
            </div>
        </div>
    </div>
}

export default ForgotPasswordForm