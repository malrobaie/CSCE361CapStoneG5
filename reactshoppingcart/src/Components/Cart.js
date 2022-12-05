import React, {useState} from 'react';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Accordion from 'react-bootstrap/Accordion';
import {cartItems} from './Cards'



const Cart = () => {
    
    const isEmpty = (cart) => {
        return (cart.length === 0 ) ? 'Your Cart is Empty ' : 'Cart Items'+' ('+cart.length+') '
    }
    
    
    
  return (
    
        <div id='cart' className='container-fluid'> 
            <h3 className='text-center py-4' id='fashion'>{isEmpty(cartItems)}<img src = {require('../assets/cart.png')} height='36'/></h3>
            <Row xs={4} md={4} className="g-4">

                {cartItems.map((product) => (

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
                            </Card.Footer>
                        </Card>
                    </Col>
                ))}
            </Row>
        </div>
  )
}

export default Cart