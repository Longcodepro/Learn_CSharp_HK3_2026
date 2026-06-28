using Microsoft.AspNetCore.Mvc;
using DapperApi.Models;
using DapperApi.Repositories;

namespace DapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _repo;
    public CourseController(ICourseRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_repo.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var course = _repo.GetById(id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var course = _repo.GetByName(name);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Course course)
    {
        _repo.Create(course);
        return CreatedAtAction(nameof(GetByName), new { name = course.CourseName }, course);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Course course)
    {
        _repo.Update(course);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }
}
