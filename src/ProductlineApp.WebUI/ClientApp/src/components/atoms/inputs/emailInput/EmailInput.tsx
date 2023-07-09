import './css/emailInput.css';

function EmailInput() {
  return (
    <div className="emailInputField">
      <label htmlFor="emial" className="emailLabel">
        Email
      </label>
      <input
        type="email"
        id="email"
        name="email"
        placeholder="Email"
        className="emailInput"
      ></input>
    </div>
  );
}

export default EmailInput;
