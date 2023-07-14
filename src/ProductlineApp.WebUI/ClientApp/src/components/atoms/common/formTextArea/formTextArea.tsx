import React, { ChangeEvent } from 'react';
import './formTextArea.css';

interface FormTextareaProps {
  name: string;
  value: string;
  onChange: (name: string, value: string) => void;
  error?: string;
  [key: string]: any;
}

const FormTextarea = ({ name, value, onChange, error, ...props }: FormTextareaProps) => {
  const parser = new DOMParser();
  value = parser.parseFromString(value, 'text/html').body.textContent as string;

  const handleChange = (event: ChangeEvent<HTMLTextAreaElement>) => {
    const inputValue = event.target.value as string;
    const parsedText = parser.parseFromString(inputValue, 'text/html').body.textContent;

    onChange(name, parsedText as string);
  };

  return (
    <div>
      <textarea value={value} className="formTextarea" onChange={handleChange} {...props} />
      {error && <span className="error">{error}</span>}
    </div>
  );
};

export { FormTextarea };
