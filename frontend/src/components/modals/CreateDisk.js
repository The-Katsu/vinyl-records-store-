import React, {useContext, useState} from 'react';
import {Button, Dropdown, Form, Modal} from "react-bootstrap";
import {Context} from "../../index";
import DropdownItem from "react-bootstrap/DropdownItem";

const CreateDisk = ({show, onHide}) => {

    const {disk} = useContext(Context)

    return (
        <Modal
            show={show}
            onHide={onHide}
            size="lg"
            centered
        >
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Добавить диск
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className={'mt-2'}>
                        <Dropdown.Toggle>
                            Выберите жанр
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {disk.genres.map(genre =>
                            <Dropdown.Item key={genre.id}>
                                {genre.name}
                            </Dropdown.Item>)}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Dropdown className={'mt-2'}>
                        <Dropdown.Toggle>
                            Выберите артиста
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {disk.artists.map(artist =>
                                <Dropdown.Item key={artist.id}>
                                    {artist.name}
                                </Dropdown.Item>)}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Form.Control
                        className={'mt-3'}
                        placeholder={'Введите название'}
                    />
                    <Form.Control
                        className={'mt-3'}
                        placeholder={'Вставьте ссылку на изображение'}
                    />
                    <Form.Control
                        className={'mt-3'}
                        placeholder={'Введите смотимость'}
                        type='number'
                    />

                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant={"outline-danger"} onClick={onHide}>Закрыть</Button>
                <Button variant={'outline-success'} onClick={onHide}>Добавить</Button>
            </Modal.Footer>
        </Modal>
    );
};

export default CreateDisk;