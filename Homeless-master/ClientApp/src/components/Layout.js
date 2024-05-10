import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Outlet } from "react-router-dom";

interface LayoutProps extends React.PropsWithChildren { }

export function Layout(props: LayoutProps) {

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
        return cookie ? cookie.split('=')[1] : null;
    }

    const isAuthenticated = isAuthentificated();

    return !isAuthenticated ? (<div>
            <Outlet />
    </div>): (
        <div>
        <NavMenu />
        < Container >
        <Outlet />
        </Container >
      </div >
    );
  
}
