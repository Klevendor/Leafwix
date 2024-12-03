import { useNavigate } from "react-router";
import { useState, useEffect } from "react";
import Select from 'react-select';
import useRecognitionStore from "../../../../context/useRecognitionStore";
import { ToastContainer, toast } from 'react-toastify';
import image from "/image.png"

import styles from "./ChangePlant.module.css";

const customStyles = {
    control: (provided) => ({
      ...provided,
      backgroundColor: '#fff', // Control background color
      borderColor: '#4caf50', // Border color when not focused
      '&:hover': {
        borderColor: '#388e3c', // Border color on hover
      },
      padding: '5px', // Padding around the select control
      fontSize: "20px" 
    }),
    option: (provided, state) => ({
      ...provided,
      backgroundColor: state.isSelected ? '#4caf50' : state.isFocused ? '#e0f7fa' : null, // Background color for option
      color: state.isSelected ? 'white' : 'black', // Text color for option
      '&:hover': {
        backgroundColor: '#80e27e', // Background color on hover
      },
    }),
    menu: (provided) => ({
      ...provided,
      backgroundColor: '#f0f8ff', // Dropdown menu background color
    }),
    singleValue: (provided) => ({
      ...provided,
      color: '#388e3c', // Color for the selected value
    }),
    indicatorSeparator: (provided) => ({
      ...provided,
      backgroundColor: '#388e3c', // Separator color
    }),
  };

const ChangePlant = () => {
    const plantSpecies = [
        { label: 'African Violet (Saintpaulia ionantha)', value: 'African Violet (Saintpaulia ionantha)' },
        { label: 'Aloe Vera', value: 'Aloe Vera' },
        { label: 'Cast Iron Plant (Aspidistra elatior)', value: 'Cast Iron Plant (Aspidistra elatior)' },
        { label: 'Chinese evergreen (Aglaonema)', value: 'Chinese evergreen (Aglaonema)' },
        { label: 'Ctenanthe', value: 'Ctenanthe' },
        { label: 'Dracaena', value: 'Dracaena' },
        { label: 'Kalanchoe', value: 'Kalanchoe' },
        { label: 'Lilium (Hemerocallis)', value: 'Lilium (Hemerocallis)' },
        { label: 'Pothos (Ivy arum)', value: 'Pothos (Ivy arum)' },
        { label: 'Rubber Plant (Ficus elastica)', value: 'Rubber Plant (Ficus elastica)' },
        { label: 'Another', value: 'Another' }
      ];
    
    const navigate = useNavigate()
    const [age, setAge] = useState("")
    const [selectedOption, setSelectedOption] = useState("");

    const {fileSelected, setPlantAge, setNewPredictedLabel} = useRecognitionStore();
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
        if (isNaN(num) || selectedOption == "") {
          toast.error('The input AGE or SELECTED SPACIES are not a valid number or empty!', {
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

      const handleChange = (selectedOption) => {
        setSelectedOption(selectedOption);
        setNewPredictedLabel(selectedOption)
      };

    return <div className={styles.container}>
    <div className={styles.cover_container}>
        <img className={styles.image_preview} src={imageUrl || image}/>
    </div>
    <div className={styles.action_container}>
        <div className={styles.recogniton_result_container}>
            <p className={styles.result_text}>Select a plant species:</p>
            <Select
            placeholder="Select"
            styles={customStyles}
            options={plantSpecies}
            onChange={handleChange} 
            value={selectedOption}
            />
        </div>
        <div className={styles.age_container}>
            <p className={styles.age_text}>Age:</p>
            <input value={age} onChange={(e) => setAge(e.target.value)} className={styles.age_input} type="text" placeholder="Enter..."/>
        </div>
        <button onClick={handleNext} className={styles.next_button}>Next</button>
        <p onClick={() => navigate("/home/recognize")} className={styles.change}>Recognize again</p>
    </div>
    <ToastContainer/>
  </div>
}

export default ChangePlant;