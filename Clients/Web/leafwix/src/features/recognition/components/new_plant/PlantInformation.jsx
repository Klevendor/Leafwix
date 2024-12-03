import { useNavigate } from "react-router";
import Spacer from "../../../../components/Spacer"
import styles from "./PlantInformation.module.css";

const PlantInformation = () => {
  const navigate = useNavigate()

  return (
    <>
     <div className={styles.plant_information_container}>
      <div className={styles.description_container}>
        <p className={styles.sub_title}>Description:</p>
        <p className={styles.description}>Ficus benjamina is a popular houseplant that belongs to the mulberry family (Moraceae). It is known for its dense crown with small glossy leaves and graceful curved branches. In nature, this plant can reach a height of up to 30 meters, but at home, its size is usually limited to 1-2 meters.
        </p>
      </div>
      <button onClick={() => navigate("/home/myplants")} className={styles.next_button}>Save</button>
      <div className={styles.spacer}></div>
    </div>
    </>);
}

export default PlantInformation;
