import React, { useState, useEffect } from 'react';
import '../../App.css';
import axios from 'axios';
import IngredientCard from './IngredientCard'
export default function Ingredients() {
  const [cards, setCards] = useState([])
  useEffect(() => {
    axios.get('/api/ingredient',
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
      })
  }, [])

  return cards.map(card => <IngredientCard name={card.name} />);
}

