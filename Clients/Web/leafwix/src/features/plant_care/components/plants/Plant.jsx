import styles from "./Plant.module.css";

const Plant = () => {
    return <div className={styles.plant_container}>
            <div className={styles.plant}>
                <img src="/default_plant.svg" width="340px" height="340px" />
            </div>
            <div className={styles.pot}>
                <img src="/pot.svg" width="260px" height="240px"/>
            </div> 
            <div className={styles.eyes_dissatisfaction}></div>
        </div>
}

export default Plant;