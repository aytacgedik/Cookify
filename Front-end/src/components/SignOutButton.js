import React from 'react';
import './SignUpButton.css';
import { Link } from 'react-router-dom';
import {logOut} from '../actions/logInOut';
import {connect} from 'react-redux';

const STYLES = ['btn--primary', 'btn--outline', 'btn--test'];

const SIZES = ['btn--medium', 'btn--large'];

const mapStateToProps = (state) => {
    return {
        isLoggedIn: state.isLoggedIn
    }
}

const mapDispatchToProps = (dispatch) => ({
    logOut: () => dispatch(logOut)
});

const SignOutButton = (props) => {
  const checkButtonStyle = STYLES.includes(props.buttonStyle)
    ? props.buttonStyle
    : STYLES[0];

  const checkButtonSize = SIZES.includes(props.buttonSize) ? props.buttonSize : SIZES[0];
  
  const handleClick = () => {
      props.logOut();
  }
  return (
    <Link to='/sign-in' className='btn-mobile'>
      <button
        className={`btn ${checkButtonStyle} ${checkButtonSize}`}
        onClick={handleClick}
        type={props.type}
      >
        {props.children}
      </button>
    </Link>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(SignOutButton);

