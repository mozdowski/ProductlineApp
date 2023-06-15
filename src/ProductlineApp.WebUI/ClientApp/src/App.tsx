import './App.css';
import '../src/components/common/sidebar/sidebar.css';
import { AuthProvider } from './providers/authProvider';
import RoutingWrapper from './components/common/routingWrapper';

function App() {
  return (
    <AuthProvider>
      <RoutingWrapper />
    </AuthProvider>
  );
}

export default App;
