import axios from "axios"
import { BASE_API_URL,BASE_EXTERNAL_API_URL } from "../data/constants" 

export const baseAxios = axios.create({
    baseURL: BASE_API_URL,
    withCredentials: true
})

export const externalAxios = axios.create({
    baseURL: BASE_EXTERNAL_API_URL,
    withCredentials: true
})