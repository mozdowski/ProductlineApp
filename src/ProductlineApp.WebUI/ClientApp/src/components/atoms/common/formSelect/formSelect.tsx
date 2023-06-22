import { ChangeEvent } from 'react';

interface FormSelectProps {
  name: string;
  value: string;
  onChange: (name: string, value: string) => void;
  options: { label: string; value: string | number }[];
  error?: string;
  [key: string]: any;
}

const FormSelect = ({ name, value, onChange, options, error, ...props }: FormSelectProps) => {
  const handleChange = (event: ChangeEvent<HTMLSelectElement>) => {
    const selectedValue = event.target.value;
    onChange(name, selectedValue);
  };

  return (
    <div>
      <select value={value} onChange={handleChange} {...props}>
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
      {error && <span className="error">{error}</span>}
    </div>
  );
};

export { FormSelect };
