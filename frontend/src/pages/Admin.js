import React, {useState} from 'react';
import {Button, Container} from "react-bootstrap";
import CreateGenre from "../components/modals/CreateGenre";
import CreateArtist from "../components/modals/CreateArtist";
import CreateDisk from "../components/modals/CreateDisk";

const Admin = () => {

    const [genreVisible, setGenreVisible] = useState(false)
    const [artistVisible, setArtistVisible] = useState(false)
    const [diskVisible, setDiskVisible] = useState(false)

    return (
        <Container className={'d-flex flex-column'}>
            <Button
                variant={"outline-dark"}
                className={'mt-2'}
                onClick={() => setGenreVisible(true)}
            >
                Добавить жанр
            </Button>
            <Button
                variant={"outline-dark"}
                className={'mt-2'}
                onClick={() => setArtistVisible(true)}
            >
                Добавить артиста
            </Button>
            <Button
                variant={"outline-dark"}
                className={'mt-2'}
                onClick={() => setDiskVisible(true)}
            >
                Добавить устройство
            </Button>
            <CreateGenre show={genreVisible} onHide={() => setGenreVisible(false)}/>
            <CreateArtist show={artistVisible} onHide={() => setArtistVisible(false)}/>
            <CreateDisk show={diskVisible} onHide={() => setDiskVisible(false)}/>
        </Container>
    );
};

export default Admin;