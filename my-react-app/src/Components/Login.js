import styled from "styled-components";

const Container = styled.div`
width: 100%;
height: !00%;
display:flex;
justify-content: center;
background color:black;
  
background-image: linear-gradient(to bottom right, #ffffff,#4C66F0);
  
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
color: #ffffff;
align-items: center;
justify-content: center;
display:flex;
`;
const User = styled.input`
width: 100%;
padding: 10px;
margin-top:20px;
border-color:transparent;
border-radius:15px

`;

const Button = styled.button`
background-color:transparent;
width: 22%;
align-items: center;
justify-content: center;
padding: 1px ;
margin-top:20px;
`;

const Link = styled.a`
positon: center;
padding: 20px 20px;
`;

const Login = () => {
    return (
        <Container  id = 'login' style={{
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            height: '100vh',
        }}>
            <Container2>
                <Heading><img src={require('../assets/logo.png')} height='70px' /><img src={require('../assets/login.png')} height=' 70px' /></Heading>
                <Web>
                    <User placeholder="Username" />
                    <User placeholder="Password" />
                    <button style={{ align: "center" }} className="btn btn-clear py-4" size='sm'><img src={require('../assets/log.png')} height=' 40px' /></button>
                    <Link style={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                    }}>Forgot Password</Link>
                </Web>
            </Container2>
        </Container>
    );
};

export default Login;