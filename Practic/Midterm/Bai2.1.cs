using System;
using System.Collections.Generic;
using System.Linq;

public class Course1
{
    public long Id {get; set; }
    public string? Title{get; set;}
    public int Credits {get; set;}

    public Course1(long id, string? title, int credits)
    {
        Id = id;
        Title = title;
        Credits =  credits;
    }
}

public static class Bai21
{
    static List<Course1> courses =  new List<Course1>
    {
        new Course1(1, "Lập trình C#", 3),
        new Course1(2, "Cow sở dữ liệu", 4),
        new Course1(4, null, 5),
    };

    public delegate string FormatCourse(Course1 course);

    public static string dinhDangCourseMethod(Course1 course)
    {
        return $"{course.Id} - {course.Title}";
    }
    public static FormatCourse dinhDangCourse{set; get; } = dinhDangCourseMethod;
}
