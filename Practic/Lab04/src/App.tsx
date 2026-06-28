import { useState } from 'react'
import LoginForm, { type LoginPayload } from './components/LoginForm'

type LoginStatus = 'idle' | 'loading' | 'success' | 'error'

interface LoginResponse {
  message: string
}

function fakeLoginAPI(
  username: string,
  password: string,
): Promise<LoginResponse> {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (username === 'admin' && password === '1234') {
        resolve({ message: `Xin chào, ${username}!` })
      } else {
        reject(new Error('Sai tài khoản hoặc mật khẩu!'))
      }
    }, 1500)
  })
}

function App() {
  const [status, setStatus] = useState<LoginStatus>('idle')
  const [message, setMessage] = useState<string>('')
  const [loggedUser, setLoggedUser] = useState<string | null>(null)

  const handleLogin = async ({
    username,
    password,
  }: LoginPayload): Promise<void> => {
    setStatus('loading')
    setMessage('')

    try {
      const result = await fakeLoginAPI(username, password)
      setStatus('success')
      setMessage(result.message)
      setLoggedUser(username)
    } catch (error) {
      const errorMessage =
        error instanceof Error ? error.message : 'Đăng nhập thất bại'
      setStatus('error')
      setMessage(errorMessage)
    }
  }

  const handleLogout = () => {
    setStatus('idle')
    setMessage('')
    setLoggedUser(null)
  }

  return (
    <main className="app-shell">
      <section className="brand-panel" aria-label="Giới thiệu">
        <div className="brand-mark">L04</div>
        <div className="brand-copy">
          <span className="eyebrow">React + TypeScript</span>
          <h2>Một form nhỏ, đầy đủ luồng xử lý.</h2>
          <p>
            Props truyền dữ liệu, state quản lý giao diện và Promise mô phỏng một
            request đăng nhập thực tế.
          </p>
        </div>
        <div className="concept-list">
          <span>Props</span>
          <span>useState</span>
          <span>Promise</span>
          <span>async / await</span>
        </div>
      </section>

      <section className="form-panel">
        {status === 'success' ? (
          <div className="success-card" role="status">
            <div className="success-icon" aria-hidden="true">
              ✓
            </div>
            <span className="eyebrow">Đăng nhập thành công</span>
            <h1>{message}</h1>
            <p>
              Bạn đang đăng nhập với tài khoản <strong>{loggedUser}</strong>.
            </p>
            <button type="button" className="logout-btn" onClick={handleLogout}>
              Đăng xuất
            </button>
          </div>
        ) : (
          <div className="form-wrapper">
            <LoginForm
              title="Đăng nhập"
              onSubmit={handleLogin}
              isSubmitting={status === 'loading'}
            />
            {status === 'error' && (
              <div className="api-error" role="alert">
                {message}
              </div>
            )}
          </div>
        )}
      </section>
    </main>
  )
}

export default App

