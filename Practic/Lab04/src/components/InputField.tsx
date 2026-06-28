import type { ChangeEventHandler } from 'react'

type InputType = 'text' | 'password'

interface InputFieldProps {
  label: string
  type: InputType
  value: string
  onChange: ChangeEventHandler<HTMLInputElement>
  placeholder?: string
  error?: string
  autoComplete?: string
}

function InputField({
  label,
  type,
  value,
  onChange,
  placeholder,
  error,
  autoComplete,
}: InputFieldProps) {
  const inputId = `login-${type}`
  const errorId = `${inputId}-error`

  return (
    <div className="input-group">
      <label className="input-label" htmlFor={inputId}>
        {label}
      </label>
      <input
        id={inputId}
        type={type}
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        autoComplete={autoComplete}
        className={`input-field ${error ? 'input-error' : ''}`}
        aria-invalid={Boolean(error)}
        aria-describedby={error ? errorId : undefined}
      />
      {error && (
        <span className="error-msg" id={errorId}>
          {error}
        </span>
      )}
    </div>
  )
}

export default InputField

