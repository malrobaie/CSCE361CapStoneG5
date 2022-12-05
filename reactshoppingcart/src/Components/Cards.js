import React, { useState } from 'react'
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Accordion from 'react-bootstrap/Accordion';
export var cartItems = []


function Cards() {
    //categories
    const fashion = 'fashion'
    const tech = 'tech'
    const trending = 'trending'




    const [products] = useState([
        {
            id: 1,
            category: fashion,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat1',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: fashion,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat2',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: fashion,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat3',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: fashion,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat4',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: tech,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat5',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: tech,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat6',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: trending,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat7',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        },
        {
            id: 1,
            category: trending,
            image: <img variant='top' src={require('../assets/item1.jpg')} />,
            title: 'Nike Hat8',
            price: '$40',
            description: 'Personalized Comfort. The Nike Sportswear Pro adjustable cap sports a classic six-panel design and press-on back for a personalized fit and Comfort'

        }

    ]);

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
    
    const addToCart = (product) => {
        cartItems.push(product)
    }

    useState(cartItems)

    return (
        <div>

            <h3 className='text-center py-4' id='fashion'>Fashion</h3>
            <Row xs={4} md={4} className="g-4">

                {fashionProd.map((product) => (

                    <Col className='products'>
                        <Card>
                            {product.image}
                            <Card.Body>
                                <Card.Title>{product.title}</Card.Title>
                                <h1 className='price'>{product.price}</h1>
                                <Accordion>
                                    <Accordion.Header>Description</Accordion.Header>
                                    <Accordion.Body>{product.description}</Accordion.Body>
                                </Accordion>
                            </Card.Body>
                            <Card.Footer>
                                <button onClick={() => addToCart(product)} className="btn btn-clear ms-2" >Add to Cart<img src={require("../assets/cart.png")} height='33px' /></button>
                            </Card.Footer>
                        </Card>
                    </Col>
                ))}
            </Row>

            <h3 className='text-center py-4' id='tech'>Tech</h3>
            <Row xs={4} md={4} className="g-4">

                {techProd.map((product) => (

                    <Col>
                        <Card>
                            {product.image}
                            <Card.Body>
                                <Card.Title>{product.title}</Card.Title>
                                <h1 className='price'>{product.price}</h1>
                                <Accordion>
                                    <Accordion.Header>Description</Accordion.Header>
                                    <Accordion.Body>{product.description}</Accordion.Body>
                                </Accordion>
                            </Card.Body>
                            <Card.Footer>
                                <button onClick={() => addToCart(product)} className="btn btn-clear ms-2" >Add to Cart<img src={require("../assets/cart.png")} height='33px' /></button>
                            </Card.Footer>
                        </Card>
                    </Col>
                ))}
            </Row>

            <h3 className='text-center py-4' id='trending'>Trending</h3>
            <Row xs={4} md={4} className="g-4">

                {trendingProd.map((product) => (

                    <Col>
                        <Card>
                            {product.image}
                            <Card.Body>
                                <Card.Title>{product.title}</Card.Title>
                                <h1 className='price'>{product.price}</h1>
                                <Accordion>
                                    <Accordion.Header>Description</Accordion.Header>
                                    <Accordion.Body>{product.description}</Accordion.Body>
                                </Accordion>
                            </Card.Body>
                            <Card.Footer>
                                <button onClick={() => addToCart(product)} className="btn btn-clear ms-2" >Add to Cart<img src={require("../assets/cart.png")} height='33px' /></button>
                            </Card.Footer>
                        </Card>
                    </Col>
                ))}
            </Row>

        </div>

    );
}

export default Cards;
