import React, {useState} from 'react';
import {Button, Form, Modal} from "react-bootstrap";
import {createArtist, createGenre} from "../../http/deviceAPI";

const CreateArtist = ({show, onHide}) => {

    const [name, setName] = useState('')
    const [bio, setBio] = useState('')
    const addArtist = () => {
        createArtist({name: name, bio: bio}).then(data => {
            setName('')
            setBio('')
            onHide()
        })
    }

    return (
        <Modal
            show={show}
            onHide={onHide}
            size="lg"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Добавить артиста
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        placeholder={"Введите имя автора"}
                    />
                    <Form.Control
                        value={bio}
                        onChange={e => setBio(e.target.value)}
                        placeholder={"Введите информацию об авторе"}
                    />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant={"outline-danger"} onClick={onHide}>Закрыть</Button>
                <Button variant={'outline-success'} onClick={addArtist}>Добавить</Button>
            </Modal.Footer>
        </Modal>
    );
};

export default CreateArtist;