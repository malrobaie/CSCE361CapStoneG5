import React, { useState } from 'react';
import './App.css';
import Navbar from './Components/Navbar';
import Carousel from './Components/Carousel';
import Cards from './Components/Cards';
import Login from './Components/Login'
import Cart from './Components/Cart';

export default function App() {
    return (
        <>
            <Navbar />
            <Carousel />
            <Cards />
            <Login />
            <Cart />
        </>
    );
}