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
}: {
  uploadProductPhotos: any;
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: any;
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
          />
        </div>
      </div>
    </>
  );
}
