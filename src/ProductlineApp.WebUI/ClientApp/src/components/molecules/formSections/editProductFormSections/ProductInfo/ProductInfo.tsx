import { ProductForm } from '../../../../../interfaces/products/productForm';
import BrandInput from '../../../../atoms/inputs/brandInput/BrandInput';
import CategoryInput from '../../../../atoms/inputs/categoryInput/CatrgoryInput';
import ConditionInput from '../../../../atoms/inputs/selectProductConditionInput/SelectProductConditionInput';
import PriceInput from '../../../../atoms/inputs/priceInput/PriceInput';
import ProductDescritionInput from '../../../../atoms/inputs/productDescriptionInput/ProcuctDescriptionInput';
import ProductNameInput from '../../../../atoms/inputs/productNameInput/ProductNameInput';
import QuantityInput from '../../../../atoms/inputs/quantityInput/QuantityInput';
import SKUInput from '../../../../atoms/inputs/skuInptu/SKUInput';
import './css/addProduct_ProductInfo.css';
import { ProductData } from '../../../../../interfaces/products/getProductsSKU';
import { ProductDtoResponse } from '../../../../../interfaces/products/getProductsResponse';

function ProductInfo({
  productForm,
  onChange,
  errors,
}: {
  productForm: ProductForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<ProductForm>;
}) {
  return (
    <>
      <div className="productInfo">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>1</h1>
          </div>
          <p>Informacje o Produkcie</p>
        </div>
        <div className="addProductInputs">
          <div className="firsLineInputs">
            <SKUInput value={productForm.sku} onChange={onChange} error={errors.sku} />
            <ProductNameInput
              value={productForm.name}
              onChange={onChange}
              error={errors.name}
              disabled={false}
            />
          </div>
          <div className="secondLineInputs">
            <BrandInput
              value={productForm.brand}
              onChange={onChange}
              error={errors.brand}
              disabled={false}
            />
            <QuantityInput
              value={productForm.quantity}
              onChange={onChange}
              error={errors.quantity}
              disabled={false}
            />
            <PriceInput
              value={productForm.price}
              onChange={onChange}
              error={errors.price}
              disabled={false}
            />
          </div>
          <div className="thirdLineInputs">
            <CategoryInput
              value={productForm.category}
              onChange={onChange}
              error={errors.category}
            />
            <ConditionInput
              value={productForm.condition}
              onChange={onChange}
              error={errors.condition}
            />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput
              value={productForm.description}
              onChange={onChange}
              error={errors.description}
              disabled={false}
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default ProductInfo;
