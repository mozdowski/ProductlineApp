import ChangeDarkModeButtton from '../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton';
import UserAccountButton from '../../atoms/buttons/userAccountButton/UserAccountButton';
import './css/PageHeader.css';

export default function SettingsPageHeader() {
  return (
    <>
      <div className="heading">
        <div className="pageTitle">
          <h1>Ustawienia</h1>
          <p>Ustawienia konta oraz aplikacji</p>
        </div>
        <div className="pageUserActions">
          <ChangeDarkModeButtton />
          <UserAccountButton />
        </div>
      </div>
    </>
  );
}
