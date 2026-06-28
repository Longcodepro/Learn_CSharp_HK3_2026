using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Menu();
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Loi: vui long nhap so hop le.");
                Pause();
                continue;
            }

            if (choice == 0)
            {
                return;
            }

            switch (choice)
            {
                case 1:
                    RunBai1();
                    break;
                case 2:
                    RunBai2();
                    break;
                case 3:
                    RunBai3();
                    break;
                case 4:
                    RunBai4();
                    break;
                default:
                    Console.WriteLine($"Loi: khong co bai {choice}.");
                    break;
            }

            Pause();
        }
    }

    private static void Menu()
    {
        Console.WriteLine("Chon bai can chay:");
        Console.WriteLine("1 - Bai 1");
        Console.WriteLine("2 - Bai 2");
        Console.WriteLine("3 - Bai 3");
        Console.WriteLine("4 - Bai 4");
        Console.WriteLine("0 - Thoat");
        Console.Write("Nhap so: ");

    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Nhan Enter de tiep tuc...");
        Console.ReadLine();
        Console.WriteLine();
    }

    private static void RunBai1()
    {
        Console.WriteLine("Bai 1:");
        Console.WriteLine($"IsEvenPositive(8) = {Bai1.IsEvenPositive(8)}");
        Console.WriteLine($"IsMultipleOfThree(9) = {Bai1.IsMultipleOfThree(9)}");
        Console.WriteLine($"CountEvenNumbers(values): ");
        foreach(var d in Bai1.CountEvenNumbers(Bai1.Values) )
        {
            Console.WriteLine(d);
        }
        Console.WriteLine($"GetLargestMultipleOfThree(values) = {Bai1.GetLargestMultipleOfThree(Bai1.Values)}");
        Console.WriteLine($"HasPairWithSum(sortedA, 7) = {Bai1.HasPairWithSum(Bai1.SortedA, 7)}");
        Console.WriteLine($"GetCommonValues(sortedA, sortedB) = [{string.Join(", ", Bai1.GetCommonValues(Bai1.SortedA, Bai1.SortedB))}]");
    }

    private static void RunBai2()
    {
        Console.WriteLine("Bai 2:");
        Console.WriteLine(Bai2.CourseFormatter(Bai2.Courses[0]));
        Console.WriteLine(Bai2.GetCourseTitle(Bai2.Courses[2]));
        Bai2.PrintCourse(Bai2.Courses[1]);

        var coursesWithEnoughCredits = Bai2.GetCoursesWithAtLeastThreeCredits();

        Console.WriteLine($"Courses with credits >= 3: {coursesWithEnoughCredits.Count}");
        foreach (var course in coursesWithEnoughCredits)
        {
            Bai2.PrintCourse(course);
        }
    }

    private static void RunBai3()
    {
        Console.WriteLine("Bai 3:");

        IBooksRepository repository = new BooksRepository();

        Console.WriteLine("All books:");
        foreach (Book book in repository.GetAll())
        {
            Console.WriteLine($"- {book.Id}: {book.Title} ({book.Price})");
        }

        Console.WriteLine("Books cheaper than 60:");
        foreach (Book book in repository.GetBooksCheaperThan(60m))
        {
            Console.WriteLine($"- {book.Id}: {book.Title} ({book.Price})");
        }

        Console.WriteLine("Top 2 expensive books:");
        foreach (Book book in repository.GetTopExpensiveBooks(2))
        {
            Console.WriteLine($"- {book.Id}: {book.Title} ({book.Price})");
        }
    }

    private static void RunBai4()
    {
        Console.WriteLine("Bai 4:");
        string connectionString = ReadConnectionString();
        var repository = new UsersDapperRepository(connectionString);

        try
        {
            PrintUsers("FindNamesEndingWith(\"nh\")", repository.FindNamesEndingWith("nh"));
            PrintUsers("GetUsersWithShortName(3)", repository.GetUsersWithShortName(3));
            Console.WriteLine($"CountNamesContaining(\"in\") = {repository.CountNamesContaining("in")}");
            PrintUsers("GetIdAndNameList()", repository.GetIdAndNameList());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Khong ket noi duoc den SQL Server.");
            Console.WriteLine(ex.Message);
        }
    }

    private static string ReadConnectionString()
    {
        using FileStream stream = File.OpenRead("appsettings.json");
        using JsonDocument document = JsonDocument.Parse(stream);

        JsonElement connectionStrings = document.RootElement.GetProperty("ConnectionStrings");
        return connectionStrings.GetProperty("Lab09Db").GetString() ?? string.Empty;
    }

    private static void PrintUsers(string title, IEnumerable<User> users)
    {
        Console.WriteLine(title + ":");
        foreach (User user in users)
        {
            Console.WriteLine($"- {user.Id}: {user.Name}");
        }
    }

}
