import { Routes, Route } from 'react-router-dom'
import Navbar from "../layouts/Navbar";
import UserPlants from './UserPlants';

import styles from "./pages_styles/Home.module.css";
import Recognition from './Recognition';

const Home = () => {
  return (
    <>
      <main className={styles.container}>
      <Navbar />
      <Routes>
          <Route path="/myplants" element={<UserPlants />} />
          <Route path="/recognize" element={<Recognition />} />
      </Routes>
      </main>
    </>);
}

export default Home;