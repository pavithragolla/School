using School.DTOs;

namespace School.Models;
public record Student
{
    public string Name { get; set; }
    public DateTimeOffset DOB { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public long Mobile { get; set; }
    public int ClassId { get; set; }

public StudentDTO asDto => new StudentDTO
{
    Name = Name,
    DOB = DOB,
    Address = Address,
    Gender = Gender,
    Mobile = Mobile,
    ClassId = ClassId
};

}
