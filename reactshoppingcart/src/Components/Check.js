import styled from "styled-components";

const Container = styled.div`
width: 100%;
height: !00%;
display:flex;
justify-content: center;
background color:black;
  
background-image: linear-gradient( #f5f5f5);
  
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
font-size: 19px;
color: #1E2D7B;
font-family: system-ui;
align-items: center;
justify-content: left;
display:flex;
padding:10px
`;
const User = styled.input`
background-color: #e8f0fc;
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
                <img src={require('../assets/payment.png')} height='60' />
                <Web className="pay">
                    <User className="pay" placeholder="Card Number" />
                    <User className="pay" placeholder="mm/dd/yyyy" />
                    <User className="pay" placeholder="CVV" />
                    <Heading>Enter Promo code</Heading>
                    <User className="pay" placeholder="Promotion Code" />
                    <Heading>Enter Delivery Address</Heading>
                    <User className="pay" placeholder="Street Address" />
                    <User className="pay" placeholder="City" />
                    <User className="pay" placeholder="State" />
                    <User className="pay" placeholder="Zipcode" />
                    <button style={{ align: "center" }} className="btn btn-white py-4" size='sm'><img src={require('../assets/checkout.png')} height='90' /></button>
                </Web>
            </Container2>
        </Container>
    );
};

export default Check;