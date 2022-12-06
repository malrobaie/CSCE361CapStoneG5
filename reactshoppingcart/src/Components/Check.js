import styled from "styled-components";
import React from "react";

const Container = styled.div`
width: 100%;
height: !00%;
display:flex;
justify-content: center;
background color:black;
  
background-image: linear-gradient(to top , #4C66F0, #ffffff);
  
background-position: center;
width: 100%;
height: 100%;
background-repeat:no-repeat;
`;
const Container2 = styled.div`
width: 55%;
padding: 80px;
justify-content: center;
background color:black;
`;
const Web = styled.form`
display: flex;
flex-direction: column;
justify-content: center;
`;
const Heading = styled.h1`
font-size: 17px;
color: grey;
align-items: center;
justify-content: left;
display:flex;
padding:10px
`;
const User = styled.input`
width: 100%;
padding: 10px;
margin-top:20px;
border-color:transparent;
border-radius:15px

`;
const Button = styled.button`
background-color:#4C66F0;
width: 22%;
align-items: center;
justify-content: center;
padding: 1px ;
margin-top:20px;
`;
const Check = () => {
    return (
        <Container>
            <Container2>
            <Heading>Enter Payment Information</Heading>
                <img src={require('../assets/payment.png')} height= '60'/>
                <Web>
                    <User placeholder="Card Number" />
                    <User placeholder="mm/dd/yyyy" />
                    <User placeholder="CVV" />
                    <Heading>Enter Promo code</Heading>
                    <User placeholder="Promotion Code" />
                    <Heading>Enter Delivery Address</Heading>
                    <User placeholder="Street Address" />
                    <User placeholder="City" />
                    <User placeholder="State" />
                    <User placeholder="Zipcode" />
                    <button style={{ align: "center" }} className="btn btn-white py-4" size='sm'><img src={require('../assets/checkout.png')} height='90' /></button>
                </Web>
            </Container2>
        </Container>
    );
};

export default Check;