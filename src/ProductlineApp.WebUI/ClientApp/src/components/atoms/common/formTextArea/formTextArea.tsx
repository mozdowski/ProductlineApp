import React, { ChangeEvent } from 'react';

interface FormTextareaProps {
  name: string;
  value: string;
  onChange: (name: string, value: string) => void;
  error?: string;
  [key: string]: any;
}

const FormTextarea = ({ name, value, onChange, error, ...props }: FormTextareaProps) => {
  const handleChange = (event: ChangeEvent<HTMLTextAreaElement>) => {
    onChange(name, event.target.value as string);
  };

  return (
    <div>
      <textarea value={value} onChange={handleChange} {...props} />
      {error && <span className="error">{error}</span>}
    </div>
  );
};

export { FormTextarea };
