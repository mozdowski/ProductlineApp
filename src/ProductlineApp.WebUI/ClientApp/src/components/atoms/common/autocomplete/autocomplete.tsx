import * as React from 'react';
import { TextField, Autocomplete } from '@mui/material';
import './autocomplete.css';

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

const AutocompleteStyle = {
  width: '316px',
  height: '44px',
  color: '#757575',
  fontFamily: 'Poppins, sans-serif',
  fontSize: '12px',
  fontWeight: 300,
  backgroundColor: '#f8f8f8',
  border: '1px solid #d8d8d8',
  borderRadius: '8px',
  '& fieldset': {
    border: 'none',
  },
};

const TextfieldStyle = {
  width: '100%',
  '& input': {
    height: '12px',
    color: '#757575',
    fontFamily: 'Poppins, sans-serif',
    fontSize: '12px',
    fontWeight: 300,
  },
};

interface AutocompleteComboBoxProps {
  name: string;
  value: string;
  placeholder: string;
  onChange: (name: string, value: string) => void;
  options: { label: string; value: any }[];
  error?: string;
}

const AutocompleteComboBox: React.FC<AutocompleteComboBoxProps> = ({
  name,
  value,
  placeholder,
  onChange,
  options,
  error,
}) => {
  const handleChange = (event: any, value: any) => {
    onChange(name, value);
  };

  return (
    <div className="autocompleteContainer">
      <Autocomplete
        sx={AutocompleteStyle}
        id={name}
        freeSolo
        value={value}
        onChange={handleChange}
        options={options.map((option) => option.label)}
        renderInput={(params) => <TextField sx={TextfieldStyle} {...params} />}
      />
      {error && <span className="autocompleteError">{error}</span>}
    </div>
  );
};

export default AutocompleteComboBox;
