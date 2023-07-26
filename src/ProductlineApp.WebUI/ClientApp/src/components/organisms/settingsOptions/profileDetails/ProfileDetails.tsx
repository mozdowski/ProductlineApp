import ChangePersonalDataSection from '../../../molecules/settingsSections/changePersonalDataSection/ChangePersonalDataSection';
import ChangeProfilePhotoSection from '../../../molecules/settingsSections/changeProfilePhotoSection/ChangeProfilePhotoSection';
import './css/profileDetails.css';

export const ProfileDetails = ({
  image,
  UserImage,
  UserName,
  UserEmail,
  changeAvatar,
}: {
  image: any;
  UserImage: any;
  UserName: string;
  UserEmail: string;
  changeAvatar: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) => {
  return (
    <div className="profileDetails grid-col-span-2">
      <h1>Szczegóły Profilu</h1>
      <ChangeProfilePhotoSection image={image} UserImage={UserImage} changeAvatar={changeAvatar} />
      <ChangePersonalDataSection UserName={UserName} UserEmail={UserEmail} />
    </div>
  );
};
