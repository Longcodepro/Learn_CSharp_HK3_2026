using DapperApi.Models;

namespace DapperApi.Models;
public class StudentWithCourses
{
    public int Id {set; get;}
    public string Name {get; set; } = string .Empty;
    public List<Course> Courses { get; set; } = new();
}