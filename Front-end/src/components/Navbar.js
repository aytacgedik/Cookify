import React, { useState, useEffect } from 'react';
import { SignInButton } from './SignInButton';
import { SignUpButton } from './SignUpButton';
import { Link } from 'react-router-dom';
import './Navbar.css';

function Navbar() {
  const [click, setClick] = useState(false);
  const [button, setButton] = useState(true);

  const handleClick = () => setClick(!click);
  const closeMobileMenu = () => setClick(false);

  const showButton = () => {
    if (window.innerWidth <= 960) {
      setButton(false);
    } else {
      setButton(true);
    }
  };

  useEffect(() => {
    showButton();
  }, []);

  window.addEventListener('resize', showButton);

  return (
    <>
      <nav className='navbar'>
        <div className='navbar-container'>
          <Link to='/' className='navbar-logo' onClick={closeMobileMenu}>
            COOKIFY
            <i class="fas fa-cheese"></i>
          </Link>
          <div className='menu-icon' onClick={handleClick}>
            <i className={click ? 'fas fa-times' : 'fas fa-bars'} />
          </div>
          <ul className={click ? 'nav-menu active' : 'nav-menu'}>
            <li className='nav-item'>
              <Link to='/' className='nav-links' onClick={closeMobileMenu}>
                Home
              </Link>
            </li>
            <li className='nav-item'>
              <Link
                to='/recipes'
                className='nav-links'
                onClick={closeMobileMenu}
              >
                Recipes
              </Link>
            </li>
            <li className='nav-item'>
              <Link
                to='/ingredients'
                className='nav-links'
                onClick={closeMobileMenu}
              >
                Ingredients
              </Link>
            </li>
            <li className='nav-item'>
              <Link
                to='/users'
                className='nav-links'
                onClick={closeMobileMenu}
              >
                Cooks
              </Link>
            </li>

            <li>
              <Link
                to='/sign-up'
                className='nav-links-mobile'
                onClick={closeMobileMenu}
              >
                Sign Up
              </Link>
            </li>
          </ul>
          {button && <SignUpButton buttonStyle='btn--outline'>SIGN UP</SignUpButton>}
          {button && <SignInButton buttonStyle='btn--outline'>SIGN IN</SignInButton>}
        </div>
      </nav>
    </>
  );
}

export default Navbar;
