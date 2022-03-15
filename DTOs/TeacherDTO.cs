namespace School.DTOs;

public record TeacherDTO
{
 public string Name { get; set; }
    public string Gender { get; set; }
    public long Mobile { get; set; }
    public int SubjectId { get; set; }

    public List<StudentDTO> Student{ get; set; }
}
public record TeacherCreateDTO
{
 public string Name { get; set; }
    public string Gender { get; set; }
    public long Mobile { get; set; }
    public int SubjectId { get; set; }
}

public record TeacherUpdateDTO
{

    public long Mobile { get; set; }
    public int SubjectId { get; set; }
}