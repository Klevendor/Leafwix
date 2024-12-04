import { useEffect, useState } from "react";
import useRecognitionStore from "../../../../context/useRecognitionStore";
import { RecognitionService } from "../../../../services/RecognitionService";

import styles from "./PlantAvatar.module.css";

const PlantAvatar = ({name,setName}) => {

  const [image_path, setImagePath] = useState("big_default_plant.svg")
  const {plant_age, predictedLabel} = useRecognitionStore()

  useEffect(() =>{
    setImagePath(RecognitionService.getPlantView(plant_age,predictedLabel))
  },[plant_age,predictedLabel])

  return (
    <div className={styles.plant_avatar_container}>
       <div className={styles.plant_name_container}>
        <input value={name} onChange={(e) => setName(e.target.value)} className={styles.plant_name} type="text" placeholder="Enter plant name"/>
      </div>
      <div className={styles.plant_container}>
            <div className={styles.plant}>
                <img src={`/species/${image_path}`} width="340px" height="340px" />
            </div>
            <div className={styles.pot}>
                <img src="/pot.svg" width="260px" height="240px"/>
            </div> 
            <div className={styles.eyes_dissatisfaction}></div>
        </div>
     
  </div>);
}

export default PlantAvatar;
