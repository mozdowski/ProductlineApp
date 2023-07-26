import AddProductButton from '../../atoms/buttons/addProductButtons/AddProductButton';
import ChangeDarkModeButtton from '../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import UserAccountButton from '../../atoms/buttons/userAccountButton/UserAccountButton';
import './css/PageHeader.css';

export default function AuctionsPageHeader() {
  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Aukcje</h1>
          <p>Lista twoich produktów wystawionych na aukcje</p>
        </div>
        <div className="pageUserActions">
          {/*<ChangeDarkModeButtton/>*/}
          <AddProductButton />
          <UserAccountButton />
        </div>
      </div>
    </>
  );
}
