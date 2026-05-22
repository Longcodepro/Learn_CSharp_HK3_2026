using System;

namespace Lab03;

class LearnList
{
    public static void Main(string[] args)
    {
        // tạo một list
        List<int> intList = {1, 2, 3, 4};
        
        // duyệt list 
        Console.WriteLine($"intList: {string.Join(", ", intList)}");
    }
}