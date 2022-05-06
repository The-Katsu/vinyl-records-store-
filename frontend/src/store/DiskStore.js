import {makeAutoObservable} from "mobx";

export default class DiskStore {
    constructor() {
        this._artists = [
            {id: 1, name: 'Michael Jackson'},
            {id: 2, name: 'Fill Kirkorov'}
        ]
        this._genres = [
            {id: 1, name: 'pop'},
            {id: 2, name: 'rock'}
        ]
        this._disks = [
            {id: 1, name: 'Bad', price: 5000, date: '1987-08-31',img: 'https://upload.wikimedia.org/wikipedia/ru/d/d2/Michael_Jackson_%E2%80%94_Bad_25_album_cover.jpg'},
            {id: 2, name: 'Sbornik', price: 9999999, date: '0001-01-01', img: 'https://n1s2.starhit.ru/2c/81/b6/2c81b6121aeaf7c11881299abf7eb74d/468x496_0_d47c6f4e425cbf113a1856bbb1aa0c9e@468x496_0x0a330c9a_9433739711540364539.jpeg'}
        ]
        makeAutoObservable(this)
    }

    setArtists(artists) {
        this._artists = artists
    }

    setGenres(genres) {
        this._genres = genres
    }

    setDisks(disks){
        this._disks = disks
    }

    get artists() {
        return this._artists
    }

    get genres() {
        return this._genres
    }

    get disks() {
        return this._disks
    }
}