import React, {useContext, useState} from 'react';
import {Button, Card, Container, Form, Row} from "react-bootstrap";
import NavLink from "react-router-dom/NavLink";
import {LOGIN_ROUTE, REGISTRATION_ROUTE, SHOP_ROUTE} from "../utils/consts";
import {useHistory, useLocation} from "react-router-dom/cjs/react-router-dom";
import {login, registration, sendCode} from "../http/userAPI";
import {observer} from "mobx-react-lite";
import {Context} from "../index";

const Auth = observer(() => {

    const {user} = useContext(Context)
    const history = useHistory()
    const location = useLocation()
    const isLogin = location.pathname === LOGIN_ROUTE
    const [fname, setFName] = useState('')
    const [lname, setLName] = useState('')
    const [email, setEmail] = useState('')
    const [code, setCode] = useState('')
    const [password, setPassword] = useState('')
    const [cpassword, setCPassword] = useState('')

    const send = async() => {
        await sendCode(email)
    }

    const click = async () => {
        try {

            let data;
            if (isLogin){
                data = await login(email, password)
            } else {
                data = await registration(fname, lname, email, code, password, cpassword)
            }
            user.setUser(data.data)
            user.setIsAuth(true)
            user.setRole(data.data.role)
            history.push(SHOP_ROUTE)
        }
        catch (e){
            alert(e.response.data.message)
        }
    }

    return (
        <Container
            className='d-flex justify-content-center align-items-center'
            style={{height: window.innerHeight - 54}}
            >
            <Card style={{width: 600}} className='p-5'>
                <h2 className='m-auto'> {isLogin ?  'Авторизация' : "Регистрация"}</h2>
                <Form className="d-flex flex-column">
                    {!isLogin ?
                        <>
                            <Form.Control
                                className="mt-3"
                                placeholder="Введите ваше имя..."
                                value={fname}
                                onChange={e => setFName(e.target.value)}
                            />
                            <Form.Control
                                className="mt-3"
                                placeholder="Введите вашу фамилию..."
                                value={lname}
                                onChange={e => setLName(e.target.value)}
                            />
                        </>
                    :
                    ""
                    }
                    <Form.Control
                        className="mt-3"
                        placeholder="Введите ваш email..."
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                    />
                    {!isLogin ?
                        <Button
                            className={'mt-3'}
                            onClick={send}
                        >
                            Отправить код на почту
                        </Button>
                        :
                        ""
                    }
                    {!isLogin ?
                        <Form.Control
                            className={'mt-3'}
                            placeholder={'Введите код подтвеждения'}
                            type='number'
                            value={code}
                            onChange={e => setCode(e.target.value)}
                        />
                        :
                        ""
                    }
                    <Form.Control
                        className="mt-3"
                        placeholder="Введите ваш пароль..."
                        type="password"
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                    />
                    {!isLogin ?
                        <Form.Control
                        className="mt-3"
                        placeholder="Подтвердите ваш пароль..."
                        type="password"
                        value={cpassword}
                        onChange={e => setCPassword(e.target.value)}
                        /> : <></>
                    }
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
                    <Button
                        className={'mt-3'}
                        variant={"outline-success"}
                        onClick={click}
                    >
                        {isLogin ? 'Войти' : 'Регистрация'}
                    </Button>
                </Form>
            </Card>
        </Container>
    );
});

export default Auth;