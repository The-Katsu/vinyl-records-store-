import React from 'react';
import {Col, Container, Row} from "react-bootstrap";
import TypeBar from "../components/TypeBar";
import ArtistBar from "../components/ArtistBar";
import DiskList from "../components/DiskList";

const Shop = () => {
    return (
        <Container>
            <Row className={'mt-3'}>
                <Col md={3}>
                    <TypeBar/>
                </Col>
                <Col md={9}>
                    <ArtistBar/>
                    <DiskList/>
                </Col>
            </Row>
        </Container>
    );
};

export default Shop;