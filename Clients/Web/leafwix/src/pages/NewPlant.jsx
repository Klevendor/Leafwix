import {PlantAvatar, PlantInformation} from "../features/recognition/index";
import DummmySidebar from "../components/DummySidebar";
import Spacer from "../components/Spacer";
import styles from "./pages_styles/NewPlant.module.css";
import { useState } from "react";

const NewPlant = () => {
  const [name, setName] = useState("")

  return (
    <div className={styles.new_plant_container}>
    <DummmySidebar />
    <div className={styles.content}>
       <PlantAvatar name={name} setName={setName}/>
       <PlantInformation name={name}/>
    </div>
  </div>);
}

export default NewPlant;
