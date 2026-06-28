# Xây dựng ứng dụng trắc nghiệm Console bằng C#

**Môn:** Lập trình C#

## 1. Mục tiêu

Sinh viên xây dựng một ứng dụng trắc nghiệm chạy trên Console bằng C#. Yêu cầu áp dụng lập trình hướng đối tượng, quản lý danh sách câu hỏi, xử lý nhập liệu, chấm điểm, dùng interface, đa hình và generic.

## 2. Sản phẩm yêu cầu

Dự án nên có cấu trúc tối thiểu như sau:

```text
MyQuizApp/
|-- Program.cs
|-- IQuestion.cs
|-- MultipleChoiceQuestion.cs
|-- TrueFalseQuestion.cs
|-- QuestionBank.cs
|-- AnswerRecord.cs
+-- Quiz.cs
```

Có thể tách thêm file nếu cần, nhưng tên class và trách nhiệm của class phải rõ ràng.

## 3. Yêu cầu về mã nguồn

1. Chương trình phải chạy được bằng lệnh `dotnet run` hoặc chạy trực tiếp trong Visual Studio/VS Code.
2. Không viết toàn bộ logic trong `Program.cs`. File `Program.cs` chỉ nên khởi tạo dữ liệu và gọi chương trình chính.
3. Phải sử dụng class, property, constructor và method.
4. Phải có đóng gói dữ liệu: field quan trọng không để public trực tiếp.
5. Phải có ít nhất một interface và ít nhất hai class triển khai interface đó.
6. Phải thể hiện tính đa hình khi xử lý danh sách câu hỏi.
7. Phải có ít nhất một class generic.
8. Phải kiểm tra nhập liệu của người dùng, không để chương trình bị dừng đột ngột khi nhập sai.
9. Không dùng thư viện ngoài. Chỉ dùng thư viện chuẩn của .NET.
10. Mỗi câu hỏi trong bài lab tương ứng 1 điểm. Tổng điểm: 10 điểm.

## 4. Ví dụ hoạt động mong muốn

```text
===== QUIZ CONSOLE APP =====
Cau 1: Tu khoa nao dung de khai bao class trong C#?
1. struct
2. class
3. object
4. method
Nhap lua chon cua ban: 2
Ket qua: Dung!

Cau 2: C# la ngon ngu lap trinh huong doi tuong? (Y/N)
Nhap lua chon cua ban: y
Ket qua: Dung!

Diem cuoi cung: 8/10
Xep loai: Kha
```

Nội dung câu hỏi có thể khác ví dụ, nhưng chương trình phải hiển thị rõ câu hỏi, nhận câu trả lời, báo đúng/sai và tổng kết điểm.

## 6. Yêu cầu

### Câu 1. Khởi tạo dự án và dữ liệu mẫu

Tạo một Console Application bằng C#. Chương trình phải có ít nhất 10 câu hỏi mẫu liên quan đến C#, OOP hoặc kiến thức lập trình cơ bản. Mỗi câu hỏi phải có dữ liệu đủ để chương trình kiểm tra đúng/sai.

### Câu 2. Class câu hỏi trắc nghiệm

Tạo class `MultipleChoiceQuestion`. Class này cần lưu nội dung câu hỏi, danh sách đáp án và chỉ số đáp án đúng. Class phải có constructor và phương thức kiểm tra câu trả lời.

Ví dụ ý tưởng:

```csharp
var question = new MultipleChoiceQuestion(
    "Tu khoa nao dung de tao class trong C#?",
    new List<string> { "struct", "class", "namespace", "using" },
    2
);
```

Trong ví dụ trên, đáp án đúng là lựa chọn số 2.

### Câu 3. Class quản lý quiz

Tạo class `Quiz` để quản lý quá trình làm bài. Class này cần hiển thị từng câu hỏi, nhận câu trả lời từ Console, kiểm tra đúng/sai và cộng điểm.

### Câu 4. Kiểm tra nhập liệu

Khi người dùng nhập sai định dạng, bỏ trống hoặc nhập số ngoài phạm vi đáp án, chương trình phải yêu cầu nhập lại. Không được để chương trình dừng do lỗi nhập liệu.

Ví dụ:

```text
Nhap lua chon cua ban: abc
Gia tri khong hop le. Vui long nhap lai.
Nhap lua chon cua ban: 9
Lua chon nam ngoai pham vi. Vui long nhap lai.
```

### Câu 5. Tổng kết điểm

Sau khi hoàn thành tất cả câu hỏi, chương trình phải hiển thị: tổng số câu, số câu đúng, số câu sai, điểm số và xếp loại.

Gợi ý xếp loại:

- Từ 80% trở lên: Giỏi
- Từ 65% trở lên: Khá
- Từ 50% trở lên: Trung bình
- Còn lại: Cần cố gắng

### Câu 6. Interface

Tạo interface `IQuestion` mô tả hành vi chung của một câu hỏi. Interface nên có các thành phần cần thiết để hiển thị câu hỏi, đọc câu trả lời hợp lệ và kiểm tra đúng/sai.

### Câu 7. Đa hình với nhiều loại câu hỏi

Tạo thêm class `TrueFalseQuestion` hoặc một loại câu hỏi khác. Class mới phải triển khai `IQuestion`. Trong class `Quiz`, xử lý danh sách câu hỏi thông qua kiểu `IQuestion`, không xử lý riêng từng class bằng nhiều khối `if` không cần thiết.

### Câu 8. Generic question bank

Tạo class generic `QuestionBank<T>` để quản lý danh sách câu hỏi. Class này cần có ràng buộc kiểu phù hợp và có ít nhất hai phương thức: thêm câu hỏi và lấy danh sách câu hỏi.

Ví dụ sử dụng:

```csharp
var bank = new QuestionBank<IQuestion>();
bank.Add(question);
var questions = bank.GetAll();
```

### Câu 9. Hiển thị câu trả lời sai gần nhất

Sau khi làm bài xong, chương trình hiển thị tối đa 3 câu trả lời sai gần nhất. Mỗi dòng cần có số thứ tự câu, nội dung câu hỏi, câu trả lời sinh viên đã chọn và đáp án đúng.

Ví dụ:

```text
3 cau sai gan nhat:
- Cau 9: ... | Ban chon: ... | Dap an dung: ...
- Cau 7: ... | Ban chon: ... | Dap an dung: ...
```

### Câu 10. Đoạn trả lời đúng liên tiếp dài nhất

Sau khi làm bài xong, chương trình tìm đoạn câu trả lời đúng liên tiếp dài nhất trong toàn bộ lượt làm bài. Nếu không có câu đúng nào, in thông báo phù hợp.

Ví dụ:

```text
Doan dung lien tiep dai nhat: tu cau 4 den cau 7, tong cong 4 cau.
```
