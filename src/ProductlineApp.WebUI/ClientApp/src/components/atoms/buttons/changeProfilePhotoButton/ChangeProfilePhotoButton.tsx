import './css/changeProfilePhotoButton.css';

function ChangeProfilePhotoButton({
  changeAvatar,
}: {
  changeAvatar: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) {
  return (
    <div className="changeProfilePhotoButton">
      <input
        type="file"
        accept="image/*"
        id="profilePhoto"
        name="profilePhoto"
        className="profilePhoto"
        onChange={changeAvatar}
      />
      <p>Zmień zdjęcie profilowe</p>
    </div>
  );
}

export default ChangeProfilePhotoButton;
