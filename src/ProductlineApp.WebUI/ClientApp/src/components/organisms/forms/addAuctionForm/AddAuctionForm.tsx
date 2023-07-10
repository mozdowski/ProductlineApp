import { ChangeEvent, useState } from 'react';
import Photos from '../../../molecules/formSections/addAuctionFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addAuctionFormSections/ProductInfo/ProductInfo';
import AuctionPortals from '../../../molecules/formSections/addAuctionFormSections/auctionPortals/AuctionPortals';
import ButtonsSection from '../../../molecules/formSections/addAuctionFormSections/buttonsSection/ButtonsSection';
import SelectProduct from '../../../molecules/formSections/addAuctionFormSections/selectProduct/SelectProduct';
import './css/addAuctionForm.css';
import { ProductAuctionData } from '../../../../interfaces/products/getProductsSKU';

export default function AddAuctionForm({
  products,
  selectedProduct,
  onSubmit,
  onProductChange,
  errors,
}: {
  products: ProductAuctionData[];
  selectedProduct: ProductAuctionData | null;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  onProductChange: (id: string) => void;
  errors: any;
}) {
  const [showFormSteps, setSelectedOption] = useState('');

  const handleShowFormSteps = (e: ChangeEvent<HTMLSelectElement>) => {
    const optionValue = e.target.value;
    setSelectedOption(optionValue);
  };

  return (
    <>
      <div className="addAuction">
        <div className="addAuctionFirstSection">
          <SelectProduct
            products={products}
            value={selectedProduct?.id}
            showFormSteps={(e: ChangeEvent<HTMLSelectElement>) => handleShowFormSteps(e)}
            onProductChange={onProductChange}
            errors={errors}
          />
          {showFormSteps != ' ' && (
            <ProductInfo selectedProduct={selectedProduct} onChange={() => {}} />
          )}
        </div>
        <ButtonsSection />
        {showFormSteps != ' ' && (
          <div className="addAuctionSecondSection">
            <Photos photos={selectedProduct ? selectedProduct.imageUrls : []} />
            <AuctionPortals />
          </div>
        )}
      </div>
    </>
  );
}
