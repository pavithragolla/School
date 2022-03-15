using School.DTOs;

namespace School.Models;


public record Teacher
{
    public string Name { get; set; }
    public string Gender { get; set; }
    public long Mobile { get; set; }
    public int SubjectId { get; set; }

    public TeacherDTO asDto => new TeacherDTO
    {
        Name = Name,
        Gender = Gender,
        Mobile = Mobile,
        SubjectId = SubjectId
    };
}