import React, {useState, useEffect} from 'react';
import '../../App.css';
import axios from 'axios';

export default function Users() {
  const [data, setData] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get(`https://cookify.azurewebsites.net/api/users`);
      setData(result.data);
    }
    fetchData();
    
  }, []);

  if (data) {
    return (
        <ul className='sign-up'>
          {console.log(data)}
          {data.map((user, i) => {return <li key={i + 1}> Cook nr {i + 1} : {user.name} {user.surname}</li> })}      
        </ul>
      );
    } else {
      return (
        <ul>
        </ul>
      )
    }
 
}
