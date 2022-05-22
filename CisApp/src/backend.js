import axios from 'axios'
import { getAuthToken } from './libs/auth'

const axiosCls = axios.create({
    baseURL: 'https://localhost:44386/api',
    headers: {
        "Content-type": "application/json"
    }
});

export function getBackend() {
    const token = getAuthToken();
    axiosCls.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    return axiosCls;
}

export default axiosCls;