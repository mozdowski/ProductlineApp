import { ProductAuctionData } from '../../../../../interfaces/products/getProductsSKU';
import BrandInput from '../../../../atoms/inputs/brandInput/BrandInput';
import ConditionInput from '../../../../atoms/inputs/conditionInput/ConditionInput';
import PriceInput from '../../../../atoms/inputs/priceInput/PriceInput';
import ProductDescritionInput from '../../../../atoms/inputs/productDescriptionInput/ProcuctDescriptionInput';
import ProductNameInput from '../../../../atoms/inputs/productNameInput/ProductNameInput';
import QuantityInput from '../../../../atoms/inputs/quantityInput/QuantityInput';
import './css/addAuction_ProductInfo.css';

function ProductInfo({
  selectedProduct,
  onChange,
}: {
  selectedProduct: ProductAuctionData | null;
  onChange: (name: string, value: string | number) => void;
}) {
  return (
    <>
      <div className="productInfo">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>2</h1>
          </div>
          <p>Informacje o Produkcie</p>
        </div>
        <div className="addAuctionInputs">
          <div className="firsLineInputs">
            <BrandInput
              value={selectedProduct?.brand}
              onChange={onChange}
              error={null}
              disabled={true}
            />
            <ProductNameInput
              value={selectedProduct?.name}
              onChange={onChange}
              error={null}
              disabled={true}
            />
          </div>
          <div className="secondLineInputs">
            <ConditionInput
              value={selectedProduct?.condition.toString()}
              onChange={onChange}
              error={null}
              disabled={true}
            />
            <QuantityInput
              value={selectedProduct?.quantity}
              onChange={onChange}
              error={null}
              disabled={true}
            />
            <PriceInput
              value={selectedProduct?.price}
              onChange={onChange}
              error={null}
              disabled={true}
            />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput
              value={selectedProduct?.description}
              onChange={onChange}
              error={null}
              disabled={true}
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default ProductInfo;
