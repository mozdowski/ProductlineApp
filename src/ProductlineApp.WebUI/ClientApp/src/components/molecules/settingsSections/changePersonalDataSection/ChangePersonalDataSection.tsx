import EmailInput from "../../../atoms/inputs/emailInput/EmailInput";
import UsernameInput from "../../../atoms/inputs/usernameInput/UsernameInput";
import "./css/changePersonalDataSection.css"


function ChangePersonalDataSection() {
    return (
        <>
            <div className="changePesonalDataSection">
                <UsernameInput />
                <EmailInput />
            </div>
        </>

    );
}

export default ChangePersonalDataSection

