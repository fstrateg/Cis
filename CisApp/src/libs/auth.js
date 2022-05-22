import backend from '../backend'

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
}

export function getAuthToken() {
    return localStorage.getItem(AUTH_TOKEN_KEY)
}

export function clearAuthToken() {
    //backend.defaults.headers.common['Authorization'] = ''
    localStorage.removeItem(AUTH_TOKEN_KEY)
}

export function isLoggedIn() {
    let authToken = getAuthToken()
    return !!authToken
}
