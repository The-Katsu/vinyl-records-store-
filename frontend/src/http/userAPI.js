import {$hosta, $authHosta} from "./index";

export const registration = async (firstName, lastName, email, code, password, confirmPassword) => {
    code = parseInt(code)
    const response = await $hosta.post('/signUp', {
        firstName, lastName, email, code, password, confirmPassword
    })
    return response
}

export const login = async (email, password) => {
    const response = await $hosta.post('/signIn', {
        email, password
    })
    return response
}

export const sendCode = async (email) => {
    const response = await $hosta.post(`/sendCode?email=${email.replace('@', '%40')}&restorePassword=${false}`)
    return response
}