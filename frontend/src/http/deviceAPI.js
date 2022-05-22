import {$hostb, $authHostb} from "./index";

export const addToBasket = async (id) => {
    const {data} = await $authHostb.post('api/Basket?recordId=' + id)
    return data
}

export const postBasket = async () => {
    const {data} = await $authHostb.post('api/Bill')
}

export const getBasket = async() => {
    const {data} = await $authHostb.get('api/Basket')
    return await data
}

export const getBills = async() => {
    const {data} = await $authHostb.get('api/Bill')
    return await data;
}

export const createGenre = async (genre) => {
    const {data} = await $authHostb.post('api/Genre', genre)
    return data
}

export const getGenres = async () => {
    const {data} = await $hostb.get('/api/Genre')
    return data
}

export const createArtist = async (artist) => {
    const {data} = await $authHostb.post('api/Artist', artist)
    return data
}

export const getArtists = async () => {
    const {data} = await $hostb.get('/api/Artist')
    return data
}

export const getArtist = async (id) => {
    const {data} = await $hostb.get('/api/Artist/' + id)
    return data
}

export const createDisk = async (disk) => {
    const {data} = await $authHostb.post('api/Disk', disk)
    return data
}

export const getDisks = async () => {
    const {data} = await $hostb.get('/api/Disk',)
    return data
}

export const getDisk = async (id) => {
    const {data} = await $hostb.get('/' + id)
    return data
}