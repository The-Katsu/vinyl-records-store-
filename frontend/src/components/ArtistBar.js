import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {Card, Row} from "react-bootstrap";

const ArtistBar = observer(() => {
    const {disk} = useContext(Context)
    return (
        <Row className={'d-flex'}>
            {disk.artists.map(artist =>
                <Card
                    style={{cursor: "pointer", width:150}}
                    key={artist.id}
                    className={'p-3'}
                    onClick={() => disk.setSelectedArtist(artist)}
                    border={artist.id === disk.selectedArtist.id ? 'danger' : 'light'}
                >
                    {artist.name}
                </Card>
            )}
        </Row>
    );
});

export default ArtistBar;