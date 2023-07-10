import './css/auctionPortalsToConnectList.css';
import AllegroIcon from '../../../../assets/icons/allegro_a_logo_icon.svg';
import EbayIcon from '../../../../assets/icons/ebay_icon_logo.svg';
import ConnectAccountButton from '../../../atoms/buttons/connectAccountButton/ConnectAccountButton';

function AuctionPortalsToConnectList() {
  return (
    <>
      <div className="auctionPortalsToConnectList">
        <div className="allegroConnectorLink">
          <img src={AllegroIcon} />
          <h3>Allegro</h3>
          <ConnectAccountButton />
        </div>
        <div className="linkSeparator"></div>
        <div className="ebayConnectorLink">
          <img src={EbayIcon} />
          <h3>Ebay</h3>
          <ConnectAccountButton />
        </div>
      </div>
    </>
  );
}

export default AuctionPortalsToConnectList;
