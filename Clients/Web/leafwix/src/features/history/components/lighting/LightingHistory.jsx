import styles from "./LightingHistory.module.css";

const LightingHistory = () => {
    return<div className={styles.container}>
     <div className={styles.history_card}>
        <div className={styles.datetime_container}>
            12/23/2024
        </div>
        <div className={styles.plant_name_container}>
            <p>John</p>
        </div>
    </div>
    <div className={styles.history_card}>
        <div className={styles.datetime_container}>
            12/23/2024
        </div>
        <div className={styles.plant_name_container}>
            <p>John</p>
        </div>
    </div><div className={styles.history_card}>
        <div className={styles.datetime_container}>
            12/23/2024
        </div>
        <div className={styles.plant_name_container}>
            <p>John</p>
        </div>
    </div><div className={styles.history_card}>
        <div className={styles.datetime_container}>
            12/23/2024
        </div>
        <div className={styles.plant_name_container}>
            <p>John</p>
        </div>
    </div>
  </div>
}

export default LightingHistory;