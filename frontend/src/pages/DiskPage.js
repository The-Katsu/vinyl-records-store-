import React from 'react';
import {Button, Card, Col, Container, Image, Row} from "react-bootstrap";

const DiskPage = () => {
    const disk = {id: 1, name: 'Bad', price: 5000, date: '1987-08-31',img: 'https://upload.wikimedia.org/wikipedia/ru/d/d2/Michael_Jackson_%E2%80%94_Bad_25_album_cover.jpg'}

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