import {makeAutoObservable} from "mobx";

export default class DiskStore {
    constructor() {
        this._artists = [
            {id: 1, name: 'Michael Jackson'},
            {id: 2, name: 'Fill Kirkorov'},
            {id: 3, name: 'Дора'}
        ]
        this._genres = [
            {id: 1, name: 'pop'},
            {id: 2, name: 'rock'},
            {id: 3, name: 'rap'},
            {id: 4, name: 'cute-rock'}
        ]
        this._disks = [
            {id: 1, name: 'Bad', price: 5000, date: '1987-08-31',img: 'https://upload.wikimedia.org/wikipedia/ru/d/d2/Michael_Jackson_%E2%80%94_Bad_25_album_cover.jpg'},
            {id: 2, name: 'Sbornik', price: 9999999, date: '0001-01-01', img: 'https://n1s2.starhit.ru/2c/81/b6/2c81b6121aeaf7c11881299abf7eb74d/468x496_0_d47c6f4e425cbf113a1856bbb1aa0c9e@468x496_0x0a330c9a_9433739711540364539.jpeg'},
            {id: 3, name: 'Дура', price: 300, date: '2020-20-20', img: 'https://avatars.yandex.net/get-music-content/2266607/25bb0801.a.8888246-1/m1000x1000'},

        ]
        this._selectedGenre = {}
        this._selectedArtist = {}
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

    setSelectedGenre(genre) {
        this._selectedGenre = genre
    }

    setSelectedArtist(artist) {
        this._selectedArtist = artist
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

    get selectedGenre() {
        return this._selectedGenre
    }

    get selectedArtist() {
        return this._selectedArtist
    }
}