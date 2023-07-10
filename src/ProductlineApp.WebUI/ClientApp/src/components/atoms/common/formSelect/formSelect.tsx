import * as React from 'react';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import ListItemText from '@mui/material/ListItemText';
import Select, { SelectChangeEvent } from '@mui/material/Select';

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
  width: '316px',
  height: '44px',
  color: '#757575',
  fontFamily: 'Poppins, sans-serif',
  fontSize: '12px',
  fontWeight: 300,
  backgroundColor: '#f8f8f8',
  border: '1px solid #d8d8d8',
  borderRadius: '8px',
  padding: 'inherit',
  margin: 'auto',
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
}

const FormSelect = ({ name, value, onChange, options, error }: FormSelectProps) => {
  const [selectedValue, setSelectedValue] = React.useState<string>(value);

  const handleChange = (event: SelectChangeEvent<typeof selectedValue>) => {
    const {
      target: { value },
    } = event;
    setSelectedValue(value);
    onChange(name, value);
  };

  return (
    <div>
      <FormControl>
        <Select
          labelId="demo-multiple-checkbox-label"
          id="demo-multiple-checkbox"
          value={selectedValue}
          onChange={handleChange}
          MenuProps={MenuProps}
          sx={{ ...SelectStyle, font: '12px Poppins, sans-serif' }}
        >
          {options.map((option) => (
            <MenuItem key={option.value} value={option.value}>
              <ListItemText primary={option.label} />
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </div>
  );

  // return (
  //   <div className="selectDiv">
  //     <select value={value} onChange={handleChange} {...props}>
  //       {options.map((option) => (
  //         <option key={option.value} value={option.value}>
  //           {option.label}
  //         </option>
  //       ))}
  //     </select>
  //     {error && <span className="error">{error}</span>}
  //   </div>
  // );
};

export { FormSelect };
