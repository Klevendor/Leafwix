import DummmySidebar from "../components/DummySidebar";
import {ChangePlant} from "../features/recognition/index";

import styles from "./pages_styles/ChangeRecognizedPlant.module.css";

const ChangeRecognizedPlant = () => {
  return (
    <div className={styles.change_recognized_plant_container}>
    <DummmySidebar />
    <div className={styles.content}>
       <ChangePlant/>
    </div>
  </div>);
}

export default ChangeRecognizedPlant;
