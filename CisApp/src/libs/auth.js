import backend from '../backend'
import decode from 'jwt-decode'

const AUTH_TOKEN_KEY = 'authToken'

export async function loginUser(username, password) {
    //try {
    await backend.post('loginnet', { Username: username, Password: password })
        .then((res) => {
            setAuthToken(res.data.token);
        });

        //} catch (err) {
        //    console.error('Caught an error during login:', err)
        //}
   
}

export function logoutUser() {
    clearAuthToken()
}

export function setAuthToken(token) {
    localStorage.setItem(AUTH_TOKEN_KEY, token)
    console.log(getTokenExpirationDate(token))
}

export function getAuthToken() {
    return localStorage.getItem(AUTH_TOKEN_KEY)
}

export function clearAuthToken() {
    //backend.defaults.headers.common['Authorization'] = ''
    localStorage.removeItem(AUTH_TOKEN_KEY)
}

function getTokenExpirationDate(encodedToken) {
    let token = decode(encodedToken)
    if (!token.exp) {
        return null
    }

    let date = new Date(0)
    date.setUTCSeconds(token.exp)

    return date
}

export function isLoggedIn() {
    let authToken = getAuthToken()
    return !!authToken && !isTokenExpired(authToken)
}

function isTokenExpired(token) {
    let expirationDate = getTokenExpirationDate(token)
    return expirationDate < new Date()
}