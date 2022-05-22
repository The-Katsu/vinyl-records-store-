import React, {useContext} from 'react';
import {Button, Card, Col, Container, Dropdown, Image, Row} from "react-bootstrap";
import {Context} from "../index";
import {getBills} from "../http/deviceAPI";

const UserPanel = () => {

    const {user} = useContext(Context)
    getBills().then(data => {
        user.setBills(data)
    })

    return (
        <Container className={'mt-3'}>
            <Row>
                <Col md={4}>
                    <Image width={400} height={400} src={"https://memepedia.ru/wp-content/uploads/2020/03/gigachad.jpg"}/>
                </Col>
                <Col md={4}>
                    <Row>
                        <h1>
                            {user.user.email}
                        </h1>
                        <h3>
                            {user.user.lastName}
                        </h3>
                        <h3>
                            {user.user.firstName}
                        </h3>
                    </Row>
                </Col>
                <Col md={4}>
                </Col>
            </Row>
        </Container>
    );
};

export default UserPanel;