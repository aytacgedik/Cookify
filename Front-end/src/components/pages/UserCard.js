import React from 'react';

const cardStyle = {
    "boxShadow": "0 4px 8px 0 rgba(0,0,0,0.2)",
    "transition": "0.3s",
    "width": "20%",
    "margin":"0 auto 10px"
}  
const container ={"padding":"2px 16px"}


const UserCard = (props) => {
    return (
        <div style={cardStyle}><img src="https://www.w3schools.com/howto/img_avatar.png" alt="Avatar" style={{ width: '100%' }} />
            <div stlye={container}>
                <h4 style={{"text-align": "center"}}><b>{props.name} {props.surname}</b></h4>
                <p style={{"text-align": "center"}}>{props.email}</p>
            </div>
        </div>
    );
}

export default UserCard
