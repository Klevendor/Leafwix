import { useRef, useState, useEffect } from 'react';
import { useNavigate} from 'react-router-dom'
import { Splide, SplideSlide } from '@splidejs/react-splide';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import '@splidejs/react-splide/css/sea-green';
import styles from "./MyPlantsPanel.module.css";

import Plant from './Plant';
import { PlantService } from '../../../../services/PlantService';
import { useAuth } from "../../../../hooks/useAuth"
import useAxiosPrivate from "../../../../hooks/useAxiosPrivate"

const CustomWaterIcon = () => (
    <span role="img" aria-label="custom-icon" style={{ fontSize: "24px" }}>
        <i className={`fa-solid fa-location-pin ${styles.drop}`}></i>
    </span>
  );

const CustomFeedingIcon = () => (
    <span role="img" aria-label="custom-icon" style={{ fontSize: "24px" }}>
        <i className={`fa-solid fa-wand-magic-sparkles ${styles.magic}`}></i>
    </span>
  );

const CustomSunnyIcon = () => (
    <span role="img" aria-label="custom-icon" style={{ fontSize: "24px" }}>
          <i className={`fa-solid fa-sun ${styles.sun}`}></i>
    </span>
  );

const CustomHeartIcon = () => (
    <span role="img" aria-label="custom-icon" style={{ fontSize: "24px" }}>
          <i className={`fa-solid fa-heart  ${styles.heart}`}></i>
    </span>
  );

const MyPlantsPanel = ({setActivePlant}) => {
    const {auth} = useAuth()
    const axiosPrivate = useAxiosPrivate()
    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false)
    const splideRef = useRef(null);
    const [activeIndex, setActiveIndex] = useState(0);
    const [name,setName] = useState()
    const [plants,setPlants] = useState([])

    useEffect(() => {
        if (splideRef.current) {
            const splide = splideRef.current.splide;

            setActiveIndex(splide.index);

            splide.on('move', () => {
                setActiveIndex(splide.index);
            });
        }
    }, []);

    useEffect(() => {
        if(plants.length != 0 && activeIndex < plants.length)
        {
            setName(plants[activeIndex].name)
            setActivePlant(plants[activeIndex])
        }
        else
        {
            setName("")
        }
    }, [activeIndex]);

    useEffect(()=>{
        handleGetUserPlants()
    },[])

    const handleGetUserPlants = async () => {
        const result = await PlantService.getAllPlantsByUser(axiosPrivate, {userid: auth.id})
            if(!result.isError) {
                setPlants(result.dataOrError)
                if(result.dataOrError.length != 0)
                    setActivePlant(result.dataOrError[0])
                    setName(result.dataOrError[0].name)
            } 
    }

    const handleWater = () => {
        toast("You watered the plant. YOUR history was updated. HEALTH +10", {
            icon: <CustomWaterIcon />,
            style: {
                backgroundColor: "#0a80ff",
                color: "#fff",
                fontWeight: "bold", 
              }
          });
    }

    const handleFeeding = () => {
        toast("You feeded the plant. YOUR history was updated. HEALTH +5", {
            icon: <CustomFeedingIcon />,
            style: {
                backgroundColor: "#1bce00",
                color: "#fff",
                fontWeight: "bold", 
              }
          });
    }
    
    const handleSunny = () => {
        toast("You have changed the lighting for the plant. YOUR history has been updated. HEALTH +5", {
            icon: <CustomSunnyIcon />,
            style: {
                backgroundColor: "#efef00",
                color: "#fff",
                fontWeight: "bold", 
              }
          });
    }

    const handleHeal = () => {
        toast("You have healed a plant. \nYOUR history has been updated. HEALTH: 100", {
            icon: <CustomHeartIcon />,
            style: {
                backgroundColor: "#f50010e5",
                color: "#fff",
                fontWeight: "bold", 
              }
          });
    }

    return <div className={styles.container}>
        <div className={styles.option_container1}>
            <div className={styles.action_buttons_container1}>
                <button onClick={handleWater} className={styles.watter_button}>
                    <i className={`fa-solid fa-location-pin ${styles.drop}`}></i>
                </button>
                <button onClick={handleFeeding} className={styles.feeding_button}>
                    <i className={`fa-solid fa-wand-magic-sparkles ${styles.magic}`}></i>
                </button>
            </div>
        </div>
        <div className={styles.visual_container}>
            <div className={styles.plant_title}>
                <h1 className={styles.title}>{name}</h1>
            </div>
            <div className={styles.plants_container}>
                <Splide ref={splideRef} aria-label="My Favorite Images">
                    {
                        plants.map((plant,index) => {
                            return  <SplideSlide key={index}>
                            <Plant path={plant.imgPath}/>
                        </SplideSlide>
                        })
                    }
                    <SplideSlide>
                        <div className={styles.button_add_container}>
                             <button onClick={() =>  navigate("/home/recognize")} className={styles.add_new_plant}>Add new</button>
                        </div>
                    </SplideSlide>
                </Splide>
            </div>
        </div>
        <div className={styles.option_container2}>
            <div className={styles.action_buttons_container2}>
                <button onClick={handleSunny} className={styles.sunny_button}>
                    <i className={`fa-solid fa-sun ${styles.sun}`}></i>
                </button>
                <button onClick={handleHeal} className={styles.heal_button}>
                    <i className={`fa-solid fa-heart  ${styles.heart}`}></i>
                </button>
            </div>
        </div>
        <div className={styles.mobile_options_container}>
            <button onClick={handleWater} className={styles.watter_button}>
                <i className={`fa-solid fa-location-pin ${styles.drop}`}></i>
            </button>
            <button onClick={handleFeeding} className={styles.feeding_button}>
                <i className={`fa-solid fa-wand-magic-sparkles ${styles.magic}`}></i>
            </button>
            <button onClick={handleSunny} className={styles.sunny_button}>
                <i className={`fa-solid fa-sun ${styles.sun}`}></i>
            </button>
            <button  onClick={handleHeal} className={styles.heal_button}>
                <i className={`fa-solid fa-heart  ${styles.heart}`}></i>
            </button>
        </div>
        <ToastContainer
            position="top-center"
            closeOnClick
            autoClose={2000}
            hideProgressBar={true}
            draggable
        />
    </div>
}

export default MyPlantsPanel;