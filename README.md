# C# – Theory & Practice

Repository lưu bài học và bài thực hành C# trong học kỳ 3 (2025-2026). Nội dung đi từ cú
pháp nền tảng, OOP và collections đến ASP.NET Core Web API, Dapper, SQL Server,
React và TypeScript.

## Cấu trúc repository

```text
.
├── Theory/
│   ├── Basic/              Cú pháp, ép kiểu, class và inheritance
│   ├── Lab01/              Namespace và mô hình tài khoản ngân hàng
│   ├── Lab02/              Console Calculator
│   ├── Lab03/              Array, ArrayList và List
│   └── Lab04/              Exception handling và polymorphism
└── Practic/
    ├── Lab01/              OOP và Collections qua 5 bài toán
    ├── Lab02/              ASP.NET Web API, Dapper và SQL Server
    ├── Lab03/              REST API theo kiến trúc 3 tầng
    ├── Lab04/              React Login Interface
    ├── Test/               Console Quiz Application
    └── Midterm/            Bài tập tổng hợp giữa kỳ
```

## Theory

### Basic

Ôn casting, class, constructor, đóng gói và kế thừa bằng C# trên .NET 8.

Tài liệu: [Basic.md](Theory/Basic/Basic.md)

### Lab01

Tìm hiểu cách tổ chức namespace, import bằng `using` và mô phỏng chức năng
chuyển tiền.

Tài liệu: [Lab01.md](Theory/Lab01/Lab01.md)

### Lab02

Xây dựng Console Calculator có menu, kiểm tra input và xử lý phép tính.

Tài liệu: [Lab02.md](Theory/Lab02/Lab02.md)

### Lab03

So sánh và thực hành `Array`, `ArrayList`, `List<T>` cùng biểu thức lambda.

Tài liệu: [Lab03.md](Theory/Lab03/Lab03.md)

### Lab04

Thực hành xử lý ngoại lệ, `virtual`, `override`, `new` và tính đa hình.

Tài liệu: [Lab04.md](Theory/Lab04/Lab04.md)

## Practice

### Lab01

Giải năm bài toán quản lý thư viện, sinh viên, kho hàng, tài khoản và nhân vật
game bằng OOP và Collections trên .NET 8.

Tài liệu: [Lab01.md](Practic/Lab01/Lab01.md)

### Lab02

Xây dựng Web API CRUD sinh viên và khóa học bằng ASP.NET Core, Repository
Pattern, Dapper, SQL Server và Swagger.

Tài liệu: [Lab02.md](Practic/Lab02/Lab02.md)

### Lab03

Xây dựng API quản lý người dùng theo kiến trúc Controller–Service–Repository,
lưu dữ liệu trong RAM và cung cấp Swagger UI.

Tài liệu: [Lab03.md](Practic/Lab03/Lab03.md)

### Lab04

Xây dựng form đăng nhập React với validation và các trạng thái
`idle/loading/success/error` bằng Vite và TypeScript.

Tài liệu: [Lab04.md](Practic/Lab04/Lab04.md)

### Test

Ứng dụng trắc nghiệm Console sử dụng interface, đa hình, generic và kiểm tra
dữ liệu nhập.

Tài liệu: [Test.md](Practic/Test/Test.md)

### Midterm

Bài tập tổng hợp thuật toán, delegate, LINQ, Repository Pattern và truy vấn
SQL Server bằng Dapper.

Tài liệu: [Midterm.md](Practic/Midterm/Midterm.md)

## Yêu cầu môi trường

- .NET SDK 9.0 trở lên. SDK này có thể build các project target .NET 8 và .NET 9.
- Node.js và npm cho `Practic/Lab04`.
- SQL Server cho `Practic/Lab02` và bài Dapper trong `Practic/Midterm`.

Kiểm tra môi trường:

```bash
dotnet --version
node --version
npm --version
```

## Chạy project

Project Console hoặc Web API:

```bash
dotnet run --project <duong-dan-file-csproj>
```

Ví dụ:

```bash
dotnet run --project Practic/Test/Lab08.csproj
dotnet run --project Practic/Lab03/UsersApp.Api/UsersApp.Api.csproj
```

React:

```bash
cd Practic/Lab04
npm install
npm run dev
```

## Cấu hình cơ sở dữ liệu

Connection string trong repository chỉ chứa `YOUR_PASSWORD`. Không commit mật
khẩu thật lên GitHub.

- Lab02 hỗ trợ override bằng biến môi trường
  `ConnectionStrings__DefaultConnection`.
- Midterm đọc `Practic/Midterm/appsettings.json`; cần thay placeholder trên máy
  local trước khi chạy bài 4 và hoàn nguyên trước khi commit.

## Trạng thái kiểm tra

- Tất cả project trong `Practic` build thành công, không có warning hoặc error.
- Frontend `Practic/Lab04` vượt qua TypeScript check và Vite production build.
- `Theory/Lab01` và `Theory/Lab02` build thành công.
- `Theory/Basic` và `Theory/Lab04` chứa nhiều entry point phục vụ nhiều bài độc
  lập; cần chọn startup object trước khi chạy.
- `Theory/Lab03` còn nhiều entry point và một lỗi khởi tạo `List` trong
  `LearnList.cs`.

## Quy ước repository

- Tài liệu riêng của từng bài mang tên thư mục, ví dụ `Lab01.md`, `Test.md`.
- `README.md` chỉ dùng tại root để GitHub hiển thị trang tổng quan.
- Không commit `bin`, `obj`, `node_modules`, `dist`, file IDE, cache hoặc secret.
- Các file PDF là đề bài/tài liệu gốc và được giữ cùng lab tương ứng.
- `package-lock.json`, `.csproj`, `.sln` và file cấu hình mẫu cần được commit để
  tái tạo môi trường.
