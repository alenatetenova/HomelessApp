import React, { useEffect, useState } from "react";

const URL = "/api/authorization/authenticate";

const Auth = () => {


    const auth = async () => {
        const newHomeless = {
            login: document.getElementById('login').value,
            password: document.getElementById('password').value
           
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
            const homeless = await result.json();
            const token = homeless.token;
            var CurrentTime = new Date();
            CurrentTime.setSeconds(CurrentTime.getSeconds() + 110);
            document.cookie = "token=" + token + ";max-age=110" ;

            window.location.replace("/homeless");
        }
    }


    return (
        <div>
            <div style={{ margin: '10px', display: 'flex', alignItems: 'center' }}>
                <input id="login" type="text" placeholder="Логин" style={{ margin: '10px' }} />
                <input id="password" type="text"  placeholder="Пароль" style={{ margin: '10px' }} />

                
                <button onClick={() => auth()} style={{ margin: '10px' }}>Войти</button>
            </div>
            
        </div>
    )
}

export default Auth;