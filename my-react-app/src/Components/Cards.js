import React, { useState } from 'react'
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Accordion from 'react-bootstrap/Accordion';

export var cartItems = new Array();
var item = {};



function Cards() {
    //categories
    const fashion = 'fashion'
    const tech = 'tech'
    const trending = 'trending'

    // array of products
    const [products] = useState([
        {
            id: 1,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat',
            price: 23.99,
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 2,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item2.jpg')} />,
            title: 'CK Warm Jacket',
            price: 52.99,
            description: "Men's Hooded Down Jacket Quilted Coat Sherpa Lined"

        },
        {
            id: 3,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item3.jpg')} />,
            title: 'Flannel Plaid Jacket',
            price: 25.99,
            description: "Legendary Whitetails Men's Camp Night Berber Lined Hooded Flannel"

        },
        {
            id: 4,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item4.jpg')} />,
            title: 'EB Fleece Hoodie Sweat Shirt',
            price: 24.99,
            description: "Eddie Bauer Men's Camp Fleece Pullover Hoodie Soft comfortable material"

        },
        {
            id: 5,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item5.jpg')} />,
            title: 'Champion Black Hoodie',
            price: 32.99,
            description: "Champion Men's Pullover Hoodie, Powerblend Fleece Midweight Hooded Sweatshirt For Men"

        },
        {
            id: 6,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item6.jpg')} />,
            title: 'Carhartt classic Winter hat',
            price: 16.99,
            description: "A cold-weather Carhartt classic that's been keeping hardworking heads warm since 1987."

        },
        {
            id: 7,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item7.jpg')} />,
            title: 'Adidas Hat',
            price: 17.99,
            description: "Adidas Men's Ultra-Tech Cap"

        },
        {
            id: 8,
            inCart: 0,
            quantity: 0,
            category: fashion,
            image: <img variant='top' src={require('../assets/item8.jpg')} />,
            title: 'Adidas Jacket for men',
            price: 42.99,
            description: "adidas Men's Essentials Warm-Up 3-Stripes Track Top"

        },
        {
            id: 9,
            inCart: 0,
            quantity: 0,
            category: tech,
            image: <img variant='top' src={require('../assets/item9.jpg')} />,
            title: 'Amazon Fire 10 Plus',
            price: 115.99,
            description: "Fire HD 10 Plus tablet, 10.1, 1080p Full HD, 32 GB, latest model 2021 release"

        },
        {
            id: 10,
            inCart: 0,
            quantity: 0,
            category: tech,
            image: <img variant='top' src={require('../assets/item10.jpg')} />,
            title: 'Apple 11-inch iPad Pro',
            price: 744.99,
            description: "2022 Apple 11-inch iPad Pro (Wi-Fi, 128GB) - Space Gray (4th Generation)"

        },
        {
            id: 11,
            inCart: 0,
            quantity: 0,
            category: tech,
            image: <img variant='top' src={require('../assets/item11.jpg')} />,
            title: 'JBL BT Headphones',
            price: 25.99,
            description: "JBL Tune 510BT: Wireless On-Ear Headphones with Purebass Sound - Black"

        },
        {
            id: 12,
            inCart: 0,
            quantity: 0,
            category: tech,
            image: <img variant='top' src={require('../assets/item12.jpg')} />,
            title: 'LG 27 Inch monitor',
            price: 189.99,
            description: "LG FHD 27-Inch Computer Monitor 27MP450-B, IPS with AMD FreeSync, Black"

        },
        {
            id: 13,
            inCart: 0,
            quantity: 0,
            category: trending,
            image: <img variant='top' src={require('../assets/item13.jpg')} />,
            title: 'TBS 600 Headset',
            price: 72.99,
            description: "Turtle Beach Stealth 600 Gen 2 USB Wireless Amplified Gaming Headset "

        },
        {
            id: 14,
            inCart: 0,
            quantity: 0,
            category: trending,
            image: <img variant='top' src={require('../assets/item14.jpg')} />,
            title: 'HP Envy Inspire Printer',
            price: 96.99,
            description: "HP Envy Inspire 7955e Wireless Color All-in-One Printer with Bonus 6 Months Instant Ink with HP+"

        },
        {
            id: 15,
            inCart: 0,
            quantity: 0,
            category: trending,
            image: <img variant='top' src={require('../assets/item15.jpg')} />,
            title: 'TP-Link Deco Mesh WiFi System',
            price: 87.99,
            description: "TP-Link Deco Mesh WiFi System (Deco S4) – Up to 5,500 Sq.ft. Coverage"

        },
        {
            id: 16,
            inCart: 0,
            quantity: 0,
            category: trending,
            image: <img variant='top' src={require('../assets/item16.jpg')} />,
            title: 'EMEET 1080P HD Webcam C960',
            price: 22.99,
            description: "EMEET 1080P HD Webcam C960 Web Camera with Microphone, 90°POV PC Camera w/2 Noise-canceling Mics &Privacy Cover, Plug & Play"

        }

    ]);

    // adjusting quantity
    function inCart(product) {
        product.inCart = 1
        if (product.inCart != 0)
            product.quantity++
    }
    

    // filtering categories
    const fashionProd = []
    const techProd = []
    const trendingProd = []


    products.map(prod => {
        if (prod.category === fashion)
            return fashionProd.push(prod)
        if (prod.category === tech)
            return techProd.push(prod)
        if (prod.category === trending)
            return trendingProd.push(prod)
    })

    // adding to cart
    products.forEach(prod => {
        if (prod.inCart === 1 && !(cartItems.includes(prod))) { cartItems.push(prod) }
    })
    
    // rendering cards
    const renderProducts = (category, title) => (<>
        <h3 className='text-center py-4' id={title}>{title}</h3>
        <Row xs={4} md={4} className="g-4">

            {category.map((product) => (

                <Col className='products'>
                    <Card>
                        {product.image}
                        <Card.Body>
                            <Card.Title>{product.title}</Card.Title>
                            <h1 className='price'>${product.price}</h1>
                            <Accordion>
                                <Accordion.Header>Description</Accordion.Header>
                                <Accordion.Body>{product.description}</Accordion.Body>
                            </Accordion>
                        </Card.Body>
                        <button onClick={() => { inCart(product) }} className="btn btn-clear ms-2" >Add to Cart<img src={require("../assets/cart.png")} height='33px' /></button>
                    </Card>
                </Col>
            ))}
        </Row>
    </>)




    return (
        <div>
            {renderProducts(fashionProd, 'Fashion')}
            {renderProducts(techProd, 'Tech')}
            {renderProducts(trendingProd, 'Trending')}
        </div>

    );
}

export default Cards;
