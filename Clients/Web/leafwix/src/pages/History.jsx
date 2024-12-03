import DummmySidebar from "../components/DummySidebar";
import { Routes, Route, useNavigate, useLocation } from 'react-router-dom'
import {Title} from "../features/history/index"
import {WaterHistory, LightingHistory, FeedingHistory} from "../features/history/index"

import styles from "./pages_styles/History.module.css";
import Spacer from "../components/Spacer";

const History = () => {
    const navigate = useNavigate()
    const location = useLocation()

    return<div className={styles.container}>
        <DummmySidebar/>
        <div className={styles.content}>
            <Title/>
            <div className={styles.histories_container}>
                <button onClick={() => navigate("/home/history/water")} className={`${styles.history_option} ${styles.water_option} ${location.pathname.includes("/history/water") ? styles.water_active : ""}`}>Water</button>
                <button onClick={() => navigate("/home/history/feeding")} className={`${styles.history_option} ${styles.feeding_option} ${location.pathname.includes("/history/feeding") ? styles.feeding_active : ""}`}>Feeding</button>
                <button onClick={() => navigate("/home/history/lighting")} className={`${styles.history_option} ${styles.lighting_option} ${location.pathname.includes("/history/lighting") ? styles.lighting_active : ""}`}>Lighting</button>
            </div>
            <Routes>
                <Route path="/water" element={<WaterHistory />} />
                <Route path="/feeding" element={<FeedingHistory />} />
                <Route path="/lighting" element={<LightingHistory />} />
            </Routes>
            <Spacer/>
        </div>
  </div>
}

export default History;