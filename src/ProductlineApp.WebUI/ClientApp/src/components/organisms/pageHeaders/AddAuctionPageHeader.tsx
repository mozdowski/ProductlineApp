import AddProductButton from '../../atoms/buttons/addProductButtons/AddProductButton';
import ChangeDarkModeButtton from '../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import UserAccountButton from '../../atoms/buttons/userAccountButton/UserAccountButton';
import './css/PageHeader.css';

export default function AddAuctionPageHeader() {
  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Dodaj Ogłoszenie</h1>
        </div>
        <div className="pageUserActions">
          {/*<ChangeDarkModeButtton />*/}
          <AddProductButton />
          <UserAccountButton />
        </div>
      </div>
    </>
  );
}
