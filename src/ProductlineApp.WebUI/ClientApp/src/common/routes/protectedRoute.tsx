import React, { Component, ReactElement, ReactNode } from 'react';
import { Navigate, Route, RouteProps } from 'react-router-dom';
import { useAuth } from '../../hooks/auth/useAuth';

const ProtectedRoute = ({ children }: { children: ReactElement }) => {
  const { isAuthenticated } = useAuth();

  if (!isAuthenticated()) {
    return <Navigate to="/login" replace />;
  }

  return children;
};

export default ProtectedRoute;
