import './css/confirmUploadedFilesButton.css';

function ConfirmUploadedFilesButton({ onClick }: { onClick?: () => void }) {
  return (
    <input
      type="submit"
      className="confirmUploadedFilesButton"
      value="Przeslij"
      onClick={onClick}
    ></input>
  );
}

export default ConfirmUploadedFilesButton;
