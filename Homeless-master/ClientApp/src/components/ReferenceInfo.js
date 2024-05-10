import React, { useEffect, useState } from "react";

const URL = "/api/referenceinfo";

const ReferenceInfo = () => {
    const [referenceInfo, setReferenceInfo] = useState({ charityCenterInfo: "", actionsInfo: "" });

    const getReferenceInfo = async () => {
        try {
            const result = await fetch(URL);
            if (result.ok) {
                const data = await result.json();
                setReferenceInfo(data);
            }
        } catch (error) {
            console.error("Error fetching reference info:", error);
        }
    };

    const updateReferenceInfo = async () => {
        try {
            const options = {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(referenceInfo)
            };
            const result = await fetch(URL, options);
            if (result.ok) {
                console.log("Reference info updated successfully");
            }
        } catch (error) {
            console.error("Error updating reference info:", error);
        }
    };

    useEffect(() => {
        getReferenceInfo();
    }, []);

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setReferenceInfo((prevState) => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleUpdateClick = () => {
        updateReferenceInfo();
    };

    return (
        <div>
            <div style={{ margin: "10px" }}>
                <input
                    id="charityCenterInfo"
                    type="text"
                    style={{ margin: "10px" }}
                    name="charityCenterInfo"
                    value={referenceInfo.charityCenterInfo}
                    onChange={handleInputChange}
                />
                <input
                    id="actionsInfo"
                    type="text"
                    style={{ margin: "10px" }}
                    name="actionsInfo"
                    value={referenceInfo.actionsInfo}
                    onChange={handleInputChange}
                />
                <button onClick={handleUpdateClick} style={{ margin: "10px" }}>
                    Обновить Справочную информацию
                </button>
            </div>
        </div>
    );
};

export default ReferenceInfo;