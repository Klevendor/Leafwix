import { useNavigate } from "react-router";
import Spacer from "../../../../components/Spacer"
import styles from "./PlantInformation.module.css";
import useRecognitionStore from "../../../../context/useRecognitionStore";
import { useState, useEffect } from "react";
import useAxiosPrivate from "../../../../hooks/useAxiosPrivate";
import { PlantService } from "../../../../services/PlantService";
import { useAuth } from "../../../../hooks/useAuth";
import { ToastContainer, toast } from 'react-toastify';

const PlantInformation = ({name}) => {
  const {auth} = useAuth()
  const axiosPrivate = useAxiosPrivate()
  const navigate = useNavigate()
 
  const [isLoading,setIsLoading] = useState(false)

  const {predictedLabel,plant_age} = useRecognitionStore()
  const [description, setDescription] = useState("")
  const [plantspecies, setPlantSpecies] = useState([])
  const [plant, setPlant] = useState(null)

  useEffect(()=>{
    handleGetSpecies()
  },[])

  useEffect(()=>{
    console.log(plantspecies)
    if(plantspecies.length != 0)
    {
      const plant = plantspecies.find(obj => obj.name === predictedLabel);
      setPlant(plant)
      setDescription(plant.description)
    }
  },[plantspecies])

  const handleGetSpecies = async () =>{
    const result = await PlantService.getAllSpecies(axiosPrivate)
    if(!result.isError)
    {
      setPlantSpecies(result.dataOrError)
    }
  }

  const handleAddPlant = async () =>{
    if(name == "")
    {
      toast.error('Plant name cannot be empty!', {
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
    const result = await PlantService.addPlant(axiosPrivate, { name: name,
      age: plant_age,
      plantSpeciesId: plant.id,
      userId: auth.id})
    
    if(!result.isError)
    {
      navigate("/home/myplants")
    }
    setIsLoading(false)
  }


  return (
    <>
     <div className={styles.plant_information_container}>
      <div className={styles.description_container}>
        <p className={styles.sub_title}>Description:</p>
        <p className={styles.description}>{description}
        </p>
      </div>
      {isLoading
      ? <div className={styles.loader}></div>
      :<button onClick={handleAddPlant} className={styles.next_button}>Save</button>}
      <div className={styles.spacer}></div>
    </div>
    <ToastContainer/>
    </>);
}

export default PlantInformation;
