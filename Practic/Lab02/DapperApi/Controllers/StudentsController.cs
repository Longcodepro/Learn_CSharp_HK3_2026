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

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_repo.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var student = _repo.GetById(id);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Student student)
    {
        _repo.Create(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        _repo.Update(student);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var student = _repo.GetByName(name);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpGet("courses")]
    public IActionResult GetAllWithCourses()
        => Ok(_repo.GetAllWithCourses());
}