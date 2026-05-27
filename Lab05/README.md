# Lab05 – OOP & Collections (C#)

**Môn:** Lập trình C# | **Giảng viên:** Phieu Tu

## Nội dung

Thực hành OOP và Collections (List, Dictionary) thông qua 5 bài tập thực tế.

---

## Bài 1: Library Management System

**Mô tả:** Quản lý thư viện với `class Book` và `List<Book>`.

**Yêu cầu cơ bản:**
- Class `Book`: `Title`, `Author`, `ISBN`, `YearPublished`
- Constructor đầy đủ tham số
- Tạo `List<Book>` chứa ít nhất 3 cuốn sách, in bằng `foreach`

**Câu hỏi 01:**
- Q1. Validation `YearPublished` (1000 → năm hiện tại)
- Q2. Constructor overload (0 tham số, 2 tham số)
- Q3. Override `Equals()` so sánh sách theo ISBN

**Câu hỏi 02:**
- A1. Implement `IComparable<Book>` sắp xếp theo năm xuất bản
- A2. Method `GetBooksAfterYear(int year)` (không dùng LINQ)
- A3. Đếm sách theo tác giả, lưu vào `Dictionary<string, int>`

---

## Bài 2: Student Management

**Mô tả:** Quản lý sinh viên bằng `Dictionary<string, Student>`.

**Yêu cầu cơ bản:**
- Class `Student`: `Id`, `Name`, `Grade`
- Dictionary với key = `Name`, value = `Student`
- Thêm 3 sinh viên và in thông tin

**Câu hỏi 01:**
- Q1. Method `AddStudentSafe()` (tránh trùng key)
- Q2. Tìm sinh viên có điểm cao nhất (dùng vòng lặp)
- Q3. Chuyển Dictionary sang `List<Student>`

**Câu hỏi 02:**
- A1. Generic class `Repository<TKey, TValue>`
- A2. Implement indexer truy cập `Student` theo `Name`
- A3. Method in sinh viên có `Grade ≥` giá trị cho trước

---

## Bài 3: Product Inventory

**Mô tả:** Quản lý kho sản phẩm bằng `List<Product>`.

**Yêu cầu cơ bản:**
- Class `Product`: `Id`, `Name`, `Price`, `Quantity`
- Method `GetTotalValue()`
- Tạo List chứa 5 sản phẩm

**Câu hỏi 01:**
- Q1. Tìm sản phẩm tồn kho thấp hơn ngưỡng cho trước
- Q2. Tính tổng giá trị kho
- Q3. Tìm sản phẩm có giá trị cao nhất

**Câu hỏi 02:**
- A1. Class `Inventory` implement `IEnumerable<Product>`
- A2. Method `UpdateStock()`
- A3. Duyệt `Inventory` bằng `foreach`

---

## Bài 4: Bank Account

**Mô tả:** Hệ thống tài khoản ngân hàng với `List<Transaction>`.

**Yêu cầu cơ bản:**
- Class `BankAccount`: `AccountNumber`, `Holder`, `Balance`
- Class `Transaction`: `Type`, `Amount`, `Date`
- Implement `Deposit`, `Withdraw`, in lịch sử giao dịch

**Câu hỏi 01:**
- Q1. Method `Transfer()` giữa 2 tài khoản
- Q2. Kiểm tra số dư hợp lệ khi rút tiền
- Q3. Dùng `enum AccountType`

**Câu hỏi 02:**
- A1. Refactor bằng `abstract class BankAccount`
- A2. Override `Withdraw()` cho từng loại tài khoản
- A3. Lưu lịch sử giao dịch bằng `List<Transaction>`

---

## Bài 5: Game Character

**Mô tả:** Quản lý nhân vật game với `List` và `Dictionary`.

**Yêu cầu cơ bản:**
- Class `Character`: `Name`, `Level`, `Health`
- Inventory: `Dictionary<string, int>`
- Skills: `List<string>`

**Câu hỏi 01:**
- Q1. Kiểm tra item có trong inventory không
- Q2. Không cho học trùng skill
- Q3. Method `LevelUp()` tăng `Level` và `Health`

**Câu hỏi 02:**
- A1. Implement `IComparer<Character>` sắp xếp Level giảm dần
- A2. Deep copy `List` và `Dictionary`
- A3. So sánh hai `Character`

---

## Kiến thức áp dụng

- OOP: class, constructor, method, `override`, `abstract`, `enum`
- Collections: `List<T>`, `Dictionary<TKey, TValue>`
- Interface: `IComparable<T>`, `IComparer<T>`, `IEnumerable<T>`
- Generic class, indexer, deep copy