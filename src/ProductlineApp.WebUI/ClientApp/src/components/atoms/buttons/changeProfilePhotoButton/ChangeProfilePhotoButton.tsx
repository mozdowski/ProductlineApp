import './css/changeProfilePhotoButton.css';

function ChangeProfilePhotoButton({ showImage }: { showImage: any }) {
  return (
    <div className="changeProfilePhotoButton">
      <input
        type="file"
        accept="image/*"
        id="profilePhoto"
        name="profilePhoto"
        className="profilePhoto"
        onChange={showImage}
      />
      <p>Zmień zdjęcie profilowe</p>
    </div>
  );
}

export default ChangeProfilePhotoButton;
