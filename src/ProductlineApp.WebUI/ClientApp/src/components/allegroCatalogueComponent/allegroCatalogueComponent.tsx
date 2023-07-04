import React, { useState, useEffect, useRef, ChangeEvent } from 'react';
import './allegroCatalogueComponent.css';
import ActionAreaCard from '../atoms/common/card/card';
import { useAuctionsService } from '../../hooks/auctions/useAuctionsService';
import { AllegroCatalogueProduct } from '../../interfaces/platforms/getAllegroCatalogueResponse';

const AllegroCatalogueComponent: React.FC = () => {
  const [inputValue, setInputValue] = useState('');
  const dropdownRef = useRef<HTMLDivElement>(null);
  const { auctionsService } = useAuctionsService();
  const [productCatalogue, setProductCatalogue] = useState<AllegroCatalogueProduct[]>([]);

  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setInputValue(value);
  };

  const handleSubmit = () => {
    auctionsService.getAllegoProductCatalogueByPhrase(inputValue).then((res) => {
      if (res && res.products) {
        setProductCatalogue(res.products);
      } else {
        setProductCatalogue([]);
      }
    });
  };

  return (
    <div ref={dropdownRef} className="dropdown">
      <input
        type="text"
        value={inputValue}
        placeholder={'wpis fraze'}
        onChange={handleInputChange}
      />

      <a onClick={handleSubmit}>search</a>

      <div className="dropdown-options">
        {productCatalogue.map((product, index) => (
          <div className="dropdown-option" key={index}>
            <ActionAreaCard
              title={product.name}
              imageUrl={product.images[0]?.url} // niektore produkty z allegro nie maja zdjec, wiec mozna wtedy zaladowac jakis nasz obraz, zeby nie pokazywalo alta
              description="opis"
            />
          </div>
        ))}
      </div>
    </div>
  );
};

export default AllegroCatalogueComponent;
