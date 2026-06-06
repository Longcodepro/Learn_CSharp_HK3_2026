using DapperApi.Models;
namespace DapperApi.Repositories;
public interface ICourseRepository
{
    public IEnumerable<Course> GetAll();
    public Course? GetById(int id);
    void Create(Course course);
    void Update(Course course);
    void Delete(int id);
    Course? GetByName(string name);
}