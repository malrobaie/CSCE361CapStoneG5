import React, { useState } from 'react';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Accordion from 'react-bootstrap/Accordion';
import { cartItems } from './Cards'



const Cart = () => {
    var total = 0

    // displaying total items and price+tax
    const isEmpty = (cart) => {
        cart.forEach(prod => {
            total += prod.quantity*(prod.price + .0725*prod.price)  ;  
            });
        return (cart.length === 0) ? 'Your Cart is Empty ' : 'Cart Items' + ' (' + cart.length + ') '+' Total: $'+ total.toFixed(2)
    }

    // rendering cart item cards
    const renderCart = () => (
        <>
            <h3 className='text-center py-4'><img src={require('../assets/cart.png')} height='36' />{isEmpty(cartItems)}</h3>
            <Row xs={4} md={4} className="g-4">

                {cartItems.map((product) => (

                    <Col >
                        <Card >
                            {product.image}
                            <Card.Body>
                                <Card.Title>{product.title}</Card.Title>
                                <Card.Subtitle>Quantity: {product.quantity}</Card.Subtitle>
                                <h1 className='price'>${product.price}</h1>
                                <Accordion>
                                    <Accordion.Header>Description</Accordion.Header>
                                    <Accordion.Body>{product.description}</Accordion.Body>
                                </Accordion>
                            </Card.Body>
                            <button onClick={() => product.inCart = 0} className="btn btn-clear ms-2"><img src={require("../assets/remove.png")} height='50px' /></button>
                        </Card>
                    </Col>
                ))}
            </Row>
        </>
    )

    return (
        <div id='cart'>
            {renderCart()}
        </div>

    )
}

export default Cart