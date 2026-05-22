using System;
using System.Collections;

namespace Lab03;
class LearnArrayList
{
    public static void Main(string[] args)
    {
        // khai báo: ArrayList có thể chưa nhiều kiểu dữ liệu khá tạp nham
        ArrayList al = new ArrayList()
        {
            "Hello",
            1,
            true,
            false,
            "a"
        }; 
                // arraylist sẽ chuyển các phần tử thành object (kiểu dữ liệu nguyên thủy)
                // và mỗi lần đưa vô thì phải boxing và lấy ra thì phả unboxing nó


        // duyệt bằng Lambda
        Console.WriteLine($"ArrayList: {string.Join(", ", al.Cast<object>())}");


        ArrayList listName = new ArrayList()
        {
            "Nam",
            "An",
            "Nguyen",
            "Van",
            "Binh"
        };

        // sort
        listName.Sort();
        Console.WriteLine($"ListName: {string.Join(", ", listName.Cast<object>())}");
        listName.Reverse();
        Console.WriteLine($"ListName: {string.Join(", ", listName.Cast<object>())}");
    }
}