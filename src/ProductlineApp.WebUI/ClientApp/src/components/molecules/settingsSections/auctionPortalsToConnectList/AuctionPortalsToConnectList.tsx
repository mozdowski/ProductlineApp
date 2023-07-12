import './css/auctionPortalsToConnectList.css';
import AllegroIcon from '../../../../assets/icons/allegro_a_logo_icon.svg';
import EbayIcon from '../../../../assets/icons/ebay_icon_logo.svg';
import ConnectAccountButton from '../../../atoms/buttons/connectAccountButton/ConnectAccountButton';
import { PlatformAuthUrl } from '../../../../interfaces/platforms/platformsAuthUrlResponse';
import { PlatformEnum } from '../../../../enums/platform.enum';
import DisconnectAccountButton from '../../../atoms/buttons/disconectAccountButton/DisconnectAccountButton';

function AuctionPortalsToConnectList({
  platformsAuthUrl,
  onDisconnect,
  userConnections,
}: {
  platformsAuthUrl: PlatformAuthUrl[];
  onDisconnect: (platformName: string) => void;
  userConnections: string[];
}) {
  const allegroPlatform = platformsAuthUrl.find((x) => x.platformName === PlatformEnum.ALLEGRO);
  const ebayPlatform = platformsAuthUrl.find((x) => x.platformName === PlatformEnum.EBAY);

  return (
    <>
      <div className="auctionPortalsToConnectList">
        <div className="allegroConnectorLink">
          <img src={AllegroIcon} />
          <h3>Allegro</h3>
          {allegroPlatform && !userConnections.includes(allegroPlatform?.platformId) && (
            <ConnectAccountButton authUrl={allegroPlatform.authUrl} />
          )}
          {(!allegroPlatform || userConnections.includes(allegroPlatform?.platformId)) && (
            <DisconnectAccountButton onDisconnect={onDisconnect} name={'allegro'} />
          )}
        </div>
        <div className="linkSeparator"></div>
        <div className="ebayConnectorLink">
          <img src={EbayIcon} />
          <h3>Ebay</h3>
          {ebayPlatform && !userConnections.includes(ebayPlatform?.platformId) && (
            <ConnectAccountButton authUrl={ebayPlatform.authUrl} />
          )}
          {(!ebayPlatform || userConnections.includes(ebayPlatform?.platformId)) && (
            <DisconnectAccountButton onDisconnect={onDisconnect} name={'ebay'} />
          )}
        </div>
      </div>
    </>
  );
}

export default AuctionPortalsToConnectList;
