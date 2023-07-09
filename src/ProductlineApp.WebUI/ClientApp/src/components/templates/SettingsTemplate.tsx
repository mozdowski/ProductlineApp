import './css/SettingsTemplate.css';
import SettingsPageHeader from '../organisms/pageHeaders/SettingsPageHeader';
import { ProfileDetails } from '../organisms/settingsOptions/profileDetails/ProfileDetails';
import { ChangePassword } from '../organisms/settingsOptions/changePassword/ChangePassword';
import { DeleteAccount } from '../organisms/settingsOptions/deleteAccount/DeleteAccount';
import { ConnectAccountToPortals } from '../organisms/settingsOptions/connectAccountToPortals/ConnectAccountToPortals';

export default function SettingsTemplate({
  image,
  showImage,
  UserImage,
}: {
  image: any;
  showImage: any;
  UserImage: any;
}) {
  return (
    <>
      <SettingsPageHeader />
      <div className="content">
        <div className="settings">
          <ProfileDetails image={image} showImage={showImage} UserImage={UserImage} />
          <ConnectAccountToPortals />
          <ChangePassword />
          <DeleteAccount />
        </div>
      </div>
    </>
  );
}
