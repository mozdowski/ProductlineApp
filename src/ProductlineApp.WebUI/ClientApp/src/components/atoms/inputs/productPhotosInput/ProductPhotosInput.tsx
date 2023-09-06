import './css/productPhotosInput.css';
import UploadImageIcon from '../../../../assets/icons/uplaoadImage_icon.png';
import ImageChip from '../../../molecules/imageChip/imageChip';

function ProductPhotosInput({
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
    <div className="uploadPhotosField">
      <p>Pierwsze zdjecie jest zdjeciem głównym</p>
      <div className="productPhotos">
        {photos.map((url, index) => (
          <ImageChip
            key={`image-${index}`}
            imageUrl={url}
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
          ></input>
          <img src={UploadImageIcon} className="uploadImageIcon"></img>
          <p>Dodaj zdjęcia</p>
        </div>
      </div>
      {error && <span className="error">{error}</span>}
    </div>
  );
}

export default ProductPhotosInput;
