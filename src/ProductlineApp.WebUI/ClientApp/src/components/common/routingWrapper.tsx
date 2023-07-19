import { useAuth } from '../../hooks/auth/useAuth';
import { Navigate, Outlet, Route, Routes } from 'react-router-dom';
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
import { OrdersProvider } from '../../providers/ordersProvider';
import AddProduct from '../../pages/AddProduct';
import AddAuction from '../../pages/AddAuction';
import { UserProvider } from '../../providers/userProvider';
import PLatformRedirect from './platformRedirect';
import { AddAuctionProvider } from '../../providers/addAuctionProvider';
import { StatisticsProvider } from '../../providers/statisticsProvider';
import EditProduct from '../../pages/EditProduct';

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
              <StatisticsProvider>
                <Dashboard />
              </StatisticsProvider>
            </ProtectedRoute>
          }
        ></Route>

        <Route
          path="products"
          element={
            <ProtectedRoute>
              <ProductsProvider>
                <Outlet />
              </ProductsProvider>
            </ProtectedRoute>
          }
        >
          <Route path="" element={<Products />}></Route>
          <Route path="add" element={<AddProduct />}></Route>
          <Route path="edit/:productId" element={<EditProduct />}></Route>
        </Route>

        <Route
          path="/auctions"
          element={
            <ProtectedRoute>
              <AuctionsProvider>
                <Outlet />
              </AuctionsProvider>
            </ProtectedRoute>
          }
        >
          <Route path="" element={<Auctions />}></Route>
          <Route
            path="add"
            element={
              <AddAuctionProvider>
                <AddAuction />
              </AddAuctionProvider>
            }
          ></Route>
          <Route path="edit" element={''}></Route>
        </Route>
        <Route
          path="/orders"
          element={
            <ProtectedRoute>
              <OrdersProvider>
                <Orders />
              </OrdersProvider>
            </ProtectedRoute>
          }
        ></Route>
        <Route
          path="/settings"
          element={
            <ProtectedRoute>
              <UserProvider>
                <Settings />
              </UserProvider>
            </ProtectedRoute>
          }
        ></Route>
        <Route
          path="/platform-redirect/:platformId"
          element={
            <ProtectedRoute>
              <UserProvider>
                <PLatformRedirect />
              </UserProvider>
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
