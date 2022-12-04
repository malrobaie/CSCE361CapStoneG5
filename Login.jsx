import styled from "styled-components";
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
font-size: 130px;
align-items: center;
justify-content: center;
display:flex;
`;
const User = styled.input`
width: 100%;
padding: 10px;
margin-top:20px;
`;
const Link = styled.a`
padding: 20px 20px;
`;
const Button = styled.button`
background-color:white;
color: black;
width: 50%;
justify-content: center;
padding: 20px 20px;
margin-top:20px;
`;
const Login = () => {
return (
<Container>
<Container2>
<Heading>LOGIN</Heading>
<Web>
<User placeholder="LoginId"/>
<User placeholder="password"/>
<Button>LOGIN</Button>
<Link>Forgot Password</Link>
</Web>
</Container2>
</Container>
);
};

export default Login;