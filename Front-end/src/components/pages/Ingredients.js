import React, { useState, useEffect } from 'react';
import '../../App.css';
import axios from 'axios';
import IngredientCard from './IngredientCard'
export default function Ingredients() {
  const [text, setText] = useState("")
  const [cards, setCards] = useState([])

  const changeText = (e) => {
    setText(e.target.value)
  }
  

  var axiosConfig = {
    headers: {
      "Access-Control-Allow-Origin": "*",
    },
    responseType: 'json'
  };
  const SearchCard = () => {
    axios.get("/api/ingredients/search", { params: { query: text } },
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
      })
  }
  const GetCards = () => {
    axios.get('/api/ingredient',
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
      })
  }

  return <div>
    <input type="text" onChange={(e) => changeText(e)} />
    <button className="button" onClick={SearchCard}>Search</button>
    <button className="button" onClick={GetCards}>Get All Ingredient</button><br /><br />
    <div>
      {cards.map(card => <IngredientCard name={card.name} />)}
    </div>
  </div>;
}

