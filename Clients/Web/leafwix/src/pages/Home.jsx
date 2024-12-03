import { Routes, Route } from 'react-router-dom'
import Navbar from "../layouts/Navbar";
import UserPlants from './UserPlants';
import Recognition from './Recognition';
import CheckRecognizedPlant from './CheckRecognizedPlant';
import ChangeRecognizedPlant from './ChangeRecognizedPlant';
import NewPlant from './NewPlant';
import History from './History';

import styles from "./pages_styles/Home.module.css";


const Home = () => {
  return (
    <>
      <main className={styles.container}>
      <Navbar />
      <Routes>
          <Route path="/myplants" element={<UserPlants />} />
          <Route path="/recognize" element={<Recognition />} />
          <Route path="/checkplant" element={<CheckRecognizedPlant />} />
          <Route path="/changeplant" element={<ChangeRecognizedPlant />} />
          <Route path="/newplant" element={<NewPlant />} />
          <Route path="/history/*" element={<History />} />
      </Routes>
      </main>
    </>);
}

export default Home;