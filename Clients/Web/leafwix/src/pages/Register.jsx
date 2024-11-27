import { RegisterForm, VisualPart } from "../features/authentication";
import styles from "./pages_styles/Register.module.css"

const Register = () => {
    return<div className={styles.container}>
    <RegisterForm/>
    <VisualPart figureStyle="diamond" side={"right"} isHeader={false}/>
  </div>
}

export default Register;