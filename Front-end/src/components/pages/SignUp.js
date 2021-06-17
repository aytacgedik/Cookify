import React, { Component,useState } from "react";
import '../../index.css'
import '../../App.css'
import './SignInUp.css'
import axios from 'axios';


var id =0;
var name ="";
var surname ="";
var email ="";
var registered =false;


var axiosConfig = {
    headers: {
        "Access-Control-Allow-Origin" : "*",
    },
    responseType : 'json'
};
const SendCard = () => {
    console.log(name)
    axios.post('/api/users', {
      "id":Math.floor(Math.random() * 10000),
      "name": name,
      "surname": surname,
      "email":email,
      "verified":true,
      "admin":true
    },axiosConfig).then(res => {
      console.log(res)
      registered = true;
    });
    
  }

export default class SignUp extends Component {
    render() {
        
        return (
            <div className="auth-wrapper">
            <div className="auth-inner">
            <h3>Sign Up</h3>
                <div className="cookify-form-group">
                    <label>First name</label>
                    <input type="text" id="fname" onChange={(e) => name=e.target.value} className="cookify-form-control" placeholder="First name" />
                </div>

                <div className="cookify-form-group">
                    <label>Last name</label>
                    <input type="text" id="lname" onChange={(e) => surname=e.target.value} className="cookify-form-control" placeholder="Last name" />
                </div>

                <div className="cookify-form-group">
                    <label>Email address</label>
                    <input type="email" id="email" onChange={(e) => email=e.target.value} className="cookify-form-control" placeholder="Enter email" />
                </div>

                <div className="cookify-form-group">
                    <label>Password</label>
                    <input type="password" id="password" className="cookify-form-control" placeholder="Enter password" />
                </div>

                <button type="submit" onClick={(SendCard)} className="cookify-btn cookify-btn-primary cookify-btn-block">Sign Up</button>
                <p className="forgot-password text-right">
                    Already registered <a href="/sign-in">sign in?</a>
                </p>
            </div>
            </div>
        );
    }
}