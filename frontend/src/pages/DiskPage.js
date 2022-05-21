import React, {useEffect, useState} from 'react';
import {Button, Card, Col, Container, Image, Row} from "react-bootstrap";
import {useParams} from "react-router-dom/cjs/react-router-dom";
import {getArtist, getDisk} from "../http/deviceAPI";

const DiskPage = () => {
    const [disk, setDisk] = useState('')
    const [artist, setArtist] = useState('')
    const {id} = useParams()
    useEffect(() => {
        getDisk(id).then(data => setDisk(data))
    }, [])

    return (
        <Container className={'mt-3'}>
            <Row>
                <Col md={4}>
                    <Image width={400} height={400} src={disk.img}/>
                </Col>
                <Col md={4}>
                    <Row>
                        <h2>
                            {disk.name}
                        </h2>
                        <h4>
                            {disk.about}
                        </h4>
                        <div className={'d-flex align-items-center justify-content-center'}>
                            {disk.date}
                        </div>
                    </Row>
                </Col>
                <Col md={4}>
                    <Card
                        className={'d-flex flex-column align-items-center justify-content-around'}
                        style={{width:400, height: 400, fontSize: 32, border: '5px solid lightgray'}}
                    >
                        <h3 className={'d-flex align-items-center justify-content-center'}>
                            {disk.price} Р
                        </h3>
                        <Button variant={"outline-dark"}>
                            Добавить в корзину
                        </Button>
                    </Card>
                </Col>
            </Row>
        </Container>
    );
};

export default DiskPage;