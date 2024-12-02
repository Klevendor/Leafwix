import { useState } from "react";
import styles from "./RecognizePlant.module.css";
import { useEffect } from "react";
import image from "/image.png"

const RecognizePlant = () => {
    const [fileSelected, setFileSelected] = useState(null);
    const [imageUrl, setImageUrl] = useState(null); // To hold the image object URL
    
    useEffect(() => {
        if (fileSelected) {
          const objectUrl = URL.createObjectURL(fileSelected);
          setImageUrl(objectUrl);
    
          // Clean up the object URL when the component is unmounted or the file changes
          return () => URL.revokeObjectURL(objectUrl);
        } else {
          setImageUrl(null); // Reset imageUrl if no file is selected
        }
      }, [fileSelected]);

    const handleUpdateCover = async () => {
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
    }


    return <div className={styles.container}>
    <h1>Recognize your plant</h1>
    <div className={styles.cover_container}>
        <img className={styles.image_preview}   src={imageUrl || image}/>
    </div>
    <div className={styles.upload_button_container}>
        <label htmlFor="plant_select" className={styles.upload_button}>
            <input id="plant_select" className={styles.upload_image} type="file" accept=".jpg, .png" onChange={(e) => setFileSelected(e.target.files[0])} hidden />
            Choose plant image
        </label>
    </div>
    <div className={styles.action_container}>
        <button className={styles.recognize_button}>Recognize</button>
    </div>
  </div>
}

export default RecognizePlant;