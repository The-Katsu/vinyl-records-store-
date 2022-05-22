import React, {useContext} from 'react';
import {Context} from "../index";
import {ListGroup, Row} from "react-bootstrap";
import DeviceItem from "./DeviceItem";
import BasketItem from "./BasketItem";

const BasketList = () => {
    const {user} = useContext(Context)
    return (
        <Row className={'d-flex'}>
            {user.basket.disks.map(disk =>
                <BasketItem key={disk.id} disk={disk}/>
            )}
        </Row>
    );
};

export default BasketList;