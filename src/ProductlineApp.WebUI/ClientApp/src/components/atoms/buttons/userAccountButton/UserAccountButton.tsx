import React from 'react';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/UserAccountButton.css';

function UserAccountButton() {
  return (
    <div className="userAccountButton">
      <div className="userInfo">
        <h2>Jan Kowalski</h2>
        <p>jankowalski@gmal.com</p>
      </div>
      <Link to="/settings" className="goToAccountSettingsLink" id="link">
        <div className="userImage"></div>
      </Link>
    </div>
  );
}

export default UserAccountButton;
