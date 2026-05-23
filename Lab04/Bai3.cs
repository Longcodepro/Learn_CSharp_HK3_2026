/*
Câu 1:
Animal myPet = new Dog () ;
myPet . MakeSound () ;
=> dự đoán output: Dog braks

Câu 2:
    new: tạo ra một method mới nhưng bị trùng tên với một method của cha
    => tránh bị nhầm lẫn (Cách hoạt động sẽ như bên dưới)
    override: định nghĩa lại cái method của cha 
    => hoạt động sẽ như ở Bài 2

Câu 3:
    Khi gọi virtual method trong constructor lớp cha, tính đa hình sẽ 
    kích hoạt phương thức override ở lớp con ngay lập tức. Đây là một
    Bad Practice vì tại thời điểm đó, lớp con chưa được chạy constructor, 
    dẫn đến các trường dữ liệu của lớp con chưa được khởi tạo (bằng null), 
    rất dễ gây ra lỗi NullReferenceException phá hỏng chương trình

Câu 4:
    => giải pháp nên dùng try catch để hứng lỗi hoặc có thể dùng interface cho những lớp 
    con có tiếng kêu (tách method MakeSoud của Animal ra) 
*/

using System;
namespace Lab04;
class Bai3
{
    public static void Main(string[] args)
    {
        // Câu 2
        Animal myPet = new Dog1();
        Console.WriteLine("Câu 2: ");
        myPet.MakeSound(); // => output: gọi method MakeSound ở class cha

        // Câu 4
        Console.WriteLine("\nCâu 4: ");
        List<Animal> animalList = new List<Animal> { new Cat(), new Dog(), new Dog2() };

        foreach (var animal in animalList)
        {
            try
            {
                // Chạy bình thường cho đến khi gặp Bird
                animal.MakeSound(); 
            }
            catch (NotImplementedException ex)
            {
                // Hứng lỗi riêng của Bird, ghi log ra màn hình và KHÔNG làm sập chương trình
                Console.WriteLine($"[Lỗi] Con vật này chưa được code chức năng kêu: {ex.Message}");
            }
        }
    }
}

class Dog1 : Animal
{
    public new void MakeSound()
    {
        Console.WriteLine("Gâu gâu");
    }
}
class Dog2 : Animal
{
    // ghi đè và ném ra ngoại lệ => nếu không hứng lỗi sẽ bị crash chương trình
    public override void MakeSound() 
    {
        // Chủ động ném ra lỗi vì chưa viết xong logic cho Chó sủa
        throw new NotImplementedException("Chức năng sủa chưa được lập trình!"); 
    }
}

