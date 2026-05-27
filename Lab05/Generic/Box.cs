using System;
using Lab05.Generic;

namespace Lab05.Generic
{
    class Box<T>
    {
        public T Value{set; get;}

        public bool IsEmpty()
        {
            if( Value == null ) return true;
            return false;
        }

        public void Print()
        {
            Console.WriteLine(Value);
        }
    }
}

namespace Lab05.Test
{
    class Test
    {
        public static void Main(string[] args)
        {
            Box<int> hop1 = new Box<int>();
            hop1.Value = 100;
            hop1.Print();
            hop1.IsEmpty();
        }
    }
}