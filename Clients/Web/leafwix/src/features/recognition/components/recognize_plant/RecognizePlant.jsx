import { useState, useEffect } from "react";
import image from "/image.png"
import { useNavigate } from "react-router";
import { RecognitionService } from "../../../../services/RecognitionService";
import { ToastContainer, toast } from 'react-toastify';
import useRecognitionStore from "../../../../context/useRecognitionStore"

import 'react-toastify/dist/ReactToastify.css';
import styles from "./RecognizePlant.module.css";

const RecognizePlant = () => {
    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)

    const {fileSelected, setFileSelected, setRecognitionResult} = useRecognitionStore();
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

    const handleRecognize = async () => {
      if (fileSelected == null)
      {
          toast.error('Upload your image!', {
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
      
        setIsLoading(true)
        const result = await RecognitionService.recognizePlant({
            image: fileSelected
        })
        if (!result.isError) {
          setRecognitionResult(result.dataOrError.predicted_class, result.dataOrError.prediction_confidence)
          navigate("/home/checkplant")
        }
        setIsLoading(false)
    }


    return <div className={styles.container}>
    <h1>Recognize your plant</h1>
    <div className={styles.cover_container}>
        <img className={styles.image_preview} src={imageUrl || image}/>
    </div>
    <div className={styles.upload_button_container}>
        <label htmlFor="plant_select" className={styles.upload_button}>
            <input id="plant_select" className={styles.upload_image} type="file" accept=".jpg, .png" onChange={(e) => setFileSelected(e.target.files[0])} hidden />
            Choose plant image
        </label>
    </div>
    <div className={styles.action_container}>
        <button onClick={handleRecognize} className={styles.recognize_button}>Recognize</button>
    </div>
    <ToastContainer/>
  </div>
}

export default RecognizePlant;