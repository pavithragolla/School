using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Models;
using School.Repositories;

namespace School.Controllers;
[ApiController]
[Route("api/class")]
public class ClassController : ControllerBase
{
 private readonly ILogger<ClassController> _logger;
  private readonly IClassRepository _Class;

  private readonly IStudentRepository _student;


 public ClassController(ILogger<ClassController> logger, IClassRepository Class, IStudentRepository student)
 {
     _logger = logger;
     _Class = Class;
     _student = student;
     
 }
 [HttpPost]
     public async Task<ActionResult<ClassDTO>> CreateGuest([FromBody] ClassCreateDTO Data)
    {
        var ToCreateClass = new Class
        {
            Capacity = Data.Capacity,
           
        };
        var CreatedClass = await _Class.Create(ToCreateClass);

        return StatusCode(StatusCodes.Status201Created, CreatedClass.asDto);
    }
 
  [HttpGet("{id}")]

    public async Task<ActionResult<ClassDTO>> GetClassById([FromRoute] int id)
    {

        var Class = await _Class.GetById(id);

        if (Class is null)
            return NotFound("No Class found with given id");


        var dto = Class.asDto;
        dto.Students = (await _student.GetAllForClass(id)).Select(x => x.asDto).ToList();
        return Ok(dto);
    }
     [HttpPut("{id}")]

    public async Task<ActionResult> UpdateClass([FromRoute] int id,
    [FromBody] ClassUpdateDTO Data)
    {
        var existing = await _Class.GetById(id);
        if (existing is null)
            return NotFound("No Class found with given  Id");

        var toUpdateGuest = existing with
        {
           
            Capacity = Data.Capacity,

        };

        var didUpdate = await _Class.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update Class");

        return NoContent();
    }
}
