// nhập một số nguyên dương và đếm chữ số ở trong nó

using System;

namespace Basic.Class
{
    class Bai4
    {
        public static void Main(String[] args)
        {
            CauB();
        }

        public static void CauA()
        {
            // input 
            Console.Write("Nhập vào giá trị của n: " );
            int n = int.Parse(Console.ReadLine() ?? "0");

            int[] a = new int[n];
            for( int i=0; i<n; i++)
            {
                Console.Write($"Nhập vào giá trị thứ {i+1}: ");
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }

            // output
            foreach(int x in a)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }

        public static void CauB()
        {
            int n = 15;
            int[] a = new int[n];

            Random rd = new Random();

            // chọn số ngãu nhiên trong [1, 100]
            for( int i=0; i<n; i++)
            {
                a[i] = rd.Next(1, 100);
            } 

            // output
            foreach(int x in a) Console.Write($"{x} ");
            Console.WriteLine();
        }
    }
}