import DummmySidebar from "../components/DummySidebar";
import {RecognizePlant} from "../features/recognition/index";
import styles from "./pages_styles/Recognition.module.css";

const Recognition = () => {
  return (
    <div className={styles.recognition_container}>
    <DummmySidebar />
    <div className={styles.content}>
       <RecognizePlant/>
    </div>
  </div>);
}

export default Recognition;
