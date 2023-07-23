import './css/productPhotosInput.css';
import UploadImageIcon from '../../../../assets/icons/uplaoadImage_icon.png';
import ImageChip from '../../../molecules/imageChip/imageChip';
import { Photo } from '../../../../pages/EditProduct';

function EditProductPhotosInput({
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
    <div className="uploadPhotosField">
      <div className="productPhotos">
        {photos.map((photo, index) => (
          <ImageChip
            key={`image-${index}`}
            imageUrl={photo.url}
            id={index.toString()}
            onDelete={() => onPhotoDelete(index)}
            moveChip={onPhotoMove}
            index={index}
          />
        ))}
        <div className="uploadPhotosInput">
          <input
            type="file"
            accept="image/*"
            id="uploadPhotos"
            name="uploadPhotos"
            multiple
            onChange={uploadProductPhotos}
          />
          <img src={UploadImageIcon} className="uploadImageIcon" alt="Upload" />
          <p>Zmień zdjęcia</p>
        </div>
      </div>
      {error && <span className="error">{error}</span>}
    </div>
  );
}

export default EditProductPhotosInput;
