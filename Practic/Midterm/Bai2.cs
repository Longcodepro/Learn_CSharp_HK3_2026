using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public int Credits { get; set; }

}

public static class Bai2
{
    public delegate string FormatCourse(Course course);

    public static List<Course> Courses { get; } = new List<Course>
    {
        new Course { Id = 1, Title = "Lap trinh C#", Credits = 3 },
        new Course { Id = 2, Title = "Co so du lieu", Credits = 4 },
        new Course { Id = 3, Title = null, Credits = 2 }
    };

    public static string CourseFormatterMethod(Course course)
    {
        return $"{course.Id} - {course.Title}";
    }
    public static FormatCourse CourseFormatter { get; } = CourseFormatterMethod;

    public static Func<Course, string> GetCourseTitle { get; } = course =>
        string.IsNullOrWhiteSpace(course.Title) ? "(chua co ten)" : course.Title;

    public static Action<Course> PrintCourse { get; } = course =>
        Console.WriteLine($"[{course.Id}] {course.Title} - {course.Credits}");

    public static Predicate<Course> HasAtLeastThreeCredits { get; } = course =>
        course.Credits >= 3;

    public static IReadOnlyList<Course> GetCoursesWithAtLeastThreeCredits()
    {
        return Courses.FindAll(HasAtLeastThreeCredits);
    }
}
