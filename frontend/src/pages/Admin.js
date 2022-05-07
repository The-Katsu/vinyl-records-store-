import React from 'react';
import {Button, Container} from "react-bootstrap";

const Admin = () => {
    return (
        <Container className={'d-flex flex-column'}>
            <Button>
                Добавить жанр
            </Button>
            <Button>
                Добавить артиста
            </Button>
            <Button>
                Добавить устройство
            </Button>
        </Container>
    );
};

export default Admin;