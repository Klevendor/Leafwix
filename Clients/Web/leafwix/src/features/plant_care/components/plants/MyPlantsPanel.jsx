import { useRef, useState, useEffect } from 'react';
import { useNavigate} from 'react-router-dom'
import { Splide, SplideSlide } from '@splidejs/react-splide';
import '@splidejs/react-splide/css/sea-green';
import styles from "./MyPlantsPanel.module.css";

import Plant from './Plant';

const MyPlantsPanel = () => {
    const navigate = useNavigate();

    const splideRef = useRef(null);
    const [activeIndex, setActiveIndex] = useState(0);

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
        console.log(activeIndex)
    }, [activeIndex]);

    

    return <div className={styles.container}>
        <div className={styles.option_container1}>
            <div className={styles.action_buttons_container1}>
                <button className={styles.watter_button}>
                    <i className={`fa-solid fa-location-pin ${styles.drop}`}></i>
                </button>
                <button className={styles.feeding_button}>
                    <i className={`fa-solid fa-wand-magic-sparkles`}></i>
                </button>
            </div>
        </div>
        <div className={styles.visual_container}>
            <div className={styles.plant_title}>
                <h1 className={styles.title}>{activeIndex}</h1>
            </div>
            <div className={styles.plants_container}>
                <Splide ref={splideRef} aria-label="My Favorite Images">
                    <SplideSlide>
                        <Plant />
                    </SplideSlide>
                    <SplideSlide>
                        <Plant />
                    </SplideSlide>
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
                <button className={styles.sunny_button}>
                    <i className={`fa-solid fa-sun ${styles.sun}`}></i>
                </button>
                <button className={styles.heal_button}>
                    <i className={`fa-solid fa-heart`}></i>
                </button>
            </div>
        </div>
        <div className={styles.mobile_options_container}>
            <button className={styles.watter_button}>
                <i className={`fa-solid fa-location-pin ${styles.drop}`}></i>
            </button>
            <button className={styles.feeding_button}>
                <i className={`fa-solid fa-wand-magic-sparkles`}></i>
            </button>
            <button className={styles.sunny_button}>
                <i className={`fa-solid fa-sun ${styles.sun}`}></i>
            </button>
            <button className={styles.heal_button}>
                <i className={`fa-solid fa-heart`}></i>
            </button>
        </div>
    </div>
}

export default MyPlantsPanel;