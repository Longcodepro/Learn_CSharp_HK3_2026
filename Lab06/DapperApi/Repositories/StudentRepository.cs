using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using DapperApi.Models;
using CourseModel = DapperApi.Models.Course;

namespace DapperApi.Repositories;
public class StudentRepository : IStudentRepository
{
    private readonly string _connStr;
    public StudentRepository(IConfiguration config)
    {
        _connStr = config.GetConnectionString("DefaultConnection")!;
    }

    // Tạo connection mới mỗi lần gọi
    private IDbConnection NewConnection()
        =>new SqlConnection(_connStr);

    // GET ALL
    public IEnumerable<Student> GetAll()
    {
        using var db = NewConnection();
        return db.Query<Student>("SELECT * FROM Students");
    }

    // GET BY ID
    public Student?  GetById(int id)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Student>(
            "SELECT * FROM Students WHERE Id = @Id",
            new { Id = id });
    }

    // CREATE 
    public void Create(Student student)
    {
        using var db = NewConnection();
        db.Execute(
            "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)",
            student);
    }

    // UPDATE
    public void Update(Student student)
    {
        using var db = NewConnection();
        db.Execute(
            "UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id",
            student);
    }

    // DELETE
    public void Delete(int id)
    {
        using var db = NewConnection();
        db.Execute(
            "DELETE FROM Students WHERE Id = @Id",
            new { Id = id });
    }

    // Tìm kiếm sinh viên theo tên (GET)
    public Student? GetByName(string name)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Student>(
            "SELECT * FROM Students WHERE Name = @Name",
            new { Name = name });
    } 

    // GET ALL WITH COURSES (multi-mapping)
    public IEnumerable<StudentWithCourses> GetAllWithCourses()
    {
        var sql = @"
            SELECT s.Id, s.Name, c.Id AS CourseId, c.CourseName
            FROM Students s
            JOIN StudentCourses sc ON s.Id = sc.StudentId
            JOIN Courses c ON sc.CourseId = c.Id
            ORDER BY s.Id";

        using var db = NewConnection();
        var dict = new Dictionary<int, StudentWithCourses>();

        db.Query<StudentWithCourses, Course, StudentWithCourses>(
            sql,
            (student, course) =>    // dùng lamda
            {
                if (!dict.TryGetValue(student.Id, out var existing))
                {
                    existing = student;
                    dict[student.Id] = existing;
                }
                existing.Courses.Add(course);
                return existing;
            },
            splitOn: "CourseId"
        );

        return dict.Values;
    }
}