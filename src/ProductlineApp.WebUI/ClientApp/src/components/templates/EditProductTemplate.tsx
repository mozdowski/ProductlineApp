import { ProductEditForm } from '../../interfaces/products/productEditForm';
import EditProductForm from '../organisms/forms/editProductForm/EditProductForm';
import EditProductPageHeader from '../organisms/pageHeaders/EditProductPageHeader';
import './css/editProductTemplate.css';

export default function EditProductTemplate({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductEditForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
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
            errors={errors} />
        </div>
      </div>
    </>
  );
}
