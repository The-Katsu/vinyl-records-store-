import React from 'react';
import {Card, Col, Image} from "react-bootstrap";
import {useHistory} from "react-router-dom/cjs/react-router-dom";
import {DISK_ROUTE} from "../utils/consts";

const DeviceItem = ({disk}) => {
    const history = useHistory()
    return (
        <Col md={3} className={'mt-3'} onClick={() => history.push(DISK_ROUTE + "/" + disk.id)}>
            <Card style={{width: 150, cursor: 'pointer'}} border={"light"}>
                <Image width={150} height={150} src={disk.img}/>
                <div className={'text-black-50'}> record </div>
                <div> {disk.name} </div>
            </Card>
        </Col>
    );
};

export default DeviceItem;