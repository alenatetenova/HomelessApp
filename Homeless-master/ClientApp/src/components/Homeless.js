import React, { useEffect, useState } from "react";

const URL = "/api/homeless";

const Homeless = () => {
    const [allHomeless, setHomeless] = useState([]);
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [patronymic, setPatronymic] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [description, setDescription] = useState("");
    const [documentType, setDocumentType] = useState("");
    const [documentNumber, setDocumentNumber] = useState("");
    const [otherDocument, setOtherDocument] = useState("");
    const [documentTypes, setDocumentTypes] = useState([]);
    const [editingHomeless, setEditingHomeless] = useState(null);

    const addHomeless = async () => {
        const newHomeless = {
            name: name,
            surname: surname,
            patronymic: patronymic,
            birthDate: birthDate,
            description: description,
            documentType: documentType,
            documentNumber: documentNumber,
            otherDocument: otherDocument
        };

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');

        const options = {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(newHomeless)
        };

        const result = await fetch(URL, options);
        if (result.ok) {
            const homeless = await result.json()
            setHomeless([...allHomeless, homeless]);
            clearInputs();
        }
    }

    const deleteHomeless = async (id) => {
        const options = {
            method: 'DELETE',
            headers: new Headers()
        }
        await fetch(`${URL}/${id}`, options);
        setHomeless(allHomeless.filter(x => x.id !== id));
    }

    const editHomeless = (homeless) => {
        setEditingHomeless(homeless);
        setName(homeless.name);
        setSurname(homeless.surname);
        setPatronymic(homeless.patronymic);
        setBirthDate(homeless.birthDate);
        setDescription(homeless.description);
        setDocumentType(homeless.documentType);
        setDocumentNumber(homeless.documentNumber);
        setOtherDocument(homeless.otherDocument);
    }

    const updateHomeless = async () => {
        const updatedHomeless = {
            id: editingHomeless.id,
            name: name,
            surname: surname,
            patronymic: patronymic,
            birthDate: birthDate,
            description: description,
            documentType: documentType,
            documentNumber: documentNumber,
            otherDocument: otherDocument
        };

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');

        const options = {
            method: 'PUT',
            headers: headers,
            body: JSON.stringify(updatedHomeless)
        };

        const result = await fetch(`${URL}/${editingHomeless.id}`, options);
        if (result.ok) {
            const updated = await result.json();
            const updatedAllHomeless = allHomeless.map(homeless => homeless.id === updated.id ? updated : homeless);
            setHomeless(updatedAllHomeless);
            setEditingHomeless(null);
            clearInputs();
        }
    }

    const getHomeless = async () => {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const result = await fetch(URL, options);
        if (result.ok) {
            const homeless = await result.json();
            setHomeless(homeless);
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

    const clearInputs = () => {
        setName("");
        setSurname("");
        setPatronymic("");
        setBirthDate("");
        setDescription("");
        setDocumentType("");
        setDocumentNumber("");
        setOtherDocument("");
    }

    useEffect(() => {
        getHomeless();
        getDocumentTypes();
    }, []);

    const getDocumentTypeNameById = (id) => {
        const documentType = documentTypes.find(type => type.id === id);
        return documentType ? documentType.documentType : '';
    }

    return (
        <div>
            <div style={{ margin: '10px', display: 'grid', gridTemplateColumns: 'repeat(4, 1fr)', gridGap: '10px' }}>
                {/* Input fields */}
                <div>
                    <div><label htmlFor="name">Имя:</label></div>
                    <input id="name" type="text" value={name} onChange={(e) => setName(e.target.value)} />
                </div>
                <div>
                    <div><label htmlFor="surname">Фамилия:</label></div>
                    <input id="surname" type="text" value={surname} onChange={(e) => setSurname(e.target.value)} />
                </div>
                <div>
                    <div><label htmlFor="patronymic">Отчество:</label></div>
                    <input id="patronymic" type="text" value={patronymic} onChange={(e) => setPatronymic(e.target.value)} />
                </div>
                <div>
                    <div><label htmlFor="birthDate">Дата рождения:</label></div>
                    <input id="birthDate" type="date" value={birthDate} onChange={(e) => setBirthDate(e.target.value)} />
                </div>
                <div><div><label htmlFor="description">Описание:</label></div>
                    <input id="description" type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
                </div>
                <div>
                    <div><label htmlFor="documentType">Тип документа:</label></div>
                    <select id="documentType" value={documentType} onChange={(e) => setDocumentType(e.target.value)}>
                        {documentTypes.map((type) => (
                            <option key={type.id} value={type.id}>{type.documentType}</option>
                        ))}
                    </select>
                </div>
                <div>
                    <div><label htmlFor="documentNumber">Номер документа:</label></div>
                    <input id="documentNumber" type="text" value={documentNumber} onChange={(e) => setDocumentNumber(e.target.value)} />
                </div>
                <div>
                    <div><label htmlFor="otherDocument">Другой документ:</label></div>
                    <input id="otherDocument" type="text" value={otherDocument} onChange={(e) => setOtherDocument(e.target.value)} />
                </div>
                <div style={{ gridColumn: 'span 4' }}>
                    {editingHomeless ? (
                        <button onClick={() => updateHomeless()} style={{ margin: '10px' }}>Сохранить</button>
                    ) : (
                        <button onClick={() => addHomeless()} style={{ margin: '10px' }}>Добавить бездомного</button>
                    )}
                </div>
            </div>
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
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {allHomeless.map(homeless =>
                        <tr key={homeless.id}>
                            <td>
                                {editingHomeless?.id === homeless.id ? <input type="text" value={name} onChange={(e) => setName(e.target.value)} /> :
                                    homeless.name}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="text" value={surname} onChange={(e) => setSurname(e.target.value)} /> :
                                    homeless.surname}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="text" value={patronymic} onChange={(e) => setPatronymic(e.target.value)} /> :
                                    homeless.patronymic}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="date" value={birthDate} onChange={(e) => setBirthDate(e.target.value)} /> :
                                    new Date(homeless.birthDate).toLocaleDateString('ru-RU')}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} /> :
                                    homeless.description}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <select value={documentType} onChange={(e) => setDocumentType(e.target.value)}>
                                        {documentTypes.map((type) => (
                                            <option key={type.id} value={type.id}>{type.documentType}</option>
                                        ))}
                                    </select> :
                                    getDocumentTypeNameById(homeless.documentType)}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="text" value={documentNumber} onChange={(e) => setDocumentNumber(e.target.value)} /> :
                                    homeless.documentNumber}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <input type="text" value={otherDocument} onChange={(e) => setOtherDocument(e.target.value)} /> :
                                    homeless.otherDocument}
                            </td>
                            <td>
                                {editingHomeless?.id === homeless.id ?
                                    <button onClick={() => updateHomeless()}>Сохранить</button> :
                                    <button onClick={() => editHomeless(homeless)}>Редактировать</button>
                                }
                                <button onClick={() => deleteHomeless(homeless.id)}>Удалить</button>
                            </td>
                        </tr>)}
                </tbody>
            </table>
        </div>
    )
}

export default Homeless;