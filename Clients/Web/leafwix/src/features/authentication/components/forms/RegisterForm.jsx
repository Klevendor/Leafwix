import { useState, useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { AuthService } from '../../../../services/AuthService'
import { ValidationService } from '../../../../services/ValidationService'
import styles from "./RegisterForm.module.css"
import useAxiosPrivate from '../../../../hooks/useAxiosPrivate'

const RegisterForm = () => {
    const navigate = useNavigate()
    const axiosPrivate = useAxiosPrivate()

    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState('')

    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [confirmPassword, setConfirmPassword] = useState('')

    useEffect(()=>{
        setError("")
    },[username,email,password,confirmPassword])

    const handleRegister = async () =>{
        
        const validationResult = await ValidationService.validateRegisterForm(username,email,password,confirmPassword)
        if(!validationResult.isValid)
        {
            setError(validationResult.error)
            return
        }

        setIsLoading(true)
        const result = await AuthService.register(axiosPrivate, {username: username,email: email, password: password})
        if(result.isError) {
            setError(result.dataOrError)
        }
        else {
            navigate("/login",{replace:true})
        }
        setIsLoading(false)
    }


    return <div className={styles.register_container}>
        <div className={styles.register_form}>
            <div className={styles.titles_container}>
                <div className={styles.form_title_container}>
                    <h1 className={styles.title}>Register</h1>
                </div>
                <div className={styles.form_subtitle_container}>
                    <h1 className={styles.subtitle}>Welcome to NovelsWord! Please enjoy your works!</h1>
                </div>
            </div>
            <div className={styles.form}>
                <div className={styles.fields}>
                    <div className={styles.form_input_block}>
                        <label htmlFor="username" className={styles.label}>Username</label>
                        <input id="username" className={styles.input} type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
                    </div>
                    <div className={styles.form_input_block}>
                        <label htmlFor="email" className={styles.label}>Email</label>
                        <input id="email" className={styles.input} type="text" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </div>
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
                    {isLoading ? <div className={styles.loader}></div> : <button className={styles.button_register} onClick={handleRegister}>Register</button>}
                    <p className={styles.text_want_login}>Do you have an account?</p>
                    <Link className={styles.link_color} to="/login">Login</Link>
                </div>
            </div>


        </div>
    </div>
}

export default RegisterForm