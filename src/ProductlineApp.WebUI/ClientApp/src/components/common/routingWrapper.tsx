import { useAuth } from '../../hooks/auth/useAuth';
import { Navigate, Route, Routes } from 'react-router-dom';
import Login from '../../pages/Login';
import Forgotpassword from '../../pages/Forgotpassword';
import Signin from '../../pages/Signin';
import ProtectedRoute from '../../common/routes/protectedRoute';
import Dashboard from '../../pages/Dashboard';
import Layout from './layout';
import { ProductsProvider } from '../../providers/productsProvider';
import Products from '../../pages/Products';
import Orders from '../../pages/Orders';
import Auctions from '../../pages/Auctions';
import Logout from '../../pages/Logout';
import Settings from '../../pages/Settings';
import { AuctionsProvider } from '../../providers/auctionsProvider';

const RoutingWrapper = () => {
  const { isAuthenticated } = useAuth();

  return (
    <Routes>
      <Route
        path="/"
        element={
          isAuthenticated() ? (
            <Navigate to="/dashboard" replace />
          ) : (
            <Navigate to="/login" replace />
          )
        }
      />
      <Route
        path="/login"
        element={isAuthenticated() ? <Navigate to="/dashboard" replace /> : <Login />}
      />
      <Route
        path="/signin"
        element={isAuthenticated() ? <Navigate to="/dashboard" replace /> : <Signin />}
      />
      <Route path="/forgotpassword" element={<Forgotpassword />} />

      <Route element={<Layout />}>
        <Route
          path="/dashboard"
          element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }
        ></Route>

        <Route
          path="/products"
          element={
            <ProtectedRoute>
              <ProductsProvider>
                <Products />
              </ProductsProvider>
            </ProtectedRoute>
          }
        >
          <Route path="add" element={''}></Route>
          <Route path="edit" element={''}></Route>
        </Route>

        <Route
          path="/auctions"
          element={
            <ProtectedRoute>
              <AuctionsProvider>
                <Auctions />
              </AuctionsProvider>
            </ProtectedRoute>
          }
        ></Route>
        <Route
          path="/orders"
          element={
            <ProtectedRoute>
              <Orders />
            </ProtectedRoute>
          }
        ></Route>
        <Route
          path="/settings"
          element={
            <ProtectedRoute>
              <Settings />
            </ProtectedRoute>
          }
        ></Route>
        <Route
          path="/logout"
          element={
            <ProtectedRoute>
              <Logout />
            </ProtectedRoute>
          }
        ></Route>
      </Route>
    </Routes>
  );
};

export default RoutingWrapper;
