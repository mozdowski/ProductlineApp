import ChangePersonalDataSection from '../../../molecules/settingsSections/changePersonalDataSection/ChangePersonalDataSection';
import ChangeProfilePhotoSection from '../../../molecules/settingsSections/changeProfilePhotoSection/ChangeProfilePhotoSection';
import './css/profileDetails.css';

export const ProfileDetails = ({
  image,
  showImage,
  UserImage,
  UserName,
  UserEmail,
  changeAatar,
}: {
  image: any;
  showImage: any;
  UserImage: any;
  UserName: string;
  UserEmail: string;
  changeAatar: () => any;
}) => {
  return (
    <div className="profileDetails grid-col-span-2">
      <h1>Szczegóły Profilu</h1>
      <ChangeProfilePhotoSection
        image={image}
        showImage={showImage}
        UserImage={UserImage}
        changeAatar={changeAatar}
      />
      <ChangePersonalDataSection UserName={UserName} UserEmail={UserEmail} />
    </div>
  );
};
