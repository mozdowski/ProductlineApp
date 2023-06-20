import { useState } from "react";
import SettingsTemplate from "../components/templates/SettingsTemplate";

export default function Settings() {

    const [image, setImage] = useState<File | null>(null);
    const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (!e.target.files) return;

        setImage(e.target.files[0]);
    };

    return (
        <SettingsTemplate image={image} showImage={showImage} UserImage={""} />
    );
}
