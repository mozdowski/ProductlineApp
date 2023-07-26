import ChangeProfilePhotoButton from '../../../atoms/buttons/changeProfilePhotoButton/ChangeProfilePhotoButton';
import './css/changeProfilePhotoSection.css';

function ChangeProfilePhotoSection({
  image,
  UserImage,
  changeAvatar,
}: {
  image: any;
  UserImage: any;
  changeAvatar: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) {
  return (
    <>
      <div className="changeProfilePhotoSection">
        <img
          className="uploadedImage"
          src={image === undefined ? UserImage : URL.createObjectURL(image)}
        ></img>
        <ChangeProfilePhotoButton changeAvatar={changeAvatar} />
      </div>
    </>
  );
}

export default ChangeProfilePhotoSection;
