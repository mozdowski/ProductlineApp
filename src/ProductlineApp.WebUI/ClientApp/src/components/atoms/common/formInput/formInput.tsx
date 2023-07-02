import React, { ChangeEvent } from 'react';

interface FormInputProps<T> {
  name: string;
  value: T;
  onChange: (name: string, value: T) => void;
  disabled?: boolean;
  error?: any;
  [key: string]: any;
}

const FormInput = <T extends string | number>({
  name,
  value,
  onChange,
  disabled,
  error,
  ...props
}: FormInputProps<T>) => {
  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    onChange(name, event.target.value as T);
  };

  return (
    <div>
      <input value={value} onChange={handleChange} disabled={disabled} {...props} />
      {error && <span className="error">{error}</span>}
    </div>
  );
};

export default FormInput;
