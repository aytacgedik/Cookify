import React from 'react';
import Navbar from './components/Navbar';
import './App.css';
import Home from './components/pages/Home';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Users from './components/pages/Users';
import Recipes from './components/pages/Recipes';
import Ingredients from './components/pages/Ingredients';
import SignUp from './components/pages/SignUp';
import SignIn from './components/pages/SignIn';
import {createStore} from 'redux';
import {Provider} from 'react-redux';
import loginReducer from './reducers/loginReducer';

const myStore = createStore(loginReducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());
function App() {
  return (
    <Provider store={myStore}>
      <Router>
        <Navbar />
        <Switch>
          <Route path='/' exact component={Home} />
          <Route path='/users' render={(props) => <Users store={myStore} {...props} /> } />  
          <Route path='/recipes' render={(props) => <Recipes store={myStore} {...props} /> } />
          <Route path='/ingredients' render={(props) => <Ingredients store={myStore} {...props} /> } />
          <Route path='/sign-up' component={SignUp} />
          <Route path='/sign-in' component={SignIn} />
        </Switch>
      </Router>
    </Provider>
  );
}

export default App;
