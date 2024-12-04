import { USE_PLATFORM, Platforms } from "../data/constants"
import { externalAxios } from "../lib/Axios"

// axiosPrivate use baseAxios!!
export const PlantService = {
    errorMessages : {
        400: "Validation error",
        409: "Conflict error",
        500: "Internal server error"
    },

    async getAllSpecies(axiosPrivate) {
        if (USE_PLATFORM == Platforms.Web) {
            try {
                const response = await axiosPrivate.get("api/PlantSpecies/getAll")
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`PlantService (getAllSpecies) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async getAllPlantsByUser(axiosPrivate,requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try {
                const response = await axiosPrivate.get(`api/Plant/getAll/${requestData.userid}`)
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`PlantService (getAllSpecies) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async addPlant(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/Plant/add-plant", {
                    name: requestData.name,
                    age: requestData.age,
                    plantSpeciesId: requestData.plantSpeciesId,
                    userId: requestData.userId
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`PlantService (addPlant) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async addHistory(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/PlantCareHistory/add", {
                    careType: requestData.careType,
                    plantId: requestData.plantId,
                    userId: requestData.userId,
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`PlantService (addHistory) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async getHistoryByType(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/PlantCareHistory/gethistory", {
                    careType: requestData.careType,
                    userId: requestData.userId
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`PlantService (getHistoryByType) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    getPlantView(age,type) {
        let size = ""
        if(age <= 3)
        {
            size = "small"
        } else if (age >= 3 && age < 5) {
            size = "medium"
        } else {
            size = "big"
        }
        
        let species = ""
        if(type == "African Violet (Saintpaulia ionantha)")
        {
            species = "african_violet"
        } 
        else if (type == "Cast Iron Plant (Aspidistra elatior)") 
        {
            species = "aspidistra_elatior"
        }
        else if (type == "Aloe Vera") 
        {
            species = "aloe_vera"
        }
        else if (type == "Dracaena") 
        {
            species = "dracaena_fragrans"
        }
        else  {
            species = "default_plant"
        }
        
        return `${size}_${species}.svg`
    }
}
