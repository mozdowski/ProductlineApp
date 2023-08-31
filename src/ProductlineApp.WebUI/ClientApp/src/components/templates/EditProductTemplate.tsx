import { ProductEditForm } from '../../interfaces/products/productEditForm';
import { Photo } from '../../pages/EditProduct';
import EditProductForm from '../organisms/forms/editProductForm/EditProductForm';
import EditProductPageHeader from '../organisms/pageHeaders/EditProductPageHeader';
import './css/editProductTemplate.css';

export default function EditProductTemplate({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors,
  onPhotoDelete,
  onPhotoMove,
  confirmDisabled
}: {
  uploadProductPhotos: any;
  photos: Photo[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductEditForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
  onPhotoMove: (dragIndex: number, hoverIndex: number) => void;
  onPhotoDelete: (index: number) => void;
  confirmDisabled: boolean;
}) {
  return (
    <>
      <EditProductPageHeader />
      <div className="content">
        <div className="editProductForm">
          <EditProductForm
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            onSubmit={onSubmit}
            productForm={productForm}
            onChange={onChange}
            errors={errors}
            onPhotoDelete={onPhotoDelete}
            onPhotoMove={onPhotoMove}
            confirmDisabled={confirmDisabled}
          />
        </div>
      </div>
    </>
  );
}
