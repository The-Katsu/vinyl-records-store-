import {BrowserRouter} from "react-router-dom";
import AppRouter from "./components/AppRouter";
import Navbar from "./components/NavBar";
import {observer} from "mobx-react-lite";
import {Context} from "./index";
import {useContext, useEffect, useState} from "react";
import {check} from "./http/userAPI";
import {Spinner} from "react-bootstrap";
import {getBasket, getBills} from "./http/deviceAPI";

const App = observer(() => {
     const {user} = useContext(Context)
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        check().then(data => {
            user.setUser(data.data)
            user.setIsAuth(true)
            user.setRole(data.data.role)
            getBasket().then(data => {
                user.setBasket(data)
            })
            getBills().then(data => {
                user.setBills(data)
            })
        }).finally(() => setLoading(false))
    }, [])

    if (loading)
    {
        return <Spinner animation={"grow"}/>
    }

    return (
        <BrowserRouter>
            <>
            <Navbar/>
            <AppRouter/>
            </>
        </BrowserRouter>
      );
})

export default App;