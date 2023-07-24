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
    onChange(name, event.target.value);
  };

  return (
    <>
      <input value={value} onChange={handleChange} disabled={disabled} {...props} />
      {error && <span className="error">{error}</span>}
    </>
  );
};

export default FormInput;
