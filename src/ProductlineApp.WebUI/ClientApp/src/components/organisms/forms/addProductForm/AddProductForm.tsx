import { ProductForm } from '../../../../interfaces/products/productForm';
import Photos from '../../../molecules/formSections/addProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/addProductForm.css';

export default function AddProductForm({
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
  errors: Partial<ProductForm>;
  onPhotoMove: (dragIndex: number, hoverIndex: number) => void;
  onPhotoDelete: (index: number) => void;
  confirmDisabled: boolean;
}) {
  return (
    <>
      <form onSubmit={onSubmit}>
        <div className="addProduct">
          <div className="detailsAboutProductForm">
            <ProductInfo productForm={productForm} onChange={onChange} errors={errors} />
          </div>
          <div className="productPhotosForm">
            <Photos
              uploadProductPhotos={uploadProductPhotos}
              photos={photos}
              error={errors.photos}
              onPhotoMove={onPhotoMove}
              onPhotoDelete={onPhotoDelete}
            />
          </div>
        </div>
        <ButtonsSection confirmDisabled={confirmDisabled} />
      </form>
    </>
  );
}
