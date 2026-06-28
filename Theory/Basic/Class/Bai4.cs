

using System;

namespace Basic.Class.Bai4
{
    class Bai4
    {
        public static void Main(String[] args)
        {
            CauB();
        }

        public static void CauA()
        {

            Console.Write("Nhập vào giá trị của n: " );
            int n = int.Parse(Console.ReadLine() ?? "0");

            int[] a = new int[n];
            for( int i=0; i<n; i++)
            {
                Console.Write($"Nhập vào giá trị thứ {i+1}: ");
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }

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

            for( int i=0; i<n; i++)
            {
                a[i] = rd.Next(1, 100);
            }

            foreach(int x in a) Console.Write($"{x} ");
            Console.WriteLine();
        }
    }
}