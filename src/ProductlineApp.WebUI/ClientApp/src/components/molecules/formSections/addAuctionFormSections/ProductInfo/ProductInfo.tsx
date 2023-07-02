import { AuctionForm } from '../../../../../interfaces/auctions/auctionForm';
import BrandInput from '../../../../atoms/inputs/brandInput/BrandInput';
import ConditionInput from '../../../../atoms/inputs/conditionInput/ConditionInput';
import PriceInput from '../../../../atoms/inputs/priceInput/PriceInput';
import ProductDescritionInput from '../../../../atoms/inputs/productDescriptionInput/ProcuctDescriptionInput';
import ProductNameInput from '../../../../atoms/inputs/productNameInput/ProductNameInput';
import QuantityInput from '../../../../atoms/inputs/quantityInput/QuantityInput';
import './css/addAuction_ProductInfo.css';

function ProductInfo({
  auctionForm,
  onChange,
  errors,
}: {
  auctionForm: AuctionForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<AuctionForm>;
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
            <BrandInput value={auctionForm.brand} onChange={onChange} error={""} disabled={true} />
            <ProductNameInput value={auctionForm.name} onChange={onChange} error={""} disabled={true} />
          </div>
          <div className="secondLineInputs">
            <ConditionInput value={auctionForm.condition.toString()} onChange={onChange} error={""} disabled={true} />
            <QuantityInput
              value={auctionForm.quantity}
              onChange={onChange}
              error={""}
              disabled={true}
            />
            <PriceInput value={auctionForm.price} onChange={onChange} error={""} disabled={true} />
          </div>
          <div className="textAreaProductDescription">
            <ProductDescritionInput
              value={auctionForm.description}
              onChange={onChange}
              error={""}
              disabled={true}
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default ProductInfo;
