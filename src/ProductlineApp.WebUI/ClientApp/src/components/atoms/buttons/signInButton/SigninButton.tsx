import React from "react";
import { Link, useMatch, useResolvedPath } from "react-router-dom";
import './css/SigninButton.css';

function SigninButton() {
    return (
        <Link to="/login" className="signinButtonLink" id="link">
            <input type="submit" className="signinButton" value="Zarejestruj"></input>
        </Link>
    );
}

export default SigninButton