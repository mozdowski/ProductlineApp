import React from 'react';
import Sidebar from './components/common/sidebar/sidebar';
import Dashboard from './pages/Dashboard';
import Products from './pages/Products';
import { Navigate, Route, Routes } from 'react-router-dom'
import Auctions from './pages/Auctions';
import Orders from './pages/Orders';
import Settings from './pages/Settings';
import Logout from './pages/Logout';
import './App.css'
import '../src/components/common/sidebar/sidebar.css'
import Login from './pages/Login';
import { Outlet } from "react-router-dom"
import Signin from './pages/Signin';
import Forgotpassword from "./pages/Forgotpassword";
import AddProduct from './pages/AddProduct';

function App() {

  const Layout = () => {
    return (
      <>
        <Sidebar />
        <div className="container" id='container'>
          <Outlet />
        </div>
      </>
    )
  }
  return (
    <>
      <Routes>
        <Route path="/" element={<Navigate to="/login" replace />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signin" element={<Signin />} />
        <Route path="/forgotpassword" element={<Forgotpassword />} />

        <Route element={<Layout />}>
          <Route path='/dashboard' element={<Dashboard />}></Route>

          <Route path='/products' element={<Products />}></Route>
          <Route path='/products/add' element={<AddProduct />}></Route>
          <Route path='/products/edit' element={""}></Route>

          <Route path='/auctions' element={<Auctions />}></Route>
          <Route path='/orders' element={<Orders />}></Route>
          <Route path='/settings' element={<Settings />}></Route>
          <Route path='/logout' element={<Logout />}></Route>
        </Route>
      </Routes>
    </>
  );
}

export default App;
