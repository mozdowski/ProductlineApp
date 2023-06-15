import { Outlet } from 'react-router-dom';
import Sidebar from './sidebar/sidebar';

const Layout = () => {
  return (
    <>
      <Sidebar />
      <div className="container" id="container">
        <Outlet />
      </div>
    </>
  );
};

export default Layout;
