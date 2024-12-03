import DummmySidebar from "../components/DummySidebar";
import {CheckPlant} from "../features/recognition/index";
import styles from "./pages_styles/CheckRecognizedPlant.module.css";

const CheckRecognizedPlant = () => {
  return (
    <div className={styles.check_recognized_plant_container}>
    <DummmySidebar />
    <div className={styles.content}>
       <CheckPlant/>
    </div>
  </div>);
}

export default CheckRecognizedPlant;
