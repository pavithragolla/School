using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Models;
using School.Repositories;

namespace School.Controllers;
[ApiController]
[Route("api/teacher")]
public class TeacherController : ControllerBase
{
 private readonly ILogger<TeacherController> _logger;
  private readonly ITeacherRepository _Teacher;
  private readonly IStudentRepository _student;


 public TeacherController(ILogger<TeacherController> logger, ITeacherRepository Teacher, IStudentRepository student)
 {
     _logger = logger;
     _Teacher = Teacher;
     _student = student;
     
 }
 [HttpPost]
     public async Task<ActionResult<TeacherDTO>> CreateGuest([FromBody] TeacherCreateDTO Data)
    {
        var ToCreateTeacher = new Teacher
        {
            Name = Data.Name,
            Gender = Data.Gender,
            Mobile = Data.Mobile,
            SubjectId = Data.SubjectId
        };
        var CreatedTeacher = await _Teacher.Create(ToCreateTeacher);

        return StatusCode(StatusCodes.Status201Created, CreatedTeacher.asDto);
    }
 [HttpGet]
    public async Task<ActionResult<List<TeacherDTO>>> GetAllUser()
    {
        var usersList = await _Teacher.GetList();


        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }
  [HttpGet("{id}")]

    public async Task<ActionResult<TeacherDTO>> GetTeacherById([FromRoute] int id)
    {

        var Teacher = await _Teacher.GetById(id);

        if (Teacher is null)
            return NotFound("No Teacher found with given id");


        var dto = Teacher.asDto;
         dto.Student = (await _student.GetAllForTeachers(id)).Select(x => x.asDto).ToList();
        return Ok(dto);
    }

     [HttpPut("{id}")]

    public async Task<ActionResult> UpdateTeacher([FromRoute] int id,
    [FromBody] TeacherUpdateDTO Data)
    {
        var existing = await _Teacher.GetById(id);
        if (existing is null)
            return NotFound("No Teacher found with given  Id");

        var toUpdateGuest = existing with
        {
           
              Mobile =Data.Mobile,
              SubjectId= Data.SubjectId

        };

        var didUpdate = await _Teacher.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update Teacher");

        return NoContent();
    }
}
