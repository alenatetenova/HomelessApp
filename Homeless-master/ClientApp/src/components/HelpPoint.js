import React, { useEffect, useState } from "react";
import axios from "axios";
import Autosuggest from "react-autosuggest"

const URL = "/api/helppoint";

const HelpPoint = () => {
    const [allHelpPoints, setHelpPoints] = useState([]);
    const [name, setName] = useState("");
    const [address, setAddress] = useState("");
    const [pointLocation, setPointLocation] = useState({ lat: null, lng: null });
    const [workingHours, setWorkingHours] = useState("");
    const [description, setDescription] = useState("");
    const [suggestions, setSuggestions] = useState([]);

    useEffect(() => {
        getHelpPoints();
    }, []);

    const getHelpPoints = async () => {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const result = await fetch(URL, options);
        if (result.ok) {
            const helpPoints = await result.json();
            setHelpPoints(helpPoints);
            return helpPoints;
        }
        return [];
    }

    const addHelpPoint = async () => {
        const newHelpPoint = {
            pointName: name,
            pointLocationX: pointLocation.lat,
            pointLocationY: pointLocation.lng,
            workingHours: workingHours,
            pointDescription: description,
            adress: address // Добавляем адрес в объект пункта помощи
        };

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');

        const options = {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(newHelpPoint)
        };

        const result = await fetch(URL, options);
        if (result.ok) {
            const helpPoint = await result.json();
            setHelpPoints([...allHelpPoints, helpPoint]);
        }
    }

    const deleteHelpPoint = async (id) => {
        const options = {
            method: 'DELETE',
            headers: new Headers()
        }
        await fetch(`${URL}/${id}`, options);
        setHelpPoints(allHelpPoints.filter(x => x.id !== id));
    }

     //для адреса

    const renderSuggestion = suggestion => (
        <div>{suggestion}</div>
    );

    const handleAddressChange = async (address) => {
        setAddress(address);
        try {
            const response = await axios.get(`https://geocode-maps.yandex.ru/1.x/?apikey=ea2d7f4b-344d-495e-8a52-09f8a619da0c&format=json&geocode=${encodeURIComponent(address)}`);
            const coordinates = response.data.response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos.split(" ");
            const lat = coordinates[1];
            const lng = coordinates[0];
            setPointLocation({ lat, lng });
            const suggestedAddresses = response.data.response.GeoObjectCollection.featureMember.map(item => item.GeoObject.metaDataProperty.GeocoderMetaData.text);
            setSuggestions(suggestedAddresses);
        } catch (error) {
            console.error("Error geocoding address:", error);
        }
    };

    const getSuggestions = async value => {
        try {
            const response = await axios.get(`https://geocode-maps.yandex.ru/1.x/?apikey=ea2d7f4b-344d-495e-8a52-09f8a619da0c&format=json&geocode=${encodeURIComponent(value)}`);
            const suggestedAddresses = response.data.response.GeoObjectCollection.featureMember.map(item => item.GeoObject.metaDataProperty.GeocoderMetaData.text);
            setSuggestions(suggestedAddresses);
        } catch (error) {
            console.error("Error fetching suggestions:", error);
        }
    };

    const onSuggestionsFetchRequested = ({ value }) => {
        getSuggestions(value);
    };

    const onSuggestionsClearRequested = () => {
        setSuggestions([]);
    };

    const inputProps = {
        placeholder: "Адрес",
        value: address,
        onChange: (_, { newValue }) => handleAddressChange(newValue)
    };

    return (
        <div>
            <div style={{ margin: '10px', display: 'flex', alignItems: 'center' }}>
                <input id="name" type="text" value={name} onChange={(e) => setName(e.target.value)} placeholder="Название пункта помощи" style={{ margin: '10px' }} />
                <Autosuggest
                    suggestions={suggestions}
                    onSuggestionsFetchRequested={onSuggestionsFetchRequested}
                    onSuggestionsClearRequested={onSuggestionsClearRequested}
                    getSuggestionValue={suggestion => suggestion}
                    renderSuggestion={renderSuggestion}
                    inputProps={inputProps}
                />
                <input id="workingHours" type="text" value={workingHours} onChange={(e) => setWorkingHours(e.target.value)} placeholder="Часы работы" style={{ margin: '10px' }} />
                <textarea id="description" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Описание" style={{ margin: '10px' }} />
                <button onClick={() => addHelpPoint()} style={{ margin: '10px' }}>Добавить Пункт помощи</button>
            </div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Название</th>
                        <th>Адрес</th>
                        <th>Часы работы</th>
                        <th>Описание</th>
                        <th>Удалить</th>
                    </tr>
                </thead>
                <tbody>
                    {allHelpPoints.map(helpPoint =>
                        <tr key={helpPoint.id}>
                            <td>{helpPoint.pointName}</td>
                            <td>{helpPoint.adress}</td> {/* Выводим строковый адрес */}
                            <td>{helpPoint.workingHours}</td>
                            <td>{helpPoint.pointDescription}</td>
                            <td>
                                <div style={{ display: 'flex' }}>
                                    <button onClick={() => deleteHelpPoint(helpPoint.id)}>Удалить</button>
                                </div>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
}

export default HelpPoint;