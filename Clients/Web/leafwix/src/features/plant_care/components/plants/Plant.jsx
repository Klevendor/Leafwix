import styles from "./Plant.module.css";

const Plant = ({path}) => {
    return <div className={styles.plant_container}>
            <div className={styles.plant}>
                <img src={`/species/${path}`} width="300px" height="300px" />
            </div>
            <div className={styles.pot}>
                <img src="/pot.svg" width="260px" height="240px"/>
            </div> 
            <div className={styles.eyes_dissatisfaction}></div>
        </div>
}

export default Plant;