import ChangeDarkModeButtton from '../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import UserAccountButton from '../../atoms/buttons/userAccountButton/UserAccountButton';
import './css/PageHeader.css';

export default function AddProductPageHeader() {
  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Dodaj Produkt</h1>
        </div>
        <div className="pageUserActions">
          <ChangeDarkModeButtton />
          <UserAccountButton />
        </div>
      </div>
    </>
  );
}
