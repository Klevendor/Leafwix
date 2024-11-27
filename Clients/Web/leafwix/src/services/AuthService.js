import { USE_PLATFORM, Platforms } from "../data/constants"
import { baseAxios } from "../lib/Axios"

// axiosPrivate use baseAxios!!
export const AuthService = {
    errorMessages : {
        400: "Validation error",
        409: "Conflict error",
        500: "Internal server error"
    },

    async login(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/auth/login", {
                    email: requestData.email,
                    password: requestData.password
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (login) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async register(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/auth/register", {
                    username: requestData.username,
                    email: requestData.email,
                    password: requestData.password
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (register) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async forgotPassword(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/auth/forgot-password", {
                    email: requestData.email
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (forgotPassword) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            } 
        }
    },

    async resetPassword(axiosPrivate, requestData) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.post("api/auth/reset-password", {
                    newPassword: requestData.newPassword,
                    token: requestData.token,
                    email: requestData.email
                })
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (resetPassword) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async refreshToken() {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await baseAxios.get("api/auth/refresh-tokens")
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (refreshToken) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    },

    async logout(axiosPrivate) {
        if (USE_PLATFORM == Platforms.Web) {
            try{
                const response = await axiosPrivate.get("api/auth/logout")
                return {
                    isError: false,
                    status: response.status,
                    dataOrError: response.data
                };
            } catch (err) {
                console.log(`AuthService (logout) -> Error ${err.response.status}: ${this.errorMessages[err.response.status] || "Unknown error"}`);
                return {
                    isError: true,
                    status: err.response.status,
                    dataOrError: err.response.data.title
                };
            }
        }
    }
}
