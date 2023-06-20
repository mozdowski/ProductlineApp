import React from "react";
import { Link, useMatch, useResolvedPath } from "react-router-dom";
import './css/LoginButton.css';

function LoginButton() {
    return (
        <Link to="/dashboard" className="loginButtonLink" id="link">
            <input type="submit" className="loginButton" value="Zaloguj" />
        </Link>
    );
}

export default LoginButton