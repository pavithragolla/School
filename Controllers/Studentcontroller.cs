using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Models;
using School.Repositories;

namespace School.Controllers;
[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
 private readonly ILogger<StudentController> _logger;
  private readonly IStudentRepository _student;
  private readonly ITeacherRepository _teacher;
  private readonly ISubjectRepository _subject;


 public StudentController(ILogger<StudentController> logger, IStudentRepository student 
 , ITeacherRepository teacher, ISubjectRepository subject
 )
 {
     _logger = logger;
     _student = student;
     _teacher = teacher;
     _subject = subject;
     
 }
 [HttpPost]
     public async Task<ActionResult<StudentDTO>> CreateGuest([FromBody] StudentCreateDTO Data)
    {
        var ToCreateStudent = new Student
        {
            Name = Data.Name,
            DOB = Data.DOB,
            Address = Data.Address,
            Gender = Data.Gender,
            Mobile = Data.Mobile,
            ClassId = Data.ClassId
        };
        var CreatedStudent = await _student.Create(ToCreateStudent);

        return StatusCode(StatusCodes.Status201Created, CreatedStudent.asDto);
    }
 [HttpGet]
    public async Task<ActionResult<List<StudentDTO>>> GetAllUser()
    {
        var usersList = await _student.GetList();


        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }
  [HttpGet("{id}")]

    public async Task<ActionResult<StudentDTO>> GetStudentById([FromRoute] int id)
    {

        var student = await _student.GetById(id);

        if (student is null)
            return NotFound("No student found with given id");


        var dto = student.asDto;
         dto.Teacher = (await _teacher.GetAllForStudents(id)).Select(x => x.asDto).ToList();
         dto.Subject = (await _subject.GetAllForStudent(id)).Select(x => x.asDto).ToList();
         
        return Ok(dto);
    }

     [HttpPut("{id}")]

    public async Task<ActionResult> UpdateStudent([FromRoute] int id,
    [FromBody] StudentUpdateDTO Data)
    {
        var existing = await _student.GetById(id);
        if (existing is null)
            return NotFound("No student found with given  Id");

        var toUpdateGuest = existing with
        {
           
             DOB = Data.DOB,
            Address = Data.Address,
              Mobile =Data.Mobile

        };

        var didUpdate = await _student.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update Student");

        return NoContent();
    }
}
