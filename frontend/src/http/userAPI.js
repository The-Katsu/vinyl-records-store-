import {$hosta, $authHosta} from "./index";
import jwt_decode from "jwt-decode";

export const registration = async (firstName, lastName, email, code, password, confirmPassword) => {
    code = parseInt(code)
    const token = await $hosta.post('/signUp', {
        firstName, lastName, email, code, password, confirmPassword
    })
    localStorage.setItem('token', token.data)
    return await getUser()
}

export const login = async (email, password) => {
    const token = await $hosta.post('/signIn', {
        email, password
    })
    localStorage.setItem('token', token.data)
    return await getUser()
}

export const sendCode = async (email) => {
    const response = await $hosta.post(`/sendCode?email=${email.replace('@', '%40')}&restorePassword=${false}`)
    return response
}

const getUser = async () => {
    const response = await $authHosta.get('/user')
    return response
}

export const check = async () => {
    const data = await $authHosta('/auth')
    localStorage.setItem('token', data.data)
    return await getUser()
}