import {makeAutoObservable} from "mobx";

export default class UserStore {
    constructor() {
        this._isAuth = false
        this._role = 'Customer'
        this._user = { }
        this._basket = []
        this._bills = [ ]
        this._selectedBill = { }
        makeAutoObservable(this)
    }

    setIsAuth(bool) {
        this._isAuth = bool
    }

    setUser(user) {
        this._user = user
    }

    setRole(role) {
        this._role = role
    }

    setBasket(basket) {
        this._basket = basket
    }

    setBills(bills) {
        this._bills = bills
    }

    setSelectedBill(bill) {
        this._selectedBill = bill
    }

    addToBasket(id) {
        this._basket.push(id)
    }

    get selectedBill() {
        return this._selectedBill
    }

    get bill() {
        return this._bills
    }

    get role() {
        return this._role
    }

    get basket() {
        return this._basket
    }

    get isAuth() {
        return this._isAuth
    }

    get user() {
        return this._user
    }
}