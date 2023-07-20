import * as React from 'react';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import ListItemText from '@mui/material/ListItemText';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import './formSelect.css';

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
const SelectStyle = {
  color: '#757575',
  fontFamily: 'Poppins, sans-serif',
  fontSize: '12px',
  fontWeight: 300,
  backgroundColor: '#f8f8f8',
  border: '1px solid #d8d8d8',
  borderRadius: '8px',
  padding: 'inherit',
  '& fieldset': {
    border: 'none',
  },
  '& .MuiListItemText-primary': {
    font: 'inherit',
  },
};

interface FormSelectProps {
  name: string;
  value: any;
  onChange: (name: string, value: string) => void;
  options: { label: string; value: string | number }[];
  error?: string;
  inputHeight?: number;
  inputWidth?: number;
  optionsWidth?: number;
}

const FormSelect = ({
  name,
  value,
  onChange,
  options,
  error,
  inputHeight,
  inputWidth,
  optionsWidth,
}: FormSelectProps) => {
  const [selectedValue, setSelectedValue] = React.useState<string>(value);

  const handleChange = (event: SelectChangeEvent<typeof selectedValue>) => {
    const {
      target: { value },
    } = event;
    setSelectedValue(value);
    onChange(name, value);
  };

  return (
    <div className="formSelect">
      <FormControl>
        <Select
          labelId="demo-multiple-checkbox-label"
          id="demo-multiple-checkbox"
          value={selectedValue}
          onChange={handleChange}
          MenuProps={{
            PaperProps: {
              style: {
                maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
                width: optionsWidth ? optionsWidth : inputWidth ? inputWidth : 250,
              },
            },
          }}
          sx={{
            ...SelectStyle,
            font: '12px Poppins, sans-serif',
            width: inputWidth ? inputWidth : '316px',
            height: inputHeight ? inputHeight : '44px',
          }}
        >
          {options.map((option) => (
            <MenuItem key={option.value} value={option.value}>
              <ListItemText primary={option.label} />
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      {error && <span className="formSelectError">{error}</span>}
    </div>
  );
};

export { FormSelect };
