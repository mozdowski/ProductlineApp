import * as React from 'react';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import ListItemText from '@mui/material/ListItemText';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import Checkbox from '@mui/material/Checkbox';

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
const MultiselectStyle = {
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
};

interface MultipleSelectCheckmarksProps {
  name: string;
  value: string | string[];
  onChange: (name: string, values: string[]) => void;
  options: { label: string; value: any }[];
  error?: string;
  [key: string]: any;
}

const MultipleSelectCheckmarks: React.FC<MultipleSelectCheckmarksProps> = ({
  name,
  value,
  onChange,
  options,
  error,
}) => {
  value = Array.isArray(value) ? value : [value];

  //   const [selectedValues, setSelectedValues] = React.useState<string[]>(
  //     Array.isArray(value) ? value : [value],
  //   );

  const [selectedOptions, setSelectedOptions] = React.useState<typeof options>(
    options.filter((x) => (value as string[]).some((v) => v === x.value)),
  );

  console.log('==========');
  console.log(selectedOptions);
  console.log(value);
  console.log(options);
  console.log(options.filter((x) => (value as string[]).some((v) => v === x.value)));

  const handleChange = (event: SelectChangeEvent<string[]>) => {
    const {
      target: { value },
    } = event;

    const values = typeof value === 'string' ? value.split(',') : value;
    const selectedOptions = options.filter((option) => values.some((v) => v === option.label));

    onChange(
      name,
      selectedOptions.map((x) => x.value),
    );
    // setSelectedValues(values);
    setSelectedOptions(selectedOptions);
  };

  return (
    <div>
      <FormControl>
        <Select
          labelId="demo-multiple-checkbox-label"
          id="demo-multiple-checkbox"
          multiple
          value={selectedOptions.map((x) => x.label)}
          onChange={handleChange}
          renderValue={(selected) => selected.join(', ')}
          MenuProps={MenuProps}
          sx={MultiselectStyle}
        >
          {options.map((option) => (
            <MenuItem key={option.value} value={option.label}>
              <Checkbox checked={selectedOptions.map((x) => x.label).indexOf(option.label) > -1} />
              <ListItemText primary={option.label} />
            </MenuItem>
          ))}
        </Select>
        {error && <span className="error">{error}</span>}
      </FormControl>
    </div>
  );
};

export default MultipleSelectCheckmarks;
