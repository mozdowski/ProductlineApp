import AuctionPortalsToConnectList from '../../../molecules/settingsSections/auctionPortalsToConnectList/AuctionPortalsToConnectList';
import './css/connectAccountToPortals.css';

export const ConnectAccountToPortals = () => {
  return (
    <div className="connectAccountToPortals">
      <h1>Połączone Konta</h1>
      <p className="info">Połącz się z serwisami sprzedazowymi na których sprzedajesz </p>
      <AuctionPortalsToConnectList />
    </div>
  );
};
