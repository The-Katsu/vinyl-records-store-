import axios from "axios";

const $hosta = axios.create({
    baseURL: process.env.REACT_APP_API_A_URL
})

const $authHosta = axios.create({
    baseURL: process.env.REACT_APP_API_A_URL
})

const $hostb = axios.create({
    baseURL: process.env.REACT_APP_API_B_URL
})

const $authHostb = axios.create({
    baseURL: process.env.REACT_APP_API_B_URL
})

const authInterceptor = config => {
    config.headers.authorization = `Bearer ${localStorage.getItem('token')}`
    return config
}

$authHosta.interceptors.request.use(authInterceptor)
$authHostb.interceptors.request.use(authInterceptor)

export {
    $hosta,
    $hostb,
    $authHosta,
    $authHostb
}