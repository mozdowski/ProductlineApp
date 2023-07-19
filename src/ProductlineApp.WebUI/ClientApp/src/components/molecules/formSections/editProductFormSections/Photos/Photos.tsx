import EditProductPhotosInput from '../../../../atoms/inputs/productPhotosInput/EditProductPhotosInput';
import './css/editProduct_Photos.css';

function Photos({
  uploadProductPhotos,
  photos,
  error,
}: {
  uploadProductPhotos: any;
  photos: string[];
  error: any;
}) {
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
          <EditProductPhotosInput
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            error={error}
          />
        </div>
      </div>
    </>
  );
}

export default Photos;
