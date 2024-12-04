import { useEffect, useState } from "react";
import Spacer from "../../../../components/Spacer";
import { PlantService } from "../../../../services/PlantService";

import styles from "./PlantRecommendation.module.css";
import useAxiosPrivate from "../../../../hooks/useAxiosPrivate";

const PlantRecommendation = ({ activePlant }) => {
    const axiosPrivate = useAxiosPrivate()

    const [isLoading, setIsLoading] = useState(false)

    const [plantspecies, setPlantSpecies] = useState([])
    const [info, setInfo] = useState(null)

    useEffect(()=>{
        handleGetSpecies()
    },[])

    useEffect(() => {
        if (activePlant == null)
            setIsLoading(true)
        else
        {
            let result = plantspecies.find(info => info.name == activePlant.type)
            setInfo(result)
            setIsLoading(false)
        }

    }, [activePlant])

    const handleGetSpecies = async () =>{
        const result = await PlantService.getAllSpecies(axiosPrivate)
        if(!result.isError)
        {
          setPlantSpecies(result.dataOrError)
        }
      }

    return <div className={styles.container}>
        <div className={styles.recommendation_container}>
            <div className={styles.title_recommendation}>
                <p className={styles.title}>Recommendation</p>
            </div>
            {isLoading
                ? <div className={styles.loader_container}>
                    <div className={styles.loader}></div>
                </div>
                :
                <>
                    <div className={styles.care_container}>
                        <p className={styles.sub_title}>Care:</p>
                        <ul className={styles.care}>
                            <li><strong>Lighting:</strong>{info?.lighting}</li>
                            <li><strong>Watering:</strong>{info?.watering}</li>
                            <li><strong>Temperature:</strong>{info?.temperature}</li>
                            <li><strong>Humidity:</strong>{info?.humidity}</li>
                        </ul>
                    </div>
                    <div className={styles.description_container}>
                        <p className={styles.sub_title}>Description:</p>
                        <p className={styles.description}>{info?.description}
                        </p>

                    </div>
                </>}
        </div>
        <div className={styles.spacer}></div>
    </div>
}

export default PlantRecommendation;