import React, {useContext} from 'react';
import {Context} from "../index";
import {Badge, Button, Col, Container, ListGroup, Row} from "react-bootstrap";
import BasketList from "../components/BasketList";
import TypeBar from "../components/TypeBar";
import ArtistBar from "../components/ArtistBar";
import DiskList from "../components/DiskList";
import {addToBasket, postBasket} from "../http/deviceAPI";
import {useHistory} from "react-router-dom/cjs/react-router-dom";
import {BASKET_ROUTE} from "../utils/consts";

const Basket = () => {

    const {user} = useContext(Context)

    const buy = async () => {
        try {
            if (!user.isAuth) {
                throw new Error("Перед покупкой авторизуйтесь")
            }
            try{

                const response = await postBasket()
            }
            catch (e) {
                alert("Корзина пустая")
            }
        }
        catch (e){
            alert(e.response.data.message)
        }
    }


    return (
        <Container>
            <Row className={'mt-3'}>
                <Col md={9}>
                    <BasketList/>
                </Col>
                <Col md={3} className={'d-flex'}>
                    <Button onClick={() => {
                        buy()
                    }}>
                        Купить!
                    </Button>
                </Col>
            </Row>
        </Container>
    );
};

export default Basket;