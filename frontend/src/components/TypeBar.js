import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {ListGroup} from "react-bootstrap";

const TypeBar = observer(() => {
    const {disk} = useContext(Context)
    return (
        <ListGroup>
            {disk.genres.map( genre =>
                <ListGroup.Item
                    style={{cursor: 'pointer'}}
                    active={genre.id === disk.selectedGenre.id}
                    onClick={() => disk.setSelectedGenre(genre)}
                    key={genre.id}
                >
                    {genre.name}
                </ListGroup.Item>
            )}
        </ListGroup>
    );
});

export default TypeBar;