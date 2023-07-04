import React, { useState, useEffect, useRef, ChangeEvent } from 'react';
import './allegroCatalogueComponent.css';
import ActionAreaCard from '../atoms/common/card/card';
import ProductNameInput from '../atoms/inputs/productNameInput/ProductNameInput';
import { useAuctionsService } from '../../hooks/auctions/useAuctionsService';
import { AllegroCatalogueProduct } from '../../interfaces/platforms/getAllegroCatalogueResponse';
import SearchButton from '../atoms/buttons/searchButton/searchButton';
import AllegroSearchInput from '../atoms/inputs/allegroSearchProductInput/allegroSearchProductInput';
import { CircularProgress } from '@mui/material';

const AllegroCatalogueComponent: React.FC = () => {
  const [inputValue, setInputValue] = useState<string>('');
  const { auctionsService } = useAuctionsService();
  const [productCatalogue, setProductCatalogue] = useState<AllegroCatalogueProduct[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  // const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
  //     const value = e.target.value;
  //     setInputValue(value);
  // };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setIsLoading(true);
    auctionsService.getAllegoProductCatalogueByPhrase(inputValue).then((res) => {
      if (res && res.products) {
        setProductCatalogue(res.products);
      } else {
        setProductCatalogue([]);
      }
      setIsLoading(false);
    });
  };

  const handleChange = (name: string, value: number | string) => {
    setInputValue(value as string);
  };

  return (
    <div className="allegroCatalogueComponent">
      <div className="searchRow">
        <AllegroSearchInput
          value={inputValue}
          disabled={false}
          onChange={handleChange}
          error={null}
          onSubmit={handleSubmit}
        />
      </div>

      {isLoading && <CircularProgress />}

      {productCatalogue.length > 0 && !isLoading && (
        <div className="productList">
          {productCatalogue.map((product, index) => (
            <div className="productCard" key={index}>
              <ActionAreaCard
                title={product.name}
                imageUrl={product.images[0]?.url} // niektore produkty z allegro nie maja zdjec, wiec mozna wtedy zaladowac jakis nasz obraz, zeby nie pokazywalo alta
              />
            </div>
          ))}
        </div>
      )}

      <div></div>
    </div>
  );
};

export default AllegroCatalogueComponent;
