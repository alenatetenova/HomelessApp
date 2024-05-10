import React, { useEffect, useState } from "react";

const URL = "/api/homelessmessage";

const HomelessMessage = () => {
    const [allHomelessMessages, setHomelessMessages] = useState([]);
    const [homelessName, setHomelessName] = useState("");
    const [adress, setAdress] = useState("");

    const [homelessSurname, setHomelessSurname] = useState("");
    const [homelessPatronymic, setHomelessPatronymic] = useState("");
    const [homelessBirthDate, setHomelessBirthDate] = useState("");
    const [homelessDescription, setHomelessDescription] = useState("");
    const [documentType, setDocumentType] = useState("");
    const [documentNumber, setDocumentNumber] = useState("");
    const [otherDocument, setOtherDocument] = useState("");
    const [otherNeed, setOtherNeed] = useState("");
    const [documentTypes, setDocumentTypes] = useState([]);
    const [homelessStatusId, setHomelessStatusId] = useState("");
    const [messageStatusId, setMessageStatusId] = useState("");
    const [needTypeId, setNeedTypeId] = useState("");
    const [homelessStates, setHomelessStates] = useState([]);
    const [messageStatuses, setMessageStatuses] = useState([]);
    const [needTypes, setNeedTypes] = useState([]);
    const [homelessLocationX, setHomelessLocationX] = useState("");
    const [homelessLocationY, setHomelessLocationY] = useState("");
    const [editingHomelessMessage, setEditingHomelessMessage] = useState(null);

    const editHomelessMessage = (homelessMessage) => {
        setEditingHomelessMessage(homelessMessage);
        setHomelessName(homelessMessage.homelessName);
        setHomelessSurname(homelessMessage.homelessSurname);
        setAdress(homelessMessage.adress);
        setHomelessPatronymic(homelessMessage.homelessPatronymic);
        setHomelessBirthDate(homelessMessage.homelessBirthDate);
        setHomelessDescription(homelessMessage.homelessDescription);
        setDocumentType(homelessMessage.documentType);
        setDocumentNumber(homelessMessage.documentNumber);
        setOtherDocument(homelessMessage.otherDocument);
        setOtherNeed(homelessMessage.otherNeed);
        setHomelessStatusId(homelessMessage.homelessStatusId);
        setMessageStatusId(homelessMessage.messageStatusId);
        setNeedTypeId(homelessMessage.needTypeId);
        setHomelessLocationX(homelessMessage.homelessLocationX);
        setHomelessLocationY(homelessMessage.homelessLocationY);
    }



    const updateHomelessMessage = async () => {
        const updatedHomelessMessage = {
            id: editingHomelessMessage.id,
            homelessName: homelessName,
            hadress: adress,
            homelessSurname: homelessSurname,
            homelessPatronymic: homelessPatronymic,
            homelessBirthDate: homelessBirthDate,
            homelessDescription: homelessDescription,
            documentType: documentType,
            documentNumber: documentNumber,
            otherDocument: otherDocument,
            otherNeed: otherNeed,
            homelessStatusId: homelessStatusId,
            messageStatusId: messageStatusId,
            needTypeId: needTypeId,
            homelessLocationX: homelessLocationX,
            homelessLocationY: homelessLocationY
        };

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');

        const options = {
            method: 'PUT',
            headers: headers,
            body: JSON.stringify(updatedHomelessMessage)
        };

        const result = await fetch(`${URL}/${editingHomelessMessage.id}`, options);
        if (result.ok) {
            const updated = await result.json();
            const updatedAllHomelessMessages = allHomelessMessages.map(message => message.id === updated.id ? updated : message);
            setHomelessMessages(updatedAllHomelessMessages);
            setEditingHomelessMessage(null);
            clearInputs();
        }
    }

    const getHomelessMessages = async () => {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const result = await fetch(URL, options);
        if (result.ok) {
            const homelessMessages = await result.json(); setHomelessMessages(homelessMessages);
        }
    }

    const getDocumentTypes = async () => {
        try {
            const result = await fetch("/api/homeless/documentTypes");
            if (result.ok) {
                const types = await result.json();
                setDocumentTypes(types);
            } else {
                console.error("Ошибка при загрузке типов документов:", result.status);
            }
        } catch (error) {
            console.error("Ошибка при загрузке типов документов:", error);
        }
    }

    const getHomelessStates = async () => {
        try {
            const result = await fetch("/api/homeless/homelessStates");
            if (result.ok) {
                const states = await result.json();
                setHomelessStates(states);
            } else {
                console.error("Ошибка при загрузке статусов бездомных:", result.status);
            }
        } catch (error) {
            console.error("Ошибка при загрузке статусов бездомных:", error);
        }
    }

    const getMessageStatuses = async () => {
        try {
            const result = await fetch("/api/homeless/messageStatuses");
            if (result.ok) {
                const statuses = await result.json();
                setMessageStatuses(statuses);
            } else {
                console.error("Ошибка при загрузке статусов сообщений:", result.status);
            }
        } catch (error) {
            console.error("Ошибка при загрузке статусов сообщений:", error);
        }
    }

    const getNeedTypes = async () => {
        try {
            const result = await fetch("/api/homeless/needTypes");
            if (result.ok) {
                const types = await result.json();
                setNeedTypes(types);
            } else {
                console.error("Ошибка при загрузке типов потребностей:", result.status);
            }
        } catch (error) {
            console.error("Ошибка при загрузке типов потребностей:", error);
        }
    }

    const clearInputs = () => {
        setHomelessName("");
        setAdress("");

        setHomelessSurname("");
        setHomelessPatronymic("");
        setHomelessBirthDate("");
        setHomelessDescription("");
        setDocumentType("");
        setDocumentNumber("");
        setOtherDocument("");
        setOtherNeed("");
        setHomelessStatusId("");
        setMessageStatusId("");
        setNeedTypeId("");
        setHomelessLocationX("");
        setHomelessLocationY("");
    }

    const getDocumentTypeNameById = (id) => {
        const documentType = documentTypes.find(type => type.id === id);
        return documentType ? documentType.documentType : '';
    }

    const getHomelessStateNameById = (id) => {
        const homelessState = homelessStates.find(state => state.id === id);
        return homelessState ? homelessState.state : '';
    }

    const getMessageStatusNameById = (id) => {
        const messageStatus = messageStatuses.find(status => status.id === id);
        return messageStatus ? messageStatus.status : '';
    }

    const getNeedTypeNameById = (id) => {
        const needType = needTypes.find(type => type.id === id);
        return needType ? needType.type : '';
    }

    useEffect(() => {
        getHomelessMessages();
        getDocumentTypes();
        getHomelessStates();
        getMessageStatuses();
        getNeedTypes();
    }, []);

    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Фамилия</th>
                        <th>Отчество</th>
                        <th>Дата рождения</th>
                        <th>Описание</th>
                        <th>Тип документа</th>
                        <th>Номер документа</th>
                        <th>Другой документ</th>
                        <th>Другая потребность</th>
                        <th>Статус бездомного</th>
                        <th>Тип потребности</th>
                        <th>Адрес</th>
                        <th>Статус сообщения</th>
                    </tr>
                </thead>
                <tbody>
                    {allHomelessMessages.map(homelessMessage =>
                        <tr key={homelessMessage.id}>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ? <input type="text" value={homelessName} onChange={(e) => setHomelessName(e.target.value)} /> :
                                    homelessMessage.homelessName}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={homelessSurname} onChange={(e) => setHomelessSurname(e.target.value)} /> :
                                    homelessMessage.homelessSurname}
                            </td>
                            <td>{editingHomelessMessage?.id === homelessMessage.id ?
                                <input type="text" value={homelessPatronymic} onChange={(e) => setHomelessPatronymic(e.target.value)} /> :
                                homelessMessage.homelessPatronymic}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="date" value={homelessBirthDate} onChange={(e) => setHomelessBirthDate(e.target.value)} /> :
                                    new Date(homelessMessage.homelessBirthDate).toLocaleDateString('ru-RU')}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={homelessDescription} onChange={(e) => setHomelessDescription(e.target.value)} /> :
                                    homelessMessage.homelessDescription}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <select value={documentType} onChange={(e) => setDocumentType(e.target.value)}>
                                        {documentTypes.map((type) => (
                                            <option key={type.id} value={type.id}>{type.documentType}</option>
                                        ))}
                                    </select> :
                                    getDocumentTypeNameById(homelessMessage.documentType)}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={documentNumber} onChange={(e) => setDocumentNumber(e.target.value)} /> :
                                    homelessMessage.documentNumber}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={otherDocument} onChange={(e) => setOtherDocument(e.target.value)} /> :
                                    homelessMessage.otherDocument}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={otherNeed} onChange={(e) => setOtherNeed(e.target.value)} /> :
                                    homelessMessage.otherNeed}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <select value={homelessStatusId} onChange={(e) => setHomelessStatusId(e.target.value)}>
                                        {homelessStates.map((state) => (
                                            <option key={state.id} value={state.id}>{state.state}</option>
                                        ))}
                                    </select> :
                                    getHomelessStateNameById(homelessMessage.homelessStatusId)}
                            </td>
                           
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <select value={needTypeId} onChange={(e) => setNeedTypeId(e.target.value)}>
                                        {needTypes.map((type) => (
                                            <option key={type.id} value={type.id}>{type.type}</option>))}
                                    </select> :
                                    getNeedTypeNameById(homelessMessage.needTypeId)}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <input type="text" value={adress} onChange={(e) => setAdress(e.target.value)} /> :
                                    homelessMessage.adress}
                            </td>
                            <td>
                                {editingHomelessMessage?.id === homelessMessage.id ?
                                    <select value={messageStatusId} onChange={(e) => setMessageStatusId(e.target.value)}>
                                        {messageStatuses.map((status) => (
                                            <option key={status.id} value={status.id}>{status.status}</option>
                                        ))}
                                    </select> :
                                    getMessageStatusNameById(homelessMessage.messageStatusId)}
                            </td>
                           
                        </tr>)}
                </tbody>
            </table>
        </div>
    )
}

export default HomelessMessage;