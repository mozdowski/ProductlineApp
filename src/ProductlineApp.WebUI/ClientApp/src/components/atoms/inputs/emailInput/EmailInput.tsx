import "./css/emailInput.css"

function EmailInput() {

    return (
        <div className="emailField">
            <label htmlFor="email" className="emailLabel">Email</label>
            <input type="email" id="email" name="email" placeholder="Email" className="emailInput"></input>
        </div>
    );
}

export default EmailInput