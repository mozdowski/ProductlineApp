import { ProductForm } from '../../../../interfaces/products/productForm';
import Photos from '../../../molecules/formSections/editProductFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/editProductFormSections/ProductInfo/ProductInfo';
import ButtonsSection from '../../../molecules/formSections/addProductFormSections/buttonsSection/ButtonsSection';
import './css/editProductForm.css';
import { ProductEditForm } from '../../../../interfaces/products/productEditForm';
import { Photo } from '../../../../pages/EditProduct';

export default function EditProductForm({
  uploadProductPhotos,
  photos,
  onSubmit,
  productForm,
  onChange,
  errors,
  onPhotoDelete,
  onPhotoMove,
  confirmDisabled,
}: {
  uploadProductPhotos: any;
  photos: Photo[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  productForm: ProductEditForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<ProductForm>;
  onPhotoMove: (dragIndex: number, hoverIndex: number) => void;
  onPhotoDelete: (index: number) => void;
  confirmDisabled: boolean;
}) {
  return (
    <>
      <form onSubmit={onSubmit}>
        <div className="editProduct">
          <div className="detailsAboutEditedProductForm">
            <ProductInfo productForm={productForm} onChange={onChange} errors={errors} />
          </div>
          <div className="editedProductPhotosForm">
            <Photos
              uploadProductPhotos={uploadProductPhotos}
              photos={photos}
              error={errors.photos}
              onPhotoDelete={onPhotoDelete}
              onPhotoMove={onPhotoMove}
            />
          </div>
        </div>
        <ButtonsSection confirmDisabled={confirmDisabled} />
      </form>
    </>
  );
}
