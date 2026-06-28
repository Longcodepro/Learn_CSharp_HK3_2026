using System;
using System.Collections;

namespace Lab03;
class LearnArrayList
{
    public static void Main(string[] args)
    {

        ArrayList al = new ArrayList()
        {
            "Hello",
            1,
            true,
            false,
            "a"
        };

        Console.WriteLine($"ArrayList: {string.Join(", ", al.Cast<object>())}");

        ArrayList listName = new ArrayList()
        {
            "Nam",
            "An",
            "Nguyen",
            "Van",
            "Binh"
        };

        listName.Sort();
        Console.WriteLine($"ListName: {string.Join(", ", listName.Cast<object>())}");
        listName.Reverse();
        Console.WriteLine($"ListName: {string.Join(", ", listName.Cast<object>())}");
    }
}