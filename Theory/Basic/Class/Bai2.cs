

using System;

namespace Basic.Class.Bai2
{
    class Bai2
    {
        public static void Main(String[] args)
        {

            Console.Write("Nhập vào số nguyên dương: ");
            int value = int.Parse(Console.ReadLine() ?? "0");

            int count = 0;
            int tmp = value;
            while (tmp > 0)
            {
                count++;
                tmp/=10;
            }

            Console.WriteLine($"Số chữ số trong số nguyên {value} là: {count}");
        }
    }
}