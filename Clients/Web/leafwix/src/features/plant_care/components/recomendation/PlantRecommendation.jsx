import Spacer from "../../../../components/Spacer";
import styles from "./PlantRecommendation.module.css";

const PlantRecommendation = () => {
    return<div className={styles.container}>
        <div className={styles.recommendation_container}>
            <div className={styles.title_recommendation}>
                <p className={styles.title}>Recommendation</p>
            </div>
           <div className={styles.care_container}>
                    <p className={styles.sub_title}>Care:</p>
                    <ul className={styles.care}>
                        <li><strong>Lighting:</strong> Loves bright diffused light, but not direct sunlight.</li>
                        <li><strong>Watering:</strong> Regular, moderate watering is required; water should not be allowed to stagnate in the soil.</li>
                        <li><strong>Temperature:</strong> The ideal temperature is 18-25°C.</li>
                        <li><strong>Humidity:</strong> Needs high humidity, so spraying the leaves is recommended.</li>
                    </ul>
           </div>
           <div className={styles.description_container}>
                <p className={styles.sub_title}>Description:</p>
                <p className={styles.description}>Ficus benjamina is a popular houseplant that belongs to the mulberry family (Moraceae). It is known for its dense crown with small glossy leaves and graceful curved branches. In nature, this plant can reach a height of up to 30 meters, but at home, its size is usually limited to 1-2 meters.
                </p>
                
            </div>
           <div className={styles.interesting_facts_container}>
                <p className={styles.sub_title}>Interesting facts:</p>
                <ul className={styles.interesting_facts}>
                    <li>Ficus purifies the air by removing toxins such as formaldehyde and benzene.</li>
                    <li>This plant symbolizes harmony and tranquility in many cultures.</li>
                </ul>
            </div>
        </div>
        <Spacer/>
  </div>
}

export default PlantRecommendation;