import { ProductForm } from '../../interfaces/products/productForm';
import AddProductForm from '../organisms/forms/addProductForm/AddProductForm';
import AddProductPageHeader from '../organisms/pageHeaders/AddProductPageHeader';
import './css/AddProductTemplate.css';

export default function AddProductTemplate({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors,
  onPhotoMove,
  onPhotoDelete,
  confirmDisabled
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
  onPhotoMove: (dragIndex: number, hoverIndex: number) => void;
  onPhotoDelete: (index: number) => void;
  confirmDisabled: boolean;
}) {
  return (
    <>
      <AddProductPageHeader />
      <div className="content">
        <div className="addProductForm">
          <AddProductForm
            uploadProductPhotos={uploadProductPhotos}
            photos={photos}
            onSubmit={onSubmit}
            productForm={productForm}
            onChange={onChange}
            errors={errors}
            onPhotoMove={onPhotoMove}
            onPhotoDelete={onPhotoDelete}
            confirmDisabled={confirmDisabled}
          />
        </div>
      </div>
    </>
  );
}
