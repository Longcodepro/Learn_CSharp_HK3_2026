# Lab04 – Exception Handling & Method Overriding (C#)

## Nội dung

### Bài tập 1: Xử lý đa ngoại lệ

Viết phương thức `HandleMultipleExceptions(string input, int index)`:
- Parse `input` sang `int`, rồi truy cập mảng `{ 1, 2, 3 }` tại vị trí `index`.
- Bắt `FormatException` → in `"Invalid format."`
- Bắt `IndexOutOfRangeException` → in `"Index out of range."`

---

### Bài tập 2: Đa hình với Virtual / Override

Xây dựng hệ thống phân cấp lớp:

| Lớp    | Phương thức `MakeSound()`   |
|--------|-----------------------------|
| Animal | `"Animal makes a sound"`    |
| Dog    | `"Dog barks"` (override)    |
| Cat    | `"Cat meows"` (override)    |

---

### Bài tập 3: Câu hỏi thảo luận

**Câu 1 – Tính đa hình & kiểu tham chiếu**  
Dự đoán kết quả:
```csharp
Animal myPet = new Dog();
myPet.MakeSound();
```

**Câu 2 – `new` vs `override` (Method Hiding)**  
Phân tích sự khác biệt khi thay `override` bằng `new` trong lớp `Dog`.

**Câu 3 – Gọi virtual method trong Constructor**  
Điều gì xảy ra khi gọi virtual method bên trong constructor lớp cha rồi khởi tạo `Dog`? Tại sao đây là *bad practice*?

**Câu 4 – Exception kết hợp OOP**  
Lớp con `Dog` override `MakeSound()` và throw `NotImplementedException`. Code có hợp lệ không? Làm sao tránh crash khi duyệt `List<Animal>`?

---

## Kiến thức áp dụng

- `try / catch` với nhiều loại exception
- `virtual` / `override` / `new` trong kế thừa C#
- Tính đa hình (Polymorphism) qua kiểu tham chiếu
- Xử lý exception trong ngữ cảnh OOP

## Chạy project

Project có nhiều hàm `Main`. Chọn bài cần chạy làm startup object trong IDE trước
khi thực thi.
