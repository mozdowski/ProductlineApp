import React from 'react';
import './sidebar.css';
import { Link, useMatch, useResolvedPath } from 'react-router-dom';
import DashboardImage from './img/dashboard.png';
import ProductsImage from './img/products.png';
import AuctionsImage from './img/auctions.png';
import OrdersImage from './img/orders.png';
import SettingsImage from './img/settings.png';
import LogoutImage from './img/logout.png';
import { useAuth } from '../../../hooks/auth/useAuth';

const SidebarOverHandler = (event: React.MouseEvent<HTMLDivElement>) => {
  const sidebar: HTMLDivElement = event.currentTarget;
  sidebar.style.width = '248px';
  const logo = document.getElementById('logo');
  const separator = document.getElementById('separator');
  const container = document.getElementById('container');
  if (!logo || !separator || !container) {
    return;
  } else {
    logo.innerHTML = '<Link to="/dashboard">productline<span id="dot">.</span></Link>';
    separator.style.width = '162px';
    container.style.width = 'calc(100% - 248px)';
    container.style.transition = '0.25s';
  }
};

const SidebarOutHandler = (event: React.MouseEvent<HTMLDivElement>) => {
  const sidebar: HTMLDivElement = event.currentTarget;
  sidebar.style.width = '104px';
  const logo = document.getElementById('logo');
  const separator = document.getElementById('separator');
  const container = document.getElementById('container');
  if (!logo || !separator || !container) {
    return;
  } else {
    logo.innerHTML = '<Link to="/dashboard">pl<span id="dot">.</span></Link>';
    separator.style.width = '22px';
    separator.style.transition = '0.25s';
    container.style.width = 'calc(100% - 104px)';
    container.style.transition = '0.25s';
  }
};

function CustomLink({
  to,
  title,
  image,
  onClick,
  ...props
}: {
  to: string;
  title: string;
  image: string;
  onClick?: () => void;
}) {
  const path = useResolvedPath(to);
  const isActive = useMatch({ path: path.pathname, end: true });

  const handleClick = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
    if (onClick) {
      onClick();
    }
  };

  return (
    <li className={isActive ? 'nav__link active' : 'nav__link'} id="nav__link">
      <Link to={to} className="link" id="link" onClick={handleClick} {...props}>
        <img id="image" src={image} className="sidebar-img" />
        <span className="nav__name">{title}</span>
      </Link>
    </li>
  );
}

function Sidebar() {
  const { logout } = useAuth();

  return (
    <div
      className="sidebar"
      id="sidebar"
      onMouseOver={SidebarOverHandler}
      onMouseOut={SidebarOutHandler}
    >
      <div className="header__img">
        <Link to="/dashboard" className="logo" id="logo">
          pl<span id="dot">.</span>
        </Link>
      </div>

      <ul className="nav__list">
        <CustomLink to="/dashboard" title="Dashboard" image={DashboardImage}></CustomLink>

        <CustomLink to="/products" title="Produkty" image={ProductsImage}></CustomLink>

        <CustomLink to="/auctions" title="Aukcje" image={AuctionsImage}></CustomLink>

        <CustomLink to="/orders" title="Zamówienia" image={OrdersImage}></CustomLink>

        <div className="separator" id="separator"></div>

        <CustomLink to="/settings" title="Ustawienia" image={SettingsImage}></CustomLink>

        <CustomLink to="/logout" title="Wyloguj" image={LogoutImage} onClick={logout}></CustomLink>
      </ul>
    </div>
  );
}

export default Sidebar;
