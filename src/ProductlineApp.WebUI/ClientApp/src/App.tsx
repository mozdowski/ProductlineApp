import Sidebar from './components/common/sidebar/sidebar';
import Dashboard from './pages/Dashboard';
import Products from './pages/Products';
import { Route, Routes } from 'react-router-dom'
import Auctions from './pages/Auctions';
import Orders from './pages/Orders';
import Statistics from './pages/Statistics';
import Settings from './pages/Settings';
import Logout from './pages/Logout';
import './App.css'
import '../src/components/common/sidebar/sidebar.css'

function App() {
  return (
    <>
      <Sidebar />
      <div className="container" id='container'>
        <Routes>
          <Route path='/dashboard' element={<Dashboard />}></Route>
          <Route path='/products' element={<Products />}></Route>
          <Route path='/auctions' element={<Auctions />}></Route>
          <Route path='/orders' element={<Orders />}></Route>
          <Route path='/statistics' element={<Statistics />}></Route>
          <Route path='/settings' element={<Settings />}></Route>
          <Route path='/logout' element={<Logout />}></Route>
        </Routes>
      </div>
    </>
  );
}

export default App;
