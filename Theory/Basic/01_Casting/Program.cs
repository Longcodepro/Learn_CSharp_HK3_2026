
using System;
namespace Basic.Casting01
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("-----------------Explicit Casting-----------------");
            long a = 1111;
            long a1 = long.MaxValue;
            int b = (int)a;
            int b1 = (int)a1;
            Console.WriteLine("(long)64bit -> (int)32bit");

            Console.WriteLine($"a({a.GetType()}) = {a}\nb({b.GetType()}) = {b}");
            Console.WriteLine($"a1({a1.GetType()}) = {a1}\nb1({b1.GetType()}) = {b1}");
        }
    }
}