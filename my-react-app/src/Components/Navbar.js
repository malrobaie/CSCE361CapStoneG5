import React, { useState } from 'react'

export default function Navbar() {

// bootstrap navbar, category filters, and page buttons
    return (
        <div id='home'>
            <nav class="navbar navbar-expand-lg">
                <div class="container">
                    <a class="navbar-brand fw-bold fs-4" href="#home"><img src={require("../assets/logo.png")} height='34px' /></a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="#home">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#Fashion">Fashion</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#Tech">Tech</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#Trending">Trending</a>
                            </li>

                        </ul>
                        <form class="d-flex" role="search">
                            <input class="form-control me-2 bg-light text-dark border-0" type="search" placeholder="Search for anything..." aria-label="Search" />
                            <button class="btn btn-clear" type="submit"><img src={require('../assets/search.png')} height='30' /></button>
                        </form>
                        <div className="buttons">
                            <a href="#login" className="btn btn-clear ms-2" >
                                <img src={require("../assets/login.png")} height='33px' /></a>

                            <a href='#cart' className="btn btn-clear ms-2">
                                <img src={require("../assets/cart.png")} height='33px' /></a>
                        </div>

                    </div>
                </div>
            </nav>
        </div>
    )
}