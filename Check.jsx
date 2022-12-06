import styled from "styled-components";
import React from "react";
const Container = styled.div`
width: 100%;
height: !00%;
display:flex;
justify-content: center;
background color:black;
  
background-image: url(https://github.com/malrobaie/CSCE361CapStoneG5/blob/main/reactshoppingcart/public/logo512.png?raw=true);
  
background-position: center;
width: 100%;
height: 100%;
background-repeat:no-repeat;
`;
const Container2 = styled.div`
width: 75%;
height:75%;
height:90%;
padding: 20px;
justify-conten:center;
background color:black;

`;
const Web = styled.form`
display: flex;
flex-direction: column;
justify-content: center;
`;
const Heading = styled.h1`
font-size: 14px;
align-items: center;
justify-content:left;
display:flex;
margin-top:5px;
`;
const User = styled.input`
width: 50%;
padding: 10px;
margin-top:20px;
`;
const Button = styled.button`
background-color:transparent;
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
<Web>
<User placeholder="card number"/>
<User placeholder="mm/dd/yyyy"/>
<User placeholder="cvv"/>
<Heading>Enter Promo code(if any)</Heading>
<User placeholder="Promotion code"/>
<Heading>Enter Delivery Address</Heading>
<User placeholder="street address"/>
<User placeholder="city"/>
<User placeholder="state"/>
<User placeholder="zipcode"/>
<Button>Check out and Pay</Button>
</Web>
</Container2>
</Container>
);
};

export default Check;