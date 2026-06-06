using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using DapperApi.Models;

namespace DapperApi.Repositories;
public class CourseRepository : ICourseRepository
{
    private readonly string _connStr;
    public CourseRepository(IConfiguration config)
    {
        _connStr = config.GetConnectionString("DefaultConnection")!;
    }

    // Tạo connection mỗi lần gọi
    private IDbConnection NewConnection()
        => new SqlConnection(_connStr);

    // GET ALL
    public IEnumerable<Course> GetAll()
    {
        using var db = NewConnection();
        return db.Query<Course>("SELECT * FROM Courses");
    }

    // GET BY ID
    public Course? GetById(int id)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Course>("SELECT * FROM Courses WHERE Id = @Id", new{ Id = id});
    }

    // GET BY NAME
    public Course? GetByName(string name)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Course>("SELECT * FROM Courses WHERE CourseName = @CourseName", new{CourseName = name});
    }

    // CREATE
    public void Create(Course course)
    {
        using var db = NewConnection();
        db.Execute("INSERT INTO Courses (CourseName) VALUES (@CourseName)", course);
    }

    // UPDATE
    public void Update(Course course)
    {
        using var db = NewConnection();
        db.Execute("UPDATE Courses SET CourseName = @CourseName WHERE Id = @Id", course);
    }

    // DELETE
    public void Delete(int id)
    {
        using var db = NewConnection();
        db.Execute("DELETE FROM Courses WHERE Id = @Id", new {Id = id});
    }
}