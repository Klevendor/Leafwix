import { USE_PLATFORM, Platforms } from "../data/constants"
import { externalAxios } from "../lib/Axios"

// axiosPrivate use baseAxios!!
export const RecognitionService = {
    errorMessages : {
        400: "Validation error",
        409: "Conflict error",
        500: "Internal server error"
    },

    async recognizePlant(requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try {
                const formData = new FormData();
                formData.append("image", requestData.image);
                const response = await externalAxios.put("/plant-recognize", formData)
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`RecognitionService (recognizePlant) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    getPlantView(age,type) {
        var size = ""
        if(age < 3)
        {
            size = "small"
        } else if (age > 3 || age < 6) {
            size = "medium"
        } else {
            size = "big"
        }
    }
}
