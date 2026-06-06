using Microsoft.AspNetCore.Mvc;
using DapperApi.Models;
using DapperApi.Repositories;

namespace DapperApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _repo;
    public StudentController(IStudentRepository repo)
    {
        _repo = repo;
    }

    // GET /api/student
    [HttpGet]
    public IActionResult GetAll()
        => Ok(_repo.GetAll());

    // GET /api/student/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var student = _repo.GetById(id);
        return student is null ? NotFound() : Ok(student);
    }

    // POST /api/student
    [HttpPost]
    public IActionResult Create([FromBody] Student student)
    {
        _repo.Create(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    // PUT /api/student
    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        _repo.Update(student);
        return NoContent();
    }

    // DELETE /api/student/{id}
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }

    // GET /api/student/{name}
    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var student = _repo.GetByName(name);
        return student is null ? NotFound() : Ok(student);
    }

    // GET /api/students/courses
    [HttpGet("courses")]
    public IActionResult GetAllWithCourses()
        => Ok(_repo.GetAllWithCourses());
}