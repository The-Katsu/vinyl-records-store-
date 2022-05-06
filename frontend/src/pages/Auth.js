import React from 'react';
import {Button, Card, Container, Form, Row} from "react-bootstrap";
import NavLink from "react-router-dom/NavLink";
import {LOGIN_ROUTE, REGISTRATION_ROUTE} from "../utils/consts";
import {useLocation} from "react-router-dom/cjs/react-router-dom";

const Auth = () => {
    const location = useLocation()
    const isLogin = location.pathname === LOGIN_ROUTE

    return (
        <Container
            className='d-flex justify-content-center align-items-center'
            style={{height: window.innerHeight - 54}}
            >
            <Card style={{width: 600}} className='p-5'>
                <h2 className='m-auto'> {isLogin ?  'Авторизация' : "Регистрация"}</h2>
                <Form className="d-flex flex-column">
                    <Form.Control
                        className="mt-3"
                        placeholder="Введите ваш email..."
                    />
                    {!isLogin ?
                        <Button className={'mt-3'}>
                            Отправить код на почту
                        </Button>
                        :
                        ""
                    }
                    {!isLogin ?
                        <Form.Control
                            className={'mt-3'}
                            placeholder={'Введите код подтвеждения'}
                        />
                        :
                        ""
                    }
                    <Form.Control
                        className="mt-3"
                        placeholder="Введите ваш пароль..."
                    />
                    <Row className={"justify-content-between mt-3"}>
                        {isLogin ?
                            <div>
                                Нет аккаунта ? <NavLink to={REGISTRATION_ROUTE}>Зарегистрируйся!</NavLink>
                            </div>
                            :
                            <div>
                                Есть аккаунт ? <NavLink to={LOGIN_ROUTE}>Войдите!</NavLink>
                            </div>
                        }
                    </Row>
                    <Button className={'mt-3'} variant={"outline-success"}>
                        {isLogin ? 'Войти' : 'Регистрация'}
                    </Button>
                </Form>
            </Card>
        </Container>
    );
};

export default Auth;