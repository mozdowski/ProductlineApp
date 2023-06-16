import React from 'react';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import './css/UserAccountButton.css';
import { useAuth } from '../../../../hooks/auth/useAuth';
import UserImage from '../../../../assets/icons/userAvatarImage.jpeg';

function UserAccountButton() {
  const { user } = useAuth();

  return (
    <div className="userAccountButton">
      <div className="userInfo">
        <h2>{user?.name}</h2>
        <p>{user?.email}</p>
      </div>
      <Link to="/settings" className="goToAccountSettingsLink" id="link">
        <img className="userImage" src={user?.avatar === null ? UserImage : user?.avatar}></img>
      </Link>
    </div>
  );
}

export default UserAccountButton;
