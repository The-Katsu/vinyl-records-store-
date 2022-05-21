import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {Row} from "react-bootstrap";
import DeviceItem from "./DeviceItem";

const DiskList = observer(() => {
    const {disk} = useContext(Context)
    const artists = disk.artists
    return (
        <Row className={'d-flex'}>
            {disk.disks.map(disk =>
                    <DeviceItem key={disk.id} disk={disk} artist={artists.find(x => x.id === disk.artistId)}/>
            )}
        </Row>
    );
});

export default DiskList;