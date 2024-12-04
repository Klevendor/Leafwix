import styles from "./FeedingHistory.module.css";

import { useEffect, useState } from "react";
import useAxiosPrivate from "../../../../hooks/useAxiosPrivate";
import { PlantService } from "../../../../services/PlantService";
import { useAuth } from "../../../../hooks/useAuth";

const FeedingHistory = () => {
    const {auth} = useAuth()

    const axiosPrivate = useAxiosPrivate()

    const [histories, setHistories] = useState([])

    useEffect(()=>{
        handleGetHistories("Feeding")
    },[])

    const handleGetHistories = async (type) => {
        const result = await PlantService.getHistoryByType(axiosPrivate, {careType: type, userId: auth.id})
        if(!result.isError)
        {
            setHistories(result.dataOrError)
        }
    }

    useEffect(()=>{
        console.log(histories)
    },[histories])

    return<div className={styles.container}>
      {histories.map((history, index) => {
            const date = new Date(history.actionDate);

            return <div key={index} className={styles.history_card}>
            <div className={styles.datetime_container}>
               {`${date.getFullYear()}-${(date.getMonth() + 1).toString().padStart(2, '0')}-${date.getDate().toString().padStart(2, '0')} ${date.getHours().toString().padStart(2, '0')}:${date.getMinutes().toString().padStart(2, '0')}:${date.getSeconds().toString().padStart(2, '0')}`}
            </div>
            <div className={styles.plant_name_container}>
                <p>{history.plantName}</p>
            </div>
        </div>
        })}
  </div>
}

export default FeedingHistory;