import React, { useState } from "react";
import '../../index.css'
import '../../App.css'
import  './SignInUp.css'
import axios from 'axios'
import {connect} from 'react-redux';
import {logIn} from '../../actions/logInOut';

const mapStateToProps = (state) => {
    return {
        isLoggedIn: state.isLoggedIn
    }
}

const mapDispatchToProps = (dispatch) => ({
    logIn: () => dispatch(logIn)
});

const SignIn = (props) => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    function handleEmailChange(e) {
        setEmail(e.target.value);
    }
    function handlePasswordChange(e) {
        setPassword(e.target.value);
    }

    function handleSubmit(e) {
        e.preventDefault();
        
        var postData = {
            "email": email
        };
        var axiosConfig = {
            headers: {
                "Access-Control-Allow-Origin" : "*",
            },
            responseType : 'json'
        };
        const authenticate = async () => {
            const result = await axios.post(`/api/sessions`, postData, axiosConfig);
            if (result.statusText === "OK") {
                props.logIn();
            }
        }
        authenticate();
    }
    return (
        <div className="auth-wrapper">
        <div className="auth-inner">
        <form>
            
            <h3>Sign In</h3>

            <div className="cookify-form-group">
                <label>Email address</label>
                <input type="email" className="cookify-form-control" placeholder="Enter email" onChange={handleEmailChange} />
            </div>

            <div className="cookify-form-group">
                <label>Password</label>
                <input type="password" className="cookify-form-control" placeholder="Enter password" onChange={handlePasswordChange} />
            </div>

            <div className="cookify-form-group cookify-form-check">
                <input type="checkbox" className="cookify-form-check-input" id="customCheck1" />
                <label className="cookify-form-check-label" htmlFor="customCheck1">Remember me</label>
            </div>

            <button type="submit" className="cookify-btn cookify-btn-primary cookify-btn-block" onClick={handleSubmit}>Submit</button>
            <p className="forgot-password text-right">
                Forgot <a href="#">password?</a>
            </p>
            {props.isLoggedIn && "Logged in"}
        </form>
        </div>
        </div>
    );
}

export default connect(mapStateToProps, mapDispatchToProps)(SignIn);