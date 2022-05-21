import {makeAutoObservable} from "mobx";

export default class DiskStore {
    constructor() {
        this._artists = [ ]
        this._genres = [ ]
        this._disks = []
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