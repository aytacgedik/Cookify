import React from 'react';

const IngredientStyle = {
    "boxShadow": "0 4px 8px 0 rgba(0,0,0,0.2)",
    "transition": "0.3s",
    "width": "20%",
    "margin":"0 auto 10px"
}  
const container ={"padding":"2px 16px"}

// function changeBackground(e) {
//     e.target.style.boxShadow = "0 8px 16px 0 rgba(0,0,0,0.2)";
//   }

const IngredientCard = (props) => {
    return (
        <div style={IngredientStyle}><img src='https://assets.materialup.com/uploads/b03b23aa-aa69-4657-aa5e-fa5fef2c76e8/preview.png' alt="ingredient" style={{ width: '100%' }} />
            <div stlye={container}>
                <h4 style={{"text-align": "center"}}><b>{props.name}</b></h4>
            </div>
        </div>
    );
}

export default IngredientCard
