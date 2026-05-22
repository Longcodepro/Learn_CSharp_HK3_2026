# Lab02 – Console Calculator (C#)

**Môn:** Lập trình C# | **Thời gian:** 60 phút

## Mục tiêu

- Khai báo và sử dụng method trong C#
- Sử dụng tham số `out` để trả về nhiều giá trị
- Xử lý input an toàn bằng `int.TryParse`
- Dùng string interpolation (`$"..."`) để định dạng chuỗi
- Tách logic thành các hàm nhỏ, rõ ràng

---

## Mô tả bài toán

Viết chương trình console thực hiện:

1. Nhập 2 số nguyên từ người dùng
2. Hiển thị menu chọn phép toán:
   - `[A]` – Cộng (Add)
   - `[S]` – Trừ (Subtract)
   - `[M]` – Nhân (Multiply)
   - `[D]` – Chia (Divide)
3. In kết quả theo định dạng: `number1 <operator> number2 = result`  
   Ví dụ: `10 + 5 = 15`
4. Xử lý lỗi:
   - Nhập không phải số nguyên → thông báo lỗi và thoát
   - Chia cho 0 → thông báo lỗi
   - Chọn ký tự không hợp lệ → thông báo lỗi

---

## Yêu cầu kỹ thuật

### Bắt buộc định nghĩa 3 hàm sau:

| Hàm | Chữ ký | Mục đích |
|-----|--------|----------|
| `TryReadInt` | `bool TryReadInt(string prompt, out int result)` | Đọc số nguyên an toàn |
| `PrintFinalEquation` | `void PrintFinalEquation(int n1, int n2, int result, string @operator)` | In kết quả phép toán |
| `EqualsCaseInsensitive` | `bool EqualsCaseInsensitive(string left, string right)` | So sánh chuỗi không phân biệt hoa/thường |

### Lưu ý

- ❌ Không dùng `int.Parse` trực tiếp (dễ crash khi nhập sai)
- ✅ Dùng `int.TryParse` bên trong `TryReadInt`
- ✅ Dùng `$"..."` thay vì cộng chuỗi `+`
- Dùng `@operator` vì `operator` là từ khóa trong C#

---

## Mô tả các hàm

### `TryReadInt`

```csharp
bool TryReadInt(string prompt, out int result)
```

- Hiển thị `prompt`, đọc input từ người dùng
- Nếu hợp lệ → ghi vào `result`, trả về `true`
- Nếu không hợp lệ → in thông báo lỗi, trả về `false`

### `PrintFinalEquation`

```csharp
void PrintFinalEquation(int n1, int n2, int result, string @operator)
```

- In kết quả dạng: `n1 <operator> n2 = result`
- Dùng string interpolation: `$"{n1} {@operator} {n2} = {result}"`

### `EqualsCaseInsensitive`

```csharp
bool EqualsCaseInsensitive(string left, string right)
    => left.ToUpper() == right.ToUpper();
```

- So sánh hai chuỗi, bỏ qua hoa/thường
- `"a"` == `"A"` → `true`

---

## Ví dụ chạy chương trình

```
Hello!
Nhap so thu nhat:
> 10
Nhap so thu hai:
> 5
Ban muon thuc hien phep tinh nao?
[A]dd numbers
[S]ubtract numbers
[M]ultiply numbers
[D]ivide numbers
> a
10 + 5 = 15
Nhan phim bat ky de dong...
```

```
Hello!
Nhap so thu nhat:
> abc
'abc' is not a valid number!
```

---

## Thang điểm

| # | Tiêu chí | Điểm |
|---|----------|------|
| 1 | Chương trình chạy được, không crash | 2.0 |
| 2 | Hàm `TryReadInt` hoạt động đúng | 2.0 |
| 3 | Hàm `PrintFinalEquation` in đúng định dạng | 1.5 |
| 4 | Hàm `EqualsCaseInsensitive` đúng | 1.0 |
| 5 | Xử lý chia cho 0 | 1.0 |
| 6 | Xử lý lựa chọn không hợp lệ | 1.0 |
| 7 | Code sạch, có comment | 1.5 |
| | **Tổng** | **10.0** |