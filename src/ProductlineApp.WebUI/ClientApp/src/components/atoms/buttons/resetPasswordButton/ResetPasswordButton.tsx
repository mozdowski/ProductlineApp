import React from "react";
import { Link, useMatch, useResolvedPath } from "react-router-dom";
import './css/ResetPasswordButton.css';

function ResetPasswordButton() {
    return (
        <Link to="/login" className="sendLinkResetPasswordLink" id="link">
            <div className="sendLinkResetPasswordButton">
                <p>Wyślij</p>
            </div>
        </Link>
    );
}

export default ResetPasswordButton