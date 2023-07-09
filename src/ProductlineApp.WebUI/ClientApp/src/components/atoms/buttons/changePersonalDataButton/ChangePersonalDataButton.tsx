import './css/changePersonalDataButton.css';

function ChangePersonalDataButton({ setDisableEdit, disableEdit }: { setDisableEdit: any, disableEdit: boolean }) {
  return (
    <div className="changePersonalDataButton" onClick={() => setDisableEdit(!disableEdit)}>
      <p>Zmień swoje dane</p>
    </div>
  );
}

export default ChangePersonalDataButton;
