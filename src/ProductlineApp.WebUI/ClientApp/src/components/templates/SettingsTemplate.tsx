import './css/SettingsTemplate.css';
import SettingsPageHeader from '../organisms/pageHeaders/SettingsPageHeader';
import { ProfileDetails } from '../organisms/settingsOptions/profileDetails/ProfileDetails';

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
        </div>
      </div>
    </>
  );
}
