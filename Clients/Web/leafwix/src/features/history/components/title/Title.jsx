import styles from "./Title.module.css";

const Title = () => {
    return <div className={styles.title_container}>
    <h1 className={styles.title}>Your action history</h1>
  </div>
}

export default Title;