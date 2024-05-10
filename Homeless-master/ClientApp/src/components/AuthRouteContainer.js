import React, { useEffect, useState } from "react";
import { Navigate, Outlet } from "react-router-dom";

const URL = "/api/authenticate";

const AuthRouteContainer = () => {

    function isAuthentificated() {
        const token = getCookie("token");
        if (token !== undefined && token !== null && token !== "") {
            return true;
        }
        else {
            return false;
        }

    }

    function getCookie(name) {
        let cookie = document.cookie.split('; ').find(row => row.startsWith(name + '='));
        let cookieContent = document.cookie.split('; ');
        return cookie ? cookie.split('=')[1] : null;
    }

    
    if (!isAuthentificated()) {
        return <Navigate to={'/authenticate'} replace />;
    }
    
    return (
        <React.Fragment>
            <Outlet />
        </React.Fragment>
    );
}

export default AuthRouteContainer;