import React from 'react';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/UserAccountButton.css';
import { useAuth } from '../../../../hooks/auth/useAuth';

function UserAccountButton() {
  const { user } = useAuth();

  return (
    <div className="userAccountButton">
      <div className="userInfo">
        <h2>{user?.name}</h2>
        <p>{user?.email}</p>
      </div>
      <Link to="/settings" className="goToAccountSettingsLink" id="link">
        <div className="userImage"></div>
      </Link>
    </div>
  );
}

export default UserAccountButton;
