import { Routes, Route } from 'react-router-dom'
import DummmySidebar from "../components/DummySidebar";
import {PlantRecommendation, MyPlantsPanel} from '../features/plant_care/index';
import Spacer from '../components/Spacer';

import styles from "./pages_styles/UserPlants.module.css";

const UserPlants = () => {
  return (
    <div className={styles.my_plants_container}>
    <DummmySidebar />
    <div className={styles.content}>
        <MyPlantsPanel/>
        <PlantRecommendation/>
    </div>
  </div>);
}

export default UserPlants;
