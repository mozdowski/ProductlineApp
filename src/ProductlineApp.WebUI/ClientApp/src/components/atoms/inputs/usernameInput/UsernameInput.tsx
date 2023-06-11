import "./css/usernameInput.css"

function UsernameInput() {

    return (
        <>
            <label htmlFor="uname" className="unameLabel">Nazwa uzytkownika</label>
            <input type="text" id="uname" name="uname" placeholder="Nazwa uzytkownika" className="unameInput"></input>
        </>
    );
}

export default UsernameInput