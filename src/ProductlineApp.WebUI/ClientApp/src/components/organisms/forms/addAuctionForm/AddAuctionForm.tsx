import { ChangeEvent, useState } from 'react';
import { AuctionForm } from '../../../../interfaces/auctions/auctionForm';
import Photos from '../../../molecules/formSections/addAuctionFormSections/Photos/Photos';
import ProductInfo from '../../../molecules/formSections/addAuctionFormSections/ProductInfo/ProductInfo';
import AuctionPortals from '../../../molecules/formSections/addAuctionFormSections/auctionPortals/AuctionPortals';
import ButtonsSection from '../../../molecules/formSections/addAuctionFormSections/buttonsSection/ButtonsSection';
import SelectProduct from '../../../molecules/formSections/addAuctionFormSections/selectProduct/SelectProduct';
import './css/addAuctionForm.css';
import { ProductSKU } from '../../../../interfaces/products/getProductsSKU';

export default function AddAuctionForm({
  productsSKURecords,
  photos,
  onSubmit,
  auctionForm,
  onChange,
  errors,
}: {
  productsSKURecords: ProductSKU[];
  photos: string[];
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
  auctionForm: AuctionForm;
  onChange: (name: string, value: string | number) => void;
  errors: Partial<AuctionForm>;
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
            productsSKURecords={productsSKURecords}
            auctionForm={auctionForm}
            showFormSteps={(e: ChangeEvent<HTMLSelectElement>) => handleShowFormSteps(e)}
            onChange={onChange}
            errors={errors}
          />
          {showFormSteps != ' ' && (
            <ProductInfo auctionForm={auctionForm} onChange={onChange} errors={errors} />
          )}
        </div>
        <ButtonsSection />
        {showFormSteps != ' ' && (
          <div className="addAuctionSecondSection">
            <Photos photos={photos} />
            <AuctionPortals auctionForm={auctionForm} errors={errors} />
          </div>
        )}
      </div>
    </>
  );
}
