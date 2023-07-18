import './App.css';
import '../src/components/common/sidebar/sidebar.css';
import { AuthProvider } from './providers/authProvider';
import RoutingWrapper from './components/common/routingWrapper';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PlatformsProvider } from './providers/platformsProvider';
import { PopupProvider } from './providers/popupProvider';

function App() {
  return (
    <AuthProvider>
      <PlatformsProvider>
        <PopupProvider>
          <RoutingWrapper />
          <ToastContainer></ToastContainer>
        </PopupProvider>
      </PlatformsProvider>
    </AuthProvider>
  );
}

export default App;
