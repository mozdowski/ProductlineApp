import ProductPhotosInput from "../../../../atoms/inputs/productPhotosInput/ProductPhotosInput";
import "./css/photos.css"


function Photos({ uploadProductPhotos, photos }: { uploadProductPhotos: any, photos: string[] }) {
    return (
        <>
            <div className="photosInfo">
                <div className="sectionLabel">
                    <div className="sectionNumber">
                        <h1>2</h1>
                    </div>
                    <p>Zdjęcia</p>
                </div>
                <div className="productImages">
                    <ProductPhotosInput uploadProductPhotos={uploadProductPhotos} photos={photos} />
                </div>
            </div>
        </>
    );
}

export default Photos