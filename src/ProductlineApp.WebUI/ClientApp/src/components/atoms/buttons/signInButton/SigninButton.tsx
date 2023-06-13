import React from 'react';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/SigninButton.css';

function SigninButton() {
  return (
    <Link to="/login" className="signinButtonLink" id="link">
      <div className="signinButton">
        <p>Zarejestruj</p>
      </div>
    </Link>
  );
}

export default SigninButton;
