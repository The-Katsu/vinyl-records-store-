import React, {useContext, useEffect, useState} from 'react';
import {Button, Dropdown, Form, Modal} from "react-bootstrap";
import {Context} from "../../index";
import DropdownItem from "react-bootstrap/DropdownItem";
import {createDisk, getArtists, getDisks, getGenres} from "../../http/deviceAPI";
import {observer} from "mobx-react-lite";

const CreateDisk = observer(({show, onHide}) => {

    const {disk} = useContext(Context)

    const format = 'bd6be2d9-0317-4ead-bdd8-b6a1a3bca761'
    const [name, setName] = useState('')
    const [about, setAbout] = useState('')
    const [img, setImg] = useState('')
    const [upc, setUpc] = useState('')
    const [price, setPrice] = useState('')
    const [genre, setGenre] = useState('')
    const [artist, setArtist] = useState('')
    const [date, setDate] = useState('')

    useEffect(() => {
        getGenres().then(data => disk.setGenres(data))
        getArtists().then(data => disk.setArtists(data))
    }, [])

    const addDisk = () => {
        const d = date
        createDisk({
            name: name,
            about: about,
            price: parseInt(price),
            upc: parseInt(upc),
            img: img,
            release: d + "T11:26:42.986Z",
            artistId: disk.selectedArtist.id,
            formatId: format,
            genreId: disk.selectedGenre.id
        }).then(data => onHide())
        setName('')
        setAbout('')
        setImg('')
        setUpc(0)
        setPrice(0)
        setDate('')
        disk.setSelectedArtist('')
        disk.setSelectedGenre('')
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
                    Добавить диск
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className={'mt-2'}>
                        <Dropdown.Toggle>
                            {disk.selectedGenre.name || "Выберите жанр"}
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {disk.genres.map(genre =>
                            <Dropdown.Item
                                onClick={() => disk.setSelectedGenre(genre)}
                                key={genre.id}>
                                {genre.name}
                            </Dropdown.Item>)}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Dropdown className={'mt-2'}>
                        <Dropdown.Toggle>
                            {disk.selectedArtist.name || "Выберите артиста"}
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            {disk.artists.map(artist =>
                                <Dropdown.Item
                                    onClick={() => disk.setSelectedArtist(artist)}
                                    key={artist.id}>
                                    {artist.name}
                                </Dropdown.Item>)}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        className={'mt-3'}
                        placeholder={'Введите название'}
                    />
                    <Form.Control
                        value={about}
                        onChange={e => setAbout(e.target.value)}
                        className={'mt-3'}
                        placeholder={'Введите информацию о пластинке'}
                    />
                    <Form.Control
                        value={img}
                        onChange={e => setImg(e.target.value)}
                        className={'mt-3'}
                        placeholder={'Вставьте ссылку на изображение'}
                    />
                    <Form.Control
                        value={upc}
                        onChange={e => setUpc(Number(e.target.value))}
                        className={'mt-3'}
                        placeholder={'Введите upc'}
                        type='number'
                    />
                    <Form.Control
                        value={price}
                        onChange={e => setPrice(Number(e.target.value))}
                        className={'mt-3'}
                        placeholder={'Введите смотимость'}
                        type='number'
                    />
                    <Form.Control
                        value={date}
                        onChange={e => setDate(e.target.value)}
                        className={'mt-3'}
                        placeholder={'Введите дату релиза'}
                        type='date'
                    />

                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant={"outline-danger"} onClick={onHide}>Закрыть</Button>
                <Button variant={'outline-success'} onClick={addDisk}>Добавить</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateDisk;