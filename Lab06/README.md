Luồng request: HTTP Request → Gọi phương thức → Truyền SQL → Execute → Mapped Objects → JSON Response

---

## Các bước thực hiện

### Bước 1 — Tạo Database và Table
Chạy script SQL tạo `SchoolDB`, bảng `Students` (Id, Name, Age), và insert dữ liệu mẫu.

### Bước 2 — Tạo ASP.NET Web API Project
```bash
dotnet new webapi -n DapperApi
cd DapperApi
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```
Tạo thêm 2 thư mục: `Models/` và `Repositories/`

### Bước 3 — Tạo Model Class
Tạo `Models/Student.cs` với 3 property: `Id`, `Name`, `Age`.

### Bước 4 — Cấu hình Connection String
Thêm `ConnectionStrings.DefaultConnection` vào `appsettings.json`.

### Bước 5 — Tạo Repository Interface
Tạo `Repositories/IStudentRepository.cs` với 5 method: `GetAll`, `GetById`, `Create`, `Update`, `Delete`.

### Bước 6 — Implement Repository với Dapper
Tạo `Repositories/StudentRepository.cs`, inject `IConfiguration`, dùng `db.Query<T>()`, `db.QuerySingleOrDefault<T>()`, `db.Execute()` để thao tác DB.

### Bước 7 — Đăng ký Dependency Injection
Trong `Program.cs`, thêm:
```csharp
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
```

### Bước 8 — Tạo Controller
Tạo `Controllers/StudentsController.cs` với đầy đủ 5 endpoint CRUD.

| Method | Endpoint | Mô tả | HTTP Status |
|--------|----------|-------|-------------|
| GET | `/api/students` | Lấy tất cả sinh viên | 200 OK |
| GET | `/api/students/{id}` | Lấy 1 sinh viên | 200 / 404 |
| POST | `/api/students` | Thêm sinh viên mới | 201 Created |
| PUT | `/api/students` | Cập nhật sinh viên | 204 No Content |
| DELETE | `/api/students/{id}` | Xoá sinh viên | 204 No Content |

### Bước 9 — Chạy và kiểm tra
```bash
dotnet run
```
Mở Swagger tại `https://localhost:5001/swagger`

---

## Bài tập mở rộng

### Bài tập 1 — Thêm trường Email
1. `ALTER TABLE Students ADD Email NVARCHAR(150);`
2. Thêm property `Email` vào `Student.cs`
3. Cập nhật tất cả SQL query trong repository
4. Thêm endpoint tìm kiếm: `GET /api/students/search?name=An`

### Bài tập 2 — Quan hệ Many-to-Many (JOIN)
1. Tạo bảng `Courses` và `StudentCourses`
2. Tạo model `StudentWithCourses` với `List<Course>`
3. Implement `GetAllWithCourses()` dùng Dapper Multi-Mapping
4. Thêm endpoint: `GET /api/students/courses`
5. Test bằng Swagger

---

## Câu hỏi thảo luận

1. **Query vs Execute**: Sự khác nhau giữa `db.Query<T>()` và `db.Execute()` trong Dapper là gì? Khi nào dùng cái nào?

2. **Repository Pattern**: Tại sao cần tách logic database ra khỏi Controller? Lợi ích là gì khi test?

3. **Dapper vs EF Core**: So sánh ưu/nhược điểm của Dapper với Entity Framework Core. Khi nào nên chọn Dapper?

4. **Connection Management**: Tại sao mỗi phương thức trong Repository tạo `IDbConnection` mới thay vì dùng chung một connection?

5. **Dependency Injection**: Giải thích sự khác nhau giữa `AddScoped`, `AddTransient` và `AddSingleton`. Cái nào phù hợp cho Repository?