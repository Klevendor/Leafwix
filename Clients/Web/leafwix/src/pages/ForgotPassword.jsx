import { VisualPart, ForgotPasswordForm } from "../features/authentication";
import styles from "./pages_styles/ForgotPassword.module.css";

const ForgotPassword = () => {
    return<div className={styles.container}>
    <VisualPart figureStyle={"none"} side={"none"} isHeader={true}/>
    <ForgotPasswordForm/>
  </div>
}

export default ForgotPassword;