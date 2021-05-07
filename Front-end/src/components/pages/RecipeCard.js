import React from 'react';

const recipeStyle = {
    "boxShadow": "0 4px 8px 0 rgba(0,0,0,0.2)",
    "transition": "0.3s",
    "width": "20%",
    "margin":"0 auto 10px"
}  
const container ={"padding":"2px 16px"}

const RecipeCard = (props) => {
    return (
        <div style={recipeStyle}><img src='https://p.kindpng.com/picc/s/79-798754_hoteles-y-centros-vacacionales-dish-placeholder-hd-png.png' alt="ingredient" style={{ width: '100%' }} />
            <div stlye={container}>
                <h4 style={{"text-align": "center"}}><b>{props.name}</b></h4>
                <p style={{"text-align": "center"}}>{props.description}</p>
                <p style={{"text-align": "center"}}>{props.rating}</p>
                <p style={{"text-align": "center"}}>{props.tag}</p>
            </div>
        </div>
    );
}

export default RecipeCard
