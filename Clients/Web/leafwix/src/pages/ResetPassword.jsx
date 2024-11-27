import { VisualPart, ResetPasswordForm } from "../features/authentication";
import styles from "./pages_styles/ResetPassword.module.css"

const ResetPassword = () => {
    return<div className={styles.container}>
    <VisualPart figureStyle={"none"} side={"none"} isHeader={true}/>
    <ResetPasswordForm/>
  </div>
}

export default ResetPassword;