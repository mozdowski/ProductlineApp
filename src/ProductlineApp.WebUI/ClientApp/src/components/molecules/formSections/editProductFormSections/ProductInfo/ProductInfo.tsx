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

function ProductInfo({
  selectedProductData,
  onChange,
  errors,
}: {
  selectedProductData: ProductData;
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
            <SKUInput value={selectedProductData.sku} onChange={onChange} error={errors.sku} />
            <ProductNameInput
              value={selectedProductData?.name}
              onChange={onChange}
              error={errors.name}
              disabled={false}
            />
          </div>
          <div className="secondLineInputs">
            <BrandInput
              value={selectedProductData?.brand}
              onChange={onChange}
              error={errors.brand}
              disabled={false}
            />
            <QuantityInput
              value={selectedProductData.quantity}
              onChange={onChange}
              error={errors.quantity}
              disabled={false}
            />
            <PriceInput
              value={selectedProductData.price}
              onChange={onChange}
              error={errors.price}
              disabled={false}
            />
          </div>
          <div className="thirdLineInputs">
            <CategoryInput
              value={selectedProductData.category}
              onChange={onChange}
              error={errors.category}
            />
            <ConditionInput
              value={selectedProductData.condition}
              onChange={onChange}
              error={errors.condition}
            />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput
              value={selectedProductData.description}
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
