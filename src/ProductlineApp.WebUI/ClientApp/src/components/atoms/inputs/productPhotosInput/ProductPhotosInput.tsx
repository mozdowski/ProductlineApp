import "./css/productPhotosInput.css"
import UploadImageIcon from "../../../../assets/icons/uplaoadImage_icon.png";

function ProductPhotosInput({ uploadProductPhotos, photos }: { uploadProductPhotos: any, photos: string[] }) {

    return (
        <div className="uploadPhotosField">
            <label htmlFor="uploadPhotos" className="uploadPhotosLabel">Zdjęcia</label>
            <p>! Pierwsze zdjecie jest zdjeciem głównym</p>
            <div className="productPhotos">
                {(photos || []).map(img => (
                    <img src={img} key={img} className="productImage"></img>
                ))}
                <div className="uploadPhotosInput">
                    <input type="file" accept="image/*" id="uploadPhotos" name="uploadPhotos" multiple onChange={uploadProductPhotos}></input>
                    <img src={UploadImageIcon} className="uploadImageIcon"></img>
                    <p>Dodaj zdjęcia</p>
                </div>
            </div>
        </div>
    );
}

export default ProductPhotosInput