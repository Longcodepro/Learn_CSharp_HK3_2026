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

    private IDbConnection NewConnection()
        => new SqlConnection(_connStr);

    public IEnumerable<Course> GetAll()
    {
        using var db = NewConnection();
        return db.Query<Course>("SELECT * FROM Courses");
    }

    public Course? GetById(int id)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Course>("SELECT * FROM Courses WHERE Id = @Id", new{ Id = id});
    }

    public Course? GetByName(string name)
    {
        using var db = NewConnection();
        return db.QuerySingleOrDefault<Course>("SELECT * FROM Courses WHERE CourseName = @CourseName", new{CourseName = name});
    }

    public void Create(Course course)
    {
        using var db = NewConnection();
        db.Execute("INSERT INTO Courses (CourseName) VALUES (@CourseName)", course);
    }

    public void Update(Course course)
    {
        using var db = NewConnection();
        db.Execute("UPDATE Courses SET CourseName = @CourseName WHERE Id = @Id", course);
    }

    public void Delete(int id)
    {
        using var db = NewConnection();
        db.Execute("DELETE FROM Courses WHERE Id = @Id", new {Id = id});
    }
}