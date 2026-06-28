import { useState, type FormEvent } from 'react'
import InputField from './InputField'

export interface LoginPayload {
  username: string
  password: string
}

type SubmitHandler = (payload: LoginPayload) => Promise<void> | void

interface LoginFormProps {
  title: string
  onSubmit: SubmitHandler
  isSubmitting?: boolean
}

interface LoginErrors {
  username?: string
  password?: string
}

function LoginForm({
  title,
  onSubmit,
  isSubmitting = false,
}: LoginFormProps) {
  const [username, setUsername] = useState<string>('')
  const [password, setPassword] = useState<string>('')
  const [errors, setErrors] = useState<LoginErrors>({})

  const validate = (): LoginErrors => {
    const newErrors: LoginErrors = {}

    if (!username.trim()) {
      newErrors.username = 'Vui lòng nhập tên đăng nhập'
    }

    if (!password.trim()) {
      newErrors.password = 'Vui lòng nhập mật khẩu'
    } else if (password.length < 4) {
      newErrors.password = 'Mật khẩu phải có tối thiểu 4 ký tự'
    }

    return newErrors
  }

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    const validationErrors = validate()
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors)
      return
    }

    setErrors({})
    void onSubmit({ username: username.trim(), password })
  }

  return (
    <form className="login-form" onSubmit={handleSubmit} noValidate>
      <header className="form-header">
        <span className="eyebrow">Chào mừng trở lại</span>
        <h1 className="form-title">{title}</h1>
        <p>Nhập thông tin tài khoản để tiếp tục.</p>
      </header>

      <InputField
        label="Tên đăng nhập"
        type="text"
        value={username}
        onChange={(event) => {
          setUsername(event.target.value)
          setErrors((current) => ({ ...current, username: undefined }))
        }}
        placeholder="Nhập tên đăng nhập..."
        error={errors.username}
        autoComplete="username"
      />

      <InputField
        label="Mật khẩu"
        type="password"
        value={password}
        onChange={(event) => {
          setPassword(event.target.value)
          setErrors((current) => ({ ...current, password: undefined }))
        }}
        placeholder="Nhập mật khẩu..."
        error={errors.password}
        autoComplete="current-password"
      />

      <button type="submit" className="login-btn" disabled={isSubmitting}>
        {isSubmitting ? (
          <>
            <span className="spinner" aria-hidden="true" />
            Đang xử lý...
          </>
        ) : (
          'Đăng nhập'
        )}
      </button>

      <p className="demo-hint">
        Tài khoản mẫu: <strong>admin</strong> / <strong>1234</strong>
      </p>
    </form>
  )
}

export default LoginForm
