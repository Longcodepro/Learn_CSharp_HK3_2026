# Bài Tập C# — Generic

> Bộ bài tập thực hành Generic trong C#, từ cơ bản đến nâng cao.  
> Mục tiêu: hiểu rõ cách `<T>` hoạt động, tại sao cần Generic, và cách áp dụng vào thực tế.

---

## Mục lục

1. [Bài 1: Hộp đựng — `Box<T>`](#bài-1-hộp-đựng--boxt)
2. [Bài 2: Hoán đổi — `Swap<T>`](#bài-2-hoán-đổi--swapt)
3. [Bài 3: Stack đơn giản — `MyStack<T>`](#bài-3-stack-đơn-giản--mystackt)
4. [Bài 4: Cặp giá trị — `Pair<TFirst, TSecond>`](#bài-4-cặp-giá-trị--pairtfirst-tsecond)
5. [Bài 5: Kho lưu trữ — `IRepository<T>`](#bài-5-kho-lưu-trữ--irepositoryt)
6. [Thứ tự học đề xuất](#thứ-tự-học-đề-xuất)

---

## Bài 1: Hộp đựng — `Box<T>`

### Mô tả
Tạo một class Generic đơn giản để hiểu cách `<T>` hoạt động ở cấp độ class.

### Yêu cầu

Tạo class `Box<T>` gồm:
- Thuộc tính `Value` kiểu `T`
- Method `IsEmpty()` — trả về `true` nếu `Value` là `null`
- Method `Print()` — in ra giá trị của `Value`

### Test

```csharp
Box<int> hop1 = new Box<int>();
hop1.Value = 100;
hop1.Print();       // 100
hop1.IsEmpty();     // false

Box<string> hop2 = new Box<string>();
hop2.Value = "Xin chào";
hop2.Print();       // Xin chào

Box<string> hop3 = new Box<string>();
hop3.IsEmpty();     // true
```

### Kiến thức áp dụng
- Generic class cơ bản
- `T` dùng làm kiểu thuộc tính

---

## Bài 2: Hoán đổi — `Swap<T>`

### Mô tả
Viết một **method Generic** (không phải class) để hiểu `<T>` có thể dùng ở cấp độ method.

### Yêu cầu

Viết static method:

```csharp
static void Swap<T>(ref T a, ref T b)
```

### Test

```csharp
int x = 5, y = 10;
Swap<int>(ref x, ref y);
Console.WriteLine(x); // 10
Console.WriteLine(y); // 5

string s1 = "Hello", s2 = "World";
Swap<string>(ref s1, ref s2);
Console.WriteLine(s1); // World
Console.WriteLine(s2); // Hello
```

### Kiến thức áp dụng
- Generic method
- Từ khóa `ref`
- `<T>` ở cấp độ method

---

## Bài 3: Stack đơn giản — `MyStack<T>`

### Mô tả
Xây dựng cấu trúc dữ liệu Stack Generic — vào sau ra trước (LIFO).

### Yêu cầu

Tạo class `MyStack<T>` gồm:
- `Push(T item)` — thêm phần tử vào đỉnh stack
- `Pop()` — lấy ra phần tử ở đỉnh (xóa khỏi stack)
- `Peek()` — xem phần tử ở đỉnh (không xóa)
- `IsEmpty()` — kiểm tra stack có rỗng không
- `Count` — số phần tử hiện có

### Test

```csharp
MyStack<int> stack = new MyStack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

stack.Peek();   // 3 (không xóa)
stack.Pop();    // 3 (xóa)
stack.Pop();    // 2 (xóa)
stack.Count;    // 1
stack.IsEmpty();// false
```

### Kiến thức áp dụng
- Generic class thực tế
- `List<T>` bên trong class Generic
- Xử lý exception khi stack rỗng

---

## Bài 4: Cặp giá trị — `Pair<TFirst, TSecond>`

### Mô tả
Tạo class Generic với **2 tham số kiểu** khác nhau cùng lúc.

### Yêu cầu

Tạo class `Pair<TFirst, TSecond>` gồm:
- Thuộc tính `First` kiểu `TFirst`
- Thuộc tính `Second` kiểu `TSecond`
- Constructor đầy đủ tham số
- Method `Print()` — in ra cả hai giá trị
- Method `Swap()` — trả về `Pair<TSecond, TFirst>` đã đổi chỗ

### Test

```csharp
Pair<string, int> p1 = new Pair<string, int>("Long", 21);
p1.Print();   // First: Long | Second: 21

var p2 = p1.Swap();
p2.Print();   // First: 21 | Second: Long

Pair<string, bool> p3 = new Pair<string, bool>("IsAdmin", true);
p3.Print();   // First: IsAdmin | Second: True
```

### Kiến thức áp dụng
- Generic với nhiều tham số kiểu (`TFirst`, `TSecond`)
- Method trả về kiểu Generic

---

## Bài 5: Kho lưu trữ — `IRepository<T>`

### Mô tả
Kết hợp Generic với Interface — áp dụng vào bài toán quản lý thực tế.

### Yêu cầu

**Bước 1** — Tạo interface:

```csharp
interface IRepository<T>
{
    void Add(T item);
    void Remove(T item);
    List<T> GetAll();
    T FindById(int id);
}
```

**Bước 2** — Tạo class `Student`:

```csharp
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }
}
```

**Bước 3** — Implement `StudentRepository : IRepository<Student>`

### Test

```csharp
StudentRepository repo = new StudentRepository();
repo.Add(new Student { Id = 1, Name = "Long", Grade = 8.5 });
repo.Add(new Student { Id = 2, Name = "An", Grade = 7.0 });

repo.GetAll();        // in ra 2 sinh viên
repo.FindById(1);     // trả về Long
repo.Remove(...);     // xóa 1 sinh viên
```

### Kiến thức áp dụng
- Generic interface
- Implement Generic interface vào class cụ thể
- Kết hợp với kiến thức từ Bài 1–4

---

## Thứ tự học đề xuất

```
Bài 1 ──► Bài 2 ──► Bài 3 ──► Bài 4 ──► Bài 5
  │          │          │          │          │
Class      Method     Class      2 kiểu    Interface
Generic    Generic    thực tế    Generic   + Generic
cơ bản
```

### Tại sao theo thứ tự này?

| Bài | Điểm mới so với bài trước |
|-----|--------------------------|
| Bài 1 | `<T>` ở class — nền tảng |
| Bài 2 | `<T>` ở method — khác với class |
| Bài 3 | Dùng `List<T>` bên trong class Generic |
| Bài 4 | Nhiều tham số kiểu `<T1, T2>` |
| Bài 5 | Generic + Interface — thực tế nhất |

---

## Ghi chú chung

- Mỗi bài nên tự code trước, không xem đáp án
- Test đủ các trường hợp: `int`, `string`, class tự tạo
- Bài 3 nên xử lý thêm exception khi `Pop()` stack rỗng
- Bài 5 là nền tảng của pattern **Repository** dùng trong dự án thực tế