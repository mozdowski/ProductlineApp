import { useRef } from 'react';
import SearchButton from '../../buttons/searchButton/searchButton';
import FormInput from '../../common/formInput/formInput';
import './allegroSearchProductInput.css';

function AllegroSearchProductInput({
  value,
  onChange,
  error,
  disabled,
  onSubmit,
}: {
  value: string;
  onChange: (name: string, value: string) => void;
  error: any;
  disabled: boolean;
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}) {
  return (
    <form className="allegroSearchField" noValidate onSubmit={onSubmit}>
      <div className="allegroSearchInputRow">
        <FormInput
          value={value}
          onChange={onChange}
          type="text"
          id="allegroSearch"
          name="name"
          placeholder="Nazwa produktu"
          className="allegroSearchInput"
          error={error}
          disabled={disabled}
        />
        <SearchButton onClick={onSubmit} />
      </div>
    </form>
  );
}

export default AllegroSearchProductInput;
