import axios from 'axios'

export default axios.create({
    baseURL: 'https://localhost:44386/api',
    headers: {
        "Content-type": "application/json",
        "Authorization": 'Bearer ' + sessionStorage.getItem('token')
    }
});