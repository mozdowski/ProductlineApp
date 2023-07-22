import { Photo } from '../../../../../pages/EditProduct';
import EditProductPhotosInput from '../../../../atoms/inputs/productPhotosInput/EditProductPhotosInput';
import './css/editProduct_Photos.css';

function Photos({
  uploadProductPhotos,
  photos,
  error,
  onPhotoDelete,
  onPhotoMove,
}: {
  uploadProductPhotos: any;
  photos: Photo[];
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
          <EditProductPhotosInput
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            error={error}
            onPhotoDelete={onPhotoDelete}
            onPhotoMove={onPhotoMove}
          />
        </div>
      </div>
    </>
  );
}

export default Photos;
