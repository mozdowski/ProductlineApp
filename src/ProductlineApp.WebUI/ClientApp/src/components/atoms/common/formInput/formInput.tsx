import React, { ChangeEvent } from 'react';

interface FormInputProps {
  name: string;
  value: any;
  onChange: (name: string, value: any) => void;
  disabled?: boolean;
  error?: any;
  [key: string]: any;
}

const FormInput: React.FC<FormInputProps> = ({
  name,
  value,
  onChange,
  disabled,
  error,
  ...props
}) => {
  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    console.log(name);
    console.log(event.target.value);
    onChange(name, event.target.value);
  };

  return (
    <div>
      <input value={value} onChange={handleChange} disabled={disabled} {...props} />
      {error && <span className="error">{error}</span>}
    </div>
  );
};

export default FormInput;
