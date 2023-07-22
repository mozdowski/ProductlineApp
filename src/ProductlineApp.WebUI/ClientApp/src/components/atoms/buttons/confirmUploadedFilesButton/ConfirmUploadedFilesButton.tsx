import './css/confirmUploadedFilesButton.css';

function ConfirmUploadedFilesButton({ onClick }: { onClick: () => void }) {
  return (
    <div className="confirmUploadedFilesButtonWrapper" onClick={onClick}>
      <input type="submit" className="confirmUploadedFilesButton" value="Przeslij"></input>
    </div>
  );
}

export default ConfirmUploadedFilesButton;
