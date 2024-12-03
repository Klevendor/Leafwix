import { useEffect } from "react";
import useRecognitionStore from "../../../../context/useRecognitionStore";
import { RecognitionService } from "../../../../services/RecognitionService";

import styles from "./PlantAvatar.module.css";

const PlantAvatar = () => {

  const {plant_age, predictedLabel} = useRecognitionStore()

  useEffect(() =>{

  },[pla])

  return (
    <div className={styles.plant_avatar_container}>
       <div className={styles.plant_name_container}>
        <input className={styles.plant_name} type="text" placeholder="Enter plant name"/>
      </div>
      <div className={styles.plant_container}>
            <div className={styles.plant}>
                <img src="/species/small African Violet.svg" width="340px" height="340px" />
            </div>
            <div className={styles.pot}>
                <img src="/pot.svg" width="260px" height="240px"/>
            </div> 
            <div className={styles.eyes_dissatisfaction}></div>
        </div>
     
  </div>);
}

export default PlantAvatar;
