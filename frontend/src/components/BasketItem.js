import React from 'react';
import {Badge, Card, Col, Image, Row} from "react-bootstrap";
import {DISK_ROUTE} from "../utils/consts";

const BasketItem = (disk) => {
    disk = Object.assign({}, disk.disk)
    return (
        <Col md={5}  className={'mt-3'}>
            <Card style={{width: 150, cursor: 'pointer'}} border={"light"}>
                <Image width={150} height={150} src={disk.img}/>
                <div className={'text-black-50'}> {disk.name} </div>
                <div> {disk.price} Руб.</div>
            </Card>
        </Col>
    );
};

export default BasketItem;