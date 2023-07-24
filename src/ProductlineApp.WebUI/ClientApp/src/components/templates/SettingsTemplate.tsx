import './css/SettingsTemplate.css';
import SettingsPageHeader from '../organisms/pageHeaders/SettingsPageHeader';
import { ProfileDetails } from '../organisms/settingsOptions/profileDetails/ProfileDetails';
import { ChangePassword } from '../organisms/settingsOptions/changePassword/ChangePassword';
import { DeleteAccount } from '../organisms/settingsOptions/deleteAccount/DeleteAccount';
import { ConnectAccountToPortals } from '../organisms/settingsOptions/connectAccountToPortals/ConnectAccountToPortals';
import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';
import { Platform } from '../../interfaces/platforms/platform';
import { ChangePasswordForm } from '../../interfaces/settings/changePasswordForm';

export default function SettingsTemplate({
  image,
  showImage,
  UserImage,
  UserName,
  UserEmail,
  platformsAuthUrl,
  onDisconnect,
  userConnections,
  onPasswordChange,
  changeAatar,
}: {
  image: any;
  showImage: any;
  UserImage: any;
  UserName: string;
  UserEmail: string;
  platformsAuthUrl: PlatformAuthUrl[];
  onDisconnect: (platformId: string) => void;
  userConnections: string[];
  onPasswordChange: (data: ChangePasswordForm) => void;
  changeAatar: () => void;
}) {
  return (
    <>
      <SettingsPageHeader />
      <div className="content">
        <div className="settings">
          <ProfileDetails
            image={image}
            showImage={showImage}
            UserImage={UserImage}
            UserName={UserName}
            UserEmail={UserEmail}
            changeAatar={changeAatar}
          />
          {platformsAuthUrl.length > 0 && (
            <ConnectAccountToPortals
              platformsAuthUrl={platformsAuthUrl}
              onDisconnect={onDisconnect}
              userConnections={userConnections}
            />
          )}
          <ChangePassword onPasswordChange={onPasswordChange} />
          <DeleteAccount />
        </div>
      </div>
    </>
  );
}
