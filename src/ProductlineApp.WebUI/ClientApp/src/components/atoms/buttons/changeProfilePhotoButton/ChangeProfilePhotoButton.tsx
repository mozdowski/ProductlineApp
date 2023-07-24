import './css/changeProfilePhotoButton.css';

function ChangeProfilePhotoButton({ showImage, changeAatar }: { showImage: any, changeAatar: () => void }) {
  return (
    <div className="changeProfilePhotoButton">
      <input
        type="file"
        accept="image/*"
        id="profilePhoto"
        name="profilePhoto"
        className="profilePhoto"
        onChange={showImage}
        onClick={changeAatar}
      />
      <p>Zmień zdjęcie profilowe</p>
    </div>
  );
}

export default ChangeProfilePhotoButton;
