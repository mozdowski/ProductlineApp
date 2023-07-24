import ChangeProfilePhotoButton from '../../../atoms/buttons/changeProfilePhotoButton/ChangeProfilePhotoButton';
import './css/changeProfilePhotoSection.css';

function ChangeProfilePhotoSection({
  image,
  showImage,
  UserImage,
  changeAatar
}: {
  image: any;
  showImage: any;
  UserImage: any;
  changeAatar: () => void
}) {
  return (
    <>
      <div className="changeProfilePhotoSection">
        <img
          className="uploadedImage"
          src={image === null ? UserImage : URL.createObjectURL(image)}
        ></img>
        <ChangeProfilePhotoButton showImage={showImage} changeAatar={changeAatar} />
      </div>
    </>
  );
}

export default ChangeProfilePhotoSection;
