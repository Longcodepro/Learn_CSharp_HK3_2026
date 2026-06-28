using System;
using System.ComponentModel;
namespace Lab04;

class Bai1
{
    public static void Main(string[] args)
    {

        HandleMultipleExceptions("123", 2);
        HandleMultipleExceptions("123a", 6);
        HandleMultipleExceptions("123", 9);
    }

    public static void HandleMultipleExceptions(string input, int index)
    {
        int[] numbers = {1, 2, 3};
        try
        {
            int parseValue = int.Parse(input);
            Console.WriteLine(numbers[index]);
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid format");
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Index out of range");
        }
    }
}