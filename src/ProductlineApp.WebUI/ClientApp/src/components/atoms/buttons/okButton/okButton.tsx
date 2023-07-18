import './okButton.css';

function OkButton({ onClick }: { onClick: any }) {
  return (
    <a className="nextButton" onClick={onClick}>
      Ok
    </a>
  );
}

export default OkButton;
