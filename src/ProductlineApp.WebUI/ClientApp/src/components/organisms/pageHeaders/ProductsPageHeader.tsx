import ChangeDarkModeButtton from "../../atoms/buttons/changeDarkModeButton/ChangeDarkModeButtton";
import UserAccountButton from "../../atoms/buttons/userAccountButton/UserAccountButton";
import "./css/PageHeader.css";

export default function ProductsPageHeader() {

    return (
        <>
            <div className="heading">
                <div className="pageTitle">
                    <h1>Produkty</h1>
                    <p>Lista twoich produktów</p>
                </div>
                <div className="pageUserActions">
                    <ChangeDarkModeButtton />
                    <UserAccountButton />
                </div>
            </div>
        </>
    );
}
