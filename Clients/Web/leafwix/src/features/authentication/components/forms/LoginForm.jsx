import { useState } from 'react'
import { Link, useNavigate} from 'react-router-dom'
import { useAuth } from '../../../../hooks/useAuth'
import { AuthService } from '../../../../services/AuthService'
import { ValidationService } from '../../../../services/ValidationService'
import useAxiosPrivate from '../../../../hooks/useAxiosPrivate'
import styles from "./LoginForm.module.css"


const LoginForm = () => {
    const axiosPrivate = useAxiosPrivate()

    const setAuth = useAuth(state => state.setAuth)
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState('')

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const handleLogin = async () =>{
        const validationResult = await ValidationService.validateLoginForm(email,password)
        if(!validationResult.isValid)
        {
            setError(validationResult.error)
            return
        }


        setIsLoading(true)
        const result = await AuthService.login(axiosPrivate, {email: email, password: password})
            if(result.isError) {
                setError(result.dataOrError)
            } 
            else {
                setAuth({
                    id: result?.dataOrError?.id,
                    email: result?.dataOrError?.email,
                    username: result?.dataOrError?.userName,
                    roles: result?.dataOrError?.userRoles,
                    accessToken: result?.dataOrError?.token,
                    avatarPath: result?.dataOrError?.avatarImagePath
                })
                navigate("/home/myplants",{replace:true})
            }
            setIsLoading(false)
    }


    return <div className={styles.login_container}>
        <div className={styles.login_form}>
            <div className={styles.titles_container}>
                <div className={styles.form_title_container}>
                    <h1 className={styles.title}>Login</h1>
                </div>
                <div className={styles.form_subtitle_container}>
                    <h1 className={styles.subtitle}>Welcome back! Please login to your account.</h1>
                </div>
            </div>
            <div className={styles.form}>
                <div className={styles.fields}>
                    <div className={styles.form_input_block}>
                        <label htmlFor="email" className={styles.label}>Email</label>
                        <input id="email" className={styles.input} type="text" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </div>
                    <div className={styles.form_input_block}>
                        <label htmlFor="password" className={styles.label}>Password</label>
                            <input id="password" className={styles.input} type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                    </div>
                </div>

                <div className={styles.info_block}>
                    <div className={styles.error_container}>
                        <p className={`${styles.error} ${error ? "" : styles.error_hidden}`}>{error}</p>
                    </div>
                    <div className={styles.forgot_password_container}>
                        <Link className={`${styles.link_color} ${styles.forgot_password}`} to="/forgotpassword">Forgot password?</Link>
                    </div>
                </div>

                <div className={styles.actions}>
                    {isLoading ? <div className={styles.loader}></div> : <button className={styles.button_login} onClick={handleLogin}>Login</button>}
                    <p className={styles.text_want_login}>Don't have an account?</p>
                    <Link className={styles.link_color} to="/register">Register</Link>
                </div>
            </div>


        </div>
    </div>
}

export default LoginForm