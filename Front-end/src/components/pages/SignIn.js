import React, { Component } from "react";
import '../../index.css'
import '../../App.css'
import  './SignInUp.css'
export default class SignIn extends Component {
    render() {
        return (
            <div className="auth-wrapper">
            <div className="auth-inner">
            <form>
                
                <h3>Sign In</h3>

                <div className="cookify-form-group">
                    <label>Email address</label>
                    <input type="email" className="cookify-form-control" placeholder="Enter email" />
                </div>

                <div className="cookify-form-group">
                    <label>Password</label>
                    <input type="password" className="cookify-form-control" placeholder="Enter password" />
                </div>

                <div className="cookify-form-group cookify-form-check">
                    <input type="checkbox" className="cookify-form-check-input" id="customCheck1" />
                    <label className="cookify-form-check-label" htmlFor="customCheck1">Remember me</label>
                </div>

                <button type="submit" className="cookify-btn cookify-btn-primary cookify-btn-block">Submit</button>
                <p className="forgot-password text-right">
                    Forgot <a href="#">password?</a>
                </p>
            </form>
            </div>
            </div>
        );
    }
}