import { useNavigate } from "react-router";
import { useState, useEffect } from "react";
import useRecognitionStore from "../../../../context/useRecognitionStore";
import { ToastContainer, toast } from 'react-toastify';
import image from "/image.png"

import styles from "./CheckPlant.module.css";

const CheckPlant = () => {
    const navigate = useNavigate()
    const [age, setAge] = useState("")

    const {fileSelected, predictedLabel, accuracy, setPlantAge} = useRecognitionStore();
    const [imageUrl, setImageUrl] = useState(null); 
    
    useEffect(() => {
        if (fileSelected) {
          const objectUrl = URL.createObjectURL(fileSelected);
          setImageUrl(objectUrl);
    
          return () => URL.revokeObjectURL(objectUrl);
        } else {
          setImageUrl(null);
        }
      }, [fileSelected]);

    const handleNext = async () => {
      let num = parseInt(age);
      if (isNaN(num)) {
        toast.error('The input AGE is not a valid number!', {
          position: "top-center",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          theme: "light"
          });
          return
      } 
      setPlantAge(num)
      navigate("/home/newplant")
    }


    return <div className={styles.container}>
    <div className={styles.cover_container}>
        <img className={styles.image_preview} src={imageUrl || image}/>
    </div>
    <div className={styles.action_container}>
        <div className={styles.recogniton_result_container}>
            <p className={styles.result_text}>Recognized plant:<span className={styles.result}>{`${predictedLabel} ${accuracy * 100}%`}</span></p>
        </div>
        <div className={styles.age_container}>
            <p className={styles.age_text}>Age:</p>
            <input value={age} onChange={(e) => setAge(e.target.value)} className={styles.age_input} type="text" placeholder="Enter..."/>
        </div>
        <button onClick={handleNext} className={styles.next_button}>Next</button>
        <p onClick={() => navigate("/home/changeplant")} className={styles.change}>Change</p>
    </div>
    <ToastContainer/>
  </div>
}

export default CheckPlant;