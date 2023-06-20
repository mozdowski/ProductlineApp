import { ChangeEvent, SetStateAction, useState } from "react";
import AddProductTemplate from "../components/templates/AddProductTemplate";


export default function AddProduct() {

    const [selectedFiles, setSelectedFiles] = useState<FileList | null>(null);
    const [imagePreviews, setImagePreviews] = useState<Array<string>>([]);

    const selectImages = (event: React.ChangeEvent<HTMLInputElement>) => {
        let images: Array<string> = [];
        let files = event.target.files;

        if (files) {
            for (let i = 0; i < files.length; i++) {
                images.push(URL.createObjectURL(files[i]));
            }

            setSelectedFiles(files);
            setImagePreviews(images);
        }
    };

    return (
        <AddProductTemplate uploadProductPhotos={selectImages} photos={imagePreviews} />
    );
}

