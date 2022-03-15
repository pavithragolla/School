using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Models;
using School.Repositories;

namespace School.Controllers;
[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
 private readonly ILogger<SubjectController> _logger;
  private readonly ISubjectRepository _Subject;
  private readonly ITeacherRepository _teacher;


 public SubjectController(ILogger<SubjectController> logger, ISubjectRepository Subject, ITeacherRepository teacher)
 {
     _logger = logger;
     _Subject = Subject;
     _teacher = teacher;
     
 }
 [HttpPost]
     public async Task<ActionResult<SubjectDTO>> CreateSubject([FromBody] SubjectCreateDTO Data)
    {
        var ToCreateSubject = new Subject
        {
            Name = Data.Name,
           
        };
        var CreatedSubject = await _Subject.Create(ToCreateSubject);

        return StatusCode(StatusCodes.Status201Created, CreatedSubject.asDto);
    }
 [HttpGet]
    public async Task<ActionResult<List<SubjectDTO>>> GetAllUser()
    {
        var usersList = await _Subject.GetList();


        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }
  [HttpGet("{id}")]

    public async Task<ActionResult<SubjectDTO>> GetSubjectById([FromRoute] int id)
    {

        var Subject = await _Subject.GetById(id);

        if (Subject is null)
            return NotFound("No Subject found with given id");


        var dto = Subject.asDto;
         dto.Teacher = (await _teacher.GetAllForSubject(id)).Select(x => x.asDto).ToList();
        return Ok(dto);
    }
}
