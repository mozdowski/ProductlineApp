import './App.css';
import '../src/components/common/sidebar/sidebar.css';
import { AuthProvider } from './providers/authProvider';
import RoutingWrapper from './components/common/routingWrapper';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <AuthProvider>
      <RoutingWrapper />
      <ToastContainer></ToastContainer>
    </AuthProvider>
  );
}

export default App;
