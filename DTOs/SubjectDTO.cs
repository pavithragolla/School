namespace School.DTOs;

public record SubjectDTO
{
    public string Name { get; set; }
    public List<TeacherDTO> Teacher {get; set; }
}
public record SubjectCreateDTO
{
    public string Name { get; set; }
}
