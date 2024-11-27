import LoginForm from "../features/authentication/components/forms/LoginForm";
import VisualPart from "../features/authentication/components/visual/VisualPart";
import styles from "./pages_styles/Login.module.css";

const Login = () => {
    return<div className={styles.container}>
    <VisualPart figureStyle="circle" side={"left"} isHeader={false}/>
    <LoginForm/>
  </div>
}

export default Login;