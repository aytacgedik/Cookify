import React,{useState} from 'react';
import '../../App.css';
import UserCard from './UserCard';
import axios from 'axios';

export default function Users() {
 
  const [text, setText] = useState("")
  const [id, setId] = useState("")
  const [name, setName] = useState("")
  const [surname, setSurname] = useState("")
  const [email, setEmail] = useState("")
  const [verified, setVerified] = useState(false)
  const [admin, setAdmin] = useState(false)
  const [cards, setCards] = useState([])

  const changeText = (e) => {
    setText(e.target.value)
  }
  const changeId = (e) => {
    setId(e.target.value)
  }
  const changeName = (e) => {
    setName(e.target.value)
  }
  const changeSurname = (e) => {
    setSurname(e.target.value)
  }
  const changeEmail = (e) => {
    setEmail(e.target.value)
  }
  const changeVerified = (e) => {
    setVerified(!verified)
    
  }
  const changeAdmin = (e) => {
    setAdmin(!admin)
  }

  const GetCards = () => {
    axios.get('/api/users',
      {
        headers: { "Access-Control-Allow-Origin": "*" },
        responseType: 'json'
      })
      .then(res => {
        setCards(res.data);
      })
  }
  var axiosConfig = {
    headers: {
        "Access-Control-Allow-Origin" : "*",
    },
    responseType : 'json'
};
  const SendCard = () => {
    axios.post('/api/users', {
      "id":id,
      "name": name,
      "surname": surname,
      "email":email,
      "verified":verified,
      "admin":admin
    },axiosConfig).then(res => {
      console.log(res)
      
    });
    
  }
  return <div>
    <button className="button" onClick={GetCards}>Get All Cooks</button><br /><br />
    <label for="male">Id: </label>
    <input type="number" onChange={(e) => changeId(e)} /><br />
    <label for="male">Name: </label>
    <input type="text" onChange={(e) => changeName(e)} /><br />
    <label for="male">Surname: </label>
    <input type="text" onChange={(e) => changeSurname(e)} /><br />
    <label for="male">Email: </label>
    <input type="mail" onChange={(e) => changeEmail(e)} /><br />
    <label for="male">Verified: </label>
    <input type="checkbox" onChange={(e) => changeVerified(e)} /><br />
    <label for="male">Admin: </label>
    <input type="checkbox" onChange={(e) => changeAdmin(e)} /><br />
    <button className="button" onClick={SendCard}>Add recipe</button>
    <div>
      {cards && cards.map(card =><UserCard name={card.name} surname={card.surname} email={card.email}/>)}
    </div>
  </div>;
}
