import {PlantAvatar, PlantInformation} from "../features/recognition/index";
import DummmySidebar from "../components/DummySidebar";
import Spacer from "../components/Spacer";
import styles from "./pages_styles/NewPlant.module.css";

const NewPlant = () => {
  return (
    <div className={styles.new_plant_container}>
    <DummmySidebar />
    <div className={styles.content}>
       <PlantAvatar/>
       <PlantInformation/>
    </div>
  </div>);
}

export default NewPlant;
