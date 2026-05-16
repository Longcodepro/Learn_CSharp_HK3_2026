// nhập một số nguyên dương và đếm chữ số ở trong nó

using System;

namespace Basic.Class
{
    class Bai2
    {
        public static void Main(String[] args)
        {
            // nhập giá trị
            Console.Write("Nhập vào số nguyên dương: ");
            int value = int.Parse(Console.ReadLine() ?? "0");

            // dùng loop để đếm chữ số
            int count = 0;
            int tmp = value;
            while (tmp > 0)
            {
                count++;
                tmp/=10;
            }

            // output
            Console.WriteLine($"Số chữ số trong số nguyên {value} là: {count}");
        }
    }
}