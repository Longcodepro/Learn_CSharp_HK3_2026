using System;

namespace Lab03;

class LearnList
{
    public static void Main(string[] args)
    {

        List<int> intList = {1, 2, 3, 4};

        Console.WriteLine($"intList: {string.Join(", ", intList)}");
    }
}