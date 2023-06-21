import Photos from '../molecules/formSections/addProductFormSections/Photos/Photos';
import AddProductForm from '../organisms/forms/addProductForm/AddProductForm';
import AddProductPageHeader from '../organisms/pageHeaders/AddProductPageHeader';
import './css/AddProductTemplate.css';

export default function AddProductTemplate({
  uploadProductPhotos,
  photos,
}: {
  uploadProductPhotos: any;
  photos: string[];
}) {
  return (
    <>
      <AddProductPageHeader />
      <div className="content">
        <div className="addProductForm">
          <AddProductForm uploadProductPhotos={uploadProductPhotos} photos={photos} />
        </div>
      </div>
    </>
  );
}
