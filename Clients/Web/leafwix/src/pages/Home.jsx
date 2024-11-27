import { Routes, Route } from 'react-router-dom'
// import Navbar from "../layouts/Navbar";

import styles from "./pages_styles/Home.module.css";


const Home = () => {
  return (
    <>
      <main className={styles.container}>
        <h1>Home</h1>
        <Routes>
            {/* <Route path="/editor/ch/:chapterId" element={<ChapterEditor />} /> */}
        </Routes>
        {/* <Navbar /> */}
      </main>
    </>);
}

export default Home;