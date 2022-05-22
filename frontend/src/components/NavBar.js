import React, {useContext, useEffect, useState} from 'react';
import {Context} from "../index";
import {Button, Container, Nav, Navbar} from "react-bootstrap";
import NavLink from "react-router-dom/NavLink";
import {ADMIN_ROUTE, BASKET_ROUTE, LOGIN_ROUTE, SHOP_ROUTE, USER_ROUTE} from "../utils/consts";
import {observer} from "mobx-react-lite";
import {useHistory} from "react-router-dom/cjs/react-router-dom";
import {check} from "../http/userAPI";
import {getBasket, getBills} from "../http/deviceAPI";

const NavBar = observer(() => {
    const {user} = useContext(Context)
    const history = useHistory()

    const [loading, setLoading] = useState(true)

    const logOut = ()  => {
        user.setUser({})
        user.setIsAuth(false)
        user.setRole('Customer')
    }

    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <NavLink style={{color: 'white'}} to={SHOP_ROUTE}> Vinyl Disks </NavLink>
                {user.isAuth ?
                    <Nav className="ms-auto" style={{color: 'white'}}>
                        {user.role === 'Admin' ?
                            <Button
                                variant={"outline-light"}
                                onClick={() => history.push(ADMIN_ROUTE)}
                            >
                                Админ панель
                            </Button>
                            : ""
                        }
                        <Button
                            variant={"outline-light"}
                            className='ms-2'
                            onClick={() => {
                                getBills().then(data => {
                                    user.setBills(data.data)
                                })
                                history.push(USER_ROUTE)
                            }}
                        >
                            Личный кабинет
                        </Button>
                        <Button
                            variant={"outline-light"}
                            className='ms-2'
                            onClick={() => {
                                getBasket().then(data => {
                                    user.setBasket(data)
                                })
                                history.push(BASKET_ROUTE)
                            }}
                        >
                            Корзина
                        </Button>
                        <Button
                            variant={"outline-light"}
                            className='ms-2'
                            onClick={() => logOut()}
                        >
                            Выйти
                        </Button>
                    </Nav>
                    :
                    <Nav className="ms-auto" style={{color: 'white'}}>
                        <Button variant={"outline-light"} onClick={() => history.push(LOGIN_ROUTE)}>Авторизация</Button>
                    </Nav>
                }
            </Container>
        </Navbar>
    );
});

export default NavBar;