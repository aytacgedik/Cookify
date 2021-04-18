import React from 'react';
import './Cards.css';
import CardItem from './CardItem';

function Cards() {
  return (
    <div className='cards'>
      <h1>Check out these EPIC Recipes!</h1>
      <div className='cards__container'>
        <div className='cards__wrapper'>
          <ul className='cards__items'>
            <CardItem
              src='images/img-9.jpg'
              text='Glazed Cinnamon-Cardamom Buns'
              label='Desert'
              path='/recipes'
            />
            <CardItem
              src='images/img-2.jpg'
              text='Pizza Night!'
              label='Pizza'
              path='/recipes'
            />
          </ul>
          <ul className='cards__items'>
            <CardItem
              src='images/img-3.jpg'
              text='Drunken Aussie Beef'
              label='Burger'
              path='/recipe'
            />
            <CardItem
              src='images/img-4.jpg'
              text='Bolognese'
              label='Pasta'
              path='/recipes'
            />
            <CardItem
              src='images/img-8.jpg'
              text='Choose your ingredients and start cooking!'
              label='Ingredients'
              path='/ingredients'
            />
          </ul>
        </div>
      </div>
    </div>
  );
}

export default Cards;
