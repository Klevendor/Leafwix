import { useNavigate } from "react-router";
import { useState, useEffect } from "react";
import image from "/image.png"

import styles from "./CheckPlant.module.css";

const CheckPlant = () => {
    const navigate = useNavigate()

    const [fileSelected, setFileSelected] = useState(null);
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
        // setIsLoading(true)
        // const result = await BookService.changeBookCover(axiosPrivate, {
        //     bookId: book.id,
        //     image: fileSelected
        // })
        // if (!result.isError) {
        //     setImagePath(result.dataOrError)
        // }
        // setKey(prev => prev + 1)
        // setIsLoading(false)
        navigate("/home/newplant")
    }


    return <div className={styles.container}>
    <div className={styles.cover_container}>
        <img className={styles.image_preview} src={imageUrl || image}/>
    </div>
    <div className={styles.action_container}>
        <div className={styles.recogniton_result_container}>
            <p className={styles.result_text}>Recognized plant:<span className={styles.result}>Flower 100%</span></p>
        </div>
        <div className={styles.age_container}>
            <p className={styles.age_text}>Age:</p>
            <input className={styles.age_input} type="text" placeholder="Enter..."/>
        </div>
        <button onClick={handleRecognize} className={styles.next_button}>Next</button>
        <p onClick={() => navigate("/home/changeplant")} className={styles.change}>Change</p>
    </div>
  </div>
}

export default CheckPlant;