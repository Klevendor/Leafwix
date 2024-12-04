import { Routes, Route } from 'react-router-dom'
import DummmySidebar from "../components/DummySidebar";
import {PlantRecommendation, MyPlantsPanel} from '../features/plant_care/index';
import Spacer from '../components/Spacer';

import styles from "./pages_styles/UserPlants.module.css";
import { useState } from 'react';

const UserPlants = () => {
  const [activePlant, setActivePlant] = useState(null)

  return (
    <div className={styles.my_plants_container}>
    <div className={styles.content}>
        <MyPlantsPanel setActivePlant={setActivePlant}/>
        <PlantRecommendation activePlant={activePlant}/>
    </div>
  </div>);
}

export default UserPlants;
