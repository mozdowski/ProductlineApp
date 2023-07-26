import AddProductButton from '../../atoms/buttons/addProductButtons/AddProductButton';
import ChangeDarkModeButtton from '../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import UserAccountButton from '../../atoms/buttons/userAccountButton/UserAccountButton';
import './css/PageHeader.css';

export default function EditProductPageHeader() {
  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Edytuj Produkt</h1>
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
