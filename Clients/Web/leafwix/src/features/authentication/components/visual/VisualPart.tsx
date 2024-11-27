import styles from "./VisualPart.module.css"

const VisualPart = ({ figureStyle, side, isHeader }) => {
  return (
    <>
      {isHeader ? (
        <div className={styles.logo_header_container}>
                   <div className={styles.logo_top}>
            <h1 className={styles.logo_first_part}>Leaf</h1>
            <h1 className={styles.logo_second_part}>Wix</h1>
       </div>
        </div>
      ) : (
        <div className={styles.visual_container}>
          {side === "left" ? (
            <div className={styles.logo_left}>
              <h1 className={styles.logo_first_part}>Leaf</h1>
              <h1 className={styles.logo_second_part}>Wix</h1>
            </div>
          ) : (
            <div className={styles.logo_right}>
              <h1 className={styles.logo_first_part}>Leaf</h1>
              <h1 className={styles.logo_second_part}>Wix</h1>
            </div>
          )}
          <div className={styles.background}></div>
          {side === "left" ? (
            <div className={styles.glass_effect_left}></div>
          ) : (
            <div className={styles.glass_effect_right}></div>
          )}
        </div>
      )}
    </>
  )
}

export default VisualPart