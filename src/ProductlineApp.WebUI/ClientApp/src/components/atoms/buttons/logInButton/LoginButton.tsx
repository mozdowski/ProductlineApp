import React from 'react';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/LoginButton.css';

function LoginButton() {
  return (
    <Link to="/dashboard" className="loginButtonLink" id="link">
      <div className="loginButton">
        <p>Zaloguj</p>
      </div>
    </Link>
  );
}

export default LoginButton;
