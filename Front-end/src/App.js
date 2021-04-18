import React from 'react';
import Navbar from './components/Navbar';
import './App.css';
import Home from './components/pages/Home';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Users from './components/pages/Users';
import Recipes from './components/pages/Recipes';
import Ingredients from './components/pages/Ingredients';
import SignUp from './components/pages/SignUp';

function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/' exact component={Home} />
          <Route path='/users' component={Users} />
          <Route path='/recipes' component={Recipes} />
          <Route path='/ingredients' component={Ingredients} />
          <Route path='/sign-up' component={SignUp} />
        </Switch>
      </Router>
    </>
  );
}

export default App;
