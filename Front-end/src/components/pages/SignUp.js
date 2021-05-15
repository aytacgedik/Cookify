import React, { Component } from "react";
import '../../index.css'
import '../../App.css'
import './SignInUp.css'
export default class SignUp extends Component {
    render() {
        return (
            <div className="auth-wrapper">
            <div className="auth-inner">
            <form>
                <h3>Sign Up</h3>

                <div className="cookify-form-group">
                    <label>First name</label>
                    <input type="text" className="cookify-form-control" placeholder="First name" />
                </div>

                <div className="cookify-form-group">
                    <label>Last name</label>
                    <input type="text" className="cookify-form-control" placeholder="Last name" />
                </div>

                <div className="cookify-form-group">
                    <label>Email address</label>
                    <input type="email" className="cookify-form-control" placeholder="Enter email" />
                </div>

                <div className="cookify-form-group">
                    <label>Password</label>
                    <input type="password" className="cookify-form-control" placeholder="Enter password" />
                </div>

                <button type="submit" className="cookify-btn cookify-btn-primary cookify-btn-block">Sign Up</button>
                <p className="forgot-password text-right">
                    Already registered <a href="/sign-in">sign in?</a>
                </p>
            </form>
            </div>
            </div>
        );
    }
}