import React, { Component } from 'react';

import { Layout } from './components/Layout';
import './custom.css';
import { BrowserRouter } from "react-router-dom";
import { Routes } from './Routes';


export function App() {
  //static displayName = App.name;

   
  return (
      
          <BrowserRouter>
                <Routes />
            </BrowserRouter>
      
    );
  
}
