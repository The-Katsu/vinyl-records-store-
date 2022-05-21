import React, {useContext, useEffect} from 'react';
import {Col, Container, Row} from "react-bootstrap";
import TypeBar from "../components/TypeBar";
import ArtistBar from "../components/ArtistBar";
import DiskList from "../components/DiskList";
import {Context} from "../index";
import {observer} from "mobx-react-lite";
import {getArtists, getDisks, getGenres} from "../http/deviceAPI";

const Shop = observer(() => {
    const {disk} = useContext(Context)
    useEffect(() => {
        getGenres().then(data => disk.setGenres(data))
        getArtists().then(data => disk.setArtists(data))
        getDisks().then(data => {disk.setDisks(data)})
    }, [])

    useEffect(() => {
        if(disk.selectedArtist.name !== undefined && disk.selectedGenre.name !== undefined){
            getDisks().then(data => {disk.setDisks(data.filter(x =>
                x.genreId === disk.selectedGenre.id &&
                x.artistId === disk.selectedArtist.id
            ))})
        }
        else if(disk.selectedGenre.name !== undefined){
            getDisks().then(data => {disk.setDisks(data.filter(x =>
                x.genreId === disk.selectedGenre.id
            ))})
        }
        else if(disk.selectedArtist.name !== undefined) {
            getDisks().then(data => {disk.setDisks(data.filter(x =>
                x.artistId === disk.selectedArtist.id
            ))})
        }
        else{
            getDisks().then(data => {disk.setDisks(data)})
        }
        console.log(disk.selectedGenre.name)
        console.log(disk.selectedArtist.name)
    }, [disk.selectedGenre, disk.selectedArtist])

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
});

export default Shop;