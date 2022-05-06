import React, {useContext} from 'react';
import {Context} from "../index";
import {Button, Container, Nav, Navbar} from "react-bootstrap";
import NavLink from "react-router-dom/NavLink";
import {SHOP_ROUTE} from "../utils/consts";
import {observer} from "mobx-react-lite";

const NavBar = observer(() => {
    const {user} = useContext(Context)
    return (
        <Navbar bg="dark" variant="dark">
            <Container>
                <NavLink style={{color: 'white'}} to={SHOP_ROUTE}> Vinyl Disks </NavLink>
                {user.isAuth ?
                    <Nav className="ms-auto" style={{color: 'white'}}>
                        <Button variant={"outline-light"}>Админ панель</Button>
                        <Button variant={"outline-light"} className='ms-2'>Выйти</Button>
                    </Nav>
                    :
                    <Nav className="ms-auto" style={{color: 'white'}}>
                        <Button variant={"outline-light"} onClick={() => user.setIsAuth(true)}>Авторизация</Button>
                    </Nav>
                }
            </Container>
        </Navbar>
    );
});

export default NavBar;