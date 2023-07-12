import './css/SettingsTemplate.css';
import SettingsPageHeader from '../organisms/pageHeaders/SettingsPageHeader';
import { ProfileDetails } from '../organisms/settingsOptions/profileDetails/ProfileDetails';
import { ChangePassword } from '../organisms/settingsOptions/changePassword/ChangePassword';
import { DeleteAccount } from '../organisms/settingsOptions/deleteAccount/DeleteAccount';
import { ConnectAccountToPortals } from '../organisms/settingsOptions/connectAccountToPortals/ConnectAccountToPortals';
import { PlatformAuthUrl } from '../../interfaces/platforms/platformsAuthUrlResponse';
import { Platform } from '../../interfaces/platforms/platform';

export default function SettingsTemplate({
  image,
  showImage,
  UserImage,
  platformsAuthUrl,
  onDisconnect,
  userConnections,
}: {
  image: any;
  showImage: any;
  UserImage: any;
  platformsAuthUrl: PlatformAuthUrl[];
  onDisconnect: (platformName: string) => void;
  userConnections: string[];
}) {
  return (
    <>
      <SettingsPageHeader />
      <div className="content">
        <div className="settings">
          <ProfileDetails image={image} showImage={showImage} UserImage={UserImage} />
          {platformsAuthUrl.length > 0 && (
            <ConnectAccountToPortals
              platformsAuthUrl={platformsAuthUrl}
              onDisconnect={onDisconnect}
              userConnections={userConnections}
            />
          )}
          <ChangePassword />
          <DeleteAccount />
        </div>
      </div>
    </>
  );
}
