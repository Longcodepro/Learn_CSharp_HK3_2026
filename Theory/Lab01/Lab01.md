# Lab01 - Namespace cơ bản trong C#

## Nội dung đã học

Lab01 tập trung vào cách sử dụng `namespace` trong C# để tổ chức code thành các khu vực logic riêng biệt. Thay vì viết tất cả class trong một file hoặc một phạm vi duy nhất, chương trình được tách thành nhiều namespace để dễ quản lý và tái sử dụng.

## Các namespace trong Lab01

### `Lab01`

Namespace chính của chương trình, chứa class `Program` và hàm `Main`.

Trong `Program.cs`, chương trình:

- Tạo hai đối tượng khách hàng `Customer`
- Gọi phương thức nạp tiền cho từng khách hàng
- Thực hiện chuyển tiền giữa hai khách hàng
- In ra số dư sau giao dịch

### `Lab01.BankCustomer`

Namespace này chứa class `Customer`, đại diện cho một khách hàng ngân hàng.

Class `Customer` gồm:

- Thuộc tính `name` để lưu tên khách hàng
- Thuộc tính `soDu` để lưu số dư tài khoản
- Constructor mặc định và constructor có tham số
- Các phương thức:
  - `napTien()` để nạp tiền vào tài khoản
  - `rutTien()` để rút tiền
  - `nhanTien()` để nhận tiền từ người khác
  - `truTien()` để trừ tiền khi chuyển tiền
  - `xemSoDu()` để hiển thị số dư

### `Lab01.ChucNangChuyenTien`

Namespace này chứa class `ChuyenTien`, đại diện cho chức năng thực hiện giao dịch chuyển tiền.

Class `ChuyenTien` có phương thức static:

```csharp
public static void thucHienGiaoDich(Customer nguoiChuyen, Customer nguoiNhan, double soTien)
```

Phương thức này nhận vào:

- Người chuyển tiền
- Người nhận tiền
- Số tiền cần chuyển

Sau đó gọi các phương thức của class `Customer` để cộng tiền cho người nhận và trừ tiền của người chuyển.

## Cách sử dụng `using`

Trong `Program.cs`, để sử dụng các class nằm trong namespace khác, ta khai báo:

```csharp
using Lab01.BankCustomer;
using Lab01.ChucNangChuyenTien;
```

Nhờ có `using`, ta có thể viết ngắn gọn:

```csharp
Customer cusA = new Customer("Nguyen Van A", 0.0);
ChuyenTien.thucHienGiaoDich(cusA, cusB, 50000);
```

Nếu không dùng `using`, cần viết đầy đủ tên namespace:

```csharp
Lab01.BankCustomer.Customer cusA = new Lab01.BankCustomer.Customer("Nguyen Van A", 0.0);
```

## Kiến thức rút ra

- `namespace` giúp gom nhóm các class có liên quan với nhau.
- Mỗi file C# có thể khai báo namespace riêng.
- Muốn dùng class ở namespace khác thì cần thêm `using`.
- Có thể tách chương trình thành nhiều file và nhiều namespace để code rõ ràng hơn.
- `public` cho phép class hoặc method được truy cập từ namespace/file khác.
- `static` cho phép gọi method trực tiếp thông qua tên class mà không cần tạo object.

## Ví dụ tổng quát

Lab01 mô phỏng một chương trình ngân hàng đơn giản:

1. `Customer` quản lý thông tin và số dư của khách hàng.
2. `ChuyenTien` quản lý logic chuyển tiền.
3. `Program` là nơi tạo object và điều khiển luồng chạy của chương trình.

Qua bài lab này, mình hiểu cách chia code thành các namespace riêng để chương trình dễ đọc, dễ quản lý và có cấu trúc hơn.
