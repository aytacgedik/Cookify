import React, { useState, useEffect } from 'react';
import '../../App.css';
import axios from 'axios';
import RecipeCard from './RecipeCard'
export default function Recipes(props) {
  const [text, setText] = useState("")
  const [name, setName] = useState("")
  const [description, setDescription] = useState("")
  const [rating, setRating] = useState(0)
  const [tag, setTag] = useState("")
  const [cards, setCards] = useState([])
  const [ingredients, setIngredients] = useState([])
  const [creatorId, setCreatorId] = useState(13)
  
  const changeCreatorId = (e) => {
    setCreatorId(13)
  }
  const changeText = (e) => {
    setText(e.target.value)
  }
  const changeName = (e) => {
    setName(e.target.value)
  }
  const changeDesc = (e) => {
    setDescription(e.target.value)
  }
  const changeRating = (e) => {
    setRating(e.target.value)
  }
  const changeTag = (e) => {
    setTag(e.target.value)
  }
  const changeIngredient = (e) => {
    let arr = e.target.value.split(",")
    let list = []
    for(let i=0;i<arr.length;i++){
      list.push({"name":arr[i]})
    }
    console.log(list)
    setIngredients(list)
  }

  var axiosConfig = {
    headers: {
      "Access-Control-Allow-Origin": "*",
    },
    responseType: 'json'
  };
  const SearchCard = () => {
    axios.get('/api/recipes/search', { params: { query: text } },
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
      })
  }
  const GetCards = () => {
    axios.get('/api/recipes',
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
        console.log(res.data)
        
      })
  }
  const SendCard = () => {
    axios.post('/api/recipes', {
      "creatorId": creatorId,
      "name": name,
      "description": description,
      "rating":rating,
      "tag":tag,
      "ingredients":ingredients
    }).then(res => {
      console.log(res)
    });
  }

  return <div>
    <input type="text" onChange={(e) => changeText(e)} />
    <button className="button" onClick={SearchCard}>Search</button>
    <button className="button" onClick={GetCards}>Get All Recipes</button><br /><br />
    {props.store.getState().isLoggedIn && <div>
    <label >Name: </label>
    <input type="text" onChange={(e) => changeName(e)} /><br />
    <label >Description: </label>
    <input type="text" onChange={(e) => changeDesc(e)} /><br />
    <label >Rating: </label>
    <input type="number" onChange={(e) => changeRating(e)} /><br />
    <label >Tag: </label>
    <input type="text" onChange={(e) => changeTag(e)} /><br />
    <label >Ingredients: </label>
    <input type="text" onChange={(e) => changeIngredient(e)} /><br />
    <button className="button" onClick={SendCard}>Add recipe</button>
      </div>}
    
    <div>
      {cards && cards.map(card => <RecipeCard name={card.name} description={card.description} ingre={card.ingredients} rating={card.rating} tag={card.tag} />)}
    </div>
  </div>;
}