import React,{useState,useEffect} from 'react';
import '../../App.css';
import UserCard from './UserCard';
import axios from 'axios';

export default function Users() {
  const [cards,setCards] = useState([])
  useEffect(() => {
      axios.get('/api/users',
      {headers: {"Access-Control-Allow-Origin": "*"},
    responseType: 'json'})
      .then(res =>
        {
            setCards(res.data);
            console.log(res.data)
        })
  }, [])
  
  return cards.map(card =><UserCard name={card.name} surname={card.surname} email={card.email}/>);
}
