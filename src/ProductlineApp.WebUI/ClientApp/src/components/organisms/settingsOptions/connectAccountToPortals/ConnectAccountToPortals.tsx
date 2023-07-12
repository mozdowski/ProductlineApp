import { Platform } from '../../../../interfaces/platforms/platform';
import { PlatformAuthUrl } from '../../../../interfaces/platforms/platformsAuthUrlResponse';
import AuctionPortalsToConnectList from '../../../molecules/settingsSections/auctionPortalsToConnectList/AuctionPortalsToConnectList';
import './css/connectAccountToPortals.css';

export const ConnectAccountToPortals = ({
  platformsAuthUrl,
  onDisconnect,
  userConnections,
}: {
  platformsAuthUrl: PlatformAuthUrl[];
  onDisconnect: (platformId: string) => void;
  userConnections: string[];
}) => {
  return (
    <div className="connectAccountToPortals">
      <h1>Połączone Konta</h1>
      <p className="info">Połącz się z serwisami sprzedazowymi na których sprzedajesz </p>
      {platformsAuthUrl.length > 0 && (
        <AuctionPortalsToConnectList
          platformsAuthUrl={platformsAuthUrl}
          onDisconnect={onDisconnect}
          userConnections={userConnections}
        />
      )}
    </div>
  );
};
