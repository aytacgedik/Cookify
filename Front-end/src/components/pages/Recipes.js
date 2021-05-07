import React,{useState,useEffect} from 'react';
import '../../App.css';
import axios from 'axios';
import RecipeCard from './RecipeCard'
export default function Recipes() {
  const [cards,setCards] = useState([])
  useEffect(() => {
      axios.get('/api/recipes',
      {headers: {"Access-Control-Allow-Origin": "*"},
    responseType: 'json'})
      .then(res =>
        {
            setCards(res.data);
        })
  }, [])
  
  return cards.map(card =><RecipeCard name={card.name} description={card.description} rating={card.rating} tag={card.tag}/>);
}