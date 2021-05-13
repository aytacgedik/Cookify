import React, {useState, useEffect} from 'react';
import '../../App.css';
import axios from 'axios';

export default function Recipes() {
  const [data, setData] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get(`https://cookify.azurewebsites.net/api/recipes`);
      setData(result.data);
    }
    fetchData();

  }, []);

  if (data) {
    return (
      <ul className='recipes'>
        {data.map((recipe, i) => {return <li key={i + 1}> Recipe nr {i + 1} :<br/> {recipe.name}<br/> {recipe.description}</li> })}      
      </ul>
      );
    } else {
      return (
        <ul>

        </ul>
      )
    }
}
