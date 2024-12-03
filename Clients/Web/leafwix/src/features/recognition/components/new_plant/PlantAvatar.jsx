import styles from "./PlantAvatar.module.css";

const PlantAvatar = () => {
  return (
    <div className={styles.plant_avatar_container}>
       <div className={styles.plant_name_container}>
        <input className={styles.plant_name} type="text" placeholder="Enter plant name"/>
      </div>
      <div className={styles.plant_container}>
            <div className={styles.plant}>
                <img src="/default_plant.svg" width="340px" height="340px" />
            </div>
            <div className={styles.pot}>
                <img src="/pot.svg" width="260px" height="240px"/>
            </div> 
            <div className={styles.eyes_dissatisfaction}></div>
        </div>
     
  </div>);
}

export default PlantAvatar;
