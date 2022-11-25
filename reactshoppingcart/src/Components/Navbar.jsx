import React from 'react'

export default function Navbar() {
    return (
        <div>
            <nav class="navbar navbar-expand-lg bg-light">
                <div class="container">
                    <a class="navbar-brand fw-bold fs-4" href="#"><span>e</span>cart</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="#">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Fashion</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Tech</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Trending</a>
                            </li>

                        </ul>
                        <form class="d-flex" role="search">
                            <input class="form-control me-2" type="search" placeholder="Search for anything..." aria-label="Search" />
                            <button class="btn btn-outline-success" type="submit">Search</button>
                        </form>
                        <div className="buttons">
                            <a href="" className="btn btn-outline-dark ms-2">
                                <i className="fa fa sign-in me-1"></i> Login</a>
                            <a href="" className="btn btn-outline-dark ms-2">
                                <i className="fa fa sign-in me-1"></i> Register</a>
                            <a href="" className="btn btn-outline-dark ms-2">
                                <i className="fa fa sign-in ms-1"></i> Cart (0)</a>
                        </div>
                    </div>
                </div>
            </nav>
        </div>
    )
}
