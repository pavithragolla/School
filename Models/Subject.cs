using School.DTOs;

namespace School.Models;

public record Subject
{
    public string Name { get; set; }

    public SubjectDTO asDto => new SubjectDTO
    {
        Name = Name,
    };
}