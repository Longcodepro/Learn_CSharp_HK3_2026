# Lab04 – React Login Interface

## Đề bài

Xây dựng giao diện đăng nhập bằng React, Vite và TypeScript. Bài lab tập trung vào
`props`, `useState`, `Promise`, `async/await` và khai báo kiểu TypeScript.

### Cấu trúc yêu cầu

```text
src/
├── App.tsx
├── App.css
├── main.tsx
└── components/
    ├── InputField.tsx
    └── LoginForm.tsx
```

### Yêu cầu chức năng

1. `InputField`:
   - Nhận dữ liệu từ component cha qua props.
   - Hỗ trợ input `text` và `password`.
   - Là controlled input với `value` và `onChange`.
   - Hiển thị thông báo và trạng thái lỗi.
2. `LoginForm`:
   - Nhận `title` và callback `onSubmit` qua props.
   - Dùng `useState` quản lý `username`, `password` và lỗi validation.
   - Không cho submit nếu username hoặc password trống.
   - Password phải có ít nhất 4 ký tự.
3. `App`:
   - Quản lý các trạng thái `idle`, `loading`, `success`, `error`.
   - Dùng Promise và `setTimeout(1500)` để giả lập API đăng nhập.
   - Xử lý Promise bằng `async/await` và `try/catch`.
   - Đăng nhập thành công khi username là `admin` và password là `1234`.
   - Hiển thị loading khi đang chờ, thông báo lỗi khi thất bại, màn hình chào
     mừng khi thành công và cho phép đăng xuất.

### Luồng xử lý

```text
idle → validate → loading → success
                      └──→ error → thử lại
success → đăng xuất → idle
```

## Chạy ứng dụng

```bash
npm install
npm run dev
```

Kiểm tra production build:

```bash
npm run build
```

Tài khoản mẫu: `admin` / `1234`.

