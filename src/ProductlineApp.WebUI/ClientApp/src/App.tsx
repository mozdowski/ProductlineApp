import './App.css';
import '../src/components/common/sidebar/sidebar.css';
import { AuthProvider } from './providers/authProvider';
import RoutingWrapper from './components/common/routingWrapper';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PlatformsProvider } from './providers/platformsProvider';

function App() {
  return (
    <AuthProvider>
      <PlatformsProvider>
        <RoutingWrapper />
        <ToastContainer></ToastContainer>
      </PlatformsProvider>
    </AuthProvider>
  );
}

export default App;
