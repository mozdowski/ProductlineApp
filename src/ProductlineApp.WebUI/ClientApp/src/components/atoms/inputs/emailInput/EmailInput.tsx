import "./css/emailInput.css"

function EmailInput() {

    return (
        <>
            <label htmlFor="emial" className="emailLabel">Email</label>
            <input type="email" id="email" name="email" placeholder="Email" className="emailInput"></input>
        </>
    );
}

export default EmailInput