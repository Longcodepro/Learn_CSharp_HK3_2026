# Midterm – Bài tập tổng hợp C#

## Mục tiêu

Bài giữa kỳ tổng hợp kiến thức về thuật toán, collections, delegate, LINQ,
Repository Pattern và Dapper.

## Nội dung

### Bài 1 – Thuật toán trên danh sách số

- Kiểm tra số dương chẵn và bội số của ba.
- Lọc số chẵn.
- Tìm bội số lớn nhất của ba.
- Tìm cặp có tổng cho trước bằng kỹ thuật two pointers.
- Tìm phần tử chung của hai danh sách đã sắp xếp.

### Bài 2 – Delegate

- Xây dựng model `Course`.
- Sử dụng custom delegate, `Func`, `Action` và `Predicate`.
- Lọc khóa học có ít nhất ba tín chỉ.

### Bài 3 – Repository và LINQ

- Xây dựng `IBooksRepository` và `BooksRepository`.
- Lấy danh sách sách, tìm theo ID và thêm sách.
- Lọc sách theo giá và lấy các sách đắt nhất.

### Bài 4 – Dapper

- Kết nối SQL Server qua `Microsoft.Data.SqlClient`.
- Truy vấn người dùng theo hậu tố, độ dài và từ khóa.
- Dùng Dapper để map kết quả SQL sang model `User`.

## Chạy project

```bash
dotnet run --project Lab09.csproj
```

Các bài 1–3 chạy không cần database. Bài 4 yêu cầu SQL Server, bảng `dbo.Users`
và connection string hợp lệ trong `appsettings.json`.

Không commit mật khẩu thật. Giá trị `YOUR_PASSWORD` chỉ là placeholder.
