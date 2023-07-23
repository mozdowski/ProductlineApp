import ProductPhotosInput from '../../../../atoms/inputs/productPhotosInput/ProductPhotosInput';
import './css/addProduct_Photos.css';

function Photos({
  uploadProductPhotos,
  photos,
  error,
  onPhotoMove,
  onPhotoDelete,
}: {
  uploadProductPhotos: any;
  photos: string[];
  error: any;
  onPhotoMove: (dragIndex: number, hoverIndex: number) => void;
  onPhotoDelete: (index: number) => void;
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
          <ProductPhotosInput
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            error={error}
            onPhotoMove={onPhotoMove}
            onPhotoDelete={onPhotoDelete}
          />
        </div>
      </div>
    </>
  );
}

export default Photos;
