# Lab03 – ASP.NET Core Web API

## Đề bài

Xây dựng REST API quản lý người dùng bằng ASP.NET Core theo kiến trúc ba tầng
`Controller – Service – Repository`. Dữ liệu được lưu trong `List<User>` ở bộ nhớ,
không sử dụng cơ sở dữ liệu.

### Yêu cầu

1. Tạo solution `UsersApp` và project Web API `UsersApp.Api`.
2. Tổ chức project thành các thư mục `Models`, `Repositories`, `Services`,
   `Controllers`.
3. Model `User` gồm:
   - `Id`: `long`
   - `Name`: `string`
4. Repository:
   - Khai báo interface `IUsersRepository`.
   - Cài đặt `UsersRepository` bằng `List<User>`.
   - Hỗ trợ lấy tất cả, lấy theo ID và thêm người dùng.
5. Service:
   - Inject `IUsersRepository` qua constructor.
   - Kiểm tra người dùng tồn tại khi tìm theo ID.
   - Không cho phép thêm tên rỗng hoặc chỉ chứa khoảng trắng.
6. Controller cung cấp các endpoint:

   | Method | URL | Kết quả |
   | --- | --- | --- |
   | `GET` | `/users` | Danh sách người dùng, HTTP 200 |
   | `GET` | `/users/{id}` | Người dùng, HTTP 200 hoặc 404 |
   | `POST` | `/users` | Thêm người dùng, HTTP 201 hoặc 400 |

7. Đăng ký Dependency Injection trong `Program.cs` bằng `AddScoped`.
8. Cấu hình OpenAPI và Swagger UI tại `/swagger` trong môi trường Development.
9. Có ba người dùng mẫu: Nguyễn Văn An, Trần Thị Bình và Lê Văn Cường.

## Chạy ứng dụng

```bash
dotnet run --project UsersApp.Api
```

Sau khi chạy, dùng URL được in trong terminal để truy cập:

- `/users` để lấy danh sách người dùng.
- `/swagger` để mở Swagger UI.

> Đề gốc yêu cầu .NET 10. Project target .NET 9 để tương thích với SDK 9.0.203
> đang được cài đặt trên máy.

## Câu hỏi tự kiểm tra

1. `UsersService` phụ thuộc vào interface để tách business logic khỏi cách lưu dữ
   liệu và cho phép thay implementation mà không sửa service.
2. `Scoped` tạo một instance mỗi HTTP request; `Transient` tạo mới mỗi lần resolve;
   `Singleton` dùng một instance trong toàn bộ vòng đời ứng dụng.
3. Swagger UI đọc tài liệu OpenAPI JSON. Chỉ mở Swagger trong Development giúp
   tránh công khai chi tiết API ngoài ý muốn ở production.
4. Swagger UI và `curl` gửi cùng loại HTTP request; Swagger có giao diện tương tác,
   còn `curl` phù hợp với terminal và script tự động.
